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
using HCISCash.Dialogs;
using HCISCash.Data;
using HCISCash.Classes;
using SecurityLoginsAndAccessControl;


namespace HCISCash
{
    public partial class FrmCash : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();

        public FrmCash()
        {
            InitializeComponent();
        }

        private void GetUserPermission()
        {
            bisUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISCash");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void bbiAdvancedSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgAdvancedSearch() { dc = dc };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            dlgPayment dlgP = new Dialogs.dlgPayment();
            dlgP.Local = true;
            dlgP.person = dlg.EditingPerson;
            dlgP.dc = this.dc;
            if (dlgP.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("آیا مایلید قبض را دریافت کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    dlgP.stiReport1.CompiledReport.ShowWithRibbonGUI();
                }
                getdata();
            }
        }

        private void FrmCash_Load(object sender, EventArgs e)
        {
            comboBoxEdit1.SelectedIndex = 0;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            // insuranceBindingSource.DataSource = dc.Insurances.ToList();

            getdata();
            //if (dossierBindingSource.Count > 0)
            //    bbiPayed.Enabled = true;
            //else
            //    bbiPayed.Enabled = false;

            bisUser.Caption = MainModule.UserFullName;
            // GetUserPermission();
        }

        private void bbiPayed_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Current = vwCashPayBindingSource.Current as Vw_CashPay;
            if (Current == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //else if(chkPayedItem.Checked)
            //{
            //    MessageBox.Show("این صورتحساب قبلا پرداخت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            else
            {
                dlgPayment dlg = new Dialogs.dlgPayment();
                dlg.Local = true;
                dlg.dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Current.DossierID);
                dlg.person = dc.Persons.FirstOrDefault(c => c.ID == Current.PersonID);
                dlg.dc = this.dc;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //if (MessageBox.Show("آیا مایلید قبض را دریافت کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    //{
                    //Print.Design(); 
                    //dlg.StiPayment.Compile();
                    //dlg.StiPayment.Render();
                    //dlg.StiPayment.ShowWithRibbonGUI();
                    //  dlg.stiReport1.CompiledReport.ShowWithRibbonGUI();
                    //   }
                    getdata();
                }
                else if (dlg.DialogResult == DialogResult.No)
                {
                    MessageBox.Show("خدمت قابل پرداخت برای بیمار انتخاب شده وجود ندارد!");
                    dc.Dispose();
                    dc = new HCISCashDataContextDataContext();
                    getdata();
                }
                else
                {
                    dc.Dispose();
                    dc = new HCISCashDataContextDataContext();
                    getdata();
                }
            }
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //dlgAdvancedSearch d = new dlgAdvancedSearch();
            //d.ShowDialog();
        }
        // public struct x {string FirstName ,LastName,Name, NationalCode;};
        private void btnSearch_Click(object sender, EventArgs e)
        {

            getdata();
        }


        void getdata()
        {
            try
            {
                if (textEdit1.Text.Trim() == "")
                { MessageBox.Show("تاریخ را وارد کنید"); return; }
                //if (lookUpEdit1.EditValue == null)
                //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }
                var PD = textEdit1.Text;
                vwCashPayBindingSource.DataSource = dc.Vw_CashPays.Where(c =>(c.DepName == MainModule.InstallLocation.Name ||c.Name == MainModule.InstallLocation.Name )&& c.Date.CompareTo(PD) == 0 && c.CompanyType == comboBoxEdit1.EditValue.ToString()).ToList()/*.Select(c=>new { c.DossierID,c.ID, c.Date, c.DrFname, c.DrLName, c.FirstName, c.LastName, c.Insure, c.CompanyType, c.NationalCode, c.PersonalCode }).Distinct()*/;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (vwCashPayBindingSource.Count > 0)
                bbiPayed.Enabled = true;
            else
                bbiPayed.Enabled = false;
            /////////////
            //var PD = MainModule.GetPersianDate(DateTime.Now);
            //dossierBindingSource.DataSource =
            //    dc.Dossiers.Where(y => y.GivenServiceMs.
            //   Any(d => d.Payed == chkPayedItem.Checked &&
            //   d.Cancelled==false));
        }
        private void bbiTodayPatiant_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var PD = MainModule.GetPersianDate(DateTime.Now);
            //dossierBindingSource.DataSource =
            //    dc.Dossiers.Where(y => y.IOtype == 0 && y.GivenServiceMs.
            //   Any(d => d.Payed == false &&
            //   (d.CreationDate == PD.ToString() || d.Agenda.Date == PD.ToString())
            //   && (d.DepartmentID == MainModule.InstallLocation.ID || (d.Department != null && d.Department.Parent == MainModule.InstallLocation.ID))
            //                                ));
            getdata();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnChangeUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diag = new dialogLogin();
            if (diag.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (var form in MdiChildren)
                form.Close();
            MainModule.UserID = diag.User.UserID;
            MainModule.UserName = diag.UserName;

            MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
            // btnUserManagement.PerformClick();
            MainModule.AppID = diag.User.ApplicationID;
            bisUser.Caption = "کاربر: " + MainModule.UserFullName;
            GetUserPermission();
        }

        private void btnUserManegment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "HCISCash");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISCash");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void grdPersonView_DoubleClick(object sender, EventArgs e)
        {
            bbiPayed.PerformClick();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new dlgPaidCatch();
            a.dc = dc;
            a.ShowDialog();
        }

        private void grdService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bbiPayed.PerformClick();
            }

        }

        private void btnLED_ItemClick(object sender, ItemClickEventArgs e)
        {
            var crnt = personBindingSource.Current as Person;
            if (crnt == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = crnt.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.Payed == true).ToList();
            var gsm = lst.OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).FirstOrDefault();

            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("Person", gsm.Person.FirstName + " " + gsm.Person.LastName + "");
            stiReport1.Dictionary.Variables.Add("Staff", gsm.Agenda.Staff.Person.FirstName + " " + gsm.Agenda.Staff.Person.LastName + "");
            stiReport1.Dictionary.Variables.Add("Speciality", gsm.Agenda.Staff.Speciality + "");
            stiReport1.Dictionary.Variables.Add("AdmitDate", gsm.AdmitDate + "");
            stiReport1.Dictionary.Variables.Add("DailySN", gsm.DailySN + "");

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnStand_ItemClick(object sender, ItemClickEventArgs e)
        {
            var crnt = personBindingSource.Current as Person;
            if (crnt == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = crnt.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.Payed == true).ToList();
            var gsm = lst.OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).FirstOrDefault();

            stiReport2.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport2.Dictionary.Variables.Add("AdmitDate", gsm.AdmitDate + "");
            stiReport2.Dictionary.Variables.Add("NationalCode", gsm.Person.NationalCode + "");
            stiReport2.Dictionary.Variables.Add("InsuranceNo", gsm.Person.InsuranceNo + "");

            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            //stiReport2.Design();
        }

        private void Sking_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void bbiBilling_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgBilling();
            dlg.dc = dc;
            dlg.ShowDialog();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnshowBiling_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = vwCashPayBindingSource.Current as Vw_CashPay;
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Current.DossierID);
                var person = dossier.Person;
                var pays = from c in dossier.Payments.ToList()
                           select new { Price = c.PayBackType == "قبض استرداد" ? -c.Price : c.Price, c.Date, c.Type, c.Time, c.PayBack, c.PayBackType };
                List<Vw_DosFinanceSB> lstDos = new List<Vw_DosFinanceSB>();
                lstDos.Clear();
                if (Current.IOtype == 0)
                {
                    lstDos = dc.Vw_DosFinanceSBs.Where(c => c.DossierNO == Current.ID).ToList();
                }
                else
                    lstDos.AddRange(dc.Vw_DosFinanceSBs.Where(x => x.DossierNO == Current.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                var givenD = from c in lstDos.Where(x => x.Payed == true)
                             select new { c.DossierNO, DRName = c.DoctorLastName + c.DoctorFirstname, c.CatName, c.Date, GivenAmount = c.Amount, c.Name, c.InsuranceShare, c.PatientShare, TotalPrice = c.PayedPrice };
                stiBilling.RegData("givenD", givenD);
                stiBilling.RegData("pays", pays);
                stiBilling.Dictionary.Variables.Add("serial", Current.ID);
                stiBilling.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                //stiBilling.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
                //stiBilling.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(havepay.ToString()));
                stiBilling.Dictionary.Variables.Add("FirstName", person.FirstName == null ? "" : person.FirstName);
                stiBilling.Dictionary.Variables.Add("LastName", person.LastName == null ? "" : person.LastName);
                stiBilling.Dictionary.Variables.Add("NationalCode", person.NationalCode == null ? "" : person.NationalCode);
                stiBilling.Dictionary.Variables.Add("BirthDate", dossier.Date == null ? "" : dossier.Date);
                stiBilling.Dictionary.Variables.Add("Insurance", dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name);
                // stiBilling.Design();
                stiBilling.Dictionary.Synchronize();
                stiBilling.Compile();
                stiBilling.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnPrintPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = vwCashPayBindingSource.Current as Vw_CashPay;
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Current.DossierID);
                var person = dossier.Person;
                var pays = from c in dossier.Payments.ToList()
                           select new { Price = c.PayBackType == "قبض استرداد" ? -c.Price : c.Price, c.Date, c.Type, c.Time, c.PayBack, c.PayBackType };
                List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();

                lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == Current.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                var givenD = from c in lstDos.Where(x => x.Payed == true)
                             select new { c.DossierNO, DRName = c.DoctorLastName + c.DoctorFirstname, c.CatName, c.Date, GivenAmount = c.Amount, c.Name, c.InsuranceShare, c.PatientShare, TotalPrice = c.PayedPrice };
                // stiPayments.RegData("givenD", givenD);
                stiPayments.RegData("pays", pays);
                stiPayments.Dictionary.Variables.Add("serial", Current.ID);
                stiPayments.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                //stiBilling.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
                //stiBilling.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(havepay.ToString()));
                stiPayments.Dictionary.Variables.Add("FirstName", person.FirstName == null ? "" : person.FirstName);
                stiPayments.Dictionary.Variables.Add("LastName", person.LastName == null ? "" : person.LastName);
                stiPayments.Dictionary.Variables.Add("NationalCode", person.NationalCode == null ? "" : person.NationalCode);
                stiPayments.Dictionary.Variables.Add("BirthDate", dossier.Date == null ? "" : dossier.Date);
                stiPayments.Dictionary.Variables.Add("Insurance", dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name);
                // stiPayments.Design();
                stiPayments.Dictionary.Synchronize();
                stiPayments.Compile();
                stiPayments.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void bbibillNotPayed_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = vwCashPayBindingSource.Current as Vw_CashPay;
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Current.DossierID);
                var person = dossier.Person;
                var pays = from c in dossier.Payments.ToList()
                           select new { Price = c.PayBackType == "قبض استرداد" ? -c.Price : c.Price, c.Date, c.Type, c.Time, c.PayBack, c.PayBackType };
                List<Vw_DosFinanceSB> lstDos = new List<Vw_DosFinanceSB>();
                lstDos.Clear();
                if (Current.IOtype == 0)
                {
                    lstDos = dc.Vw_DosFinanceSBs.Where(c => c.DossierNO == Current.ID).ToList();
                }
                else
                    lstDos.AddRange(dc.Vw_DosFinanceSBs.Where(x => x.DossierNO == Current.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                var givenD = from c in lstDos
                             select new { c.DossierNO, DRName = c.DoctorLastName + c.DoctorFirstname, c.CatName, c.Date, GivenAmount = c.Amount, c.Name, c.InsuranceShare, c.PatientShare, TotalPrice = c.PayedPrice };
                stiBilling.RegData("givenD", givenD);
                stiBilling.RegData("pays", pays);
                stiBilling.Dictionary.Variables.Add("serial", Current.ID);
                stiBilling.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                //stiBilling.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
                //stiBilling.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(havepay.ToString()));
                stiBilling.Dictionary.Variables.Add("FirstName", person.FirstName == null ? "" : person.FirstName);
                stiBilling.Dictionary.Variables.Add("LastName", person.LastName == null ? "" : person.LastName);
                stiBilling.Dictionary.Variables.Add("NationalCode", person.NationalCode == null ? "" : person.NationalCode);
                stiBilling.Dictionary.Variables.Add("BirthDate", dossier.Date == null ? "" : dossier.Date);
                stiBilling.Dictionary.Variables.Add("Insurance", dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name);
                // stiBilling.Design();
                stiBilling.Dictionary.Synchronize();
                stiBilling.Compile();
                stiBilling.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

        }
    }
}