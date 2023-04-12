using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgDrugDelivery : DevExpress.XtraEditors.XtraForm
    {
        public RequestDMg RDMG { get; set; }
        public RequestD RD { get; set; }
        public HCISDataContexDataContext dc;
        public dlgDrugDelivery()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgDrugDelivery_Load(object sender, EventArgs e)
        {
            if (RD == null)
            {
                return;
            }
                txtDrugName.EditValue = RD.Service.Name;
                txtAmountDelivery.Text = RD.Amount.ToString();
            

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (RDMG == null)
            {
                if (RD.Amount > Int32.Parse(txtAmountDelivery.Text))
                {
                    RD.Indent = true;
                    RD.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                    RD.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                    RD.AmountDeliveryUser = MainModule.UserID;
                }
                else if (RD.Amount <= Int32.Parse(txtAmountDelivery.Text))
                {
                    RD.Indent = false;
                    RD.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                    RD.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                    RD.AmountDeliveryUser = MainModule.UserID;
                }
                RD.AmountDelivery = Int32.Parse(txtAmountDelivery.Text);

                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (RDMG.Amount > Int32.Parse(txtAmountDelivery.Text))
                {
                    RDMG.Indent = true;
                    RDMG.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                    RDMG.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                    RDMG.AmountDeliveryUser = MainModule.UserID;
                }
                else if (RDMG.Amount <= Int32.Parse(txtAmountDelivery.Text))
                {
                    RDMG.Indent = false;
                    RDMG.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                    RDMG.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                    RDMG.AmountDeliveryUser = MainModule.UserID;
                }
                RDMG.AmountDelivery = Int32.Parse(txtAmountDelivery.Text);

                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
        }
    }
}