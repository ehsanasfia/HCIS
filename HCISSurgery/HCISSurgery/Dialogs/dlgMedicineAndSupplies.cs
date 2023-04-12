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
using HCISSurgery.Dialogs;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgMedicineAndSupplies : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD crnt { get; set; }
        GivenServiceD ObjectdrugGSD;
        GivenServiceD ObjectusingGSD;
        List<GivenServiceD> lstGSDdrug;
        List<GivenServiceD> lstGSDsupp;

        public dlgMedicineAndSupplies()
        {
            InitializeComponent();
        }

        private void dlgMedicineAndSupplies_Load(object sender, EventArgs e)
        {
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            DrugServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
            DrugDiagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.دارو).ToList();
            UsingServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.لوازم_مصرفی).ToList();
            UsingDiagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.لوازم_مصرفی).ToList();
            GetData();
        }

        private void EndEdit()
        {
            DrugGSDBindingSource.EndEdit();
            UsingGSDBindingSource.EndEdit();
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
                if (ObjectusingGSD == null)
                {
                    ObjectusingGSD = new GivenServiceD() { Amount = 1 };
                }
                if (lstGSDdrug == null)
                {
                    lstGSDdrug = new List<GivenServiceD>();
                }
                if (lstGSDsupp == null)
                {
                    lstGSDsupp = new List<GivenServiceD>();
                }
                DrugGSDBindingSource.DataSource = ObjectdrugGSD;
                UsingGSDBindingSource.DataSource = ObjectusingGSD;
                givenServiceDBindingSource.DataSource = lstGSDdrug;
                givenServiceDBindingSource1.DataSource = lstGSDsupp;
                gridControl1.RefreshDataSource();
                gridControl2.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            if (lstGSDdrug.Any())
            {
                var gsmDrug = new GivenServiceM()
                {
                    ParentID = crnt.GivenServiceM.ID,
                    Person = MainModule.GSM_Set.Person,
                    Dossier = MainModule.GSM_Set.Dossier,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    LastModificator = MainModule.UserID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Admitted = true,
                    Confirm = true,
                    AdmitDate = MainModule.GetPersianDate(DateTime.Now),
                    AdmitTime = DateTime.Now.ToString("HH:mm"),
                    DepartmentID = MainModule.MyDepartment.ID,
                    InsuranceID = crnt.GivenServiceM.InsuranceID,
                    AnsweringDate = today,
                    AdmitUserID = MainModule.UserID,
                    CreatorUserFullname = MainModule.UserFullName,
                    BookletExpireDate = crnt.GivenServiceM.BookletExpireDate,
                    BookletDate = crnt.GivenServiceM.BookletDate,
                    BookletPageNumber = crnt.GivenServiceM.BookletPageNumber,
                    BookletSerialNumber = crnt.GivenServiceM.BookletSerialNumber,
                    ComplementInsurance = crnt.GivenServiceM.ComplementInsurance,
                    ComplementInsuranceNO = crnt.GivenServiceM.ComplementInsuranceNO,
                    InsuranceNo = crnt.GivenServiceM.InsuranceNo,
                    RequestDate = today,
                    RequestTime = now,
                    ServiceCategoryID = (int)Category.دارو,
                };

                foreach (var item in lstGSDdrug)
                {
                    gsmDrug.ServiceCategoryID = (int)Category.دارو;
                    item.GivenServiceM = gsmDrug;
                    item.GivenAmount = item.Amount;
                    item.Payed = true;
                    item.Confirm = true;
                    item.LastModificationDate = today;
                    item.LastModificationTime = now;
                    item.LastModificator = MainModule.UserID;
                    dc.GivenServiceDs.InsertOnSubmit(item);
                }
                dc.GivenServiceMs.InsertOnSubmit(gsmDrug);
            }
            if (lstGSDsupp.Any())
            {
                var gsmUsing = new GivenServiceM()
                {
                    ParentID = crnt.GivenServiceM.ID,
                    Person = MainModule.GSM_Set.Person,
                    Dossier = MainModule.GSM_Set.Dossier,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    LastModificator = MainModule.UserID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Admitted = true,
                    Confirm = true,
                    AdmitDate = MainModule.GetPersianDate(DateTime.Now),
                    AdmitTime = DateTime.Now.ToString("HH:mm"),
                    DepartmentID = MainModule.MyDepartment.ID,
                    InsuranceID = crnt.GivenServiceM.InsuranceID,
                    AnsweringDate = today,
                    AdmitUserID = MainModule.UserID,
                    CreatorUserFullname = MainModule.UserFullName,
                    BookletExpireDate = crnt.GivenServiceM.BookletExpireDate,
                    BookletDate = crnt.GivenServiceM.BookletDate,
                    BookletPageNumber = crnt.GivenServiceM.BookletPageNumber,
                    BookletSerialNumber = crnt.GivenServiceM.BookletSerialNumber,
                    ComplementInsurance = crnt.GivenServiceM.ComplementInsurance,
                    ComplementInsuranceNO = crnt.GivenServiceM.ComplementInsuranceNO,
                    InsuranceNo = crnt.GivenServiceM.InsuranceNo,
                    RequestDate = today,
                    RequestTime = now,
                    ServiceCategoryID = (int)Category.لوازم_مصرفی
                };
                foreach (var item in lstGSDsupp)
                {
                    item.GivenServiceM = gsmUsing;
                    item.GivenAmount = item.Amount;
                    item.Payed = true;
                    item.Confirm = true;
                    item.LastModificationDate = today;
                    item.LastModificationTime = now;
                    item.LastModificator = MainModule.UserID;
                    dc.GivenServiceDs.InsertOnSubmit(item);
                }
                dc.GivenServiceMs.InsertOnSubmit(gsmUsing);
            }

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
            ObjectdrugGSD.Confirm = true;

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

        private void btnPanelDrug_Click(object sender, EventArgs e)
        {
            var dlg = new dlgDrugsPanel();
            dlg.dc = dc;
            dlg.crnt = crnt;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in dlg.lstPTD)
                {
                    var gsd = new GivenServiceD()
                    {
                        Service = item.Service,
                        Amount = item.Amount,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Confirm = true
                    };
                    lstGSDdrug.Add(gsd);
                }
                GetData();
            }
        }

        private void btnAddSupp_Click(object sender, EventArgs e)
        {
            ObjectusingGSD.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectusingGSD.Time = DateTime.Now.ToString("HH:mm");
            ObjectusingGSD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectusingGSD.LastModificationTime = DateTime.Now.ToString("HH:mm");
            ObjectusingGSD.Confirm = true;

            if (ObjectusingGSD.Service != null)
            {
                lstGSDsupp.Add(ObjectusingGSD);
            }
            else
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectusingGSD = null;
            GetData();
        }

        private void btnPanelSupp_Click(object sender, EventArgs e)
        {
            var dlg = new dlgSuppliesPanel();
            dlg.dc = dc;
            dlg.crnt = crnt;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in dlg.lstPTD)
                {
                    var gsd = new GivenServiceD()
                    {
                        Service = item.Service,
                        Amount = item.Amount,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Confirm = true
                    };
                    lstGSDsupp.Add(gsd);
                }
                GetData();
            }
        }

        private void DeleteG2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView3.DeleteSelectedRows();
        }
    }
}