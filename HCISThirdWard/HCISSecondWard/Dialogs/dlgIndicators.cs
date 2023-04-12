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
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgIndicators : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<QAPlus> lst = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };
        private List<QAPlus> lstAnswerQA;

        public dlgIndicators()
        {
            InitializeComponent();
            this.repositoryItemRadioGroup1.Columns = 3;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "دارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "ندارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "پر نشده")});
        }

        private void dlgIndicators_Load(object sender, EventArgs e)
        {
            MainModule.MyDepartment = dc.Departments.FirstOrDefault(x => x.ID == MainModule.MyDepartment.ID);
            var mapp = dc.QuestGroupDepartmentMappings.FirstOrDefault(x => x.DepartmentID == MainModule.MyDepartment.ID);
            var id = Guid.Parse("f919fcbb-c3f2-4600-a0bf-28e6cf88083b");
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == id && x.ID == mapp.QuestionnaireGroupID).ToList();
            lstAnswerQA = dc.QAPlus.Where(c => c.IDGivenServiceM == MainModule.GSM_Set.ID).ToList();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            lstItems = new List<RepositoryItem>();
            gridControl1.RepositoryItems.Clear();

            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;
            lstItems = new List<RepositoryItem>();
            gridControl1.RepositoryItems.Clear();

            var AnswerQA = lstAnswerQA.Where(x => x.Questionnaire.QuestionnaireGroup == cur);
            var QuestsAll = cur.Questionnaires.ToList();
            var Quests = QuestsAll.Where(c => !AnswerQA.Any(x => x.Questionnaire == c)).ToList();

            foreach (var Questionnaire in Quests)
            {
                if (lst.Any(x => x.PQuestionnaire != null && x.PQuestionnaire.ID == Questionnaire.ID))
                    continue;

                var qa = new QAPlus()
                {
                    PQuestionnaire = Questionnaire,
                };

                lst.Add(qa);

                if (Questionnaire.Editor == "RadioGroup")
                {
                    var a = new RepositoryItemRadioGroup();
                    var answers = Questionnaire.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                    }
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }
                else if (Questionnaire.Editor == "ComboBox")
                {
                    var a = new RepositoryItemComboBox();
                    a.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    var answers = Questionnaire.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }
                else if (Questionnaire.Editor == "MemoExEdit")
                {
                    var a = new RepositoryItemMemoExEdit();
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }
                else if (Questionnaire.Editor == "CheckedComboBoxEdit")
                {
                    var a = new RepositoryItemCheckedComboBoxEdit();
                    var answers = Questionnaire.Answers.Split(',', '،');
                    foreach (var ans in answers)
                    {
                        a.Items.Add(ans);
                    }
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }
                else if (Questionnaire.Editor == "Date")
                {

                    var a = new RepositoryItemButtonEdit();
                    a.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
                    a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgIndicators));
                    DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                    a.Buttons.Clear();
                    a.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "امروز", null, null, true) });
                    a.ButtonClick += Date_ButtonClick;
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }
                else if (Questionnaire.Editor == "Time")
                {
                    var a = new RepositoryItemTextEdit();
                    a.Mask.EditMask = "90:00";
                    a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    a.Tag = Questionnaire.ID;
                    gridControl1.RepositoryItems.Add(a);
                    lstItems.Add(a);
                }

            }

            if (AnswerQA != null)
            {

                //lstItems = new List<RepositoryItem>();
                //gridControl1.RepositoryItems.Clear();
                foreach (var item in AnswerQA)
                {
                    if (lst.Any(x => x.Questionnaire != null && x.Questionnaire.ID == item.Questionnaire.ID))
                        continue;

                    item.PQuestionnaire = item.Questionnaire;
                    lst.Add(item);

                    if (item.Questionnaire.Editor == "RadioGroup")
                    {
                        var a = new RepositoryItemRadioGroup();
                        var answers = item.Questionnaire.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                        }
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Questionnaire.Editor == "ComboBox")
                    {
                        var a = new RepositoryItemComboBox();
                        a.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        var answers = item.Questionnaire.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(ans);
                        }
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Questionnaire.Editor == "MemoExEdit")
                    {
                        var a = new RepositoryItemMemoExEdit();
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Questionnaire.Editor == "CheckedComboBoxEdit")
                    {
                        var a = new RepositoryItemCheckedComboBoxEdit();
                        var answers = item.Questionnaire.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(ans);
                        }
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Questionnaire.Editor == "Date")
                    {
                        var a = new RepositoryItemButtonEdit();
                        a.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
                        a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgIndicators));
                        DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                        a.Buttons.Clear();
                        a.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "امروز", null, null, true) });
                        a.ButtonClick += Date_ButtonClick;
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Questionnaire.Editor == "Time")
                    {
                        var a = new RepositoryItemTextEdit();
                        a.Mask.EditMask = "90:00";
                        a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                        a.Tag = item.PQuestionnaire.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                }
            }
            
            qAPlusBindingSource.DataSource = lst.Where(x => QuestsAll.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol).ToList();
            gridControl1.RefreshDataSource();
        }

        private void Date_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ((ButtonEdit)sender).Text = MainModule.GetPersianDate(DateTime.Now);
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

                foreach (var item in lst)
                {
                    if (item.ResultCHK != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.Date = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationTime = DateTime.Now.ToString("HH:mm");
                        item.CreationUser = MainModule.UserID;
                        if (item.ID == 0)
                            dc.QAPlus.InsertOnSubmit(item);
                    }
                }

                gridControl1.RefreshDataSource();
                dc.SubmitChanges();
                MessageBox.Show("ثبت با موفقیت انجام شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            QAPlus qap = gridView1.GetRow(e.RowHandle) as QAPlus;
            if (qap == null)
                return;
            if (e.Column == colEditor)
            {
                if (qap.PQuestionnaire.YesNo)
                    e.RepositoryItem = DisabledTextEdit;
                else
                    e.RepositoryItem = lstItems.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.PQuestionnaire.ID));
            }
            else if (e.Column == colResultCHK)
            {
                if (!qap.PQuestionnaire.YesNo)
                {
                    e.RepositoryItem = DisabledTextEdit;
                }
            }
        }

        private void frmPregnancy1_Shown(object sender, EventArgs e)
        {
            treeList1.CollapseAll();
        }
    }
}