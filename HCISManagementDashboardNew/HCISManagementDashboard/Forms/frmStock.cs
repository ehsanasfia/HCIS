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

namespace HCISManagementDashboard.Forms
{
    public partial class frmStock : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_LastAmountOfDrugResult> lst = new List<Spu_LastAmountOfDrugResult>();
        List<SpuMT74Result> lstM = new List<SpuMT74Result>();
        public frmStock()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            GetData();
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
           // var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {
         
           // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var pid = lkpPharmcy.EditValue as Guid ?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //var yearmonth = temp.Substring(0, 7);
            lst = dc.Spu_LastAmountOfDrug(pid, temp).ToList();
            spuLastAmountOfDrugResultBindingSource.DataSource = lst;
              
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Guid.Parse(lkpPharmcy.EditValue.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم موجودی انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        lkpPharmcy.Text,
                        u.Amount,
                        u.Name,
                        u.Shape,
                        u.Money,
                        
                       
                    };
            MainModule.GetClientConfig(stiReport1);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
    }
   
}