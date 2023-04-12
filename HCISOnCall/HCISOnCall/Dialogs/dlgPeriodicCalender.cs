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
using HCISOnCall.Data;
using HCISOnCall.Forms;
using HCISOnCall.Classes;

namespace HCISOnCall.Dialogs
{
    public partial class dlgPeriodicCalender : DevExpress.XtraEditors.XtraForm
    {
        public HCISOnCallDataContext dc { get; set; }

        public dlgPeriodicCalender()
        {
            InitializeComponent();
        }

        private void dlgPeriodicCalender_Load(object sender, EventArgs e)
        {
            var myStaff = dc.View_SecurityUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationName == "HCISSpecialist");
            var query = from c in dc.vwMemGroups
                        where c.HeadUserID == myStaff.UserID
                        select  c;
           
            vwMemGroupBindingSource.DataSource = query.ToList();

            txtFromdate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {     
            var miladiFDatee = MainModule.GetDateFromPersianString(txtFromdate.Text);
            var miladitoDatee = MainModule.GetDateFromPersianString(txtToDate.Text);

            DateTime miladiFromdate = Convert.ToDateTime(miladiFDatee);
            DateTime miladitoDate = Convert.ToDateTime(miladitoDatee);


            for (miladiFromdate.ToString("yyyy/MM/dd"); miladiFromdate <= miladitoDate; miladiFromdate = miladiFromdate.AddDays(1))
            {
                ONcall u = new ONcall();
                var datee = miladiFromdate.DayOfWeek;

                u.Date = MainModule.GetPersianDate(miladiFromdate);            
                u.Day = MainModule.GetPersianDayOfWeek(miladiFromdate.DayOfWeek);

                u.ONCall1 = cmbONCall.Text;
                u.ShiftID = Int32.Parse(rbtnShift.EditValue.ToString());
                u.PersonGID = Guid.Parse(lkpPhysician.EditValue.ToString());

                var qh = from p in dc.Holidays
                         where p.Date.ToString() == u.Date// MainModule.GetPersianDate(miladiFromdate).ToString()

                         select p;
                if (qh.Count() > 0 || u.Day == "پنج شنبه" || u.Day == "جمعه")
                {
                    u.IsHoliday = true;
                }


                dc.ONcalls.InsertOnSubmit(u);

            }
            dc.SubmitChanges();
           

            txtToDate.Text = " ";
            txtFromdate.Text = " ";           
            lkpPhysician.Text = " ";


            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }
