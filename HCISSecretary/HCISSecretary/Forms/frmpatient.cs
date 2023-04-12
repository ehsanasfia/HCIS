using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecretary.Data;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Classes;
using HCISSecretary.Dialogs;

namespace HCISSecretary.Forms
{
    public partial class frmpatients : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        HCISDataContext dc = new HCISDataContext();
        Classes.MainAction MA;
        public frmpatients()
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            InitializeComponent();

            //dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void bbiPrintTicket_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Current = givenServiceMBindingSource1.Current as GivenServiceM;
            Print(Current);
        }

        private void bbiRecourse_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var Current = givenServiceMBindingSource.Current as GivenServiceM;
                if (Current.Cancelled == true)
                {
                    MessageBox.Show("این نوبت کنسل شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var today = MainModule.GetPersianDate(DateTime.Now);
                if (Current.Agenda != null && Current.Agenda.Date != null && Current.Agenda.Date.CompareTo(today) > 0)
                {
                    MessageBox.Show("این نوبت برای روز های آینده میباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                Current.AdmitTime = DateTime.Now.ToString("HH:mm");
                Current.AdmitDate = MainModule.GetPersianDate(DateTime.Now);
                Current.AdmitUserID = MainModule.UserID;
                Current.AdmitUserFullName = MainModule.UserFullName;
                Current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                Current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                Current.LastModificator = MainModule.UserID;
                Current.Admitted = true;
                Current.SendToDr = true;
                Current.SendToDrTime = DateTime.Now.ToString("HH:mm");

                //comment shode be dastor khanom savari dar tarikh 1397/10/18 tavasote mohammad goudarzi (DayliSn be khode paziresh enteghal yaft)

                //var list = dc.GivenServiceMs.Where(c => c.AgendaID == Current.AgendaID && c.Admitted == true && c.Cancelled != true).OrderBy(x => x.DailySN).ToList();
                //if (list.Count > 0)
                //    Current.DailySN = list.Count() + 1;
                //else
                //    Current.DailySN = 1;



                MA.Save();
                if (barToggleSwitchItem1.Checked == true)
                    Print(Current);

                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && (p.Agenda.Deleted == false || p.Agenda.Deleted == null) && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.SendToDr != true && p.Admitted != true).ToList();
                //givenServiceMBindingSource1.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.Admitted == true && p.SendToDr != true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true).ToList();
                givenServiceMBindingSource2.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.SendToDr == true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true).ToList();
            }
            catch
            {

            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }
        void Print(GivenServiceM GivenServiceM)
        {
            //stiReport1.Compile();
            //stiReport1.CompiledReport["FName"] = GivenServiceM.Person.FirstName;
            //stiReport1.CompiledReport["LName"] = GivenServiceM.Person.LastName;
            //stiReport1.CompiledReport["DrName"] = GivenServiceM.Staff.Person.FirstName + " " + GivenServiceM.Staff.Person.LastName;
            //stiReport1.CompiledReport["Number"] = GivenServiceM.DailySN.ToString();
            //stiReport1.CompiledReport["Date"] = GivenServiceM.AdmitDate.ToString();
            //stiReport1.CompiledReport["Time"] = GivenServiceM.AdmitTime.ToString();
            //stiReport1.CompiledReport["Room"] = GivenServiceM.Agenda.Staff.RoomNumber == null ? "" : GivenServiceM.Agenda.Staff.RoomNumber;
            //stiReport1.CompiledReport["ClinicName"] = GivenServiceM.Agenda.Department.Name.ToString();
            //stiReport1.CompiledReport["PersonelNumber"] = GivenServiceM.Person.PersonalCode == null ? "" : GivenServiceM.Person.PersonalCode.ToString();
            //stiReport1.Dictionary.Synchronize();
            //stiReport1.Compile();
            //stiReport1.CompiledReport.Print();

            stiReport1.Dictionary.Variables.Add("FName", GivenServiceM.Person.FirstName ?? "");
            stiReport1.Dictionary.Variables.Add("LName", GivenServiceM.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("DrName", GivenServiceM.Staff.Person.FirstName + " " + GivenServiceM.Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("Number", GivenServiceM.DailySN == null ? "" : GivenServiceM.DailySN.ToString());
            stiReport1.Dictionary.Variables.Add("Date", GivenServiceM.AdmitDate ?? "");
            stiReport1.Dictionary.Variables.Add("Time", GivenServiceM.AdmitTime ?? "");
            stiReport1.Dictionary.Variables.Add("Room", GivenServiceM.Agenda.Staff.RoomNumber == null ? "" : GivenServiceM.Agenda.Staff.RoomNumber);
            stiReport1.Dictionary.Variables.Add("ClinicName", GivenServiceM.Agenda.Department.Name ?? "");
            stiReport1.Dictionary.Variables.Add("PersonelNumber", GivenServiceM.Person.PersonalCode == null ? "" : GivenServiceM.Person.PersonalCode.ToString());
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.Print();
            //stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lookUpDoctor.EditValue == null)
            {
                MessageBox.Show("!لطفا دکتر را مشخص کنید");
                return;
            }
            else
            {
                if (radioGroup1.EditValue == null)
                {
                    MessageBox.Show("!لطفا شیفت را مشخص کنید");
                    return;
                }
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && (p.Agenda.Deleted == false || p.Agenda.Deleted == null) && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.SendToDr != true && p.Admitted != true).ToList();
                givenServiceMBindingSource_CurrentChanged(null, null);
                //givenServiceMBindingSource1.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.Admitted == true && p.SendToDr != true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true).ToList();
                givenServiceMBindingSource2.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.SendToDr == true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true).ToList();
            }
        }

        private void frmpatients_Load(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            var Current = givenServiceMBindingSource1.Current as GivenServiceM;
            var staff = dc.Agendas.Where(c => c.DepartmentID == MainModule.MyDepartment.ID && c.Date.CompareTo(date) >= 0 && c.Staff.UserType == "دکتر").Select(d => d.Staff.Person).Distinct();
            personBindingSource.DataSource = staff;
            txtdate.Text = Classes.MainModule.GetPersianDate(DateTime.Now).ToString();
            if (Current == null)
                bbiSendToDr.Enabled = false;
            bbiPrintTicket.Enabled = false;
            bbiRecourse.Enabled = false;
            MA = new Classes.MainAction(dc);
        }

        private void givenServiceMBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            if (givenServiceMBindingSource.Count > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = true;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }
        }
        //private void givenServiceMBindingSource1_DataSourceChanged(object sender, EventArgs e)
        //{
        //    if (givenServiceMBindingSource1.Count > 0)
        //    {
        //        bbiPrintTicket.Enabled = true;
        //        bbiRecourse.Enabled = fals;
        //        bbiSendToDr.Enabled = true;
        //    }
        //    else
        //    {
        //        bbiPrintTicket.Enabled = false;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = false;
        //    }
        //}

        //private void givenServiceMBindingSource2_DataSourceChanged(object sender, EventArgs e)
        //{
        //    if (givenServiceMBindingSource2.Count > 0)
        //    {
        //        bbiPrintTicket.Enabled = true;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = true;
        //    }
        //    else
        //    {
        //        bbiPrintTicket.Enabled = false;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = false;
        //    }
        //}

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                var ID = Guid.Parse(View.GetRowCellValue(e.RowHandle, View.Columns[16]).ToString());
                // ServiceCategoryID for paraclinic service is 2
                var list = dc.GivenServiceMs.Where(c => c.ParentID == ID && c.ServiceCategoryID == 2 && c.Payed == true).ToList();
                if (list.Count > 0)
                {
                    e.Appearance.BackColor = Color.Salmon;
                }
            }
            catch
            {

            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Current = givenServiceMBindingSource.Current as GivenServiceM;
            if (Current != null)
            {

                if (Current.Admitted != true)
                {
                    bbiPrintTicket.Enabled = false;
                    bbiRecourse.Enabled = true;
                    bbiSendToDr.Enabled = false;
                }
                else
                {
                    bbiPrintTicket.Enabled = true;
                    bbiSendToDr.Enabled = true;
                    bbiRecourse.Enabled = false;
                }
                if (Current.SendToDr != true)
                {

                }
                else
                {
                    bbiSendToDr.Enabled = false;
                    bbiPrintTicket.Enabled = false;
                }
            }
        }

        //private void givenServiceMBindingSource1_CurrentChanged(object sender, EventArgs e)
        //{
        //    var Current = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (Current != null)
        //    {

        //        if (Current.Admitted != true)
        //        {
        //            bbiPrintTicket.Enabled = false;
        //            bbiRecourse.Enabled = true;
        //            bbiSendToDr.Enabled = false;
        //        }
        //        else
        //        {
        //            bbiPrintTicket.Enabled = true;
        //            bbiSendToDr.Enabled = true;
        //            bbiRecourse.Enabled = false;
        //        }
        //        if (Current.SendToDr != true)
        //        {

        //        }
        //        else
        //        {
        //            bbiSendToDr.Enabled = false;
        //            bbiPrintTicket.Enabled = false;
        //        }
        //    }
        //}


        //private void givenServiceMBindingSource2_CurrentChanged(object sender, EventArgs e)
        //{
        //    var Current = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (Current != null)
        //    {

        //        if (Current.Admitted != true)
        //        {
        //            bbiPrintTicket.Enabled = false;
        //            bbiRecourse.Enabled = true;
        //            bbiSendToDr.Enabled = false;
        //        }
        //        else
        //        {
        //            bbiPrintTicket.Enabled = true;
        //            bbiSendToDr.Enabled = true;
        //            bbiRecourse.Enabled = false;
        //        }
        //        if (Current.SendToDr != true)
        //        {

        //        }
        //        else
        //        {
        //            bbiSendToDr.Enabled = false;
        //            bbiPrintTicket.Enabled = false;
        //        }
        //    }
        //}

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiSendToDr_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = givenServiceMBindingSource1.Current as GivenServiceM;
                if (Current == null)
                {
                    MessageBox.Show("....لطفا ابتدا بیمار را انتخاب کنید");
                }
                else
                {
                    Current.SendToDrTime = DateTime.Now.ToString("HH:mm");
                    Current.SendToDr = true;
                    Current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    Current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    //dc.SubmitChanges();
                    MA.Save();

                    //givenServiceMBindingSource1.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.Admitted == true && p.SendToDr != true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true).ToList();
                    givenServiceMBindingSource2.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Agenda.DepartmentID == MainModule.MyDepartment.ID && p.SendToDr == true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.Agenda.ShiftID == int.Parse(radioGroup1.EditValue.ToString()) && p.ServiceCategoryID == 3 && p.Payed == true).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void gridControl1_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = true;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;

            }
        }

        private void gridControl2_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource1.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = true;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = true;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }

        }

        private void gridControl3_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource2.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            bbiRecourse_ItemClick(null, null);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            bbiSendToDr_ItemClick(null, null);
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lookUpDoctor.EditValue as Person == null)
            {
                MessageBox.Show("ابتدا دکتر را مشخص کنید");
                return;
            }
            var dlg = new Dialogs.dlgEnterAndExit();
            dlg.Doc = lookUpDoctor.EditValue as Person;
            dlg.today = txtdate.Text;
            dlg.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lookUpDoctor.EditValue as Person == null)
            {
                MessageBox.Show("ابتدا دکتر را مشخص کنید");
                return;
            }
            var dlg = new Dialogs.dlgDocAgenda();
            dlg.doc = lookUpDoctor.EditValue as Person;
            dlg.ShowDialog();
        }

        private void btnService_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cur = givenServiceMBindingSource2.Current as GivenServiceM;
            if (cur == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var d = new Dialogs.dlgChooseDoc();
            d.dc = dc;
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                var doc = d.staff;
                var dlg = new Forms.frmConsumerGoods();
                dlg.Current = cur;
                dlg.MyDepartment = MainModule.MyDepartment.ID;
                dlg.fromdlgtoday = true;
                dlg.Staffid = doc;
                dlg.NationalCode = cur.Person.NationalCode;
                dlg.ShowDialog();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialogs = new Dialogs.dlgWardClinicalService();
            dialogs.dc = dc;
            dialogs.ShowDialog();
            if (dialogs.DialogResult == DialogResult.OK)
            {
                var d = new Dialogs.dlgChooseDoc();
                d.dc = dc;
                d.ShowDialog();
                if (d.DialogResult == DialogResult.OK)
                {
                    var doc = d.staff;
                    var dlg = new Forms.frmConsumerGoods();
                    dlg.MyDepartment = MainModule.InstallLocation.ID;
                    dlg.fromdlgtoday = true;
                    dlg.fromWarddlg = true;
                    dlg.todayGSD = dialogs.GSD;
                    dlg.Current = dialogs.GSD.GivenServiceM;
                    dlg.Staffid = doc;
                    dlg.NationalCode = dialogs.GSD.GivenServiceM.Person.NationalCode;
                    dlg.ShowDialog();
                }
                else
                    return;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}