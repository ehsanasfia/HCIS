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
using HCISDefinitions.Data;


namespace HCISDefinitions.Dialogs
{
    public partial class dlgPeriodicCalender : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Staff Doc { get; set; }
        public Department Dep { get; set; }

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public dlgPeriodicCalender()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                if (txtFromClock.Text == "" || txtToclock.Text == "" || rbtnShift.SelectedIndex == -1)
                {
                    MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var a = new PeriodicCalender()
                {
                    ShiftID = Int32.Parse(rbtnShift.EditValue.ToString()),
                    Capacity = Int32.Parse(spnCapecity.Text.ToString()),
                    FromClock = txtFromClock.Text,
                    InaccessibleCapacity = Int32.Parse(spinEdit1.Text.ToString()),
                    ServiceCategoryID = (int)Category.ویزیت,
                    ToClock = txtToclock.Text,
                    FromDate = txtFromDate.Text,
                    ToDate = txtToDate.Text
                };

                foreach (var checkitem in chkDays.CheckedItems)
                {
                    switch (checkitem.ToString())
                    {
                        case ("شنبه"):
                            a.Shanbeh = true;
                            break;
                        case ("یکشنبه"):
                            a.YekShanbeh = true;
                            break;
                        case ("دوشنبه"):
                            a.DoShanbeh = true;
                            break;
                        case ("سه شنبه"):
                            a.SeShanbeh = true;
                            break;
                        case ("چهارشنبه"):
                            a.ChaharShanbeh = true;
                            break;
                        case ("پنج شنبه"):
                            a.PanjShanbeh = true;
                            break;
                        case ("جمعه"):
                            a.Jomeh = true;
                            break;
                    }
                }

                var fromDate = txtFromDate.Text;
                var toDate = txtToDate.Text;

                var miladitoDate = MainModule.GetDateFromPersianString(toDate);
                for (var miladiFromdate = MainModule.GetDateFromPersianString(fromDate); miladiFromdate <= miladitoDate; miladiFromdate = miladiFromdate.AddDays(1))
                {
                    var date = miladiFromdate.DayOfWeek;

                    foreach (var item in chkDays.CheckedItems)
                    {
                        var day = MainModule.GetPersianDayOfWeek(date);
                        var day1 = item.ToString();
                        if (day == day1)
                        {
                            Agenda agenda;
                            var shamsi = MainModule.GetPersianDate(miladiFromdate);
                            if (!dc.Agendas.Any(x => x.StaffID == Doc.ID && x.DepartmentID == Dep.ID && x.Date == shamsi && x.ShiftID == a.ShiftID))
                            {
                                agenda = new Agenda()
                                {
                                    BeginTime = txtFromClock.Text,
                                    EndTime = txtToclock.Text,
                                    Date = shamsi,
                                    Capacity = Int32.Parse(spnCapecity.Text.ToString()),
                                    InaccessibleCapacity = Int32.Parse(spinEdit1.Text.ToString()),
                                    PeriodicCalender = a,
                                    ShiftID = Int32.Parse(rbtnShift.EditValue.ToString()),
                                    StaffID = Doc.ID,
                                    DepartmentID = Dep.ID,
                                };
                            }
                            else
                            {
                                agenda = dc.Agendas.FirstOrDefault(x => x.StaffID == Doc.ID && x.DepartmentID == Dep.ID && x.Date == shamsi && x.ShiftID == a.ShiftID);
                                agenda.BeginTime = txtFromClock.Text;
                                agenda.EndTime = txtToclock.Text;
                                agenda.Date = shamsi;
                                agenda.Capacity = Int32.Parse(spnCapecity.Text.ToString());
                                agenda.InaccessibleCapacity = Int32.Parse(spinEdit1.Text.ToString());
                                agenda.PeriodicCalender = a;
                                agenda.ShiftID = Int32.Parse(rbtnShift.EditValue.ToString());
                                agenda.StaffID = Doc.ID;
                                agenda.Department = Dep;
                            }
                            if (!dc.Agendas.Any(c => c.ID == agenda.ID))
                                dc.Agendas.InsertOnSubmit(agenda);
                        }
                    }
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void dlgPeriodicCalender_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void spnCapecity_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit1.Text = spnCapecity.Text;
        }
    }
}