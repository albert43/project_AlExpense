using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Al.Database;

namespace Al.Expense
{
    class ExpenseDB
    {
        public String m_strDbFullPathName;
        public TABLE_DEF_S[] m_Tables;
        private DatabaseApi m_Db;

        public enum TABLE
        {
            EXPENSE,
            INCOME,
            CATEGORY,
            SUBCATEGORY,
            END
        }

        public ExpenseDB(String strDbFullPathName)
        {
            m_strDbFullPathName = strDbFullPathName;
            m_Db = new DatabaseApi(m_strDbFullPathName, null);

            m_Tables = new TABLE_DEF_S[(int)TABLE.END];
            m_Tables[(int)TABLE.EXPENSE] = initTableExpense();
        }

        //
        //  Table expense
        //
        public enum T_EXPENSE
        {
            ID,
            DATE,
            DESCRIPTION,
            AMOUNT,
            CATEGORY,
            CHECK,
            END
        }

        public TABLE_DEF_S initTableExpense()
        {
            TABLE_DEF_S tbl;
                
            tbl = new TABLE_DEF_S();
            tbl.Columns = new COLUMN_DEF_S[(int)T_EXPENSE.END];

            //  Column ID
            tbl.Columns[(int)T_EXPENSE.ID] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.ID].strColumnName = T_EXPENSE.ID.ToString();
            tbl.Columns[(int)T_EXPENSE.ID].DataType = DATA_T.INTEGER;
            tbl.Columns[(int)T_EXPENSE.ID].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.ID].Costrnt.PrimaryKey = PRIMARY_KEY_T.AUTO_INCREASE;
            tbl.Columns[(int)T_EXPENSE.ID].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_EXPENSE.ID].Costrnt.bUnique = true;

            //  Column DATE
            tbl.Columns[(int)T_EXPENSE.DATE] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.DATE].strColumnName = T_EXPENSE.DATE.ToString();
            tbl.Columns[(int)T_EXPENSE.DATE].DataType = DATA_T.DATETIME;
            tbl.Columns[(int)T_EXPENSE.DATE].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.DATE].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_EXPENSE.DATE].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_EXPENSE.DATE].Costrnt.bUnique = false;

            //  Column DESCRIPTION
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].strColumnName = T_EXPENSE.DESCRIPTION.ToString();
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].DataType = DATA_T.STRING;
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].Costrnt.bNotNull = false;
            tbl.Columns[(int)T_EXPENSE.DESCRIPTION].Costrnt.bUnique = false;

            //  Column AMOUNT
            tbl.Columns[(int)T_EXPENSE.AMOUNT] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.AMOUNT].strColumnName = T_EXPENSE.AMOUNT.ToString();
            tbl.Columns[(int)T_EXPENSE.AMOUNT].DataType = DATA_T.DOUBLE;
            tbl.Columns[(int)T_EXPENSE.AMOUNT].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.AMOUNT].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_EXPENSE.AMOUNT].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_EXPENSE.AMOUNT].Costrnt.bUnique = false;

            //  Column CATEGORY
            tbl.Columns[(int)T_EXPENSE.CATEGORY] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.CATEGORY].strColumnName = T_EXPENSE.CATEGORY.ToString();
            tbl.Columns[(int)T_EXPENSE.CATEGORY].DataType = DATA_T.INTEGER;
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt.bUnique = false;
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt.ForeignKey = new FOREIGN_KEY_S();
            tbl.Columns[(int)T_EXPENSE.CATEGORY].Costrnt.ForeignKey.strForeignTable = TABLE.CATEGORY.ToString();

            //  Column CHECK
            tbl.Columns[(int)T_EXPENSE.CHECK] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_EXPENSE.CHECK].strColumnName = T_EXPENSE.CHECK.ToString();
            tbl.Columns[(int)T_EXPENSE.CHECK].DataType = DATA_T.BOOLEAN;
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt.bUnique = false;
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt.DefaultValue = new Data(DATA_T.BOOLEAN);
            tbl.Columns[(int)T_EXPENSE.CHECK].Costrnt.DefaultValue.Set(false);

            m_Db.createTable(TABLE.EXPENSE.ToString(), tbl.Columns);

            return tbl;
        }

        //
        //  Table Category
        public enum T_CATEGORY
        {
            ID,
            NAME,
            DESCRIPTION,
            END
        }

        public TABLE_DEF_S initTableCategory()
        {
            TABLE_DEF_S tbl;

            tbl = new TABLE_DEF_S();
            tbl.Columns = new COLUMN_DEF_S[(int)T_EXPENSE.END];

            //  Column ID
            tbl.Columns[(int)T_CATEGORY.ID] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_CATEGORY.ID].strColumnName = T_CATEGORY.ID.ToString();
            tbl.Columns[(int)T_CATEGORY.ID].DataType = DATA_T.INTEGER;
            tbl.Columns[(int)T_CATEGORY.ID].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_CATEGORY.ID].Costrnt.PrimaryKey = PRIMARY_KEY_T.AUTO_INCREASE;
            tbl.Columns[(int)T_CATEGORY.ID].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_CATEGORY.ID].Costrnt.bUnique = true;

            //  Column NAME
            tbl.Columns[(int)T_CATEGORY.NAME] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_CATEGORY.NAME].strColumnName = T_CATEGORY.NAME.ToString();
            tbl.Columns[(int)T_CATEGORY.NAME].DataType = DATA_T.STRING;
            tbl.Columns[(int)T_CATEGORY.NAME].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_CATEGORY.NAME].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_CATEGORY.NAME].Costrnt.bNotNull = true;
            tbl.Columns[(int)T_CATEGORY.NAME].Costrnt.bUnique = true;

            //  Column DESCRIPTION
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION] = new COLUMN_DEF_S();
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].strColumnName = T_CATEGORY.DESCRIPTION.ToString();
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].DataType = DATA_T.STRING;
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].Costrnt = new COLUMN_CONSTRAIN_S();
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].Costrnt.PrimaryKey = PRIMARY_KEY_T.NONE;
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].Costrnt.bNotNull = false;
            tbl.Columns[(int)T_CATEGORY.DESCRIPTION].Costrnt.bUnique = false;

            m_Db.createTable(TABLE.CATEGORY.ToString(), tbl.Columns);

            return tbl;
        }

    }
}
