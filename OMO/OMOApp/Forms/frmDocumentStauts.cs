using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;

namespace OMOApp.Forms
{
    public partial class frmDocumentStauts : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        public frmDocumentStauts()
        {
            InitializeComponent();
        }

        private void frmDocumentStauts_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = txtTodate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            vwUserToDoBindingSource.DataSource = dc.Vw_UserToDos.Where(x => x.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && x.AdmitDate.CompareTo(txtTodate) <= 0).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = true;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                colSpirometryDate.Visible =
                colSpiroUser.Visible = true;
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = false;
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                colPsychologyDate.Visible =
                colPsychoUser.Visible = true;
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = false;
            }
            else if (radioGroup1.SelectedIndex == 3)
            {
                colAudioUser.Visible =
                colAudioDate.Visible = true;
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = false;
            }
            else if (radioGroup1.SelectedIndex == 4)
            {
                colOptometryDate.Visible =
                colOptoUser.Visible = true;
                colAudioUser.Visible =
                colAudioDate.Visible =
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = false;
            }
            else if (radioGroup1.SelectedIndex == 5)
            {
                colNursingDate.Visible =
                colNursingUser.Visible = true;
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible =
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = false;
            }

            else if (radioGroup1.SelectedIndex == 6)
            {
                colCheckUpDate.Visible =
                colCheckUpUser.Visible = true;
                colNursingDate.Visible =
                colNursingUser.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colSpirometryDate.Visible =
                colSpiroUser.Visible =
                colResultDate.Visible =
                colResultLastName.Visible = false;

            }

            else if (radioGroup1.SelectedIndex == 6)
            {
                colResultDate.Visible =
               colResultLastName.Visible = true;
                colCheckUpDate.Visible =
                colCheckUpUser.Visible =
                colNursingDate.Visible =
                colNursingUser.Visible =
                colOptometryDate.Visible =
                colOptoUser.Visible =
                colAudioUser.Visible =
                colAudioDate.Visible =
                colPsychologyDate.Visible =
                colPsychoUser.Visible =
                colSpirometryDate.Visible =
                colSpiroUser.Visible = false;
            }

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ClearDocument();
            var hf = printableComponentLink1.PageHeaderFooter as DevExpress.XtraPrinting.PageHeaderFooter;
            hf.Header.Content[1] = String.Format("[Image 0]\r\nگزارش وضعیت پرونده ها\r\nاز تاریخ {0} لغایت {1}", txtFromDate.Text, txtTodate.Text);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}