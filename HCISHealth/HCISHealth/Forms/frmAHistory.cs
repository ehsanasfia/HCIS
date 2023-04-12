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

namespace HCISHealth.Forms
{
    public partial class frmAHistory : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmAHistory()
        {
            InitializeComponent();
        }

        private void frmAHistory_Load(object sender, EventArgs e)
        {
             visitBindingSource.DataSource = dc.Visits.Where(x => x.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID).ToList();

            spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(MainModule.GSM_SET.Person.NationalCode).ToList();
            spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(MainModule.GSM_SET.Person.NationalCode).ToList();
        //    spuVisitsHistoryResultBindingSource.DataSource = dc.Spu_VisitsHistory(MainModule.GSM.Person.NationalCode).ToList();

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}