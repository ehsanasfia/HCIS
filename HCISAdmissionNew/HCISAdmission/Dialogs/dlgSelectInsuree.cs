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


namespace HCISAdmission.Dialogs
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

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var c = gridView1.FocusedRowHandle;
            var ins = gridView1.GetRow(gridView1.FocusedRowHandle) as IGrouping<string, Spu_AllDBPersonResult>;
            Current = ins.Key;
            DialogResult = DialogResult.OK;

        }
    }
}