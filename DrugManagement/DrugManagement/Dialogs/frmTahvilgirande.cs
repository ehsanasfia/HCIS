using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class frmTahvilgirande : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public DrugTransferee C { get; set; }
        public bool isEdit { get; set; }
        public frmTahvilgirande()
        {
            InitializeComponent();
        }

        private void frmTahvilgirande_Load(object sender, EventArgs e)
        {
            if(isEdit == true)
            {
                txtN.Text = C.FName;
                txtLname.Text = C.LName;
                txtTel.Text = C.Tel;
                mmdAddress.Text = C.Address;
                txtNationalCode.Text = C.NatioalCode;
                txtNum.Text = C.Number;

            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
             
                C.FName = txtN.Text;
                C.LName = txtLname.Text;
                C.Tel = txtTel.Text;
                C.Address = mmdAddress.Text;
                C.NatioalCode = txtNationalCode.Text;
                C.Number = txtNum.Text;
                dc.SubmitChanges();
            }
            if (isEdit == false)
            {
                DrugTransferee u = new DrugTransferee();
                u.FName = txtN.Text;
                u.LName = txtLname.Text;
                u.Tel = txtTel.Text;
                u.Address = mmdAddress.Text;
                u.NatioalCode = txtNationalCode.Text;
                u.Number = txtNum.Text;
                dc.DrugTransferees.InsertOnSubmit(u);
                dc.SubmitChanges();
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }
    }
}