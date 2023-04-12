using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgParaclinicHistory : DevExpress.XtraEditors.XtraForm
    {
        public Person person { get; set; }

        DataClasses1DataContext dc = new DataClasses1DataContext();
        public dlgParaclinicHistory()
        {
            InitializeComponent();
        }

        private void dlgParaclinicHistory_Load(object sender, EventArgs e)
        {
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == person.ID && x.GivenServiceM.ServiceCategoryID == 2).ToList();
        }
    }
}