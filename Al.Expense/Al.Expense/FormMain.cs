using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Al.Database;
//using System.Data.SQLite;

namespace Al.Expense
{
    public partial class Form_Main : Form
    {
        
        private String m_strConfigName;
        private DatabaseApi m_Db;

        public Form_Main(String strConfigName, String strDbPath)
        {
            InitializeComponent();
            m_strConfigName = strConfigName;
            m_Db = new DatabaseApi(strDbPath, null);

            //  Template test for DatabaseApi class
            createTable();
            insertData();
            deleteData();
            selectData();
        }

        private void createTable()
        {
            COLUMN_DEF_S[] ColDef = new COLUMN_DEF_S[7];

            String[] strColumnNames = new String[7] { "id", "date", "item", "amount", "category", "description", "check" };
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
            m_Db.createTable("expense", ColDef);
        }

        private void insertData()
        {
            COLUMN_DATA_S[] Data = new COLUMN_DATA_S[6];
            String[] strColumnNames = new String[7] { "id", "date", "item", "amount", "category", "description", "check" };
            DATA_T[] DataTypes = new DATA_T[7] { DATA_T.INTEGER, DATA_T.DATETIME, DATA_T.STRING, DATA_T.DOUBLE, DATA_T.INTEGER, DATA_T.STRING, DATA_T.BOOLEAN };
            for (int i = 0; i < 6; i++)
            {
                Data[i].Value = new Data(DataTypes[i + 1]);
                Data[i].strColumnName = strColumnNames[i + 1];
            }

            DateTime[] Date = new DateTime[] 
            {
                new DateTime(2014,6,3),
                new DateTime(2014,6,3), 
                new DateTime(2014,6,5),
                new DateTime(2014,6,7),
                new DateTime(2014,6,14),
            };

            String[] Item = new String[5] { "Breakfast", "Bus", "Lunch", "Date", "Cell phone" };
            Double[] Amount = new Double[5] { 75.0, 15.0, 33.5, 120.7, 1275.9 };
            Int32[] Category = new Int32[5] { 2, 3, 2, 4, 7 };
            String[] Description = new String[5]
            {
                "The same as usual",
                "Home to office",
                "Lunch box and coffee",
                "Japanese food with Juliy",
                "2014-April"
            };


            for (int iDataNum = 0; iDataNum < 5; iDataNum++)
            {
                Data[0].Value.Set(Date[iDataNum]);
                Data[1].Value.Set(Item[iDataNum]);
                Data[2].Value.Set(Amount[iDataNum]);
                Data[3].Value.Set(Category[iDataNum]);
                Data[4].Value.Set(Description[iDataNum]);
                if ((iDataNum == 2) || (iDataNum == 1) || (iDataNum == 4))
                    Data[5].Value.Set(true);
                else
                    Data[5].Value.Set(false);

                m_Db.insertData("expense", Data);
            }
        }

        private void deleteData()
        {
            SELECT_EXPRES_S expr;
            
        }

        private void selectData()
        {
            SELECT_EXPRES_S expr;

            m_Db.selectData("expense", null, null);
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetting Form = new FormSetting(m_strConfigName);

            Form.ShowDialog();
        }
    }
}
