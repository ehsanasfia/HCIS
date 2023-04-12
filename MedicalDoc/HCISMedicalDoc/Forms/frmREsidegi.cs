using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISMedicalDoc.Data;

using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISMedicalDoc.Forms
{
    public partial class frmREsidegi : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        //DataClasses1DataContext bank = new DataClasses1DataContext();
        public ReferenceFile RF { get; set; }
        List<Spu_PriceConfirmResult> lst1 = new List<Spu_PriceConfirmResult>();
        List<Spu_PriceConfirmResult> lst2 = new List<Spu_PriceConfirmResult>();
        public frmREsidegi()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmREsidegi_Load(object sender, EventArgs e)
        {
            textEdit4.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            if (checkBox1Introduction.Checked == true)
            {
                mmdIntroduction.Enabled = true;
            }
            else
            {
                mmdIntroduction.Enabled = false;
            }
            vwHandelBindingSource.DataSource = dc.vwHandels.Where(c => c.ID == RF.PersonID && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).ToList();
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
            try
            {
                //if (Classes.MainModule.ReferenceFile_Set.Person.Photo != null)
                //{
                //    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                //    {
                //        var data = Classes.MainModule.ReferenceFile_Set.Person.Photo.ToArray();
                //        ms.Write(data, 0, data.Length);
                //        ms.Flush();
                //        barEditItem1.EditValue = Image.FromStream(ms);
                //    }
                //}
                //else if (Classes.MainModule.ReferenceFile_Set.Person.Photo == null)
                //{
                //    barEditItem1.EditValue = null;
                //}
            }
            catch
            { }

            if (Classes.MainModule.ReferenceFile_Set == null)
            {

            }
            else
            {
                barStaticItem1.Caption = "نام: " + Classes.MainModule.ReferenceFile_Set.Person.FirstName ?? "";
                barStaticItem2.Caption = "نام خانوادگی: " + Classes.MainModule.ReferenceFile_Set.Person.LastName ?? "";
                barStaticItem3.Caption = "شماره پذیرش : " + Classes.MainModule.ReferenceFile_Set.IDAdmit ?? "";
                barStaticItem4.Caption = "ردیف عائله : " + Classes.MainModule.ReferenceFile_Set.Person.NROrder ?? "";
                barStaticItem8.Caption = "ردیف عائله : " + Classes.MainModule.ReferenceFile_Set.Person.PersonalNo ?? "";
            }


            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                MessageBox.Show("شخص را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;

            }

            else
            {

            }
        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            var o = lookUpEdit3.EditValue as ServiceCategory;
            if (o == null)
            {
                return;
                vWServiceBindingSource.DataSource = null;
            }
            vWServiceBindingSource.DataSource = o.VWServices.ToList();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtamount.Text == "")
            {
                ConditionValidationRule notEmpty = new ConditionValidationRule();
                notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
                notEmpty.ErrorText = "تعداد را وارد کنید";
                dxValidationProvider1.SetValidationRule(txtamount, notEmpty);
                dxValidationProvider1.Validate();
                return;
            }
            if (lookUpEdit2.EditValue == null)
            {
                ConditionValidationRule notEmpty = new ConditionValidationRule();
                notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
                notEmpty.ErrorText = "تخصص را انتخاب کنید";
                dxValidationProvider1.SetValidationRule(lookUpEdit2, notEmpty);
                dxValidationProvider1.Validate();
                return;
            }
            if (lookUpEdit1.EditValue == null)
            {
                MessageBox.Show("نوع سرویس را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lookUpEdit2.EditValue == null)
            {
                MessageBox.Show("نوع تخصص را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtamount.Text == "")
            {
                MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (clc1.Text == "")
            {
                MessageBox.Show("هزینه درخواستی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (clc2.Text == "")
            {
                MessageBox.Show("هزینه تاییدشده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            Handle u = new Handle();
            u.ServiceID = Guid.Parse(lookUpEdit1.EditValue.ToString());
            u.ReferenceFileID = RF.ID;
            u.PriceRequest = Int32.Parse(clc1.Text);
            u.Price = clc2.Value;
            u.SPecialityID = Int32.Parse(lookUpEdit2.EditValue.ToString());
            u.CaseDeficit = comboBoxEdit2.Text;
            u.DatePrice = textEdit4.Text;
            u.txtPayed = comboBoxEdit1.Text;
            u.Introductiontxt = checkBox1Introduction.Checked;
            u.txtIntroduction = mmdIntroduction.Text;

            u.Amount = Int32.Parse(txtamount.Text);
            u.CreatorUserID = Classes.MainModule.UserID;
            u.CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            u.CreationTime = DateTime.Now.ToString("HH:mm");
            u.DepartmanID = Classes.MainModule.MyDepartment.ID;
            dc.Handles.InsertOnSubmit(u);
            dc.SubmitChanges();
            vwHandelBindingSource.DataSource = dc.vwHandels.Where(c => c.ID == RF.PersonID && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).ToList();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            textEdit3.Text = "";
            lookUpEdit3.EditValue = null;
            lookUpEdit1.EditValue = null;
            txtamount.Text = null;
            lookUpEdit2.EditValue = null;
            clc1.Text = "";
            clc2.Text = "";
            comboBoxEdit2.Text = "";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var s = dc.Services.Where(c => c.SalamatBookletCode.CompareTo(textEdit3.Text.Trim()) == 0).FirstOrDefault();
            if (s == null)
                return;
            vWServiceBindingSource.DataSource = s;
            lookUpEdit1.EditValue = s.ID;
            lookUpEdit3.EditValue = s.ServiceCategory;
        }

        private void simpleButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var s = dc.VWServices.Where(c => c.IDInt == Int32.Parse(textEdit3.Text)).FirstOrDefault();
                if (s == null)
                    return;
                vWServiceBindingSource.DataSource = s;
                lookUpEdit1.EditValue = s.ID;
            }
        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var s = dc.VWServices.Where(c => c.IDInt == Int32.Parse(textEdit3.Text)).FirstOrDefault();
                if (s == null)
                    return;
                vWServiceBindingSource.DataSource = s;
                lookUpEdit1.EditValue = s.ID;
                lookUpEdit3.EditValue = s.ServiceCategory;

            }
        }

        private void checkBox1Introduction_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1Introduction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1Introduction.Checked == true)
            {
                mmdIntroduction.Enabled = true;
            }
            else
            {
                mmdIntroduction.Enabled = false;
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new frmHistory();
            dlg.NationalCode2 = Classes.MainModule.ReferenceFile_Set.Person.ID;

            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {


            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged_1(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                var serv = Guid.Parse(lookUpEdit1.EditValue.ToString());

                var price = dc.FindPrice(serv, RF.IDInsurance, Classes.MainModule.GetPersianDate(DateTime.Now));
                if (price == 0 || price == null)
                    clc1.Value = clc2.Value = 0;
                else
                    clc1.Value = clc2.Value = (decimal)price;

            }
            else
                clc1.Value = clc2.Value = 0;

        }

        private void txtamount_EditValueChanged(object sender, EventArgs e)
        {
            var amount = txtamount.Value;

            if (lookUpEdit1.EditValue != null)
            {
                var serv = Guid.Parse(lookUpEdit1.EditValue.ToString());

                var price = dc.FindPrice(serv, RF.IDInsurance, Classes.MainModule.GetPersianDate(DateTime.Now));
                if (price == 0 || price == null)
                    clc1.Value = clc2.Value = 0;
                else
                    clc1.Value = clc2.Value = (decimal)price * amount;

            }
            else
                clc1.Value = clc2.Value = 0;


        }
    }
}
