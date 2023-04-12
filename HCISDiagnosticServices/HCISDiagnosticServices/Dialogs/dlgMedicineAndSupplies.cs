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
using HCISDiagnosticServices.Dialogs;
using HCISDiagnosticServices.Data;

namespace HCISDiagnosticServices.Dialogs
{
    public partial class dlgMedicineAndSupplies : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM crnt { get; set; }

        GivenServiceD ObjectdrugGSD;
        List<GivenServiceD> lstGSDdrug;

        public dlgMedicineAndSupplies()
        {
            InitializeComponent();
        }

        private void dlgMedicineAndSupplies_Load(object sender, EventArgs e)
        {
            var depid = dc.Departments.FirstOrDefault(x => x.Name == "بیمارستان").ID;
            DrugServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
            DrugDiagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.دارو).ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == depid).OrderBy(x => x.Name).ToList();
            GetData();
        }

        private void EndEdit()
        {
            DrugGSDBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (ObjectdrugGSD == null)
                {
                    ObjectdrugGSD = new GivenServiceD() { Amount = 1 };
                }
                if (lstGSDdrug == null)
                {
                    lstGSDdrug = new List<GivenServiceD>();
                }
                DrugGSDBindingSource.DataSource = ObjectdrugGSD;
                givenServiceDBindingSource.DataSource = lstGSDdrug;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if((lkpDrugStore.EditValue as Department) == null)
            {
                MessageBox.Show("لطفا یک داروخانه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var gsmDrug = new GivenServiceM()
            {
                ParentID = crnt.ID,
                Person = crnt.Person,
                Dossier = crnt.Dossier,
                Department = (lkpDrugStore.EditValue as Department),
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                CreatorUserID = MainModule.UserID,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID,
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
            };
            foreach (var item in lstGSDdrug)
            {
                gsmDrug.ServiceCategoryID = (int)Category.دارو;
                item.GivenServiceM = gsmDrug;
                item.NIS = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == item.Service.ID && c.PharmacyID == (lkpDrugStore.EditValue as Department).ID).NIS;
                if (item.NIS == true)
                {
                    item.Payed = true;
                    item.PaymentPrice = 0;
                    item.PatientShare = 0;
                    item.InsuranceShare = 0;
                }
                else
                {
                    var tarefee = item.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == crnt.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        item.Payed = true;
                        item.PaymentPrice = 0;
                        item.PatientShare = 0;
                        item.InsuranceShare = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        item.Payed = true;
                        item.PaymentPrice = 0;
                        item.PatientShare = 0;
                        item.InsuranceShare = (decimal)item.Amount * tarefee.OrganizationShare ?? 0;
                    }
                    else
                    {
                        item.PaymentPrice = (decimal)item.Amount * tarefee.PatientShare ?? 0;
                        item.PatientShare = (decimal)item.Amount * tarefee.PatientShare ?? 0;
                        item.InsuranceShare = (decimal)item.Amount * tarefee.OrganizationShare ?? 0;
                    }
                }
            }
            dc.GivenServiceMs.InsertOnSubmit(gsmDrug);
            gsmDrug.PaymentPrice = gsmDrug.GivenServiceDs.Sum(x => x.PatientShare);
            if (gsmDrug.PaymentPrice == 0)
            {
                gsmDrug.Payed = true;
                gsmDrug.PayedPrice = 0;
            }

            dc.GivenServiceDs.InsertAllOnSubmit(lstGSDdrug);

            DialogResult = DialogResult.OK;
        }

        private void DeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            ObjectdrugGSD.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectdrugGSD.Time = DateTime.Now.ToString("HH:mm");
            ObjectdrugGSD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectdrugGSD.LastModificationTime = DateTime.Now.ToString("HH:mm");

            if (ObjectdrugGSD.Service != null)
            {
                lstGSDdrug.Add(ObjectdrugGSD);
            }
            else
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectdrugGSD = null;
            GetData();
        }
    }
}