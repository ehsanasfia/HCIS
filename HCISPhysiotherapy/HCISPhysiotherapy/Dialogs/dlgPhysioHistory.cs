using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgPhysioHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        public Person prs;
        List<Spu_PhysioHistoryResult> lst = new List<Spu_PhysioHistoryResult>();

        public dlgPhysioHistory()
        {
            InitializeComponent();
        }

        private void dlgPhysioHistory_Load(object sender, EventArgs e)
        {
            lst = dc.Spu_PhysioHistory(prs.NationalCode, prs.MedicalID).ToList();
            spuPhysioHistoryResultBindingSource.DataSource = lst.OrderByDescending(c => c.AdmitDate);
            gridControl1.RefreshDataSource();
        }
    }
}