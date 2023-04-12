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
    public partial class dlgCaseTrace : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        List<GivenServiceM> lst = new List<GivenServiceM>();

        public dlgCaseTrace()
        {
            InitializeComponent();
        }

        private void dlgCaseTrace_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoss.Text) && string.IsNullOrWhiteSpace(txtPersonalCode.Text) && string.IsNullOrWhiteSpace(txtFname.Text) && string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("لطفا اطلاعات را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var ds = string.IsNullOrWhiteSpace(txtDoss.Text.Trim());
            var pc = string.IsNullOrWhiteSpace(txtPersonalCode.Text.Trim());
            var fn = string.IsNullOrWhiteSpace(txtFname.Text);
            var ln = string.IsNullOrWhiteSpace(txtLname.Text);

            if (!ds && pc && fn && ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.DossierID == int.Parse(txtDoss.Text.Trim()) && x.ServiceCategoryID == 10).ToList();
            }
            if (ds && !pc && fn && ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.Person != null && x.Person.PersonalCode == txtPersonalCode.Text.Trim() && x.ServiceCategoryID == 10).ToList();
            }
            if (ds && pc && !fn && ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.Person != null && x.Person.FirstName == txtFname.Text && x.ServiceCategoryID == 10).ToList();
            }
            if (ds && pc && fn && !ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.Person != null && x.Person.LastName == txtLname.Text && x.ServiceCategoryID == 10).ToList();
            }

            if (!ds && !pc && fn && ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.DossierID == int.Parse(txtDoss.Text.Trim()) && x.Person != null && x.Person.PersonalCode == txtPersonalCode.Text.Trim() && x.ServiceCategoryID == 10).ToList();
            }
            if (ds && pc && !fn && !ln)
            {
                lst = dc.GivenServiceMs.Where(x => x.Dossier != null && x.Person != null && x.Person.FirstName == txtFname.Text && x.Person.LastName == txtLname.Text && x.ServiceCategoryID == 10).ToList();
            }

            lst.Select(x => x.DossierID).Distinct().ToList();
            givenServiceMBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                labelControl1.Text = "";
                return;
            }
            else if (current.Dossier.ArchiveDashboards.Any() == false)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "بیمار بستری است.";
            }
            else if (current.Dossier.ArchiveDashboards.Any() && current.Dossier.ArchiveDashboards.Any(c => c.SecretaryAccept == true) == false)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "بیمار از بخش ترخیص شده ولی پرونده ای به بایگانی ارسال نشده است.";
            }
            else if (current.Dossier.ArchiveDashboards.Any() && current.Dossier.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true && current.Dossier.ArchiveDashboards.FirstOrDefault().ArchivistAccept != true && current.Dossier.ArchiveDashboards.Any(c => c.ArchiveBabyObservations.Any() || c.ArchiveCodings.Any()) == false)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی چک لیست است.";
            }
            else if (current.Dossier.ArchiveDashboards.Any() && current.Dossier.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true && current.Dossier.ArchiveDashboards.FirstOrDefault().ArchivistAccept == true && current.Dossier.ArchiveDashboards.Any(c => c.ArchiveBabyObservations.Any() || c.ArchiveCodings.Any()) == false)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی کدینگ است.";
            }
            else if (current.Dossier.ArchiveDashboards.Any() && current.Dossier.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true && current.Dossier.ArchiveDashboards.FirstOrDefault().ArchivistAccept == true && current.Dossier.ArchiveDashboards.Any(c => c.ArchiveBabyObservations.Any() || c.ArchiveCodings.Any()))
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی بایگانی است.";
            }

            if (current.Dossier.GivenServiceMs.Any(x => x.ServiceCategoryID == 9 || x.ServiceCategoryID == 11))
            {
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossierID && x.GivenServiceM.ServiceCategoryID == 11);
                givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossierID && x.GivenServiceM.ServiceCategoryID == 9);
            }
            else
            {
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            if (dc.ArchiveDashboards.Any(x => x.DosID == current.Dossier.ID))
            {
                var archive = dc.ArchiveDashboards.FirstOrDefault(x => x.DosID == current.DossierID);
                var dialog = new Dialogs.dlgArchiveCheckList();
                dialog.dc = dc;
                dialog.dos = archive;
                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("بیمار هنوز ترخیص نشده است");
                return;
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            if (dc.ArchiveDashboards.Any(x => x.DosID == current.Dossier.ID))
            {
                var archive = dc.ArchiveDashboards.FirstOrDefault(x => x.DosID == current.DossierID);
                var dialog = new Dialogs.dlgCoding();
                dialog.dc = dc;
                dialog.Ad = archive;
                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("بیمار هنوز ترخیص نشده است");
                return;
            }
        }
    }
}