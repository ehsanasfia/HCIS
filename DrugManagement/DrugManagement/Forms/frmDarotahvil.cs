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
    public partial class frmDarotahvil : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_DrugDeliveryResult> lst = new List<Spu_DrugDeliveryResult>();
       // List<SpuMT74Result> lstM = new List<SpuMT74Result>();
        public frmDarotahvil()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDarotahvil_Load(object sender, EventArgs e)
        {
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
            lst = dc.Spu_DrugDelivery(temp, temp2, temp3).ToList();
            spuDrugDeliveryResultBindingSource.DataSource = lst;
            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
       //     lstM = dc.SpuMT74(MainModule.MyDepartment.ID, temp, temp2).ToList();
            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
            {
                return;
            }
            var cu = spuDrugDeliveryResultBindingSource.Current as Spu_DrugDeliveryResult;
            if (cu == null)
            {
                return;
            }
             


               
            requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.RequestM.ToUnit == pid && c.Service.ID == cu.ID && c.AmountDeliveryDate.CompareTo(textEdit1.Text) >= 0 && c.AmountDeliveryDate.CompareTo(textEdit2.Text) <= 0).OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst
                    select new { Service = u.Name == null ? "" : u.Name, amount = u.Expr1, price = u.Expr2 ,u.MESCCode_No, u.Shape, u.NIS
                   , UserFullname = MainModule.UserFullName, dateprint = MainModule.GetPersianDate(DateTime.Now), timeprint = DateTime.Now.ToString("HH:mm")};
            //var doc = dc.Staffs.FirstOrDefault(c => c.ID == (Guid)lookUpEdit1.EditValue);
            ////var doc1 = dc.Specialities.FirstOrDefault(c => c.ID == (Guid)searchLookUpEdit1.EditValue);

            ////stiReport1.Dictionary.Variables.Add("t", doc1.);
            //stiReport1.Dictionary.Variables.Add("name", doc.Person.LastName);
            //var doc = dc.Staffs.FirstOrDefault(c => c.ID == (Guid)lookUpEdit1.EditValue);
            ////var doc1 = dc.Specialities.FirstOrDefault(c => c.ID == (Guid)searchLookUpEdit1.EditValue);

            ////stiReport1.Dictionary.Variables.Add("t", doc1.);
            stiReport1.Dictionary.Variables.Add("date1", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("date2", textEdit2.Text);
            stiReport1.Dictionary.Variables.Add("username", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("time", DateTime.Now.ToString("HH:mm"));
            stiReport1.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
      //    stiReport1.Design();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
    }
}