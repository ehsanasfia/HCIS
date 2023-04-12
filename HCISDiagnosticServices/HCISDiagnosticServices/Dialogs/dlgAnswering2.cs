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
using HCISDiagnosticServices.Data;
using HCISDiagnosticServices.Forms;

namespace HCISDiagnosticServices.Dialogs
{

    public partial class dlgAnswering2 : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }
        public GivenDiagnosticServiceM GSMDiag { get; set; }

        public bool isA5 = false;

        public Stimulsoft.Report.StiReport StiRPT4;
        public Stimulsoft.Report.StiReport StiRPT5;

        //Guid stfID;

        static Guid SaveStaff;

        public dlgAnswering2()
        {
            InitializeComponent();
        }

        private void dlgAnswering_Load(object sender, EventArgs e)
        {
            //if (frmMain.SaveStffID != null)
            //{
            //    stfID = dc.Staffs.FirstOrDefault(x => x.ID == frmMain.SaveStffID).ID;
            //}

            var lstStaff = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && x.Staff.Speciality != null).OrderBy(x => x.Staff.Person.FirstName).ToList();
            if (SaveStaff != null && SaveStaff != Guid.Empty)
            {
                var sstf = lstStaff.FirstOrDefault(x => x.ID == SaveStaff);
                GSM.Staff1 = sstf.Staff;
            }

            lblNameLastName.Text = GSM.Person.FirstName + " " + GSM.Person.LastName;
            lblNationalCode.Text = GSM.Person.NationalCode;
            var Dname = MainModule.DiagnosticService.Name;
            personsBindingSource.DataSource = lstStaff;
            GivenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.Where(x => x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service != null && x.Service.ParentID == MainModule.DiagnosticService.ID).ToList();
            SampleAnswersBindingSource.DataSource = dc.SampleAnswers.Where(x => x.GroupServiceID == MainModule.DiagnosticService.ID).OrderBy(c => c.Title).ToList();

            if (GSM.GivenDiagnosticServiceM == null)
                GSMDiag = new GivenDiagnosticServiceM();
            else
                GSMDiag = GSM.GivenDiagnosticServiceM;

            GSMDiag.GivenServiceM = GSM;

            if (string.IsNullOrWhiteSpace(GSM.AnsweringDate))
            {
                GSM.AnsweringDate = MainModule.GetPersianDate(DateTime.Now);
            }

            GivenServiceMBindingSource.DataSource = GSM;
            GivenDiagnosticServiceMBindingSource.DataSource = GSMDiag;
            //GSM.Staff1 = dc.Staffs.FirstOrDefault(x => x.ID == stfID);

            StiRPT4 = stiReportRTL1;
            StiRPT5 = stiReportRTL2;
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = SampleAnswersBindingSource.Current as SampleAnswer;
                if (row == null)
                    return;

                if (mmResult.Text == "")
                    mmResult.Text = row.Description;
                else
                {
                    string str1 = "\r\n";
                    string str2 = mmResult.Text;
                    mmResult.Text = str2 + str1 + row.Description;
                }

                GSMDiag.Result = mmResult.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mmResult.Text))
                {
                    MessageBox.Show("لطفا جواب را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (GSM.Staff1 == null)
                {
                    MessageBox.Show("لطفا پزشک را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                GSMDiag.AnsweringDate = MainModule.GetPersianDate(DateTime.Now);
                GSMDiag.AnswerTime = DateTime.Now.ToString("HH:mm");
                SaveStaff = (lkpFunctor.EditValue as Staff).ID;

                if (GSMDiag.ID == Guid.Empty || !dc.GivenDiagnosticServiceMs.Any(x => x.ID == GSMDiag.ID))
                {
                    dc.GivenDiagnosticServiceMs.InsertOnSubmit(GSMDiag);
                }
                dc.SubmitChanges();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.P | Keys.Control))
            {
                btnPrint.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnOk_Click(null, null);

            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(mmResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = mmResult.Text;
                StiRPT4.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                StiRPT4.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                StiRPT4.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                StiRPT4.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                StiRPT4.Dictionary.Variables.Add("staffDarkhast", GSM.Staff == null ? "" : (GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName));
                StiRPT4.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                StiRPT4.Dictionary.Variables.Add("result", GSMDiag.Result);
                StiRPT4.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");


                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                StiRPT4.RegData("Data", Data);
                StiRPT4.Compile();
                //StiRPT4.Design();          

                isA5 = false;
                StiRPT4.CompiledReport.ShowWithRibbonGUI();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            btnOk_Click(null, null);

            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(mmResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = mmResult.Text;
                StiRPT5.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                StiRPT5.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                StiRPT5.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                StiRPT5.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                StiRPT5.Dictionary.Variables.Add("staffDarkhast", GSM.Staff == null ? "" : (GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName));
                StiRPT5.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                StiRPT5.Dictionary.Variables.Add("result", GSMDiag.Result);
                StiRPT5.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");
                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                StiRPT5.RegData("Data", Data);
                StiRPT5.Compile();
                //StiRPT5.Design();  

                isA5 = true;
                StiRPT5.CompiledReport.ShowWithRibbonGUI();
                DialogResult = DialogResult.OK;
            }
        }

        private void chkLTR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLTR.Checked)
            {
                mmResult.RightToLeft = RightToLeft.No;
                StiRPT4 = stiReportLTR1;
                StiRPT5 = stiReportLTR2;
            }
            else
            {

                mmResult.RightToLeft = RightToLeft.Yes;
                StiRPT4 = stiReportRTL1;
                StiRPT5 = stiReportRTL2;
            }
        }

        //private void btnAddDrug_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var dlg = new dlgMedicineAndSupplies();
        //        dlg.dc = dc;
        //        dlg.crnt = GSM;
        //        if (dlg.ShowDialog() == DialogResult.OK)
        //            dc.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
        //        return;
        //    }
        //}
    }
}