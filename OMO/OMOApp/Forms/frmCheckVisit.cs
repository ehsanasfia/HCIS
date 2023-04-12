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
using DevExpress.XtraEditors.Repository;

namespace OMOApp
{
    public partial class frmCheckVisit : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<QAPlus> lst = new List<QAPlus>();
        List<QAPlus> lstDefault = new List<QAPlus>();

        List<QAPlus> lstAnswerQA = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };

        public frmCheckVisit()
        {
            InitializeComponent();
        }

        private void frmLabTest_Load(object sender, EventArgs e)
        {
            //2f5a072b-dce6-41e9-b28e-507dabcc2a76
            //b0a323ed-2cd1-411b-9731-bcf40c55edce
            var id = Guid.Parse("2f5a072b-dce6-41e9-b28e-507dabcc2a76");
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == id || (x.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.IDParent == id) ||
            (x.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id) ||
            (x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id)).OrderBy(c => c.IDint).ToList();
            lstAnswerQA.AddRange(dc.QAPlus.Where(c => c.VisitID == MainModule.VST_Set.ID).ToList());
            var lst = dc.QAPlus.Where(x => (x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID) && (x.Questionnaire.QuestionnaireGroup.IDParent == id || (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.IDParent == id) ||
              (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id) ||
              (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id))).OrderByDescending(c => c.CreationDate).ToList();
            foreach (var item in lst)
                item.QusetionnairGroup = dc.Func_QuestionnaireTree(item.Questionnaire.IDGroup);
            HistoryqAPlusBindingSource.DataSource = lst;

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            //qAPlusBindingSource.DataSource = lst;

            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;

            var AnswerQA = lstAnswerQA.Where(x => x.Questionnaire.QuestionnaireGroup == cur).ToList();

            var QuestsAll = cur.Questionnaires/*.Where(c => c.TypeID != 1 )*/.ToList();
            var Quests = QuestsAll.Where(c => !AnswerQA.Any(x => x.Questionnaire == c)).ToList();
            #region
            if (Quests == null)
            {
                //lst = null;
                qAPlusBindingSource.DataSource = null;
            }
            else
            {
                //lstItems = new List<RepositoryItem>();
                //gridControl1.RepositoryItems.Clear();
                foreach (var item in Quests)
                {
                    if (lst.Any(x => x.PQuestionnaire != null && x.PQuestionnaire.ID == item.ID))
                        continue;

                    var qa = new QAPlus()
                    {
                        PQuestionnaire = item,
                    };

                    if (item.TypeID == 1 && AnswerQA.Count == 0)
                        qa.ResultCHK = true;
                    else if (item.TypeID == 1 && AnswerQA.Count != 0)
                        qa.ResultCHK = false;
                    lst.Add(qa);

                    if (item.Editor == "RadioGroup")
                    {
                        var a = new RepositoryItemRadioGroup();
                        var answers = item.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                        }
                        a.Tag = item.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
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
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "MemoExEdit")
                    {
                        var a = new RepositoryItemMemoExEdit();
                        a.Tag = item.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
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
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "Date")
                    {
                        var a = new RepositoryItemButtonEdit();
                        a.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
                        a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptometry1));
                        DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                        a.Buttons.Clear();
                        a.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "امروز", null, null, true) });
                        a.ButtonClick += Date_ButtonClick;
                        a.Tag = item.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "Time")
                    {
                        var a = new RepositoryItemTextEdit();
                        a.Mask.EditMask = "90:00";
                        a.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                        a.Tag = item.ID;
                        gridControl1.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    //if(item.YesNo == true)
                    //{
                    //    var a = new RepositoryItemMemoExEdit();
                    //    a.Tag = item.ID;
                    //    gridControl1.RepositoryItems.Add(a);
                    //    lstItems.Add(a);
                    //}
                }
            }
            #endregion
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptometry1));
                        DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                        a.Buttons.Clear();
                        a.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "امروز", null, null, true) });
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

            qAPlusBindingSource.DataSource = lst.Where(x => QuestsAll.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl1.RefreshDataSource();
            var Historylst = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID && x.Questionnaire.IDGroup == cur.ID).OrderByDescending(c => c.CreationDate).ToList();

            foreach (var item in Historylst)
                item.QusetionnairGroup = dc.Func_QuestionnaireTree(item.Questionnaire.IDGroup);

            HistoryqAPlusBindingSource.DataSource = Historylst;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            //    return;

            try
            {
                var gsm = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
                if (gsm == null)
                    return;
                Add_BedoneNeshaneh();
                foreach (var item in lst)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        if (item.Questionnaire == null)
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.Visit = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            lstDefault.Remove(lstDefault.FirstOrDefault(c => c.PQuestionnaire.QuestionnaireGroup == item.PQuestionnaire.QuestionnaireGroup));
                            if (item.PQuestionnaire.QuestionnaireGroup.IDParent == null)
                                item.HasTariffParent = item.PQuestionnaire.QuestionnaireGroup.ID;
                            else if (item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.IDParent == null)
                                item.HasTariffParent = item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID;
                            else if (item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == null)
                                item.HasTariffParent = item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID;
                            else if (item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == null)
                                item.HasTariffParent = item.PQuestionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.ID;

                            if (item.ID == 0) dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                }
                foreach (var item in lstAnswerQA)
                {
                    lstDefault.Remove(lstDefault.FirstOrDefault(c => c.PQuestionnaire.QuestionnaireGroup == item.Questionnaire.QuestionnaireGroup));
                }
                if (lstDefault.Count > 0)
                    foreach (var item in lstDefault)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.Visit = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            if (item.ID == 0) dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                gridControl1.RefreshDataSource();
                var visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
                if (visit.ToDoList.CheckUpUserID == null)
                {
                    visit.ToDoList.CheckUpDate = MainModule.GetPersianDate(DateTime.Now);
                    visit.ToDoList.CheckUpUserID = MainModule.UserID;
                    visit.ToDoList.CheckUpTime = DateTime.Now.ToString("HH:mm");
                }
                visit.ToDoList.Checkup = true;
                dc.SubmitChanges();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void Add_BedoneNeshaneh()
        {
            foreach (var item in dc.Questionnaires.Where(c => c.TypeID == 1))
            {

                lstDefault.Add(new QAPlus() { PQuestionnaire = item, ResultCHK = true });
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
                {// e.RepositoryItem = DisabledTextEdit;
                }
                else
                    e.RepositoryItem = lstItems.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.PQuestionnaire.ID));
            }
            else if (e.Column == colResultCHK)
            {
                if (!qap.PQuestionnaire.YesNo)
                {
                    // e.RepositoryItem = DisabledTextEdit;
                }
            }
        }

        private void frmPregnancy1_Shown(object sender, EventArgs e)
        {
            treeList1.CollapseAll();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //var cur = gridView1.GetRow(e.RowHandle) as QAPlus;
            //if (cur == null)
            //    return;
            //if (cur.PQuestionnaire.TypeID == 1 && cur.ResultCHK == true)
            //{
            //    lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID != 1).ToList().ForEach(x => x.ResultCHK = false);
            //    lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID != 1).ToList().ForEach(x => x.Description = null);
            //    qAPlusBindingSource.DataSource = lst.OrderBy(c => c.PQuestionnaire.SortCol);
            //}
            //if (cur.PQuestionnaire.TypeID != 1 && cur.ResultCHK == true)
            //{
            //    lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID == 1).ToList().ForEach(x => x.ResultCHK = false);
            //    lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID == 1).ToList().ForEach(x => x.Description = null);
            //    qAPlusBindingSource.DataSource = lst.OrderBy(c => c.PQuestionnaire.SortCol);

            //}
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var cur = gridView1.GetRow(e.RowHandle) as QAPlus;
            if (cur == null)
                return;
            if (cur.PQuestionnaire.TypeID == 1 && e.Value as bool? != null && e.Value as bool? == true)
            {

                lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID != 1).ToList().ForEach(x => x.ResultCHK = false);
                lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID != 1).ToList().ForEach(x => x.Description = null);
                //qAPlusBindingSource.DataSource = lst.OrderBy(c => c.PQuestionnaire.SortCol);
                cur.ResultCHK = e.Value as bool?;
            }
            if (cur.PQuestionnaire.TypeID != 1 && e.Value as bool? != null && e.Value as bool? == true)
            {
                lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID == 1).ToList().ForEach(x => x.ResultCHK = false);
                lst.Where(c => c.PQuestionnaire.IDGroup == cur.PQuestionnaire.IDGroup && c.PQuestionnaire.TypeID == 1).ToList().ForEach(x => x.Description = null);
                //qAPlusBindingSource.DataSource = lst.OrderBy(c => c.PQuestionnaire.SortCol);
                cur.ResultCHK = e.Value as bool?;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;

            var dlg = new Dialogs.dlgSeperateHistory() { dc = dc, curID = cur.ID };
            dlg.ShowDialog();
        }

        private void btnOldHistory_Click(object sender, EventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);

            var dlg = new Dialogs.dlgOldHistory();
            dlg.SelectedPrs = MainModule.VST_Set.Person;
            dlg.Checkup = true;
            dlg.ShowDialog();
        }

        private void Date_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((ButtonEdit)sender).Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void frmCheckVisit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lst.Any())
            {
                var result = MessageBox.Show("آیا مایل به ذخیره ی تغییرات هستید؟", "توجه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (result == DialogResult.Yes)
                {
                    btnOk_Click(null, null);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}