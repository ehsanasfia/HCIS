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
    public partial class frmHoliday : DevExpress.XtraEditors.XtraForm
    {
        HCISOnCallDataContext dc = new HCISOnCallDataContext();
        Holiday ObjectHD;

        public frmHoliday()
        {
            InitializeComponent();
        }

        private void frmHoliday_Load(object sender, EventArgs e)
        {
            if(ObjectHD == null)
            {
                ObjectHD = new Holiday();
            }
            ObjectHD.Date = MainModule.GetPersianDate(DateTime.Now);
            HoliidayBindingSource.DataSource = ObjectHD;
            holidayBindingSource.DataSource = dc.Holidays.OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(string.IsNullOrEmpty(txtDate.Text) || string.IsNullOrWhiteSpace(txtCermony.Text))
            {
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ObjectHD.Holiday1 = true;
            ObjectHD.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectHD.CreationUser = MainModule.UserFullName;
            dc.Holidays.InsertOnSubmit(ObjectHD);
            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            holidayBindingSource.DataSource = dc.Holidays.OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();

            ObjectHD = new Holiday();
            HoliidayBindingSource.DataSource = ObjectHD;
        }

        private void DeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = holidayBindingSource.Current as Holiday;
            if (cur == null)
                return;
            dc.Holidays.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            holidayBindingSource.DataSource = dc.Holidays.OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}