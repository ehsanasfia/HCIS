﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Forms;
using Inventory.Dialogs;
namespace Inventory.Dialogs
{
    public partial class dlgWarehouseDefinition : DevExpress.XtraEditors.XtraForm
    {

        public DataClassesDataContext dc { get; set; }
        public Organ Or { get; set; }
        public bool isEdit { get; set; }
        public dlgWarehouseDefinition()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            personsBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Persons;
        }

        private void dlgWarehouseDefinition_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                txtName.Text = Or.Name;
                txtTel.Text = Or.Phone;
                checkEdit1.Checked = Or.WarehouseMedical;

            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                Organ u = new Organ();
                u.Name = txtName.Text;
                u.Phone = txtTel.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.WarehouseMedical = checkEdit1.Checked;
                u.Warehouse = true;
                dc.Organs.InsertOnSubmit(u);
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            }
            if (isEdit == true)
            {
                Or.Phone = txtTel.Text;
                Or.Name = txtName.Text;
                Or.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                Or.LastModificationTime = DateTime.Now.ToString("HH:mm");
            }
            DialogResult = DialogResult.OK;
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}