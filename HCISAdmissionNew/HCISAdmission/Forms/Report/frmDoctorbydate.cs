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
    public partial class frmDoctorbydate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public frmDoctorbydate()
        {
            InitializeComponent();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void frmDoctorbydate_Load(object sender, EventArgs e)
        {
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").OrderBy(x => x.Staff.Code).ToList();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            //btnSearch_Click(null, null);
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
                         select new { pFullName = c.Person.FirstName + " " + c.Person.LastName, c.Insurance.Name, c.PayedPrice, c.Comment, c.AdmitDate };

            stiReport1.RegData("mydata", mydata);
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            var stf = slkDoctor.EditValue as Staff;
            if (stf == null)
            {
                MessageBox.Show("لطفا پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            stiReport1.Dictionary.Variables.Add("Doctor", stf.Person.LastName);

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && x.AdmitDate.CompareTo(txtToDate.Text) <= 0 && x.Staff != null && x.Staff.Person != null && x.Staff.Person.ID == (slkDoctor.EditValue as Staff).ID).OrderByDescending(x => x.Date).ToList();
            givenServiceMBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

    }
}