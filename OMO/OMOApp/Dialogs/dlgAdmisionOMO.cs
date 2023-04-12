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
using System.IO;
using OMOApp.Data;
using OMOApp.Data.IMPHOData;
using OMOApp.Classes;
using OMOApp.Data.HCISData;


namespace OMOApp.Forms
{
    public partial class dlgAdmisionOMO : DevExpress.XtraEditors.XtraForm
    {
        JamiatClassesDataContext dcJ = new JamiatClassesDataContext();
        OMOClassesDataContext dco = new OMOClassesDataContext();
   
        
        public OMOApp.Data.Person OmoPrs { get; set; }

        public dlgAdmisionOMO()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                personBindingSource.EndEdit();
                dco.Persons.InsertOnSubmit(OmoPrs);
                dco.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
               
            }
          
        }

        private void frmAdmit_Load(object sender, EventArgs e)
        {
            definitionBindingSource1.DataSource = dco.Definitions.Where(c => c.ParentID == 1).ToList();
            
            manageMentBindingSource1.DataSource = dco.ManageMents.OrderBy(x => x.Name).ToList();

            companyBindingSource.DataSource = dco.Companies.OrderBy(x => x.Name).ToList();
            subCompanyBindingSource.DataSource = dco.SubCompanies.OrderBy(x => x.Name).ToList();
            unitBindingSource.DataSource = dco.Units.OrderBy(x => x.Name).ToList();
            if (OmoPrs == null)
            {
                OmoPrs = new Data.Person();
                OmoPrs.NationalCode = codeMeli;
                personBindingSource.DataSource = OmoPrs;
            }
        }
        
        private void EmptyForm()
        {
            txtFirstName.Text = "";
            txtAdress.Text = "";
            txtBirth.Text = "";
            txtFather.Text = "";
            slkManagment.EditValue= null;
            slkCompany.EditValue = null;
            slkSubCompany.EditValue = null;
            slkUnit.EditValue = null;
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            pictureEdit1.Image = null;
            OmoPrs = null;
        }

        private void spinEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            try
            {
                var today = Classes.MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                if (string.IsNullOrWhiteSpace(txtCodemeli.Text))
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                int id = -1;
                bool valid = int.TryParse(txtCodemeli.Text.Trim(), out id);
                if (id == -1 || !valid)
                {
                    MessageBox.Show("کد ملی معتبر نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                EmptyForm();
                OmoPrs = dco.Persons.Where(c => c.NationalCode == txtCodemeli.Text).FirstOrDefault();
                if (OmoPrs == null)
                {
                  var  JamiatPrs = dcJ.PersonTbls.Where(c => c.NationalCode == txtCodemeli.Text && c.RelationOrderNo == 0).FirstOrDefault();
                    if (JamiatPrs == null)
                    {
                        MessageBox.Show("فردی با کد شناسایی وارد شده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        OmoPrs = new Data.Person();
                        personBindingSource.DataSource = OmoPrs;

                    }
                    else
                    {
                        OmoPrs = new Data.Person()
                        {
                            Address = JamiatPrs.HomeAddress,
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            FirstName = JamiatPrs.Firstname,
                            LastName = JamiatPrs.Lastname,
                            FatherName = JamiatPrs.FatherName,
                            BirthDate = JamiatPrs.BirthDate + "",
                            PersonalNo = JamiatPrs.PersonnelNo,
                            NationalCode = txtCodemeli.Text,
                            PhoneNumber = JamiatPrs.HomePhone,
                            Sex = JamiatPrs.Sex == 0 ? false : true,
                           IDCompany=JamiatPrs.EmployeeInfoTbls.IDCompany,
                           IDManagement=JamiatPrs.EmployeeInfoTbls.IDManagement,
                           IDSubCompany=JamiatPrs.EmployeeInfoTbls.IDSubCompany,
                           IDunit=JamiatPrs.EmployeeInfoTbls.IDUnit
                        };
                    }

                }
                else
                {
                  
                    personBindingSource.DataSource = OmoPrs;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (OmoPrs == null)
            {
                visitBindingSource.DataSource = null;
            }
            else
            {
                visitBindingSource.DataSource = dco.Visits.Where(c => c.PersonID == OmoPrs.ID).OrderByDescending(c => c.AdmitDate).ToList();
            }
        }

       

        private void slkManagment_EditValueChanged(object sender, EventArgs e)
        {
            if (slkManagment.EditValue != null)
                companyBindingSource.DataSource = dco.Companies.Where(c => c.IDMg == Int32.Parse(slkManagment.EditValue.ToString())).ToList();

        }
        private void slkCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (slkCompany.EditValue.ToString() != "")
                subCompanyBindingSource.DataSource = dco.SubCompanies.Where(c => c.IDCo == Int32.Parse(slkCompany.EditValue.ToString()) && c.IDMg == Int32.Parse(slkManagment.EditValue.ToString())).ToList();
        }

        private void slkSubCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (slkSubCompany.EditValue !=null)
                unitBindingSource.DataSource = dco.Units.Where(c => c.IDMg == Int32.Parse(slkCompany.EditValue.ToString()) && c.IDOrgan == Int32.Parse(slkSubCompany.EditValue.ToString())).ToList();
        }

        private void slkUnit_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}