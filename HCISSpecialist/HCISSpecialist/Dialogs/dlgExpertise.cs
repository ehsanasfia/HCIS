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
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgExpertise : DevExpress.XtraEditors.XtraForm
    {
        public HCISSpecialistClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }
        public dlgExpertise()
        {
            InitializeComponent();
        }

        private void dlgExpertise_Load(object sender, EventArgs e)
        {
            var Hospital = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
            var today6monthsago = MainModule.GetPersianDate(DateTime.Now.AddDays(-180));
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM.PersonID == visit.PersonID && x.Confirm != true && x.SuggestedDate.CompareTo(today6monthsago) >= 0);
            specialityBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == Hospital).ToList();
            rad1_CheckedChanged(null, null);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            var today6monthsago = MainModule.GetPersianDate(DateTime.Now.AddDays(-180));
            if (dc.References.Any(x => x.GivenServiceM.PersonID == visit.PersonID && x.DepartmentID == (lkpExperties.EditValue as Guid?) && x.Confirm != true && x.SuggestedDate.CompareTo(today6monthsago) >= 0 && x.Hide != true && x.DestinationWard == null))
            {
                MessageBox.Show(".این بیمار به این کلینیک ارجاع داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            if (rad1.Checked == true)
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
            var sug = MainModule.GetPersianDate(sugestdate);
            var end = sugestdate.AddDays(7);
            var endLincence = MainModule.GetPersianDate(end);
            var start = sugestdate.AddDays(-7);
            var startLincence = MainModule.GetPersianDate(start);
            try
            {
                var reffer = new Reference()
                {
                    GivenServiceM = visit,
                    DepartmentID = lkpExperties.EditValue as Guid?,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    SuggestedDate = sug,
                    EndDateLicense = endLincence,
                    StartDateLicense = startLincence,
                    Staff = visit.Staff
                };
                if (checkEdit1.Checked == true)
                    reffer.Priority = true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {
            if (rad1.Checked == true)
            {
                layoutControlItem6.Enabled = true;
                layoutControlItem8.Enabled = false;
            }
        }

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            if (rad2.Checked == true)
            {
                layoutControlItem6.Enabled = false;
                layoutControlItem8.Enabled = true;
            }
        }
    }
}