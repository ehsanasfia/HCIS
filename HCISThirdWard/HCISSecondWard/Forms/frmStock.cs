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
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
namespace HCISSecondWard.Forms
{
    public partial class frmStock : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
       List<Spu_LastAmountOfDrugForWardsResult> lst = new List<Spu_LastAmountOfDrugForWardsResult>();
      
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
            departmentBindingSource.DataSource = dc.Departments.ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
        
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {
         
      
            var pid = lkpPharmcy.EditValue as Guid ?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
 
            lst = dc.Spu_LastAmountOfDrugForWards(pid, temp).ToList();
            spuLastAmountOfDrugForWardsResultBindingSource.DataSource = lst;
              
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
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
         // stiReport1.Design();
        }
        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
    }
   
}