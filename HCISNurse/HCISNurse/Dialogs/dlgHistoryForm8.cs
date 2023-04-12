﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgHistoryForm8 : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person Cur { get; set; }

        public dlgHistoryForm8()
        {
            InitializeComponent();
        }

        private void dlgHistoryForm8_Load(object sender, EventArgs e)
        {
            qABindingSource.DataSource = dc.QAs.Where(x => x.GivenServiceM != null && x.GivenServiceM.Person == Cur && x.Service != null && x.Service.Service1 != null && x.Service.Service1.Name == "جدول یک").OrderByDescending(c => c.CreationDate).ToList();
            qABindingSource1.DataSource = dc.QAs.Where(x => x.GivenServiceM != null && x.GivenServiceM.Person == Cur && x.Service != null && x.Service.Service1 != null && x.Service.Service1.Name == "جدول دو").OrderByDescending(c => c.CreationDate).ToList();
            qABindingSource2.DataSource = dc.QAs.Where(x => x.GivenServiceM != null && x.GivenServiceM.Person == Cur && x.Service != null && x.Service.Service1 != null && x.Service.Service1.Name == "جدول سه").OrderByDescending(c => c.CreationDate).ToList();
            personDiseaseBindingSource.DataSource = dc.PersonDiseases.Where(x => x.Person == Cur).OrderByDescending(c => c.DateOfDiscovery).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}