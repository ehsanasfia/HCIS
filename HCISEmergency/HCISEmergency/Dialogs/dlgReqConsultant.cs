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
    public partial class dlgReqConsultant : DevExpress.XtraEditors.XtraForm
    {
        public dlgReqConsultant()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        private List<Consultant> newConsultants = new List<Consultant>();
        public List<VwDoctorInstraction> newConsDI = new List<VwDoctorInstraction>();

        private void dlgReqConsultant_Load(object sender, EventArgs e)
        {
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
            newConsultants.Add(current);
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

        private void dlgReqConsultant_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in newConsultants)
            {
                var vins = new VwDoctorInstraction()
                {
                    CatName = "مشاوره-" + item.Speciality.Speciality1,
                    DossierID = MainModule.GSM_Set.DossierID,
                    Amount = 1,
                    ServiceName = "درخواست مشاوره-" + item.ReqType + "-تخصص:" + item.Speciality.Speciality1,
                    Date = item.ReqDate,
                    Time = item.ReqTime,
                    Result = item.ReplyText,
                    gsdComment = item.ReqText,
                };
                newConsDI.Add(vins);
            }
        }
    }
}