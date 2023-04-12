using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
namespace HCISSecondWard.Dialogs
{
    public partial class dlgAnbargardaniii : DevExpress.XtraEditors.XtraForm
    {
        public RequestD RD { get; set; }
        public HCISDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public bool isEdit { get; set; }
        public dlgAnbargardaniii()
        {
            InitializeComponent();
        }

        private void dlgAnbargardaniii_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            //radioGroup1.SelectedIndex = 0;
            try
            {
                //    if (radioGroup1.SelectedIndex == 0)
                //    {
                //        departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16).OrderBy(c => c.Name).ToList();
                //    }

                //    else if (radioGroup1.SelectedIndex == 1)
                //    {
                //        departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 10 || c.IDIntParent == 37).OrderBy(c => c.Name).ToList();
                //    }
                //    else if (radioGroup1.SelectedIndex == 2)
                //    {
                //        departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 53).OrderBy(c => c.Name).ToList();
                //    }
                //    else if (radioGroup1.SelectedIndex == 3)
                //    {
                //        departmentBindingSource1.DataSource = dc.Departments.Where(c => (c.TypeID == 32 && c.Name == "بهداشت طب صنعتی") ||
                //        c.Name == "آزمایشگاه بیمارستان").OrderBy(c => c.Name).ToList();
                //    }
                var x = dc.Departments.Where(c => c.ID == MainModule.MyDepartment.ID).FirstOrDefault();
                departmentBindingSource1.DataSource = x;
                lkpFromUnit.EditValue = x;
                var s = dc.Departments.Where(c => c.Pharmacy.ID == Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")).FirstOrDefault();
                departmentBindingSource.DataSource = s;
                lkpToUnit.EditValue = s;
                servicesBindingSource.DataSource = dc.Services.Where(lp => lp.CategoryID == 4).OrderBy(ccc => x.Name).ToList();

            }
            catch
            {
                MessageBox.Show("داروخانه  برای شما ثبت نشده است");
            }
            if (isEdit == true)
            {
                lkpToUnit.Enabled = false;
                lkpFromUnit.Enabled = false;
                lkpFromUnit.EditValue = ObjectRM.Department.ID;
                lkpToUnit.EditValue = ObjectRM.Department1;
                requestDsBindingSource.DataSource = ObjectRM.RequestDs.OrderBy(c => c.Service.Name);
                lst.AddRange(ObjectRM.RequestDs);
            }

            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }
            //  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID).ToList();
            // departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID && c.Name != "انبار").ToList();
            // servicesBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList(); مهم


            // servicesBindingSource.DataSource = org.Pharmacy.PharmacyDrugs.Select(c => c.Service.Name).ToList();
            if (isEdit == true)
                lkpToUnit.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkpFromUnit.Text == "")
            {
                MessageBox.Show("بخش را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            foreach (var item in lst)
            {
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار برای( " + item.Service.Name + " )وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            }


            if (lst.Count > 0)
            {
                if (isEdit == true)
                {
                    //foreach (var l in lst)
                    //{

                    //    if (l.AmountDelivery > 0)
                    //    {
                    //        MessageBox.Show("درخواست به تایید واحد انبار رسیده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //        return;
                    //    }
                    //}
                }
                if (isEdit == false)
                {
                    ObjectRM = new RequestM();
                }

                if (lkpToUnit.EditValue == null)
                {
                    MessageBox.Show("واحد صادر کننده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                ObjectRM.CreationTime = DateTime.Now.ToString("HH:mm");
                ObjectRM.CreationDate = txtDate.Text;
                ObjectRM.FromWard = true;
                ObjectRM.ToUnit = (lkpToUnit.EditValue as Department).ID;
                ObjectRM.UserFullname = MainModule.UserFullName;
                //ObjectRM.CreatorUserID = MainModule.UserID;
                if (lkpResponsible.EditValue == null)
                {
                    ObjectRM.CreatorUserID = MainModule.UserID;
                }
                ObjectRM.FromUnit = (lkpFromUnit.EditValue as Department).ID;
                if (isEdit == false)
                {
                    dc.RequestMs.InsertOnSubmit(ObjectRM);
                }
                dc.SubmitChanges();
                foreach (var item in lst)
                {

                    item.RequestM = ObjectRM;

                    //  dc.RequestDs.InsertOnSubmit(item);
                }
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("دارویی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var row = requestDsBindingSource.Current as RequestD;
            lst.Remove(row);
            requestDsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (skpDrug.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            RequestD u = new RequestD();
            u.Indent = true;
            //  u.AmountDelivery = Int32.Parse(txtAmount.Text);
            u.Service = (skpDrug.EditValue as Service);
            u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
            u.AmountDeliveryDate = txtDate.Text;

            if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            //u.Service = (skpDrug.EditValue as PharmacyDrug);
            //u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            //u.LastModificationTime = DateTime.Now.ToString("HH:mm");
            lst.Add(u);
            requestDsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
            txtAmount.Text = "";
            skpDrug.EditValue = null;
        }

        private void lkpFromUnit_EditValueChanged(object sender, EventArgs e)
        {
            //if (isEdit == true)
            //{

            //}
            //else
            //{
            //    var org = lkpFromUnit.EditValue as Department;
            //    if (org == null)
            //    {
            //        servicesBindingSource.DataSource = null;
            //        return;
            //    }
            //    pharmacyDrugBindingSource.DataSource = org.PharmacyDrugs.OrderBy(c => c.Service.Name).ToList();

            //}
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
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                RequestD u = new RequestD();
                u.Indent = true;
                //  u.AmountDelivery = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                u.AmountDeliveryDate = txtDate.Text;

                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                //u.Service = (skpDrug.EditValue as PharmacyDrug);
                //u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                //u.LastModificationTime = DateTime.Now.ToString("HH:mm");
                lst.Add(u);
                requestDsBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                GetData();
                txtAmount.Text = "";
                skpDrug.EditValue = null;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (skpDrug.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                RequestD u = new RequestD();
                u.Indent = true;
                //u.AmountDelivery = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                u.AmountDeliveryDate = txtDate.Text;

                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                //u.Service = (skpDrug.EditValue as PharmacyDrug);
                //u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                //u.LastModificationTime = DateTime.Now.ToString("HH:mm");
                lst.Add(u);
                requestDsBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                GetData();
                txtAmount.Text = "";
                skpDrug.EditValue = null;
            }
        }

        private void simpleButton3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}