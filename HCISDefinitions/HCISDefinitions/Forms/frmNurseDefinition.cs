using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Forms
{
    public partial class frmNurseDefinition : DevExpress.XtraEditors.XtraForm
    {
        Data.HCISDataClassesDataContext dc = new Data.HCISDataClassesDataContext();
        public bool isEdit { get; set; }

        public frmNurseDefinition()
        {
            InitializeComponent();
        }

        private void frmNurseDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            try
            {
                staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "پرستار").ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgNursedef();
            dlg.isEdit = false;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {         
            var dlg = new dlgNursedef();
            dlg.isEdit = true;
            dlg.dc = dc;
            var CurrentUser = staffBindingSource.Current as Staff;
            if (CurrentUser == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.EditingUser = CurrentUser;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                GetData();
            }
        }
    }
}