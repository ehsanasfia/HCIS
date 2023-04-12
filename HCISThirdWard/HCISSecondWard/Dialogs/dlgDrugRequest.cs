﻿using System;
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
    public partial class dlgDrugRequest : DevExpress.XtraEditors.XtraForm
    {
        //HCISDataContext dc = new HCISDataContext();
        public HCISDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public bool isEdit { get; set; }
        public dlgDrugRequest()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgDrugRequest_Load(object sender, EventArgs e)
        {
            GetData();
            requestDBindingSource.DataSource = dc.RequestDs.Where(x => x.RequestM.ToUnit == MainModule.MyDepartment.ID && x.DrugDelivery != true);
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).OrderBy(x => x.Name);
        }
        private void GetData()
        {

            try
            {
               
                var dep = dc.Departments.Where(z => z.ID == MainModule.MyDepartment.ID).FirstOrDefault();
                departmentBindingSource1.DataSource = dep;
                lkpFromUnit.EditValue = dep.ID;
                departmentBindingSource.DataSource = dc.Departments.Where(c => (c.TypeID == 11) 
               // || c.ID == Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")
                 || c.ID == Guid.Parse("7fd91942-ce64-4f5d-bc49-f9daae937bb8")
                      || c.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")

                );
            }
            catch
            {
                MessageBox.Show("داروخانه  برای شما ثبت نشده است");
            }
            if (isEdit == true)
            {
                lkpToUnit.EditValue = ObjectRM.Department1;
                requestDsBindingSource.DataSource = ObjectRM.RequestDs;
                lst.AddRange(ObjectRM.RequestDs);
            }

            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }
            if (isEdit == true)
                lkpToUnit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
            u.Amount = Int32.Parse(txtAmount.Text);
            u.Service = (skpDrug.EditValue as Service);
            if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

            lst.Add(u);
            requestDsBindingSource.DataSource = lst;
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
            if (lst.Count > 0)
            {
                if (isEdit == true)
                {
                    foreach (var l in lst)
                    {

                        if (l.AmountDelivery > 0)
                        {
                            MessageBox.Show("درخواست به تایید واحد انبار رسیده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                    }
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
                ObjectRM.ToUnit = (lkpToUnit.EditValue as Department).ID;
                ObjectRM.CreatorUserID = MainModule.UserID;
                ObjectRM.UserFullname = MainModule.UserFullName;
                //if (lkpResponsible.EditValue == null)
                //{
                    ObjectRM.CreatorUserID = MainModule.UserID;
                //}
                // ObjectRM.FromUnit = Guid.Parse(lkpFromUnit.EditValue.ToString());
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

        private void lkpToUnit_EditValueChanged(object sender, EventArgs e)
        {
            //if (isEdit == true)
            //{

            //}
            //else
            //{
            //    var org = lkpToUnit.EditValue as Department;
            //    if (org == null)
            //    {
            //        servicesBindingSource.DataSource = null;
            //        return;
            //    }
            //    pharmacyDrugBindingSource.DataSource = org.PharmacyDrugs.OrderBy(c => c.Service.Name).ToList();

            //}
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            var row = requestDsBindingSource.Current as RequestD;
            lst.Remove(row);
            requestDsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
        }

        private void lkpFromUnit_EditValueChanged(object sender, EventArgs e)
        {

            //txtPerson.Text = org.Pharmacy.Staff.Person.LastName;
        }

        private void lkpToUnit_DragOver(object sender, DragEventArgs e)
        {

        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
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
                u.Amount = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

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
                u.Amount = Int32.Parse(txtAmount.Text);
                u.Service = (skpDrug.EditValue as Service);
                if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

                lst.Add(u);
                requestDsBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                GetData();
                txtAmount.Text = "";
                skpDrug.EditValue = null;
            }
        }
    }
}