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
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmNurse : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        Visit visit { set; get; }

        public frmNurse()
        {
            InitializeComponent();
        }

        private void frmNurce_Load(object sender, EventArgs e)
        {
            if (Classes.MainModule.VST_Set == null)
            {
                return;

            }
            visit = dc.Visits.FirstOrDefault(x => x.ID == Classes.MainModule.VST_Set.ID);
            if (visit.VitalSign == null)
            {
                vitalSignBindingSource.Add(new VitalSign() { Visit = visit });
            }
            else
            {
                vitalSignBindingSource.DataSource = visit.VitalSign;
            }

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            vitalSignBindingSource.EndEdit();
            var vital = vitalSignBindingSource.Current as VitalSign;
            if (visit.VitalSign == null)
                dc.VitalSigns.InsertOnSubmit(vital);

            var visitn = dc.Visits.FirstOrDefault(x => x.ID == Classes.MainModule.VST_Set.ID);
            if (visitn.ToDoList.NursingUserID == null)
            {
                visitn.ToDoList.NursingDate = MainModule.GetPersianDate(DateTime.Now);
                visitn.ToDoList.NursingUserID = MainModule.UserID;
                visitn.ToDoList.NursingTime = DateTime.Now.ToString("HH:mm");
            }
            visitn.ToDoList.Nursing = true;
            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void txtHeight_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                txtBMI.Text = "0";
                return;
            }

            double weight = Convert.ToDouble(txtWeight.Text.Trim());
            double height = Convert.ToDouble(txtHeight.Text.Trim()) * 0.01;

            if (weight == 0 || height == 0)
            {
                txtBMI.Text = "0";
                return;
            }

            double BMI = weight / (height * height);
            txtBMI.Text = BMI.ToString("0.00");
        }

        private void btnOldHistory_Click(object sender, EventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);

            var dlg = new Dialogs.dlgOldHistory();
            dlg.SelectedPrs = MainModule.VST_Set.Person;
            dlg.Nurse = true;
            dlg.ShowDialog();
        }

        private void bbiVitalHistory_Click(object sender, EventArgs e)
        {
            var dlg = new Dialogs.dlgVitalsignHistory() { dc = dc };
            dlg.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNurse_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ذخیره ی تغییرات هستید؟", "توجه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == DialogResult.Yes)
            {
                simpleButton2_Click(null, null);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}