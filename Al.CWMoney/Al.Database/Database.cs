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

        public struct FOREIGN_KEY
        {
            String strForeignTable;
            String[] strColumnName;
        }

        public struct COLUMN_CONSTRAIN
        {
            PRIMARY_KEY_T PrimaryKey;
            Boolean bNotNull;
            Boolean bUnique;
            String strDefaultValue;
            FOREIGN_KEY ForeignKey;
        }

        public struct COLUMN_DEF
        {
            String strColumnName;
            COLUMN_CONSTRAIN Costrnt;
        }

        public struct COLUMN_DATA
        {
            String strColumnName;
            String strValue;
        }

        private String m_strDbFullPath;
        private String m_strPassword;

        public DatabaseApi(String strDbFullPath, String strPassword)
        {
            m_strDbFullPath = strDbFullPath;
            m_strPassword = strPassword;
        }

        public void createTable(String strTableName, COLUMN_DEF[] ColumnDef)
        {
        }

        public void insertData(String strTableName, COLUMN_DATA[] Value)
        {
        }

        public void deleteData()
        {
        }
    }
}
