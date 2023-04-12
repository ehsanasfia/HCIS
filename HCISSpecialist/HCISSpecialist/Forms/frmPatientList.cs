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
using HCISSpecialist.Data;
using DevExpress.XtraGrid.Columns;

namespace HCISSpecialist.Forms
{
    public partial class frmPatientList : DevExpress.XtraEditors.XtraForm
    {
        HCISSpecialistClassesDataContext dc = new HCISSpecialistClassesDataContext();
        SeqdbmlDataContext seq = new SeqdbmlDataContext();
        public GivenServiceM current;
        public DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private List<GivenServiceM> DataList;
        public bool running = false;
        public bool fromLoad = false;

        public frmPatientList()
        {
            InitializeComponent();
            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }
        public int BirthDay(String birthDate)
        {
            var now = MainModule.GetPersianFirstDateOfYear(DateTime.Now);
            var age = int.Parse(now.Substring(0, 4)) - int.Parse(birthDate.Substring(0, 4));
            return age;
        }

        private void GetData()
        {
            try
            {
                if (running)
                    return;
                running = true;
                btnDayPatient.Enabled = false;
                var toDay = textEdit1.Text;
                if (Program.fromHCIS)
                {
                    var userID = seq.tblUsers.Where(x => x.UserName == MainModule.UserName &&
                    x.ApplicationID == 3087).FirstOrDefault().UserID;
                    DataList = dc.GivenServiceMs.Where(x => x.Agenda.Date == toDay &&
                    x.Admitted == true &&
                    x.Payed == true &&
                    x.Agenda.ShiftID == Int32.Parse(radioGroup1.EditValue.ToString()) &&
                    x.SendToDr == true &&
                    x.ServiceCategoryID == (int)Category.ویزیت &&
                    x.Agenda.Staff.UserID == userID &&
                    x.Cancelled != true &&
                    x.Agenda.Department != null &&
                    x.Agenda.Department.Parent == MainModule.InstallLocation.ID).ToList();
                    givenServiceMBindingSource.DataSource = DataList;
                }
                else
                {
                    DataList = dc.GivenServiceMs.Where(x => x.Agenda.Date == toDay &&
                    x.Admitted == true &&
                    x.Payed == true &&
                    x.SendToDr == true &&
                    x.Agenda.ShiftID == Int32.Parse(radioGroup1.EditValue.ToString()) &&
                    x.ServiceCategoryID == (int)Category.ویزیت &&
                    x.Agenda.Staff.UserID == HCISSpecialist.MainModule.UserID &&
                    x.Cancelled != true &&
                    x.Agenda.Department != null &&
                    x.Agenda.Department.Parent == MainModule.InstallLocation.ID).ToList();
                    givenServiceMBindingSource.DataSource = DataList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            running = false;
            btnDayPatient.Enabled = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                current = givenServiceMBindingSource.Current as GivenServiceM;
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

                var a = new Forms.frmCheckup();
                var main = this.MdiParent as frmMain;
                if (current.Agenda.Department.Name == "بینائی سنجی")
                    a.optoVisit = true;
                if (current.Agenda.Department.Name == "شنوایی سنجی")
                    a.audio = true;
                a.checkup = current;
                if(checkButton1.Checked == true)
                {
                    a.RightToLeft = RightToLeft.No;
                    a.RightToLeftLayout = false;
                }
                else
                {
                    a.RightToLeft = RightToLeft.Yes;
                    a.RightToLeftLayout = true;
                }
                a.dc = dc;
                timer1.Enabled = false;
                a.FrmPL = this;
                a.ShowDialog();
                a.BringToFront();
                timer1.Enabled = true;
            }

            finally
            {
                try
                {
                    splashScreenManager2.CloseWaitForm();
                }
                catch (Exception)
                {

                }

            }
            GetData();
        }

        private void frmPatientList_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            GetData();
            if (Properties.Settings.Default.DefultPharmcy == null || Properties.Settings.Default.DefultPharmcy == "")
            {
                fromLoad = true;
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID && x.Name != "داروخانه بخش های بستری" && x.Name != "انبار دارویی" && x.Name != "واحد ترکیبی داروخانه بخش های بستری");
                lookUpEdit1.ItemIndex = 0;
                if (lookUpEdit1.Text == "انبار" && departmentBindingSource.Count > 1)
                    lookUpEdit1.ItemIndex = 2;
                var dep = dc.Departments.Where(x => x.ID == Guid.Parse(lookUpEdit1.EditValue.ToString())).FirstOrDefault();
                MainModule.MyDepartment = dep;
                fromLoad = false;
            }

            else if (MainModule.InstallLocation.Name == "بیمارستان")
            {
                fromLoad = true;
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID && x.Name != "داروخانه بخش های بستری" && x.Name != "انبار دارویی" && x.Name != "واحد ترکیبی داروخانه بخش های بستری");
                var id = Guid.Parse(Properties.Settings.Default.DefultPharmcy);
                var dep = dc.Departments.Where(x => x.ID == id).FirstOrDefault();
                lookUpEdit1.EditValue = dc.Departments.Where(x => x.ID == id).FirstOrDefault().ID;
                MainModule.MyDepartment = dep;
                fromLoad = false;
            }
        }

        private void btnDayPatient_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!fromLoad)
            {
                var dep = dc.Departments.Where(x => x.ID == Guid.Parse(lookUpEdit1.EditValue.ToString())).FirstOrDefault();
                MainModule.MyDepartment = dep;
                Properties.Settings.Default.DefultPharmcy = lookUpEdit1.EditValue.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}