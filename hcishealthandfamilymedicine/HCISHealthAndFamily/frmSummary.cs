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
using HCISHealthAndFamily.Dialogs;

namespace HCISHealthAndFamily
{
    public partial class frmSummary : DevExpress.XtraEditors.XtraForm
    {
        public frmSummary()
        {
            InitializeComponent();

        }

        public Person SelectedPerson { set; get; }
        public HCISDataClassesDataContext dc;
        public String PetientType = "";

        private void frmSummary_Load(object sender, EventArgs e)
        {
            if (PetientType == "zanan")
            {
                layoutControlGroup6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            dc = new HCISDataClassesDataContext();
            SelectedPerson = dc.Persons.FirstOrDefault(c => c.ID == MainModule.GSM_Set.Person.ID);
            getData();
        }

        private void getData(string GridName)//Fill Spacific Gird
        {
            switch (GridName)
            {
                case "Drug":
                    {
                        spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(SelectedPerson.NationalCode).ToList();
                        break;
                    }
                case "ParaClinic":
                    {
                        paraClinicServiceHistoryBindingSource.DataSource = dc.ParaClinicServiceHistories.Where(c => c.Person == SelectedPerson).ToList();
                        break;
                    }
                case "Surgery":
                    {
                        surgeyHistoryBindingSource.DataSource = dc.SurgeyHistories.Where(c => c.Person == SelectedPerson).ToList();
                        break;
                    }
                case "Vaccination":
                    {
                        drugHistoryBindingSource.DataSource = dc.DrugHistories.Where(c => c.Person == SelectedPerson && c.Service.CategoryID != 4).ToList(); break;
                    }
                case "Visit":
                    {
                        spuVisitsHistoryForBehdashtResultBindingSource.DataSource = dc.Spu_VisitsHistoryForBehdasht(SelectedPerson.NationalCode).OrderByDescending(c => c.Date).ToList();
                        break;
                    }
                case "Test":
                    {
                        testHistoryBindingSource.DataSource = dc.TestHistories.Where(c => c.Person == SelectedPerson).ToList();
                        break;
                    }
                case "Disease":
                    {
                        personDiseaseBindingSource.DataSource = dc.PersonDiseases.Where(c => c.Person == SelectedPerson).ToList();
                        break;
                    }

                case "Risk":
                    {
                        var idRisk = Guid.Parse("ffc14139-e3c4-450b-80dd-b7ae98c94101");
                        RiskFactorQAPlusBindingSource.DataSource = dc.QAPlus.Where(c => c.GivenServiceM != null && c.GivenServiceM.Person == SelectedPerson && (c.Questionnaire != null && c.Questionnaire.IDGroup == idRisk) && c.ResultCHK == true).OrderByDescending(c => c.CreationDate).ToList();
                        break;
                    }
                case "Dentist":
                    {
                        spuDentistHistoryResultBindingSource.DataSource = dc.Spu_DentistHistory(SelectedPerson.NationalCode).ToList();
                        break;
                    }
                case "Nutrition":
                    {
                        nutritionHistoryBindingSource.DataSource = dc.NutritionHistories.Where(x => x.Person == SelectedPerson).ToList();
                        break;
                    }
                case "MentalHealth":
                    {
                        mentalHealthHistoryBindingSource.DataSource = dc.MentalHealthHistories.Where(x => x.Person == SelectedPerson).ToList();
                        break;
                    }
                case "Midwifery":
                    {
                        var id = Guid.Parse("569ddb75-00a6-4a46-89ad-36ab4cf73801");
                        questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == id ||
                        (x.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.IDParent == id) ||
                        (x.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id) ||
                        (x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id)).ToList();
                        break;
                    }
                default:
                    { break; }
            }
        }

        private void getData()// Fill All Grid
        {
            spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(SelectedPerson.NationalCode).ToList();
            paraClinicServiceHistoryBindingSource.DataSource = dc.ParaClinicServiceHistories.Where(c => c.Person == SelectedPerson).ToList();
            surgeyHistoryBindingSource.DataSource = dc.SurgeyHistories.Where(c => c.Person == SelectedPerson).ToList();
            testHistoryBindingSource.DataSource = dc.TestHistories.Where(c => c.Person == SelectedPerson).ToList();
            drugHistoryBindingSource.DataSource = dc.DrugHistories.Where(c => c.Person == SelectedPerson && c.Service.CategoryID != 4).ToList();
            spuVisitsHistoryForBehdashtResultBindingSource.DataSource = dc.Spu_VisitsHistoryForBehdasht(SelectedPerson.NationalCode).OrderByDescending(c => c.Date).ToList();
            personDiseaseBindingSource.DataSource = dc.PersonDiseases.Where(c => c.Person == SelectedPerson).ToList();
            var idRisk = Guid.Parse("ffc14139-e3c4-450b-80dd-b7ae98c94101");
            RiskFactorQAPlusBindingSource.DataSource = dc.QAPlus.Where(c => c.GivenServiceM != null && c.GivenServiceM.Person == SelectedPerson && (c.Questionnaire != null && c.Questionnaire.IDGroup == idRisk) && c.ResultCHK == true).OrderByDescending(c => c.CreationDate).ToList();
            spuDentistHistoryResultBindingSource.DataSource = dc.Spu_DentistHistory(SelectedPerson.NationalCode).ToList();
            nutritionHistoryBindingSource.DataSource = dc.NutritionHistories.Where(x => x.Person == SelectedPerson).ToList();
            mentalHealthHistoryBindingSource.DataSource = dc.MentalHealthHistories.Where(x => x.Person == SelectedPerson).ToList();
            var id = Guid.Parse("569ddb75-00a6-4a46-89ad-36ab4cf73801");
            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == id ||
            (x.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.IDParent == id) ||
            (x.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id) ||
            (x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == id)).ToList();
        }

        private void bbiDrug_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgDrugHistory1() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Drug");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiParaclicinc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgParaClinichistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("ParaClinic");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiSurgery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgSurgeryHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Surgery");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiVaccination_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgVaccinationHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Vaccination");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiVisit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgVistiHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Visit");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgTestHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Test");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiDisease_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgDiseaseHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Disease");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiRiskFactor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgRiskFactorHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Risk");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiNutrition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgNutritionHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("Nutrition");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void bbiMentalHealth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedPerson != null)
            {
                var dlg = new dlgMentalHealthHistory() { dc = dc, SelectedPerson = SelectedPerson };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getData("MentalHealth");
                }
            }
            else
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;
            
            qAPlusBindingSource.DataSource = dc.QAPlus.Where(x => x.GivenServiceM != null && x.GivenServiceM.PersonID == SelectedPerson.ID && x.Questionnaire != null && x.Questionnaire.IDGroup == cur.ID).OrderBy(c => c.Questionnaire.SortCol).OrderByDescending(c => c.CreationDate).ToList();
            gridControl9.RefreshDataSource();
        }
    }
}