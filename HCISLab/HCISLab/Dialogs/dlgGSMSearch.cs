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
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgGSMSearch : DevExpress.XtraEditors.XtraForm
    {
        private HCISLabClassesDataContext dc;
        List<GivenServiceM> lst = new List<GivenServiceM>();
        private GivenServiceM SelectedGSM;

        public Guid? SelectedGSM_ID { get; set; }
        private static string PersonalCode;
        private static int? rdgIndex;
        private static string SerialNumber;
        private static int? LastSearchButton;
        private static string FromDate;
        private static string ToDate;

        public dlgGSMSearch()
        {
            InitializeComponent();
        }

        private void dlgDateSearch_Load(object sender, EventArgs e)
        {
            dc = new HCISLabClassesDataContext();

            btnSelect.Enabled = false;
            //radioGroup1.SelectedIndex = 1;


            if (!string.IsNullOrWhiteSpace(PersonalCode))
                txtPersonalCode.Text = PersonalCode.Trim();
            if (rdgIndex != null)
                radioGroup1.SelectedIndex = rdgIndex.Value;
            else
                radioGroup1.SelectedIndex = 1;

            if (!string.IsNullOrWhiteSpace(SerialNumber))
                txtSerialNumber.Text = SerialNumber.Trim();
            if (!string.IsNullOrWhiteSpace(FromDate))
                FromDtp.Date = FromDate;
            if (!string.IsNullOrWhiteSpace(ToDate))
                ToDtp.Date = ToDate;


            if (LastSearchButton != null)
            {
                if (LastSearchButton == 1)
                    btnDateSearch.PerformClick();
                else if (LastSearchButton == 2)
                    btnSerialSearch.PerformClick();
                else if (LastSearchButton == 3)
                    btnPersonSearch.PerformClick();
            }
            else
                btnDateSearch.PerformClick();

        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LastSearchButton = 1;
                if (radioGroup1.SelectedIndex == 0) //تاریخ درخواست
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                    && x.RequestDate.CompareTo(FromDtp.Date) >= 0
                    && x.RequestDate.CompareTo(ToDtp.Date) <= 0
                    && x.DepartmentID == MainModule.InstallLocation.ID).ToList();

                    gridView1.ClearSorting();
                    colRequestDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                }
                else if (radioGroup1.SelectedIndex == 1)//تاریخ پذیرش
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                    && x.AdmitDate.CompareTo(FromDtp.Date) >= 0
                    && x.AdmitDate.CompareTo(ToDtp.Date) <= 0
                    && x.DepartmentID == MainModule.InstallLocation.ID).ToList();

                    gridView1.ClearSorting();
                    colDailySN.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                }
                else if (radioGroup1.SelectedIndex == 2)//تاریخ نوبت
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                    && x.TurningDate.CompareTo(FromDtp.Date) >= 0
                    && x.TurningDate.CompareTo(ToDtp.Date) <= 0
                    && x.DepartmentID == MainModule.InstallLocation.ID).ToList();
                }
                else if (radioGroup1.SelectedIndex == 3)//تاریخ جواب دهی
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                    && x.AnsweringDate.CompareTo(FromDtp.Date) >= 0
                    && x.AnsweringDate.CompareTo(ToDtp.Date) <= 0
                    && x.DepartmentID == MainModule.InstallLocation.ID).ToList();
                }

                //lst = lst.OrderByDescending(x => x.AdmitDate).ToList();
                //dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lst);

                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();

                lblPerson.Text = "بیمار:";
                lblNationalCode.Text = "کد ملی:";
                txtSerialNumber.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnPersonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonalCode.Text))
            {
                var dlg = new dlgPersonSearch() { dc = dc };
                if (dlg.ShowDialog() == DialogResult.OK && dlg.EditingPerson != null)
                {
                    lst = dlg.EditingPerson.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                                                            && x.DepartmentID == MainModule.InstallLocation.ID).ToList();
                    if (!lst.Any())
                    {
                        MessageBox.Show("بیمار انتخاب شده، تا کنون پذیرش نشده است و آزمایشی توسط پزشک درخواست نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        LastSearchButton = 1;
                    }
                    else
                    {
                        LastSearchButton = 3;
                    }
                    lblPerson.Text = "بیمار: " + dlg.EditingPerson.FirstName + " " + dlg.EditingPerson.LastName;
                    lblNationalCode.Text = "کد ملی: " + dlg.EditingPerson.NationalCode;

                    givenServiceMsBindingSource.DataSource = lst;
                    gridView1.BestFitColumns();
                    btnSelect.Enabled = lst.Any();
                }
            }
            else
            {
                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                  && x.Person.PersonalCode == txtPersonalCode.Text.Trim()
                  && x.DepartmentID == MainModule.InstallLocation.ID).OrderByDescending(c => c.AdmitDate).ToList();
                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();
                lblPerson.Text = "بیمار:";
                lblNationalCode.Text = "کد ملی:";
                txtSerialNumber.Text = "";
                LastSearchButton = 3;
            }

            //if (lst.Any())
            //    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lst);
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!btnSelect.Enabled)
                return;
            SelectedGSM = givenServiceMsBindingSource.Current as GivenServiceM;
            if (SelectedGSM == null)
                return;

            if (!SelectedGSM.Payed && (SelectedGSM.GivenServiceM1 == null
                || SelectedGSM.GivenServiceM1.Department == null || SelectedGSM.GivenServiceM1.Department.TypeID != 11 || SelectedGSM.GivenServiceM1.Department.Name == "اورژانس"))
            {
                MessageBox.Show("بیمار هنوز نسخه ی آزمایش را پرداخت نکرده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                PersonalCode = txtPersonalCode.Text.Trim();
            else
                PersonalCode = null;

            rdgIndex = radioGroup1.SelectedIndex;
            if (!string.IsNullOrWhiteSpace(txtSerialNumber.Text))
                SerialNumber = txtSerialNumber.Text.Trim();
            else
                SerialNumber = null;

            if (!string.IsNullOrWhiteSpace(FromDtp.Date))
                FromDate = FromDtp.Date.Trim();
            else
                FromDate = null;

            if (!string.IsNullOrWhiteSpace(ToDtp.Date))
                ToDate = ToDtp.Date.Trim();
            else
                ToDate = null;


            SelectedGSM_ID = SelectedGSM.ID;



            DialogResult = DialogResult.OK;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDateSearch.PerformClick();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPersonSearch.PerformClick();
            }
        }

        private void btnSerialSearch_Click(object sender, EventArgs e)
        {
            if (txtSerialNumber.Text.Trim() != "")
            {
                int srl = -1;
                bool valid = int.TryParse(txtSerialNumber.Text.Trim(), out srl);
                if (!valid || srl == -1)
                {
                    MessageBox.Show("سریال به درستی وارد نشده است.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                  && x.SerialNumber == srl
                  && x.DepartmentID == MainModule.InstallLocation.ID).OrderByDescending(c => c.AdmitDate).ToList();
                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();

                lblPerson.Text = "بیمار:";
                lblNationalCode.Text = "کد ملی:";

                if (lst.Any())
                {
                    //dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lst);
                    LastSearchButton = 2;
                }
                else
                {
                    MessageBox.Show("بیمار با این شماره سریال یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    LastSearchButton = 1;
                }
            }

        }

        private void txtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSerialSearch.PerformClick();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            if (btnSelect.Enabled)
                btnSelect_Click(null, null);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (gridControl1.ContainsFocus)
                {
                    if (btnSelect.Enabled)
                        btnSelect.PerformClick();
                    return true;
                }
                else if (radioGroup1.ContainsFocus || radioGroup1.Focused || FromDtp.ContainsFocus || FromDtp.Focused || ToDtp.ContainsFocus || ToDtp.Focused)
                {
                    btnDateSearch.PerformClick();
                    return true;
                }
            }
            else if (keyData == Keys.Space)
            {
                if (gridControl1.ContainsFocus)
                {
                    if (btnSelect.Enabled)
                        btnSelect.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}