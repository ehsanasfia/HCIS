using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISArchives.Data;
using HCISArchives.Dialogs;

namespace HCISArchives.Forms
{
    public partial class frmMedicalDocumentsCodings : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<ArchiveDashboard> lst = new List<ArchiveDashboard>();

        public frmMedicalDocumentsCodings()
        {
            InitializeComponent();
        }

        private void frmMedicalDocuments_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            radioGroup2_SelectedIndexChanged(null, null);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var from = txtFrom.Text.Trim();
            var to = txtTo.Text.Trim();

            if(radioGroup2.SelectedIndex == 0)
            {
                lst = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true).ToList();

                if (radioGroup1.SelectedIndex == 0)
                    lst = lst.Where(x => x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 1)
                    lst = lst.Where(x => x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 2)
                    lst = lst.Where(x => x.Dossier.Date.CompareTo(from) >= 0 && x.Dossier.Date.CompareTo(to) <= 0).ToList();

                archiveDashboardBindingSource.DataSource = lst;
            }
            else if(radioGroup2.SelectedIndex == 1)
            {
                lst = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true && (x.ArchivistAccept == null || x.ArchivistAccept == false)).ToList();

                if (radioGroup1.SelectedIndex == 0)
                    lst = lst.Where(x => x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 1)
                    lst = lst.Where(x => x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 2)
                    lst = lst.Where(x => x.Dossier.Date.CompareTo(from) >= 0 && x.Dossier.Date.CompareTo(to) <= 0).ToList();

                archiveDashboardBindingSource.DataSource = lst;
            }
            else if(radioGroup2.SelectedIndex == 2)
            {
                lst = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true && x.ArchivistAccept == true && x.CodingAccept == true).ToList();

                if (radioGroup1.SelectedIndex == 0)
                    lst = lst.Where(x => x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 1)
                    lst = lst.Where(x => x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 2)
                    lst = lst.Where(x => x.Dossier.Date.CompareTo(from) >= 0 && x.Dossier.Date.CompareTo(to) <= 0).ToList();

                archiveDashboardBindingSource.DataSource = lst;
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                radioGroup1_SelectedIndexChanged(null, null);
            }
            else if (radioGroup2.SelectedIndex == 1)
            {
                var from = txtFrom.Text.Trim();
                var to = txtTo.Text.Trim();

                lst = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true && (x.ArchivistAccept == null || x.ArchivistAccept == false)).ToList();

                if (radioGroup1.SelectedIndex == 0)
                    lst = lst.Where(x => x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 1)
                    lst = lst.Where(x => x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 2)
                    lst = lst.Where(x => x.Dossier.Date.CompareTo(from) >= 0 && x.Dossier.Date.CompareTo(to) <= 0).ToList();

                archiveDashboardBindingSource.DataSource = lst;
            }
            else if(radioGroup2.SelectedIndex == 2)
            {
                var from = txtFrom.Text.Trim();
                var to = txtTo.Text.Trim();

                lst = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true && x.ArchivistAccept == true && x.CodingAccept == true).ToList();

                if (radioGroup1.SelectedIndex == 0)
                    lst = lst.Where(x => x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 1)
                    lst = lst.Where(x => x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0).ToList();
                else if (radioGroup1.SelectedIndex == 2)
                    lst = lst.Where(x => x.Dossier.Date.CompareTo(from) >= 0 && x.Dossier.Date.CompareTo(to) <= 0).ToList();

                archiveDashboardBindingSource.DataSource = lst;
            }
        }

        private void btnCaseTrace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgCaseTrace2();
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void btnPatientHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (cur == null)
                return;

            var dlg = new dlgPateintHistory();
            dlg.PersonID = (Guid)cur.Dossier.PersonID;
            dlg.ShowDialog();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            radioGroup2_SelectedIndexChanged(null, null);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (cur == null)
                return;
            
            var a = new Dialogs.dlgCoding();
            a.dc = dc;
            a.Ad = cur;
            if(a.ShowDialog() == DialogResult.OK)
            {
                cur.CodingAccept = true;
                cur.CodingAcceptDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                cur.CodingAcceptTime = DateTime.Now.ToString("HH:mm");
                cur.CodingUserName = Classes.MainModule.UserFullName;
                dc.SubmitChanges();
                radioGroup2_SelectedIndexChanged(null, null);
            }
        }

        private void archiveDashboardBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (current == null)
                return;

            if (current.Dossier.GivenServiceMs.Any(x => x.ServiceCategoryID == 9 || x.ServiceCategoryID == 11))
            {
                layoutControlItem5.Visibility = layoutControlItem6.Visibility = splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DosID && x.GivenServiceM.ServiceCategoryID == 11);
                givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DosID && x.GivenServiceM.ServiceCategoryID == 9);
            }
            else
            {
                layoutControlItem5.Visibility = layoutControlItem6.Visibility = splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        //private void btnBackToWard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (MessageBox.Show("آیا مایلید پرونده های انتخابی را باز گردانی کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
        //    {
        //        foreach (var item in gridView1.GetSelectedRows())
        //        {
        //            var Dos = gridView1.GetRow(item) as ArchiveDashboard;
        //            Dos.ArchivistAccept = false;
        //            Dos.ArchivistAcceptDate = null;
        //            Dos.ArchivistAcceptTime = null;
        //            Dos.SecretaryAccept = null;
        //            Dos.SecretaryAcceptDate = null;
        //            Dos.SecretaryAcceptTime = null;
        //        }
        //        dc.SubmitChanges();
        //        GetData();
        //    }
        //}

        //private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    var count = gridView1.GetSelectedRows().Count();
        //    if (count == 0)
        //    {
        //        MessageBox.Show("پرونده ای انتخاب نشده است", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign));
        //        return;
        //    }

        //    if (MessageBox.Show("آیا مایل به تایید " + count + " پرونده پزشکی هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign)) != DialogResult.Yes)
        //        return;

        //    foreach (var item in gridView1.GetSelectedRows())
        //    {
        //        var Archive = gridView1.GetRow(item) as ArchiveDashboard;
        //        if (!Archive.ArchiveDossierChecklists.Any(x => x.ArchivistChecked == false || x.ArchivistChecked == true))
        //        {
        //            if (MessageBox.Show("چک لیست  پرونده " + Archive.Dossier + "بررسی نشده است آیا مایل به بررسی هستید؟", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign)) != DialogResult.Yes)
        //                continue;
        //            else
        //            {

        //                var a = new Dialogs.dlgArchiveCheckList();
        //                a.dc = dc;
        //                a.dos = Archive;
        //                a.ShowDialog();
        //            }
        //        }

        //        Archive.ArchivistAccept = true;
        //        Archive.ArchivistAcceptDate = Classes.MainModule.GetPersianDate(DateTime.Now);
        //        Archive.ArchivistAcceptTime = DateTime.Now.ToString("HH:mm");
        //        Archive.ArchivistUserName = Classes.MainModule.UserFullName;
        //        dc.SubmitChanges();
        //    }
        //}
    }
}