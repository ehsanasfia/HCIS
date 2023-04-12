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
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgHistoryForm7 : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person Cur { get; set; }

        public dlgHistoryForm7()
        {
            InitializeComponent();
        }

        private void dlgHistoryForm7_Load(object sender, EventArgs e)
        {
            qABindingSource.DataSource = dc.QAs.Where(x => x.GivenServiceM != null && x.GivenServiceM.Person == Cur && x.Service != null && x.Service.Service1 != null && x.Service.Service1.Service1 != null && x.Service.Service1.Service1.Name == "فرم سلامت نوجوان دو").OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}