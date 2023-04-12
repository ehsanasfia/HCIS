using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Classes;
using HCISSecondWard.Data;

namespace HCISSecondWard.Forms
{
    public partial class frmDischargedPatients : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmDischargedPatients()
        {
            InitializeComponent();
        }

        private void frmDischargedPatients_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            simpleButton1_Click(null, null);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var from = txtFromDate.Text;
            var to = txtToDate.Text;
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x =>
                        x.ServiceCategoryID == 10
                        && x.DepartmentID == MainModule.MyDepartment.ID
                        && x.Confirm
                        && x.Admitted && x.Dossier != null && x.Dossier.Discharge1 != null
                        && x.Dossier.Date.CompareTo(from) >= 0
                        && x.Dossier.Date.CompareTo(to) <= 0).OrderByDescending(x => x.Dossier.Discharge1.DischargeDate).ToList();

            gridControl1.RefreshDataSource();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;

            if (cur.Dossier.LockBilling == true)
            {
                MessageBox.Show("برنامه بیمار قفل شده است امکان ویرایش وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("آیا مایل به بازگشت بیمار به بخش فعلی هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            cur.Dossier.Editable = true;
            cur.Confirm = false;
            dc.SubmitChanges();

            simpleButton1_Click(null, null);

            MessageBox.Show("بازگشت بیمار انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}