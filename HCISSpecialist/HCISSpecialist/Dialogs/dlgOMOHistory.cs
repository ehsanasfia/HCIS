using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;



namespace HCISSpecialist.Dialogs
{
    public partial class dlgOMOHistory : DevExpress.XtraEditors.XtraForm
    {
        OMODataContext dc = new OMODataContext();
        bool checkup, binaei, shenawaei, rawanshenasi, rie, lab = false;
        public PersonOMO Per { get; set; }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAudioChart_Click(object sender, EventArgs e)
        {
            var vst = searchLookUpEdit1.EditValue as VisitOMO;
            if (vst == null)
                return;
            var dlg = new Dialogs.dlgAudChart();
            dlg.vst = vst;
            dlg.FromHistory = true;
            dlg.ShowDialog();
        }

        public dlgOMOHistory()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var vst = searchLookUpEdit1.EditValue as VisitOMO;
            if (vst == null)
                return;

            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                MedicalHistoryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID && x.Questionnaire.IDGroup == Guid.Parse("45dff7dc-73e4-4698-89ae-56fd0f1cefe6")).OrderByDescending(c => c.CreationDate).ToList();
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                var id = Guid.Parse("2f5a072b-dce6-41e9-b28e-507dabcc2a76");
                if (!checkup)
                {
                    CheckupQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                checkup = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                var id = Guid.Parse("dd00e1be-fbae-4072-8dfa-d41a7fc367d7");
                if (!binaei)
                {
                    OptometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                binaei = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
            {
                var id = Guid.Parse("ac5fc5d3-470d-4075-99c8-e8472845a988");
                if (!shenawaei)
                {
                    AudiometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                shenawaei = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 4)
            {
                var id = Guid.Parse("1bf99ecd-6cc2-4666-ad69-874f67f62b45");
                if (!rawanshenasi)
                {
                    PsychologyQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID && x.Questionnaire.IDGroup == id).OrderByDescending(c => c.CreationDate).ToList();
                }
                rawanshenasi = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 5)
            {
                var id = Guid.Parse("2c160974-70fd-4cc4-92aa-fc76a1f6dde1");
                if (!rie)
                {
                    SpirometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                rie = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 6)
            {
                var id = Guid.Parse("26ce2ea1-61a4-4a58-b68b-e68d156293ef");
                if (!lab)
                {
                    LabQApBindingSource.DataSource = dc.QAPlus.Where(x => x.VisitOMO != null && x.VisitOMO.PersonID == vst.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                lab = true;
            }

        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            visitOMOBindingSource.DataSource = dc.VisitOMOs.Where(c => c.PersonID == Per.ID);

        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            GetData();
        }
    }
}