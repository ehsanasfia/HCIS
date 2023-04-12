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
using HCISFinance.Data;

namespace HCISFinance.Dialogs
{
    public partial class dlgIncomeTypeDef : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { set; get; }
        public CostType ObjectCST;

        public dlgIncomeTypeDef()
        {
            InitializeComponent();
        }

        private void dlgIncomeTypeDef_Load(object sender, EventArgs e)
        {
            if (ObjectCST == null)
            {
                ObjectCST = new CostType();
            }

            CostTypeBindingSource.DataSource = ObjectCST;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dc.CostTypes.Any(x => x.ID == ObjectCST.ID))
                {
                    ObjectCST.Income = true;
                    dc.CostTypes.InsertOnSubmit(ObjectCST);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }
    }
}