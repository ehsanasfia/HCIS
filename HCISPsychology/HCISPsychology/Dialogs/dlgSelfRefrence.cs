using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{
    public partial class dlgSelfRefrence : DevExpress.XtraEditors.XtraForm
    {
        public HCISPsychologyClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }
        public dlgSelfRefrence()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            if (radioGroup1.SelectedIndex == 0)
            {
                sugestdate = sugestdate.AddDays(1);
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                sugestdate = sugestdate.AddDays(3);
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                sugestdate = sugestdate.AddDays(7);
            }
            else if (radioGroup1.SelectedIndex == 3)
            {
                sugestdate = sugestdate.AddDays(14);
            }
            else if (radioGroup1.SelectedIndex == 4)
            {
                sugestdate = sugestdate.AddDays(21);
            }
            else if (radioGroup1.SelectedIndex == 5)
            {
                sugestdate = sugestdate.AddDays(30);
            }
            else if (radioGroup1.SelectedIndex == 6)
            {
                sugestdate = sugestdate.AddDays(60);
            }
            else if (radioGroup1.SelectedIndex == 7)
            {
                sugestdate = sugestdate.AddDays(90);
            }
            else if (radioGroup1.SelectedIndex == 8)
            {
                sugestdate = sugestdate.AddDays(180);
            }
            var end = sugestdate.AddDays(7);
            var endLincence = MainModule.GetPersianDate(end);
            var start = sugestdate.AddDays(-7);
            var startLincence = MainModule.GetPersianDate(start);

            try
            {
                var reffer = new Reference()
                {
                    GivenServiceM = visit,
                    DepartmentID = visit.Agenda.DepartmentID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    SuggestedDate = date,
                    EndDateLicense = endLincence,
                    StartDateLicense = startLincence,
                    Staff = visit.Staff
                };
                dc.References.InsertOnSubmit(reffer);
                dc.SubmitChanges();
                MessageBox.Show(".بیمار با موفقیت ارجاع داده شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}