using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al.Expense
{
    public partial class Form_Main : Form
    {
        private String m_strConfigName;

        public Form_Main(String strConfigName)
        {
            InitializeComponent();
            m_strConfigName = strConfigName;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetting Form = new FormSetting(m_strConfigName);

            Form.ShowDialog();
        }
    }
}
