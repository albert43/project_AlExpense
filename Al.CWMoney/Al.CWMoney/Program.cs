using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Al.CWMoney
{
    static class Program
    {
        private const String CONFIG_PATH = "alcwmoney.json";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(CONFIG_PATH) == false)
                Application.Run(new FormSetting());

            if (File.Exists(CONFIG_PATH) == true)
                Application.Run(new Form_Main());
        }
    }
}
