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
using HCISAdmission.Forms;

namespace HCISAdmission
{
    public partial class frmIndoor : DevExpress.XtraEditors.XtraForm
    {
        public frmIndoor()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM { get; set;   }
        public GivenServiceD EditinGivenD { get; set; }
        bool flag = false;
        void Save()
        {
            EndEdit();
            dc.SubmitChanges();
            gridControl1.RefreshDataSource();
            GetData();
        }
        void Search(Person person)
        {
            try
            {
                layoutlblPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                txtNationalCode.Text = person.NationalCode;
                lblPerson.Text = string.Format("{0} {1} {2} {3} {4} {5} {6} ", person.FirstName, " ", person.LastName, " ,فرزند ", person.FatherName, " ,تاریخ تولد ", person.BirthDate);
                personBindingSource.DataSource = person;
                lkpInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == person.InsuranceName);
                txtInsuranceNo.Text = person.InsuranceNo;
                flag = true;
               
            }
            catch (Exception)
            {


            }
        }
        void GetData()
        {
            

            staffBindingSource.DataSource = dc.Staffs.Where(c=>c.UserType == "دکتر");
            insuranceBindingSource.DataSource = dc.Insurances;
            departmentBindingSource.DataSource = dc.Departments.ToList();
            EditingGivenM = new GivenServiceM();
            givenServiceMBindingSource.DataSource = EditingGivenM;
            //var GSM = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == 4).ToList();
            //personBindingSource1.DataSource = dc.Persons.Where(c => c.GivenServiceMs.);

            //gridView1.BestFitColumns();
            // personBindingSource1.DataSource = EditingPerson;
        }
        void EndEdit()
        {
            personBindingSource.EndEdit();
        }
        private void brbExtendedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdvancedSearch();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var Paitionts = dc.Persons.Where(c => c.NationalCode == txtNationalCode.Text).ToList();
            if (Paitionts.Count != 1)
            {

                if (MessageBox.Show(this, "بیماری باکدملی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;


                brbNewPaitiont_ItemClick(null, null);




            }
            EditingPerson = Paitionts.FirstOrDefault();

            Search(EditingPerson);


        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            List<Person> lstPerson = new List<Person>();
            var department = departmentBindingSource.Current as Department;
            //-----فعلا در همین حد کافیه زمانیکه برنامه بخش شروع شد اینجا رو تکمیل میکنیم 
            var givenServiceM = dc.GivenServiceMs.Where(c=>/*c.DepartmentID==department.ID &&*/ c.ServiceCategoryID==MainModule.InDoorCategoryID
            
            
            ).ToList();
            foreach (var item in givenServiceM)
            {
                var person=item.Person;
                lstPerson.Add(person);
            }
            personBindingSource1.DataSource = lstPerson;
        }

        private void frmIndoor_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void brbClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

       

      

        private void brbHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgHistory1() { dc = dc, EditingPerson = EditingPerson,HistoryType=true };
            dlg.ShowDialog();
        }

        private void brbNewPaitiont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new frmAdmission() { Call=true} ;
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }

        private void brbOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EditingGivenM.Date = MainModule.GetPersianDate(DateTime.Now);
                EditingGivenM.Time = DateTime.Now.ToString("HH:MM");
                EditingGivenM.ServiceCategoryID = MainModule.InDoorCategoryID;
                EditingGivenM.PersonID = EditingPerson.ID;
                EditingGivenM.RequestStaffID = (lkpDoctor.EditValue as Staff).ID;
                EditingGivenM.InsuranceID = (lkpInsurance.EditValue as Insurance).ID;
                dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);
                dc.SubmitChanges();
                // ثبت GivenServiceD 
                EditinGivenD = new GivenServiceD()
                {
                    GivenServiceMID = EditingGivenM.ID,
                };
                Save();

                ////
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);


            }
        }
    }
}