using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmHistory : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        bool checkup, binaei, shenawaei, rawanshenasi, rie, lab = false;

        private void btnAudioChart_Click(object sender, EventArgs e)
        {
            var dlg = new Dialogs.dlgAudChart();
            dlg.FromHistory = true;
            dlg.ShowDialog();
        }

        public frmHistory()
        {
            InitializeComponent();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(c => c.ID == MainModule.VST_Set.ID);

            MedicalHistoryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID && x.Questionnaire.IDGroup == Guid.Parse("45dff7dc-73e4-4698-89ae-56fd0f1cefe6")).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                var id = Guid.Parse("2f5a072b-dce6-41e9-b28e-507dabcc2a76");
                if (!checkup)
                {
                    CheckupQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                checkup = true;
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                var id = Guid.Parse("dd00e1be-fbae-4072-8dfa-d41a7fc367d7");
                if (!binaei)
                {
                    OptometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                binaei = true;
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 3)
            {
                var id = Guid.Parse("ac5fc5d3-470d-4075-99c8-e8472845a988");
                if (!shenawaei)
                {
                    AudiometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                shenawaei = true;
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 4)
            {
                var id = Guid.Parse("1bf99ecd-6cc2-4666-ad69-874f67f62b45");
                if (!rawanshenasi)
                {
                    PsychologyQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID && x.Questionnaire.IDGroup == id).OrderByDescending(c => c.CreationDate).ToList();
                }
                rawanshenasi = true;
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 5)
            {
                var id = Guid.Parse("2c160974-70fd-4cc4-92aa-fc76a1f6dde1");
                if (!rie)
                {
                    SpirometryQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                rie = true;
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 6)
            {
                var id = Guid.Parse("26ce2ea1-61a4-4a58-b68b-e68d156293ef");
                if (!lab)
                {
                    LabQApBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID &&
                    ((x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.ID == id) ||
                    (x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.Questionnaire.QuestionnaireGroup.QuestionnaireGroup1.QuestionnaireGroup1.ID == id))).OrderByDescending(c => c.CreationDate).ToList();
                }
                lab = true;
            }
        }
    }
}