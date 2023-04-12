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
    public partial class frmNosakhtekrari2 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_RepeatedPrescription1Result> lst = new List<Spu_RepeatedPrescription1Result>();
        public frmNosakhtekrari2()
        {
            InitializeComponent();
        }

        private void frmNosakhtekrari2_Load(object sender, EventArgs e)
        {
            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //   serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            GetData();
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            //var pid = lookUpEdit1.EditValue as Guid?;
            //if (pid == null)
            //    return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = int.Parse(spinEdit1.Text);
            if (string.IsNullOrWhiteSpace(temp))
                return;

            //lst = dc.Spu_RepeatedPrescription1(temp, temp2, temp3).ToList();
            //spuRepeatedPrescription1ResultBindingSource.DataSource = lst;

     

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}