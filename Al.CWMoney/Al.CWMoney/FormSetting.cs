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
        private ConfigApi m_Config;

        public FormSetting(String strConfigName)
        {
            InitializeComponent();
            m_Config = new ConfigApi(strConfigName);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SystemConf confData = new SystemConf();

            confData.DbDir = textBox_DbDir.Text;
            confData.Synch = new SynConf();
            confData.Synch.Dir = textBox_DropboxDir.Text;

            m_Config.setConfig<SystemConf>(confData);
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            //  Get config data.
            SystemConf confData = m_Config.getConfig<SystemConf>();

            textBox_DbDir.Text = confData.DbDir;
            textBox_DropboxDir.Text = confData.Synch.Dir;
        }
    }
}
