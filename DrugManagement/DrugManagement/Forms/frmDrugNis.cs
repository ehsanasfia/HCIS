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
    public partial class frmDrugNis : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Vw_drgNISDrug> lst = new List<Vw_drgNISDrug>();
        List<Spu_NISDrugUpperGridResult> lstUper = new List<Spu_NISDrugUpperGridResult>();
        public frmDrugNis()
        {
            InitializeComponent();
        }

        private void frmDrugNis_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
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

           lstUper= dc.Spu_NISDrugUpperGrid(temp, temp2, MainModule.MyDepartment.ID).ToList();
            spuNISDrugUpperGridResultBindingSource.DataSource = lstUper;
             

            //lst = dc.Vw_drgNISDrugs.Where(c =>c.DepartmentID == MainModule.MyDepartment.ID && c.Date.CompareTo(temp) >= 0 && c.Date.CompareTo(temp2) <= 0).ToList();
            //vwdrgNISDrugBindingSource.DataSource = lst;
           

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lstUper
                    select new
                    {
                        
                        u.Name,
                        u.GivenAmount,
                     
                    };
            stiReport1.Dictionary.Variables.Add("d", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("f", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("t", textEdit2.Text);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
           // stiReport1.Design();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var n = vwdrgNISDrugBindingSource.Current as Vw_drgNISDrug;
            if (n== null)
                return;

            bindingSource1.DataSource = dc.Vw_drgNISDrugs.Where(c => c.DrugID == n.DrugID).ToList();
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            var n = spuNISDrugUpperGridResultBindingSource.Current as Spu_NISDrugUpperGridResult;
            if (n == null)
                return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            spuNISDrugLowerGridResultBindingSource.DataSource = dc.Spu_NISDrugLowerGrid(temp,temp2, MainModule.MyDepartment.ID,n.DrugID);
        }
    }
    
}