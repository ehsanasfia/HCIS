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
using DrugManagement.Dialogs;
using DrugManagement.Data;

namespace DrugManagement.Forms
{
    public partial class frmNis : DevExpress.XtraEditors.XtraForm
    {
        SecurityDataContext sec = new SecurityDataContext();
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmNis()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgNIS();
            dlg.Text = "تعریف داروهای NIS ";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }
        private void GetData()
        {
            //var userid = sec.tblUsers.FirstOrDefault(k => k.UserName == MainModule.UserName && k.ApplicationID == 3106).UserID;
            //var x = dc.Staffs.Where(c => c.UserID == userid).FirstOrDefault();
            //////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();
            ////var d = dc.Departments.Where(l => l.ID == f.ID).FirstOrDefault();

            pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(c=> c.PharmacyID == MainModule.MyDepartment.ID).OrderBy(c=> c.Service.Name).ToList();
        }

        private void frmNis_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pharmacyDrugBindingSource.EndEdit();
            dc.SubmitChanges();

            MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var c = pharmacyDrugBindingSource.Current as PharmacyDrug;
            if (c == null)
            {
            }
   
            c.NISDate = MainModule.GetPersianDate(DateTime.Now);
            //  item.Indent = true;
            c.NISTime = DateTime.Now.ToString("HH:mm");
            c.NISUserID = MainModule.UserID;
            c.NISUserIFullName = MainModule.UserFullName;

            pharmacyDrugBindingSource.EndEdit();
            dc.SubmitChanges();
    
            GetData();

           
        }
    }

}
