using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{
    public partial class dlgDrugOnDischarge : DevExpress.XtraEditors.XtraForm
    {
        public dlgDrugOnDischarge()
        {
            InitializeComponent();
        }
        public Staff MyStaff;
        List<Service> lstDrug = new List<Service>();
        HCISDataContext dc = new HCISDataContext();
        public bool Editvalue = false;
        public GivenServiceM gsm = null;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            var current = DrugServiceserviceBindingSource.Current as Service;
            if (current == null)
                return;

            if (lstDrug.Contains(current))
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dep = lookUpEdit1.EditValue as Department;
            if (dep == null)
            {
                MessageBox.Show("ابتدا داروخانه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var phDrg = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == current.ID && c.PharmacyID == dep.ID);
            if (phDrg != null)
            {
                var NIS = phDrg.NIS;
                if (NIS)
                {
                    if (MessageBox.Show("این دارو در دارو خانه ی مورد نظر  NIS می باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                    current.IsNIS = true;
                }
            }

            var a = new Dialogs.dlgDrugPlan();
            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;

            lstDrug.Add(current);
            btnOk.Enabled = true;

            string str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit100.EditValue as string)) ? "" : (a.lookUpEdit100.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit3.EditValue as string)) ? "" : (a.lookUpEdit3.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;
            SelectedserviceBindingSource.DataSource = lstDrug;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            gridControl2.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("شما در حال ثبت خدمت برای \n \n" + "\"" + MainModule.GSM_Set.Person.FirstName + " " + MainModule.GSM_Set.Person.LastName + "\"" + " میباشید " + "\n\n" + "آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            if (lookUpEdit1.EditValue == null)
                return;
            if (lstDrug.Count > 0)
            {
                gsm = new GivenServiceM()
                {
                    ParentID = MainModule.GSM_Set.ID,
                    Priority = false,
                    PersonID = MainModule.GSM_Set.PersonID,
                    DepartmentID = (lookUpEdit1.EditValue as Department).ID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = MainModule.GSM_Set.InsuranceID,
                    InsuranceNo = MainModule.GSM_Set.InsuranceNo,
                    RequestStaffID = MyStaff.ID,// MainModule.GSM_Set.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.دارو,
                    DossierID = MainModule.GSM_Set.DossierID,
                    LastModificator = MainModule.UserID,
                    CreatorUserID = MainModule.UserID,
                    //  Staff = MyStaff
                };
                lstDrug.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        NIS = x.IsNIS,
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        DrugFrequencyUsage = x.HIX,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        CreatorUserFullname = MainModule.UserFullName,
                        Amount = x.Amount,
                        GivenAmount = x.Amount,
                    };

                    x.IsNIS = false;

                    if (gsd.NIS == true)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                        gsd.GivenAmount = 0;
                    }
                    else
                    {
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                            gsd.TotalPrice = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                    }
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                dc.SubmitChanges();
                MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                lstDrug.Clear();

                DialogResult = DialogResult.OK;
            }
        }

        private void dlgDrugOnDischarge_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e") && (x.Name == "داروخانه تخصصی 1" || x.Name == "داروخانه تخصصی 2")).ToList();
            lookUpEdit1.ItemIndex = 1;

            var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
            if (clinicStaff != null)
                MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
            GetData();
            Editvalue = true;
        }


        private void GetData()
        {
            var Pharmcy = lookUpEdit1.EditValue as Department;
            if (Pharmcy == null)
                return;
            var lstSpec = dc.SpecialityDrugs.Where(x => x.SpecialityID == MyStaff.SpecialityID).ToList();
            var lstPD = dc.PharmacyDrugs.ToList();

            var joined = lstPD.Join(lstSpec, pd => pd.DrugID, spc => spc.DrugID, (pd, spc) => pd).ToList();

            DrugServiceserviceBindingSource.DataSource = joined.Where(x => x.Department.ID == Pharmcy.ID).Select(x => x.Service).OrderBy(x => x.Name).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (Editvalue)
                GetData();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = SelectedserviceBindingSource.Current as Service;
            if (cur == null)
                return;
            lstDrug.Remove(cur);
            gridControl2.RefreshDataSource();
        }
    }
}