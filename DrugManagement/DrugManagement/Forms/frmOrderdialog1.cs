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
    public partial class frmOrderdialog1 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<spuDrugOrder_MainResult> lst = new List<spuDrugOrder_MainResult>();
        List<SpuMT74Result> lstM = new List<SpuMT74Result>();
        public frmOrderdialog1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmOrderdialog1_Load(object sender, EventArgs e)
        {
            GetData();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            // var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {

            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //var yearmonth = temp.Substring(0, 7);
            lst = dc.spuDrugOrder_Main(temp, temp2).Where(c=> c.Amount > 0).ToList();
            spuDrugOrderMainResultBindingSource.DataSource = lst;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}