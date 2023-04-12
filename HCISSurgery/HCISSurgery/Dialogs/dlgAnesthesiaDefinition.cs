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
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgAnesthesiaDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { set; get; }
        public Service ObjectSRV;
        public DiagnosticServiceDetail ObjectDSD;
        int? Wcode;
        public dlgAnesthesiaDefinition() 
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectSRV == null)
            {
                ObjectSRV = new Service();
            }
            if(ObjectDSD == null)
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
                    if (dc.DiagnosticServiceDetails.Any(x => x.Code == ObjectDSD.Code && x.Service != null && x.Service.CategoryID == (int)Category.بیهوشی))
                    {
                        MessageBox.Show("این نام کوتاه قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                if (ObjectSRV.BasicK == null)
                {
                    MessageBox.Show("لطفا K را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectSRV.SupplementBasicK == null)
                {
                    MessageBox.Show("لطفا K را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                ObjectDSD.Service = ObjectSRV;
                var anst = dc.Services.FirstOrDefault(c => c.ParentID == null && c.CategoryID == (int)Category.بیهوشی && c.Name == "عمل");
                if (anst == null)
                {
                    anst = new Service()
                    {
                        ParentID = null,
                        Name = "عمل",
                        CategoryID = (int)Category.بیهوشی,
                    };
                    dc.Services.InsertOnSubmit(anst);
                }
                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID) && !dc.DiagnosticServiceDetails.Any(x => x.ID == ObjectDSD.ID))
                {
                    ObjectSRV.CategoryID = (int)Category.بیهوشی;
                    ObjectSRV.Service1 = anst;
                    dc.Services.InsertOnSubmit(ObjectSRV);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
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