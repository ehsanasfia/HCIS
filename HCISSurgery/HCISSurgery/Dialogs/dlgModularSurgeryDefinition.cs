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
    public partial class dlgModularSurgeryDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { set; get; }
        public Service ObjectSRV;

        public dlgModularSurgeryDefinition() 
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
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
                var tdli = dc.Services.FirstOrDefault(c => c.ParentID == null && c.CategoryID == (int)Category.خدمات_جراحی && c.Name == "خدمات تعدیلی");
                if (tdli == null)
                {
                    tdli = new Service()
                    {
                        ParentID = null,
                        Name = "خدمات تعدیلی",
                        CategoryID = (int)Category.خدمات_جراحی,
                    };
                    dc.Services.InsertOnSubmit(tdli);
                }
                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID))
                {

                    ObjectSRV.CategoryID = (int)Category.خدمات_جراحی;
                    ObjectSRV.Service1 = tdli;
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