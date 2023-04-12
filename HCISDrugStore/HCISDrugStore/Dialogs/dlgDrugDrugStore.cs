using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgDrugDrugStore : DevExpress.XtraEditors.XtraForm
    {
        public HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        public PharmacyDrug PD { get; set; }
        public GivenServiceD gsd { get; set; }
        public bool isEdit { get; set; }
        List<PharmacyDrug> lst = new List<PharmacyDrug>();
        public dlgDrugDrugStore()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgDrugDrugStore_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                checkBox1.Checked = PD.NIS;
                skpPharmacy.EditValue = PD.Department;
                skpService.EditValue = PD.Service;
            }
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //skpPharmacy.EditValue = d.ID;

            var s = dc.Departments.Where(c => c.Pharmacy.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            departmentBindingSource.DataSource = s;

            skpPharmacy.EditValue = s;
            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PD.NIS = checkBox1.Checked;
            PD.NISUserIFullName = MainModule.UserFullName;
            PD.NISUserID = MainModule.UserID;
            PD.NISDate = MainModule.GetPersianDate(DateTime.Now);
            PD.NISTime = DateTime.Now.ToString("HH:mm");
            dc.SubmitChanges();
            gsd.NIS = checkBox1.Checked;
            dc.SubmitChanges();
            if (checkBox1.Checked == true)
            {
                gsd.GivenAmount = 0;
            }
            if (checkBox1.Checked == false)
            {
                gsd.GivenAmount = gsd.Amount;
            }
            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
            MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }
    }
}