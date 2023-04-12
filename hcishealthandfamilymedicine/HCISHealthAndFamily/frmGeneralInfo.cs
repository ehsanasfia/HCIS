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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;
using DevExpress.XtraEditors.Repository;

namespace HCISHealthAndFamily
{
    public partial class frmGeneralInfo : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        Person ObjectPRS;
        List<VwPersonsCompany> vwPC;

        List<QAPlus> lstPersonal;
        List<RepositoryItem> lstItems1;

        List<QAPlus> lstPrevention;
        List<RepositoryItem> lstItems2;
        RepositoryItemTextEdit DisabledTextEdit;

        PersonDisease ObjectPD;

        public frmGeneralInfo()
        {
            InitializeComponent();
        }

        private void frmGeneralInfo_Load(object sender, EventArgs e)
        {
            if (vwPC == null)
                vwPC = new List<VwPersonsCompany>();

            if (lstPersonal == null)
                lstPersonal = new List<QAPlus>();

            if (lstPrevention == null)
                lstPrevention = new List<QAPlus>();

            DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };

            if (ObjectPD == null)
                ObjectPD = new PersonDisease();

            ObjectPRS = dc.Persons.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Person.ID);
            T1PersonBindingSource.DataSource = ObjectPRS;
            personBindingSource.DataSource = dc.Persons.Where(x => x.PersonalCode == ObjectPRS.PersonalCode).OrderByDescending(c => c.ID == ObjectPRS.ID).ToList();
            if (vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID) == null)
                txtSupervisorWorkplace.Text = "";
            else
                txtSupervisorWorkplace.Text = vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID).Name;

            var quests1 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("36918818-1d85-4fb1-91f6-93485f1a45a5")).ToList();
            lstItems1 = new List<RepositoryItem>();
            gridControl4.RepositoryItems.Clear();
            foreach (var item in quests1)
            {
                var qa = new QAPlus()
                {
                    PQuestionnaire = item,
                };

                lstPersonal.Add(qa);

                if (item.Editor == "RadioGroup")
                {
                    var a = new RepositoryItemRadioGroup();
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                    }
                    a.Tag = item.ID;
                    gridControl4.RepositoryItems.Add(a);
                    lstItems1.Add(a);
                }
                else if (item.Editor == "ComboBox")
                {
                    var a = new RepositoryItemComboBox();
                    a.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = item.ID;
                    gridControl4.RepositoryItems.Add(a);
                    lstItems1.Add(a);
                }
                else if (item.Editor == "MemoExEdit")
                {
                    var a = new RepositoryItemMemoExEdit();
                    a.Tag = item.ID;
                    gridControl4.RepositoryItems.Add(a);
                    lstItems1.Add(a);
                }
                else if (item.Editor == "CheckedComboBoxEdit")
                {
                    var a = new RepositoryItemCheckedComboBoxEdit();
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = item.ID;
                    gridControl4.RepositoryItems.Add(a);
                    lstItems1.Add(a);
                }
            }

            var quests2 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("04545c0a-0056-481a-b87d-d54fe2b9879e")).ToList();
            lstItems2 = new List<RepositoryItem>();
            gridControl2.RepositoryItems.Clear();
            foreach (var item in quests2)
            {
                var qa = new QAPlus()
                {
                    PQuestionnaire = item,
                };

                lstPrevention.Add(qa);

                if (item.Editor == "RadioGroup")
                {
                    var a = new RepositoryItemRadioGroup();
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                    }
                    a.Tag = item.ID;
                    gridControl2.RepositoryItems.Add(a);
                    lstItems2.Add(a);
                }
                else if (item.Editor == "ComboBox")
                {
                    var a = new RepositoryItemComboBox();
                    a.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = item.ID;
                    gridControl2.RepositoryItems.Add(a);
                    lstItems2.Add(a);
                }
                else if (item.Editor == "MemoExEdit")
                {
                    var a = new RepositoryItemMemoExEdit();
                    a.Tag = item.ID;
                    gridControl2.RepositoryItems.Add(a);
                    lstItems2.Add(a);
                }
                else if (item.Editor == "CheckedComboBoxEdit")
                {
                    var a = new RepositoryItemCheckedComboBoxEdit();
                    var answers = item.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = item.ID;
                    gridControl2.RepositoryItems.Add(a);
                    lstItems2.Add(a);
                }
            }

            PersonalQAPlusBindingSource.DataSource = lstPersonal.OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl4.RefreshDataSource();
            PreventionQAPlusBindingSource.DataSource = lstPrevention.OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl2.RefreshDataSource();

            PersonDiseaseBindingSource.DataSource = ObjectPD;
            prsDiseaseBindingSource.DataSource = ObjectPRS.PersonDiseases.ToList();
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.ToList();

            DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
            FDdepartmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 13).ToList();
        }

        private void SetLabels()
        {
            lblBirthDate.Text = "تاریخ تولد: " + ObjectPRS.BirthDate ?? "";
            lblFatherName.Text = "نام پدر: " + ObjectPRS.FatherName ?? "";
            lblFirstName.Text = "نام: " + ObjectPRS.FirstName ?? "";
            lblLastName.Text = "نام خانوادگی: " + ObjectPRS.LastName ?? "";
            lblNationalCode.Text = "کد ملی: " + ObjectPRS.NationalCode ?? "";
            lblPersonalCode.Text = "کد پرسنلی: " + ObjectPRS.PersonalCode ?? "";
        }

        private void btnOkT1_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("تغییرات ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = personBindingSource.Current as Person;
            ObjectPRS = cur;
            T1PersonBindingSource.DataSource = ObjectPRS;
            SetLabels();
        }

        private void gridView6_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView6.GetRow(e.RowHandle) as QAPlus;
            if (e.Column == colEditor01)
            {
                e.RepositoryItem = lstItems1.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.PQuestionnaire.ID));
            }
        }

        private void btnOkT2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in lstPersonal)
                {
                    if (!string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAPlus.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                gridControl4.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnOkT3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in lstPrevention)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAPlus.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                gridControl2.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView4_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView4.GetRow(e.RowHandle) as QAPlus;
            if (e.Column == colEditor02)
            {
                if (qap.PQuestionnaire.YesNo)
                    e.RepositoryItem = DisabledTextEdit;
                else
                    e.RepositoryItem = lstItems2.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.PQuestionnaire.ID));
            }
            else if (e.Column == colResultCHK02)
            {
                if (!qap.PQuestionnaire.YesNo)
                {
                    e.RepositoryItem = DisabledTextEdit;
                }
            }
        }

        private void btnOkT4_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            ObjectPD.Person = gsm.Person;
            ObjectPD.SpecialDisease = lkpSpecialDisease.EditValue as SpecialDisease;
            ObjectPD.DateOfDiscovery = txtDate.Text;
            ObjectPD.Referred = (rdg.EditValue as bool?) ?? false;

            if (ObjectPD.Disease != null)
                dc.PersonDiseases.InsertOnSubmit(ObjectPD);
            else
                return;

            dc.SubmitChanges();
            ObjectPD = null;
            lkpSpecialDisease.EditValue = null;
            txtDate.Text = null;
            rdg.EditValue = null;
            PersonDiseaseBindingSource.DataSource = ObjectPD;
            prsDiseaseBindingSource.DataSource = ObjectPRS.PersonDiseases.ToList();
            gridControl3.RefreshDataSource();
        }
    }
}