using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{
    public partial class dlgAllPateintTest : DevExpress.XtraEditors.XtraForm
    {
        internal HCISPsychologyClassesDataContext dc;

        public dlgAllPateintTest()
        {
            InitializeComponent();
        }

        public GivenServiceM SelectedGMS { get; internal set; }
        public List<GivenServiceM> TestGSM { get; internal set; }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectedGMS = givenServiceMBindingSource.Current as GivenServiceM;
         DialogResult= DialogResult.OK;
          
        }

        private void dlgAllPateintTest_Load(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = TestGSM.OrderByDescending(x => x.RequestTime).OrderByDescending(x => x.RequestDate).ToList();
        }
    }
}