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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgTurn : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        public GivenServiceM GSMAdmission { get; set; }
        public Staff STF { get; set; }
        public List<DateString> lstDate { get; set; }



        private List<Staff> lstSTF;

        string today = MainModule.GetPersianDate(DateTime.Now);
        public dlgTurn()
        {
            InitializeComponent();
        }

        private void dlgTurn_Load(object sender, EventArgs e)
        {
            if (lstDate == null)
            {
                lstDate = new List<DateString>();
            }
            gridControl1.DataSource = lstDate;
            lstSTF = dc.Staffs.Where(x => x.UserType == "فیزیوتراپیست" && x.Hide == false).OrderBy(c => c.Person.LastName).ToList();
            staffsBindingSource.DataSource = lstSTF;
            definitionsBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 1).ToList();
            lkpShift.ItemIndex = 0;
            radioButton2.Checked = true;
            labelControl.Text = "تعداد جلسات درخواست شده توسط پزشک: " + GSMAdmission.RequestedTime;
        }

        private void dlgTurn_Shown(object sender, EventArgs e)
        {
            Turning();
        }

        private void Turning()
        {
            try
            {
                lstSTF.ForEach(x => x.Turn = false);
                if (lstSTF == null || !lstSTF.Any())
                    return;

                var LastGSM = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.ParentID == null && x.TurningDate != null).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault();

                Staff LastStaff = null;
                if (LastGSM == null)
                {
                    gridView2.FocusedRowHandle = gridView2.GetRowHandle(0);
                    LastStaff = lstSTF.FirstOrDefault();
                    if (LastStaff != null)
                        LastStaff.Turn = true;
                    return;
                }
                LastStaff = LastGSM.Staff1;
                if (LastStaff == null)
                {
                    if (LastGSM.GivenServiceMs.Any())
                    {
                        foreach (var gsm in LastGSM.GivenServiceMs)
                        {
                            if (gsm.Staff1 != null)
                            {
                                LastStaff = gsm.Staff1;
                                LastGSM.Staff1 = gsm.Staff1;
                                break;
                            }
                        }
                    }
                    if (LastStaff == null)
                    {
                        gridView2.FocusedRowHandle = gridView2.GetRowHandle(0);
                        LastStaff = lstSTF.FirstOrDefault();
                        if (LastStaff != null)
                            LastStaff.Turn = true;
                        return;
                    }
                }

                bool found = false;
                int index = 0;
                for (index = 0; index < lstSTF.Count; index++)
                {
                    if (lstSTF.ElementAt(index).ID == LastStaff.ID)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                    return;

                index = (index + 1) % lstSTF.Count;

                LastStaff = lstSTF.ElementAt(index);
                gridView2.FocusedRowHandle = gridView2.GetRowHandle(index);
                LastStaff.Turn = true;


                var HistoryPhysiotherapist = GSMAdmission.Person.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.ParentID == null && x.TurningDate != null).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault()?.Staff1;
                if (HistoryPhysiotherapist == null)
                    return;

                found = false;
                index = 0;
                for (index = 0; index < lstSTF.Count; index++)
                {
                    if (lstSTF.ElementAt(index).ID == HistoryPhysiotherapist.ID)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                    return;

                gridView2.FocusedRowHandle = gridView2.GetRowHandle(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffsBindingSource.Current == null)
                {
                    MessageBox.Show("لطفا فیزیوتراپیست را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (radioButton1.Checked)
                {
                    if (rdgShift.SelectedIndex == -1)
                    {
                        MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    var a = new PeriodicCalender()
                    {
                        ShiftID = int.Parse(rdgShift.EditValue.ToString()),
                        ServiceCategoryID = (int)Category.فیزیوتراپی,
                        FromDate = today,
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

                    int count = GSMAdmission.GivenServiceMs.Count;
                    for (var miladiFromdate = DateTime.Now; count < GSMAdmission.RequestedTime; miladiFromdate = miladiFromdate.AddDays(1))
                    {
                        var date = miladiFromdate.DayOfWeek;
                        List<Tariff> lstUsedTariffs = new List<Tariff>();
                        foreach (var item in chkDays.CheckedItems)
                        {
                            var day0 = MainModule.GetPersianDayOfWeek(date);
                            var day1 = item.ToString();

                            if (day0 == day1)
                            {
                                var thisDay = MainModule.GetPersianDate(miladiFromdate);
                                if (GSMAdmission.GivenServiceMs.Any(x => x.TurningDate == thisDay)
                                    && GSMAdmission.GivenServiceMs.FirstOrDefault(x => x.TurningDate == thisDay).ShiftID == (rdgShift.EditValue as int?))
                                {
                                    MessageBox.Show("تاریخ " + day1 + " " + thisDay + " و در شیفت " + dc.Definitions.FirstOrDefault(x => x.ID == (rdgShift.EditValue as int?)).Name + " قبلا انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                                    count++;
                                    break;
                                }
                                GivenServiceM PCgsm = new GivenServiceM()
                                {
                                    Admitted = true,
                                    Confirm = true,
                                    ConfirmDate = today,
                                    ConfirmTime = DateTime.Now.ToString("HH:mm"),
                                    PeriodicCalender = a,
                                    TurningDate = thisDay,
                                    Person = GSMAdmission.Person,
                                    Insurance = GSMAdmission.Insurance,
                                    InsuranceNo = GSMAdmission.InsuranceNo,
                                    GivenServiceM1 = GSMAdmission,
                                    CreationDate = today,
                                    CreationTime = DateTime.Now.ToString("HH:mm"),
                                    CreatorUserID = MainModule.UserID,
                                    LastModificationDate = today,
                                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                    LastModificator = MainModule.UserID,
                                    Definition = dc.Definitions.FirstOrDefault(x => x.ID == int.Parse(rdgShift.EditValue.ToString())),
                                    ServiceCategoryID = (int)Category.فیزیوتراپی,
                                    Staff1 = staffsBindingSource.Current as Staff,
                                    AdmitDate = today,
                                    AdmitTime = DateTime.Now.ToString("HH:mm"),
                                    DossierID = GSMAdmission.DossierID,
                                    Date = today,
                                    Time = DateTime.Now.ToString("HH:mm"),
                                    DepartmentID = dc.Departments.FirstOrDefault(x => x.IDIntParent == 37 && x.TypeID == 66).ID
                                };
                                foreach (var POD in GSMAdmission.GivenServiceDs)
                                {
                                    var gsd = new GivenServiceD()
                                    {
                                        Service = POD.Service,
                                        GivenServiceM = PCgsm,
                                        Comment = POD.Position,
                                        LastModificationDate = today,
                                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                        LastModificator = MainModule.UserID,
                                        Date = today,
                                        Time = DateTime.Now.ToString("HH:mm"),
                                        Amount = Convert.ToDouble(GSMAdmission.NumberOfOrgans),
                                        GivenAmount = Convert.ToDouble(GSMAdmission.NumberOfOrgans),
                                        Confirm = true
                                    };
                                    dc.GivenServiceDs.InsertOnSubmit(gsd);

                                    Tariff lastTrf;
                                    lastTrf = lstUsedTariffs.FirstOrDefault(x => x.ServiceID == POD.ServiceID);
                                    if (lastTrf == null)
                                    {
                                        gsd.Payed = true;
                                        gsd.PaymentPrice = 0;
                                        gsd.PatientShare = 0;
                                        gsd.InsuranceShare = 0;
                                        gsd.TotalPrice = 0;
                                    }

                                    else if (lastTrf.PatientShare == 0)
                                    {
                                        gsd.Payed = true;
                                        gsd.PaymentPrice = 0;
                                        gsd.PatientShare = 0;
                                        gsd.InsuranceShare = (decimal)gsd.Amount * lastTrf.OrganizationShare ?? 0;
                                        gsd.TariffID = lastTrf.ID;
                                        gsd.TotalPrice = gsd.InsuranceShare;
                                    }
                                    else
                                    {
                                        gsd.PaymentPrice = (decimal)gsd.Amount * lastTrf.PatientShare ?? 0;
                                        gsd.PatientShare = (decimal)gsd.Amount * lastTrf.PatientShare ?? 0;
                                        gsd.InsuranceShare = (decimal)gsd.Amount * lastTrf.OrganizationShare ?? 0;
                                        gsd.TariffID = lastTrf.ID;
                                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                                    }
                                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                                }
                                dc.GivenServiceMs.InsertOnSubmit(PCgsm);
                                count++;
                                break;
                            }

                        }
                    }

                    dc.PeriodicCalenders.InsertOnSubmit(a);

                    DialogResult = DialogResult.OK;
                }
                else if (radioButton2.Checked)
                {
                    List<Tariff> lstUsedTariffs = new List<Tariff>();
                    foreach (var date in lstDate)
                    {
                        GivenServiceM Dategsm = new GivenServiceM()
                        {
                            Admitted = true,
                            Confirm = true,
                            ConfirmDate = today,
                            ConfirmTime = DateTime.Now.ToString("HH:mm"),
                            Person = GSMAdmission.Person,
                            Insurance = GSMAdmission.Insurance,
                            InsuranceNo = GSMAdmission.InsuranceNo,
                            GivenServiceM1 = GSMAdmission,
                            CreationDate = today,
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            LastModificationDate = today,
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            Definition = lkpShift.EditValue as Definition,
                            ServiceCategoryID = (int)Category.فیزیوتراپی,
                            Staff1 = staffsBindingSource.Current as Staff,
                            AdmitDate = today,
                            AdmitTime = DateTime.Now.ToString("HH:mm"),
                            TurningDate = date.Date,
                            DossierID = GSMAdmission.DossierID,
                            Date = today,
                            Time = DateTime.Now.ToString("HH:mm"),
                            DepartmentID = dc.Departments.FirstOrDefault(x => x.IDIntParent == 37 && x.TypeID == 66).ID
                        };

                        foreach (var POD in GSMAdmission.GivenServiceDs)
                        {
                            var gsd = new GivenServiceD()
                            {
                                Service = POD.Service,
                                GivenServiceM = Dategsm,
                                Comment = POD.Position,
                                LastModificationDate = today,
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                LastModificator = MainModule.UserID,
                                Date = today,
                                Time = DateTime.Now.ToString("HH:mm"),
                                Amount = Convert.ToDouble(GSMAdmission.NumberOfOrgans),
                                GivenAmount = Convert.ToDouble(GSMAdmission.NumberOfOrgans),
                                Confirm = true
                            };

                            Tariff lastTrf;
                            lastTrf = lstUsedTariffs.FirstOrDefault(x => x.ServiceID == POD.ServiceID);
                            if (lastTrf == null)
                                lastTrf = dc.Tariffs.Where(x => x.ServiceID == POD.ServiceID && x.InsuranceID == GSMAdmission.InsuranceID).OrderByDescending(x => x.Date).FirstOrDefault();
                            if (lastTrf == null)
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = 0;
                                gsd.TotalPrice = 0;
                            }

                            else if (lastTrf.PatientShare == 0)
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = (decimal)gsd.Amount * lastTrf.OrganizationShare ?? 0;
                                gsd.TariffID = lastTrf.ID;
                                gsd.TotalPrice = gsd.InsuranceShare;
                            }
                            else
                            {
                                gsd.PaymentPrice = (decimal)gsd.Amount * lastTrf.PatientShare ?? 0;
                                gsd.PatientShare = (decimal)gsd.Amount * lastTrf.PatientShare ?? 0;
                                gsd.InsuranceShare = (decimal)gsd.Amount * lastTrf.OrganizationShare ?? 0;
                                gsd.TariffID = lastTrf.ID;
                                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                            }
                            dc.GivenServiceDs.InsertOnSubmit(gsd);
                        }
                        Dategsm.PaymentPrice = Dategsm.GivenServiceDs.Sum(x => x.PaymentPrice);
                        dc.GivenServiceMs.InsertOnSubmit(Dategsm);
                    }
                    STF = staffsBindingSource.Current as Staff;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Group1.Enabled = true;
                Group2.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                Group1.Enabled = false;
                Group2.Enabled = true;
            }
        }

        private void faMonthView1_DoubleClick(object sender, EventArgs e)
        {
            if (lstDate.Count + GSMAdmission.GivenServiceMs.Count >= GSMAdmission.RequestedTime)
            {
                MessageBox.Show("تعداد تاریخ های وارد شده به حد نصاب رسیده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (faMonthView1.SelectedDateTime == null)
            {
                return;
            }

            var date = MainModule.GetPersianDate((DateTime)faMonthView1.SelectedDateTime);
            var today = MainModule.GetPersianDate(DateTime.Now);
            //توسط محمد کامنت شد
            //if (date.CompareTo(today) < 0)
            //{
            //    return;
            //}

            if (lstDate.Any(x => x.Date == date)
                || (GSMAdmission.GivenServiceMs.Any(x => x.TurningDate == date)
                && GSMAdmission.GivenServiceMs.FirstOrDefault(x => x.TurningDate == date).ShiftID == (lkpShift.EditValue as Definition).ID))
            {
                //MessageBox.Show("تاریخ " + date + " قبلا انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            lstDate.Add(new DateString() { Date = date });
            lstDate = lstDate.OrderBy(c => c.Date).ToList();
            gridControl1.DataSource = lstDate;
            gridControl1.RefreshDataSource();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
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
    }

    public class DateString
    {
        public string Date { get; set; }
    }
}