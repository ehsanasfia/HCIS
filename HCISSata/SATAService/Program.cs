using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SATAService
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool fromHCIS { get; set; }
        [STAThread]
        public static void Main()
        {

            if (fromHCIS)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
