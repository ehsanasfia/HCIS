using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgDrugDrugStore : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public PharmacyDrug PD { get; set; }
        public bool isEdit { get; set; }
        List<PharmacyDrug> lst =new List<PharmacyDrug>();
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
            if (skpPharmacy.Text == "")
            {
                MessageBox.Show("دارویی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (isEdit == true)
            {
                if (dc.PharmacyDrugs.Any(c => c.Service == (skpService.EditValue as Service) && c.Department == (skpPharmacy.EditValue as Department))) { MessageBox.Show("دارو قبلا به داروخانه اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                //PharmacyDrug u = new PharmacyDrug();
                PD.Service = (skpService.EditValue as Service);
                PD.Department = (skpPharmacy.EditValue as Department);
                PD.NIS = checkBox1.Checked;
                PD.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                PD.CreationTime = DateTime.Now.ToString("HH:mm");
                dc.SubmitChanges();

            }
            else
            {
                PharmacyDrug u = new PharmacyDrug();
                if (dc.PharmacyDrugs.Any(c => c.Service == (skpService.EditValue as Service) && c.Department == (skpPharmacy.EditValue as Department))) { MessageBox.Show("دارو قبلا به داروخانه اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                u.Service = (skpService.EditValue as Service);
                u.Department = (skpPharmacy.EditValue as Department);
                u.NIS = checkBox1.Checked;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                dc.PharmacyDrugs.InsertOnSubmit(u);
         
                dc.SubmitChanges();
            }

            DialogResult = DialogResult.OK;
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }
    }
}