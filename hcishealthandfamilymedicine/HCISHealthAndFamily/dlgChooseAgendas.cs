using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class dlgChooseAgendas : DevExpress.XtraEditors.XtraForm
    {
        public List<Agenda> lstAgn { get; set; }
        public Agenda SelectedAgenda { get; set; }

        public dlgChooseAgendas()
        {
            InitializeComponent();
        }

        private void dlgChooseAgendas_Load(object sender, EventArgs e)
        {
            agendasBindingSource.DataSource = lstAgn;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = agendasBindingSource.Current as Agenda;
            if (cur == null)
                return;

            SelectedAgenda = cur;
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnOk.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dlgChooseAgendas_Shown(object sender, EventArgs e)
        {
            if (SelectedAgenda != null)
                gridView1.FocusedRowHandle = gridView1.GetRowHandle(lstAgn.IndexOf(SelectedAgenda));
        }
    }
}