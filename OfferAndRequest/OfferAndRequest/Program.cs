using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using SecurityLoginsAndAccessControl;
using System.Drawing;

namespace OfferAndRequest
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
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                MainModule.UserID = UserID;
                MainModule.UserName = UserName;
                //MainModule.UserFullName = UserFullName;
                MainModule.SetApplicationNameForConnectionString("HCISConnectionString");
            }
            else
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                var diag = new SecurityLoginsAndAccessControl.dialogLogin();
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    MainModule.UserID = diag.User.UserID;

                    MainModule.UserName = diag.UserName;
                    MainModule.FirstName = string.Format(diag.User.FirstName);
                    MainModule.LastName = string.Format(diag.User.LastName);
                    MainModule.P = (diag.User.PersonalNo).ToString();
                    //  MainModule.SetApplicationNameForConnectionString("OfferAndRequest");
                    Application.Run(new frmMain());
                }
            }
            
        }
    }
}
