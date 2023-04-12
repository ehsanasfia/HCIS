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
    public partial class frmDaroBakhshDarkhast : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_DrugRequestWard1Result> lst = new List<Spu_DrugRequestWard1Result>();
        public frmDaroBakhshDarkhast()
        {
            InitializeComponent();
        }

        private void frmDaroBakhshDarkhast_Load(object sender, EventArgs e)
        {
            GetData();
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16).OrderBy(c => c.Name).ToList();
           // var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
          //  lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {


            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
     


            lst = dc.Spu_DrugRequestWard1(temp, temp2, pid).Where(c=> c.WardOutputConsumeDrug >= 1 || c.Expr1 >= 1).ToList();
            spuDrugRequestWard1ResultBindingSource.DataSource = lst;


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

       
    }
}