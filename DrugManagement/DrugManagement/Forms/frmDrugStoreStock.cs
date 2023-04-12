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
namespace DrugManagement.Forms
{
    public partial class frmDrugStoreStock : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<SpuDrogStoreStockResult> lst = new List<SpuDrogStoreStockResult>();
        public frmDrugStoreStock()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
           // departmentsBindingSource.DataSource = new DrugManagement.Data.HCISDataContexDataContext().Departments;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugStoreStock_Load(object sender, EventArgs e)
        {
            GetData();
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            // var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();
            var d = dc.Departments.Where(l => l.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {

            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //var yearmonth = temp.Substring(0, 7);
            lst = dc.SpuDrogStoreStock(pid, temp).ToList();
           spuDrogStoreStockResultBindingSource.DataSource = lst;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        lkpPharmcy.Text,
                        u.Amount,
                        u.Name,
                        u.Shape,
                        u.Money,
                        u.MESCCode_No
 

                    };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
     //  stiReport1.Design();
        }
    }
}