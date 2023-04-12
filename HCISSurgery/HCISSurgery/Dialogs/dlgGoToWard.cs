using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgGoToWard : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }
        public bool isEdit = false;

        public dlgGoToWard()
        {
            InitializeComponent();
        }

        private void dlgGoToWard_Load(object sender, EventArgs e)
        {
            visit = dc.GivenServiceMs.FirstOrDefault(x => x.ID == visit.ID);
            person = dc.Persons.FirstOrDefault(x => x.ID == person.ID);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 || x.TypeID == 16 || x.TypeID == 15).ToList();
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && x.Staff.Speciality != null).OrderBy(x => x.Staff.Person.FirstName).ToList();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            if (visit.Confirm == true)
            {
                isEdit = true;
                var ThisGSM = dc.GivenServiceMs.FirstOrDefault(x => x.ParentID == visit.ID && x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری);
                slkDepartment.EditValue = ThisGSM.Department;
                slkDoctor.EditValue = dc.Staffs.FirstOrDefault(x => x.ID == ThisGSM.RequestStaffID);
                txtDate.Text = ThisGSM.Date;
                txtTime.Text = ThisGSM.Time;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            try
            {
                if (slkDepartment.Text == null)
                {
                    MessageBox.Show("لطفا بخش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (slkDoctor.Text == null)
                {
                    MessageBox.Show("لطفا پزشک بخش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (isEdit == false)
                {
                    var gsm = new GivenServiceM()
                    {
                        GivenServiceM1 = visit,
                        Date = txtDate.Text.Trim(),
                        Time = txtTime.Text.Trim(),
                        ServiceCategoryID = (int)Category.خدمات_انجام_شده_در_بخش_بستری,
                        RequestStaffID = (slkDoctor.EditValue as Staff).ID,
                        Person = person,
                        Dossier = visit.Dossier,
                        Department = (slkDepartment.EditValue as Department),
                        Payed = true,
                        CreationDate = today,
                        CreationTime = now,
                        CreatorUserID = MainModule.UserID,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        RequestDate = today,
                        RequestTime = now,
                        InsuranceID = visit.InsuranceID,
                        InsuranceNo = visit.InsuranceNo,
                    };
                    if (visit.Bed != null)
                    {
                        var bd = dc.Beds.FirstOrDefault(x => x.ID == visit.Bed.ID);
                        bd.Condition = "خالی";
                    }

                    if (gsm.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(gsm);

                    var ServiceID = Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1");
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        Payed = true,
                        ServiceID = ServiceID,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        Date = today,
                        Time = now,
                    };

                    dc.GivenServiceDs.InsertOnSubmit(gsd);

                    var refrence = new Reference()
                    {
                        CreationDate = today,
                        CreationTime = now,
                        GivenServiceM = visit,
                        DestinationWard = (slkDepartment.EditValue as Department).ID,
                        LastModificationDate = today,
                        LastModificationTime = now,
                    };
                    dc.References.InsertOnSubmit(refrence);
                    MessageBox.Show("بیمار به بخش بستری ارجاع داده شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else if (isEdit == true)
                {
                    var ThisGSM = dc.GivenServiceMs.FirstOrDefault(x => x.ParentID == visit.ID && x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری);
                    var rfrns = ThisGSM.References.FirstOrDefault(x => x.CreationDate == ThisGSM.CreationDate && x.CreationTime == ThisGSM.CreationTime);
                    if(rfrns != null)
                        rfrns.DestinationWard = (slkDepartment.EditValue as Department).ID;
                    else
                    {
                        var refrence = new Reference()
                        {
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            GivenServiceM = visit,
                            DestinationWard = (slkDepartment.EditValue as Department).ID,
                        };
                        dc.References.InsertOnSubmit(refrence);
                    }
                    ThisGSM.Department = (slkDepartment.EditValue as Department);
                    var stf = (slkDoctor.EditValue as Staff);
                    ThisGSM.RequestStaffID = stf.ID;
                    ThisGSM.Date = txtDate.Text;
                    ThisGSM.Time = txtTime.Text;
                    MessageBox.Show("بیمار به بخش بستری ارجاع داده شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}