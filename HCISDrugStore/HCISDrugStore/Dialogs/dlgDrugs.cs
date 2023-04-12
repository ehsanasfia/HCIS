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
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgDrugs : DevExpress.XtraEditors.XtraForm
    {
        public HCISDrugStoreClassesDataContext dc { set; get; }
        public Service ObjectSRV;
        public dlgDrugs()
        {
            InitializeComponent();
        }

        private void dlgDrugs_Load(object sender, EventArgs e)
        {
            if (ObjectSRV == null)
            {
                ObjectSRV = new Service();
            }

            ServiceBindingSource.DataSource = ObjectSRV;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID))
                {
                    ObjectSRV.CategoryID = (int)Category.دارو;
                    dc.Services.InsertOnSubmit(ObjectSRV);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}