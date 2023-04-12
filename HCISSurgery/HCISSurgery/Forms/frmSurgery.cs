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

namespace HCISSurgery.Forms
{
    public partial class frmSurgery : DevExpress.XtraEditors.XtraForm
    {
        HCISSurgeryDataClassesDataContext dc = new HCISSurgeryDataClassesDataContext();

        public frmSurgery()
        {
            InitializeComponent();
        }

        private void frmSurgery_Load(object sender, EventArgs e)
        {
            if (MainModule.GSM_Set.Confirm == true)
            {
                //btnNew.Enabled = false;
                //btnEdit.Enabled = false;
            }

            if (MainModule.MyDepartment != null && MainModule.MyDepartment.Name == "اتاق عمل اورژانس")
            {
                btnDoctorInstructions.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnParaService.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnDoctorInstructions.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnParaService.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            GetData();

            bsiBirthDate.Caption = "تاریخ تولد: " + MainModule.GSM_Set.Person.BirthDate ?? "";
            bsiFatherName.Caption = "نام پدر: " + MainModule.GSM_Set.Person.FatherName ?? "";
            bsiFirstName.Caption = "نام: " + MainModule.GSM_Set.Person.FirstName ?? "";
            bsiLastName.Caption = "نام خانوادگی: " + MainModule.GSM_Set.Person.LastName ?? "";
            bsiNationalCode.Caption = "کد ملی: " + MainModule.GSM_Set.Person.NationalCode ?? "";
            bsiPersonalCode.Caption = "کد پرسنلی: " + MainModule.GSM_Set.Person.PersonalCode ?? "";
            if (MainModule.GSM_Set.Person.Photo != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = MainModule.GSM_Set.Person.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    bbiPic.EditValue = Image.FromStream(ms);
                }
            }
            else
                bbiPic.EditValue = null;
        }

