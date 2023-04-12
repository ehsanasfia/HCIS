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

    public partial class dlgAnswering3 : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }
        public GivenDiagnosticServiceM GSMDiag { get; set; }

        public bool isA5 = false;

        Staff sonoStf;
        Staff mriStf;
        Staff sangStf;
        Staff ctStf;
        Staff radioStf;
        Staff mamoStf;

        public dlgAnswering3()
        {
            InitializeComponent();
        }

        public Stimulsoft.Report.StiReport StiRPT4;
        public Stimulsoft.Report.StiReport StiRPT5;

        private void dlgAnswering_Load(object sender, EventArgs e)
        {
            if(MainModule.sonoStaffID != null)
            {
                sonoStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.sonoStaffID);
            }
            if (MainModule.mriStaffID != null)
            {
                mriStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.mriStaffID);
            }
            if (MainModule.sangStaffID != null)
            {
                sangStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.sangStaffID);
            }
            if (MainModule.ctStaffID != null)
            {
                ctStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.ctStaffID);
            }
            if (MainModule.radioStaffID != null)
            {
                radioStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.radioStaffID);
            }
            if (MainModule.mamoStaffID != null)
            {
                mamoStf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.mamoStaffID);
            }

            lblNameLastName.Text = GSM.Person.FirstName + " " + GSM.Person.LastName;
            lblNationalCode.Text = GSM.Person.NationalCode;
            var Dname = MainModule.DiagnosticService.Name;
            personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && x.Staff.Speciality != null).OrderBy(x => x.Staff.Person.FirstName).ToList();
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

            if (GSM.Staff1 == null)
            {
                if (MainModule.DiagnosticService.Name == "سونوگرافی")
                {
                    GSM.Staff1 = sonoStf;
                }
                else if (MainModule.DiagnosticService.Name == "MRI")
                {
                    GSM.Staff1 = mriStf;
                }
                else if (MainModule.DiagnosticService.Name == "سنگ شکن")
                {
                    GSM.Staff1 = sangStf;
                }
                else if (MainModule.DiagnosticService.Name == "CT")
                {
                    GSM.Staff1 = ctStf;
                }
                else if (MainModule.DiagnosticService.Name == "رادیوگرافی")
                {
                    GSM.Staff1 = radioStf;
                }
                else if (MainModule.DiagnosticService.Name == "ماموگرافی")
                {
                    GSM.Staff1 = mamoStf;
                }
            }

            GivenServiceMBindingSource.DataSource = GSM;
            GivenDiagnosticServiceMBindingSource.DataSource = GSMDiag;

            if (GSMDiag.RtfResult == null)
                RtfResult.Text = GSMDiag.Result;
            else
                RtfResult.Rtf = GSMDiag.RtfResult;

        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = SampleAnswersBindingSource.Current as SampleAnswer;
                if (row == null)
                    return;

                if (RtfResult.Text == "")
                    RtfResult.Text = row.Description;
                else
                {
                    string str1 = "\r\n";
                    string str2 = RtfResult.Text;
                    RtfResult.Text = str2 + str1 + row.Description;
                }

                GSMDiag.Result = RtfResult.Text;
                GSMDiag.RtfResult = RtfResult.Rtf;
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
                if (string.IsNullOrWhiteSpace(RtfResult.Text))
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

                if (MainModule.DiagnosticService.Name == "سونوگرافی")
                {
                    MainModule.sonoStaffID = (lkpFunctor.EditValue as Staff).ID;
                }
                else if (MainModule.DiagnosticService.Name == "MRI")
                {
                    MainModule.mriStaffID = (lkpFunctor.EditValue as Staff).ID;
                }
                else if (MainModule.DiagnosticService.Name == "سنگ شکن")
                {
                    MainModule.sangStaffID = (lkpFunctor.EditValue as Staff).ID;
                }
                else if (MainModule.DiagnosticService.Name == "CT")
                {
                    MainModule.ctStaffID = (lkpFunctor.EditValue as Staff).ID;
                }
                else if (MainModule.DiagnosticService.Name == "رادیوگرافی")
                {
                    MainModule.radioStaffID = (lkpFunctor.EditValue as Staff).ID;
                }
                else if (MainModule.DiagnosticService.Name == "ماموگرافی")
                {
                    MainModule.mamoStaffID = (lkpFunctor.EditValue as Staff).ID;
                }

                GSMDiag.RtfResult = RtfResult.Rtf;
                GSMDiag.Result = RtfResult.Text;
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

            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(RtfResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = RtfResult.Text;
                stiReport1.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                stiReport1.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                stiReport1.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                stiReport1.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                stiReport1.Dictionary.Variables.Add("staffDarkhast", GSM.Staff == null ? "" : (GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName));
                stiReport1.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                stiReport1.Dictionary.Variables.Add("result", GSMDiag.Result);
                stiReport1.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");


                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                stiReport1.RegData("Data", Data);
                stiReport1.Compile();
                //stiReport1.Design();
                isA5 = false;

                stiReport1.CompiledReport.ShowWithRibbonGUI();
                //DialogResult = DialogResult.OK;
            }
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            btnOk_Click(null, null);

            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(RtfResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = RtfResult.Text;
                stiReport2.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                stiReport2.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                stiReport2.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                stiReport2.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                stiReport2.Dictionary.Variables.Add("staffDarkhast", GSM.Staff == null ? "" : (GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName));
                stiReport2.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                stiReport2.Dictionary.Variables.Add("result", GSMDiag.Result);
                stiReport2.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");
                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                stiReport2.RegData("Data", Data);
                stiReport2.Compile();
                //stiReport2.Design();          
                isA5 = true;

                //stiReport2.CompiledReport.ShowWithRibbonGUI();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnRtfAnswer_Click(object sender, EventArgs e)
        {
            btnOk_Click(null, null);

            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(RtfResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = mmResult.Text;

                GSM.GivenDiagnosticServiceM.RtfResult = RtfResult.Rtf;
                stiReport3.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                stiReport3.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                stiReport3.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                stiReport3.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                stiReport3.Dictionary.Variables.Add("staffDarkhast", GSM.Staff == null ? "" : (GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName));
                stiReport3.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                stiReport3.Dictionary.Variables.Add("result", GSMDiag.RtfResult);
                stiReport3.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");
                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                stiReport3.RegData("Data", Data);
                stiReport3.Compile();
                //stiReport3.Design();
                isA5 = false;

                stiReport3.CompiledReport.ShowWithRibbonGUI();
                //DialogResult = DialogResult.OK;
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {

            FontStyle style = RtfResult.SelectionFont.Style;
            if (RtfResult.SelectionFont.Bold)
            {
                style = style & ~FontStyle.Bold;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Regular);
            }
            else
            {
                style = style | FontStyle.Bold;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Bold);
            }
            RtfResult.SelectionFont = new Font(RtfResult.SelectionFont, style);
            RtfResult.Focus();
        }

        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            FontStyle style = RtfResult.SelectionFont.Style;
            if (RtfResult.SelectionFont.Underline)
            {
                style = style & ~FontStyle.Underline;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Regular);
            }
            else
            {
                style = style | FontStyle.Underline;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Underline);
            }
            RtfResult.SelectionFont = new Font(RtfResult.SelectionFont, style);
            RtfResult.Focus();

        }

        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            RtfResult.SelectAll();
            RtfResult.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            RtfResult.SelectAll();
            RtfResult.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            RtfResult.SelectAll();
            RtfResult.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void RtfResult_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {   //click event
                //MessageBox.Show("you got it!");
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.MenuItems.Add(menuItem);

                RtfResult.ContextMenu = contextMenu;
            }
        }
        void CutAction(object sender, EventArgs e)
        {
            RtfResult.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, RtfResult.SelectedRtf);
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                RtfResult.SelectedRtf
                    = Clipboard.GetData(DataFormats.Rtf).ToString();
            }else
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                RtfResult.SelectedText
                    = Clipboard.GetData(DataFormats.UnicodeText).ToString();
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