using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgWardPatients : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc { get; set; }

        public dlgWardPatients()
        {
            InitializeComponent();
        }

        private void dlgWardPatients_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}