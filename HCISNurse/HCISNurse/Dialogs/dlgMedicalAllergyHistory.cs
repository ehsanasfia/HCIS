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

namespace HCISNurse.Dialogs
{
    public partial class dlgMedicalAllergyHistory : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person CurPerson { get; set; }

        public dlgMedicalAllergyHistory()
        {
            InitializeComponent();
        }

        private void dlgDrugAllergyHistory_Load(object sender, EventArgs e)
        {
            this.Text = "حساسیت دارویی" + " " + CurPerson.FirstName + " " + CurPerson.LastName;
            drugAllergyBindingSource.DataSource = dc.DrugAllergies.Where(x => x.Person.NationalCode == CurPerson.NationalCode).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}