using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class dlgRecall : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Recall> lstRCL;

        public dlgRecall()
        {
            InitializeComponent();
        }

        private void dlgRecall_Load(object sender, EventArgs e)
        {
            if (lstRCL == null)
                lstRCL = new List<Recall>();
            screeningBindingSource.DataSource = dc.Screenings.Where(x => x.Finish != true).OrderBy(c => c.Number).OrderBy(c => c.Date).ToList();
            var IMPHOID = MainModule.InstallLocation.IMPHOID;
            if (IMPHOID == null)
            {
                MessageBox.Show("منطقه درمانی مشخص نشده");
                return;
            }
            viewIMPHOHISPersonBindingSource.DataSource = dc.View_IMPHO_HIS_Persons.Where(x => x.IDValidCenter != IMPHOID).ToList();
        }

        private void slkScreening_EditValueChanged(object sender, EventArgs e)
        {
            var scrn = slkScreening.EditValue as Screening;
            lstRCL = dc.Recalls.Where(x => x.Screening == scrn).ToList();
            recallBindingSource.DataSource = lstRCL;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var scrn = slkScreening.EditValue as Screening;
            if (scrn == null)
            {
                MessageBox.Show("لطفا نوع غربالگری را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if(string.IsNullOrWhiteSpace(txtRecallDate.Text))
            {
                MessageBox.Show("لطفا تاریخ فراخوان را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            foreach (var item in gridView2.GetSelectedRows())
            {
                var prs = gridView2.GetRow(item) as View_IMPHO_HIS_Person;
                var rcll = new Recall()
                {
                    IDPerson = prs.ID,
                    IDScreening = scrn.ID,
                    RecallDate = txtRecallDate.Text.Trim(),
                    RecallCause = txtRecallCause.Text.Trim(),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                };

                if (!lstRCL.Any(c => c.IDPerson == prs.ID))
                    dc.Recalls.InsertOnSubmit(rcll);
            }

            dc.SubmitChanges();
            txtRecallCause.Text = null;
            txtRecallDate.Text = null;
            lstRCL = dc.Recalls.Where(x => x.Screening == scrn).ToList();
            recallBindingSource.DataSource = lstRCL;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}