using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISAngio.Data;

namespace HCISAngio.Dialogs
{
    public partial class dlgAngioHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD crnt { get; set; }

        public dlgAngioHistory()
        {
            InitializeComponent();
        }

        private void dlgAngioHistory_Load(object sender, EventArgs e)
        {
            angioBindingSource.DataSource = dc.Angios.Where(x => x.GivenServiceM == crnt.GivenServiceM).ToList();
        }
    }
}