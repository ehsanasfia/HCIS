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
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Dialogs
{
    public partial class dlgExpertise : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesHCISHealthDataContext dc { get; set; }
        public Person person { get; set; }
        public GivenServiceM visit { get; set; }

        public dlgExpertise()
        {
            InitializeComponent();
        }

        private void dlgExpertise_Load(object sender, EventArgs e)
        {
            visit = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
            person = dc.Persons.FirstOrDefault(x => x.ID == MainModule.PRS_SET.ID);
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceMID == visit.ID);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10).ToList();
            rad1_CheckedChanged(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (visit.References.Any(x => x.GivenServiceMID == visit.ID && x.DepartmentID == (lkpExperties.EditValue as Department).ID && x.Confirm != true))
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
            else if(rad2.Checked == true)
            {
                if(textEdit1.Text == "0" || string.IsNullOrWhiteSpace(textEdit1.Text))
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
                    Department = lkpExperties.EditValue as Department,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    SuggestedDate = sug,
                    EndDateLicense = endLincence,
                    StartDateLicense = startLincence,
                    Staff = visit.Staff,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    LastModificator = MainModule.UserID,
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
            if(rad1.Checked == true)
            {
                layoutControlItem6.Enabled = true;
                layoutControlItem8.Enabled = false;
            }
        }

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            if(rad2.Checked == true)
            {
                layoutControlItem6.Enabled = false;
                layoutControlItem8.Enabled = true;
            }
        }
    }
}