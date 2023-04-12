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
    public partial class dlgEditServiceCode : DevExpress.XtraEditors.XtraForm
    {
        public dlgEditServiceCode()
        {
            InitializeComponent();
        }

        public DoctorFunction CurrentDocFunction { get; set; }

        public HCISDataContexDataContext dc { get; set; }
        //HCISDataContexDataContext dc = new HCISDataContexDataContext();
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length == 0)
            {
                MessageBox.Show("لطفاً کد را وارد نمایید.","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                return;
            }

            var rvu = dc.RVUs.SingleOrDefault(c => c.NationalID.CompareTo(textEdit1.Text) == 0);
            if (rvu == null)
            {
                MessageBox.Show("کد وارد شده در کتابچه ثبت نشده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                return;
            }
            CurrentDocFunction.Service.SalamatBookletCode = textEdit1.Text;
            CurrentDocFunction.JozeHerfeyi = (rvu.Joze_Herfeyi_26 ?? 0) * CurrentDocFunction.Amount;
            CurrentDocFunction.TotalK = ((rvu.Joze_Herfeyi_26 ?? 0) + (rvu.Joze_Fanni_27 ?? 0)) * CurrentDocFunction.Amount;

            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dlgEditServiceCode_Load(object sender, EventArgs e)
        {
            //var d = dc.DoctorFunctions.First(c => c.ID == CurrentDocFunction.ID);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}