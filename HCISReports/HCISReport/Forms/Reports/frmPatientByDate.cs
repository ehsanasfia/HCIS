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
using HCISReport.Classes;
using HCISReport.Data;

namespace HCISReport.Forms.Reports
{
    public partial class frmPatientByDate : DevExpress.XtraEditors.XtraForm
    {
        public frmPatientByDate()
        {
            InitializeComponent();
        }
        public HCISDataContext dc = new HCISDataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();

        private void frmPatientByDate_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && x.AdmitDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(x => x.Date).ToList();
            givenServiceMBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!lst.Any())
            {
                MessageBox.Show("لیستی برای چاپ موجود نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var mydata = from c in lst
                         select new { sFullName = c.Staff.Person.FirstName + " " + c.Staff.Person.LastName, pFullName = c.Person.FirstName + " " + c.Person.LastName, c.AdmitDate, c.Comment, c.PayedPrice, c.Insurance.Name };

            stiReport1.RegData("mydata", mydata);
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtToDate.Text);

          stiReport1.Compile();
          stiReport1.CompiledReport.ShowWithRibbonGUI();
          //stiReport1.Design();
        }
    }
}