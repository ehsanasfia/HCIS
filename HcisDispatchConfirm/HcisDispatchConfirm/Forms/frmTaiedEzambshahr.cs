using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HcisDispatchConfirm.Data;

namespace HcisDispatchConfirm.Forms
{
    public partial class frmTaiedEzambshahr : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmTaiedEzambshahr()
        {
            InitializeComponent();
        }

        private void frmTaiedEzambshahr_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

    
        }
        private void GetData()
        {
            dispatchBindingSource.DataSource = dc.Dispatches.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList(); 
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {

            dispatchBindingSource.DataSource = dc.Dispatches.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {

            dispatchBindingSource.DataSource = dc.Dispatches.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView22_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("جناب (" + MainModule.UserFullName + ") آیا اعزام بیمار را تایید میکنید ؟"

             , "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var current = dispatchBindingSource.Current as Dispatch;
            if (current == null)
            {
                return;
            }
            var dlg = new Dialogs.dlgTaiedEzam();
            dlg.Text = "تایید اعزام";
            dlg.dc = dc;
            dlg.dis = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
            var current = dispatchBindingSource.Current as Dispatch;
            if (current == null)
            {
                return;
            }
            if (MessageBox.Show("جناب (" + MainModule.UserFullName + ") آیا اعزام بیمار را تایید میکنید ؟"

               , "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var dlg = new Dialogs.dlgTaiedEzam();
            dlg.Text = "تایید اعزام";
            dlg.dc = dc;
            dlg.dis = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}