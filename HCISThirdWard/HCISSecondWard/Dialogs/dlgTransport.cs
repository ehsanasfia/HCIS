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
    public partial class dlgTransport : DevExpress.XtraEditors.XtraForm
    {
        public dlgTransport()
        {
            InitializeComponent();
        }
        public HCISDataContext dc = new HCISDataContext();
        private void dlgTransport_Load(object sender, EventArgs e)
        {
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM.DossierID == MainModule.GSM_Set.DossierID);
        }
        private void btnSelectWard_Click(object sender, EventArgs e)
        {
            var a = new Dialogs.dlgGoToWard { person = MainModule.GSM_Set.Person, visit = MainModule.GSM_Set, dc = dc };
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                MainModule.GSM_Set.Confirm = true;
                MainModule.GSM_Set.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                MainModule.GSM_Set.ConfirmTime = DateTime.Now.ToString("HH:mm");
                MainModule.GSM_Set.GivenServiceDs.FirstOrDefault(x => x.Service.ID == Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1")).Confirm = true;
                dc.SubmitChanges();
                referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM.ServiceCategory.ID == 10 && x.GivenServiceM.Person == MainModule.GSM_Set.Person);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}