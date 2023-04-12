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
    public partial class dlgVistiHistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgVistiHistory()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc { set; get; }
        public Person MyPerson { set; get; }
        public Person SelectedPerson { get; internal set; }

        private void dlgDrugHistory_Load(object sender, EventArgs e)
        {
            iCD10BindingSource.DataSource = MainModule.icd;
            iCD10BindingSource1.DataSource = MainModule.icd;
            iCD10BindingSource2.DataSource = MainModule.icd;
            visitHistoryBindingSource.DataSource = new VisitHistory();

        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            visitHistoryBindingSource.EndEdit();
       var NewVisit= visitHistoryBindingSource.Current as VisitHistory;
            NewVisit.Person = SelectedPerson;
            NewVisit.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewVisit.CreationTime = DateTime.Now.ToString("HH:mm");
            NewVisit.CreatorUserID = MainModule.UserID;
            dc.VisitHistories.InsertOnSubmit(NewVisit);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}