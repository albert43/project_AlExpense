using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Al.Config;

namespace Al.CWMoney
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SysemConf confData = new SysemConf();

            confData.m_strDbDir = textBox_DbDir.Text;
            confData.m_Sync = new SynConf();
            confData.m_Sync.m_strDir = textBox_DropboxDir.Text;

            ConfigApi conf = new ConfigApi("conf");

            conf.setConfig<SysemConf>(confData);

            if (textBox_DbDir.Text.Length > 0)
                MessageBox.Show(textBox_DbDir.Text);
            else
                MessageBox.Show("No Data");
        }
    }
}
