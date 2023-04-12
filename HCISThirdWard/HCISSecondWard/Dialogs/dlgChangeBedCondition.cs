using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgChangeBedCondition : DevExpress.XtraEditors.XtraForm
    {
        public dlgChangeBedCondition()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        BedManagement EditingBedMangmanet;
        private void dlgChangeBedCondition_Load(object sender, EventArgs e)
        {
            if (EditingBedMangmanet == null)
            {
                EditingBedMangmanet = new BedManagement();
            }
            definitionBindingSource.DataSource = dc.Definitions.Where(x=>x.Parent==113);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditingBedMangmanet.Date = txtDate.Text;
            EditingBedMangmanet.Time = txtTime.Text;
            EditingBedMangmanet.DosID =Int32.Parse( txtDossierID.Text);
            EditingBedMangmanet.BedStatus =(lkpBed.EditValue as Definition).ID;
            dc.BedManagements.InsertOnSubmit(EditingBedMangmanet);
            dc.SubmitChanges();
        }

        private void bbiCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}