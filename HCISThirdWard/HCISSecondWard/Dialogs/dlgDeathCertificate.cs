using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Classes;
using HCISSecondWard.Data;
using HCISSecondWard.Dialogs;
using HCISSecondWard.Forms;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgDeathCertificate : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public dlgDeathCertificate()
        {
            InitializeComponent();
        }

        private void dlgDeathCertificate_Load(object sender, EventArgs e)
        {

            lkpTypeOfLivingPlace.EditValue = dc.SepasDefinitions.Where(x => x.Parent == 1);
            slkpAllDeathInformation.EditValue = dc.SepasDefinitions.Where(x => x.Parent == 3);
            slkpSourceOfDiagnosisOfDeath.EditValue = dc.SepasDefinitions.Where(x => x.Parent == 2);
            slkpDiagnosisOfCauseOfDeath.EditValue = dc.SepasDefinitions.Where(x => x.Parent == 4);   
         
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.C | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                var a = new HCISSecondWard.Data.DeathCertificate();

                a.SerialNumberOfDeathCertificate = txtSerialNumberOfDeathCertificate.Text;
                a.FileNumber = txtFileNumber.Text;
                a.Explantion = txtExplantion.Text;
                a.TimeOfDeath = txtTimeOfDeath.Text;
                a.DateOfDeath = txtDateOfDeath.Text;
                a.CauseOfDeath = txtCauseOfDeath.Text;
                a.DateOfDeathCertificate = txtDateOfDeathCertificate.Text;
                a.NCodeOfParent = txtNCodeOfParent.Text;
                a.TypeOfLivingPlace = (lkpTypeOfLivingPlace.EditValue as DeathCertificate).ID;
                a.SourceOfDiagnosisOfDeath = (slkpSourceOfDiagnosisOfDeath.EditValue as DeathCertificate).ID;
                a.AllDeathInformation = (slkpAllDeathInformation.EditValue as DeathCertificate).ID;
                a.DiagnosisOfCauseOfDeath = (slkpDiagnosisOfCauseOfDeath.EditValue as DeathCertificate).ID;

                dc.DeathCertificates.InsertOnSubmit(a);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}