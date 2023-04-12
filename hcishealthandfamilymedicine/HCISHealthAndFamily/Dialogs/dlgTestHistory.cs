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
    public partial class dlgTestHistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgTestHistory()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc { set; get; }
        public Person MyPerson { set; get; }
        public Person SelectedPerson { get; internal set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            testHistoryBindingSource.EndEdit();
            var NewTest = testHistoryBindingSource.Current as TestHistory;
            NewTest.Person = SelectedPerson;
            NewTest.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewTest.CreationTime = DateTime.Now.ToString("HH:mm");
            NewTest.CreatorUserID = MainModule.UserID;
            dc.TestHistories.InsertOnSubmit(NewTest);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void ServiceLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var Cur = ServiceLookUpEdit.EditValue as Service;
            if (Cur == null) return;
            if (Cur.LaboratoryServiceDetail != null)
            {
                NormalRangeTextEdit.EditValue = Cur.LaboratoryServiceDetail.NormalRange ?? "";
                NormalRangeTextEdit.Text = Cur.LaboratoryServiceDetail.NormalRange ?? "";
            }
            else
            {
                NormalRangeTextEdit.EditValue = "";
                NormalRangeTextEdit.Text = "";
            }
        }

        private void dlgTestHistory_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 1).ToList();
            testHistoryBindingSource.DataSource = new TestHistory();
        }
    }
}