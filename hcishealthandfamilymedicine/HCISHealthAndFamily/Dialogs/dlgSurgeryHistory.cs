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
    public partial class dlgSurgeryHistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgSurgeryHistory()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc { set; get; }
        public Person MyPerson { set; get; }
        public Person SelectedPerson { get; internal set; }
        
        private void dlgSurgeryHistory_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 9).ToList();
            surgeyHistoryBindingSource.DataSource = new SurgeyHistory();
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textEdit1.Text))
            {
                MessageBox.Show("لطفا تاریخ را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            surgeyHistoryBindingSource.EndEdit();
            var NewSurgery = surgeyHistoryBindingSource.Current as SurgeyHistory;
            NewSurgery.Person = SelectedPerson;
            NewSurgery.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewSurgery.CreationTime = DateTime.Now.ToString("HH:mm");
            NewSurgery.CreatorUserID = MainModule.UserID;
            dc.SurgeyHistories.InsertOnSubmit(NewSurgery);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}