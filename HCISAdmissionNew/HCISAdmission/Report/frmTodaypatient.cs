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
    public partial class frmTodaypatient : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataClasses1DataContext dc = new DataClasses1DataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public frmTodaypatient()
        {
            InitializeComponent();
        }

        private void frmTodaypatientt_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            lst = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == 3 && c.AdmitDate.CompareTo(today) == 0).ToList();
            givenServiceMBindingSource.DataSource = lst;
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
                         select new { sFirstName = c.Staff.Person.FirstName , sLastName = c.Staff.Person.LastName, sFullName = c.Staff.Person.FirstName + " " + c.Staff.Person.LastName, pFirstName = c.Person.FirstName , pLastName = c.Person.LastName, pFullName = c.Person.FirstName + " " + c.Person.LastName, c.PayedPrice , c.Comment , c.Insurance.Name };

            stiReport1.RegData("mydata", mydata);
            stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
    }
}