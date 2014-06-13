using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Al.Database
{
    public class DatabaseApi
    {
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

        public struct COLUMN_CONSTRAIN_S
        {
            public PRIMARY_KEY_T PrimaryKey;
            public Boolean bNotNull;
            public Boolean bUnique;
            public String strDefaultValue;
            public FOREIGN_KEY_S ForeignKey;
        }

        public struct COLUMN_DEF_S
        {
            public String strColumnName;
            public COLUMN_CONSTRAIN_S Costrnt;
        }

        public struct COLUMN_DATA_S
        {
            public String strColumnName;
            public String strValue;
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
            public String strValue1;
            public String strValue2;       //  Only in use when Operator is BETWEEN.
        }


        //
        //  SQLite command format.
        //
        /// <summary>
        /// {0}: table-name
        /// {1}: COLUMN_DEFIN_FMT(s)
        /// </summary>
        private const String CREATE_TABLE_FMT = "CREATE TABLE IF NOT EXISTS {0} ({1})";

        /// <summary>
        /// {0}: column-name
        /// {1}: COLUMN_CONSTRAINT_FMT
        /// </summary>
        private const String COLUMN_DEFIN_FMT = "{0} {1}";

        /// <summary>
        /// {0}: PRIMARY_KEY_FMT
        /// {1}: NOT_NULL_TAG
        /// {2}: UNIQUE_TAG
        /// {3}: DEFAULT_VALUE_FMT
        /// {4}: FOREIGN_KEY_FMT
        /// </summary>
        private const String COLUMN_CONSTRAINT_FMT = "{0} {1} {2} {3} {4}";

        /// <summary>
        /// {0}: ASC_TAG/DESC_TAG
        /// {1}: AUTOINCREMENT_TAG
        /// </summary>
        private const String PRIMARY_KEY_FMT = "PRIMARY KEY {0} {1}";

        /// <summary>
        /// {0}: The default value.
        /// </summary>
        private const String DEFAULT_VALUE_FMT = "DEFAULT {0}";

        /// <summary>
        /// {0}: References table-name.
        /// {1}: column-name(s)
        /// </summary>
        private const String FOREIGN_KEY_FMT = "REFERENCES {0} ({1})";

        //
        //  SQLite command tag.
        //
        private const String ASC_TAG = "ASC";
        private const String DESC_TAG = "DESC";
        private const String AUTOINCREMENT_TAG = "AUTOINCREMENT";
        private const String NOT_NULL_TAG = "NOT NULL";
        private const String UNIQUE_TAG = "UNIQUE";


        private SQLiteConnection m_sqliteConn;
        private SQLiteCommand m_sqliteCmd;
        private String m_strDbFullPath;
        private String m_strPassword;

        public DatabaseApi(String strDbFullPath, String strPassword)
        {
            m_strDbFullPath = strDbFullPath;
            m_strPassword = strPassword;

            //SQLiteConnectionStringBuilder sqliteConnString = new SQLiteConnectionStringBuilder();

            //sqliteConnString.DataSource = strDbFullPath;
            //sqliteConnString.Password = strPassword;

            //m_sqliteConn = new SQLiteConnection(sqliteConnString.ToString());
        }

        ~DatabaseApi()
        {
        }

        public void createTable(String strTableName, COLUMN_DEF_S[] ColumnDef)
        {
            String strColumnDef = "";
            String strColumnConstraint;
            String strPrimaryKey;
            String strDefaultValue;
            String strForeignKey;
            int i;

            for (i = 0; i < ColumnDef.Length; i++)
            {
                COLUMN_CONSTRAIN_S ColCostrnt = ColumnDef[i].Costrnt;

                //  Foreign key
                String strColumnList = "";
                int iCol;
                for (iCol = 0; iCol < ColCostrnt.ForeignKey.strColumnName.Length; iCol++)
                    strColumnList += ColCostrnt.ForeignKey.strColumnName[iCol];
                
                strForeignKey = String.Format(FOREIGN_KEY_FMT, ColCostrnt.ForeignKey.strForeignTable, strColumnList);
                
                //  Default value
                strDefaultValue = String.Format(DEFAULT_VALUE_FMT, ColCostrnt.strDefaultValue);

                //  Primary key
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
                strColumnDef = strColumnDef + " " + String.Format(
                    COLUMN_DEFIN_FMT,
                    ColumnDef[i].strColumnName,
                    strColumnConstraint
                );
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
