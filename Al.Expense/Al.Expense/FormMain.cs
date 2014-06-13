using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Al.Database;
//using System.Data.SQLite;

namespace Al.Expense
{
    public partial class Form_Main : Form
    {
        private const String DB_PATH = "alexpense.db";
        private String m_strConfigName;
        private DatabaseApi m_Db;

        public Form_Main(String strConfigName)
        {
            InitializeComponent();
            m_strConfigName = strConfigName;

            //  Template test for DatabaseApi class
            m_Db = new DatabaseApi(DB_PATH, "");

            DatabaseApi.COLUMN_DEF_S[] Coldef = new DatabaseApi.COLUMN_DEF_S[1];

            Coldef[0].strColumnName = "id";
            Coldef[0].Costrnt.PrimaryKey = DatabaseApi.PRIMARY_KEY_T.AUTO_INCREASE;

            m_Db.createTable("expense", Coldef);
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetting Form = new FormSetting(m_strConfigName);

            Form.ShowDialog();
        }
    }
}
