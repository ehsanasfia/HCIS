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

namespace HCISAdmission
{
    public partial class frmChangePersonInfo : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson { get; set; }
        static bool flag = false;
        public bool Call = false;
        public frmChangePersonInfo()
        {
            InitializeComponent();
        }

        private void frmAdmision_Load(object sender, EventArgs e)
        {
            txtBirthDay.Text = MainModule.GetPersianDate(DateTime.Now);
            //    GetData();
        }
        void GetData()
        {
            EditingPerson = new Person();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            personBindingSource1.DataSource = EditingPerson;
            var Date = MainModule.GetPersianDate(DateTime.Now);
            personBindingSource.DataSource = dc.Persons.Where(c => c.LastModificationDate == Date).ToList();
        }

        private bool checkperson()
        {
            if (EditingPerson.FirstName == null)
            {
                MessageBox.Show(this, "نام را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.LastName == null)
            {
                MessageBox.Show(this, "نام خانوادگی را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.NationalCode == null)
            {
                MessageBox.Show(this, "نام را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.InsuranceName == null)
            {
                MessageBox.Show(this, " بیمه را انتخاب کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.InsuranceName.Trim() != "آزاد" && EditingPerson.InsuranceNo == null)
            {
                MessageBox.Show(this, "شماره بیمه را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            return true;
        }


        void EndEdit()
        {
            personBindingSource.EndEdit();
        }
        void FormEmpty()
        {
            txtNationalCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtPhone.Text = string.Empty;
            rdbSex.EditValue = string.Empty;
            txtBirthDay.Text = string.Empty;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    MessageBox.Show("لطفا شماره پرونده بیمار را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                // agar codemeli valerd shode bashad
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == long.Parse(txtNationalCode.Text));
                if (dossier == null)
                {
                    MessageBox.Show("بيماری یافت نشد");return;
                }
                if(dossier.IOtype==0)
                { MessageBox.Show("این پرونده مربوط به بیمار بستری نمی باشد");return; }
                    EditingPerson = dossier.Person;
                    Search(EditingPerson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
}



private void BuildNewPerson()
{
    EditingPerson = null;
    GetData();
    EditingPerson.NationalCode = txtNationalCode.Text;
}
void Search(Person person)
{
    try
    {
        txtBirthDay.Text = string.IsNullOrEmpty(EditingPerson.BirthDate) ? "" : EditingPerson.BirthDate;
        personBindingSource1.DataSource = EditingPerson;
        var prs = dc.View_IMPHO_Persons.FirstOrDefault(c => c.NationalCode.CompareTo(person.NationalCode) == 0);


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
    catch (Exception ex)
    {
        MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        return;
    }
}

private void simpleButton1_Click(object sender, EventArgs e)
{

}
        Dossier dossier;
private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
  //var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == long.Parse(txtNationalCode.Text));
            if (dossier == null) return;
            var cur = person1BindingSource.Current as Person1;
    if (cur == null)
    { MessageBox.Show("لطفا رکورد جای گزین را انتخاب نمایید"); return; }

            //if (EditingPerson.NationalCode == cur.NationalCode.Replace("-", ""))
            //{
            //    EditingPerson.MedicalID = cur.MedicalID;
            //    EditingPerson.FirstName = cur.Firstname;
            //    EditingPerson.LastName = cur.Lastname;
            //    EditingPerson.BirthDate = cur.BirthDate;
            //    EditingPerson.FatherName = cur.FatherName;
            //    EditingPerson.InsuranceNo = cur.MedicalID;
            //    EditingPerson.Phone = cur.HomePhone;
            //    EditingPerson.Sex = cur.Sex == 0 ? true : false;
            //    EditingPerson.Comment = cur.Note;
            //    EditingPerson.NationalCode = cur.NationalCode.Replace("-", "");
            //    dc.SubmitChanges();
            //}
            //else
            //{
                var newPerson = new Person();
                var prs = dc.Persons.FirstOrDefault(c => c.MedicalID == cur.MedicalID);
                if (prs == null)
                {
                    var ViewImpho = dc.View_IMPHO_Persons.FirstOrDefault(c => c.InsuranceNo == cur.MedicalID);
                    if (ViewImpho == null)
                    { MessageBox.Show("اطلاعات پرسنلی بیمار یافت نشد"); return; }
                    newPerson.MedicalID = ViewImpho.InsuranceNo;
                    newPerson.FirstName = ViewImpho.Firstname;
                    newPerson.LastName = ViewImpho.Lastname;
                    newPerson.BirthDate = ViewImpho.BirthDate;
                    newPerson.FatherName = ViewImpho.FatherName;
                    newPerson.InsuranceNo = ViewImpho.InsuranceNo;
                    newPerson.Phone = ViewImpho.HomePhone;
                    newPerson.Sex = ViewImpho.Sex == 0 ? true : false;
                    newPerson.Comment = ViewImpho.Note;
                    newPerson.NationalCode = ViewImpho.NationalCode.Replace("-", "");
                    newPerson.InsuranceName = ViewImpho.InsureName;
                    dc.Persons.InsertOnSubmit(newPerson);
                    dc.SubmitChanges();
                }
                else
                {
                    newPerson = prs;
                    dossier.Person = newPerson;
                    dossier.SpicialCode = "";
                dossier.AllInsuranceShare = 0;
                dossier.AllPateintShare = 0;
                dossier.AllPay = 0;
                    dossier.NationalCode = newPerson.NationalCode;
                    foreach (var item in dossier.GivenServiceMs)

                    item.PersonID = newPerson.ID;
                    dc.SubmitChanges();
                    var insure = dc.Insurances.FirstOrDefault(c => c.Name == newPerson.InsuranceName);
                    if (insure == null)
                    { MessageBox.Show("بیمه ی بیمار مشخص نیست"); return; }
                    ChangeInsurance(insure.ID, dossier);
                }
            //}
    try
    {
        dc.SubmitChanges();
        MessageBox.Show(this, "تغییرات با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
    }
    catch (Exception ex)
    {
        MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
    }
}
         private void ChangeInsurance(int v,Dossier dossier)
        {
            try
            {
                var MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                MainGSM.InsuranceID = v;
                dossier.XInsuranceID = v;
                var allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                allGSM.ForEach(x =>
                {
                    x.InsuranceID = v;
                });
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
    flag = false;
    gridControl1.RefreshDataSource();
    FormEmpty();
    GetData();
}

private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
    Close();
}

private void btnAdvanceSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
    var dlg = new dlgAdvancedSearch() { dc = this.dc };
    if (dlg.ShowDialog() != DialogResult.OK)
    {
        return;
    }
    EditingPerson = dlg.EditingPerson;
    Search(EditingPerson);
}

private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
{
    if (e.KeyChar == (char)Keys.Enter)
    {
        btnSearch.PerformClick();
    }
}

private void btnSearchInIMPho_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrWhiteSpace(txtPErsonalCode.Text))
        {
            MessageBox.Show("لطفا کد شناسایی بیمار را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            return;
        }

                // agar codemeli valerd shode bashad
                var x = txtPErsonalCode.Text;
                for (int i= x.Length; x.Length<7;i++)
                    x = "0" + x;
                var PateintPersonalCode = IM.Person1s.Where(c => c.MedicalID.Contains(x)).ToList();
            if (PateintPersonalCode.Count() == 0)
            {
                MessageBox.Show("بيماری یافت نشد");
            }
            else
            {
                person1BindingSource.DataSource = PateintPersonalCode;
            }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        return;
    }
}
    }
}
