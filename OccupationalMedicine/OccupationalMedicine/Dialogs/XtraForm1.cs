using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine.Dialogs
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            // OccupationalMedicine.Properties.Settings.Default.OccupationalMedicineConnectionString = "sss";
            MainModule.SelectedServer = Properties.Settings.Default.SelectedServer;

            if (MainModule.SelectedServer == "MainServer")
            {
                radioGroup1.EditValue = "MainServer";
            }
            else if (MainModule.SelectedServer == "Team1")
            {
                radioGroup1.EditValue = "Team1";
            }
            else if (MainModule.SelectedServer == "Team2")
            {
                radioGroup1.EditValue = "Team2";

            }
            else
            {
                radioGroup1.EditValue = "";
            }




           // textEdit1.Text = connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2"].ConnectionString.ToString();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue.ToString() == "MainServer")
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString1"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString1"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString3"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.SelectedServer = "MainServer";
                Properties.Settings.Default.Save();
            }
            if (radioGroup1.EditValue.ToString() == "Team1")
            {
                Properties.Settings.Default.SelectedServer = "Team1";
                Properties.Settings.Default.Save();
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString1"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString1"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString3"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                       }
            Properties.Settings.Default.Reload();
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue.ToString() == "MainServer")
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString1"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString1"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString3"].ConnectionString = "Data Source=artp-srv;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.SelectedServer = "MainServer";
                Properties.Settings.Default.Save();
            }
            if (radioGroup1.EditValue.ToString() == "Team1")
            {
                Properties.Settings.Default.SelectedServer = "Team1";
                Properties.Settings.Default.Save();
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString2"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString1"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicine91ConnectionString1"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                connectionStringsSection.ConnectionStrings["OccupationalMedicine.Properties.Settings.OccupationalMedicineConnectionString3"].ConnectionString = "Data Source=172.30.1.145;Initial Catalog=OccupationalMedicine;Persist Security Info=True;User ID=artp;Password=506070";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }

            Properties.Settings.Default.Reload();
        }
    }
}