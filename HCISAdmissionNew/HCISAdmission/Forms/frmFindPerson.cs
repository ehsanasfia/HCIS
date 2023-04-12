using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace HCISAdmission
{
    public partial class frmFindPerson : DevExpress.XtraEditors.XtraForm
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        IMPHODataContext IM = new IMPHODataContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Boolean cancelflag = false;
            try
            {

              
                List<View_IMPHO_Person> persons = null;
                var query = dc.View_IMPHO_Persons.AsQueryable();


                if (String.IsNullOrWhiteSpace(txtPersonelCode.Text)== false)
                {
                    query = query.Where(d => d.PersonnelNo == txtPersonelCode.Text);
                }
                else if (String.IsNullOrWhiteSpace(txtNational.Text) == false)
                {
                    query = query.Where(d => d.NationalCode == txtNational.Text);
                }
               
                else if (String.IsNullOrWhiteSpace(txtName.Text) == false || String.IsNullOrWhiteSpace(txtLastName.Text)==false )
                {
                    query = query.Where(d => d.Firstname.Contains(txtName.Text) == true && d.Lastname.Contains(txtLastName.Text) == true);


                }
                else
                {
                    MessageBox.Show("لطفا اطلاعات خواسته شده را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }

                var listPerson = query.ToList();
                if (listPerson.Count() <= 0)
                {
                    MessageBox.Show("اطلاعات خواسته شده یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    view_IMPHO_PersonBindingSource.Clear();
                }
                else
                    view_IMPHO_PersonBindingSource.DataSource = listPerson;



                //     personInformationBindingSource.DataSource = query.ToList();


                //view_IMPHO_PersonBindingSource_CurrentChanged(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

   

        private void frmFindPerson_Load_1(object sender, EventArgs e)
        {
            cmbManagement.Properties.DataSource = IM.Tbl_Managements.Select(d => new { Id = d.IDManagement, Name = d.Name }).ToList();
            cmbCompany.Properties.DataSource = IM.Tbl_Companies.Select(d => new { Id = d.IDCompany, Name = d.Name }).ToList();
            cmbSubCompany.Properties.DataSource = IM.Tbl_SubCompanies.Select(d => new { Id = d.IDSubCompany, Name = d.Name }).ToList();

                            cmbValidCenterZone.Properties.DataSource = IM.Tbl_ValidCenterZones.Select(d => new { Id = d.IDValidCenterZone, Name = d.Name }).ToList();
            cmbValidCenter.Properties.DataSource = IM.Tbl_ValidCenters.Select(d => new { Id = d.IDValidCenter, Name = d.Name }).ToList();

            var dd= gridView.FormatRules[0].Rule as DevExpress.XtraEditors.FormatConditionRuleValue;
            dd.Value1 = MainModule.GetPersianDate(DateTime.Now);

        }

        private void cmbCompany_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void view_IMPHO_PersonBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = view_IMPHO_PersonBindingSource.Current as View_IMPHO_Person;
            var age = MainModule.GetAge(MainModule.GetDateFromPersianString(current.BirthDate));
            txtAge.Text = age.ToString();
            if (current.Photo== null)
            {
                pictureBox1.Image = null;
                return;
            }



            MemoryStream mem = new MemoryStream(current.Photo.ToArray());
            pictureBox1.Image = Image.FromStream(mem);

            //////////////چک کردن تاریخ انقضا 

        }

     

        public static DateTime ToDateTime(String str)
        {
            String[] date = str.Split('/');
            if (date.Length < 3)
                return DateTime.Now;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dtstart = pc.ToDateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]), 0, 0, 0, 0);
            return dtstart;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }



    }


   
}