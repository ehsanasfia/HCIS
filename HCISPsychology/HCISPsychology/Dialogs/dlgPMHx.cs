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
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{

    public partial class dlgPMHx : DevExpress.XtraEditors.XtraForm
    {
        public HCISPsychologyClassesDataContext dc { get; set; }
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
                givenServiceMBindingSource.EndEdit();
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.PersonID == person.ID && x.ServiceCategoryID == (int)Category.ویزیت && x.Visit != null).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null || current.Visit == null)
            {
                lkpIMP.Text = "پر نشده است";
                lkpDDX1.Text = "پر نشده است";
                lkpDDX2.Text = "پر نشده است";
            }
            
            lkpIMP.Text = current.Visit.ICD10 == null ? "پر نشده" : current.Visit.ICD10.NameE;
            lkpDDX1.Text = current.Visit.ICD101 == null ? "پر نشده" : current.Visit.ICD101.NameE;
            lkpDDX2.Text = current.Visit.ICD102 == null ? "پر نشده" : current.Visit.ICD102.NameE;
            cmbSince.Text = current.Visit.Since == null ? "پر نشده" : current.Visit.Since.ToString();
            cmbAgo.Text = current.Visit.Ago == null ? "پر نشده" : current.Visit.Ago.ToString();
            txtCC.Text = current.Visit.ChiefComplaint == null ? "پر نشده" : current.Visit.ChiefComplaint;
            memComment.Text = current.Visit.Comment == null ? "پر نشده" : current.Visit.Comment;
            memDocument.Text = current.Visit.AccompanyingDocument == null ? "پر نشده" : current.Visit.AccompanyingDocument;
        }
    }
}