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
using HCISDentist.Data;


namespace HCISDentist.Dialogs
{
    public partial class dlgSelectInsuree : DevExpress.XtraEditors.XtraForm
    {
        public HCISDentisClassesDataContext dc = new HCISDentisClassesDataContext();
        public string  Current;
      public  List< IGrouping<string ,Spu_AllDBPersonResult>> insurlist = new List<IGrouping<string, Spu_AllDBPersonResult>>();
        public dlgSelectInsuree()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = insurlist;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var c = gridView1.FocusedRowHandle;
            var ins = gridView1.GetRow(gridView1.FocusedRowHandle) as IGrouping<string, Spu_AllDBPersonResult>;
            Current = ins.Key;
            DialogResult = DialogResult.OK;
        }
    }
}