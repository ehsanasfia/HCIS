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
using DrugManagement.Dialogs;
namespace DrugManagement.Forms
{
    public partial class frmReportMDruSt : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<spuDrugStoreFactorForDayResult> lst = new List<spuDrugStoreFactorForDayResult>();
        List<Spu_DepDrugDeliveryResult> lst1 = new List<Spu_DepDrugDeliveryResult>();
        List<spuDrugCompany1Result> lst2 = new List<spuDrugCompany1Result>();
        bool delivery, request = false;

        public frmReportMDruSt()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            //  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            if (did == null)
                return;
            var temp = spinEdit1.Text + "/" + comboBoxEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            lst = dc.spuDrugStoreFactorForDay(pid, did.DrugID, temp).ToList();
            spuDrugStoreFactorForDayResultBindingSource.DataSource = lst;


            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }
        private void frmReportMDruSt_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")).ToList();
            spinEdit1.Text = "1397";
            GetData();

            var d = dc.Departments.Where(l => l.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
            var org = MainModule.MyDepartment.ID;
            if (org == null)
            {
                aPPharmcyDrugBindingSource.DataSource = null;
                return;
            }
            aPPharmcyDrugBindingSource.DataSource = dc.AP_PharmcyDrugs.Where(c => c.PharmacyID == org).OrderBy(c => c.NameandShape).ToList();
        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            if (did == null)
                return;
            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;

            var cell = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");
            if (cell == null)
                return;
            var temp = cell.ToString();
            if (string.IsNullOrWhiteSpace(temp))
                return;

            if (request)
            {
                var DD = dc.Services.FirstOrDefault(c => c.ID == did.DrugID).ID;
                lst2 = dc.spuDrugCompany1(temp,temp, DD).OrderBy(c => c.Name).ToList();
                spuDrugCompany1ResultBindingSource.DataSource = lst2;
            }
            else
                checkEdit1_CheckedChanged(null, null);

            if (delivery)
                spuDepDrugDeliveryResultBindingSource.DataSource = dc.Spu_DepDrugDelivery(did.DrugID, pid, temp, temp).ToList();
            else
                checkEdit2_CheckedChanged(null, null);


            spuDepDrugRequestResultBindingSource.DataSource = dc.Spu_DepDrugRequest(did.DrugID, pid, temp, temp).ToList();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        comboBoxEdit1.Text,
                        spinEdit1.Value,
                        Name = (lkpDrug.EditValue as AP_PharmcyDrug).NameandShape,
                        u.Date,
                        u.Enterd,
                        u.Consume,
                        u.Exit,
                        u.stock,

                    };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
            //   stiReport1.Design();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetData();
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            MESC.Text = dc.Services.FirstOrDefault(c => c.ID == did.DrugID).MESCCode_No;
            var Pr = dc.SpuDrugTariff(MainModule.MyDepartment.ID, MainModule.GetPersianDate(DateTime.Now)).FirstOrDefault(c => c.ID == did.DrugID).price.ToString();
            textEdit2.Text = Pr;

            checkEdit1_CheckedChanged(null, null);
            checkEdit2_CheckedChanged(null, null);
        }

        private void lkpDrug_Popup(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            if (did == null)
                return;
            var DD = dc.Services.FirstOrDefault(c => c.ID == did.DrugID).ID;

            if (checkEdit1.Checked)
            {
                request = false;
                var year = spinEdit1.Text;
                var f = year + "/01/01";
                var t = year + "/12/30";
                spuDrugCompany1ResultBindingSource.DataSource = dc.spuDrugCompany1(f, t, DD).OrderBy(c => c.Name).ToList();
            }
            else
            {
                request = true;
                gridView1_Click(null, null);
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            if (did == null)
                return;
            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;

            if (checkEdit2.Checked)
            {
                delivery = false;
                var year = spinEdit1.Text;
                var f = year + "/01/01";
                var t = year + "/12/30";
                spuDepDrugDeliveryResultBindingSource.DataSource = dc.Spu_DepDrugDelivery(did.DrugID, pid, f, t).ToList();
            }
            else
            {
                delivery = true;
                gridView1_Click(null, null);
            }
        }
    }

}