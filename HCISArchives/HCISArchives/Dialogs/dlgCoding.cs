using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISArchives.Data;

namespace HCISArchives.Dialogs
{
    public partial class dlgCoding : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public ArchiveDashboard Ad { get; set; }
        List<ArchiveBabyObservation> lstBaby = new List<ArchiveBabyObservation>();

        public dlgCoding()
        {
            InitializeComponent();
        }

        private void dlgCoding_Load(object sender, EventArgs e)
        {
            lblDos.Text = "شماره پرونده" + "  :" + Ad.DosID;
            lblFirstName.Text = "نام" + "  :" + Ad.Dossier.Person.FirstName;
            lblLastname.Text = "نام خانوادگی" + "  :" + Ad.Dossier.Person.LastName;
            lblMedical.Text = "شناسه پزشکی" + "  :" + Ad.Dossier.Person.FirstName;
            lblCode.Text = "کد ویژه" + "  :" + Ad.Dossier.SpicialCode;
            GetData();
            GetHistory();
            archiveBabyObservationBindingSource.DataSource = lstBaby;

        }
        private void GetHistory()
        {
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            if (Ad.ArchiveCodings.Any())
            {

                if (radioGroup1.SelectedIndex == 0)
                {
                    archiveCodingBindingSource.DataSource = dc.ArchiveCodings.Where(x => x.ArchivDashboardID == Ad.ArchiveDashboardID && x.Type == 70);
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    archiveCodingBindingSource.DataSource = dc.ArchiveCodings.Where(x => x.ArchivDashboardID == Ad.ArchiveDashboardID && x.Type == 71);
                }
                else if (radioGroup1.SelectedIndex == 2)
                {
                    archiveCodingBindingSource.DataSource = dc.ArchiveCodings.Where(x => x.ArchivDashboardID == Ad.ArchiveDashboardID && x.Type == 72);
                }

            }
            if (radioGroup1.SelectedIndex == 3)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }

        private void GetData()
        {
            iCD10BindingSource.DataSource = Classes.MainModule.lstICD10;
            angioBindingSource.DataSource = dc.Angios.Where(x => (x.GivenServiceM.ServiceCategoryID == 13 || x.GivenServiceM.ServiceCategoryID == 14) && x.GivenServiceM.DossierID == Ad.DosID);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHistory();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            var current = iCD10BindingSource.Current as ICD10;
            if (current == null)
                return;

            var type = byte.Parse(radioGroup1.EditValue.ToString());
            if (dc.ArchiveCodings.Any(x => x.ICDID == current.ID && x.ArchivDashboardID == Ad.ArchiveDashboardID && x.Type == type))
            {
                MessageBox.Show("این کد وارد شده است");
                return;
            }
            current = dc.ICD10s.FirstOrDefault(x => x.ID == current.ID);
            var ArchiveCode = new ArchiveCoding()
            {
                ICD10 = current,
                ArchiveDashboard = Ad,
                Type = type, // در جدول difinition هست اعداد
                ArchivistUserName = Classes.MainModule.UserFullName
            };
            dc.ArchiveCodings.InsertOnSubmit(ArchiveCode);
            dc.SubmitChanges();
            GetHistory();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in lstBaby)
            {
                item.ArchiveDashboardID = Ad.ArchiveDashboardID;
                dc.ArchiveBabyObservations.InsertOnSubmit(item);
            }

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var current = archiveCodingBindingSource.Current as ArchiveCoding;
            if (current == null)
                return;
            dc.ArchiveCodings.DeleteOnSubmit(current);
            dc.SubmitChanges();
            GetHistory();
        }
    }
}