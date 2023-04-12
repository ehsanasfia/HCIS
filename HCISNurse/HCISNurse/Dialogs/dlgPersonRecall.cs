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
    public partial class dlgPersonRecall : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person PRS;
        public Recall RCLL;

        public dlgPersonRecall()
        {
            InitializeComponent();
        }

        private void dlgPersonRecall_Load(object sender, EventArgs e)
        {
            recallBindingSource.DataSource = dc.Recalls.Where(x => x.Person == PRS && x.Admitted == false).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RCLL = recallBindingSource.Current as Recall;
            if (RCLL == null)
                return;

            RCLL.Admitted = true;
            RCLL.AdmitDate = MainModule.GetPersianDate(DateTime.Now);
            DialogResult = DialogResult.OK;
        }
    }
}