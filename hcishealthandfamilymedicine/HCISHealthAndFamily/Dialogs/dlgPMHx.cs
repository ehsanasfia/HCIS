using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;

namespace HCISHealthAndFamily.Dialogs
{

    public partial class dlgPMHx : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public dlgPMHx()
        {
            InitializeComponent();
        }

        private void memoEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void dlgPMHx_Load(object sender, EventArgs e)
        {
            try
            {
                //givenServiceMBindingSource.EndEdit();
                getPMHxResultBindingSource.DataSource = dc.GetPMHx(person.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void getPMHxResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = getPMHxResultBindingSource.Current as GetPMHxResult;
            if (current == null)
            {
                lkpIMP.Text = "پر نشده است";
                lkpDDX1.Text = "پر نشده است";
                lkpDDX2.Text = "پر نشده است";
                lkpIMP.Text = "پر نشده است";
                lkpDDX1.Text = "پر نشده است";
                lkpDDX2.Text = "پر نشده است";
                cmbSince.Text = "پر نشده است";
                cmbAgo.Text = "پر نشده است";
                txtCC.Text = "پر نشده است";
                memComment.Text = "پر نشده است";
                memDocument.Text = "پر نشده است";
                return;
            }

            lkpIMP.Text = current.IMP == null ? "پر نشده" : current.IMP;
            lkpDDX1.Text = current.DDx1 == null ? "پر نشده" : current.DDx1;
            lkpDDX2.Text = current.DDx2 == null ? "پر نشده" : current.DDx2;
            cmbSince.Text = current.Since == null ? "پر نشده" : current.Since.ToString();
            cmbAgo.Text = current.Ago == null ? "پر نشده" : current.Ago;
            txtCC.Text = current.ChiefComplaint == null ? "پر نشده" : current.ChiefComplaint;
            memComment.Text = current.Comment == null ? "پر نشده" : current.Comment;
            memDocument.Text = current.AccompanyingDocument == null ? "پر نشده" : current.AccompanyingDocument;

        }
    }
}