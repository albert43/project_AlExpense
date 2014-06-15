using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Data.SQLite;

namespace Al.Database
{
    public class DatabaseApi
    {
        /// <summary>
        /// The column definition.
        /// </summary>
        public struct COLUMN_DEF_S
        {
            public String strColumnName;
            public DATA_T DataType;
            public COLUMN_CONSTRAIN_S Costrnt;
        }

        public struct COLUMN_CONSTRAIN_S
        {
            public PRIMARY_KEY_T PrimaryKey;
            public Boolean bNotNull;
            public Boolean bUnique;
            public Data DefaultValue;
            public FOREIGN_KEY_S ForeignKey;
        }

        /// <summary>
        /// NONE: It's not primary key.
        /// NOT_AUTO: The primary key value doesn't be auto-assigned.
        /// AUTO_INCREASE: The primary key value is autoincreased.
        /// AUTO_DECREASE: The primary key value is autodecreased.
        /// </summary>
        public enum PRIMARY_KEY_T
        {
            NONE,
            NOT_AUTO,
            AUTO_INCREASE,
            AUTO_DECREASE
        }

        public struct FOREIGN_KEY_S
        {
            public String strForeignTable;
            public String[] strColumnName;
        }


        public struct COLUMN_DATA_S
        {
            public String strColumnName;
            public Data Value;
        }

        public enum RELATION_OP_T
        {
            LARGE_THAN,
            LESS_THAN,
            EQUAL_TO,
            BETWEEN
        }

        public struct SELECT_EXPRES_S
        {
            public String strColumnName;
            public RELATION_OP_T Operator;
            public Data Value1;
            public Data Value2;       //  Only in use when Operator is BETWEEN.
        }

        public enum DATA_T
        {
            INTEGER,
            DOUBLE,
            BOOLEAN,
            DATETIME,
            STRING
        }

        public class Data
        {
            private DATA_T m_Type;

            public Int32 m_i { set; get; }
            public Double m_d { set; get; }
            public Boolean m_b { set; get; }
            public DateTime m_dt { set; get; }
            public String m_str { set; get; }

            public Data(DATA_T Type)
            {
                m_Type = Type;
                m_str = "";
            }

            public Int32 ToInt32()
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        return m_i;
                    case DATA_T.DOUBLE:
                        return Convert.ToInt32(m_d);
                    case DATA_T.BOOLEAN:
                        return Convert.ToInt32(m_b);
                    case DATA_T.DATETIME:
                        return Convert.ToInt32(m_dt);
                    case DATA_T.STRING:
                        return Convert.ToInt32(m_str);
                }

                return m_i;
            }

