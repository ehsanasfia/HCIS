using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgSpecialDisease : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public SpecialDisease SelectedSD { get; set; }

        public dlgSpecialDisease()
        {
            InitializeComponent();
        }

        private void dlgSpecialDisease_Load(object sender, EventArgs e)
        {
            if (SelectedSD == null)
                SelectedSD = new SpecialDisease();

            SDBindingSource.DataSource = SelectedSD;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SelectedSD.ID == 0)
                dc.SpecialDiseases.InsertOnSubmit(SelectedSD);

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}