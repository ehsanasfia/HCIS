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
using HCISOnCall.Data;
using HCISOnCall.Classes;

namespace HCISOnCall.Forms
{
    public partial class frmShift : DevExpress.XtraEditors.XtraForm
    {
        HCISOnCallDataContext dc = new HCISOnCallDataContext();
        Shift ObjectSH;

        public frmShift()
        {
            InitializeComponent();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            if (ObjectSH == null)
            {
                ObjectSH = new Shift();
            }
            ObjectSH.Date = MainModule.GetPersianDate(DateTime.Now);
            ShiiftBindingSource.DataSource = ObjectSH;
            shiftBindingSource.DataSource = dc.Shifts.OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDate.Text)
                || string.IsNullOrWhiteSpace(txtFrom.Text) || string.IsNullOrWhiteSpace(txtTo.Text)
                || string.IsNullOrWhiteSpace(cmbShiftName.Text))
            {
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ObjectSH.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectSH.CreationUser = MainModule.UserFullName;
            dc.Shifts.InsertOnSubmit(ObjectSH);
            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            shiftBindingSource.DataSource = dc.Shifts.OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();

            ObjectSH = new Shift();
            ShiiftBindingSource.DataSource = ObjectSH;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}