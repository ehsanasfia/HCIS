using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgNewPatient : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public GivenServiceM SelectedGSM { get; set; }

        public dlgNewPatient()
        {
            InitializeComponent();
        }

        private void dlgNewPatient_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.GivenServiceMs.Where(x => (x.ParentID == null || (x.ParentID != null ? x.GivenServiceM1.ServiceCategory.ID != (int)Category.فیزیوتراپی : false)) && x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.GivenServiceMs.Count() == 1).ToList();
            givenServiceMBindingSource.DataSource = lst;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedGSM = givenServiceMBindingSource.Current as GivenServiceM;
            if (SelectedGSM == null)
                return;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 2)
            {
                SelectedGSM = givenServiceMBindingSource.Current as GivenServiceM;
                if (SelectedGSM == null)
                    return;
                DialogResult = DialogResult.OK;
            }
        }
    }
}