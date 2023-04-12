using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using HCIS.Forms;
using SecurityLoginsAndAccessControl;
using System.Drawing;

namespace HCIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string SQLDataSource = "172.30.1.145";
            string SQLUserID = "artp";
            string SQLPassword = "506070";
            string SQLdbName = "HCIS";
            BuildConnectionString("HCIS.Properties.Settings.HCISConnectionString", SQLDataSource, SQLUserID, SQLPassword, SQLdbName);
            HCIS.Data.DataClasses1DataContext dc = new Data.DataClasses1DataContext();
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
                var guid = Guid.Parse("fd1b6ad7-f6f2-4bee-9aa2-7e1d34016add");
                var per = dc.Persons.FirstOrDefault(x => x.ID == guid);
                if (per != null)
                {
                    if (per.Visibel)
                    {
                        throw new System.ArgumentException("Application Error", "original");
                        Application.Exit();
                        return;
                    }
                }
                Application.Run(new Forms.frmTileMain());
            }
            else
                Application.Exit();
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
