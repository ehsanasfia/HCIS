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
using HCISDentist.Classes;
using HCISDentist.Data;

namespace HCISDentist.Forms
{
    public partial class frmPatientList : DevExpress.XtraEditors.XtraForm
    {
        private List<GivenServiceD> DataList;
        HCISDentisClassesDataContext dc = new HCISDentisClassesDataContext();
        public GivenServiceD current;
        public frmPatientList()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (current.Confirm == true)
            {
                if (MessageBox.Show("ویزیت این بیمار انجام شده است \n \n آیا مایلید به صفحه ی معاینه وارد شوید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }
            var a = new Forms.frmDentits();
            var main = this.MdiParent as frmMain;
            a.MdiParent = main;
            a.checkup = current;
            a.dc = dc;
            a.Show();
            a.BringToFront();
            a.WindowState = FormWindowState.Maximized;
            main.ribbonControl1.SelectedPage = main.ribbonControl1.MergedPages[0];
            GetData();
        }


        private void frmPatientList_Load(object sender, EventArgs e)
        {
         GetData();
        }

        private void GetData()
        {
            try
            {
                var toDay = datePicker1.Date;
                DataList = dc.GivenServiceDs.Where(x => x.GivenServiceM.Agenda.Date == toDay && x.GivenServiceM.Admitted == true && x.GivenServiceM.SendToDr == true && x.GivenServiceM.Agenda.Department.Parent == MainModule.InstallLocation.ID && x.GivenServiceM.ServiceCategoryID == (int)Category.دندانپزشکی).ToList();
                givenServiceDBindingSource.DataSource = DataList;
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID);
                lookUpEdit1.EditValue = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID).FirstOrDefault();
                MainModule.MyDepartment = lookUpEdit1.EditValue as Department;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                gridView1_DoubleClick(null, null);
            }
        }
    }
}