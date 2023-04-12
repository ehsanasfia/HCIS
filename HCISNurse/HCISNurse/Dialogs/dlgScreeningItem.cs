using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgScreeningItem : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Screening selectedScreening;
        List<ScreeningItem> lstSI;

        public dlgScreeningItem()
        {
            InitializeComponent();
        }

        private void dlgScreeningItem_Load(object sender, EventArgs e)
        {
            if (lstSI == null)
                lstSI = new List<ScreeningItem>();

            ServiceBindingSource.DataSource = dc.Services.Where(x => x.ParentID == Guid.Parse("38f0882f-4c0c-4977-8168-ded36e6e8b4a")).ToList();
            lstSI = dc.ScreeningItems.Where(x => x.Screening == selectedScreening).ToList();
            ScreeningItemBindingSource.DataSource = lstSI;
        }


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var srv = ServiceBindingSource.Current as Service;
                var Sitem = new ScreeningItem()
                {
                    Service = srv,
                    Screening = selectedScreening
                };

                if (lstSI.Any(c => c.ItmeID == srv.ID))
                    return;
                else
                    dc.ScreeningItems.InsertOnSubmit(Sitem);

                dc.SubmitChanges();
                lstSI = dc.ScreeningItems.Where(x => x.Screening == selectedScreening).ToList();
                ScreeningItemBindingSource.DataSource = lstSI;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}