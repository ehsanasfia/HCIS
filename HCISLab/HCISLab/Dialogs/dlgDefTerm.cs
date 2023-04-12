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
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgDefTerm : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        public dlgDefTerm()
        {
            InitializeComponent();
        }

        private void dlgDefTerms_Load(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            try
            {
                labTermBindingSource.DataSource = dc.LabTerms;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                labTermBindingSource.EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("اطلاعات با موفقیت ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row != null)
                if (dc.LabTerms.Any(c => c.TermText == (e.Row as LabTerm).TermText))
                {
                    MessageBox.Show("این کلمه کلیدی تکراری می باشد");
                    labTermBindingSource.Remove(e.Row as LabTerm);
                }

        }

        private void btnRemove_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var trm = labTermBindingSource.Current as LabTerm;
                if (trm == null)
                    return;

                if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;

                labTermBindingSource.RemoveCurrent();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در حذف اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}