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
    public partial class dlgOrderSeeEE : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public dlgOrderSeeEE()
        {
            InitializeComponent();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgOrderSeeEE_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //staffBindingSource.DataSource = x;
            //lkpResponsible.EditValue = x.UserID;


            var s = dc.Departments.Where(c => c.Pharmacy.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")).FirstOrDefault();
            departmentBindingSource1.DataSource = s;
            lkpFromUnit.EditValue = s.ID;
            departmentBindingSource.DataSource = s;
            lkpToUnit.EditValue = s.ID;
            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.RequestPermissions1.Any(d => d.FromUnit == s.ID));
            // lkpToUnit.EditValue = departmentBindingSource.DataSource;
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }
            //   departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID && c.Pharmacy.PharmacyStore == true).ToList();
            //lkpToUnit.EditValue = s.ID;
            //    lkpToUnit.EditValue = departmentBindingSource.DataSource;
            servicesBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c=> c.Name).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (skpDrug.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        

                RequestD u = new RequestD();
                //  u.Amount = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                u.AmountDelivery = 0;
                u.Indent = true;
                u.WarhouseKeeper = true;
                u.WarhouseKeeperDate = MainModule.GetPersianDate(DateTime.Now);
                u.WarhouseKeeperTime = DateTime.Now.ToString("HH:mm");
                u.WarhouseKeeperUSER = MainModule.UserID;
                u.WarhouseKeeperUSERFullName = MainModule.UserFullName;
                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                // u.DrugName = (skpDrug.EditValue as Service).Name;
                //u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                //u.LastModificationTime = DateTime.Now.ToString("HH:mm");
                lst.Add(u);
                requestDBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                GetData();
                txtAmount.Text = "";
                skpDrug.EditValue = null;
             

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var item in lst)
            {
                if (item.Amount == null)
                {
                    MessageBox.Show("مقدار برای( " + item.Service.Name + " )وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            }
            if (lkpToUnit.EditValue == null)
            {
                MessageBox.Show("واحد صادر کننده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ObjectRM.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectRM.CreationDate = txtDate.Text;
            ObjectRM.FromUnit = Guid.Parse(lkpFromUnit.EditValue.ToString());
            ObjectRM.ToUnit = Guid.Parse(lkpToUnit.EditValue.ToString());
            ObjectRM.UserFullname = MainModule.UserFullName;
            ObjectRM.CreatorUserID = MainModule.UserID;
            dc.RequestMs.InsertOnSubmit(ObjectRM);
            dc.SubmitChanges();
            foreach (var item in lst)
            {

                item.RequestM = ObjectRM;

                //  dc.RequestDs.InsertOnSubmit(item);
            }
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            var row = requestDBindingSource.Current as RequestD;
            lst.Remove(row);
            requestDBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
        }

        private void skpDrug_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (skpDrug.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {

                RequestD u = new RequestD();
                //  u.Amount = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                u.AmountDelivery = 0;
                u.Indent = true;
                u.WarhouseKeeper = true;
                u.WarhouseKeeperDate = MainModule.GetPersianDate(DateTime.Now);
                u.WarhouseKeeperTime = DateTime.Now.ToString("HH:mm");
                u.WarhouseKeeperUSER = MainModule.UserID;
                u.WarhouseKeeperUSERFullName = MainModule.UserFullName;
                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                // u.DrugName = (skpDrug.EditValue as Service).Name;
                //u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                //u.LastModificationTime = DateTime.Now.ToString("HH:mm");
                lst.Add(u);
                requestDBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                GetData();
                txtAmount.Text = "";
                skpDrug.EditValue = null;
        
            }
        }
    }
}