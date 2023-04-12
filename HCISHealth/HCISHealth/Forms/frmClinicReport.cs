using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
namespace HCISHealth.Forms
{
    public partial class frmClinicReport : DevExpress.XtraEditors.XtraForm
    {

        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<spuAPHealthResult> lst = new List<spuAPHealthResult>();
        List<GivenServiceD> del = new List<GivenServiceD>();
        public GivenServiceM ObjectRM { get; set; }
        public frmClinicReport()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmClinicReport_Load(object sender, EventArgs e)
        {
            textEdit1.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
           
            GetData();

        }
        private void GetData()
        {
          
            var temp1 = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp1))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp2))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            var id = Classes.MainModule.MyDepartment.ID;
            if (id == null)
                return;
            lst = dc.spuAPHealth(/*Classes.MainModule.MyDepartment.ID,*/ temp1,temp2).OrderBy(c=>c.ServiceName).ToList();
            spuAPHealthResultBindingSource.DataSource = lst;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}