using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Dialogs
{
    public partial class dlgSafety : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesHCISHealthDataContext dc { get; set; }
        QA ObjectQA;
        List<QA> lstHistory;

        public dlgSafety()
        {
            InitializeComponent();
        }

        private void dlgSafety_Load(object sender, EventArgs e)
        {
            if (ObjectQA == null)
                ObjectQA = new QA();

            if (lstHistory == null)
                lstHistory = new List<QA>();

            lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ID == Guid.Parse("97d0020d-c6bb-4a0c-9df0-faa9de221698")).ToList();
            HistoryQABindingSource.DataSource = lstHistory.OrderByDescending(c => c.CreationDate);

            gridControl1.RefreshDataSource();

            QABindingSource.DataSource = ObjectQA;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
            if (gsm == null)
                return;
            var srv = dc.Services.FirstOrDefault(x => x.ID == Guid.Parse("97d0020d-c6bb-4a0c-9df0-faa9de221698"));

            if (!string.IsNullOrWhiteSpace(ObjectQA.MResult) || ObjectQA.ResultCHK == true || !string.IsNullOrWhiteSpace(ObjectQA.Date))
            {
                ObjectQA.Service = srv;
                ObjectQA.GivenServiceM = gsm;
                ObjectQA.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                ObjectQA.CreationUser = MainModule.UserID;
                dc.QAs.InsertOnSubmit(ObjectQA);
            }
            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
        }
    }
}