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

namespace HCISHealth.Dialogs
{
    public partial class dlgDentistHistory : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesHCISHealthDataContext dc { get; set; }
        public Person prs;
        List<Spu_DentistHistoryResult> lst;

        public dlgDentistHistory()
        {
            InitializeComponent();
        }

        private void dlgDentistHistory_Load(object sender, EventArgs e)
        {
            if (lst == null)
                lst = new List<Spu_DentistHistoryResult>();

            lst = dc.Spu_DentistHistory(prs.NationalCode).ToList();
            spuDentistHistoryResultBindingSource.DataSource = lst;
        }
    }
}