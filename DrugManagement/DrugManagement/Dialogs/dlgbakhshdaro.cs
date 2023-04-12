﻿using System;
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
    public partial class dlgbakhshdaro : DevExpress.XtraEditors.XtraForm
    {
        public RequestD RD { get; set; }
        public HCISDataContexDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public bool isEdit { get; set; }
     
        public dlgbakhshdaro()
        {
            InitializeComponent();
        }

        private void dlgbakhshdaro_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            radioGroup1.SelectedIndex = 0;
            try
            {
                if(radioGroup1.SelectedIndex == 0)
                {
                    departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16 ).OrderBy(c => c.Name).ToList();
                }

                else if (radioGroup1.SelectedIndex == 1)
                {
                    departmentBindingSource1.DataSource = dc.Departments
               .Where(c => c.Parent == Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e") && c.TypeID != 15
               && c.TypeID != 11 && c.TypeID != 12 && c.TypeID != 16 && c.TypeID != 52 && c.TypeID != 53
               /*|| c.IDIntParent == 37) || (c.TypeID == 66 || c.IDIntParent == 37*/).OrderBy(c => c.Name).ToList();
                }
                else if (radioGroup1.SelectedIndex == 2)
                {
                    departmentBindingSource1.DataSource = dc.Departments.Where(c =>  c.TypeID == 53).OrderBy(c => c.Name).ToList();
                }
                else if (radioGroup1.SelectedIndex == 3)
                {
                    departmentBindingSource1.DataSource = dc.Departments.Where(c => (c.TypeID == 32 && c.Name == "بهداشت طب صنعتی") ||
                    c.Name == "آزمایشگاه بیمارستان" ).OrderBy(c => c.Name).ToList();
                }
                var s = dc.Departments.Where(c => c.Pharmacy.ID == MainModule.MyDepartment.ID).FirstOrDefault();
                departmentBindingSource.DataSource = s;
                lkpToUnit.EditValue = s;

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
                ObjectRM.FromUnit = Guid.Parse(lkpFromUnit.EditValue.ToString());
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var row = requestDsBindingSource.Current as RequestD;
            lst.Remove(row);
            requestDsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
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
            u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
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

        private void lkpToUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (isEdit == true)
            {

            }
            else
            {
                var org = (lkpToUnit.EditValue as Department);
                if (org == null)
                {
                    servicesBindingSource.DataSource = null;
                    return;
                }
                pharmacyDrugBindingSource.DataSource = org.PharmacyDrugs.OrderBy(c => c.Service.Name).ToList();

            }
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
                u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
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
                u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
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

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                layoutControlItem8.Text = "بخش:";
                departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16).OrderBy(c => c.Name).ToList();
            }

            else if (radioGroup1.SelectedIndex == 1)
            {
                layoutControlItem8.Text = "کلینیک:";
                //departmentBindingSource1.DataSource = dc.Departments
                //        .Where(c => ((c.TypeID == 10 || c.IDIntParent == 37) || (c.TypeID == 66 || c.IDIntParent == 37))).OrderBy(c => c.Name).ToList();
                departmentBindingSource1.DataSource = dc.Departments
         .Where(c => c.Parent == Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e") && c.TypeID != 15
         && c.TypeID != 11 && c.TypeID != 12 && c.TypeID != 16 && c.TypeID != 52 && c.TypeID != 53
         /*|| c.IDIntParent == 37) || (c.TypeID == 66 || c.IDIntParent == 37*/).OrderBy(c => c.Name).ToList();
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                layoutControlItem8.Text = "پرستاری:";
                departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 53).OrderBy(c => c.Name).ToList();
            }
            else if (radioGroup1.SelectedIndex == 3)
            {

                layoutControlItem8.Text = "متفرقه:";
                departmentBindingSource1.DataSource = dc.Departments.Where(c => (c.TypeID == 32 && c.Name == "بهداشت طب صنعتی") ||
                     c.Name == "آزمایشگاه بیمارستان").OrderBy(c => c.Name).ToList();
            }
        }
    }
}