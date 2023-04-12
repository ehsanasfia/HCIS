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
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgReference : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Person person { get; set; }

        public dlgReference()
        {
            InitializeComponent();
        }

        private void dlgReference_Load(object sender, EventArgs e)
        {
            referencesBindingSource.DataSource = dc.References.Where(x => x.GivenServiceMID != null && x.DepartmentID != null && x.GivenServiceM.Person == person && x.Confirm != true).ToList();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }
    }
}