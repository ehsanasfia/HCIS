using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;
using OMOApp.Dialogs;

namespace OMOApp.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext om = new OMOClassesDataContext();
        Data.HCISData.HCISClassesDataContext hdc = new Data.HCISData.HCISClassesDataContext();
        private List<ManageMent> lstManagement;
        private List<Company> lstCompany;
        private List<SubCompany> lstSubCompany;
        private List<Unit> lstUnit;
        private List<Definition> lstVisitType;

        Person EditingPerson;
        Visit EditingVisit;

        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            lstVisitType = om.Definitions.Where(x => x.ParentID == 1).ToList();
            definitionBindingSource.DataSource = lstVisitType;
            definitionBindingSource1.DataSource = om.Definitions.Where(x => x.ParentID == 224).OrderBy(x => x.Name).ToList();
            definitionBindingSource2.DataSource = om.Definitions.Where(x => x.ParentID == 300).OrderBy(x => x.Name).ToList();

            lstManagement = om.ManageMents.OrderBy(x => x.Name).ToList();
            lstCompany = om.Companies.OrderBy(x => x.Name).ToList();
            lstSubCompany = om.SubCompanies.OrderBy(x => x.Name).ToList();
            lstUnit = om.Units.OrderBy(x => x.Name).ToList();

            manageMentBindingSource.DataSource = lstManagement;

            EmptyForm();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearchNationalCode_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtNationalCode.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("لطفا کد ملی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtNationalCode.Select();
                    return;
                }
                var nat = text.Trim();
                if (nat.Length != 10)
                {
                    MessageBox.Show("کد ملی وارد شده معتبر نمیباشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtNationalCode.Select();
                    return;
                }

                var dlgSrch = new dlgPersonSearch() { GivenNationalCode = nat };
                if (dlgSrch.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var person = dlgSrch.SelectedPerson;
                if (person == null)
                    return;

                EmptyForm();
                EditingPerson = om.Persons.FirstOrDefault(x => x.ID == person.ID);
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSearchPersonalCode_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtPersonalCode.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("لطفا کد پرسنلی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtPersonalCode.Select();
                    return;
                }
                var code = text.Trim();
                int codeInt = -1;
                bool valid = int.TryParse(code, out codeInt);
                if (!valid || codeInt == -1)
                {
                    MessageBox.Show("کد پرسنلی وارد شده معتبر نمیباشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtPersonalCode.Select();
                    return;
                }

                var dlgSrch = new dlgPersonSearch() { GivenPersonalCode = code };
                if (dlgSrch.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var person = dlgSrch.SelectedPerson;
                if (person == null)
                    return;

                EmptyForm();
                EditingPerson = om.Persons.FirstOrDefault(x => x.ID == person.ID);
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void GetData()
        {
            if (EditingPerson == null || EditingPerson.ID == Guid.Empty)
            {
                EmptyForm();
                return;
            }

            txtNationalCode.Text = EditingPerson.NationalCode;
            txtPersonalCode.Text = EditingPerson.PersonalNo == null || !EditingPerson.PersonalNo.HasValue || EditingPerson.PersonalNo.Value == 0 ? null : EditingPerson.PersonalNo.Value.ToString();
            if (EditingPerson.Photo != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = EditingPerson.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pictureEdit1.EditValue = Image.FromStream(ms);
                }
            }
            else
            {
                pictureEdit1.EditValue = null;
            }


            //if (EditingPerson.IDManagement != null)
            //{
            //    txtManagement.Text = lstManagement.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement)?.Name;
            //    if (EditingPerson.IDCompany != null)
            //    {
            //        txtCompany.Text = lstCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany)?.Name;
            //        if (EditingPerson.IDSubCompany != null)
            //        {
            //            txtSubCompany.Text = lstSubCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany)?.Name;
            //            if (EditingPerson.IDunit != null)
            //            {
            //                txtUnit.Text = lstUnit.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDco == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany && x.IDUnit == EditingPerson.IDunit)?.Name;
            //            }
            //        }
            //    }
            //}
            if (EditingVisit == null)
                EditingVisit = new Visit();
            if (EditingPerson.IDManagement != null)
            {

                slkIntroductionManagement.EditValue = lstManagement.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement);
                if (EditingPerson.IDCompany != null)
                {
                    slkIntroductionCompany.EditValue = lstCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany);
                    if (EditingPerson.IDSubCompany != null)
                    {
                        slkIntroductionSubCompany.EditValue = lstSubCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany);
                        if (EditingPerson.IDunit != null)
                        {
                            slkIntroductionUnit.EditValue = lstUnit.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDco == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany && x.IDUnit == EditingPerson.IDunit);
                        }
                    }
                }
            }

            PersonBindingSource.DataSource = EditingPerson;
            PersonBindingSource.ResetBindings(false);

            if (EditingVisit != null && EditingVisit.ID != Guid.Empty)
            {
                lkpVisitType.EditValue = EditingVisit.Definition;
                lkpMoaref.EditValue = EditingVisit.Definition4;
                lkpPersonalType.EditValue = EditingVisit.Definition3;
                txtIntroductionCode.Text = EditingVisit.IntroductionCode;
                dtpAdmitDate.Date = EditingVisit.AdmitDate;
                dtpIntroductionDate.Date = EditingVisit.IntroductionDate;
                txtAdmitTime.Text = EditingVisit.AdmitTime;
                txtCurrentJob.Text = EditingVisit.CurrentJob;
                txtSuggestJob.Text = EditingVisit.SuggestedJob;

                if (EditingVisit.IntroductionIDManagment != null)
                {
                    slkIntroductionManagement.EditValue = lstManagement.FirstOrDefault(x => x.IDMg == EditingVisit.IntroductionIDManagment);
                    if (EditingVisit.IntroductionCompanyID != null)
                    {
                        slkIntroductionCompany.EditValue = lstCompany.FirstOrDefault(x => x.IDMg == EditingVisit.IntroductionIDManagment && x.IDCo == EditingVisit.IntroductionCompanyID);
                        if (EditingVisit.IntroductionIDSubCompany != null)
                        {
                            slkIntroductionSubCompany.EditValue = lstSubCompany.FirstOrDefault(x => x.IDMg == EditingVisit.IntroductionIDManagment && x.IDCo == EditingVisit.IntroductionCompanyID && x.IDOrgan == EditingVisit.IntroductionIDSubCompany);
                            if (EditingVisit.IntroductionIDUnit != null)
                            {
                                slkIntroductionUnit.EditValue = lstUnit.FirstOrDefault(x => x.IDMg == EditingVisit.IntroductionIDManagment && x.IDco == EditingVisit.IntroductionCompanyID && x.IDOrgan == EditingVisit.IntroductionIDSubCompany && x.IDUnit == EditingVisit.IntroductionIDUnit);
                            }
                        }
                    }
                }
            }
            else
            {
                var lastVisit = om.Visits.Where(x => x.PersonID == EditingPerson.ID).OrderByDescending(c => c.AdmitDate).FirstOrDefault();
                if(lastVisit != null)
                {
                    txtCurrentJob.Text = lastVisit.CurrentJob;
                }
            }

            visitBindingSource.DataSource = EditingPerson.Visits.OrderBy(x => x.AdmitDate).ToList();
            gridControl1.RefreshDataSource();

            personWorkHistoryBindingSource.DataSource = om.PersonWorkHistories.Where(x => x.PesronID == EditingPerson.ID).OrderBy(x => x.CreationDate).ToList();
            gridControl2.RefreshDataSource();
        }

        private void EmptyForm()
        {
            EditingPerson = new Person();
            PersonBindingSource.DataSource = EditingPerson;

            EditingVisit = null;

            txtNationalCode.Text = "";
            txtPersonalCode.Text = "";
            //txtManagement.Text = "";
            //txtCompany.Text = "";
            //txtSubCompany.Text = "";
            //txtUnit.Text = "";
            txtCurrentJob.Text = "";
            txtSuggestJob.Text = "";
            lkpVisitType.EditValue = lstVisitType.FirstOrDefault(x => x.ID == 2);
         
            slkIntroductionManagement.EditValue = null;
            txtIntroductionCode.Text = "";
            dtpAdmitDate.Date = MainModule.GetPersianDate(DateTime.Now);
            dtpIntroductionDate.Date = MainModule.GetPersianDate(DateTime.Now);
            txtAdmitTime.Text = DateTime.Now.ToString("HH:mm");
            pictureEdit1.EditValue = null;
            visitBindingSource.DataSource = null;
            personWorkHistoryBindingSource.DataSource = null;
            gridControl2.RefreshDataSource();
            gridControl1.RefreshDataSource();
            slkIntroductionManagement.EditValue = null;
            slkIntroductionCompany.EditValue = null;
            slkIntroductionSubCompany.EditValue = null;
            slkIntroductionUnit.EditValue = null;
            lkpPersonalType.EditValue = null;
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchNationalCode_Click(null, null);
                lkpVisitType.Select();
            }
        }

        private void txtPersonalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchPersonalCode_Click(null, null);
                lkpVisitType.Select();
            }
        }

        private void btnEditPerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null || EditingPerson.ID == Guid.Empty)
            {
                MessageBox.Show("ابتدا مراجعه کننده را جستجو کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new Dialogs.dlgPerson() { EditingPerson = EditingPerson };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var prs = dlg.EditingPerson;
            EditingPerson = om.Persons.FirstOrDefault(x => x.ID == prs.ID);
            om.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingPerson);
            GetData();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EmptyForm();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null || EditingPerson.ID == Guid.Empty)
            {
                MessageBox.Show("ابتدا مراجعه کننده را جستجو کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var vstType = lkpVisitType.EditValue as Definition;
            if (vstType == null)
            {
                MessageBox.Show("لطفا نوع معاینات را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var vstIntoduce = lkpMoaref.EditValue as Definition;
            if (vstIntoduce == null)
            {
                MessageBox.Show("لطفا نوع معاینات را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");


                var mg = slkIntroductionManagement.EditValue as ManageMent;
                var cmp = slkIntroductionCompany.EditValue as Company;
                var sub = slkIntroductionSubCompany.EditValue as SubCompany;
                var unt = slkIntroductionUnit.EditValue as Unit;

                var prsType = lkpPersonalType.EditValue as Definition;

                if (EditingVisit == null)
                    EditingVisit = new Visit();
                
                EditingVisit.AdmitDate = dtpAdmitDate.Date;
                EditingVisit.AdmitTime = txtAdmitTime.Text;
                EditingVisit.IntroductionCode = txtIntroductionCode.Text;
                EditingVisit.IntroductionDate = dtpIntroductionDate.Date;
                EditingVisit.Person = EditingPerson;
                EditingVisit.Definition = vstType;
                EditingVisit.Definition4 = vstIntoduce;
                EditingVisit.Definition3 = prsType;
                EditingVisit.IntroductionIDManagment = mg?.IDMg;
                EditingVisit.IntroductionCompanyID = cmp?.IDCo;
                EditingVisit.IntroductionIDSubCompany = sub?.IDOrgan;
                EditingVisit.IntroductionIDUnit = unt?.IDUnit;
                EditingVisit.CurrentJob = txtCurrentJob.Text;
                EditingVisit.SuggestedJob = txtSuggestJob.Text;

                bool isNew = (EditingVisit.ID == Guid.Empty);
                if (EditingVisit.ID == Guid.Empty)
                {
                    EditingVisit.CreatorUserID = MainModule.UserID;
                    EditingVisit.CreationDate = today;
                    EditingVisit.CreationTime = now;
                    var tdl = new ToDoList();
                    tdl.Visit = EditingVisit;
                    om.Visits.InsertOnSubmit(EditingVisit);
                    om.ToDoLists.InsertOnSubmit(tdl);
                }

                om.SubmitChanges();
                if (isNew)
                    MessageBox.Show("پذیرش با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                else
                    MessageBox.Show("پذیرش با موفقیت ویرایش شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                Classes.MainModule.VST_Set = EditingVisit;
                visitBindingSource.DataSource = om.Visits.Where(x => x.PersonID == EditingPerson.ID).OrderByDescending(c => c.AdmitDate);

                // btnCancel_ItemClick(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void slkIntroductionManagement_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkIntroductionManagement.EditValue as ManageMent;
            if (cur == null)
            {
                companyBindingSource.DataSource = null;
                return;
            }

            companyBindingSource.DataSource = lstCompany.Where(x => x.IDMg == cur.IDMg).ToList();
        }

        private void slkIntroductionCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkIntroductionCompany.EditValue as Company;
            if (cur == null)
            {
                subCompanyBindingSource.DataSource = null;
                return;
            }

            subCompanyBindingSource.DataSource = lstSubCompany.Where(x => x.IDMg == cur.IDMg && x.IDCo == cur.IDCo).ToList();
        }

        private void slkIntroductionSubCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkIntroductionSubCompany.EditValue as SubCompany;
            if (cur == null)
            {
                unitBindingSource.DataSource = null;
                return;
            }

            unitBindingSource.DataSource = lstUnit.Where(x => x.IDMg == cur.IDMg && x.IDco == cur.IDCo && x.IDOrgan == cur.IDOrgan).ToList();
        }

        private void btnAddWorkHistory_Click(object sender, EventArgs e)
        {
            var dlgPWH = new dlgWorkHistory() { EditingPerson = EditingPerson, isEdit = false, Text = "جدید" };
            if (dlgPWH.ShowDialog() == DialogResult.OK)
            {
                personWorkHistoryBindingSource.DataSource = om.PersonWorkHistories.Where(x => x.PesronID == EditingPerson.ID).OrderBy(x => x.CreationDate).ToList();
                gridControl2.RefreshDataSource();
            }
        }

        private void btnVisitSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgVisitSearch() { om = om };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EmptyForm();
                EditingPerson = dlg.SelectedVisit.Person;
                EditingVisit = dlg.SelectedVisit;
                GetData();
            }
        }

        private void btnPersonSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlgSrch = new dlgPersonSearch();
            if (dlgSrch.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var person = dlgSrch.SelectedPerson;
            if (person == null)
                return;

            EmptyForm();
            EditingPerson = om.Persons.FirstOrDefault(x => x.ID == person.ID);
            GetData();
        }

        private void bbiAddTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = visitBindingSource.Current as Visit;
            if (cur == null)
                return;

            if (Classes.MainModule.ConnectToHcis == true)
            {
                var a = new Dialogs.dlgLabPanelList();
                a.ObjectVST = cur;
                a.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnCancel_ItemClick(null, null);
        }

        private void bbiPatientTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Classes.MainModule.ConnectToHcis == true)
            {
                var cur = visitBindingSource.Current as Visit;
                if (cur == null)
                    return;

                var gsm = hdc.GivenServiceMs.Where(x => x.Person != null && x.Person.NationalCode == cur.Person.NationalCode && x.ServiceCategoryID == 1).ToList();
                //var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();

                if (gsm.Count == 0)
                {
                    MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                    return;
                }

                var dlg = new Dialogs.dlgAllPateintTest() { dc = hdc, TestGSM = gsm, EditingVisit = cur, ShowLabelPrint = true };
                dlg.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void txtSuggestJob_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}