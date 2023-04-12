﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;
namespace HCISManagementDashboard.Forms
{
    public partial class frmPDrug : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_PatientDrugResult> lst = new List<Spu_PatientDrugResult>();
      //  private readonly object vwdrgPatientDrugBindingSource;

        public frmPDrug()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
          //  vw_drgPatientDrugsBindingSource.DataSource = new HCISManagementDashboard.Data.HCISDataContexDataContext().Vw_drgPatientDrugs;
        }

        private void frmPDrug_Load(object sender, EventArgs e)
        {
            //textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            //textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
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

            //var temp = spinEdit1.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            var temp = spinEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var y = temp ;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst = dc.Spu_PatientDrug(y)/*.Where(x => x.PharmcyName == MainModule.MyDepartment.Name)*/.OrderByDescending(c=> c.Date).ToList();
            spuPatientDrugResultBindingSource.DataSource = lst;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (spinEdit1.Text == "")
            {
                return;
            }
            var dlg = new Dialogs.dlgPerson();
            dlg.Text = "انتخاب بیمار";
            dlg.dc = dc;
            dlg.PCode = spinEdit1.Text;
           
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {

                spinEdit1.Text = dlg.NationalCode;
                GetData();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Money,
                        u.Total,
                        u.Name,
                        u.PFirstName,
                        u.PLirstName,
                        u.Expr1,
                        u.Date,
                        u.Speciality,
                        

                    };
            //stiReport1.Dictionary.Variables.Add("d", lookUpEdit1.Text);
            //stiReport1.Dictionary.Variables.Add("f", textEdit1.Text);
            //stiReport1.Dictionary.Variables.Add("t", textEdit1.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
    }
 
}