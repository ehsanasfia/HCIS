using System;
using System.Windows.Forms;
using SecurityLoginsAndAccessControl;
using System.Drawing;

namespace HCISAdmission
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
            //Application.Run(new frmAdmission());

            //try
            //{
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
                        var dlg = new Dialogs.dlgStart();
                        if (dlg.ShowDialog() == DialogResult.OK)
                            Application.Run(new Forms.frmMain());

                    }
                    else
                        Application.Exit();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            /*
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
            Application.Run(new Forms.frmMain());
            */
        }
    }
}
