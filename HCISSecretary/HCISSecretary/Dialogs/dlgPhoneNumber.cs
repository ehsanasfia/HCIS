using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISSecretary.Dialogs
{
    public partial class dlgPhoneNumber : DevExpress.XtraEditors.XtraForm
    {
        public dlgPhoneNumber()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public String PhoneNumber = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Trim().Length >= 8)
            {
                PhoneNumber = textEdit1.Text;

                this.DialogResult = DialogResult.OK;
            }
            else
            { MessageBox.Show("شماره تماس اشتباه است"); } }

    }
}