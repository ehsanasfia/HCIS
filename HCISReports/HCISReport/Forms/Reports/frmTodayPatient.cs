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
using DevExpress.XtraBars;
using HCISReport.Data;
using HCISReport.Classes;

namespace HCISReport.Forms.Reports
{
    public partial class frmTodayPatient : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc = new HCISDataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public frmTodayPatient()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!lst.Any())
            {
                MessageBox.Show("لیستی برای چاپ موجود نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var mydata = from c in lst
                         select new { sFirstName = c.Staff.Person.FirstName, sLastName = c.Staff.Person.LastName, sFullName = c.Staff.Person.FirstName + " " + c.Staff.Person.LastName, pFirstName = c.Person.FirstName, pLastName = c.Person.LastName, pFullName = c.Person.FirstName + " " + c.Person.LastName, c.PayedPrice, c.Comment, c.Insurance.Name };

            stiReport1.RegData("mydata", mydata);
            //stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));

           stiReport1.Compile();
           stiReport1.CompiledReport.ShowWithRibbonGUI();
           //stiReport1.Design();
        }

        private void frmTodayPatient_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            lst = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == 3 && c.AdmitDate.CompareTo(today) == 0).ToList();
            givenServiceMBindingSource.DataSource = lst;
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}