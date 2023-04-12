using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgParaService : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        GivenServiceD ObjectGSD;
        List<GivenServiceD> lstGSD;

        public dlgParaService()
        {
            InitializeComponent();
        }

        private void dlgParaService_Load(object sender, EventArgs e)
        {
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SalamatBookletCode != null).OrderBy(c => c.Name).ToList();
            GetData();
        }

        private void EndEdit()
        {
            GSDBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (ObjectGSD == null)
                {
                    ObjectGSD = new GivenServiceD() { Amount = 1 };
                }
                if (lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }

                GSDBindingSource.DataSource = ObjectGSD;
                givenServiceDBindingSource.DataSource = lstGSD;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectGSD.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.Time = DateTime.Now.ToString("HH:mm");
            ObjectGSD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.LastModificationTime = DateTime.Now.ToString("HH:mm");
            ObjectGSD.Confirm = true;

            if (ObjectGSD.Service != null)
            {
                lstGSD.Add(ObjectGSD);
            }
            else
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectGSD = null;
            GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            if (lstGSD.Any())
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = MainModule.GSM_Set.ID,
                    Person = MainModule.GSM_Set.Person,
                    Dossier = MainModule.GSM_Set.Dossier,
                    CreationDate = today,
                    CreationTime = now,
                    CreatorUserID = MainModule.UserID,
                    CreatorUserFullname = MainModule.UserFullName,
                    LastModificationDate = today,
                    LastModificationTime = now,
                    LastModificator = MainModule.UserID,
                    Date = today,
                    Time = now,
                    Admitted = true,
                    AdmitDate = today,
                    AdmitTime = now,
                    AdmitUserID = MainModule.UserID,
                    Confirm = true,
                    ConfirmDate = today,
                    ConfirmTime = now,
                    DepartmentID = MainModule.MyDepartment.ID,
                    InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                    InsuranceNo = MainModule.GSM_Set.InsuranceNo == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                    ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                };

                foreach (var item in lstGSD)
                {
                    gsm.ServiceCategoryID = (int)Category.خدمات_کلینیکی;
                    item.GivenServiceM = gsm;
                    item.GivenAmount = item.Amount;
                    item.Payed = true;
                    item.Confirm = true;
                    item.LastModificationDate = today;
                    item.LastModificationTime = now;
                    item.LastModificator = MainModule.UserID;
                    dc.GivenServiceDs.InsertOnSubmit(item);
                }
                dc.GivenServiceMs.InsertOnSubmit(gsm);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }
    }
}