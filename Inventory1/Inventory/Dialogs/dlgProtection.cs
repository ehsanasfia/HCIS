﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Dialogs
{
    public partial class dlgProtection : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }

        List<Protection> lst = new List<Protection>();

        List<Protection> del = new List<Protection>();
        public Protection ObjectP { get; set; }

        public dlgProtection()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // organsBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Organs;
            // This line of code is generated by Data Source Configuration Wizard
            // protectionsBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Protections;
        }

        private void dlgProtection_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
           
            organsBindingSource.DataSource = dc.Organs.ToList();
            organBindingSource.DataSource = dc.Organs.ToList();
            productBindingSource.DataSource = dc.Products.Where(x => x.Parent != null).ToList();
            //protectionsBindingSource.DataSource = dc.Protections.Where(x=> x.InPutProduct == true).ToList();
            protectionProductBindingSource.DataSource = dc.ProtectionProducts.ToList();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var prs = lkpOrgan.EditValue as Organ;
            if (prs == null)
            {
                MessageBox.Show("درخواست دهنده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (txtWorker.Text == "")
            {
                MessageBox.Show("نام حامل بار را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtCar.Text == "")
            {
                MessageBox.Show("نام خودرو را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
         
       
            if (lkpPerson.Text == "")
            {
                MessageBox.Show("نام تحویل دهنده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpTahvilgirande.Text == "")
            {
                MessageBox.Show("نام تحویل گیرنده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            Protection u = new Protection();
            u.InPutProduct = true;
            u.IDProduct = (lkpProduct.EditValue as Product).ID;
            u.ProductName = (lkpProduct.EditValue as Product).FaName;
            u.Amount =Int32.Parse(txtAmount.Text);
            u.DesProduct = txtDes.Text;
            u.DateInProtection = MainModule.GetPersianDate(DateTime.Now);
            u.TimeInProtection = DateTime.Now.ToString("HH:mm");
            u.IPUser = MainModule.RoleName + "";
            u.HouseKeeping = txtHouseKeeping.Text;
            u.InProtection = true;
            lst.Add(u);
            MessageBox.Show("ثبت شد");
            txtHouseKeeping.Text = "";
            txtAmount.Text = "0";
            txtDes.Text = "";
            protectionBindingSource.DataSource = lst;
            gridControl2.RefreshDataSource();
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (var item in lst)
            {
                var u = new Protection()
                {
                    InPutProduct = true,
                    Driver = txtDriver.Text,
                    Worker = txtWorker.Text,
                    Car = txtCar.Text,
                    CarNumber = txtCarNumber.Text,
                    IDProduct = item.IDProduct,
                    Amount = item.Amount,
                    OrganName = (lkpOrgan.EditValue as Organ).Name,
                    PersonName = (lkpPerson.EditValue as Person).LastName,
                    Destination = (lkpDestination.EditValue as Organ).Name,
                    Tahvilgirande = (lkpTahvilgirande.EditValue as Person).LastName,
                    ProductName = item.ProductName,
                    DesProduct = item.DesProduct,
                    DateInProtection = item.DateInProtection ,
                    TimeInProtection =   item.TimeInProtection,
                    IPUser =  item.IPUser,
                    HouseKeeping = item.HouseKeeping,
                    InProtection =item.InProtection,
            };
                dc.Protections.InsertOnSubmit(u);
            }
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void lkpOrgan_EditValueChanged_1(object sender, EventArgs e)
        {
            var org = lkpOrgan.EditValue as Organ;
            if (org == null)
            {
                personBindingSource.DataSource = null;
                return;
            }

            personBindingSource.DataSource = org.Persons.ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var cu = protectionBindingSource.Current as Protection;
            if(cu == null)
            {
                return;
            }
            dc.Protections.DeleteOnSubmit(cu);
            dc.SubmitChanges();
            protectionBindingSource.DataSource = del;
        }

        private void lkpDestination_EditValueChanged(object sender, EventArgs e)
        {
            var org = lkpOrgan.EditValue as Organ;
            if (org == null)
            {
                personBindingSource.DataSource = null;
                return;
            }

            personBindingSource.DataSource = org.Persons.ToList();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var org = lkpOrgan.EditValue as Organ;
            if (org == null)
            {
                personBindingSource.DataSource = null;
                return;
            }

            personBindingSource.DataSource = org.Persons.ToList();
        }

        private void lkpDestination_EditValueChanged_1(object sender, EventArgs e)
        {
            var org = lkpDestination.EditValue as Organ;
            if (org == null)
            {
                personBindingSource1.DataSource = null;
                return;
            }
            personBindingSource1.DataSource = org.Persons.ToList();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            foreach (var item in lst)
            {
                var u = new Protection()
                {
                    InPutProduct = true,
                    Driver = txtDriver.Text,
                    Worker = txtWorker.Text,
                    Car = txtCar.Text,
                    CarNumber = txtCarNumber.Text,
                    IDProduct = item.IDProduct,
                    Amount = item.Amount,
                    OrganName = (lkpOrgan.EditValue as Organ).Name,
                    PersonName = (lkpPerson.EditValue as Person).LastName,
                    Destination = (lkpDestination.EditValue as Organ).Name,
                    Tahvilgirande = (lkpTahvilgirande.EditValue as Person).LastName,
                    ProductName = item.ProductName,
                    DesProduct = item.DesProduct,
                    DateInProtection = item.DateInProtection,
                    TimeInProtection = item.TimeInProtection,
                    IPUser = item.IPUser,
                    HouseKeeping = item.HouseKeeping,
                    InProtection = item.InProtection,
                };
                dc.Protections.InsertOnSubmit(u);
            }
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }
    }

}