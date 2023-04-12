using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;
using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISCash.Dialogs
{
    public partial class dlgAdvancePayment : DevExpress.XtraEditors.XtraForm
    {
        public dlgAdvancePayment()
        {
            InitializeComponent();
        }
        public decimal AdvancePayment = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConditionValidationRule notEmpty = new ConditionValidationRule();
            notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty.ErrorText = ". وارد کردن مبلغ الزامی است";
            dxValidationProvider1.SetValidationRule(txtAdvancePayment, notEmpty);
            if (!dxValidationProvider1.Validate())
                return;
            AdvancePayment =decimal.Parse (txtAdvancePayment.Text);
            DialogResult = DialogResult.OK;
        }
    }
}