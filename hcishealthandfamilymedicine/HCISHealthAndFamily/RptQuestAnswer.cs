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
using DevExpress.XtraEditors.Repository;

namespace HCISHealthAndFamily
{
    public partial class RptQuestAnswer : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lst = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };
        List<Vw_QuestAnswer> lstQA = new List<Vw_QuestAnswer>();

        public RptQuestAnswer()
        {
            InitializeComponent();
            this.repositoryItemRadioGroup1.Columns = 3;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "دارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "ندارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "پر نشده")});
        }

        private void RptQuestAnswer_Load(object sender, EventArgs e)
        {
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;

            var Quests = cur.Questionnaires.ToList();
            if (Quests == null)
            {
                qAPlusBindingSource.DataSource = null;
            }
            else
            {
                foreach (var item in Quests)
                {
                    if (lst.Any(x => x.Questionnaire != null && x.Questionnaire.ID == item.ID))
                        continue;

                    var qa = new QAPlus()
                    {
                        Questionnaire = item,
                    };

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
                }
            }
            qAPlusBindingSource.DataSource = lst.Where(x => Quests.Contains(x.Questionnaire)).OrderBy(c => c.Questionnaire.SortCol);
            gridControl1.RefreshDataSource();
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView1.GetRow(e.RowHandle) as QAPlus;
            if (qap == null)
                return;
            if (e.Column == colEditor)
            {
                if (qap.Questionnaire.YesNo)
                    e.RepositoryItem = DisabledTextEdit;
                else
                    e.RepositoryItem = lstItems.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.Questionnaire.ID));
            }
            else if (e.Column == colResultCHK)
            {
                if (!qap.Questionnaire.YesNo)
                {
                    e.RepositoryItem = DisabledTextEdit;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstQA.Clear();
            var vwList = dc.Vw_QuestAnswers.ToList();
            foreach (var item in gridView1.GetSelectedRows())
            {
                var row = gridView1.GetRow(item) as QAPlus;
                //if (!lstQA.Any())
                lstQA.AddRange(vwList.Where(c => c.Q == row.Questionnaire.Name && (c.ResultCHK == row.ResultCHK || c.Description == row.Description)).ToList());
            }

            vwQuestAnswerBindingSource.DataSource = lstQA;
        }

        private void RptQuestAnswer_Shown(object sender, EventArgs e)
        {
            treeList1.CollapseAll();
        }
    }
}