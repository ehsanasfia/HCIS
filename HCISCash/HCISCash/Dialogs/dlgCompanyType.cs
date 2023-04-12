using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISCash.Dialogs
{
    public partial class dlgCompanyType : DevExpress.XtraEditors.XtraForm
    {
        public dlgCompanyType()
        {
            InitializeComponent();
        }
        public bool CompanyType { get; set; }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var x = Boolean.Parse(radioGroup1.EditValue.ToString());
            if (CompanyType)
            {
                if (x)
                    MainModule.CompanyTypeSelected = "شرکتی";
                else
                    MainModule.CompanyTypeSelected = "غیرشرکتی";

                Properties.Settings.Default.CompanyType = x.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                if (x)
                    MainModule.CompanyTypeSelected = "شرکتی";
                else
                    MainModule.CompanyTypeSelected = "غیرشرکتی";
            }
            DialogResult = DialogResult.OK;
        }

        private void dlgCompanyType_Load(object sender, EventArgs e)
        {

            if (!CompanyType)
            {
                string dep = Properties.Settings.Default.CompanyType;
                if (string.IsNullOrWhiteSpace(dep))
                {
                    CompanyType = true;
                }
            }
            if (!CompanyType)
            {
                string CompanyTypeStr = Properties.Settings.Default.CompanyType;
                var CompanyTypeBool = Boolean.Parse(CompanyTypeStr);

                if (CompanyTypeBool)
                {
                    MainModule.CompanyTypeSelected = "شرکتی";
                    radioGroup1.EditValue = true;
                }
                else
                {
                    MainModule.CompanyTypeSelected = "غیرشرکتی"; ;
                    radioGroup1.EditValue = false;
                } DialogResult = DialogResult.OK;
            }
        }
    }
}