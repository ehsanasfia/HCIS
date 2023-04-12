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
    public partial class dlgCompany : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public Company C { get; set; }
        public bool isEdit { get; set; }
        public dlgCompany()
        {
            InitializeComponent();
        }

        private void dlgCompany_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                txtCompanyName.Text = C.CompanyName;
                txtResponsible.Text = C.Responsible;
                txtResponsibleMobail.Text = C.ResponsibleMobail;
                txtTel.Text = C.Tel;
                txtPostalCode.Text = C.PostalCode;
                mmdAdreess.Text = C.Adreess;
                txtNum.Text = C.Number;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                C.CompanyName = txtCompanyName.Text;
                C.Responsible = txtResponsible.Text;
                C.ResponsibleMobail = txtResponsibleMobail.Text;
                C.Tel = txtTel.Text;
                C.PostalCode = txtPostalCode.Text;
                C.Adreess = mmdAdreess.Text;
                C.Number = txtNum.Text;
            }
            else
            {
                Company u = new Company();
                u.CompanyName = txtCompanyName.Text;
                u.Responsible = txtResponsible.Text;
                u.ResponsibleMobail = txtResponsibleMobail.Text;
                u.Tel = txtTel.Text;
                u.PostalCode = txtPostalCode.Text;
                u.Number = txtNum.Text;
                u.Adreess = mmdAdreess.Text;
                dc.Companies.InsertOnSubmit(u);
            }
            DialogResult = DialogResult.OK;
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}