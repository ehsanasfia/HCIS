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
using DrugManagement.Data;
using DrugManagement.Dialogs;

namespace DrugManagement.Forms
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
       
    //List<Person> lst = new List<Person>();
    //    public Staff ObjectS { get; set; }
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            GetData();
        
        }
        private void GetData()
        {
            userDrugManagementBindingSource.DataSource = dc.UserDrugManagements.ToList();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = userDrugManagementBindingSource.Current as UserDrugManagement;
            if (current == null)
            {
                return;
            }
           // var x = dc.Staffs.Where(c => c.UserID == current.UserID).FirstOrDefault();
            if (dc.Staffs.Any(c => c.UserID == current.UserID))
            {

                var dlg = new dlgUser();
                dlg.Text = "ویرایش";
                dlg.isEditt = true;
                dlg.Doc = current;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    //try
                    //{
                        dc.SubmitChanges();
                    MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("  ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                    // Close();
                }
            }
            else
            {
                var z = userDrugManagementBindingSource.Current as UserDrugManagement;
                if (z == null)
                {
                    return;
                }
                var dlg = new dlgUser();
                dlg.Text = "اطلاعات کاربران";
                dlg.Doc = z;
                dlg.isEditt = false;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    //try
                    //{
                        dc.SubmitChanges();
                    MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("  ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                }
            }
        }
        

        private void gridView1_Click(object sender, EventArgs e)
        {

            var current = userDrugManagementBindingSource.Current as UserDrugManagement;
            if (current == null)
            {
                return;
            }
            // var x = dc.Staffs.Where(c => c.UserID == current.UserID).FirstOrDefault();
            if (dc.Staffs.Any(c => c.UserID == current.UserID))
            {

                var dlg = new dlgUser();
                dlg.Text = "ویرایش";
                dlg.isEditt = true;
                dlg.Doc = current;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    //try
                    //{
                    dc.SubmitChanges();
                    MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("  ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                    // Close();
                }
            }
            else
            {
                var z = userDrugManagementBindingSource.Current as UserDrugManagement;
                if (z == null)
                {
                    return;
                }
                var dlg = new dlgUser();
                dlg.Text = "اطلاعات کاربران";
                dlg.Doc = z;
                dlg.isEditt = false;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    //try
                    //{
                    dc.SubmitChanges();
                    MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("  ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                }
                }
            }
        
    }
}