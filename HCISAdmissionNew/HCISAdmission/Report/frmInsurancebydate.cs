using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISAdmission;

namespace HCISAdmission.Report
{
    public partial class frmInsurancebydate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public frmInsurancebydate()
        {
            InitializeComponent();
        }

        private void frmInsurancebydate_Load(object sender, EventArgs e)
        {
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && x.AdmitDate.CompareTo(txtToDate.Text) <= 0 && x.Insurance != null && x.Insurance.Name == slkInsurance.Text).OrderByDescending(x => x.Date).ToList();
            givenServiceMBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!lst.Any())
            {
                MessageBox.Show("لیستی برای چاپ موجود نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var mydata = from c in lst
                         select new { sFullName = c.Staff.Person.FirstName + " " + c.Staff.Person.LastName, pFullName = c.Person.FirstName + " " + c.Person.LastName, c.AdmitDate, c.Comment, c.PayedPrice };

            stiReport1.RegData("mydata", mydata);
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            var ins = slkInsurance.EditValue as Insurance;
            if (ins == null)
            {
                MessageBox.Show("لطفا بیمه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            stiReport1.Dictionary.Variables.Add("Insurance", ins.Name);

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
    }
}