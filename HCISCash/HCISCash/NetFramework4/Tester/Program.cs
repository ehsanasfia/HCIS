using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SSP1126.Pc2Pos.Desktop.Tester;

namespace Sep.Pc2Pos.Desktop.Tester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
