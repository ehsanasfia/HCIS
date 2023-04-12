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
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{
    public partial class dlgTreatmentProgress : DevExpress.XtraEditors.XtraForm
    {
        public dlgTreatmentProgress()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
                if (memProgress.Text.Trim() != "")
                {
                    var p = new TreatmentProgress() { GivenserviceMID = MainModule.GSM_Set.ID, DosseirID = MainModule.GSM_Set.DossierID, PROGRESSNote = memProgress.Text, Date = MainModule.GetPersianDate(DateTime.Now), Time = DateTime.Now.ToString("HH:mm") };
                    dc.TreatmentProgresses.InsertOnSubmit(p);
                    dc.SubmitChanges();
                    treatmentProgressBindingSource.DataSource = dc.TreatmentProgresses.Where(c => c.DosseirID == MainModule.GSM_Set.DossierID);
                gridControl20.RefreshDataSource();
                    MessageBox.Show("سیر بیماری ثبت گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    memProgress.Text = "";
                }
                else
                {
                    MessageBox.Show("لطفا متن مورد نظر را تایپ کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
                }

           
        }

        private void dlgTreatmentProgress_Load(object sender, EventArgs e)
        {
            treatmentProgressBindingSource.DataSource = dc.TreatmentProgresses.Where(c => c.DosseirID == MainModule.GSM_Set.DossierID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}