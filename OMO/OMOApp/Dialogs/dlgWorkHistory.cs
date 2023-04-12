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
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgWorkHistory : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext dc { get; set; }
        public PersonWorkHistory ObjectPWH;
        public Person EditingPerson { get; set; }
        public bool isEdit;

        public dlgWorkHistory()
        {
            InitializeComponent();

            //List<string> jobOrders = new List<string>();
            //jobOrders.Add("شغل قبلی");
            //jobOrders.Add("شغل فعلی");
            //lkpJobOrder.Properties.DataSource = jobOrders;-

            //List<string> AssignedTasks = new List<string>();
            //AssignedTasks.Add("اداری");
            //AssignedTasks.Add("عملیاتی");
            //AssignedTasks.Add("حراست");
            //AssignedTasks.Add("راننده");
            //AssignedTasks.Add("سایر");
            //lkpAssignedTask.Properties.DataSource = AssignedTasks;
            //  lkpAssignedTask
        }

        private void dlgWorkHistory_Load(object sender, EventArgs e)
        {
            if (dc == null)
                dc = new OMOClassesDataContext();

            EditingPerson = dc.Persons.FirstOrDefault(x => x.ID == EditingPerson.ID);

            if (ObjectPWH == null)
                ObjectPWH = new PersonWorkHistory();

            if (!isEdit)
            {
                //lkpJobOrder.EditValue = "شغل فعلی";
                ObjectPWH.Shift = "روزکار";
            }
            else
            {
                //lkpJobOrder.EditValue = ObjectPWH.JobOrder;
                lkpAssignedTask.EditValue = ObjectPWH.AssignedTaskID;
            }

            WorkHistoryBindingSource.DataSource = ObjectPWH;
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 192).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectPWH.Person = EditingPerson;
            if (lkpAssignedTask.EditValue != null)
                ObjectPWH.AssignedTaskID = Int32.Parse(lkpAssignedTask.EditValue.ToString());
            ObjectPWH.JobOrder = "شغل قبلی";
            ObjectPWH.SetAsCurrent = false;
            //if (lkpJobOrder.EditValue.ToString() == "شغل فعلی")
            //    ObjectPWH.SetAsCurrent = true;

            if (!isEdit)
            {
                ObjectPWH.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                ObjectPWH.CreationTime = DateTime.Now.ToString("HH:mm");
                ObjectPWH.CreatorUserID = MainModule.UserID;
            }

            if (ObjectPWH.ID == 0)
                dc.PersonWorkHistories.InsertOnSubmit(ObjectPWH);

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}