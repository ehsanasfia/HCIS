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
namespace DrugManagement.Forms
{
    public partial class frmDrugOutOfpharmcy : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
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
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;

        }
        private void GetData()
        {
            dc.CommandTimeout = 10000;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            var temp3 = MainModule.MyDepartment.ID;
            lst = dc.SpuDrugOutOfPharmcy(MainModule.MyDepartment.ID, temp, temp2).ToList();
            spuDrugOutOfPharmcyResultBindingSource.DataSource = lst;
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
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
            //  stiReport2.Design();
            // spuLastAmountOfDrugResultBindingSource.DataSource = lstM;
        }
    }
}