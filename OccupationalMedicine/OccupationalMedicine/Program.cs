using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using OccupationalMedicine.Forms;
using System.Drawing;
using SecurityLoginsAndAccessControl;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine
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
            string SQLDataSource = "artp";
            string SQLUserID = "artp";
            string SQLPassword = "506070";
            string SQLdbName = "OccupationalMedicine";

            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString1", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString1", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString3", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            BuildConnectionString("OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);

            if (fromHCIS)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 9, FontStyle.Bold);
                MainModule.UserID = UserID;
                MainModule.UserName = UserName;
                MainModule.UserFullName = UserFullName;
                MainModule.SetApplicationNameForConnectionString("OccupationalMedicineConnectionString");
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
                    MainModule.SetApplicationNameForConnectionString("OccupationalMedicineConnectionString");
                    Application.Run(new Forms.frmMain());
                }
                else
                    Application.Exit();
            }
        }

        private static void BuildConnectionString(string connectionStringName, string dataSource, string userName, string userPassword, string dbName)
        {
            // Retrieve the partial connection string named databaseConnection
            // from the application's app.config or web.config file.
            System.Configuration.ConnectionStringSettings settings =
                System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];

            if (settings != null)
            {
                // Retrieve the partial connection string.
                string connectString = settings.ConnectionString;
                //Console.WriteLine("Original: {0}", connectString);

                // Create a new SqlConnectionStringBuilder based on the
                // partial connection string retrieved from the config file.
                System.Data.SqlClient.SqlConnectionStringBuilder builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(connectString);

                // Supply the additional values.
                builder.DataSource = dataSource;
                builder.UserID = userName;
                builder.Password = userPassword;
                builder.InitialCatalog = dbName;

                //MessageBox.Show(settings.IsReadOnly() + "");
                var fi = typeof(System.Configuration.ConfigurationElement).GetField("_bReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                fi.SetValue(settings, false);

                settings.ConnectionString = builder.ConnectionString;

                //Console.WriteLine("Modified: {0}", builder.ConnectionString);
            }
        }
    }
}
