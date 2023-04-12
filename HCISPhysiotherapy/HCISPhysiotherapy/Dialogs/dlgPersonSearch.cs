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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgPersonSearch : DevExpress.XtraEditors.XtraForm
    {
        public dlgPersonSearch()
        {
            InitializeComponent();
        }
        public HCISClassesDataContext dc { get; set; }
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
                    && string.IsNullOrWhiteSpace(txtName.Text)
                    && string.IsNullOrWhiteSpace(txtLastName.Text)
                    && string.IsNullOrWhiteSpace(txtFatherName.Text)
                    && string.IsNullOrWhiteSpace(txtIdentityNumber.Text)
                    && string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                {
                    lst = new List<ExtendedSearchResult>();
                    personBindingSource.DataSource = lst;
                    return;
                }
                lst = dc.ExtendedSearch(
                    txtNationalCode.Text == null || txtNationalCode.Text.Trim() == "" ? null : txtNationalCode.Text,
                    txtName.Text == null || txtName.Text.Trim() == "" ? null : txtName.Text,
                    txtLastName.Text == null || txtLastName.Text.Trim() == "" ? null : txtLastName.Text,
                    txtFatherName.Text == null || txtFatherName.Text.Trim() == "" ? null : txtFatherName.Text,
                    txtIdentityNumber.Text == null || txtIdentityNumber.Text.Trim() == "" ? null : txtIdentityNumber.Text,
                    txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "" ? null : txtPersonalCode.Text).ToList();

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

    }
}