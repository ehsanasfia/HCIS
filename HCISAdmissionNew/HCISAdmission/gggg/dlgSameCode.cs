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

namespace Admission.Dialogs
{
    public partial class dlgSameCode : DevExpress.XtraEditors.XtraForm
    {
        public dlgSameCode()
        {
            InitializeComponent();
        }
     public   List<Person> Paitionts = new List<Person>();
     public   Person Current = new Person();
        private void dlgSameCode_Load(object sender, EventArgs e)
        {
            personBindingSource.DataSource = Paitionts;

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
             Current = personBindingSource.Current as Person;
            DialogResult = DialogResult.OK;

        }
    }
}