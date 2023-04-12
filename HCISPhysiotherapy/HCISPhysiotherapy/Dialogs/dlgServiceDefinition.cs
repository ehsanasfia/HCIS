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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgServiceDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { set; get; }
        public Service ObjectSRV;
        int? Wcode;

        public dlgServiceDefinition()
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectSRV == null)
            {
                ObjectSRV = new Service();
            }
            else
            {
                Wcode = ObjectSRV.OldID;
            }
            ServiceBindingSource.DataSource = ObjectSRV;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjectSRV.OldID != Wcode)
                {
                    if (dc.Services.Any(x => x.OldID == ObjectSRV.OldID && x.CategoryID == (int)Category.فیزیوتراپی))
                    {
                        MessageBox.Show("این نام کوتاه قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                
                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID))
                {
                    ObjectSRV.CategoryID = (int)Category.فیزیوتراپی;
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
    }
}