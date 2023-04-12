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
using HCISManualService.Data;

namespace HCISManualService.Form
{
    public partial class frmAddService : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Person EditingPerson { get; set; }
        public Dossier EditingDossier { get; set; }
        public GivenServiceM EditingGsm { get; set; }

        public frmAddService()
        {
            InitializeComponent();
        }

        private void frmAddService_Load(object sender, EventArgs e)
        {
            GetData();
            txtDate.Text = Class.MainModule.GetPersianDate(DateTime.Now);
            txtTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void GetData()
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 27).ToList();

            if (EditingPerson != null)
            {
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ServiceCategoryID == 27 && x.GivenServiceM.PersonID == EditingPerson.ID).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (EditingDossier != null)
                EditingDossier = null;
            if (EditingGsm != null)
                EditingGsm = null;
            EditingPerson = null;
            txtFName.Text = "";
            txtLname.Text = "";
            var personaalCode = txtPersonnalCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(personaalCode))
                return;

            var lstPer = dc.Persons.Where(x => x.PersonalCode == personaalCode).ToList();

            if (lstPer.Count == 0)
                return;
            else if (lstPer.Count == 1)
            {
                EditingPerson = lstPer.FirstOrDefault();
                txtFName.Text = EditingPerson.FirstName;
                txtLname.Text = EditingPerson.LastName;
                txtPersonnalCode.Text = EditingPerson.PersonalCode;
            }
            else if (lstPer.Count > 1)
            {
                var dlg = new Dialog.dlgSelectPerson();
                dlg.lstperson = lstPer;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    EditingPerson = dlg.SelectedPerson;
                    txtFName.Text = EditingPerson.FirstName;
                    txtLname.Text = EditingPerson.LastName;
                    txtPersonnalCode.Text = EditingPerson.PersonalCode;
                }
            }
            GetData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (EditingPerson == null)
                return;
            var SelectedService = slkService.EditValue as Service;
            if (SelectedService == null)
                return;
            var insure = dc.Insurances.FirstOrDefault(x => x.Name == EditingPerson.InsuranceName);
            if (insure == null)
                insure.ID = 32;
            if (EditingDossier == null)
            {
                var dos = new Dossier()
                {
                    IOtype = 0,
                    PersonID = EditingPerson.ID,
                    XInsuranceID = insure.ID,
                    MedicalCenter = "بیمارستان بزرگ نفت",
                    NationalCode = EditingPerson.NationalCode,
                    CreationDate = txtDate.Text,
                    Date = txtDate.Text,
                    Time = txtTime.Text,
                    CreationTime = txtTime.Text.Trim()
                };
                dc.Dossiers.InsertOnSubmit(dos);
                dc.SubmitChanges();
                EditingDossier = dos;
            }
            if (EditingGsm == null)
            {
                var gsm = new GivenServiceM()
                {
                    DossierID = EditingDossier.ID,
                    PersonID = EditingPerson.ID,
                    InsuranceID = insure.ID,
                    ServiceCategoryID = 27,
                    CreationDate = txtDate.Text,
                    Date = txtDate.Text,
                    Time = txtTime.Text,
                    CreationTime = txtTime.Text,
                    Comment = "ثبت خدمات دستی",
                    RequestDate = txtDate.Text,
                    AdmitDate = txtDate.Text,
                    RequestTime = txtTime.Text,
                    AdmitTime = txtTime.Text,
                    Confirm = true,

                };
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                dc.SubmitChanges();
                EditingGsm = gsm;
            }
            var gsd = new GivenServiceD()
            {
                GivenServiceMID = EditingGsm.ID,
                LastModificationDate = txtDate.Text.Trim(),
                Date = txtDate.Text.Trim(),
                Time = txtTime.Text.Trim(),
                LastModificationTime = txtTime.Text.Trim(),
                ServiceID = SelectedService.ID,
                Amount = (double)spinEdit1.Value,
                GivenAmount = (double)spinEdit1.Value,
                InsuranceShare = calcEdit1.Value,
                PatientShare = 0,
                TotalPrice = calcEdit1.Value,
                Payed = true,
                Confirm = true,
                Comment = "ثبت خدمات دستی"
            };
            dc.GivenServiceDs.InsertOnSubmit(gsd);
            dc.SubmitChanges();
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ServiceCategoryID == 27 && x.GivenServiceM.PersonID == EditingPerson.ID).ToList();
            MessageBox.Show("ثبت شد");
        }

        private void slkService_EditValueChanged(object sender, EventArgs e)
        {
            var SelectedService = slkService.EditValue as Service;
            if (SelectedService == null)
                return;
            if (EditingPerson == null)
                return;
            var insure = dc.Insurances.FirstOrDefault(x => x.Name == EditingPerson.InsuranceName);
            if (insure == null)
                return;
            var price = dc.FindPrice(SelectedService.ID, insure.ID, Class.MainModule.GetPersianDate(DateTime.Now));
            if (price == null)
                price = 0;

            calcEdit1.Value = (decimal)price;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
                return;

            if(MessageBox.Show("آیا از حذف اطمینان دارید؟","توجه",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1 , MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                dc.GivenServiceDs.DeleteOnSubmit(current);
                dc.SubmitChanges();
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ServiceCategoryID == 27 && x.GivenServiceM.PersonID == EditingPerson.ID).ToList();
            }
        }
    }
}