using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Al.Expense
{
    static class Program
    {
        private const String CONFIG_PATH = "alexpense.config";
        private const String DB_PATH = "alexpense.db";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(CONFIG_PATH) == false)
                Application.Run(new FormSetting(CONFIG_PATH));

            
            if (File.Exists(CONFIG_PATH) == true)
                Application.Run(new Form_Main(CONFIG_PATH, DB_PATH));

            Application.Exit();
        }
    }
}
