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
    public partial class frmDrugSpecial : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_SpecialDrugResult> lst = new List<Spu_SpecialDrugResult>();
        public frmDrugSpecial()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugSpecial_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
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

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.Spu_SpecialDrug(temp,temp2,MainModule.MyDepartment.ID).ToList();
            spuSpecialDrugResultBindingSource.DataSource = lst;

            ////pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            //// serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        u.Cat,
                        u.Shape,
                     //   u.TotalPrice,
                        u.Sum,
                        u.Drug,
                        u.Amount,
                        u.Expr1

                    };
            stiReport1.Dictionary.Variables.Add("d", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("f", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("t", textEdit2.Text);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
          // stiReport1.ShowWithRibbonGUI();
          // stiReport1.Design();
        }
    }
}