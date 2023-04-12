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

namespace OfferAndRequest.Dialogs
{
    public partial class dlganswering : DevExpress.XtraEditors.XtraForm
    {
        public OfferAndRequestDataContexDataContext dc { get; set; }
        public CommentAndRequest C { get; set; }
        public dlganswering()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlganswering_Load(object sender, EventArgs e)
        {
            memoEdit1.Text = C.Answer;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            C.Answer = memoEdit1.Text;
            C.AnswerBit = true;
            DialogResult = DialogResult.OK;
        }
    }
}