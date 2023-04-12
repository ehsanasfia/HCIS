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
using HCISAngio.Dialogs;
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Forms
{
    public partial class frmAngiography : DevExpress.XtraEditors.XtraForm
    {
        HCISAngioDataClassesDataContext dc = new HCISAngioDataClassesDataContext();

        public frmAngiography()
        {
            InitializeComponent();
            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }

        private void frmSurgery_Load(object sender, EventArgs e)
        {
            if (MainModule.GSM_Set.Confirm == true)
            {
                //btnNew.Enabled = false;
                //btnNext.Enabled = false;
                //btnSendPatient.Enabled = false;
            }

            AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
            || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
            gridControl1.RefreshDataSource();

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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAngiography();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
                || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = AngioGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;

            if (crnt.Service.CategoryID == (int)Category.آنژیوگرافی)
            {
                var dlg = new dlgEditAngiography();
                dlg.dc = dc;
                dlg.ObjectGSD = crnt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                    (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
                    || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                    gridControl1.RefreshDataSource();
                }
            }

            if (crnt.Service.CategoryID == (int)Category.آنژیوپلاستی)
            {
                var dlg = new dlgEditAngioPlasty();
                dlg.dc = dc;
                dlg.ObjectGSD = crnt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                    (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
                    || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                    gridControl1.RefreshDataSource();
                }
            }
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAngiography();
            var crnt = AngioGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            dlg.Text = "جراحی بعدی";
            dlg.dc = dc;
            dlg.crnt = crnt;
            dlg.isNext = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
                || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnMedicineAndSupplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAngioMedicineAndSupplies();
            var crnt = AngioGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (crnt.GivenServiceM.ServiceCategoryID != (int)Category.آنژیوگرافی && crnt.GivenServiceM.ServiceCategoryID != (int)Category.آنژیوپلاستی)
            {
                MessageBox.Show("لطفا برای ثبت دارو و لوازم مصرفی ابتدا یک عمل را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.dc = dc;
            dlg.crnt = crnt;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
                (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
                || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnSendPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAngioHistory();
            var crnt = AngioGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            dlg.dc = dc;
            if (crnt.Service.CategoryID == (int)Category.آنژیوگرافی)
            {
                dlg.crnt = crnt;
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("این عمل جزییات بیشتری ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void AngioGSDBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = AngioGSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            DrugSuppGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            ((x.GivenServiceM.ServiceCategoryID == (int)Category.دارو && x.GivenServiceM.GivenServiceM1 == cur.GivenServiceM)
            || (x.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی && x.GivenServiceM.GivenServiceM1 == cur.GivenServiceM))).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
            gridControl2.RefreshDataSource();
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = DrugSuppGSDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;

            dc.GivenServiceDs.DeleteOnSubmit(cur);
            gridView2.DeleteSelectedRows();
            dc.SubmitChanges();
            gridControl2.RefreshDataSource();
        }

        private void btnDeleteAngio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var crnt = AngioGSDBindingSource.Current as GivenServiceD;
            if (crnt == null)
                return;
            if (MessageBox.Show("آیا از حذف این عمل اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            
            var gsd = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            ((x.GivenServiceM.ServiceCategoryID == (int)Category.دارو && x.GivenServiceM.GivenServiceM1 == crnt.GivenServiceM)
            || (x.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی && x.GivenServiceM.GivenServiceM1 == crnt.GivenServiceM))).ToList();
            var gsm = dc.GivenServiceMs.Where(x => x.ParentID != null && x.ParentID == crnt.GivenServiceMID).ToList();

            dc.GivenServiceDs.DeleteAllOnSubmit(gsd);
            dc.GivenServiceMs.DeleteAllOnSubmit(gsm);
            gsm.ForEach(x =>
            {
                if(x.Angio != null)
                    dc.Angios.DeleteOnSubmit(x.Angio);
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
            if (crnt.GivenServiceM.Angio != null)
            {
                dc.Angios.DeleteOnSubmit(crnt.GivenServiceM.Angio);
            }
            if (crnt.GivenServiceM.GivenServiceDs.Count == 1)
                dc.GivenServiceMs.DeleteOnSubmit(crnt.GivenServiceM);

            dc.SubmitChanges();
            AngioGSDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID && x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID &&
            (x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوگرافی
            || x.GivenServiceM.ServiceCategoryID == (int)Category.آنژیوپلاستی)).OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
            gridControl1.RefreshDataSource();
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
    }
}