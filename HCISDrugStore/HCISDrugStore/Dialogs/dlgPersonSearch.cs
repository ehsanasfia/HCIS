using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgPersonSearch : DevExpress.XtraEditors.XtraForm
    {
        public dlgPersonSearch()
        {
            InitializeComponent();
        }
        public HCISDrugStoreClassesDataContext dc { get; set; }
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

                gridControl1.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //  var s=(personBindingSource.Current as ExtendedSearchResult).ID;
            try
            {
                var Row = gridView1.GetFocusedRowCellValue("ID");
                if (Row == null)
                    return;
                var id = Row.ToString();
                var person = dc.Persons.FirstOrDefault(c => c.ID.ToString() == id);
                if (person == null)
                    return;
                EditingPerson = person;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && btnOk.Enabled)
                btnOk_Click(null, null);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            if (btnOk.Enabled)
                btnOk_Click(null, null);
        }
    }
}