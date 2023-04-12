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
using HCISSecondWard.Classes;
using HCISSecondWard.Dialogs;

namespace HCISSecondWard.Forms
{

    public partial class frmCashBastari2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCashBastari2()
        {
            InitializeComponent();

            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }


        HCISDataContext dc = new HCISDataContext();


        public Dossier dossier;
        List<Vw_DosFinance> lstDosFinance = new List<Vw_DosFinance>();
        private void bbiSearchDossier_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (txtDossierId.Text.Trim() == "")
                {
                    MessageBox.Show("لطفا شماره پرونده را وارد نمایید");
                    return;
                }

                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Int32.Parse(txtDossierId.Text));

                if (dossier.IOtype != 1)
                {
                    MessageBox.Show("این پرونده مربوط به بیمار بستری نمی باشد"); return;
                }
                if (dossier != null)
                    if (dossier.LockBilling == true)
                    {
                        MessageBox.Show("این پرونده قفل می باشد "); return;

                    }
                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? x.Department.Name == "اورژانس" : false))
                {

                    if (dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList().Count == 1)
                    {

                        BillingForOrjans();
                    }
                    else
                    {
                        var dlg = new dlgSelectKindBilling();
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg.Kind == 1)
                            {

                                BillingForOrjans();
                            }
                            if (dlg.Kind == 2)
                            {

                                BillForWard();
                            }
                        }
                    }
                }
                else
                {

                    BillForWard();
                }
               
                //  lstDosFinance = dc.Vw_DosFinances.Where(c => c.DossierNO == Int32.Parse(txtDossierId.Text)).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BillForWard()
        {
            try
            {
                lstDosFinance.Clear();
                lstDosFinance.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == Int32.Parse(txtDossierId.Text) && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                foreach (var item in lstDosFinance)
                {
                    if (item.ParentID == null)
                        continue;
                    var cat = dc.GivenServiceMs.FirstOrDefault(x => x.ID == item.ParentID).ServiceCategoryID;
                    if (cat == 9 || cat == 11)
                    {
                        if (item.ID == 12)
                            item.CatName = "لوازم مصرفی اتاق عمل";
                        else if (item.ID == 4)
                            item.CatName = "داروهای اتاق عمل";
                    }

                    else if (cat == 13 || cat == 14)
                    {
                        if (item.ID == 12)
                            item.CatName = "لوازم مصرفی آنژیو";
                        else if (item.ID == 4)
                            item.CatName = "داروهای آنژیو";
                    }
                }
                lstDosFinance = lstDosFinance.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDosFinance.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "خدمات جراحی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "محاسبه خدمات جراحی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "آنژیوگرافی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "آنژیوپلاستی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "خدمات پرستاری در بخش").ToList();
                vwDosFinanceBindingSource.DataSource = lstDosFinance;
                var Person = dossier.Person;
                txtFirstName.Text = Person.FirstName;
                txtLastName.Text = Person.LastName;
                txtNationalCode.Text = Person.NationalCode;
                txtDate.Text = dossier.Date;
                textEdit1.Text = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name;
                //if (dossier.LockBilling == true)
                //{
                //    bbiAddNewGSD.Enabled = bbipayments.Enabled = true;
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void BillingForOrjans()
        {
            try
            {
                lstDosFinance.Clear();
                lstDosFinance.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == Int32.Parse(txtDossierId.Text) && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());

                lstDosFinance = lstDosFinance.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDosFinance.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "خدمات جراحی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "محاسبه خدمات جراحی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "آنژیوگرافی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "آنژیوپلاستی").ToList();
                lstDosFinance = lstDosFinance.Where(x => x.CatName != "خدمات پرستاری در بخش").ToList();

                vwDosFinanceBindingSource.DataSource = lstDosFinance;
                var Person = dossier.Person;
                txtFirstName.Text = Person.FirstName;
                txtLastName.Text = Person.LastName;
                txtNationalCode.Text = Person.NationalCode;
                txtDate.Text = dossier.Date;
                textEdit1.Text = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name;
                //if (dossier.LockBilling == true)
                //{
                //    bbiAddNewGSD.Enabled = bbipayments.Enabled = true;
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void frmCashBastari2_Load(object sender, EventArgs e)
        {
            if (dossier != null)
            {
                if (dossier.LockBilling == true)
                {
                    MessageBox.Show("این پرونده قفل می باشد "); return;
                }
                txtDossierId.EditValue = dossier.ID.ToString();
                bbiSearchDossier.PerformClick();
            }
        }


        private void bbiAddNewGSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new dlgAddNewGSD() { dc = dc, MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault() };

            dlg.ShowDialog();
            bbiSearchDossier.PerformClick();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                vwDosFinanceBindingSource.EndEdit();
                lstDosFinance.ForEach(x =>
                {
                    var gsd = dc.GivenServiceDs.FirstOrDefault(c => c.ID == x.GSDID);
                    gsd.InsuranceShare = x.InsuranceShare;
                    gsd.PatientShare = x.PatientShare;
                });
                dc.SubmitChanges();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            DialogResult = DialogResult.OK;
        }

        private void bbiLock_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            if (MessageBox.Show(this, "بعد از قفل کردن صورتحساب امکان ویرایش وجود ندارد \n مایل به ادامه قفل کردن هستید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                dossier.LockBilling = true;
                dc.SubmitChanges();
            }
            else
                return;
        }

        private void txtDossierId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                bbiSearchDossier.PerformClick();
            }
        }
       
        List<GivenServiceM> GSMs;
        private void bbiHotling_ItemClick(object sender, ItemClickEventArgs e)
        {
         }
    
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiAdvanceSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgSearchBastari();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDossierId.Text = dlg.dossierID.ToString();
                bbiSearchDossier.PerformClick();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = vwDosFinanceBindingSource.Current as Vw_DosFinance;

            if (row == null)
                return;
            if (MessageBox.Show(String.Format("آیا از حذف خدمت {0} اطمینان دارید ؟\r\nدرصورت حذف امکان بازگشت وجود نخواهد داشت.", row.Name), "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;


            dc.GivenServiceDs.DeleteOnSubmit(dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID));
            dc.SubmitChanges();

            var lstEx = GetExpandedRowHandles(gridView1);

            bbiSearchDossier.PerformClick();

            ExpandRows(gridView1, lstEx);

            MessageBox.Show(string.Format("خدمت انتخابی با موفقیت حذف گردید.\r\n{0}", row.Name));
        }

        private List<int> GetExpandedRowHandles(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            List<int> lstEx = new List<int>();
            int Handle = -1;
            // group rows have negative row handles
            while (gridView.GetRow(Handle) != null)
            {
                if (gridView.GetRowExpanded(Handle))
                {
                    lstEx.Add(Handle);
                }

                Handle--;
            }

            return lstEx;
        }

        private void ExpandRows(DevExpress.XtraGrid.Views.Grid.GridView gridView, List<int> list)
        {
            foreach (var item in list)
            {
                if (gridView1.IsValidRowHandle(item))
                    gridView1.ExpandGroupRow(item);
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            var row = vwDosFinanceBindingSource.Current as Vw_DosFinance;

            if (row == null)
                return;

            var gsd = dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID);
            gsd.Date = row.GsdDate;
            gsd.Time = row.Time;
            gsd.Amount = row.Amount;

            try
            {

                dc.SubmitChanges();
                MessageBox.Show("ثبت شد.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = vwDosFinanceBindingSource.Current as Vw_DosFinance;

            if (row == null)
                return;
            var dlg = new Dialogs.dlgEditDoc();
            var gsd = dc.GivenServiceDs.SingleOrDefault(x => x.ID == row.GSDID);
            dlg.GSD = gsd;
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                bbiSearchDossier.PerformClick();

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var currentRow = gridView1.GetRow(e.RowHandle) as Data.Vw_DosFinance;
            try
            {
                var gsd = dc.GivenServiceDs.SingleOrDefault(x => x.ID == currentRow.GSDID);
                gsd.Date = currentRow.GsdDate;
                gsd.Time = currentRow.Time;
                gsd.GivenAmount = currentRow.GivenAmount;
                gsd.Amount = currentRow.Amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                vwDosFinanceBindingSource.EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقیت ثبت شد.", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show(String.Format("آیا از حذف  اين خدمت اطمینان دارید ؟\r\nدرصورت حذف امکان بازگشت وجود نخواهد داشت."), "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;
            foreach (var item in gridView1.GetSelectedRows())
            {
                var row = gridView1.GetRow(item) as Vw_DosFinance;
                if (row == null? true : (row.WardParent.Contains("عمل") || row.ID==1))
                    continue;
                if (row == null ? true : (row.Confirm==true && row.ID==6))
                    continue;
                if (dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID).GivenServiceM.GivenServiceDs.ToList().Count()==1)
                {
                    dc.GivenServiceMs.DeleteOnSubmit(dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID).GivenServiceM);
                 }
                else

                dc.GivenServiceDs.DeleteOnSubmit(dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID));
                 }
            dc.SubmitChanges();
            MessageBox.Show(string.Format("خدمات انتخابی با موفقیت حذف گردیدند.\r\n"));

            var lstEx = GetExpandedRowHandles(gridView1);
            bbiSearchDossier.PerformClick();
            ExpandRows(gridView1, lstEx);
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }
    }
}