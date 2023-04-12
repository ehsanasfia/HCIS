using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HcisDispatchConfirm.Data;
namespace HcisDispatchConfirm.Dialogs
{
    public partial class dlgTaiedEzam : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Dispatch dis { get; set; }
        List<Dispatch> lst = new List<Dispatch>();
        public dlgTaiedEzam()
        {
            InitializeComponent();
        }

        private void dlgTaiedEzam_Load(object sender, EventArgs e)
        {
            txtName.Text = dis.GivenServiceM.Person.FirstName + "   " + dis.GivenServiceM.Person.LastName;
            txtShPezeshki.Text = dis.GivenServiceM.Person.MedicalID;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
         var   lst = dc.Dispatches.Where(c => c.ID == dis.ID).FirstOrDefault();

            stiReport1.Dictionary.Variables.Add("FNameLName", dis.GivenServiceM.Person.FirstName + " "+dis.GivenServiceM.Person.LastName );
            stiReport1.Dictionary.Variables.Add("PersonalCode", dis.GivenServiceM.Person.PersonalCode);
            stiReport1.Dictionary.Variables.Add("BirthDate", dis.GivenServiceM.Person.BirthDate);
            stiReport1.Dictionary.Variables.Add("CreationDate", dis.CreationDate);
            stiReport1.Dictionary.Variables.Add("title", dis.DispatchReason.Title);
            stiReport1.Dictionary.Variables.Add("Comment", dis.Comment);
            stiReport1.Dictionary.Variables.Add("Staff", dis.GivenServiceM.Agenda.Staff.Person.FirstName +" " + dis.GivenServiceM.Agenda.Staff.Person.LastName);
           // stiReport1.Dictionary.Variables.Add("Comment", dis.Comment);
            //   stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            stiReport1.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("GDateNow", MainModule.GetPersianDate(DateTime.Now));
        //   stiReport1.Design();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dis.Confirmation = true;
            dis.ConfirmationDate = MainModule.GetPersianDate(DateTime.Now);
            dis.ConfirmationTime = DateTime.Now.ToString("HH:mm");
            dis.ConfirmationUserID = MainModule.UserID;
            DialogResult = DialogResult.OK;
        }
    }
}