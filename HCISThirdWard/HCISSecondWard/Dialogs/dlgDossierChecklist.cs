using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgDossierChecklist  : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        long hospitalRecordID;

        public dlgDossierChecklist(Data.ArchiveDashboard dashboard)
        {
            InitializeComponent();
            dashboard = dc.ArchiveDashboards.SingleOrDefault(d => d.ArchiveDashboardID == dashboard.ArchiveDashboardID);
            lblTitle.Text = dashboard.Dossier.Person.FullName + " / کد پرسنلی: " +
                            dashboard.Dossier.Person.PersonalCode + " / شماره پرونده: " +
                            dashboard.Dossier.ID.ToString();

            hospitalRecordID = dashboard.DosID;

            archiveDossierChecklistBindingSource.DataSource = dashboard.ArchiveDossierChecklists;
            //zHRDSummaryResultBindingSource.DataSource = dc.zHRDSummary(dashboard.HospitalRecordID);
        }

        private void frmDossierChecklist_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            //DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnViewDossier_Click(object sender, EventArgs e)
        {
            try
            {
                var guid = "6A04A05F-DDCD-4263-9895-EAA345869F59";
                var hospitalWardAppDir = "\"\\\\172.30.1.30\\AsfiyaProjects\\HospitalWard\\Shared\\HospitalWard.exe\"";
                System.Diagnostics.Process.Start(hospitalWardAppDir, string.Format("{0} {1}", guid, hospitalRecordID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
