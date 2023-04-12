using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class dlgtarifdaro : DevExpress.XtraEditors.XtraForm
    {
        
        public HCISDataContexDataContext dc { get; set; }
        public Service C { get; set; }
        public bool isEdit { get; set; }
        public dlgtarifdaro()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lkpGroup.Text == "")
            {
                MessageBox.Show("گروه دارو را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("نام دارو را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (isEdit == true)
            {
                C.MeasurementDefinition = (searchLookUpEdit1.EditValue as MeasurementDefinition);
                // dc.Services.InsertOnSubmit(u);
                dc.SubmitChanges();

            }
            if (isEdit == true)
            {

                //if (dc.PharmacyDrugs.Any(c=> c.DrugID == C.ID))
                //{
                //    MessageBox.Show("دارو برای داروخانه ثبت شده امکان ویرایش وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                //if (dc.GivenServiceDs.Any(c => c.ServiceID == C.ID))
                //{
                //    MessageBox.Show("دارو در نسخه ثبت شده امکان ویرایش وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}

                C.Name = txtName.Text;
               // C.Name_En = txtEnname.Text;
                C.Shape = cmbShape.Text;
                C.MESCCode_No = txtMESC.Text;
                C.CaliforniaCode = txtCalif.Text;
                //u.Price = Int32.Parse(spnPrice.Text);
                C.CategoryID = 4;
                C.SalamatBookletCode = txtSalamatCode.Text;
                C.HIXCode = txtshenaseHIX.Text;
                C.NIS = false;
                C.Service1 = (lkpGroup.EditValue as Service);
                C.MeasurementDefinition = (searchLookUpEdit1.EditValue as MeasurementDefinition);
                C.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                C.LastModificationTime = DateTime.Now.ToString("HH:mm");
                C.LastMUserIFullName = MainModule.UserFullName;
                C.LastModificator = MainModule.UserID;
                // dc.Services.InsertOnSubmit(u);
                dc.SubmitChanges();
            }
            if (isEdit == false)
            {

                Service u = new Service();
                u.Name = txtName.Text;
              //  u.Name_En = txtEnname.Text;
                u.Shape = cmbShape.Text;
                u.MESCCode_No = txtMESC.Text;
                u.CaliforniaCode = txtCalif.Text;
                //u.Price = Int32.Parse(spnPrice.Text);
                u.CategoryID = 4;
                u.SalamatBookletCode = txtSalamatCode.Text;
                u.HIXCode = txtshenaseHIX.Text;
                u.NIS = false;
                u.Service1 = (lkpGroup.EditValue as Service);
                u.MeasurementDefinition = (searchLookUpEdit1.EditValue as MeasurementDefinition);
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreationUserIFullName = MainModule.UserFullName;
                u.CreatorUserID = MainModule.UserID;
                dc.Services.InsertOnSubmit(u);
                dc.SubmitChanges();
            }
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void dlgtarifdaro_Load(object sender, EventArgs e)
        {
            measurementDefinitionBindingSource.DataSource = dc.MeasurementDefinitions.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c=> c.ParentID == null &&
           ( c.ID == Guid.Parse("45e73d16-4ca5-4842-ab42-8d2370fc5559")
            || c.ID == Guid.Parse("91fe517d-a719-4bbe-bbf6-5a3e4eb1a208")
               || c.ID == Guid.Parse("68eb9096-52e9-432e-9ea1-0a9ac03a459f")
               || c.ID == Guid.Parse("64a61c9f-f864-41d6-845d-46e080a0030e")
                || c.ID == Guid.Parse("0d2db7d1-0be5-450b-b59b-218e2a602864")
                 || c.ID == Guid.Parse("043df2e3-56d5-49fe-80fc-200a9b201ca7"
                )

                       || c.ID == Guid.Parse("e1804155-52d4-46ef-bf50-47164805a455"
                )

                       || c.ID == Guid.Parse("5767fece-a76e-49bd-8c3e-716982eaa9c5"
                )
                        || c.ID == Guid.Parse("5d6c5a01-d55f-447f-8cc6-6305379a5f71"
                )
            )).ToList();
            if (isEdit == true)
            {
                txtName.ReadOnly = true;
                cmbShape.ReadOnly = true;
                lkpGroup.EditValue = C.Service1;
               txtName.Text = C.Name;
                //txtEnname.Text = C.Name_En;
                cmbShape.Text = C.Shape;
                txtMESC.Text = C.MESCCode_No;
                txtCalif.Text = C.CaliforniaCode;
               //u.Price = Int32.Parse(spnPrice.Text);
               // u.CategoryID = 4;
               txtSalamatCode.Text = C.SalamatBookletCode;
               txtshenaseHIX.Text = C.HIXCode;
                searchLookUpEdit1.EditValue =C. MeasurementDefinition;
            }
            lkpTabeghebandi.EditValue = 4;
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
        }
    }
}