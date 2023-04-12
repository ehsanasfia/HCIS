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
using Inventory.Data;
using Inventory.Forms;
using Inventory.Dialogs;

namespace Inventory.Dialogs
{
    public partial class dlgProvider : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Provider PHT { get; set; }
        public dlgProvider()
        {
            InitializeComponent();
        }

        private void dlgProvider_Load(object sender, EventArgs e)
        {

            if (isEdit == true)
            {
                txtName.Text = PHT.Name ;
                txtManager.Text= PHT.Manager;
                mmdAddress.Text = PHT.Address + "";
                txtTel.Text = PHT.Tel + "";
                txtAvailable.Text = PHT.Available;
                mmdDescription.Text = PHT.Description;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                PHT = new Provider();
            }
            PHT.Name = txtName.Text;
            PHT.Manager = txtManager.Text;
            PHT.Address = mmdAddress.Text;
            PHT.Tel = txtTel.Text;
            PHT.Available = txtAvailable.Text;
            PHT.Description = mmdDescription.Text;

            if (isEdit == false)
                dc.Providers.InsertOnSubmit(PHT);





            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }
    }
}