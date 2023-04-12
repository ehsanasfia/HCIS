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

namespace HCISDiagnosticServices.Dialogs
{

    public partial class dlgAnswering : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }

        public dlgAnswering()
        {
            InitializeComponent();
        }

        private void dlgAnswering_Load(object sender, EventArgs e)
        {
            lblNameLastName.Text = GSM.Person.FirstName + " " + GSM.Person.LastName;
            lblNationalCode.Text = GSM.Person.NationalCode;
            var Dname = MainModule.DiagnosticService.Name;
            personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && x.Staff.Speciality != null && x.Staff.Speciality.Speciality1 == Dname).OrderBy(x => x.Staff.Code).ToList();
            GivenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.Where(x => x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service != null && x.Service.ParentID == MainModule.DiagnosticService.ID).ToList();
            SampleAnswersBindingSource.DataSource = dc.SampleAnswers.Where(x => x.GroupServiceID == MainModule.DiagnosticService.ID).ToList();

            if (GSM.GivenDiagnosticServiceM == null)
                GSM.GivenDiagnosticServiceM = new GivenDiagnosticServiceM();
            rtfResult.Rtf = GSM.GivenDiagnosticServiceM.Result;

            if (string.IsNullOrWhiteSpace(GSM.AnsweringDate))
            {
                GSM.AnsweringDate = MainModule.GetPersianDate(DateTime.Now);
            }

            GivenServiceMBindingSource.DataSource = GSM;
            GivenDiagnosticServiceMBindingSource.DataSource = GSM.GivenDiagnosticServiceM;       
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = SampleAnswersBindingSource.Current as SampleAnswer;
                if (row == null)
                    return;

                if (rtfResult.Text == "")
                    rtfResult.Rtf = row.Description;
                else
                {
                    rtfResult.AppendText("\r\n");
                    string str = rtfResult.Text;
                    rtfResult.Rtf = row.Description;
                    rtfResult.Text = str + rtfResult.Text;
                }
                GSM.GivenDiagnosticServiceM.Result = rtfResult.Rtf;
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
                if (string.IsNullOrWhiteSpace(rtfResult.Text))
                {
                    MessageBox.Show("لطفا جواب را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (GSM.Staff1 == null)
                {
                    MessageBox.Show("لطفا پزشک را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                DialogResult = DialogResult.OK;
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
            if (GSM.Staff1 == null || string.IsNullOrWhiteSpace(rtfResult.Text))
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را کامل کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                GSM.GivenDiagnosticServiceM.Result = rtfResult.Rtf;
                stiReport1.Dictionary.Variables.Add("name", GSM.Person.FirstName);
                stiReport1.Dictionary.Variables.Add("lastname", GSM.Person.LastName);
                stiReport1.Dictionary.Variables.Add("nationalcode", GSM.Person.NationalCode);
                stiReport1.Dictionary.Variables.Add("answeringDate", GSM.AnsweringDate ?? "");
                stiReport1.Dictionary.Variables.Add("staffDarkhast", GSM.Staff.Person.FirstName + " " + GSM.Staff.Person.LastName);
                stiReport1.Dictionary.Variables.Add("staffAnjam", GSM.Staff1.Person.FirstName + " " + GSM.Staff1.Person.LastName);
                stiReport1.Dictionary.Variables.Add("result", GSM.GivenDiagnosticServiceM.Result);
                stiReport1.Dictionary.Variables.Add("serialnumber", GSM.SerialNumber + "");


                var Data = from d in ((IEnumerable<GivenServiceD>)(GivenServiceDsBindingSource.DataSource))
                           select new
                           {
                               d.Service.Name,
                           };

                stiReport1.RegData("Data", Data);
                stiReport1.Compile();
                //stiReport1.Design();

                stiReport1.CompiledReport.Show();
            }
        }

        private void chkLTR_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLTR.Checked)
            {
                rtfResult.SelectAll();
                rtfResult.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                rtfResult.SelectAll();
                rtfResult.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void rtfResult_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { 
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

                rtfResult.ContextMenu = contextMenu;
            }
        }

        void CopyAction(object sender, EventArgs e)
        {
            Graphics objGraphics;
            Clipboard.Clear();
            Clipboard.SetData(DataFormats.Rtf, rtfResult.SelectedRtf);           
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                rtfResult.SelectedRtf
                    = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        void CutAction(object sender, EventArgs e)
        {
            rtfResult.Cut();
        }
    }
}