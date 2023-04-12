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
using HCISPathology.Data;

namespace HCISPathology.Dialogs
{
    public partial class dlgAdvancedSearch : DevExpress.XtraEditors.XtraForm
    {
        public HCISPathologyDataClassesDataContext dc { get; set; }
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public GivenServiceM SelectedGSM { get; set; }
        public dlgAdvancedSearch()
        {
            InitializeComponent();
        }
        private void dlgAdvancedSearch_Load(object sender, EventArgs e)
        {
            btnSelect.Enabled = false;
            rdbDateReception.Checked = true;
            btnSearch_Click(null, null);
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
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.AdmitDate.CompareTo(dtpFrom.Date) >= 0 && x.AdmitDate.CompareTo(dtpTo.Date) <= 0).ToList();
                }
                else if(rdbDateRequest.Checked) //تاریخ درخواست
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.RequestDate.CompareTo(dtpFrom.Date) >= 0 && x.RequestDate.CompareTo(dtpTo.Date) <= 0).ToList();
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
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.Person.NationalCode.Contains(txtNationalCode.Text.Trim())).ToList();
                    }
                    else if (!hasNationalCode && hasSerialNumber && !hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0).ToList();
                    }
                    else if(!hasNationalCode && !hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim())).ToList();
                    }
                    else if (hasNationalCode && hasSerialNumber && !hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0)).ToList();
                    }
                    else if (!hasNationalCode && hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && (x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0)).ToList();
                    }
                    else if (hasNationalCode && !hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()))).ToList();
                    }
                    else if(hasNationalCode && hasSerialNumber && hasPersonalCode)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && (x.Person.NationalCode.Contains(txtNationalCode.Text.Trim()) || x.SerialNumber.CompareTo(txtSerialNumber.Text.Trim()) == 0 || x.Person.PersonalCode.Contains(txtPersonalCode.Text.Trim()))).ToList();
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
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.Person.FirstName.Contains(txtName.Text.Trim())).ToList();
                    }
                    else if (!hasFirstName && hasLastName)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && x.Person.LastName.Contains(txtLastName.Text.Trim())).ToList();
                    }
                    else if (hasFirstName && hasLastName)
                    {
                        lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.پاتولوژی && (x.Person.FirstName.Contains(txtName.Text.Trim()) || x.Person.LastName.Contains(txtLastName.Text.Trim()))).ToList();
                    }
                }
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
            if (SelectedGSM.Payed == false && !(SelectedGSM.FromDepartmentObject != null
                            && SelectedGSM.FromDepartmentObject.TypeID == 11
                            && SelectedGSM.FromDepartmentObject.Name != "اورژانس"))
            {
                MessageBox.Show("بیمار هنوز هزینه را پرداخت نکرده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (SelectedGSM.Dossier.LockBilling == true)
            {
                MessageBox.Show("پرونده ی بیمار توسط امور مالی قفل شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var row = givenServiceMsBindingSource.Current as GivenServiceM;
            if (row == null)
                return;
            SelectedGSM = row;

            DialogResult = DialogResult.OK;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var row = givenServiceMsBindingSource.Current as GivenServiceM;
                if (row == null)
                    return;
                SelectedGSM = row;

                DialogResult = DialogResult.OK;
            }
        }
    }
}