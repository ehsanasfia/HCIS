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
using HCISEmergency.Data;

namespace HCISEmergency.Dialogs
{
    public partial class dlgSameCode : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public string PersonalC;
        public Person Current;

        public dlgSameCode()
        {
            InitializeComponent();
        }

        private void dlgSameCode_Load(object sender, EventArgs e)
        {
            personBindingSource.DataSource = dc.Persons.Where(x => x.PersonalCode == PersonalC);
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = e.ListSourceRowIndex + 1;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            if (personBindingSource.Current != null)
            {
                btnAccept.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (personBindingSource.Current == null)
            {
                MessageBox.Show("لطفاً بیمار را انتخاب نمایید.");
                return;
            }

            Current = personBindingSource.Current as Person;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}