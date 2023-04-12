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
    public partial class dlgLabHistory : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person prs;

        public dlgLabHistory()
        {
            InitializeComponent();
        }

        private void dlgLabHistory_Load(object sender, EventArgs e)
        {
            spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(prs.NationalCode).ToList();
        }

        private void spuFullLabHistoryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;
            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(prs.NationalCode).Where(x => x.ID == current.ID);
            gridView2.ExpandAllGroups();
        }
    }
}