        private void GetData()
        {
            if (MainModule.MyDepartment != null && MainModule.MyDepartment.Name == "اتاق عمل اورژانس")
            {
                GSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                (x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_جراحی || x.GivenServiceM.ServiceCategoryID == (int)Category.بیهوشی || x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_کلینیکی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
            else
            {
                GSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                (x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_جراحی || x.GivenServiceM.ServiceCategoryID == (int)Category.بیهوشی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSurgeryNewVersion();
            dlg.Text = "جراحی جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GetData();
            }
            //else
            //{
            //    dlg.ObjectGSDAnesthesia.ModularServices.Clear();
            //    dlg.ObjectGSDSurgery.ModularServices.Clear();
            //}
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = GSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (crnt.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_جراحی)
            {
                var dlg = new dlgEditSurgeryNewVersion() { dc = dc, ObjectGSDSurgery = crnt, ObjectSurgery = crnt.Surgery };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var lstD = crnt.GivenServiceM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو).ToList();
                    var lstL = crnt.GivenServiceM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.لوازم_مصرفی).ToList();
                    foreach (var d in lstD)
                    {
                        if (d != null)
                        {
                            foreach (var item in d.GivenServiceDs)
                            {
                                item.Date = crnt.Date;
                            }
                        }
                    }
                    foreach (var l in lstL)
                    {
                        if (l != null)
                        {
                            foreach (var item in l.GivenServiceDs)
                            {
                                item.Date = crnt.Date;
                            }
                        }
                    }

                    dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, crnt);
                    dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, crnt.Surgery);
                    dc.SubmitChanges();
                    gridControl2.RefreshDataSource();
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, crnt);
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, crnt.Surgery);
                    GetData();
                }
            }
            if (crnt.GivenServiceM.ServiceCategoryID == (int)Category.بیهوشی)
            {
                var dlg = new dlgEditAnesthesiaNewVersion() { dc = dc, ObjectGSDSurgery = crnt, ObjectSurgery = crnt.Surgery };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var lstD = crnt.GivenServiceM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو).ToList();
                    var lstL = crnt.GivenServiceM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.لوازم_مصرفی).ToList();
                    foreach (var d in lstD)
                    {
                        if (d != null)
                        {
                            foreach (var item in d.GivenServiceDs)
                            {
                                item.Date = crnt.Date;
                            }
                        }
                    }
                    foreach (var l in lstL)
                    {
                        if (l != null)
                        {
                            foreach (var item in l.GivenServiceDs)
                            {
                                item.Date = crnt.Date;
                            }
                        }
                    }

                    dc.SubmitChanges();
                    gridControl2.RefreshDataSource();
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, crnt);
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, crnt.Surgery);
                    GetData();
                }
            }
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSurgery();
            var crnt = GSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (crnt.Service.CategoryID == (int)Category.دارو || crnt.Service.CategoryID == (int)Category.لوازم_مصرفی)
            {
                MessageBox.Show("لطفا یک عمل را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            dlg.Text = "جراحی بعدی";
            dlg.dc = dc;
            dlg.crnt = crnt;
            dlg.isNext = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GetData();
            }
        }

        private void btnMedicineAndSupplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = GSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            var dlg = new dlgMedicineAndSupplies();
            dlg.dc = dc;
            dlg.crnt = crnt;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnSendPerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgGoToWard { person = MainModule.GSM_Set.Person, visit = MainModule.GSM_Set, dc = dc };
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                if (dlg.isEdit == false)
                {
                    MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                    MainModule.GSM_Set.Confirm = true;
                }
                dc.SubmitChanges();
                btnClose_ItemClick(null, null);
                MainModule.GSM_Set = null;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPathology_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPathology();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
        }

        private void btnSurgeryRpt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = GSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            var dlg = new dlgSurgeryRpt();
            dlg.dc = dc;
            dlg.GSD = cur;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
        }

        private void btnAnesthesiaRpt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = GSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            var dlg = new dlgAnesthesiaRpt();
            dlg.dc = dc;
            dlg.GSD = cur;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
        }

        private void btnAfterSurgeryRpt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = GSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            var dlg = new dlgAfterSurgeryRpt();
            dlg.dc = dc;
            dlg.GSD = cur;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
        }

        private void btnFinancialDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgFinancialDepartment();
            dlg.dc = dc;
            dlg.GSM = MainModule.GSM_Set;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
            else
            {
                dc.Dispose();
                dc = new HCISSurgeryDataClassesDataContext();
                GetData();
            }
        }

        private void btnDischarge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDischarge();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                MessageBox.Show("بیمار ترخیص گردید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                btnClose_ItemClick(null, null);
                MainModule.GSM_Set = null;
            }
        }

        private void GSDBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = GSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            DrugSuppGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            ((x.GivenServiceM.ServiceCategoryID == (int)Category.دارو && x.GivenServiceM.GivenServiceM1 == cur.GivenServiceM) ||
            (x.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی && x.GivenServiceM.GivenServiceM1 == cur.GivenServiceM))).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
            gridControl2.RefreshDataSource();
        }

        private void btnEditDS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = DrugSuppGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (crnt.GivenServiceM.ServiceCategoryID == (int)Category.دارو)
            {
                var dlg = new dlgEditDrugAndSupplies() { dc = dc, ObjectGSD = crnt };
                dlg.Text = "ویرایش دارو";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dc.SubmitChanges();
                }
            }
            if (crnt.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی)
            {
                var dlg = new dlgEditDrugAndSupplies() { dc = dc, ObjectGSD = crnt };
                dlg.Text = "ویرایش لوازم مصرفی";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dc.SubmitChanges();
                }
            }
        }

        private void btnDeleteSurgery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = GSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (MessageBox.Show("آیا از حذف این عمل اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var gsd = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            ((x.GivenServiceM.ServiceCategoryID == (int)Category.دارو && x.GivenServiceM.GivenServiceM1 == crnt.GivenServiceM) ||
            (x.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی && x.GivenServiceM.GivenServiceM1 == crnt.GivenServiceM))).ToList();
            var gsm = dc.GivenServiceMs.Where(x => x.ParentID != null && x.ParentID == crnt.GivenServiceMID).ToList();
            dc.GivenServiceDs.DeleteAllOnSubmit(gsd);
            dc.GivenServiceMs.DeleteAllOnSubmit(gsm);
            gsm.ForEach(x =>
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(x.GivenServiceMs);
            });

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dc.GivenServiceDs.DeleteOnSubmit(crnt);
            dc.Surgeries.DeleteOnSubmit(crnt.Surgery);
            if (crnt.GivenServiceM.GivenServiceDs.Count == 1)
                dc.GivenServiceMs.DeleteOnSubmit(crnt.GivenServiceM);

            dc.SubmitChanges();
            GetData();
        }

        private void btnDoctorInstructions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDoctorOrder() { dc = dc };
            dlg.ShowDialog();
        }

        private void btnParaService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgParaService();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}