using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Al.Database;

namespace Al.Expense
{
    public partial class FormExpenseTable : Form
    {
        private DatabaseApi m_hDb;

        public FormExpenseTable(DatabaseApi hDb)
        {
            InitializeComponent();
            m_hDb = hDb;
        }

        public void initializeTable()
        {

        }

        private void createTable()
        {
            COLUMN_DEF_S[] ColDef = new COLUMN_DEF_S[7];

            String[] strColumnNames = new String[6] { "id", "date", "description", "amount", "category", "check" };
            DATA_T[] DataTypes = new DATA_T[7] { DATA_T.INTEGER, DATA_T.DATETIME, DATA_T.STRING, DATA_T.DOUBLE, DATA_T.INTEGER, DATA_T.STRING, DATA_T.BOOLEAN };
            Boolean[] bNotNull = new Boolean[7] { true, true, false, true, true, false, false };
            Boolean[] bUnique = new Boolean[7] { true, false, false, false, false, false, false };

            for (int i = 0; i < 7; i++)
            {
                ColDef[i].strColumnName = strColumnNames[i];
                ColDef[i].DataType = DataTypes[i];
                ColDef[i].Costrnt = new COLUMN_CONSTRAIN_S();
                ColDef[i].Costrnt.bNotNull = bNotNull[i];
                ColDef[i].Costrnt.bUnique = bUnique[i];
            }
            ColDef[0].Costrnt.PrimaryKey = PRIMARY_KEY_T.AUTO_INCREASE;
            ColDef[6].Costrnt.DefaultValue = new Data(DATA_T.BOOLEAN);
            ColDef[6].Costrnt.DefaultValue.m_b = false;

            //Coldef[1].Costrnt.DefaultValue = new DatabaseApi.Data(DatabaseApi.DATA_T.DATETIME);
            //Coldef[1].Costrnt.DefaultValue.Set(DateTime.Today);
            m_hDb.createTable("expense", ColDef);
        }
    }
}
