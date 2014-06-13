using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Al.Config;

namespace Al.Expense
{
    public partial class FormSetting : Form
    {
        private ConfigApi m_Config;

        public FormSetting(String strConfigName)
        {
            InitializeComponent();
            m_Config = new ConfigApi(strConfigName);
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            //  Get config data.
            SystemConf confData = m_Config.getConfig<SystemConf>();

            textBox_DbDir.Text = confData.DbDir;
            textBox_DropboxDir.Text = confData.Sync.Dir;
        }

        private void button_DbDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dir = new FolderBrowserDialog();
            dir.ShowDialog();

            textBox_DbDir.Text = dir.SelectedPath;
        }

        private void button_DropboxDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dir = new FolderBrowserDialog();
            dir.ShowDialog();

            textBox_DropboxDir.Text = dir.SelectedPath;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SystemConf confData = new SystemConf();

            confData.DbDir = textBox_DbDir.Text;
            confData.Sync = new SynConf();
            confData.Sync.Dir = textBox_DropboxDir.Text;

            m_Config.setConfig<SystemConf>(confData);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
