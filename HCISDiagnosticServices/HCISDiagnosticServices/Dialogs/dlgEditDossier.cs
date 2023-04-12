using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDiagnosticServices.Data;

namespace HCISDiagnosticServices.Dialogs
{
    public partial class dlgEditDossier : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM GSM;

        public dlgEditDossier()
        {
            InitializeComponent();
        }

        private void dlgEditDossier_Load(object sender, EventArgs e)
        {
            GSM = dc.GivenServiceMs.FirstOrDefault(c => c.ID == GSM.ID);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var WrongDossier = GSM.Dossier;

            int dossID = -1;
            var boolValid = int.TryParse(txtNewDoss.Text, out dossID);
            if (!boolValid || dossID == -1 || dossID < 0)
            {
                MessageBox.Show("شماره پرونده به درستی وارد نشده است.");
                return;
            }
            var doss = dc.Dossiers.FirstOrDefault(c => c.ID == dossID);
            if (doss == null)
            {
                MessageBox.Show("شماره پرونده ی وارد شده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if(doss.PersonID != GSM.PersonID)
            {
                MessageBox.Show("بیمار ثبت شده با این شماره پرونده با بیمار فعلی یکسان نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var lstWards = doss.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).ToList();
            GivenServiceM gsmWard = null;
            if (lstWards.Count >= 1)
            {
                gsmWard = lstWards.OrderByDescending(x => x.AdmitTime).OrderByDescending(x => x.AdmitDate).FirstOrDefault();
            }
            else
            {
                MessageBox.Show("شماره پرونده ی وارد شده یافت نشد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            GSM.Dossier = doss;
            GSM.GivenServiceM1 = gsmWard;

            dc.SubmitChanges();

            var DossOld = dc.Dossiers.FirstOrDefault(c => c.ID == WrongDossier.ID);
            if(DossOld.GivenServiceMs.Any())
            {
                MessageBox.Show("عملیات با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                dc.Dossiers.DeleteOnSubmit(DossOld);
            }

            dc.SubmitChanges();

            MessageBox.Show("عملیات با موفقیت انجام شد.","توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            DialogResult = DialogResult.OK;
        }
    }
}