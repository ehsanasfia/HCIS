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
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Forms
{
    public partial class frmAdmissionList : DevExpress.XtraEditors.XtraForm
    {
        HCISSurgeryDataClassesDataContext dc = new HCISSurgeryDataClassesDataContext();

        public frmAdmissionList()
        {
            InitializeComponent();
        }

        private void frmWaitingList_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.DepartmentID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            var mdName = MainModule.MyDepartment.Name;
            if (MainModule.DepSRV == null || !MainModule.DepSRV.Any())
                MainModule.DepSRV = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Service1.Name == mdName && x.SalamatBookletCode != null).ToList();
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
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }

        private void btnSearchDoss_Click(object sender, EventArgs e)
        {
            var dos = txtDossNumber.Text;
            if (string.IsNullOrWhiteSpace(dos))
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == false && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Confirm == true && x.Payed == true && x.CreationDate == txtDate.Text).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
                }
            }
            else
            {
                var longdos = long.Parse(dos);
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.DossierID == longdos && x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department.ID == MainModule.MyDepartment.ID && x.Admitted == true && x.Payed == true).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
        }
    }
}