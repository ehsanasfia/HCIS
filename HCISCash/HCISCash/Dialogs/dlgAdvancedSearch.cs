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
using HCISCash.Data;
using HCISCash.Dialogs;

namespace HCISCash.Dialogs
{

    public partial class dlgAdvancedSearch : DevExpress.XtraEditors.XtraForm
    {
        public List<Person> lstperson;
        public dlgAdvancedSearch()
        {
            InitializeComponent();
        }
        public HCISCashDataContextDataContext dc { get; set; }
        public Person EditingPerson { get; set; }
        List<ExtendedSearchResult> lst = new List<ExtendedSearchResult>();
        private void dlgAdvancedSearch_Load(object sender, EventArgs e)
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNationalCode.Text)
                    && string.IsNullOrWhiteSpace(txtFirstName.Text)
                    && string.IsNullOrWhiteSpace(txtLastName.Text)
                    && string.IsNullOrWhiteSpace(txtFatherName.Text)
                    && string.IsNullOrWhiteSpace(txtPersonalCode.Text)
                    && string.IsNullOrWhiteSpace(txtIdentityNumber.Text))
                {
                    lst = new List<ExtendedSearchResult>();
                    personBindingSource.DataSource = lst;
                    return;
                }
                lst = dc.ExtendedSearch(
                    string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text,
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text,
                    string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text,
                    string.IsNullOrWhiteSpace(txtFatherName.Text) ? null : txtFatherName.Text,
                    string.IsNullOrWhiteSpace(txtIdentityNumber.Text) ? null : txtIdentityNumber.Text,
                    string.IsNullOrWhiteSpace(txtPersonalCode.Text) ? null : txtPersonalCode.Text).ToList();

                personBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnOk.Enabled = lst.Any();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
              
                var Row = gridView1.GetFocusedRowCellValue("ID");
                if (Row == null)
                    return;
                var id = Row.ToString();
                EditingPerson = dc.Persons.FirstOrDefault(c => c.ID.ToString() == id);
                
                if (EditingPerson == null) return;
                
                //}
                var GivenM = dc.GivenServiceMs.Where(p => p.PersonID == EditingPerson.ID && p.Payed != true );
                if (GivenM.Count() > 0)
                {
                    this.DialogResult = DialogResult.OK;
                  
                }
                else
                {
                    MessageBox.Show("این بیمار صورتحساب قابل پرداخت ندارد.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }
    }
}
