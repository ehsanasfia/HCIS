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
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgGSMSearch : DevExpress.XtraEditors.XtraForm
    {
        public HCISDrugStoreClassesDataContext dc { get; set; }
        List<GivenServiceM> lst = new List<GivenServiceM>();
        public GivenServiceM SelectedGSM { get; set; }

        public dlgGSMSearch()
        {
            InitializeComponent();
        }

        private void dlgDateSearch_Load(object sender, EventArgs e)
        {
            btnSelect.Enabled = false;
            radioGroup1.SelectedIndex = 1;
            btnDateSearch_Click(null, null);
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 0) //تاریخ پذیرش
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                   && x.Department == MainModule.MyDepartment && x.GivenServiceM1 != null
                    && x.GivenServiceM1.ServiceCategoryID == (int)Category.ویزیت
                    && x.GivenServiceM1.AdmitDate.CompareTo(FromDtp.Date) >= 0 
                    && x.GivenServiceM1.AdmitDate.CompareTo(ToDtp.Date) <= 0).ToList();
                }
                else if (radioGroup1.SelectedIndex == 1) //تاریخ درخواست پزشک
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                  && x.Department == MainModule.MyDepartment && x.GivenServiceM1 != null
                    && x.GivenServiceM1.ServiceCategoryID == (int)Category.ویزیت
                    && x.GivenServiceM1.RequestDate.CompareTo(FromDtp.Date) >= 0
                    && x.GivenServiceM1.RequestDate.CompareTo(ToDtp.Date) <= 0).ToList();
                }
                else if (radioGroup1.SelectedIndex == 2)//تاریخ تحویل
                {
                    lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                 && x.Department == MainModule.MyDepartment && x.AnsweringDate.CompareTo(FromDtp.Date) >= 0 
                    && x.AnsweringDate.CompareTo(ToDtp.Date) <= 0).ToList();
                }
                
                
                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();
                
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
            bool isName = !string.IsNullOrWhiteSpace(txtName.Text);
            bool isCode = !string.IsNullOrWhiteSpace(txtNationalCode.Text);
            bool isPersonelCode = !string.IsNullOrWhiteSpace(txtPersonalCode.Text);

            txtName.Text = txtName.Text.Trim();
            txtNationalCode.Text = txtNationalCode.Text.Trim();
            txtPersonalCode.Text = txtPersonalCode.Text.Trim();

            if (isName && isCode && isPersonelCode)
            {
                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                 && x.Department == MainModule.MyDepartment && x.Person != null
                    && ( ((x.Person.FirstName ?? "") + " " + (x.Person.LastName ?? "")).Contains(txtName.Text) || (x.Person.NationalCode != null && x.Person.NationalCode.Contains(txtNationalCode.Text)))
                    ).ToList();


                if (lst.Any())
                {
                    givenServiceMsBindingSource.DataSource = lst;
                    gridView1.BestFitColumns();
                    btnSelect.Enabled = lst.Any();
                }
                else
                    ShowPersonSearch();
            }
            else if (isName)
            {
                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                 && x.Department == MainModule.MyDepartment && x.Person != null
                    && ((x.Person.FirstName ?? "") + " " + (x.Person.LastName ?? "")).Contains(txtName.Text)
                    ).ToList();

                if (lst.Any())
                {
                    givenServiceMsBindingSource.DataSource = lst;
                    gridView1.BestFitColumns();
                    btnSelect.Enabled = lst.Any();
                }
                else
                    ShowPersonSearch();
            }
            else if (isPersonelCode)
            {
                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                && x.Department == MainModule.MyDepartment && x.Person != null
                   && x.Person.PersonalCode != null && x.Person.PersonalCode.Equals(txtPersonalCode.Text)
                   ).ToList();

                if (lst.Any())
                {
                    givenServiceMsBindingSource.DataSource = lst;
                    gridView1.BestFitColumns();
                    btnSelect.Enabled = lst.Any();
                }
                else
                    ShowPersonSearch();
            }
            else if (isCode)
            {
                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                && x.Department == MainModule.MyDepartment && x.Person != null
                    && x.Person.NationalCode != null && x.Person.NationalCode.Contains(txtNationalCode.Text)
                    ).ToList();

                if (lst.Any())
                {
                    givenServiceMsBindingSource.DataSource = lst;
                    gridView1.BestFitColumns();
                    btnSelect.Enabled = lst.Any();
                }
                else
                    ShowPersonSearch();
            }
            else
            {
                ShowPersonSearch();
            }
        }

        private void ShowPersonSearch()
        {
            var dlg = new dlgPersonSearch() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK && dlg.EditingPerson != null)
            {
                lst = dlg.EditingPerson.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو && x.Department == MainModule.MyDepartment).ToList();
                if (!lst.Any())
                {
                    MessageBox.Show("برای این بیمار نسخه ی دارویی ثبت نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                txtName.Text = dlg.EditingPerson.FirstName + " " + dlg.EditingPerson.LastName;
                txtNationalCode.Text = dlg.EditingPerson.NationalCode;

                givenServiceMsBindingSource.DataSource = lst;
                gridView1.BestFitColumns();
                btnSelect.Enabled = lst.Any();
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedGSM = givenServiceMsBindingSource.Current as GivenServiceM;
            if (SelectedGSM == null)
                return;
            DialogResult = DialogResult.OK;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSerialSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSerialNumber.Text))
                    return;
                txtSerialNumber.Text = txtSerialNumber.Text.Trim();
                int sri = Convert.ToInt32(txtSerialNumber.Text);

                lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دارو
                 && x.Department == MainModule.MyDepartment && x.SerialNumber == sri).ToList();

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

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && btnSelect.Enabled)
                btnSelect_Click(null, null);
        }

        private void txtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSerialSearch_Click(null, null);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnPersonSearch_Click(null, null);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            if (btnSelect.Enabled)
                btnSelect_Click(null, null);
        }
    }
}