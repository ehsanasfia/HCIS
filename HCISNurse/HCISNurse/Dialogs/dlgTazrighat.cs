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
    public partial class dlgTazrighat : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public GivenServiceM CurrentTazriq { get; set; }

        public dlgTazrighat()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.CreationDate == today);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgTazrighat_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var curent = givenServiceMBindingSource.Current as GivenServiceM;
            if (curent == null)
                return;
            CurrentTazriq = curent;
            DialogResult = DialogResult.OK;
        }
    }
}