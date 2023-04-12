using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BloodBank.Forms;
using BloodBank.Data;
using BloodBank.Dialogs;


namespace BloodBank.Forms
{
    public partial class frmRequest : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmRequest()
        {
            InitializeComponent();
        }


        private void frmRequest_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

        }
        private void GetData()
        {
            vwBloodBankMainBindingSource.DataSource = dc.Vw_BloodBankMains.Where(c=>  c.Date.CompareTo(txtFromDate.Text) >= 0 && c.Date.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.Date).ThenByDescending(c => c.Time).ToList();                
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
            if (current == null)
            {
                return;
            }
          
            {
                var z = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
                if (z == null)
                {
                    return;
                }
                var dlg = new dlgRequest();
                dlg.Text = "درخواست خون";
                dlg.Doc = z;
                dlg.isEditt = false;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        dc.SubmitChanges();
                        MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    catch
                    {
                        MessageBox.Show("ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {

            vwBloodBankMainBindingSource.DataSource = dc.Vw_BloodBankMains.Where(c => c.Date.CompareTo(txtFromDate.Text) >= 0 && c.Date.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.Date).ThenByDescending(c => c.Time).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {

            vwBloodBankMainBindingSource.DataSource = dc.Vw_BloodBankMains.Where(c => c.Date.CompareTo(txtFromDate.Text) >= 0 && c.Date.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.Date).ThenByDescending(c => c.Time).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
            if (current == null)
            {
                return;
            }
         
            {
                var z = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
                if (z == null)
                {
                    return;
                }
                var dlg = new dlgRequest();
                dlg.Text = "درخواست خون";
                dlg.Doc = z;
                dlg.isEditt = false;
                dlg.dc = dc;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        dc.SubmitChanges();
                        MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    catch
                    {
                        MessageBox.Show("ثبت با خطا مواجه است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
            }
        }
    }
    
}