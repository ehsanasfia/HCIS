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
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgReference : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public GivenServiceM gsm = new GivenServiceM();
        public Speciality spc { get; set; }
        public Reference refrence { get; set; }
        public Person person { get; set; }

        public dlgReference()
        {
            InitializeComponent();
        }

        private void dlgReference_Load(object sender, EventArgs e)
        {
            referencesBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM.Person == person && x.Confirm != true).ToList();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            var cur = referencesBindingSource.Current as Reference;
            gsm = cur.GivenServiceM;
            spc = cur.Staff == null ? null : cur.Staff.Speciality;
            refrence = cur;
            DialogResult = DialogResult.OK;
        }
    }
}