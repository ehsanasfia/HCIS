using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecondWard.Data;

namespace HCISSecondWard.Forms
{
    public partial class frmEditReference : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmEditReference()
        {
            InitializeComponent();
        }
        public HCISDataContext dc { get; set; }

        public Dossier Dossier { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            this.Dossier = dc.Dossiers.SingleOrDefault(c => c.ID == int.Parse(txtDossierNumber.EditValue.ToString()));
            if (Dossier != null)
                if (Dossier.LockBilling == true)
                {
                    MessageBox.Show("این پرونده قفل می باشد "); return;

                }
            givenServiceMBindingSource.DataSource = Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();

            txtDischargeDate.Enabled = false;
            txtDischargeTime.Enabled = false;
            if (Dossier.Discharge1 != null)
            {
                txtDischargeDate.Enabled = true;
                txtDischargeTime.Enabled = true;
                txtDischargeDate.EditValue = Dossier.Discharge1.DischargeDate;
                txtDischargeTime.EditValue = Dossier.Discharge1.DischargeTime;
            }
        }

        private void bbiConfirm_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtDischargeDate.Enabled)
            {
                Dossier.Discharge1.DischargeDate = txtDischargeDate.Text;
                Dossier.Discharge1.DischargeTime = txtDischargeTime.Text;
            }
            try
            {
                gridView1.CloseEditForm();
                gridView1.UpdateCurrentRow();
                givenServiceMBindingSource.EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقیت ثبت گردید");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmEditReference_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16);
            if (Dossier != null)
            {
                if (Dossier.LockBilling == true)
                {
                    MessageBox.Show("این پرونده قفل می باشد "); return;
                }
                txtDossierNumber.EditValue = Dossier.ID.ToString();
                simpleButton1.PerformClick();
            }
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;

            using (var diag = new Dialogs.dlgChangeWard(gsm))
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    var dep = dc.Departments.SingleOrDefault(x => x.ID == diag.DepID);
                    gsm.GivenServiceMs.Where(x => x.DepartmentID == gsm.DepartmentID).ToList().ForEach(d => d.Department = dep);
                    gsm.Department = dep;
                    gridView1.CloseEditor();
                    gridControl1.RefreshDataSource();
                    gridView1.RefreshEditor(false);
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var curent = givenServiceMBindingSource.Current as GivenServiceM;
            if (curent == null)
                return;

            if (curent.WardEdit == true)
            {
                MessageBox.Show("این پرونده به بخش فرستاده شده است");
                return;
            }
            else
            {
                curent.WardEdit = true;
                dc.SubmitChanges();
                MessageBox.Show(" بیمار به بخش " + curent.Department.Name + " فرستاده شد ");
            }
        }
    }
}