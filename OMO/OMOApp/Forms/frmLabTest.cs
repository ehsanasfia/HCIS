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
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmLabTest : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext om = new OMOClassesDataContext();
        Data.HCISData.HCISClassesDataContext dc = new Data.HCISData.HCISClassesDataContext();
        List<Data.HCISData.Service> patientTests = new List<Data.HCISData.Service>();

        //    public Data.HCISData.GivenServiceM MainGsm { get; set; }

        public frmLabTest()
        {
            InitializeComponent();
        }
        List<Data.HCISData.Department> deplst;
        bool fromLoad;
        private void frmLabTest_Load(object sender, EventArgs e)
        {
            fromLoad = true;
            //MainGsm = MainModule.VST_Set;
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();

            deplst = new List<Data.HCISData.Department>();
            deplst = dc.Departments.Where(x => x.TypeID == 52).ToList();
            departmentBindingSource.DataSource = deplst;
            string dep = Properties.Settings.Default.SelectedLab;
            if (!string.IsNullOrWhiteSpace(dep))
            {
                if (dep == "Hospital")
                    lkpLab.EditValue = dc.Departments.Where(x => x.TypeID == 52).FirstOrDefault().ID;
                else
                    lkpLab.EditValue = dc.Departments.Where(x => x.TypeID == 52 && x.Name == "آزمایشگاه کوی نفت").FirstOrDefault().ID;
            }
            else
                lkpLab.EditValue = dc.Departments.Where(x => x.TypeID == 52 && x.Name == "آزمایشگاه کوی نفت").FirstOrDefault().ID;
            fromLoad = false;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();

            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                servicesBindingSource.DataSource = dc.FavoriteServices.Where(x => x.UserID == MainModule.UserID).Select(x => x.Service).ToList();

            }
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            var current = servicesBindingSource.Current as Data.HCISData.Service;
            if (current == null)
                return;
            if (!patientTests.Contains(current))
            {
                patientTests.Add(current);
            }
            else
            {
                MessageBox.Show("این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientTestsBindingSource.DataSource = patientTests;
            gridControl1.RefreshDataSource();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var person = dc.Persons.FirstOrDefault(c => c.NationalCode == MainModule.VST_Set.Person.NationalCode);
            var InsurID = dc.Insurances.FirstOrDefault(c => c.Name == person.InsuranceName).ID;
            var dos = new Data.HCISData.Dossier()
            {
                PersonID = person.ID,
                Date = Classes.MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                DepartmentID = Guid.Parse(lkpLab.EditValue.ToString()), //    DepartmentID = Guid.Parse("419a412b-adcd-490f-80d7-aa191387cd91"),//بیمارستان,
                NationalCode = person.NationalCode,
                CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                CreatorUser = Classes.MainModule.UserID,
                IOtype = 0,
                XInsuranceID = InsurID
            };

            var gsm = new Data.HCISData.GivenServiceM()
            {
                // GivenServiceM1 = MainGsm,
                Priority = false,
                PersonID = person.ID,
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                InsuranceID = InsurID,
              DepartmentID = Guid.Parse(lkpLab.EditValue.ToString()),   //DepartmentID = Guid.Parse("419a412b-adcd-490f-80d7-aa191387cd91"),//بیمارستان
                RequestStaffID = Guid.Parse("128cf084-0ab8-4401-9854-0e23990fa9b3"),//دکتر شفیعی زاده
                RequestDate = MainModule.GetPersianDate(DateTime.Now),
                RequestTime = DateTime.Now.ToString("HH:mm"),
                CreatorUserID = MainModule.UserID,
                Dossier = dos,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                ServiceCategoryID = 1,
                VST_OMO = MainModule.VST_Set.ID
            };

            var lstLabTests = dc.Services.Where(x => x.CategoryID == 1).ToList();
            List<Data.HCISData.Service> lstFullTests = new List<Data.HCISData.Service>();
            patientTests.ForEach(x => x.MustHavePrice = true);
            foreach (var srv in patientTests)
            {
                var oldID = srv.OldID;
                var childs = lstLabTests.Where(c => c.OldParentID == oldID).ToList();

                foreach (var itemchild in childs)
                {
                    if (patientTests.Any(x => x.OldID == itemchild.OldID))
                        continue;

                    itemchild.Partial_LabParent = srv;
                    lstFullTests.Add(itemchild);
                }
            }
            lstFullTests.AddRange(patientTests);

            foreach (var x in lstFullTests)
            {
                var gsd = new Data.HCISData.GivenServiceD()
                {
                    GivenServiceM = gsm,
                    ServiceID = x.ID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Amount = 1,
                    GivenAmount = 1,
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    GivenLaboratoryServiceD = new Data.HCISData.GivenLaboratoryServiceD() { NormalRange = x.LaboratoryServiceDetail?.NormalRange }
                };
                if (x.MustHavePrice)
                {
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == x.ID && z.InsuranceID == InsurID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.PayedPrice = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }
                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PayedPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.PayedPrice = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                    }
                }
                else
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.PayedPrice = 0;
                    gsd.InsuranceShare = 0;
                    gsd.TotalPrice = 0;
                }
            }
            dc.GivenServiceMs.InsertOnSubmit(gsm);
            gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            gsm.PayedPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            if (gsm.PaymentPrice == 0)
            {
                gsm.Payed = true;
                gsm.PayedPrice = 0;

            }

            foreach (var x in gsm.GivenServiceDs.ToList())
            {
                if (x.GivenLaboratoryServiceD == null)
                    x.GivenLaboratoryServiceD = new Data.HCISData.GivenLaboratoryServiceD() { NormalRange = x.Service?.LaboratoryServiceDetail?.NormalRange };

                var srv = lstFullTests.FirstOrDefault(y => y.ID == x.ServiceID);

                if (srv.Partial_LabParent != null)
                {
                    x.GivenServiceD1 = gsm.GivenServiceDs.FirstOrDefault(y => y.ServiceID == srv.Partial_LabParent.ID);
                    srv.Partial_LabParent = null;
                }
            }

            dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
            dc.SubmitChanges();
            MessageBox.Show(".آزمایشات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            patientTests.ForEach(x => x.MustHavePrice = false);
            PatientTestsBindingSource.DataSource = null;
            patientTests.Clear();
        }

        private void frmLabTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(patientTests.Any())
            {
                var result = MessageBox.Show("آیا مایل به ذخیره ی تغییرات هستید؟", "توجه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (result == DialogResult.Yes)
                {
                    btnOK_Click(null, null);
                }
                else if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void lkpLab_EditValueChanged(object sender, EventArgs e)
        {
            if (!fromLoad)
            {
                if (lkpLab.EditValue.ToString() == "419a412b-adcd-490f-80d7-aa191387cd91")
                    Properties.Settings.Default.SelectedLab = "Hospital";
                else
                    Properties.Settings.Default.SelectedLab = "Other";

            }
        }
    }
}