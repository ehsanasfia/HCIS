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
    public partial class frmFamilyPlanning : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> Parents = new List<QAPlus>();
        List<QAPlus> AllChild = new List<QAPlus>();
        List<QAPlus> FilterChild = new List<QAPlus>();
        List<RepositoryItem> lstItems;
        RepositoryItemTextEdit DisabledTextEdit;

        public Person SeletedPerson { get; private set; }

        public frmFamilyPlanning()
        {
            InitializeComponent();
        }

       
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
                lstItems = new List<RepositoryItem>();
                gridControl1.RepositoryItems.Clear();
            if (e.Clicks >= 2)
            {
                var cur = questionnaireGroupBindingSource1.Current as QuestionnaireGroup;
                if (cur == null)
                    return;
                lstItems = new List<RepositoryItem>();
                gridControl1.RepositoryItems.Clear();
                foreach (var Questionnaire in cur.Questionnaires)
                {
                    if (!AllChild.Any(c => c.PQuestionnaire.ID == Questionnaire.ID))
                    {
                        var qa = new QAPlus()
                        {
                            PQuestionnaire = Questionnaire,
                        };
                        AllChild.Add(qa);
                    }
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
                    FilterChild.Clear();
                    FilterChild = AllChild.Where(x => x.PQuestionnaire.IDGroup == cur.ID).ToList();
                    qABindingSource1.DataSource = FilterChild;
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void frmFamilyPlanning_Load(object sender, EventArgs e)
        {
            SeletedPerson= dc.Persons.FirstOrDefault(c => c.ID == MainModule.GSM_Set.Person.ID);
            preventingDeviceReciveBindingSource1.DataSource = dc.PreventingDeviceRecives.Where(c => c.Person == SeletedPerson);
            getdata();
            preventingDeviceReciveBindingSource.DataSource = new PreventingDeviceRecive();
            DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };
        }

        private void getdata()
        {
            AllChild.Clear();
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(c => c.QuestionnaireGroup1.Name == "وسایل پیشگیری");
            preventingStartBindingSource.DataSource = new PreventingStartAndEnd();
            preventingStartAndEndListBindingSource1.DataSource = dc.PreventingStartAndEnds.Where(c => c.Person == MainModule.GSM_Set.Person).ToList();
            iCD10BindingSource.DataSource = MainModule.icd.ToList();
        }

        private void btnStartOk_Click(object sender, EventArgs e)
        {
            preventingStartBindingSource.EndEdit();
            var NewPrevent = preventingStartBindingSource.Current as PreventingStartAndEnd;
          NewPrevent.Person = dc.Persons.FirstOrDefault(c => c.ID == MainModule.GSM_Set.Person.ID);
            NewPrevent.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewPrevent.CreationTime = DateTime.Now.ToString("HH:mm");
            NewPrevent.CreatorUser = MainModule.UserID;
            dc.PreventingStartAndEnds.InsertOnSubmit(NewPrevent);

            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in AllChild)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.PreventingStartAndEnd = NewPrevent;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        if (item.ID == 0) dc.QAPlus.InsertOnSubmit(item);
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
            preventingDeviceReciveBindingSource1.DataSource = dc.PreventingDeviceRecives.Where(c => c.Person == SeletedPerson);
            AllChild.Clear();
            preventingStartBindingSource.Clear();
            preventingStartBindingSource.AddNew();
       //     preventingStartBindingSource.DataSource = new PreventingDeviceRecive();
            //   DialogResult = DialogResult.OK;
        }

        private void gridControl5_DoubleClick(object sender, EventArgs e)
        {
            var PreventEnd = preventingStartAndEndListBindingSource1.Current as PreventingStartAndEnd;
            preventingEndBindingSourc2.DataSource = PreventEnd;
        }

        private void btnEndOK_Click(object sender, EventArgs e)
        {
            preventingEndBindingSourc2.EndEdit();
            dc.SubmitChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dc.Dispose();
            dc = new HCISDataClassesDataContext();
            getdata();
        }

        private void btnCnacleStart_Click(object sender, EventArgs e)
        {
            dc.Dispose();
            dc = new HCISDataClassesDataContext();
            getdata();
        }

        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView2.GetRow(e.RowHandle) as QAPlus;
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

        private void cmbPreventionDevice_EditValueChanged(object sender, EventArgs e)
        {
            var Quest =cmbPreventionDevice.EditValue as QuestionnaireGroup;
            if (Quest == null) return;
            questionnaireGroupBindingSource1.DataSource = dc.QuestionnaireGroups.Where(c => c.IDParent == Quest.ID).ToList();
        }

        private void btnDeviseOk_Click(object sender, EventArgs e)
        {
            preventingDeviceReciveBindingSource.EndEdit();
            var NewDevis = preventingDeviceReciveBindingSource.Current as PreventingDeviceRecive;
            NewDevis.Person = SeletedPerson;
            NewDevis.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewDevis.CreationTime = DateTime.Now.ToString("HH:mm");
            NewDevis.CreatorUser = MainModule.UserID;
            dc.PreventingDeviceRecives.InsertOnSubmit(NewDevis);
            dc.SubmitChanges();
            preventingDeviceReciveBindingSource1.DataSource = dc.PreventingDeviceRecives.Where(c => c.Person == SeletedPerson);
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
           var cur= preventingStartAndEndListBindingSource1.Current as PreventingStartAndEnd;
            if(cur!=null)
            preventingEndBindingSourc2.DataSource = cur;
        }
    }
}