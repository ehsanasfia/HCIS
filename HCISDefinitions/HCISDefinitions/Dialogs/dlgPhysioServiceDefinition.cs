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
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgPhysioServiceDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { set; get; }
        public Service ObjectSRV;
        public DiagnosticServiceDetail ObjectDSD;
        int? Wcode;
        public dlgPhysioServiceDefinition()
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectSRV == null)
            {
                ObjectSRV = new Service();
            }
            if (ObjectDSD == null)
            {
                ObjectDSD = new DiagnosticServiceDetail();
            }
            else
            {
                Wcode = ObjectDSD.Code;
            }
            ServiceBindingSource.DataSource = ObjectSRV;
            DetailBindingSource.DataSource = ObjectDSD;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                    if (ObjectDSD.Code != Wcode)
                    {
                        if (dc.DiagnosticServiceDetails.Any(x => x.Code == ObjectDSD.Code && x.Service != null && x.Service.CategoryID == (int)Category.فیزیوتراپی))
                        {
                            MessageBox.Show("این نام کوتاه قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                    }

                    ObjectDSD.Service = ObjectSRV;
                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID) && !dc.DiagnosticServiceDetails.Any(x => x.ID == ObjectDSD.ID))
                {
                    ObjectSRV.CategoryID = (int)Category.فیزیوتراپی;
                    dc.Services.InsertOnSubmit(ObjectSRV);
                    //dc.DiagnosticServiceDetails.InsertOnSubmit(ObjectDSD);
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