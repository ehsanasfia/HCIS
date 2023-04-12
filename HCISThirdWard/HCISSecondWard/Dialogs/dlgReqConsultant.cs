using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgReqConsultant : DevExpress.XtraEditors.XtraForm
    {
        public dlgReqConsultant()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        public bool fromarchive { get; set; }

        private void dlgReqConsultant_Load(object sender, EventArgs e)
        {
            if (fromarchive)
                layoutControlItem30.Enabled = false;
            consultantBindingSource.DataSource = new Data.Consultant();
            specialityBindingSource.DataSource = dc.Specialities.ToList();

            consultantListBindingSource.DataSource = dc.Consultants.Where(c => c.DossierID == MainModule.GSM_Set.DossierID).ToList();//&& c.StaffID == dc.Staffs.FirstOrDefault(x => x.UserID == clinicStaff).ID).ToList();
        }

        private void btnAddConsultant_Click(object sender, EventArgs e)
        {
            consultantBindingSource.EndEdit();
            var current = consultantBindingSource.Current as Consultant;
            current.ReqTime = DateTime.Now.ToString("HH:mm");
            current.ReqDate = MainModule.GetPersianDate(DateTime.Now);
            current.DossierID = MainModule.GSM_Set.DossierID;
            dc.Consultants.InsertOnSubmit(current);
            dc.SubmitChanges();
            consultantListBindingSource.DataSource = dc.Consultants.Where(c => c.DossierID == MainModule.GSM_Set.DossierID).ToList();
            consultantBindingSource.Clear();
            consultantBindingSource.DataSource = new Consultant();
        }

        private void lkpSpeciality_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpSpeciality.EditValue.ToString() == "")
                return;
            DoctorListBindingSource.DataSource = dc.Persons.Where(c => c.Staff.UserType == "دکتر" && c.Staff.SpecialityID == Int32.Parse(lkpSpeciality.EditValue.ToString())).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}