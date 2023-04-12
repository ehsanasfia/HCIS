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
using OfferAndRequest;

namespace OfferAndRequest.Dialogs
{
    public partial class dlgRegComment : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit { get; set; }
        public OfferAndRequestDataContexDataContext dc { get; set; }
        public CommentAndRequest O { get; set; }
        public dlgRegComment()
        {
            InitializeComponent();
        }

        private void dlgRegComment_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void btnok_Click_1(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                CommentAndRequest u = new CommentAndRequest();
                u.tel = txtTel.Text;
                u.Description = txtDes.Text;
                u.ApplicationName = txtApp.Text;
                u.Subject = txtSub.Text;
                u.CreatorUserID = MainModule.UserID;
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreatorUsername = MainModule.LastName;
                dc.CommentAndRequests.InsertOnSubmit(u);
            }
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}