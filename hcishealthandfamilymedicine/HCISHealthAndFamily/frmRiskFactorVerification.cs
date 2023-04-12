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

namespace HCISHealthAndFamily
{
    public partial class frmRiskFactorVerification : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lstQAfrm4;
        List<QAPlus> lstChilds;
        QAPlus ObjectQA;

        public frmRiskFactorVerification()
        {
            InitializeComponent();
            this.repositoryItemRadioGroup1.Columns = 3;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "دارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "ندارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "پر نشده")});
        }

        private void frmRiskFactorVerification_Load(object sender, EventArgs e)
        {
            if (lstQAfrm4 == null)
                lstQAfrm4 = new List<QAPlus>();

            if (lstChilds == null)
                lstChilds = new List<QAPlus>();

            if (ObjectQA == null)
                ObjectQA = new QAPlus();

            frm4QAPlusBindingSource.DataSource = lstQAfrm4;
            QuestionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == Guid.Parse("d9e71086-b0b6-48bf-8c9c-71017b855a8e")).ToList();
            QGBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == Guid.Parse("d9e71086-b0b6-48bf-8c9c-71017b855a8e")).ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 10);
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var Quests = QuestionnaireGroupBindingSource.Current as QuestionnaireGroup;
                if (Quests == null)
                    return;

                var lstQ = new List<Questionnaire>();

                Quests.QuestionnaireGroups.ToList().ForEach(x => lstQ.AddRange(x.Questionnaires.ToList()));

                if(lstQ.Any())
                {
                    foreach (var item in lstQ)
                    {
                        if (lstChilds.Any(x => x.PQuestionnaire != null && x.PQuestionnaire.ID == item.ID))
                            continue;
                        var qa = new QAPlus()
                        {
                            PQuestionnaire = item
                        };
                        lstChilds.Add(qa);
                    }
                }
                
                foreach (var item in lstChilds.Where(x => x.PQuestionnaire != null && x.PQuestionnaire.QuestionnaireGroup != null).ToList())
                {
                    if (item.PQuestionnaire.QuestionnaireGroup.Name.Contains("عضو یا ارگان آسیب دیده"))
                    {
                        item.SortName = "2. " + item.PQuestionnaire.QuestionnaireGroup.Name;
                    }
                    else if (item.PQuestionnaire.QuestionnaireGroup.Name.Contains("وجود ریسک فاکتور"))
                    {
                        item.SortName = "1. " + item.PQuestionnaire.QuestionnaireGroup.Name;
                    }
                }

                QAPlusBindingSource.DataSource = lstChilds.Where(x => lstQ.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol);
                gridView1.ExpandAllGroups();
                gridControl1.RefreshDataSource();
            }
            else
                return;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in lstChilds)
                {
                    if (item.ResultCHK != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationTime = DateTime.Now.ToString("HH:mm");
                        item.CreationUser = MainModule.UserID;

                        dc.QAPlus.InsertOnSubmit(item);
                    }
                }

                dc.QAPlus.InsertAllOnSubmit(lstQAfrm4);

                dc.SubmitChanges();
                QAPlusBindingSource.DataSource = null;
                QuestionnaireGroupBindingSource.DataSource = null;
                frm4QAPlusBindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            ObjectQA.GivenServiceM = gsm;
            var qg = lkpTitr.EditValue as QuestionnaireGroup;
            ObjectQA.Questionnaire = qg.Questionnaires.FirstOrDefault(c => c.Name == qg.Name);
            var doc = slkReference.EditValue as Department;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "ارجاع به: " + doc.Name;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "";

            if (ObjectQA.Questionnaire.QuestionnaireGroup != null)
                lstQAfrm4.Add(ObjectQA);
            else
            {
                MessageBox.Show("نوع تشخیص مشخص نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectQA = null;
            frm4QAPlusBindingSource.DataSource = lstQAfrm4;
            gridControl3.RefreshDataSource();
        }
    }
}