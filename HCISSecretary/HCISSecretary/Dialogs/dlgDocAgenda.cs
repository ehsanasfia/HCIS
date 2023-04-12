using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgDocAgenda : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Person doc { get; set; }
        public dlgDocAgenda()
        {
            InitializeComponent();
        }

        private void dlgDocAgenda_Load(object sender, EventArgs e)
        {
            agendaBindingSource.DataSource = dc.Agendas.Where(x => x.StaffID == doc.ID && (x.Deleted != true | x.Deleted == null));

        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RemainingDays")
            {
                var agenda = e.Row as Agenda;
                if (agenda == null) return;

                e.Value = agenda.Capacity - agenda.GivenServiceMs.Count;
            }
        }
    }
}