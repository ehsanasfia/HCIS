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
using System.IO;
using HCISSecretary.Data;
using HCISSecretary.Classes;

namespace HCISSecretary.Dialogs
{
    public partial class dlgAdmision32 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Person EditingPerson { get; set; }
        public string Code;
        static bool flag = false;
        public bool Call = false;
        public dlgAdmision32()
        {
            InitializeComponent();
        }

        private void frmAdmision_Load(object sender, EventArgs e)
        {
            checkEdit1_CheckedChanged(null, null);
            layoutControlGroup2.Expanded = false;
            txtBirthDay.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }
        void GetData()
        {
           
                EditingPerson = new Person();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            //gridView1.BestFitColumns();
            personBindingSource1.DataSource = EditingPerson;
            if (Code.Length == 10)
                txtNationalCode.Text = Code;
            else
                txtPersonalCode.Text = Code;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(lkpInsuranceType.EditValue == null)
            {
                MessageBox.Show("لطفا بیمه بیمار را وارد کنید");
                return;
            }

            if (pictureEdit1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                    objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                    EditingPerson.Photo = binary;
                }
            }
            else
                EditingPerson.Photo = null;

            try
            {
                EditingPerson.BirthDate = txtBirthDay.Text;
                if (!flag)// زمانی ک بیمار جدید باشد
                {
                    if (txtName.Text == "" && txtLastName.Text == "")
                    {
                        MessageBox.Show("لطفا نام و نام خانوادگیِ بیمار را وارد کنید");
                        return;
                    }
                    if (dc.Persons.Any(x => x.NationalCode == txtNationalCode.Text))
                    {
                        MessageBox.Show(".بیمار با این کد ملی وارد شده است");
                        return;
                    }
                    dc.Persons.InsertOnSubmit(EditingPerson);

                }
                if (checkEdit1.Checked == null || checkEdit1.Checked == false)
                    EditingPerson.Forieng = false;
                dc.SubmitChanges();
                // این ها زمانی اجرا میشوند که این فرم از فرمهای دیگر فراخوانی شده باشد
                if (Call)
                {
                    //   EditingPerson = personBindingSource.Current as Person;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

        }
        void EndEdit()
        {
            personBindingSource.EndEdit();
        }
        void FormEmpty()
        {
            txtNationalCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtPhone.Text = string.Empty;
            rdbSex.EditValue = string.Empty;
            txtBirthDay.Text = string.Empty;
            pictureEdit1.EditValue = string.Empty;
            txtInsuranceNumber.Text = string.Empty;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //  var Paitionts = dc.Persons.Where(c => c.NationalCode == txtNationalCode.Text).ToList();
            //  if (Paitionts.Count != 1)
            //  {
            //      MessageBox.Show(this,"بیمار با کدملی مورد نظر یافت نشد","توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //      return;
            //  }
            //  EditingPerson = Paitionts.FirstOrDefault();

            // Search(EditingPerson);


            ////  pictureEdit1.EditValue = Paitiont.Photo;


        }
        void Search(Person person)
        {
            try
            {
                txtBirthDay.Text = string.IsNullOrEmpty(EditingPerson.BirthDate) ? "" : EditingPerson.BirthDate;
                personBindingSource1.DataSource = EditingPerson;
                flag = true;

                //txtName.Text = string.IsNullOrEmpty(person.FirstName)?"": person.FirstName;
                //txtLastName.Text = string.IsNullOrEmpty(person.LastName)?"": person.LastName;
                //txtFatherName.Text = string.IsNullOrEmpty (person.FatherName)?"": person.FatherName;
                //txtNumber.Text = string.IsNullOrEmpty( person.IdentityNumber)?"": person.IdentityNumber;
                //txtPhone.Text = string.IsNullOrEmpty (person.Phone)?"": person.Phone;
                //rdbSex.EditValue =  person.Sex;
                //dtpBirthday.Date = string.IsNullOrEmpty (person.BirthDate)?"": person.BirthDate;
                //txtInsuranceNumber.Text = string.IsNullOrEmpty(person.InsuranceNo)?"": person.InsuranceNo;
                //lkpInsuranceType.EditValue = string.IsNullOrEmpty(person.InsuranceName)?"": person.InsuranceName;
                //txtHappy.EditValue = string.IsNullOrEmpty(person.MaritalStatus)?"": person.MaritalStatus;

            }
            catch (Exception)
            {


            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnExtendedSearch_Click(object sender, EventArgs e)
        {
            var dlg = new dlgAdvancedSearch() { dc = this.dc };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureEdit1.LoadImage();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit1.Checked == false || checkEdit1.Checked == null)
            {
                layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
    }
}