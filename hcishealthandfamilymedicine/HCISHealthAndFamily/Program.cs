using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using HCISHealthAndFamily.Classes;
using System.Drawing;
using SecurityLoginsAndAccessControl;

namespace HCISHealthAndFamily
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

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            var diag = new SecurityLoginsAndAccessControl.dialogLogin();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                MainModule.UserID = diag.User.UserID;
                MainModule.UserName = diag.UserName;
                MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
                MainModule.SetApplicationNameForConnectionString("HCISConnectionString");
                var dlg = new Dialogs.dlgStart();
                if (dlg.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmMain());
           }
            else
                Application.Exit();

            //}
            //else
            //    Application.Exit();
        }
    }
}
