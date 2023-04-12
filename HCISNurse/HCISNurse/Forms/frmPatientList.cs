using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Classes;
using HCISNurse.Data;
using HCISNurse.Dialogs;

namespace HCISNurse.Forms
{
    public partial class frmPatientList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private List<Dossier> lstDos;

        public frmPatientList()
        {
            InitializeComponent();
        }

        private void frmPatientList_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void GetData()
        {
            try
            {
                var date = txtDate.Text;
                lstDos = dc.Dossiers.Where(x =>
                    x.Date == date &&
                    x.GivenServiceMs.Any(c => 
                            (c.ServiceCategoryID == (int)Category.خدمات_کلینیکی 
                            || c.ServiceCategoryID == (int)Category.لوازم_مصرفی)
                            && c.Cancelled == false))
                    .OrderByDescending(x => x.Time)
                    .ToList();

                lstDos.ForEach(x => 
                    x.GsmPayed = x.GivenServiceMs.Any(c => (c.ServiceCategoryID == (int)Category.خدمات_کلینیکی
                            || c.ServiceCategoryID == (int)Category.لوازم_مصرفی) &&  c.Payed));

                dossierBindingSource.DataSource = lstDos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgConsumerGoods()
            {
                InstallLocation = Guid.Parse(MainModule.InstallLocation.ID.ToString()),
                fromnurse = true,
                NurseDep = MainModule.MyDepartment.ID
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GetData();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetData();
            }
        }

        private void btnServices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = dossierBindingSource.Current as Dossier;
            if (cur == null)
            {
                MessageBox.Show("لطفا ابتدا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cur);
            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cur.GivenServiceMs);
            cur.GsmPayed = cur.GivenServiceMs.Any(c => (c.ServiceCategoryID == (int)Category.خدمات_کلینیکی
                            || c.ServiceCategoryID == (int)Category.لوازم_مصرفی) && c.Payed);
            if (cur.GsmPayed == false)
            {
                MessageBox.Show("هیچ خدمتی از این پرونده پرداخت نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new dlgGivenServices(cur, dc);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
            }
            else
            {
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.lstGSD);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnServices_ItemClick(null, null);
        }
    }
}