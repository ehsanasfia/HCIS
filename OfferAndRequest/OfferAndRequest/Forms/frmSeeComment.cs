using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OfferAndRequest.Data;
using OfferAndRequest.Dialogs;
namespace OfferAndRequest.Forms
{
    public partial class frmSeeComment : DevExpress.XtraEditors.XtraForm
    {
        OfferAndRequestDataContexDataContext dc = new OfferAndRequestDataContexDataContext();
        public frmSeeComment()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmSeeComment_Load(object sender, EventArgs e)
        {
            commentAndRequestBindingSource.DataSource = dc.CommentAndRequests.ToList(); 
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            var cu = commentAndRequestBindingSource.Current as CommentAndRequest;
            var dlg = new dlganswering();
            dlg.Text = "پاسخ";
            dlg.dc = dc;
            dlg.C = cu;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                MessageBox.Show("اطلاعات با موفقیت ثبت  گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                commentAndRequestBindingSource.DataSource = dc.CommentAndRequests.ToList();
            }
        }
    }
}