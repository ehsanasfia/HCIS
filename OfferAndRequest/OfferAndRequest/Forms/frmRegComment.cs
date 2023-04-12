using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OfferAndRequest.Data;
using OfferAndRequest.Dialogs;
using OfferAndRequest;

namespace OfferAndRequest.Forms
{
    public partial class frmRegComment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OfferAndRequestDataContexDataContext dc = new OfferAndRequestDataContexDataContext();
        public frmRegComment()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmRegComment_Load(object sender, EventArgs e)
        {
 
            GetData();
        }
        private void GetData()
        {
            commentAndRequestBindingSource.DataSource = dc.CommentAndRequests.Where(c => c.CreatorUserID == MainModule.UserID).ToList();
        }
        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgRegComment();
            dlg.Text = "ثبت درخواست وپیشنهادات";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                MessageBox.Show("اطلاعات با موفقیت ثبت  گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                GetData();
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var cu = commentAndRequestBindingSource.Current as CommentAndRequest;
            var dlg = new dlgAnswer();
            dlg.Text = "پاسخ";
            dlg.dc = dc;
            dlg.C = cu;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                MessageBox.Show("اطلاعات با موفقیت ثبت  گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                GetData();
            }
        }
    }
}