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
using HealthAndFamilyReportHCIS.Data;
using HealthAndFamilyReportHCIS.Classes;

namespace HealthAndFamilyReportHCIS.Forms
{
    public partial class frmShakhes : DevExpress.XtraEditors.XtraForm
    {
        public JamiatDataContext jdc { get; set; }
        public Tbl_ValidCenterZone SelectedZone { get; set; }

        HCISHealthDataContext hdc = new HCISHealthDataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public frmShakhes()
        {
            InitializeComponent();
        }

        private void frmShakhes_Load(object sender, EventArgs e)
        {
            var lst = new List<Tbl_ValidCenter>();
            lst.Add(new Tbl_ValidCenter() { Name = "همه" });
            lst.AddRange(jdc.Tbl_ValidCenters.Where(x => x.IDValidCenterZone == SelectedZone.IDValidCenterZone).OrderBy(x => x.Name).ToList());

            tbl_ValidCentersBindingSource.DataSource = lst;

            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today.Substring(0, 8) + "01";
            txtToDate.Text = today;

            btnSearch.PerformClick();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cur = tbl_ValidCentersBindingSource.Current as Tbl_ValidCenter;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک مرکز را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            //List<Spu_HealthShakhesByDateResult> lst = null;

            //if (cur.Name == "همه")
            //{
            //    lst = hdc.Spu_HealthShakhesByDate(txtFromDate.Text, txtToDate.Text, -1, SelectedZone.IDValidCenterZone).OrderBy(x => x.IndexCode).ToList();
            //}
            //else
            //{
            //    lst = hdc.Spu_HealthShakhesByDate(txtFromDate.Text, txtToDate.Text, cur.IDValidCenter, -1).OrderBy(x => x.IndexCode).ToList();
            //}

            //spuHealthShakhesByDateResultBindingSource.DataSource = lst;
            //gridControl2.RefreshDataSource();



            List<Spu_HealthUnionIndexResult> lst = null;

            if (cur.Name == "همه")
            {
                lst = hdc.Spu_HealthUnionIndex(txtFromDate.Text, txtToDate.Text, null, null).ToList();
            }
            else
            {
                var imphovalidcenter = IM.Tbl_ValidCenterIMPHOs.FirstOrDefault(x => x.NewIDValidCenter == cur.IDValidCenter);
                if (imphovalidcenter != null)
                    lst = hdc.Spu_HealthUnionIndex(txtFromDate.Text, txtToDate.Text, imphovalidcenter.IDValidCenter, imphovalidcenter.IDValidCenterZone).ToList();
                else
                    lst = hdc.Spu_HealthUnionIndex(txtFromDate.Text, txtToDate.Text, null, null).ToList();

            }

            spuHealthUnionIndexResultBindingSource.DataSource = lst;
            gridControl3.RefreshDataSource();




        }
    }
}