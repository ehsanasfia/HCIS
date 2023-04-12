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
using HCISManualService.Data;

namespace HCISManualService.Dialog
{
    public partial class dlgSelectPerson : DevExpress.XtraEditors.XtraForm
    {
        public List<Person> lstperson = new List<Person>();
        public Person SelectedPerson { get; set; }
        public dlgSelectPerson()
        {
            InitializeComponent();
        }

        private void dlgSelectPerson_Load(object sender, EventArgs e)
        {
            personBindingSource.DataSource = lstperson.ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var curretn = personBindingSource.Current as Person;
            if (curretn == null)
                return;
            SelectedPerson = curretn;
            DialogResult = DialogResult.OK;

        }
    }
}