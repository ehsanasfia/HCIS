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
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmAnsweringBarcode : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        public frmAnsweringBarcode()
        {
            InitializeComponent();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReadCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var code = bbiCode.EditValue as string; // HERE!!! READ THIS CODE FROM THE BARCODE READER ++++++++++++++
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("کد وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                givenServiceDsBindingSource.DataSource = null;
                return;
            }
            //code = code.Trim();
            //Guid id = Guid.Empty;
            //try
            //{
            //    id = Guid.Parse(code);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("کد باید شامل 32 کاراکتر و 4 خط فاصله (-) باشد.", "کد نامعتبر", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    givenServiceDsBindingSource.DataSource = null;
            //    return;
            //}
            var id = Int32.Parse(code);
            if (!dc.GivenServiceMs.Any(x => x.ServiceCategoryID==(int)Category.آزمایش && x.SerialNumber == id))
            {
                MessageBox.Show("آزمایشی با این کد پیدا نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                givenServiceDsBindingSource.DataSource = null;
                return;
            }
            givenServiceDsBindingSource.DataSource = dc.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == (int)Category.آزمایش && x.SerialNumber == id).GivenServiceDs;
           
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var gsd = gridView1.GetRow(e.RowHandle) as GivenServiceD;
            if (gsd == null)
                return;
            if (gsd.GivenLaboratoryServiceD == null)
            {
                gsd.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { ID = gsd.ID };
            }
            if (e.Column == colResult)
            {
                gsd.Confirm = !string.IsNullOrWhiteSpace(e.Value as string);
            }
            else if (e.Column == colConfirm && e.Value as bool? == false && gsd.GivenLaboratoryServiceD != null)
            {
                gsd.GivenLaboratoryServiceD.Result = null;
            }
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقیت ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc.Dispose();
            dc = new HCISLabClassesDataContext();
            btnReadCode_ItemClick(null, null);
        }
        

        private void repositoryItemTextEdit1_Leave(object sender, EventArgs e)
        {
            btnReadCode_ItemClick(null, null);
        }

        private void frmAnsweringBarcode_Load(object sender, EventArgs e)
        {

        }
    }
}