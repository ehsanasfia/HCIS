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
    public partial class dlgGoToWard : DevExpress.XtraEditors.XtraForm
    {

        public HCISDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }
        public dlgGoToWard()
        {
            InitializeComponent();
        }

        private void dlgGoToWard_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.Name== "اتاق عمل اورژانس").ToList();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                //var bdPrv = dc.Beds.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Bed.ID);
                //bdPrv.Condition = "خالی";
                //var crnt = bedBindingSource.Current as Bed;
                //if (crnt == null)
                //{
                //    MessageBox.Show("لطفا یک تخت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                if ((departmentBindingSource.Current as Department) == null)
                {
                    MessageBox.Show("لطفا بخش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                //if(slkDoctor.Text == null)
                //{
                //    MessageBox.Show("لطفا پزشک بخش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                var refrence = new Reference()
                {
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    GivenServiceMID = visit.ID,
                    DestinationWard = (departmentBindingSource.Current as Department).ID,
                };
                dc.References.InsertOnSubmit(refrence);
                dc.SubmitChanges();
                //var doss = new Dossier()
                //{
                //    Date = MainModule.GetPersianDate(DateTime.Now),
                //    Time = DateTime.Now.ToString("HH:mm"),
                //    NationalCode = person.NationalCode,
                //    PersonID = person.ID
                //};
                //dc.Dossiers.InsertOnSubmit(doss);
                //dc.SubmitChanges();
                var gsm = new GivenServiceM()
                {
                    ParentID = visit.ID,
                    Date = txtDate.Text.Trim(),
                    ServiceCategoryID = (int)Category.خدمات_انجام_شده_در_بخش_بستری,
                    RequestStaffID = visit.RequestStaffID,
                    PersonID = person.ID,
                    DossierID = visit.DossierID,
                    Department = (departmentBindingSource.Current as Department),
                    //Bed = crnt,
                    Payed = true,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID=MainModule.GSM_Set.InsuranceID,
                    InsuranceNo= MainModule.GSM_Set.InsuranceNo,
                };
                //var bd = dc.Beds.FirstOrDefault(x => x.ID == crnt.ID);
                //bd.Condition = "پر";

                if (gsm.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(gsm);

                var ServiceID = Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1");
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    Payed = true,
                    ServiceID = ServiceID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                };
                dc.GivenServiceDs.InsertOnSubmit(gsd);
                dc.SubmitChanges();
                MessageBox.Show("بیمار به بخش بستری ارجاع داده شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        //private void slkDepartment_EditValueChanged(object sender, EventArgs e)
        //{
        //    bedBindingSource.DataSource = dc.Beds.Where(x => x.Condition == "خالی" && x.DepartmentID == (slkDepartment.EditValue as Department).ID).ToList();
        //    var today = MainModule.GetPersianDate(DateTime.Now);
        //    //staffBindingSource.DataSource = dc.Agendas.Where(c => c.DepartmentID == (slkDepartment.EditValue as Department).ID && c.Date.CompareTo(today) >= 0).Select(d => d.Staff).Distinct();
        //}
    }
}