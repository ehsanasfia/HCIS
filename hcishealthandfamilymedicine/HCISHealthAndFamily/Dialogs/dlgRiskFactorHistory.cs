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

namespace HCISHealthAndFamily.Dialogs
{
    public partial class dlgRiskFactorHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { set; get; }
        public Person SelectedPerson { get; internal set; }

        QAPlus ObjectQAP;

        public dlgRiskFactorHistory()
        {
            InitializeComponent();
        }

        private void dlgRiskFactorHistory_Load(object sender, EventArgs e)
        {
            if (ObjectQAP == null)
                ObjectQAP = new QAPlus();

            questionnaireBindingSource.DataSource = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("ffc14139-e3c4-450b-80dd-b7ae98c94101")).ToList();
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(c => c.ID == MainModule.GSM_Set.ID);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectQAP.Questionnaire = lookUpEdit1.EditValue as Questionnaire;
            ObjectQAP.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectQAP.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectQAP.CreationUser = MainModule.UserID;
            ObjectQAP.ResultCHK = true;
            ObjectQAP.GivenServiceM = MainModule.GSM_Set;
            dc.QAPlus.InsertOnSubmit(ObjectQAP);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}