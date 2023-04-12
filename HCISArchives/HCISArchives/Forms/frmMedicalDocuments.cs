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
    public partial class frmMedicalDocuments : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();

        public frmMedicalDocuments()
        {
            InitializeComponent();
        }

        private void frmMedicalDocuments_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void GetData()
        {
            var from = txtFrom.Text.Trim();
            var to = txtTo.Text.Trim();

            archiveDashboardBindingSource.DataSource = dc.ArchiveDashboards.Where(x => x.SecretaryAccept == true && x.SecretaryAcceptDate.CompareTo(from) >= 0 && x.SecretaryAcceptDate.CompareTo(to) <= 0 && (x.ArchivistAccept == null || x.ArchivistAccept == false)).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnCaseTrace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgCaseTrace2();
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void btnBackToWard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا مایلید پرونده های انتخابی را باز گردانی کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    var Dos = gridView1.GetRow(item) as ArchiveDashboard;
                    Dos.ArchivistAccept = false;
                    Dos.ArchivistAcceptDate = null;
                    Dos.ArchivistAcceptTime = null;
                    Dos.SecretaryAccept = null;
                    Dos.SecretaryAcceptDate = null;
                    Dos.SecretaryAcceptTime = null;
                }
                dc.SubmitChanges();
                GetData();
            }
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
            GetData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (cur == null)
                return;

            var a = new Dialogs.dlgArchiveCheckList();
            a.dc = dc;
            a.dos = cur;
            if (a.ShowDialog() == DialogResult.OK)
            {
                cur.ArchivistAccept = true;
                cur.ArchivistAcceptDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                cur.ArchivistAcceptTime = DateTime.Now.ToString("HH:mm");
                cur.ArchivistUserName = Classes.MainModule.UserFullName;
                dc.SubmitChanges();
                GetData();
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
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DosID && x.GivenServiceM.ServiceCategoryID == 11).ToList();
                givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DosID && x.GivenServiceM.ServiceCategoryID == 9).ToList();
            }
            else
            {
                layoutControlItem5.Visibility = layoutControlItem6.Visibility = splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var count = gridView1.GetSelectedRows().Count();
            //if (count == 0)
            //{
            //    MessageBox.Show("پرونده ای انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign));
            //    return;
            //}

            //if (MessageBox.Show("آیا مایل به تایید " + count + " پرونده پزشکی هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign)) != DialogResult.Yes)
            //    return;

            //foreach (var item in gridView1.GetSelectedRows())
            //{
            //    var ad = gridView1.GetRow(item) as ArchiveDashboard;

            //    if(ad.ArchiveBabyObservations.Any() == false && ad.ArchiveCodings.Any() == false)
            //    {
            //        MessageBox.Show("شماره پرونده ی " + ad.DosID + " در مرحله ی کدینگ است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign));
            //        continue;
            //    }
            //    if(!ad.ArchiveDossierChecklists.Any(x => x.ArchivistChecked == false || x.ArchivistChecked == true))
            //    {
            //        if (MessageBox.Show("چک لیست  پرونده " + ad.DosID + "بررسی نشده است آیا مایل به بررسی هستید؟",  "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RightAlign)) != DialogResult.Yes)
            //            continue;
            //        else
            //        {
            //            var a = new Dialogs.dlgArchiveCheckList();
            //            a.dc = dc;
            //            a.dos = ad;
            //            a.ShowDialog();
            //        }
            //    }

            //    ad.ArchivistAccept = true;
            //    ad.ArchivistAcceptDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            //    ad.ArchivistAcceptTime = DateTime.Now.ToString("HH:mm");
            //    ad.ArchivistUserName = Classes.MainModule.UserFullName;
            //    dc.SubmitChanges();
            //}
        }
    }
}