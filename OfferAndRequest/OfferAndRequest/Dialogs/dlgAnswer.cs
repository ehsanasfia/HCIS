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
namespace OfferAndRequest.Dialogs
{
    public partial class dlgAnswer : DevExpress.XtraEditors.XtraForm
    {
        public OfferAndRequestDataContexDataContext dc { get; set; }
        public CommentAndRequest C { get; set; }
        public dlgAnswer()
        {
            InitializeComponent();
        }

        private void dlgAnswer_Load(object sender, EventArgs e)
        {
            memoEdit1.Text = C.Answer;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}