﻿using System;
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
    public partial class dlgTransportNew : DevExpress.XtraEditors.XtraForm
    {
        public dlgTransportNew()
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
            var a = new Dialogs.dlgGoToWardNew { person = MainModule.GSM_Set.Person, visit = MainModule.GSM_Set, dc = dc };
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                MainModule.GSM_Set.Confirm = true;
                MainModule.GSM_Set.GivenServiceDs.FirstOrDefault(x => x.Service.ID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).Confirm = true;
                MainModule.GSM_Set.Dossier.Discharge = true;
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