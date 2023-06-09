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
    public partial class dlgInProtectionMain : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        List<FactorProduct> lst = new List<FactorProduct>();
        List<Protection> lstP = new List<Protection>();
        public Protection ObjectP { get; set; }
        public dlgInProtectionMain()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // factorProductsBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().FactorProducts;
        }

        private void dlgInProtectionMain_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            organBindingSource.DataSource = dc.Organs.ToList();
            organBindingSource1.DataSource = dc.Organs.ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtIDFactor.Text == "")
            {
                factorProductsBindingSource.DataSource = null;
                MessageBox.Show("کد فاکتور را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                var F = dc.Factors.FirstOrDefault(c => c.ID == Int32.Parse(txtIDFactor.Text));
                if (F != null)
                    factorProductsBindingSource.DataSource = dc.FactorProducts.Where(x => x.IDFactor == F.ID).ToList();
                else
                {
                    factorProductsBindingSource.DataSource = null;
                    MessageBox.Show("کد فاکتور یافت نشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }

            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var prs = lkpOrgan.EditValue as Organ;
            if (lkpOrgan.EditValue == null)
            {
                MessageBox.Show("مبداء را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpPerson.Text == "")
            {
                MessageBox.Show("نام تحویل دهنده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpDestination.EditValue == null)
            {
                MessageBox.Show("مقصد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpTahvilgirande.EditValue == null)
            {
                MessageBox.Show("تحویل گیرنده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
    
         
            var x = gridView3.GetSelectedRows();
            foreach (var c in x)
            {
                var a = gridView3.GetRow(c) as FactorProduct;
                var u = new Protection()
                {

                    InPutProduct = true,
                    Driver = txtDriver.Text,
                    Worker = txtWorker.Text,
                    Car = txtCar.Text,
                    CarNumber = txtCarNumber.Text,
                    IDProduct = a.IDProduct,
                    ProductName = a.ProductName,
                    DateInProtection = MainModule.GetPersianDate(DateTime.Now),
                    TimeInProtection = DateTime.Now.ToString("HH:mm"),
                    IPUser = MainModule.RoleName + "",
                    OrganName = (lkpOrgan.EditValue as Organ).Name,
                    PersonName = (lkpPerson.EditValue as Person).LastName,
                    Destination = (lkpDestination.EditValue as Organ).Name,
                    Tahvilgirande = (lkpTahvilgirande.EditValue as Person).LastName,
                    IDFactor =Int32.Parse(txtIDFactor.Text),
                    InProtection = true,
            };
                dc.Protections.InsertOnSubmit(u);
            }

            dc.SubmitChanges();           
            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
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

        private void lkpDestination_EditValueChanged(object sender, EventArgs e)
        {
            var org = lkpDestination.EditValue as Organ;
            if (org == null)
            {
                personBindingSource1.DataSource = null;
                return;
            }

            personBindingSource1.DataSource = org.Persons.ToList();
        }
    }
}



