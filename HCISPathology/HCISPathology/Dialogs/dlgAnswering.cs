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
using HCISPathology.Data;

namespace HCISPathology.Dialogs
{

    public partial class dlgAnswering : DevExpress.XtraEditors.XtraForm
    {
        public HCISPathologyDataClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }

        public dlgAnswering()
        {
            InitializeComponent();
        }

        private void dlgAnswering_Load(object sender, EventArgs e)
        {
            lblNameLastName.Text = GSM.Person.FirstName + " " + GSM.Person.LastName;
            lblNationalCode.Text = GSM.Person.NationalCode;
            var srv = dc.Services.FirstOrDefault(x => x.ParentID == null && x.Name == "پاتولوژی");
            if (srv == null)
            {
                MessageBox.Show("خدمت پاتولوژی تعریف نشده");
                return;
            }
            var serviceID = srv.ID;
            personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && x.Staff.Speciality != null && x.Staff.Speciality.Speciality1 == "پاتولوژیست").OrderBy(x => x.Staff.Code).ToList();
            GivenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.پاتولوژی && x.Service.ParentID != null).ToList();
            SampleAnswersBindingSource.DataSource = dc.SampleAnswers.Where(x => x.GroupServiceID == serviceID).ToList();

            if (GSM.GivenDiagnosticServiceM == null)
                GSM.GivenDiagnosticServiceM = new GivenDiagnosticServiceM();
            rtfResult.Rtf = GSM.GivenDiagnosticServiceM.Result;

            GivenServiceMBindingSource.DataSource = GSM;
            GivenDiagnosticServiceMBindingSource.DataSource = GSM.GivenDiagnosticServiceM;

            //date
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = SampleAnswersBindingSource.Current as SampleAnswer;
                if (row == null)
                {
                    return;
                }
                rtfResult.Rtf = row.Description;
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
                stiReport1.Dictionary.Variables.Add("admit", GSM.AdmitDate ?? MainModule.GetPersianDate(DateTime.Now));
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
    }
}