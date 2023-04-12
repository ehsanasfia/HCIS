﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Forms;
using Inventory.Dialogs;
using Inventory.Data;
using Inventory.Forms;
using Inventory.Dialogs;
namespace Inventory.Dialogs
{
    public partial class dlgBudgetDefinition : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Budget PHT { get; set; }
        public dlgBudgetDefinition()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            organsBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Organs;
        }

        private void dlgBudgetDefinition_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                lkpOrgan.EditValue = PHT.IDOrgan;
                spnBudget.Text = PHT.BudgetRequest + "";
                txtYear.Text = PHT.Year + "";



            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                PHT = new Budget();
            }
            PHT.IDOrgan = Int32.Parse(lkpOrgan.EditValue.ToString());
            PHT.Year = Int32.Parse(txtYear.Text);
            PHT.BudgetRequest = decimal.Parse(spnBudget.Text);


            if (isEdit == false)
                dc.Budgets.InsertOnSubmit(PHT);





            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}