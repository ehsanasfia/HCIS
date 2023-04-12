using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{

    public partial class dlgEzam : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public GivenServiceM Gsm { get; set; }
        public Staff stf { get; set; }

        public List<Dispatch> lstNewDipatches = new List<Dispatch>();
        public dlgEzam()
        {
            InitializeComponent();
        }

        private void dlgEzam_Load(object sender, EventArgs e)
        {
            dispatchReasonBindingSource.DataSource = dc.DispatchReasons.Where(x => x.EmergencyResons == true);
            dispatchBindingSource.DataSource = dc.Dispatches.Where(x => x.GivenServiceM.ID == Gsm.ID);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            var resson = lookUpEdit1.EditValue as DispatchReason;
            if (dc.Dispatches.Any(x => x.GivenServiceM.PersonID == Gsm.PersonID && x.CreationDate == today))
            {
                MessageBox.Show("برای این بیمار امروز اعزام ثبت شده است!", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (resson == null)
            {
                MessageBox.Show("لطفا علت اعزام را وارد کنید!", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dis = new Dispatch()
            {
                GsmID = Gsm.ID,
                DispatchResonID = resson.ID,
                Comment = memoEdit1.Text,
                Destinition = string.IsNullOrWhiteSpace(cmbDestinition.Text) ? null : cmbDestinition.Text.Trim(),
                Sender = string.IsNullOrWhiteSpace(txtSender.Text) ? null : txtSender.Text.Trim(),
                Receiver = string.IsNullOrWhiteSpace(txtReceiver.Text) ? null : txtReceiver.Text.Trim(),
                CreationDate = today,
                CreatorUserID = MainModule.UserID,
                CreationTime = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = today,
                LastModifactor = MainModule.UserID,
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
            };
            dc.Dispatches.InsertOnSubmit(dis);
            dc.SubmitChanges();
            lstNewDipatches.Add(dis);
            MessageBox.Show(".اعزام با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            dispatchBindingSource.DataSource = dc.Dispatches.Where(x => x.GivenServiceM.ID == Gsm.ID);
            //DialogResult = DialogResult.OK;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);

            stiEzam.Dictionary.Variables.Add("FNameLName", Gsm.Person.FirstName + " " + Gsm.Person.LastName);
            stiEzam.Dictionary.Variables.Add("PersonalCode", Gsm.Person.PersonalCode ?? "");
            stiEzam.Dictionary.Variables.Add("BirthDate", Gsm.Person.BirthDate == null ? "" : Gsm.Person.BirthDate.Substring(0, 4));
            stiEzam.Dictionary.Variables.Add("title", (lookUpEdit1.EditValue as DispatchReason) == null ? "" : (lookUpEdit1.EditValue as DispatchReason).Title);
            stiEzam.Dictionary.Variables.Add("Comment", memoEdit1.Text.Trim());
            stiEzam.Dictionary.Variables.Add("Staff", Gsm.Staff == null ? "" : Gsm.Staff.Person.FirstName + " " + Gsm.Staff.Person.LastName);
            stiEzam.Dictionary.Variables.Add("CreationDate", MainModule.GetPersianDate(DateTime.Now));
            stiEzam.Dictionary.Variables.Add("Destinition", string.IsNullOrWhiteSpace(cmbDestinition.Text) ? "" : cmbDestinition.Text.Trim());
            stiEzam.Dictionary.Variables.Add("Sender", string.IsNullOrWhiteSpace(txtSender.Text) ? "" : txtSender.Text.Trim());
            stiEzam.Dictionary.Variables.Add("Receiver", string.IsNullOrWhiteSpace(txtReceiver.Text) ? "" : txtReceiver.Text.Trim());


            stiEzam.Dictionary.Synchronize();
            stiEzam.Compile();
            stiEzam.CompiledReport.ShowWithRibbonGUI();
            //stiEzam.Design();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = dispatchBindingSource.Current as Dispatch;
            if (cur == null)
                return;

            stiEzam.Dictionary.Variables.Add("FNameLName", cur.GivenServiceM.Person.FirstName + " " + cur.GivenServiceM.Person.LastName);
            stiEzam.Dictionary.Variables.Add("PersonalCode", cur.GivenServiceM.Person.PersonalCode ?? "");
            stiEzam.Dictionary.Variables.Add("BirthDate", cur.GivenServiceM.Person.BirthDate == null ? "" : cur.GivenServiceM.Person.BirthDate.Substring(0, 4));
            stiEzam.Dictionary.Variables.Add("title", cur.DispatchReason == null ? "" : cur.DispatchReason.Title);
            stiEzam.Dictionary.Variables.Add("Comment", cur.Comment ?? "");
            stiEzam.Dictionary.Variables.Add("Staff", cur.GivenServiceM.Staff == null ? "" : cur.GivenServiceM.Staff.Person.FirstName + " " + cur.GivenServiceM.Staff.Person.LastName);
            stiEzam.Dictionary.Variables.Add("CreationDate", cur.CreationDate ?? "");
            stiEzam.Dictionary.Variables.Add("Destinition", cur.Destinition ?? "");
            stiEzam.Dictionary.Variables.Add("Sender", cur.Sender ?? "");
            stiEzam.Dictionary.Variables.Add("Receiver", cur.Receiver ?? "");


            stiEzam.Dictionary.Synchronize();
            stiEzam.Compile();
            stiEzam.CompiledReport.ShowWithRibbonGUI();
            //stiEzam.Design();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var cur = dispatchBindingSource.Current as Dispatch;
            if (cur == null)
                return;

            stiEzam.Dictionary.Variables.Add("FNameLName", cur.GivenServiceM.Person.FirstName + " " + cur.GivenServiceM.Person.LastName);
            stiEzam.Dictionary.Variables.Add("PersonalCode", cur.GivenServiceM.Person.PersonalCode ?? "");
            stiEzam.Dictionary.Variables.Add("BirthDate", cur.GivenServiceM.Person.BirthDate == null ? "" : cur.GivenServiceM.Person.BirthDate.Substring(0, 4));
            stiEzam.Dictionary.Variables.Add("title", cur.DispatchReason == null ? "" : cur.DispatchReason.Title);
            stiEzam.Dictionary.Variables.Add("Comment", cur.Comment ?? "");
            stiEzam.Dictionary.Variables.Add("Staff", cur.GivenServiceM.Staff == null ? "" : cur.GivenServiceM.Staff.Person.FirstName + " " + cur.GivenServiceM.Staff.Person.LastName);
            stiEzam.Dictionary.Variables.Add("CreationDate", cur.CreationDate ?? "");
            stiEzam.Dictionary.Variables.Add("Destinition", cur.Destinition ?? "");
            stiEzam.Dictionary.Variables.Add("Sender", cur.Sender ?? "");
            stiEzam.Dictionary.Variables.Add("Receiver", cur.Receiver ?? "");


            stiEzam.Dictionary.Synchronize();
            stiEzam.Compile();
            stiEzam.CompiledReport.ShowWithRibbonGUI();
        }
    }
}