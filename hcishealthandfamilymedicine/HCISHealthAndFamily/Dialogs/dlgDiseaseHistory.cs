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
    public partial class dlgDiseaseHistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgDiseaseHistory()
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
            personDiseaseBindingSource.EndEdit();
       var NewDisease= personDiseaseBindingSource.Current as PersonDisease;
            NewDisease.Person = SelectedPerson;
            NewDisease.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewDisease.CreationTime = DateTime.Now.ToString("HH:mm");
            NewDisease.CreatorUserID = MainModule.UserID;
            dc.PersonDiseases.InsertOnSubmit(NewDisease);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void dlgDiseaseHistory_Load(object sender, EventArgs e)
        {
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.ToList();
            personDiseaseBindingSource.DataSource = new PersonDisease();

        }
    }
}