using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgGoToWard : DevExpress.XtraEditors.XtraForm
    {
        public HCISSpecialistClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }
        public GivenServiceM gsm;
        public dlgGoToWard()
        {
            InitializeComponent();
        }

        private void dlgGoToWard_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
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

                gsm = new GivenServiceM();
                gsm.ParentID = visit.ID;
                gsm.Date = txtDate.Text.Trim();
                gsm.ServiceCategoryID = (int)Category.خدمات_انجام_شده_در_بخش_بستری;
                gsm.Staff = visit.Staff;
                gsm.PersonID = person.ID;
                gsm.DossierID = visit.DossierID;
                gsm.Department = (departmentBindingSource.Current as Department);
                //gsm.BedID = crnt.ID;
                gsm.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                gsm.CreationTime = DateTime.Now.ToString("HH:mm");
                gsm.CreatorUserID = MainModule.UserID;
                gsm.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsm.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsm.RequestDate = MainModule.GetPersianDate(DateTime.Now);
                gsm.RequestTime = DateTime.Now.ToString("HH:mm");
                if (visit.Confirm && (departmentBindingSource.Current as Department).Name == "اورژانس")
                    gsm.Payed = true;

                if (gsm.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(gsm);

                var ServiceID = Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1");
                var emergency = Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1");
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };

                if ((departmentBindingSource.Current as Department).Name == "اورژانس")
                    gsd.ServiceID = emergency;
                else
                    gsd.ServiceID = ServiceID;

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

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk_Click(null, null);
        }
    }
}