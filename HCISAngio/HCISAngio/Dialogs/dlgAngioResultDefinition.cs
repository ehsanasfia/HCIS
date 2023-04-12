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
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Dialogs
{
    public partial class dlgAngioResultDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { set; get; }
        public AngioResult ObjectAR;

        public dlgAngioResultDefinition() 
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectAR == null)
            {
                ObjectAR = new AngioResult();
            }

            AResultBindingSource.DataSource = ObjectAR;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(ObjectAR.ID == 0)
                {
                    dc.AngioResults.InsertOnSubmit(ObjectAR);
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