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
using HCISDiagnosticServices.Data;

namespace HCISDiagnosticServices.Dialogs
{
    public partial class dlgAdvancedSearch : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM SelectedGSM { get; set; }
        public bool isDoss { get; set; }
        List<GivenServiceM> lst = new List<GivenServiceM>();

        public dlgAdvancedSearch()
        {
            InitializeComponent();
        }
        private void dlgAdvancedSearch_Load(object sender, EventArgs e)
        {
            btnSelect.Enabled = false;
            rdbPersonalNum.Checked = true;
            if(isDoss == true)
            {
                rdbDateReception.Checked = true;
                rdbDateRequest.Enabled = false;
                rdbNameLname.Enabled = false;
                rdbPersonalNum.Enabled = false;
            }
        }

        private void rdbPersonalNum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPersonalNum.Checked)
            {
                Group1.Enabled = true;
                Group2.Enabled = false;
                Group3.Enabled = false;
            }
            else if (rdbDateReception.Checked)
            {
                Group1.Enabled = false;
                Group2.Enabled = true;
                Group3.Enabled = false;
            }
            else if (rdbDateRequest.Checked)
            {
                Group1.Enabled = false;
                Group2.Enabled = true;
                Group3.Enabled = false;
            }
            else if (rdbNameLname.Checked)
            {
                Group1.Enabled = false;
                Group2.Enabled = false;
                Group3.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbDateReception.Checked) //تاریخ پذیرش
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.AdmitDate.CompareTo(dtpFrom.Date) >= 0 && x.AdmitDate.CompareTo(dtpTo.Date) <= 0).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).ToList();
                }
                else if(rdbDateRequest.Checked) //تاریخ درخواست
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.RequestDate.CompareTo(dtpFrom.Date) >= 0 && x.RequestDate.CompareTo(dtpTo.Date) <= 0).OrderBy(c => c.RequestTime).OrderBy(c => c.RequestDate).ToList();
                }
                else if(rdbPersonalNum.Checked)
                {
                    bool hasNationalCode = !string.IsNullOrWhiteSpace(txtNationalCode.Text);
                    bool hasSerialNumber = !string.IsNullOrWhiteSpace(txtSerialNumber.Text);
                    bool hasPersonalCode = !string.IsNullOrWhiteSpace(txtPersonalCode.Text);
                    if (!hasNationalCode && !hasSerialNumber && !hasPersonalCode)
                    {
                        MessageBox.Show("لطفا کد ملی یا شماره سریال یا شماره پرسنلی را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    if (hasNationalCode && !hasSerialNumber && !hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.Person.NationalCode.Contains(txtNationalCode.Text.Trim())).ToList();
                    }
                    else if (!hasNationalCode && hasSerialNumber && !hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0).ToList();
                    }
                    else if(!hasNationalCode && !hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim())).ToList();
                    }
                    else if (hasNationalCode && hasSerialNumber && !hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0)).ToList();
                    }
                    else if (!hasNationalCode && hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && (x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0)).ToList();
                    }
                    else if (hasNationalCode && !hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()))).ToList();
                    }
                    else if(hasNationalCode && hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0 || x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()))).ToList();
                    }
                }
                else if(rdbNameLname.Checked)
                {
                    bool hasFirstName = !string.IsNullOrWhiteSpace(txtName.Text);
                    bool hasLastName = !string.IsNullOrWhiteSpace(txtLastName.Text);
                    if (!hasFirstName && !hasLastName)
                    {
                        MessageBox.Show("لطفا نام یا نام خانوادگی را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    if (hasFirstName && !hasLastName)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.Person.FirstName.Contains(txtName.Text.Trim())).ToList();
                    }
                    else if (!hasFirstName && hasLastName)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && x.Person.LastName.Contains(txtLastName.Text.Trim())).ToList();
                    }
                    else if (hasFirstName && hasLastName)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.Any(y => y.Service != null && y.Service.ParentID == MainModule.DiagnosticService.ID) && (x.Person.FirstName.Contains(txtName.Text.Trim()) || x.Person.LastName.Contains(txtLastName.Text.Trim()))).ToList();
                    }
                }
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lst);
                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedGSM = givenServiceMsBindingSource.Current as GivenServiceM;
            if (SelectedGSM == null)
                return;
            if (SelectedGSM.Payed == false && (SelectedGSM.FromDepartmentObject != null
                                           && SelectedGSM.FromDepartmentObject.TypeID != 11
                                           && SelectedGSM.FromDepartmentObject.Name != "اورژانس"))
            {
                MessageBox.Show("بیمار هنوز هزینه را پرداخت نکرده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if(SelectedGSM.Person != null && !string.IsNullOrWhiteSpace(SelectedGSM.Person.MedicalID))
            {
                var mi = dc.View_IMPHO_Persons.FirstOrDefault(c => c.InsuranceNo != null && c.InsuranceNo.Trim() == SelectedGSM.Person.MedicalID.Trim() && c.ExpDate != null && c.ExpDate.Length == 10);
                if(mi != null)
                {
                    SelectedGSM.BookletExpireDate = mi.ExpDate;
                    SelectedGSM.Person.BookletExpireDate = mi.ExpDate;
                }
            }

            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F | Keys.Control))
            {
                btnSearch.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSelect_Click(null,null);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 2)
            {
                btnSelect_Click(null, null);
            }
        }
    }
}