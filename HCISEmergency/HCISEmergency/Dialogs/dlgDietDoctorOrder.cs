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
    public partial class dlgDietDoctorOrder : DevExpress.XtraEditors.XtraForm
    {
        public dlgDietDoctorOrder()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        Service FoodService;
        private void dlgDietDoctorOrder_Load(object sender, EventArgs e)
        {
            FoodService = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "غذا");

            var DietType = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "نوع رژیم");
            DietTypeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 10 && x.ParentID == DietType.ID).ToList();
            dietBindingSource.DataSource = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time);

            //DietServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 10 && x.ParentID == FoodService.ID && x.ID != DietType.ID).ToList();
            //givenServiceMBindingSource_CurrentChanged(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Staff MyStaff = new Staff();
                var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
                if (clinicStaff != null)
                    MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
                var gsd = new GivenServiceD()
                {
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    GivenServiceMID = MainModule.GSM_Set.ID,
                    FunctorID = MyStaff.ID,
                    Service
                = FoodService
                };
                var dietservice = new Diet()
                {
                    Service = lkpDiet.EditValue as Service,
                    GivenServiceD = gsd,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    Meal = "نوع رژیم",
                    ParentID = null
                    //  Along = rdgFor.EditValue as bool?,
                };
                if (gsd.ID == Guid.Empty)
                {
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                }
                if (dietservice.ID == Guid.Empty)
                {
                    dc.Diets.InsertOnSubmit(dietservice);
                }
                dc.SubmitChanges();
                MessageBox.Show("انجام شد");
                dietBindingSource.DataSource = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time);

            }
            catch { }
        }
    }
}