using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgSelfRefrence : DevExpress.XtraEditors.XtraForm
    {
        public HCISSpecialistClassesDataContext dc { get; set; }
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
            var today6monthsago = MainModule.GetPersianDate(DateTime.Now.AddDays(-180));
            if (dc.References.Any(x => x.GivenServiceM.PersonID == visit.PersonID && x.Confirm != true && x.SuggestedDate.CompareTo(today6monthsago) >= 0 && x.DepartmentID == visit.Agenda.DepartmentID))
            {
                MessageBox.Show(".بیمار قبلا به خود ارجع داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            if (raf1.Checked == true)
            {
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
            }
            else if (rad2.Checked == true)
            {
                if (textEdit1.Text == "0" || string.IsNullOrWhiteSpace(textEdit1.Text))
                {
                    MessageBox.Show(".لطفا تعداد روز را به درستی وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                sugestdate = sugestdate.AddDays(int.Parse(textEdit1.Text));
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

        private void dlgSelfRefrence_Load(object sender, EventArgs e)
        {
            var today6monthsago = MainModule.GetPersianDate(DateTime.Now.AddDays(-180));
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM.PersonID == visit.PersonID && x.Confirm != true && x.SuggestedDate.CompareTo(today6monthsago) >= 0);
            raf1_CheckedChanged(null, null);
        }

        private void raf1_CheckedChanged(object sender, EventArgs e)
        {
            if (raf1.Checked == true)
            {
                layoutControlItem6.Enabled = true;
                layoutControlItem5.Enabled = false;
            }
        }

        private void rad2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rad2.Checked == true)
            {
                layoutControlItem6.Enabled = false;
                layoutControlItem5.Enabled = true;
            }
        }
    }
}