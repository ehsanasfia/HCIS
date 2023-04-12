using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using HCISAngio.Forms;
using HCISAngio.Classes;
using System.Drawing;

namespace HCISAngio
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
            try
            {
                if (fromHCIS)
                {
                    DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                    MainModule.UserID = UserID;
                    MainModule.UserName = UserName;
                    MainModule.UserFullName = UserFullName;
                    MainModule.SetApplicationNameForConnectionString("HCISConnectionString");
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    DevExpress.UserSkins.BonusSkins.Register();
                    var diag = new SecurityLoginsAndAccessControl.dialogLogin();
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                        MainModule.UserID = diag.User.UserID;
                        MainModule.UserName = diag.UserName;
                        MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
                        MainModule.SetApplicationNameForConnectionString("HCISConnectionString");
                        Application.Run(new frmMain());
                    }
                    else
                        Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
