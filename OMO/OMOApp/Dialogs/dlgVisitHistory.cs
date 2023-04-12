using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgVisitHistory : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext dc { get; set; }
        public Guid curID;

        public dlgVisitHistory()
        {
            InitializeComponent();
        }

        private void dlgSeperateHistory_Load(object sender, EventArgs e)
        {
            visitBindingSource.DataSource = dc.Visits.Where(x => x.ID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}