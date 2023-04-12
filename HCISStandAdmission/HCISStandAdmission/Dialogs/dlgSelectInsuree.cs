using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISStandAdmission.Data;


namespace HCISStandAdmission.Dialogs
{
    public partial class dlgSelectInsuree : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc = new DataClasses1DataContext();
        public string Current;
        public List<IGrouping<string, Spu_AllDBPersonResult>> insurlist = new List<IGrouping<string, Spu_AllDBPersonResult>>();
        public dlgSelectInsuree()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = insurlist;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Current = (insuranceBindingSource.Current as Insurance).Name;
            DialogResult = DialogResult.OK;
        }
    }
}