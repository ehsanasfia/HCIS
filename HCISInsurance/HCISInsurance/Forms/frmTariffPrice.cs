using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISInsurance.Data;
namespace HCISInsurance.Forms
{
    public partial class frmTariffPrice : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        List<ViewTariffComplete> lst;

        public int CategoryID { get; set; }
        public bool RowEdited { get; set; }
        bool dontChange = false;

        public frmTariffPrice()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmTariffPrice_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            insurancesBindingSource.DataSource = dc.Insurances.OrderBy(x => x.Name).ToList();
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.Where(c => c.ID == 4).ToList();


            /*
            tblInsureGroupBindingSource.DataSource = dc.tblInsureGroups.Where(c => c.Insure > 4);
            if (CategoryID == 0)
                billCategoryBindingSource.DataSource = dc.BillCategories.Where(c => c.ID != 17 && (c.ID < 4 || c.ID > 7));
            else
                billCategoryBindingSource.DataSource = dc.BillCategories.Where(c => c.ID == CategoryID);
            //lookUpEdit3.Properties.DataSource = dc.RVUs.GroupBy(c => c.خصوصیت_کد).Select(b => new { Name = b.Key });
            */
            //txtDateRVU.Text = MainModule.GetPersianDate(DateTime.Now);
            txtDateAll.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void lkpInsurance_EditValueChanged(object sender, EventArgs e)
        {
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {
                var ins = lkpInsurance.EditValue as Insurance;
                if (ins == null)
                {
                    viewTariffCompletesBindingSource.DataSource = null;
                    gridControl1.RefreshDataSource();
                    return;
                }

                lst = dc.ViewTariffCompletes.Where(x => x.InsuranceID == ins.ID && x.CategoryID == 4).OrderBy(x => x.ServiceName).OrderBy(x => x.CategoryName).ToList();

                foreach (var vc in lst)
                {
                    vc.Lock = true;
                }

                viewTariffCompletesBindingSource.DataSource = lst;


                gridControl1.RefreshDataSource();
                gridControl1.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnOPrice_Click(object sender, EventArgs e)
        {
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {


                var selectedService = slkServices.EditValue as Service;
                if (selectedService == null)
                {
                    MessageBox.Show("خدمت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }


                var Price = double.Parse(txtServicePrice.Text);
                var PatientPercent = Convert.ToDouble(txtServicePatientShare.EditValue);
                //var faPercent = (double)textEdit4.EditValue;
                //var saPercent = (double)textEdit7.EditValue;
                //var thaPercent = (double)textEdit6.EditValue;
                //var ocPercent = (double)textEdit8.EditValue;
                var faniPercent = Convert.ToDouble(txtServiceFaniPercent.EditValue);
                Tariff row;

                foreach (var item in chkCmbServiceInsurance.Properties.Items.OfType<DevExpress.XtraEditors.Controls.CheckedListBoxItem>().Where(c => c.CheckState == CheckState.Checked))
                {
                    if (item.Value == null)
                        continue;

                    var trf = dc.Tariffs.FirstOrDefault(c => c.Date == txtDateAll.Text && c.InsuranceID == Convert.ToInt32(item.Value) && c.ServiceID == selectedService.ID);
                    if (trf == null)
                    {
                        row = new Tariff()
                        {
                            Date = txtDateAll.Text,
                            InsuranceID = Convert.ToInt32(item.Value),
                            ServiceID = selectedService.ID
                        };
                        dc.Tariffs.InsertOnSubmit(row);
                    }
                    else
                    {
                        row = trf;
                        if (row.Lock)
                            continue;
                    }

                    row.Lock = true;
                    row.TotalPrice = Convert.ToDecimal(Price);
                    row.PatientShare = Convert.ToDecimal(Price * PatientPercent);

                    var ruvRow = dc.RVUs.FirstOrDefault(c => c.NationalID == selectedService.SalamatBookletCode);
                    var technicalPart = 0.0;
                    var faniPart = 0.0;
                    var SumK = 0.0;

                    if (ruvRow != null)
                    {
                        try
                        {
                            technicalPart = ruvRow.Joze_Herfeyi_26 ?? 0.0;
                            faniPart = ruvRow.Joze_Fanni_27 ?? 0.0;
                            if (ruvRow.Joze_Fanni_27 == null)
                                faniPart = faniPercent * technicalPart;

                            SumK = technicalPart + faniPart;
                            technicalPart = technicalPart * (Price / SumK);
                            faniPart = Price - technicalPart;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    //row.FaniPrice = faniPart;
                    row.OrganizationShare = Convert.ToDecimal(Price * (1 - PatientPercent));
                    //row.FirstAssistantPart = ((bool)radioGroup1.EditValue ? technicalPart : Price) * faPercent;
                    //row.SecondAssistantPart = ((bool)radioGroup1.EditValue ? technicalPart : Price) * saPercent;
                    //row.ThirdAssistantPart = ((bool)radioGroup1.EditValue ? technicalPart : Price) * thaPercent;
                    //row.OncallPart = ((bool)radioGroup1.EditValue ? technicalPart : Price) * ocPercent;
                }

                dc.SubmitChanges();
                lkpInsurance_EditValueChanged(null, null);
                MessageBox.Show("ثبت فرمول های محاسباتی جدید با موفقیت صورت پذیرفت.", "ثبت فرمول جدید", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (dontChange)
                    return;

                if (!e.Column.OptionsColumn.AllowEdit)
                    return;

                RowEdited = true;
                if (e.Column == colLock)
                    return;

                var row = gridView1.GetRow(e.RowHandle) as ViewTariffComplete;
                if (row == null)
                    return;

                //string today = MainModule.GetPersianDate(DateTime.Now);

                //bool noDate = string.IsNullOrWhiteSpace(row.Date);
                //string date = noDate ? today : row.Date;


                //var tfRow = dc.Tariffs.FirstOrDefault(c => c.ServiceID == row.ServiceID 
                //                                        && c.InsuranceID == row.InsuranceID 
                //                                        && c.Date != null 
                //                                        && c.Date.CompareTo(date) == 0);

                //if (tfRow == null)
                //{
                //tfRow = new Tariff()
                //{
                //    ServiceID = row.ServiceID,
                //    InsuranceID = row.InsuranceID,
                //    Date = string.IsNullOrWhiteSpace(row.Date) ? today : row.Date,
                //};
                //dc.Tariffs.InsertOnSubmit(tfRow);
                //dontChange = true;
                //row.Date = tfRow.Date;
                //dontChange = false;
                //}

                //gridView1.CloseEditor();


                row.TotalPrice = row.TotalPrice;
                row.PatientShare = row.PatientShare;
                row.OrganizationShare = row.TotalPrice - row.PatientShare;
                gridView1.SetRowCellValue(e.RowHandle, colOrganizationShare, row.OrganizationShare);

                //tfRow.TotalPrice = row.TotalPrice;
                //tfRow.PatientShare = row.PatientShare;
                //tfRow.OrganizationShare = row.TotalPrice - row.PatientShare;
                //gridView1.SetRowCellValue(e.RowHandle, colOrganizationShare, tfRow.OrganizationShare);
                //if (row.Date == null)
                //row.Date = MainModule.GetPersianDate(DateTime.Now);


                //dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {
                if (RowEdited)
                {
                    var row = gridView1.GetRow(e.RowHandle) as ViewTariffComplete;
                    if (row == null)
                        return;

                    row.Lock = true;

                    Tariff tfRow;

                    bool isEmpty = row.PatientShare == null && row.OrganizationShare == null && row.TotalPrice == null;

                    if (!isEmpty)
                    {
                        dontChange = true;

                        string today = MainModule.GetPersianDate(DateTime.Now);

                        bool hasDate = !string.IsNullOrWhiteSpace(row.Date);
                        string date = hasDate ? row.Date : today;


                        tfRow = dc.Tariffs.FirstOrDefault(c => c.ServiceID == row.ServiceID
                                                                && c.InsuranceID == row.InsuranceID
                                                                && c.Date != null
                                                                && c.Date.CompareTo(date) == 0);

                        if (tfRow == null)
                        {
                            tfRow = new Tariff()
                            {
                                ServiceID = row.ServiceID,
                                InsuranceID = row.InsuranceID,
                                Date = date,
                            };
                            dc.Tariffs.InsertOnSubmit(tfRow);
                            row.Date = tfRow.Date;
                        }

                        gridView1.CloseEditor();


                        row.TotalPrice = row.TotalPrice;
                        row.PatientShare = row.PatientShare;
                        row.OrganizationShare = row.TotalPrice - row.PatientShare;
                        gridView1.SetRowCellValue(e.RowHandle, colOrganizationShare, row.OrganizationShare);

                        tfRow.TotalPrice = row.TotalPrice;
                        tfRow.PatientShare = row.PatientShare;
                        tfRow.OrganizationShare = row.TotalPrice - row.PatientShare;
                        gridView1.SetRowCellValue(e.RowHandle, colOrganizationShare, tfRow.OrganizationShare);
                        if (string.IsNullOrWhiteSpace(row.Date))
                            row.Date = MainModule.GetPersianDate(DateTime.Now);


                        dc.SubmitChanges();


                        dontChange = false;
                    }


                    tfRow = dc.Tariffs.FirstOrDefault(c => c.ServiceID == row.ServiceID && c.InsuranceID == row.InsuranceID && c.Date != null && c.Date.CompareTo(row.Date) == 0);
                    if (tfRow != null)
                    {
                        tfRow.Lock = true;
                    }

                    dc.SubmitChanges();
                    RowEdited = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void lkpCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpCategory.EditValue != null)
                servicesBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == (int)lkpCategory.EditValue).OrderBy(x => x.Name).ToList();
            else
                servicesBindingSource.DataSource = null;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            if (e.Column == colDate)
            {
                var row = gridView1.GetRow(e.RowHandle) as ViewTariffComplete;
                if (row == null)
                    return;
                var dlg = new Dialogs.dlgChangeTariff();
                dlg.row = row;
                dlg.ShowDialog();

                if (dlg.lastTrf != null)
                {
                    dontChange = true;
                    row.TotalPrice = dlg.lastTrf.TotalPrice;
                    row.PatientShare = dlg.lastTrf.PatientShare;
                    row.OrganizationShare = dlg.lastTrf.OrganizationShare;
                    row.Date = dlg.lastTrf.Date;
                    dontChange = false;
                }
            }
        }

        private void frmTariffPrice_Shown(object sender, EventArgs e)
        {
            lkpInsurance.ItemIndex = 0;
            //lcgBook.Visibility = CategoryID > 0 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gridControl1.Focused && keyData == (Keys.D | Keys.Control))
            {
                var cur = viewTariffCompletesBindingSource.Current as ViewTariffComplete;
                if (cur == null)
                    return base.ProcessCmdKey(ref msg, keyData);

                cur.Lock = !cur.Lock;
                gridControl1.RefreshDataSource();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn == colLock)
                return;
            var row = gridView1.GetFocusedRow() as ViewTariffComplete;
            if (row == null)
                return;

            if (row.Lock.HasValue && row.Lock.Value)
                e.Cancel = true;
        }
    }
}