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
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgDayCalender : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Staff doctor { get; set; }
        public Department dep { get; set; }
        public bool isEdit { get; set; }
        public Agenda day { get; set; }
        public bool JustHozori { get; set; }
        public dlgDayCalender()
        {
            InitializeComponent();
        }

        private void dlgDayCalender_Load(object sender, EventArgs e)
        {
            if (JustHozori)
                spinEdit1.ReadOnly = true;
            txtDate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            if (isEdit == true)
            {
                lblRemain.Text = "ظرفیت باقیمانده حضوری: " + day.RemainingDaysOrInfinite + "       " + "ظرفیت باقیمانده غیر حضوری: " + day.RemainingInaccessible;
                txtBeginTime.Text = day.BeginTime;
                txtDate.Text = day.Date;
                txtEndTime.Text = day.EndTime;
                spnCapacity.Value = Int32.Parse(day.Capacity.ToString());
                spinEdit1.Value = Int32.Parse(day.InaccessibleCapacity.ToString());
                if (day.ShiftID == 2)
                    radioShift.SelectedIndex = 0;
                else if (day.ShiftID == 3)
                    radioShift.SelectedIndex = 1;
                else if (day.ShiftID == 4)
                    radioShift.SelectedIndex = 2;
                memoEdit1.Text = day.Comment;
            }
            else
                lytLabel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtBeginTime.Text == "" || txtEndTime.Text == "" || spnCapacity.Text == "" || radioShift.EditValue == null)
            {
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (txtBeginTime.Text.CompareTo(txtEndTime.Text) >= 0)
            //{
            //    MessageBox.Show("ساعت های وارد شده نامعتبر است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            if (isEdit == true)
            {
                if (dc.Agendas.Any(x => x.Deleted == false
                && x.ID != day.ID
                && x.StaffID == doctor.ID
                && x.DepartmentID == dep.ID
                && x.Date == txtDate.Text
                && (
                ((txtBeginTime.Text.CompareTo(x.BeginTime) >= 0 && txtBeginTime.Text.CompareTo(x.EndTime) <= 0)
                ||
                (txtEndTime.Text.CompareTo(x.BeginTime) >= 0 && txtEndTime.Text.CompareTo(x.EndTime) <= 0))
                ||
                ((x.BeginTime.CompareTo(txtBeginTime.Text) >= 0 && x.EndTime.CompareTo(txtBeginTime.Text) <= 0)
                ||
                (x.BeginTime.CompareTo(txtEndTime.Text) >= 0 && x.EndTime.CompareTo(txtEndTime.Text) <= 0))
                )
                ))
                {
                    MessageBox.Show("در این تاریخ  و ساعت قبلا برنامه وارد شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                day.BeginTime = txtBeginTime.Text;
                day.Capacity = int.Parse(spnCapacity.Text);
                day.InaccessibleCapacity = int.Parse(spinEdit1.Text);
                day.Date = txtDate.Text;
                day.EndTime = txtEndTime.Text;
                day.Definition = dc.Definitions.FirstOrDefault(x => x.ID == int.Parse(radioShift.EditValue.ToString()));
                day.Comment = memoEdit1.Text;
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (dc.Agendas.Any(x => x.Deleted == true
                && x.StaffID == doctor.ID
                && x.DepartmentID == dep.ID
                && x.Date == txtDate.Text
                && (
                ((txtBeginTime.Text.CompareTo(x.BeginTime) >= 0 && txtBeginTime.Text.CompareTo(x.EndTime) <= 0)
                ||
                (txtEndTime.Text.CompareTo(x.BeginTime) >= 0 && txtEndTime.Text.CompareTo(x.EndTime) <= 0))
                ||
                ((x.BeginTime.CompareTo(txtBeginTime.Text) >= 0 && x.EndTime.CompareTo(txtBeginTime.Text) <= 0)
                ||
                (x.BeginTime.CompareTo(txtEndTime.Text) >= 0 && x.EndTime.CompareTo(txtEndTime.Text) <= 0))
                )
                ))
                {
                    MessageBox.Show("در این تاریخ  و ساعت قبلا برنامه وارد شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var a = new Agenda()
                {
                    BeginTime = txtBeginTime.Text,
                    Capacity = int.Parse(spnCapacity.Text),
                    InaccessibleCapacity = int.Parse(spinEdit1.Text),
                    Date = txtDate.Text,
                    EndTime = txtEndTime.Text,
                    StaffID = doctor.ID,
                    DepartmentID = dep.ID,
                    ShiftID = int.Parse(radioShift.EditValue.ToString()),
                    Comment = memoEdit1.Text.ToString(),
                };

                dc.Agendas.InsertOnSubmit(a);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void spnCapacity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void spnCapacity_EditValueChanged(object sender, EventArgs e)
        {
            //spinEdit1.Text = spnCapacity.Text;
        }
    }
}