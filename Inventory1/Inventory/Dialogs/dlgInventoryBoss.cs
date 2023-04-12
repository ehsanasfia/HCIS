using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
namespace Inventory.Dialogs
{
    public partial class dlgInventoryBoss : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public RequestD RD { get; set; }
        public dlgInventoryBoss()
        {
            InitializeComponent();
        }

        private void dlgInventoryBoss_Load(object sender, EventArgs e)
        {
            GetData();

        }
        private void GetData()
        {
            productBindingSource.DataSource = dc.Products.ToList();
            lkpProduct.EditValue = RD.IDProduct;
            txtAmountRequest.Text = RD.AmountRequest + "";
            txtDelivery.Text = RD.AmountDelivery + "";
            txtAmountSub.Text = RD.AmountSub + "";
            textEdit5.Text = RD.PMRLP;
            checkEdit1LP.Checked = RD.LPWarHousekeeper;
            checkEdit2PMR.Checked = RD.PMRWarHousekeeper;
            textEdit5.Text = RD.PMRLPWarHousekeeper;
            txtAmountPMRLP.Text = RD.AmountPMRLP + "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtAmountPMRLP.Text == "")
            {
                MessageBox.Show("مقدار PMR LPوارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (textEdit5.Text == "")
            {
                MessageBox.Show("فرم PMR یا LP را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //  RequestD u = new RequestD();
            RD.AmountPMRLP = Int32.Parse(txtAmountPMRLP.Text);
            RD.PMRLPWarHousekeeper = textEdit5.Text;
            RD.LPWarHousekeeper = checkEdit1LP.Checked;
            RD.PMRWarHousekeeper = checkEdit2PMR.Checked;

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkEdit1LP_EditValueChanged(object sender, EventArgs e)
        {
            if (checkEdit1LP.Checked == true)
            {
                
                checkEdit2PMR.Checked = false;
                textEdit5.Text = "LP";
            }

            else if (checkEdit1LP.Checked == false)
            {
                textEdit5.Text = "";
            }

        }

        private void checkEdit2PMR_EditValueChanged(object sender, EventArgs e)
        {

            if (checkEdit2PMR.Checked == true)
            {
               
                checkEdit1LP.Checked =false;
                textEdit5.Text = "PMR";
            }

            else if (checkEdit2PMR.Checked == false)
            {
                textEdit5.Text = "";
            }
        }
    }
}