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
using HCISPathology.Data;

namespace HCISPathology.Forms
{
    public partial class frmSampleAnswers2 : DevExpress.XtraEditors.XtraForm
    {
        HCISPathologyDataClassesDataContext dc = new HCISPathologyDataClassesDataContext();
        SampleAnswer EditingSA;

        public frmSampleAnswers2()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmSampleAnswers2_Load(object sender, EventArgs e)
        {
            btnCancel_ItemClick(null, null);
        }

        private void EndEdit()
        {
            sampleAnswersBindingSource.EndEdit();
            SampleAnswerBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                if (EditingSA == null)
                {
                    EditingSA = new SampleAnswer();
                }
                var srv = dc.Services.FirstOrDefault(x => x.ParentID == null && x.Name == "پاتولوژی");
                sampleAnswersBindingSource.DataSource = dc.SampleAnswers.Where(x => x.Service != null && x.Service == srv).ToList();
                SampleAnswerBindingSource.DataSource = EditingSA;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingSA.ID == Guid.Empty || !dc.SampleAnswers.Any(x => x.ID == EditingSA.ID))
            {
                var srv = dc.Services.FirstOrDefault(x => x.ParentID == null && x.Name == "پاتولوژی");
                var gpSrv = dc.Services.FirstOrDefault(x => x.ID == srv.ID);
                EditingSA.Service = gpSrv;

                dc.SampleAnswers.InsertOnSubmit(EditingSA);
            }
            dc.SubmitChanges();
            btnCancel_ItemClick(null, null);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingSA = null;
            GetData();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var DL = sampleAnswersBindingSource.Current as SampleAnswer;
            if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            dc.SampleAnswers.DeleteOnSubmit(DL);
            dc.SubmitChanges();
            btnNew.PerformClick();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var row = sampleAnswersBindingSource.Current as SampleAnswer;
            if (row == null)
            {
                return;
            }
            dc.Dispose();
            dc = new HCISPathologyDataClassesDataContext();

            EditingSA = dc.SampleAnswers.FirstOrDefault(x => x.ID == row.ID);
            GetData();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnCancel.PerformClick();
        }
    }
}