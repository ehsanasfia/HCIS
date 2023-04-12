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
    public partial class dlgDefPanel : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        public dlgDefPanel()
        {
            InitializeComponent();
        }

        private void dlgDefPanel_Load(object sender, EventArgs e)
        {
            try
            {
                servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش).OrderBy(x => x.Name);
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
                servicesBindingSource.EndEdit();
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

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var srv = servicesBindingSource.Current as Service;
            if (srv == null)
                return;

            //if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            //    return;

            
            treeList1.DeleteSelectedNodes();
        }
    }
}