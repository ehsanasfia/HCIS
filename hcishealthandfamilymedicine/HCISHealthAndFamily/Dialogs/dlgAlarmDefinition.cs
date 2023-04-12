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
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily.Dialogs
{
    public partial class dlgAlarmDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Alarm ObjectALM;
        List<QAPlus> lst = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };
        List<Service> lstService;
        List<AlarmDetail> lstALDQ = new List<AlarmDetail>();
        List<AlarmDetail> lstALDS = new List<AlarmDetail>();

        public dlgAlarmDefinition()
        {
            InitializeComponent();
        }

        private void dlgAlarmDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectALM == null)
                ObjectALM = new Alarm();

            rdgChoose_SelectedIndexChanged(null, null);
            AlarmBindingSource.DataSource = ObjectALM;
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
                        gridControl2.RepositoryItems.Add(a);
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
                        gridControl2.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "MemoExEdit")
                    {
                        var a = new RepositoryItemMemoExEdit();
                        a.Tag = item.ID;
                        gridControl2.RepositoryItems.Add(a);
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
                        gridControl2.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                }
            }
            qAPlusBindingSource.DataSource = lst.Where(x => Quests.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl2.RefreshDataSource();
        }

        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView2.GetRow(e.RowHandle) as QAPlus;
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

        private void rdgChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgChoose.SelectedIndex == 0)
            {
                gridControl1.Enabled = false;
                lkpServiceCategory.Enabled = false;
                gridControl3.Enabled = false;
                gridControl2.Enabled = true;
                treeList1.Enabled = true;
                questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList();
                treeList1.CollapseAll();
                serviceBindingSource.DataSource = null;
                serviceCategoryBindingSource.DataSource = null;
                lstALDS = new List<AlarmDetail>();
            }
            else
            {
                gridControl1.Enabled = true;
                lkpServiceCategory.Enabled = true;
                gridControl3.Enabled = true;
                gridControl2.Enabled = false;
                treeList1.Enabled = false;
                serviceCategoryBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 1 || x.ID == 5).ToList();
                questionnaireGroupBindingSource.DataSource = null;
                qAPlusBindingSource.DataSource = null;
                lstALDQ = new List<AlarmDetail>();
                lst = new List<QAPlus>();
            }
        }

        private void lkpServiceCategory_EditValueChanged(object sender, EventArgs e)
        {
            var val = lkpServiceCategory.EditValue as ServiceCategory;
            if (val == null)
                return;

            if (val.ID == 1)
            {
                colFResult.Visible = true;
                colTResult.Visible = true;
            }
            else
            {
                colFResult.Visible = false;
                colTResult.Visible = false;
            }

            lstALDS = new List<AlarmDetail>();
            alarmDetailBindingSource.DataSource = lstALDS;
            lstService = dc.Services.Where(x => x.CategoryID == val.ID).ToList();
            serviceBindingSource.DataSource = lstService;
            gridControl1.RefreshDataSource();
        }

        private void dlgAlarmDefinition_Shown(object sender, EventArgs e)
        {
            treeList1.CollapseAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectALM.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectALM.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectALM.CreatorUserID = MainModule.UserID;
            ObjectALM.Disable = false;

            foreach (var item in lst)
            {
                if (item.ResultCHK != true && string.IsNullOrWhiteSpace(item.Description))
                    continue;

                var ALD = new AlarmDetail();
                if (item.ResultCHK == true)
                {
                    ALD.ResultCHK = item.ResultCHK;
                }
                else if (!string.IsNullOrWhiteSpace(item.Description))
                {
                    ALD.Result = item.Description;
                }

                ALD.Questionnaire = item.PQuestionnaire;
                ALD.Alarm = ObjectALM;
                lstALDQ.Add(ALD);
            }

            foreach (var item in lstALDS)
            {
                item.Service = item.PService;
                item.Alarm = ObjectALM;
            }

            if (ObjectALM.ID == 0)
                dc.Alarms.InsertOnSubmit(ObjectALM);

            if (lstALDQ.Any())
                dc.AlarmDetails.InsertAllOnSubmit(lstALDQ);
            if (lstALDS.Any())
                dc.AlarmDetails.InsertAllOnSubmit(lstALDS);

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = serviceBindingSource.Current as Service;
            if (cur == null)
                return;

            var ALD = new AlarmDetail();
            ALD.PService = cur;
            lstALDS.Add(ALD);
            alarmDetailBindingSource.DataSource = lstALDS;
            gridControl3.RefreshDataSource();
        }
    }
}