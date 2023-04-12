using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{
    public partial class dlgSpecialDisease : DevExpress.XtraEditors.XtraForm
    {
        public HCISPsychologyClassesDataContext dc { get; set; }
        public GivenServiceM CurPerson { get; set; }
        public dlgSpecialDisease()
        {
            InitializeComponent();
        }

        private void dlgSpecialDisease_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dis = lookUpEdit1.EditValue as SpecialDisease;
            if(dis == null)
            {
                MessageBox.Show("ابتدا یک بیماری را انتخاب کنید");
                return;
            }
            if(dc.PersonDiseases.Any(x => x.PersonID == CurPerson.PersonID && x.Disease == dis.ID))
            {
                MessageBox.Show(".این بیماری برای این بیمار قبلا وارد شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var personDiseas = new PersonDisease()
            {
                PersonID = CurPerson.PersonID,
                Disease = dis.ID,
                DateOfDiscovery = textEdit1.Text,
                DoctorDiagnostic = CurPerson.Agenda.StaffID,

            };
            dc.PersonDiseases.InsertOnSubmit(personDiseas);
            dc.SubmitChanges();
            MessageBox.Show(".اطالاعات ثبت شدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}