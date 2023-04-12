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
    public partial class frmChildBirthConditions : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lst = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };

        public frmChildBirthConditions()
        {
            InitializeComponent();
        }

        private void frmChildBirthConditions_Load(object sender, EventArgs e)
        {
            var gp = dc.QuestionnaireGroups.FirstOrDefault(x => x.Name == "وضعیت تولد کودک");
            if (gp == null)
                return;

            var Quests = gp.Questionnaires.OrderBy(x => x.SortCol).ToList();
            if (Quests == null)
            {
                qAPlusBindingSource.DataSource = null;
            }
            else
            {
                foreach (var item in Quests)
                {
                    if (lst.Any(x => x.PQuestionnaire != null && x.PQuestionnaire.ID == item.ID))
                        continue;

                    var qa = new QAPlus()
                    {
                        PQuestionnaire = item,
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

            qAPlusBindingSource.DataSource = lst.Where(x => Quests.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl1.RefreshDataSource();


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
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationTime = DateTime.Now.ToString("HH:mm");
                        item.CreationUser = MainModule.UserID;
                        dc.QAPlus.InsertOnSubmit(item);
                    }
                }

                
                dc.SubmitChanges();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}