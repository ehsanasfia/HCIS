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
using OMOApp.Data.HCISData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgLabServiceList : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext om = new OMOClassesDataContext();
        HCISClassesDataContext dc = new HCISClassesDataContext();
        public IGrouping<string, Pattern> ObjectPTT { get; set; }

        public dlgLabServiceList()
        {
            InitializeComponent();
        }

        private void dlgLabServiceList_Load(object sender, EventArgs e)
        {
            var lstIDs = ObjectPTT.Select(x => x.ServiceID).ToList();
            var lstLabTests = dc.Services.Where(x => x.CategoryID == 1 && lstIDs.Contains(x.ID)).ToList();
            serviceBindingSource.DataSource = lstLabTests;
            gridControl1.RefreshDataSource();
        }
    }
}