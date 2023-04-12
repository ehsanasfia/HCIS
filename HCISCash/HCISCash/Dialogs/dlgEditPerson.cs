using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgEditPerson : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc { get; set; }
        public Dossier ObjectDoss;
        public Person ObjectPrs;

        public dlgEditPerson()
        {
            InitializeComponent();
        }

        private void dlgEditPerson_Load(object sender, EventArgs e)
        {
            if (ObjectPrs == null)
                ObjectPrs = new Person();

            ObjectPrs = ObjectDoss.Person;
            PersonBindingSource.DataSource = ObjectPrs;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PersonBindingSource.EndEdit();
            DialogResult = DialogResult.OK;
        }
    }
}