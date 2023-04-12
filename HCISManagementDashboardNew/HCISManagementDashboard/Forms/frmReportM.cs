using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;
using HCISManagementDashboard.Dialogs;

namespace HCISManagementDashboard.Forms
{
    public partial class frmReportM : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_MontlyStockResult> lst = new List<Spu_MontlyStockResult>();
        List<Spu_DepDrugDeliveryResult> lst1 = new List<Spu_DepDrugDeliveryResult>();
        public frmReportM()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmReportM_Load(object sender, EventArgs e)
        {

            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            spinEdit1.Text = "1397";
            GetData();
           
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();

            var org = MainModule.MyDepartment.ID;
            if (org == null)
            {
                aPPharmcyDrugBindingSource.DataSource = null;
                return;
            }
            aPPharmcyDrugBindingSource.DataSource = dc.AP_PharmcyDrugs.Where(c => c.PharmacyID == org).OrderBy(c => c.NameandShape).ToList();
            // pharmacyDrugBindingSource.DataSource = org.PharmacyDrugs.OrderBy(x => x.Service.Name).ToList();

            //lkpPharmcy.EditValue = d.ID;
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
            var temp = spinEdit1.Text+"/" + comboBoxEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
           //  var yearmonth = temp.Substring(0, 7);
          //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            lst = dc.Spu_MontlyStock(pid, did.DrugID, temp).ToList();
            spuMontlyStockResultBindingSource.DataSource = lst;


            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            var org = MainModule.MyDepartment.ID;
            if (org == null)
            {
                aPPharmcyDrugBindingSource.DataSource = null;
                return;
            }
            aPPharmcyDrugBindingSource.DataSource = dc.AP_PharmcyDrugs.Where(c=> c.PharmacyID == org).OrderBy(c=> c.NameandShape).ToList();
            // pharmacyDrugBindingSource.DataSource = org.PharmacyDrugs.OrderBy(x => x.Service.Name).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم گزارش ماهیانه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
              //  return;
            }
            GetData();
        }
        

        private void gridView1_Click(object sender, EventArgs e)
        {
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            if (did == null)
                return;
            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;
         
            var temp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date").ToString();
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //lst1 = 
            spuDepDrugDeliveryResultBindingSource.DataSource = dc.Spu_DepDrugDelivery(did.DrugID, pid, temp).ToList();
            spuDepDrugRequestResultBindingSource.DataSource = dc.Spu_DepDrugRequest(did.DrugID, pid, temp).ToList();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
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
            MainModule.GetClientConfig(stiReport1);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void lkpDrug_EditValueChanged(object sender, EventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم گزارش ماهیانه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
               // return;
            }
            GetData();
            var did = lkpDrug.EditValue as AP_PharmcyDrug;
            MESC.Text = dc.Services.FirstOrDefault(c => c.ID == did.DrugID).MESCCode_No;
            var Pr = dc.SpuDrugTariff(MainModule.MyDepartment.ID, MainModule.GetPersianDate(DateTime.Now)).FirstOrDefault(c => c.ID == did.DrugID).price.ToString();
            textEdit2.Text = Pr;
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم گزارش ماهیانه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            GetData();
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم گزارش ماهیانه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
              //  return;
            }
            GetData();
        }
    }
}