using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;

namespace HCISEmergency.Dialogs
{
    public partial class dlgWarning : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public dlgWarning()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            emergencyWarningBindingSource.EndEdit();
            var Ew = dc.EmergencyWarnings.FirstOrDefault();
            Ew.CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            Ew.CreationTime = DateTime.Now.ToString("HH:mm");
            Ew.CreatorUserID = Classes.MainModule.UserID;

            dc.SubmitChanges();
            MessageBox.Show("تغییرات با موفقیت ذخیره شد");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgWarning_Load(object sender, EventArgs e)
        {
            emergencyWarningBindingSource.DataSource = dc.EmergencyWarnings.ToList();
        }
    }
}