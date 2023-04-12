using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgConsumerGoodHistory : DevExpress.XtraEditors.XtraForm
    {
        public GivenServiceM CheckUp { get; set; }
        public HCISDataContext dc { get; set; }
        public dlgConsumerGoodHistory()
        {
            InitializeComponent();
        }

        private void dlgConsumerGoodHistory_Load(object sender, EventArgs e)
        {
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == CheckUp.DossierID && x.GivenServiceM.ServiceCategoryID == 12);

        }
    }
}