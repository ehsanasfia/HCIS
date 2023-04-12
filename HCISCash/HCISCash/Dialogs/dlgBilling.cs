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
using HCISCash.Data;
using HCISCash.Dialogs;

namespace HCISCash.Dialogs
{

    public partial class dlgBilling : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc { get; set; }
        List<Dossier> lst = new List<Dossier>();

        public dlgBilling()
        {
            InitializeComponent();
        }

        private void dlgAdvancedSearch_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string national = string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();
                string firstname = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text.Trim();
                string lastname = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text.Trim();
                string fathername = string.IsNullOrWhiteSpace(txtFatherName.Text) ? null : txtFatherName.Text.Trim();
                string personalcode = string.IsNullOrWhiteSpace(txtPersonalCode.Text) ? null : txtPersonalCode.Text.Trim();
                string identity = string.IsNullOrWhiteSpace(txtIdentityNumber.Text) ? null : txtIdentityNumber.Text.Trim();

                if(string.IsNullOrWhiteSpace(national)
                    && string.IsNullOrWhiteSpace(firstname)
                    && string.IsNullOrWhiteSpace(lastname)
                    && string.IsNullOrWhiteSpace(fathername)
                    && string.IsNullOrWhiteSpace(personalcode)
                    && string.IsNullOrWhiteSpace(identity))
                {
                    MessageBox.Show("لطفا ابتدا یک مورد را جستجو کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                lst = dc.Dossiers.Where(x =>
                    x.Person != null
                    && national == null ? true : x.Person.NationalCode == national
                  // && firstname == null ? true : (x.Person.FirstName != null && x.Person.FirstName==firstname)
                //  && lastname == null ? true : (x.Person.LastName != null && x.Person.LastName==lastname)
                    //&& fathername == null ? true : (x.Person.FatherName != null && x.Person.FatherName==fathername)
                    && personalcode == null ? true : (x.Person.PersonalCode != null && x.Person.PersonalCode==personalcode)
                    && identity == null ? true : x.Person.IdentityNumber == identity).ToList();

                dossierBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnOk.Enabled = lst.Any();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var Current = dossierBindingSource.Current as Dossier;
                var person = Current.Person;
                var pays = from c in Current.Payments.ToList()
                           select new { c.Price, c.Date, c.Type,c.Time,c.PayBack };
                var givenD = from c in dc.Vw_DosForSepas.Where(x => x.DossierNO == Current.ID && x.IOtype==0)
                             select new { c.DossierNO, DRName = c.DoctorLastName + c.DoctorFirstname, c.CatName, c.Date, c.GivenAmount, c.Name,c.InsuranceShare,c.PatientShare,c.TotalPrice };
                stiBilling.RegData("givenD", givenD);
                stiBilling.RegData("pays", pays);

                stiBilling.Dictionary.Variables.Add("serial", Current.ID);
                stiBilling.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
               // stiBilling.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
              //  stiBilling.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(havepay.ToString()));
                stiBilling.Dictionary.Variables.Add("FirstName", person.FirstName == null ? "" : person.FirstName);
                stiBilling.Dictionary.Variables.Add("LastName", person.LastName == null ? "" : person.LastName);
                stiBilling.Dictionary.Variables.Add("NationalCode", person.NationalCode == null ? "" : person.NationalCode);
                stiBilling.Dictionary.Variables.Add("BirthDate", person.BirthDate==null? "": person.BirthDate);
                stiBilling.Dictionary.Variables.Add("Insurance", Current.GivenServiceMs.FirstOrDefault().Insurance.Name );

                //stiBilling.Design();
                stiBilling.Dictionary.Synchronize();
                stiBilling.Compile();
                stiBilling.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            try
            {
                string date = string.IsNullOrWhiteSpace(txtDate.Text) ? null : txtDate.Text.Trim();
                
                if (string.IsNullOrWhiteSpace(date) )
                {
                    MessageBox.Show("لطفا ابتدا یک مورد را جستجو کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                lst = dc.Dossiers.Where(x =>
                    x.Date == null ? true : x.Date== date
                    && x.Payments.Any() && ( x.IOtype==0 ||  (x.IOtype==1  
                    && x.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().DepartmentID == Guid.Parse("d457926e-73f1-4096-9528-d023366a1835")))).ToList();
                dossierBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnOk.Enabled = lst.Any();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }
    }
}

