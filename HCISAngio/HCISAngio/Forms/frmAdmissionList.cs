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
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Forms
{
    public partial class frmAdmissionList : DevExpress.XtraEditors.XtraForm
    {
        HCISAngioDataClassesDataContext dc = new HCISAngioDataClassesDataContext();
        public frmAdmissionList()
        {
            InitializeComponent();
        }

        private void frmWaitingList_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnDone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            //if (current.Dossier.LockBilling == true)
            //{
            //    MessageBox.Show("پرونده ی بیمار توسط امور مالی قفل شده است.\nشماره پرونده: " + current.DossierID,
            //        "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            MainModule.GSM_Set = current;
            btnClose_ItemClick(null, null);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dos = txtDossNumber.Text;
            if (string.IsNullOrWhiteSpace(dos))
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
                }
            }
            else
            {
                var longdos = long.Parse(dos);
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.DossierID == longdos && x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == true && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }
    }
}