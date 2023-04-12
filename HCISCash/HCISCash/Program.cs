using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using HCISCash.Dialogs;
using SecurityLoginsAndAccessControl;
using System.Drawing;

namespace HCISCash
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool fromHCIS { get; set; }
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string UserFullName { get; set; }
        [STAThread]
        public static void Main()
        {

            if (fromHCIS)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                MainModule.UserID = UserID;
                MainModule.UserName = UserName;
                MainModule.UserFullName = UserFullName;
                MainModule.SetApplicationNameForConnectionString("hcisConnectionString2");
            }
            else
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
                    MainModule.SetApplicationNameForConnectionString("hcisConnectionString2");
                    var dlg = new Dialogs.dlgStart();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var dlg1 = new Dialogs.dlgCompanyType();
                        if (dlg1.ShowDialog() == DialogResult.OK)
                            Application.Run(new FrmMain());
                    }
                }
            }
        }
    }
}
