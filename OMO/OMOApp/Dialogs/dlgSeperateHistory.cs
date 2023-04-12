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
    public partial class dlgSeperateHistory : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext dc { get; set; }
        public Guid curID;

        public dlgSeperateHistory()
        {
            InitializeComponent();
        }

        private void dlgSeperateHistory_Load(object sender, EventArgs e)
        {
            qAPlusBindingSource.DataSource = dc.QAPlus.Where(x => x.Visit != null && x.Visit.PersonID == MainModule.VST_Set.PersonID && x.Questionnaire.IDGroup == curID).OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}