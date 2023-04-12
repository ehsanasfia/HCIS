using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;
using HCISLab.Dialogs;

namespace HCISLab.Forms
{
    public partial class frmBatchPrinting : DevExpress.XtraEditors.XtraForm
    {
        List<GivenServiceM> lstGSM;
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();

        public frmBatchPrinting()
        {
            InitializeComponent();
        }

        private void frmBatchPrinting_Load(object sender, EventArgs e)
        {
            departmentsBindingSource.DataSource = dc.Departments.Where(x => 
                                                                    x.TypeID == 10 
                                                                    || x.TypeID == 11
                                                                    || x.TypeID == 13
                                                                    || x.TypeID == 14
                                                                    || x.TypeID == 15).OrderBy(x => x.Name).ToList();
            ToDtp.Text = FromDtp.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void bbiSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dep = slkDepartment.EditValue as Department;

                int? fromSN = (FromSnSpn.EditValue == null || FromSnSpn.Value == 0) ? null : (int?)FromSnSpn.Value;
                int? toSN = (ToSnSpn.EditValue == null || ToSnSpn.Value == 0) ? null : (int?)ToSnSpn.Value;


                lstGSM = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش
                        && x.Admitted
                        && x.AdmitDate != null
                        && x.DepartmentID == MainModule.InstallLocation.ID
                        //&& x.FromDepartmentObject != null
                        && x.AdmitDate.CompareTo(FromDtp.Text) >= 0
                        && x.AdmitDate.CompareTo(ToDtp.Text) <= 0
                        && (fromSN == null ? true : x.DailySN >= fromSN)
                        && (toSN == null ? true : x.DailySN <= toSN)
                        ).ToList();

                //lstGSM = lstGSM.Where(x =>
                //        ((dep == null) ? ((x.FromDepartmentObject.TypeID == 10
                //                || x.FromDepartmentObject.TypeID == 11
                //                || x.FromDepartmentObject.TypeID == 13
                //                || x.FromDepartmentObject.TypeID == 14
                //                || x.FromDepartmentObject.TypeID == 15))
                //            : (x.FromDepartmentObject != null && x.FromDepartmentObject.ID == dep.ID))).ToList();

                lstGSM = lstGSM.Where(x => {

                    var frDep = x.FromDepartmentObject;
                    
                    if (frDep == null)
                        return false;

                    if (dep != null)
                        return (x.FromDepartmentObject != null && x.FromDepartmentObject.ID == dep.ID);
                    

                    return frDep.TypeID == 10
                            || frDep.TypeID == 11
                            || frDep.TypeID == 13
                            || frDep.TypeID == 14
                            || frDep.TypeID == 15;

                }).ToList();

                //|| (x.Dossier != null && x.Dossier.DepartmentID != null && x.Dossier.DepartmentID == dep.ID)
                givenServiceMsBindingSource.DataSource = lstGSM;

                gridView1.ClearSorting();
                colDailySN.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void givenServiceMsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                givenServiceDsBindingSource.DataSource = null;
                return;
            }

            givenServiceDsBindingSource.DataSource = cur.GivenServiceDs.ToList();
            gridControl2.RefreshDataSource();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var curGsm = givenServiceMsBindingSource.Current as GivenServiceM;
                if (curGsm == null)
                    return;

                var EditingPerson = curGsm.Person;
                if (curGsm == null || EditingPerson.ID == Guid.Empty || curGsm == null || curGsm.ID == Guid.Empty)
                {
                    MessageBox.Show(" هیچ بیماری انتخاب نشده است یا بیمار وارد شده، ثبت و پذیرش نشده است.\r\nلطفا بیمار را از طریق جستجوی پذیرش یا کد ملی انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (string.IsNullOrWhiteSpace(EditingPerson.NationalCode) && string.IsNullOrWhiteSpace(EditingPerson.MedicalID))
                {
                    MessageBox.Show("بیمار، کد ملی و شناسه پزشکی ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var cur = givenServiceDsBindingSource.Current as GivenServiceD;
                if (cur == null)
                    return;
                if (cur.Service == null)
                    return;

                string nat = string.IsNullOrWhiteSpace(EditingPerson.NationalCode) ? null : EditingPerson.NationalCode.Trim();
                string med = string.IsNullOrWhiteSpace(EditingPerson.MedicalID) ? null : EditingPerson.MedicalID.Trim();

                var lst = dc.Spu_LabHistory(nat, med).Where(x => x.OldID != null && x.OldID == cur.Service.OldID).ToList();

                var answer =
                    from c in lst
                    select new
                    {
                        c.SerialNumber,
                        c.Result,
                        c.AdmitDate,
                        c.Abbr
                    };

                stiHistory.Dictionary.Variables.Add("TestName", cur.Service.LaboratoryServiceDetail == null ? (cur.Service.Name_En ?? cur.Service.Name) : cur.Service.LaboratoryServiceDetail.AbbreviationName);
                stiHistory.Dictionary.Variables.Add("Person", "");
                stiHistory.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));

                stiHistory.Dictionary.Variables.Add("Person", EditingPerson.FirstName + " " + EditingPerson.LastName);
                if (curGsm.Staff != null)
                {
                    stiHistory.Dictionary.Variables.Add("Doctor", curGsm.Staff.Person.FirstName + " " + curGsm.Staff.Person.LastName);
                }
                stiHistory.Dictionary.Variables.Add("Date", curGsm.AnsweringDate);


                stiHistory.RegData("Answer", answer);
                stiHistory.Dictionary.Synchronize();
                stiHistory.Compile();
                stiHistory.CompiledReport.ShowWithRibbonGUI();
                //stiHistory.Design();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;

            if (cur.Confirm)
            {
                MessageBox.Show("این بیمار قبلا تایید نهایی شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("آیا از تایید نهایی نتایج آزمایش این بیمار اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            cur.Confirm = true;
            dc.SubmitChanges();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}