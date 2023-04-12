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
    public partial class dlgDrugHistory1 : DevExpress.XtraEditors.XtraForm
    {
        public dlgDrugHistory1()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc { set; get; }
        public Person MyPerson { set; get; }
        public Person SelectedPerson { get; internal set; }

        private void dlgDrugHistory_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            drugHistoryBindingSource.DataSource = new DrugHistory();
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            drugHistoryBindingSource.EndEdit();
       var NewDrug=drugHistoryBindingSource.Current as DrugHistory;
            NewDrug.Person = SelectedPerson;
            NewDrug.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewDrug.CreationTime = DateTime.Now.ToString("HH:mm");
            NewDrug.CreatorUserID = MainModule.UserID;
            dc.DrugHistories.InsertOnSubmit(NewDrug);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}