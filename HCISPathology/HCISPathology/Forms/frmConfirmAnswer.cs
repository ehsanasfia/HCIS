using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPathology.Data;

namespace HCISPathology.Forms
{
    public partial class frmConfirmAnswer : DevExpress.XtraEditors.XtraForm
    {
        HCISPathologyDataClassesDataContext dc = new HCISPathologyDataClassesDataContext();

        public frmConfirmAnswer()
        {
            InitializeComponent();
        }

        private void frmConfirmAnswre_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList();
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var GSM = givenServiceMBindingSource.Current as GivenServiceM;
            if (GSM == null)
                return;
            givenServiceDBindingSource.DataSource = GSM.GivenServiceDs.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.پاتولوژی && x.Service.ParentID != null).ToList();
            mmResult.Text = GSM.GivenDiagnosticServiceM.Result;
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;
            if (MessageBox.Show("آیا از تایید اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            cur.GivenDiagnosticServiceM.DrConfirm = true;
            cur.GivenDiagnosticServiceM.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
            cur.GivenDiagnosticServiceM.ConfirmTime = DateTime.Now.ToString("HH:mm");
            cur.GivenDiagnosticServiceM.Result = mmResult.Text;
            dc.SubmitChanges();
            gridControl2.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}