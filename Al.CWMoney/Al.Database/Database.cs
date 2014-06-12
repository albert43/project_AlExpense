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
        /// AUTOINCREASE: The primary key value is autoincreased.
        /// AUTODECREASE: The primary key value is autodecreased.
        /// </summary>
        public enum PRIMARY_KEY_T
        {
            NONE,
            NOT_AUTO,
            AUTOINCREASE,
            AUTODECREASE
        }

        public struct FOREIGN_KEY_S
        {
            String strForeignTable;
            String[] strColumnName;
        }

        public struct COLUMN_CONSTRAIN_S
        {
            PRIMARY_KEY_T PrimaryKey;
            Boolean bNotNull;
            Boolean bUnique;
            String strDefaultValue;
            FOREIGN_KEY_S ForeignKey;
        }

        public struct COLUMN_DEF_S
        {
            String strColumnName;
            COLUMN_CONSTRAIN_S Costrnt;
        }

        public struct COLUMN_DATA_S
        {
            String strColumnName;
            String strValue;
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
            String strColumnName;
            RELATION_OP_T Operator;
            String strValue1;
            String strValue2;       //  Only in use when Operator is BETWEEN.
        }

        private String m_strDbFullPath;
        private String m_strPassword;

        public DatabaseApi(String strDbFullPath, String strPassword)
        {
            m_strDbFullPath = strDbFullPath;
            m_strPassword = strPassword;
        }

        public ~DatabaseApi()
        {
        }

        public void createTable(String strTableName, COLUMN_DEF_S[] ColumnDef)
        {
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
