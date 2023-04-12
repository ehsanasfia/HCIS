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
    public partial class dlgStockEs : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public Spu_LastAmountOfDrugResult ObjectRM { get; set; }
        public Department doc { get; set; }
        public bool isEdit { get; set; }
        public dlgStockEs()
        {
            InitializeComponent();
        }

        private void dlgStockEs_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //staffBindingSource.DataSource = x;
            //lkpResponsible.EditValue = x.UserID;
            try
            {


                var s = dc.Departments.Where(c => c.Pharmacy.ID == doc.ID).FirstOrDefault();
                departmentBindingSource1.DataSource = s;
                lkpFromUnit.EditValue = s;
                var x = dc.Departments.Where(c => c.Pharmacy.ID == Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")).FirstOrDefault();
                departmentBindingSource.DataSource = x;
                lkpToUnit.EditValue = x;
                departmentBindingSource.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
                && c.ID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") && c.ID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516") && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1") && c.Pharmacy.OtherPharmacy != true).OrderBy(c => c.Name);
                //////lkpToUnit.Properties.DisplayMember = s.ID;
                var v = dc.PharmacyDrugs.Where(c => c.Service.ID == ObjectRM.ID).FirstOrDefault();
                pharmacyDrugBindingSource.DataSource = v;
                skpDrug.EditValue = v;
            }
            catch
            {
                MessageBox.Show("داروخانه  برای شما ثبت نشده است");
            }
            //if (isEdit == true)
            //{
            //    lkpFromUnit.EditValue = ObjectRM.Department1;
            //    requestDsBindingSource.DataSource = ObjectRM.RequestDs.OrderBy(c => c.Service.Name);
            //    lst.AddRange(ObjectRM.RequestDs);
            //}

            //txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            //if (ObjectRM == null)
            //{
            //    ObjectRM = new RequestM();
            //}
            //if (isEdit == true)
            //    lkpFromUnit.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (radioGroup1.SelectedIndex == 0)
            {

                RequestD u = new RequestD();
                u.RequestM = new RequestM();
                u.RequestM.CreationTime = DateTime.Now.ToString("HH:mm");
                u.RequestM.CreationDate = txtDate.Text;

                u.RequestM.ToUnit = (lkpToUnit.EditValue as Department).ID;
                u.RequestM.UserFullname = MainModule.UserFullName;
                //ObjectRM.CreatorUserID = MainModule.UserID;

                u.RequestM.CreatorUserID = MainModule.UserID;

                u.RequestM.FromUnit = (lkpFromUnit.EditValue as Department).ID;
                u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
                u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                u.AmountDeliveryDate = txtDate.Text;
                u.Comment = memoEdit1.Text;
                u.Indent = true;
                u.AmountDelivery = Int32.Parse(txtAmount.Text);
                dc.RequestDs.InsertOnSubmit(u);

                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }

            else if (radioGroup1.SelectedIndex == 1)
            {
                RequestD u = new RequestD();
                u.RequestM = new RequestM();
                u.RequestM.CreationTime = DateTime.Now.ToString("HH:mm");
                u.RequestM.CreationDate = txtDate.Text;

                u.RequestM.ToUnit = (lkpFromUnit.EditValue as Department).ID;
                u.RequestM.UserFullname = MainModule.UserFullName;
                //ObjectRM.CreatorUserID = MainModule.UserID;

                u.RequestM.CreatorUserID = MainModule.UserID;

                u.RequestM.FromUnit = (lkpToUnit.EditValue as Department).ID;
                u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
                u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                u.AmountDeliveryDate = txtDate.Text;
                u.Comment = memoEdit1.Text;
                u.Indent = true;
                u.AmountDelivery = Int32.Parse(txtAmount.Text);
                dc.RequestDs.InsertOnSubmit(u);

                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
        }
    }
}