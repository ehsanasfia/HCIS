using System;
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
    public partial class frmDrugOutOfpharmcy : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<SpuDrugOutOfPharmcyResult> lst = new List<SpuDrugOutOfPharmcyResult>();
        List<SpuMT74Result> lstM = new List<SpuMT74Result>();
        public frmDrugOutOfpharmcy()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmDrugOutOfpharmcy_Load(object sender, EventArgs e)
        {

            //departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            //textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            //textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            GetData();
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
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

            var temp3 = MainModule.MyDepartment.ID;

            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst = dc.SpuDrugOutOfPharmcy(MainModule.MyDepartment.ID, temp, temp2).ToList();
            spuDrugOutOfPharmcyResultBindingSource.DataSource = lst;
            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
            lstM = dc.SpuMT74(MainModule.MyDepartment.ID, temp, temp2).ToList();
     

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //var yearmonth = temp.Substring(0, 7);
            lstM = dc.SpuMT74(MainModule.MyDepartment.ID, temp, temp2).ToList();
            var q = from u in lstM

                    select new
                    {
                        lkpPharmcy.Text,
                        u.Amount,
                        u.Name,
                        u.Shape,
                        u.MESCCode_No,


                    };
            stiReport2.RegData("Drugs", q.ToList());
            //stiReport2.Compile();
            //stiReport2.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            stiReport2.Design();
            // spuLastAmountOfDrugResultBindingSource.DataSource = lstM;
        }
    }
}