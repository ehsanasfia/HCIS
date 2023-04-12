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
namespace DrugManagement.Dialogs
{
    public partial class dlgOrderSSee : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
 
        public DrugOrder_Main  DM { get; set; }
      
        List<spuDrugOrder_MainResult> lst = new List<spuDrugOrder_MainResult>();
        List<SpuMT74Result> lstM = new List<SpuMT74Result>();
        public dlgOrderSSee()
        {
            InitializeComponent();
        }

        private void dlgOrderSSee_Load(object sender, EventArgs e)
        {
            label1.Text = DM.Name;
            GetData();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            // requestDsBindingSource.DataSource = dc.RequestDs.Where(c => c.ID == DM.ID).ToList();
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
            lst = dc.spuDrugOrder_Main(temp, temp2).Where(c => c.Amount > 0 && c.Name == DM.Name).ToList();
            spuDrugOrderMainResultBindingSource.DataSource = lst;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}