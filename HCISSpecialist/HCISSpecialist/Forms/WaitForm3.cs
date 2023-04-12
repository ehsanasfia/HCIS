using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace HCISSpecialist.Forms
{
    public partial class WaitForm3 : WaitForm
    {
        public WaitForm3()
        {
            InitializeComponent();
            
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(labelControl1.Text);
            this.labelControl1.Text = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(labelControl1.Text);
            this.labelControl1.Text = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.LoadDrug)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری داروها";

            }
            else if (command == WaitFormCommand.LoadTest)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری آزمایشات";
            }
            else if (command == WaitFormCommand.LoadPara)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری خدمات پاراکلینیکی";
            }
            else if (command == WaitFormCommand.LoadPhisio)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری فیزیوتراپی";
            }
            else if (command == WaitFormCommand.LoadICD)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری تشخیص ها";
            }

            else if (command == WaitFormCommand.LoadDiag)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری خدمات تشخیصی";
            }
            else if (command == WaitFormCommand.LoadFav)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری خدمات پرکاربرد";
            }
            else if (command == WaitFormCommand.LoadPato)
            {
                progressBarControl1.EditValue = arg;
                labelControl1.Text = "در حال بارگیری پاتولوژی";
            }
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
            LoadDrug,
            LoadTest,
            LoadPara,
            LoadDiag,
            LoadFav,
            LoadICD,
            LoadPato,
            LoadPhisio
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            
        }
    }
}