using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;

namespace HCISContracts.Dialogs
{
    public partial class dlgDoctorSalaryParams : DevExpress.XtraEditors.XtraForm
    {
        public Data.HCISDataContexDataContext dc;
        public Guid staffID;
        public string date;

        //List<DoctorSalaryParam> lst = new List<DoctorSalaryParam>();

        public dlgDoctorSalaryParams()
        {
            InitializeComponent();
        }


        private void dlgDoctorSalaryParams_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dsp = new DoctorSalaryParam()
            {
              
                StaffID = staffID,
                Date = date,
                ParamName = txtParamName.Text,
                ParamValue = clcParamValue.Value,
                CreatorUserID = Classes.MainModule.UserID

            };
            dc.DoctorSalaryParams.InsertOnSubmit(dsp);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                if (clcParamValue.Value < 0)
                    clcParamValue.Value = clcParamValue.Value * -1;
                else
                    clcParamValue.Value = clcParamValue.Value * 1;
            }
            if (radioGroup1.SelectedIndex == 1)
            {
                if (clcParamValue.Value < 0)
                    clcParamValue.Value = clcParamValue.Value * 1;
                else
                    clcParamValue.Value = clcParamValue.Value * -1;
            }
        }
    }
}