using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OMOApp.Data;

namespace OMOApp.Forms
{
    public partial class frmEditQA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmEditQA()
        {
            InitializeComponent();
        }
        Data.OMOClassesDataContext dc = new Data.OMOClassesDataContext();
        private void frmEditQA_Load(object sender, EventArgs e)
        {
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList(); ;
            //questionnairesBindingSource.DataSource = dc.Questionnaires;
        }

        private void questionnaireGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var item = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (item == null)
            {
                questionnaireBindingSource.DataSource = null;
            }
            else
            {
                questionnaireBindingSource.DataSource = item.Questionnaires.ToList();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var qg = questionnaireGroupBindingSource.Current as Data.QuestionnaireGroup;
            if (qg == null)
            {
                MessageBox.Show("ابتدا یک گروه را انتخاب کنید");
                return;
            }
            var dlg = new Dialogs.dialogAddGroup();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newRecord = new QuestionnaireGroup();
            newRecord.IDParent = qg.IDParent;
            newRecord.Name = dlg.Title;
            dc.QuestionnaireGroups.InsertOnSubmit(newRecord);
            dc.SubmitChanges();
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList();
            treeList1.RefreshDataSource();
            treeList1.FocusedNode = treeList1.FindNodeByKeyID(newRecord.ID);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            var qg = questionnaireGroupBindingSource.Current as Data.QuestionnaireGroup;
            if (qg == null)
            {
                MessageBox.Show("ابتدا یک گروه را انتخاب کنید");
                return;
            }
            var dlg = new Dialogs.dialogAddGroup();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newRecord = new QuestionnaireGroup();
            newRecord.QuestionnaireGroup1 = qg;
            newRecord.Name = dlg.Title;
            dc.QuestionnaireGroups.InsertOnSubmit(newRecord);
            dc.SubmitChanges();
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList();
            treeList1.RefreshDataSource();
            treeList1.FocusedNode = treeList1.FindNodeByKeyID(newRecord.ID);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            var qg = questionnaireGroupBindingSource.Current as Data.QuestionnaireGroup;
            if (qg == null)
            {
                MessageBox.Show("ابتدا یک گروه را انتخاب کنید");
                return;
            }
            var dlg = new Dialogs.dialogAddGroup() { Title = qg.Name };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            qg.Name = dlg.Title;
            dc.SubmitChanges();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            var qg = questionnaireGroupBindingSource.Current as Data.QuestionnaireGroup;
            if (qg == null)
            {
                MessageBox.Show("ابتدا یک گروه را انتخاب کنید");
                return;
            }
            var question = questionnaireBindingSource.AddNew() as Questionnaire;
            question.QuestionnaireGroup = qg;
            question.YesNo = false;
            dc.SubmitChanges();
        }

        private void questionnaireBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            questionnaireBindingSource.EndEdit();
            dc.SubmitChanges();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (questionnaireBindingSource.Current == null)
            {
                MessageBox.Show("ابتدا سوال را انتخاب نمایید");
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "حذف سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            {
                return;
            }
            var item = questionnaireBindingSource.Current as Questionnaire;
            questionnaireBindingSource.RemoveCurrent();
            questionnaireBindingSource.EndEdit();
            dc.Questionnaires.DeleteOnSubmit(item);
            dc.SubmitChanges();
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}