            public Double ToDouble()
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        return Convert.ToDouble(m_i);
                    case DATA_T.DOUBLE:
                        return m_d;
                    case DATA_T.BOOLEAN:
                        return Convert.ToDouble(m_b);
                    case DATA_T.DATETIME:
                        return Convert.ToDouble(m_dt);
                    case DATA_T.STRING:
                        return Convert.ToDouble(m_str);
                }

                return m_d;
            }

            public Boolean ToBoolean()
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        return Convert.ToBoolean(m_i);
                    case DATA_T.DOUBLE:
                        return Convert.ToBoolean(m_d);
                    case DATA_T.BOOLEAN:
                        return m_b;
                    case DATA_T.DATETIME:
                        return Convert.ToBoolean(m_dt);
                    case DATA_T.STRING:
                        return Convert.ToBoolean(m_str);
                }

                return m_b;
            }

            public DateTime ToDateTime()
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        return Convert.ToDateTime(m_i);
                    case DATA_T.DOUBLE:
                        return Convert.ToDateTime(m_d);
                    case DATA_T.BOOLEAN:
                        return Convert.ToDateTime(m_b);
                    case DATA_T.DATETIME:
                        return m_dt;
                    case DATA_T.STRING:
                        return Convert.ToDateTime(m_str);
                }

                return m_dt;
            }

            public override String ToString()
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        return Convert.ToString(m_i);
                    case DATA_T.DOUBLE:
                        return Convert.ToString(m_d);
                    case DATA_T.BOOLEAN:
                        return Convert.ToString(m_b);
                    case DATA_T.DATETIME:
                        return Convert.ToString(m_dt);
                    case DATA_T.STRING:
                        return m_str;
                }

                return m_str;
            }

            //  Set methods.
            public void Set(int Val) { setValue<Int32>(Val); }
            public void Set(Double Val) { setValue<Double>(Val); }
            public void Set(Boolean Val) { setValue<Boolean>(Val); }
            public void Set(DateTime Val) { setValue<DateTime>(Val); }
            public void Set(String Val) { setValue<String>(Val); }

            /// <summary>
            /// Set the val depend on the DATA_T
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="Val"></param>
            private void setValue<T>(T Val)
            {
                switch (m_Type)
                {
                    case DATA_T.INTEGER:
                        m_i = Convert.ToInt32(Val);
                        break;
                    case DATA_T.DOUBLE:
                        m_d = Convert.ToDouble(Val);
                        break;
                    case DATA_T.BOOLEAN:
                        m_b = Convert.ToBoolean(Val);
                        break;
                    case DATA_T.DATETIME:
                        m_dt = Convert.ToDateTime(Val);
                        break;
                    case DATA_T.STRING:
                        m_str = Convert.ToString(Val);
                        break;
                }
            }
        }

        //
        //  SQLite command format.
        //
        /// <summary>
        /// {0}: table-name
        /// {1}: COLUMN_DEFIN_FMT(s)
        /// </summary>
        private readonly String CREATE_TABLE_FMT = "CREATE TABLE IF NOT EXISTS {0} ({1})";

        /// <summary>
        /// {0}: column-name
        /// {1}: data-type
        /// {2}: COLUMN_CONSTRAINT_FMT
        /// </summary>
        private readonly String COLUMN_DEFIN_FMT = "{0} {1} {2}";

        /// <summary>
        /// {0}: PRIMARY_KEY_FMT
        /// {1}: NOT_NULL_TAG
        /// {2}: UNIQUE_TAG
        /// {3}: DEFAULT_VALUE_FMT
        /// {4}: FOREIGN_KEY_FMT
        /// </summary>
        private readonly String COLUMN_CONSTRAINT_FMT = "{0} {1} {2} {3} {4}";

        /// <summary>
        /// {0}: ASC_TAG/DESC_TAG
        /// {1}: AUTOINCREMENT_TAG
        /// </summary>
        private readonly String PRIMARY_KEY_FMT = "PRIMARY KEY {0} {1}";

        /// <summary>
        /// {0}: The default value.
        /// </summary>
        private readonly String DEFAULT_VALUE_FMT = "DEFAULT {0}";

        /// <summary>
        /// {0}: References table-name.
        /// {1}: column-name(s)
        /// </summary>
        private readonly String FOREIGN_KEY_FMT = "REFERENCES {0} ({1})";

        //
        //  SQLite command tag.
        //
        private readonly String ASC_TAG = "ASC";
        private readonly String DESC_TAG = "DESC";
        private readonly String AUTOINCREMENT_TAG = "AUTOINCREMENT";
        private readonly String NOT_NULL_TAG = "NOT NULL";
        private readonly String UNIQUE_TAG = "UNIQUE";
        private readonly String[] DATA_TYPE_TAGS = new String[5] { "INTEGER", "REAL", "INTEGER", "STRING", "STRING" };

        private SQLiteConnection m_sqliteConn;
        private SQLiteCommand m_sqliteCmd;
        private String m_strDbFullPath;
        private String m_strPassword;

        public DatabaseApi(String strDbFullPath, String strPassword)
        {
            m_strDbFullPath = strDbFullPath;
            m_strPassword = strPassword;

            SQLiteConnectionStringBuilder sqliteConnString = new SQLiteConnectionStringBuilder();

            sqliteConnString.DataSource = strDbFullPath;
            if ((strPassword != null) && (strPassword.Length > 0))
                sqliteConnString.Password = strPassword;

            String str = sqliteConnString.ToString();
            m_sqliteConn = new SQLiteConnection("Data source=database.db");
        }

        ~DatabaseApi()
        {
        }

        public void createTable(String strTableName, COLUMN_DEF_S[] ColumnDef)
        {
            String strColumnDef = null;
            String strColumnConstraint = null;
            String strPrimaryKey = null;
            String strDefaultValue = null;
            String strForeignKey = null;
            int i;

            for (i = 0; i < ColumnDef.Length; i++)
            {
                COLUMN_CONSTRAIN_S ColCostrnt = ColumnDef[i].Costrnt;

                //  Foreign key
                if (ColCostrnt.ForeignKey.strForeignTable != null)
                {
                    String strColumnList = "";
                    if (ColCostrnt.ForeignKey.strColumnName != null)
                    {
                        for (int iCol = 0; iCol < ColCostrnt.ForeignKey.strColumnName.Length; iCol++)
                            strColumnList += ColCostrnt.ForeignKey.strColumnName[iCol];
                    }
                    strForeignKey = String.Format(FOREIGN_KEY_FMT, ColCostrnt.ForeignKey.strForeignTable, strColumnList);
                }

                //  Default value
                if (ColCostrnt.DefaultValue != null)
                {
                    strDefaultValue = String.Format(DEFAULT_VALUE_FMT, ColCostrnt.DefaultValue);
                }

                //  Primary key: ColCostrnt.PrimaryKey is always true that haven't not be check.
                switch (ColCostrnt.PrimaryKey)
                {
                    case PRIMARY_KEY_T.AUTO_INCREASE:
                        strPrimaryKey = String.Format(PRIMARY_KEY_FMT, ASC_TAG, AUTOINCREMENT_TAG);
                        break;
                    case PRIMARY_KEY_T.AUTO_DECREASE:
                        strPrimaryKey = String.Format(PRIMARY_KEY_FMT, DESC_TAG, AUTOINCREMENT_TAG);
                        break;
                    case PRIMARY_KEY_T.NOT_AUTO:
                        strPrimaryKey = String.Format(PRIMARY_KEY_FMT, null, null);
                        break;
                    case PRIMARY_KEY_T.NONE:
                    default:
                        strPrimaryKey = null;
                        break;
                }

                //  Column constraint.
                strColumnConstraint = String.Format(
                    COLUMN_CONSTRAINT_FMT, 
                    strPrimaryKey, 
                    ColCostrnt.bNotNull == true ? NOT_NULL_TAG : null,
                    ColCostrnt.bUnique == true ? UNIQUE_TAG : null,
                    strDefaultValue,
                    strForeignKey
                );
                
                //  Column define(s)
                if (strColumnDef == null)
                {
                    strColumnDef = String.Format(
                        COLUMN_DEFIN_FMT,
                        ColumnDef[i].strColumnName, 
                        DATA_TYPE_TAGS[(int)ColumnDef[i].DataType], 
                        strColumnConstraint);
                }
                else
                {
                    strColumnDef = strColumnDef + "," + String.Format(
                        COLUMN_DEFIN_FMT,
                        ColumnDef[i].strColumnName,
                        DATA_TYPE_TAGS[(int)ColumnDef[i].DataType], 
                        strColumnConstraint);
                }
            }   //  End of Column Define loop.

            //  Execute the command.
            m_sqliteConn.Open();
            m_sqliteCmd = m_sqliteConn.CreateCommand();
            m_sqliteCmd.CommandText = String.Format(CREATE_TABLE_FMT, strTableName, strColumnDef);
            m_sqliteCmd.ExecuteNonQuery();
        }

        public void insertData(String strTableName, COLUMN_DATA_S[] Value)
        {
        }

        public void deleteData(String strTableName, SELECT_EXPRES_S[] Exp)
        {
        }

        public void selectData(String strTableName, SELECT_EXPRES_S[] Exp)
        {
        }

        public void commit()
        {
        }

        public void revert()
        {
        }
    }
}
