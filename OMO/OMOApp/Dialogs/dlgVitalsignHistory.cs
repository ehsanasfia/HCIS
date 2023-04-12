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
    public partial class dlgVitalsignHistory : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext dc { get; set; }
        public Guid curID;

        public dlgVitalsignHistory()
        {
            InitializeComponent();
        }

        private void dlgSeperateHistory_Load(object sender, EventArgs e)
        {
           vitalSignBindingSource.DataSource = dc.VitalSigns.Where(x => x.Visit != null && x.Visit.ID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}