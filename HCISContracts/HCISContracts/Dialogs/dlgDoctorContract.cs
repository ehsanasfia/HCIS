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
using HCISContracts.Data;
using HCISContracts.Classes;

using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISContracts.Dialogs
{
    public partial class dlgDoctorContract : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public bool IsEdit = false;
        public DoctorContract Doc { get; set; }
        List<DoctorPaymentCategory> lst = new List<DoctorPaymentCategory>();
        List<DoctorContractD> lst1 = new List<DoctorContractD>();
        public DoctorContractM ObjectRM { get; set; }
        public DoctorContractM EditingDoctorM { get; set; }
        public dlgDoctorContract()
        {
            InitializeComponent();
        }

        private void GetData1()
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            //serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
        }


        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var spc = slkpSpeciality.EditValue as Speciality;
            if (spc == null)
            {
                staffsBindingSource.DataSource = null;
                slkDoctorName.Enabled = false;
                return;
            }

            slkDoctorName.Enabled = true;
            if (checke.Checked == true)
            {
                staffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.ID == spc.ID && x.Offical == true);
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                staffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.ID == spc.ID && x.Offical == false);
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

        }

        private void dlgDoctorContract_Load(object sender, EventArgs e)
        {
            if (EditingDoctorM == null)
            {
                if (ObjectRM == null)
                {
                    ObjectRM = new DoctorContractM();
                }
                GetData1();
                txtStartDate.Text = MainModule.GetPersianDate(DateTime.Now);
                txtEndDate.Text = MainModule.GetPersianDate(DateTime.Now);
                doctorPaymentCategoryBindingSource.DataSource = dc.DoctorPaymentCategories.ToList();
            }
            else
            {
                if (ObjectRM == null)
                {
                    ObjectRM = new DoctorContractM();
                }
                if (EditingDoctorM.Rasmi == true)
                    checke.Checked = true;
                GetData1();
                txtStartDate.Text = MainModule.GetPersianDate(DateTime.Now);
                txtEndDate.Text = MainModule.GetPersianDate(DateTime.Now);
                txtContractNumber.Text = EditingDoctorM.ContractNumber;
                if (checke.Checked == true)
                {
                    calcSalaryBase.Value = (decimal)EditingDoctorM.SalaryBase;
                    clcPositionPercent.Text = EditingDoctorM.PositionPercentage.ToString();
                }
                if (EditingDoctorM.UseQeyreDolatiTariff)
                    rgbTariff.SelectedIndex = 0;
                else if (EditingDoctorM.UseKhososiTariff)
                    rgbTariff.SelectedIndex = 1;
                else if (EditingDoctorM.UseQeyreDolatiTariff)
                    rgbTariff.SelectedIndex = 2;
            }
            simpleButton1_Click(null, null);
            if (checke.Checked == true)
                rgbTariff.SelectedIndex = 0;
            else
                rgbTariff.SelectedIndex = 1;
        }

        public List<CD> ListItems { get; set; } = new List<CD>();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var stf = slkDoctorName.EditValue as Staff;

            if (stf == null)
            {
                ConditionValidationRule notEmpty = new ConditionValidationRule();
                notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
                notEmpty.ErrorText = ".دکتر را انتخاب کنید";
                dxValidationProvider1.SetValidationRule(slkDoctorName, notEmpty);
                dxValidationProvider1.Validate();
                return;
            }
            if (checke.Checked == true)
            {
                if (calcSalaryBase.Value == null || calcSalaryBase.Value == 0 || string.IsNullOrWhiteSpace(clcPositionPercent.Text))
                {
                    MessageBox.Show("لطفا اطلاعات رسمی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }

            ListItems.Where(c => c.Multiplier != null).ToList().ForEach(x =>
              {
                  dc.DoctorContractDs.InsertOnSubmit(new DoctorContractD()
                  {
                      DoctorPaymentCategory = x.DS_Category,
                      Multiplier = x.Multiplier,
                      DoctorContractM = ObjectRM
                  });
              });
            ObjectRM.StaffID = (slkDoctorName.EditValue as Staff).ID;
            ObjectRM.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectRM.CreatorUserFullname = MainModule.UserFullName;
            ObjectRM.CreatorUserID = MainModule.UserID;
            ObjectRM.ContractNumber = txtContractNumber.Text;
            ObjectRM.StartDate = txtStartDate.Text;
            ObjectRM.EndDate = txtEndDate.Text;
            ObjectRM.Rasmi = checke.Checked;
            if (rgbTariff.SelectedIndex == 0)
                ObjectRM.UseDolatiTariff = true;
            else if (rgbTariff.SelectedIndex == 1)
                ObjectRM.UseKhososiTariff = true;
            else if (rgbTariff.SelectedIndex == 2)
                ObjectRM.UseQeyreDolatiTariff = true;
            if (checke.Checked == true)
            {
                ObjectRM.SalaryBase = calcSalaryBase.Value;
                ObjectRM.PositionPercentage = float.Parse(clcPositionPercent.Text);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTax.Text))
                {
                    ObjectRM.TaxesPercentage = null;
                }
                else
                    ObjectRM.TaxesPercentage = float.Parse(txtTax.Text);
            }
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void checke_CheckedChanged(object sender, EventArgs e)
        {
            specialityBindingSource_CurrentChanged(null, null);
            layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup5.Expanded = true;
            ListItems.Clear();
            if (checke.Checked == true)
                rgbTariff.SelectedIndex = 0;
            else
                rgbTariff.SelectedIndex = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (EditingDoctorM == null)
            {
                ListItems.Clear();
                if (checke.Checked == true)
                    lst = dc.DoctorPaymentCategories.Where(x => x.ForOffical == true && x.Hide != true).ToList();
                else
                    lst = dc.DoctorPaymentCategories.Where(x => x.ForNonOffical == true && x.Hide != true).ToList();

                lst.ForEach(x =>
                {
                    ListItems.Add(new CD() { DS_Category = x, Multiplier = x.DefultRatio ?? 1 });
                });
                cDBindingSource1.DataSource = ListItems;
            }
            else
            {
                ListItems.Clear();
                var lst = dc.DoctorContractDs.Where(x => x.DoctorContractM.ID == EditingDoctorM.ID).ToList();
                foreach (var item in lst)
                {
                    ListItems.Add(new CD() { DS_Category = item.DoctorPaymentCategory, Multiplier = item.Multiplier });

                }
                cDBindingSource1.DataSource = ListItems;
            }
        }
    }

    public class CD
    {
        public DoctorPaymentCategory DS_Category { get; set; }
        public double? Multiplier { get; set; }
    }
}