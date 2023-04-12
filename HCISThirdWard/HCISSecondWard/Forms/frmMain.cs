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
using SecurityLoginsAndAccessControl;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
using HCISSecondWard.Dialogs;

namespace HCISSecondWard.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmMain()
        {
            InitializeComponent();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            var Rpc = new UserPermissionsController(Classes.MainModule.UserName, "HCISSecondWard");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(Classes.MainModule.UserName, this.Name, ribbonControl1, "HCISSecondWard");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(Classes.MainModule.UserName, "HCISSecondWard");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var diag = new dialogLogin();
            if (diag.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (var form in MdiChildren)
                form.Close();
            Classes.MainModule.UserID = diag.User.UserID;
            Classes.MainModule.UserName = diag.UserName;
            Classes.MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
            // btnUserManagement.PerformClick();
            Classes.MainModule.AppID = diag.User.ApplicationID;
            bsiUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            GetUserPermission();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(Classes.MainModule.MyDepartment!=null)
            bsiWardName.Caption = "نام بخش: " + Classes.MainModule.MyDepartment.Name;
            Classes.MainModule.icd = dc.ICD10s.ToList();
            GetUserPermission();
            //barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem11.Enabled = true;
            var frm = new frmPatientList();
            ShowForm(frm);
            if (frm.DialogResult == DialogResult.OK)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        void ShowForm(Form frm)
        {
            foreach (var form in MdiChildren) form.Close();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if(MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            if(MainModule.GSM_Set.Confirm == true && MainModule.GSM_Set.WardEdit == false)
            {
                MessageBox.Show("این بیمار ترخیص یا انتقال داده شده است");
                return;
            }
            MainModule.Action = "Secretary";
            var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
            if (clinicStaff != null)
            {
                MainModule.MyStaff = new HCISDataContext().Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);

            }
            else
            {
                if (MainModule.MyStaff == null)
                {
                    bbiSelectDoctor.PerformClick();
                }
            }

            var frm = new Forms.frmWardDoctor();
            ShowForm(frm);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            if (MainModule.GSM_Set.Confirm == true && MainModule.GSM_Set.WardEdit == false)
            {
                MessageBox.Show("این بیمار ترخیص یا انتقال داده شده است");
                return;
            }
            MainModule.Action = "Nurse";
            var frm = new Forms.frmWardNurse();
            ShowForm(frm);
        }

        private void bbiAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAdmissionList();
            ShowForm(frm);
        }


        private void bbiBed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmBedDefinition();
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgStart();
            dlg.ShowDialog();
            bsiWardName.Caption = "نام بخش" +" " + Classes.MainModule.MyDepartment.Name;
        }

        private void bbiSelectDoctor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectDr();
            if (dlg.ShowDialog() == DialogResult.OK)
                bsiDrName.Caption = "نام پزشک" + " " + Classes.MainModule.MyStaff.Person.FirstName + " " + Classes.MainModule.MyStaff.Person.LastName;
            else
            {
                MessageBox.Show("بدون انتخاب پزشک امکان ثبت اطلاعات پزشکی بیمار امکان پذیر نیست");
                bbiSelectDoctor.PerformClick();
            }
            //  Classes.MainModule.MyStaff=
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugRequest();
            ShowForm(a);
        }

        private void bbiSerach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSearchBastari()
            {
                AllowDeleteServices = barButtonItem8.Visibility == DevExpress.XtraBars.BarItemVisibility.Always,
                AllowEditRefrences = barButtonItem9.Visibility == DevExpress.XtraBars.BarItemVisibility.Always
            };

            dlg.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmPanelDefinition();
            ShowForm(frm);
        }

        private void btnDischargePatients_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDischargedPatients();
            ShowForm(frm);
        }

        private void btnWardTransport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Dialogs.dlgWardTrasport();
            frm.DepID = MainModule.MyDepartment.ID;
            frm.ShowDialog();
        }

        private void btnAdmitDializ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSpecialAdmit();
            ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmCashBastari2();
            ShowForm(f);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmEditReference() { dc = dc };
            ShowForm(f);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmDrugtemplate();
            ShowForm(f);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmPatientList();
            ShowForm(f);
            if(f.DialogResult == DialogResult.OK)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void btnAnbarGardani_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmWarehouseHandling();
            ShowForm(a);
        }

        private void btnDrugDelivery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugDelivery();
            ShowForm(a);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmStock();
            ShowForm(a);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmWardDrugPation();
            ShowForm(a);
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmStockEs();
            ShowForm(a);
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgArchive();
            a.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmConsumerGoodsTemplate();
            ShowForm(a);
        }

        private void btnDischargeRpt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmPatientDischargeStatus();
            ShowForm(a);
        }

        private void bbiSelectPrinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectPrinter();
            dlg.ShowDialog();
        }

        private void btnDeathCertificate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDeathCertificate();
            dlg.ShowDialog();
        }
    }
}