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
    public partial class frmDrugP : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_DrugPatientResult> lst = new List<Spu_DrugPatientResult>();
        public frmDrugP()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugP_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }
        private void GetData()
        {

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var pid = skpDrug.EditValue as Guid?;
            if (pid == null)
                return;
            lst = dc.Spu_DrugPatient(temp, temp2, pid)/*.Where(x => x.Expr2 == MainModule.MyDepartment.Name)*/.OrderByDescending(c => c.Date).ToList();
            spuDrugPatientResultBindingSource.DataSource = lst;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = lst.GroupBy(x => new { x.Doc, x.Name, x.Shape , x.PersonalCode }).Select(u => new
            {
                SumAmount = u.Sum(x => x.Expr1),
                SumTotal = u.Sum(x => x.Total),
                u.Key.Doc,
                u.Key.PersonalCode,
                u.Key.Name,
                u.Key.Shape
            }).ToList();
            //stiReport1.Dictionary.Variables.Add("f", textEdit1.Text);
            //stiReport1.Dictionary.Variables.Add("t", textEdit1.Text);
            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
    }
}