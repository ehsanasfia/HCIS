using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using HCISLab.Forms;
using HCISLab.Dialogs;
using System.Drawing;

namespace HCISLab
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static bool fromHCIS { get; set; }
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string UserFullName { get; set; }

        [STAThread]
        public static void Main()
        {
            if (fromHCIS)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 8.25f, FontStyle.Regular);
                MainModule.UserID = UserID;
                MainModule.UserName = UserName;
                MainModule.UserFullName = UserFullName;
                MainModule.SetApplicationNameForConnectionString("HCISConnectionString1");
                //var pfc = new System.Drawing.Text.PrivateFontCollection();
                //pfc.AddFontFile(@"Resources\IRANSansWeb.ttf");
                //pfc.AddFontFile(@"Resources\IRANSansWeb_Bold.ttf");
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font(pfc.Families[0], 8.25f, FontStyle.Regular);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.UserSkins.BonusSkins.Register();
                var diag = new SecurityLoginsAndAccessControl.dialogLogin();
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 8.25f, FontStyle.Regular);
                    //var pfc = new System.Drawing.Text.PrivateFontCollection();
                    //pfc.AddFontFile(@"Resources\IRANSansWeb.ttf");
                    //pfc.AddFontFile(@"Resources\IRANSansWeb_Bold.ttf");
                   // DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font(pfc.Families[0], 8.25f, FontStyle.Regular);
                    MainModule.UserID = diag.User.UserID;
                    MainModule.UserName = diag.UserName;
                    MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
                    MainModule.SetApplicationNameForConnectionString("HCISConnectionString1");
                    var dlg = new Dialogs.dlgStart();
                    if (dlg.ShowDialog() == DialogResult.OK)
                        Application.Run(new Forms.frmMain());
                }
                else
                    Application.Exit();
            }
        }
    }
}
