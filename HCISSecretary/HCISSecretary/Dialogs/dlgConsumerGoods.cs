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
using HCISSecretary.Forms;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Dialogs;
using HCISSecretary.Data;
using HCISSecretary.Classes;

namespace HCISSecretary.Dialogs
{
    public partial class dlgConsumerGoods : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson;
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        public GivenServiceM RefGSM { get; set; }
        public Reference Ref { get; set; }
        private bool flag;
        private bool fromRef = false;
        public decimal PatientShare;
        public decimal InsuranceShare;
        public bool paraclinic = false;
        public bool fromnurse { get; set; }
        public Guid NurseDep { get; set; }
        public Speciality spes { get; set; }
        public List<Service> patientParaClinic = new List<Service>();
        public List<GivenServiceD> lstGSD = new List<GivenServiceD>();
        public Guid InstallLocation;
        //public GivenServiceM todayGSM { get; set; }
        public bool fromdlgtoday = false;
        List<Service> lstSrv;

        public dlgConsumerGoods()
        {
            InitializeComponent();
        }

        private void frmOutDoor_Load(object sender, EventArgs e)
        {
            if (paraclinic)
                txtBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        void GetData()
        {
            try
            {
                EndEdit();
                GSMBindingSource.DataSource = EditingGivenM;
                PersonBindingSource.DataSource = EditingPerson;

                ParaClinicBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 12).ToList();

                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                if (fromnurse)
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == NurseDep).ToList();
                else
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == MainModule.MyDepartment.ID).ToList();
                //departmentBindingSource_CurrentChanged(null, null);
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                serviceCategoriesBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 3 || x.ID == 8 || x.ID == 9).ToList();
                serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.خدمات_کلینیکی).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void brbOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                //if (fromdlgtoday)
                //{
                    var cur = givenServiceDBindingSource.Current as GivenServiceD;
                    if (cur == null)
                    {
                        MessageBox.Show(".لطفا خدمت پاراکلینیکی را وارد کنید");
                    }
                //}
                //else
                //{
                //    var dossier = new Dossier()
                //    {
                //        Date = today,
                //        Time = now,
                //        DepartmentID = InstallLocation,
                //        NationalCode = EditingPerson.NationalCode,
                //        Person = EditingPerson
                //    };
                //    dc.Dossiers.InsertOnSubmit(dossier);
                //    EditingGivenM.Dossier = dossier;
                //}
                var lstNew = lstGSD.Where(x => x.ID == Guid.Empty).ToList();
                if (!patientParaClinic.Any() && !lstNew.Any())
                {
                    MessageBox.Show("هیچ خدمتی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (lstNew.Any())
                {
                    //GivenServiceM gsm = null;
                    //if (fromdlgtoday)
                    //{
                    //gsm = todayGSM;
                    //}
                    //else
                    //{
                    //    gsm = new GivenServiceM()
                    //    {
                    //        PersonID = EditingPerson.ID,
                    //        Date = today,
                    //        Time = now,
                    //        LastModificationDate = today,
                    //        LastModificationTime = now,
                    //        InsuranceID = (lkpInsurance.EditValue as Insurance).ID,
                    //        Dossier = EditingGivenM.Dossier,
                    //        RequestDate = today,
                    //        RequestTime = now,
                    //        CreatorUserID = MainModule.UserID,
                    //        CreationDate = today,
                    //        CreationTime = now,
                    //        Confirm = true,
                    //        DepartmentID = InstallLocation,
                    //        ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                    //    };
                    //    if (checkEdit1.Checked == true)
                    //        gsm.RequestStaffID = null;
                    //    else
                    //        gsm.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                    //}
                    var gsm = new GivenServiceM()
                    {
                        ParentID = EditingGivenM.ID,
                        Person = EditingPerson,
                        Date = today,
                        Time = now,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        InsuranceID = (lkpInsurance.EditValue as Insurance).ID,
                        Dossier = EditingGivenM.Dossier,
                        RequestDate = today,
                        RequestTime = now,
                        CreatorUserID = MainModule.UserID,
                        CreationDate = today,
                        CreationTime = now,
                        Confirm = true,
                        Department = MainModule.MyDepartment,
                        ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                    };
                    if (checkEdit1.Checked == true)
                        gsm.RequestStaffID = null;
                    else
                        gsm.RequestStaffID = (staffBindingSource.Current as Staff).ID;

                    if (gsm.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(gsm);

                    foreach (var gsd in lstNew)
                    {
                        gsd.GivenServiceM = gsm;
                        gsd.LastModificationDate = today;
                        gsd.LastModificationTime = now;
                        var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == (lkpInsurance.EditValue as Insurance).ID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        }

                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    }
                }

                EditingGivenM.Date = today;
                EditingGivenM.Time = now;
                EditingGivenM.RequestDate = today;
                EditingGivenM.RequestTime = now;
                EditingGivenM.Person = EditingPerson;
                EditingGivenM.ServiceCategoryID = 12;
                EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                EditingGivenM.BookletExpireDate = txtBookLetExpire.Text;
                EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                EditingGivenM.BookletDate = today;
                EditingGivenM.Confirm = true;
                EditingGivenM.Insurance = (lkpInsurance.EditValue as Insurance);
                EditingGivenM.LastModificator = MainModule.UserID;
                EditingGivenM.LastModificationDate = today;
                EditingGivenM.LastModificationTime = now;
                EditingGivenM.CreatorUserID = MainModule.UserID;

                if (fromRef)
                {
                    EditingGivenM.ParentID = RefGSM.ID;
                    Ref.Confirm = true;
                }
                if (fromnurse == false)
                    EditingGivenM.DepartmentID = MainModule.MyDepartment.ID;
                else
                    EditingGivenM.DepartmentID = NurseDep;

                EditingGivenM.CreationDate = today;
                EditingGivenM.CreationTime = now;
                var ins = lkpInsurance.EditValue as Insurance;
                //if (ins != null)
                //    EditingPerson.InsuranceName = ins.Name;
                //if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                //{
                //    MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                if (EditingGivenM.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);

                var lst = patientParaClinic.Where(x => x.ID == Guid.Empty).ToList();

                lst.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        Service = x,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        LastModificator = MainModule.UserID,
                        Date = today,
                        Time = now,
                        Amount = x.Number,
                    };
                    var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == (lkpInsurance.EditValue as Insurance).ID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                });

                EditingGivenM.PaymentPrice = EditingGivenM.GivenServiceDs.Sum(x => x.PatientShare);
                if (EditingGivenM.PaymentPrice == 0)
                {
                    EditingGivenM.Payed = true;
                    EditingGivenM.PayedPrice = 0;
                }
                
                dc.SubmitChanges();
                MessageBox.Show("خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                patientParaClinic.Clear();
                lstGSD.Clear();
                //lstSrv.Clear();
                SelectedParaClinicBindingSource.DataSource = null;
                ClearAll();
                departmentBindingSource_CurrentChanged(null, null);
                fromRef = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ClearAll()
        {
            EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };
            GSMBindingSource.DataSource = EditingGivenM;
            EditingPerson = null;
            txtName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            txtNationalCode.Text = "";
            txtBirthDate.Text = "";
            //txtBookLetNo.Text = "";
            pictureEdit1.EditValue = null;
            lkpInsurance.EditValue = null;
            txtBookLetExpire.Text = "";
            fromdlgtoday = false;
            lstGSD.Clear();
            givenServiceDBindingSource.DataSource = null;
            gridView3.RefreshData();
            checkEdit1.Checked = false;
            searchLookUpEdit2.EditValue = null;
            lstSrv = null;

        }

        void EndEdit()
        {
            GSMBindingSource.EndEdit();
            PersonBindingSource.EndEdit();
        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var dep = departmentBindingSource.Current as Department;
            if (dep == null) return;
            //agendaBindingSource.DataSource = dc.Agendas.Where(c=>c.DepartmentID==dep.ID).ToList();
            var date = MainModule.GetPersianDate(DateTime.Now);
            var ins = lkpInsurance.EditValue as Insurance;
            if (ins == null)
            {
                //agendaBindingSource.Clear();
                staffBindingSource.Clear();
                return;
            }
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
            if (fromdlgtoday)
            {
                var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)) && c.Staff.ID == EditingGivenM.Staff.ID).Select(d => d.Staff).Distinct();
                if (staff.Count() > 0)
                    staffBindingSource.DataSource = staff.ToList();
                else
                {
                    //agendaBindingSource.Clear();
                    staffBindingSource.Clear();
                }
            }

            else
            {
                var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID))).Select(d => d.Staff).Distinct();
                if (staff.Count() > 0)
                    staffBindingSource.DataSource = staff.ToList();
                else
                {
                    //agendaBindingSource.Clear();
                    staffBindingSource.Clear();
                }
            }
        }

        private void staffBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var staff = staffBindingSource.Current as Staff;
            if (staff == null) return;

            var SpecialityID = staff.SpecialityID;
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SpecialityID == SpecialityID).ToList();

        }

        private void brbClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode.HasChildren)
                return;
            var current = ParaClinicBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientParaClinic.Contains(current))
            {
                patientParaClinic.Add(current);
            }
            else
            {
                MessageBox.Show("این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedParaClinicBindingSource.DataSource = patientParaClinic;
            gridControl4.RefreshDataSource();
        }

        private void gridView3_DoubleClick_1(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
                return;
            if (current.Used)
            {
                MessageBox.Show(".این پنل را وارد کردید");
                return;
            }
            var ptm = dc.PatternMs.FirstOrDefault(x => x.ServiceMID == current.ServiceID);
            if (ptm == null || !ptm.PatternDs.Any())
            {
                MessageBox.Show(".برای این خدمت پنل آماده وارد نشده است");
                return;
            }
            if (lstSrv == null)
                lstSrv = new List<Service>();

            var lstPtd = ptm.PatternDs.ToList();
            foreach (var ptd in lstPtd)
            {
                int index = patientParaClinic.IndexOf(ptd.Service);
                if (index != -1)
                {
                    patientParaClinic.ElementAt(index).Number += (float)ptd.Amount;
                }
                else
                {
                    ptd.Service.Number = (float)ptd.Amount;
                    lstSrv.Add(ptd.Service);
                }
            }
            current.Used = true;
            patientParaClinic.AddRange(lstSrv);
            SelectedParaClinicBindingSource.DataSource = patientParaClinic;
            gridView4.RefreshData();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearAll();
            departmentBindingSource_CurrentChanged(null, null);
            fromRef = false;
            SelectedParaClinicBindingSource.DataSource = null;
            patientParaClinic.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var curent = searchLookUpEdit2.EditValue as Service;
            if (curent == null)
            {
                MessageBox.Show("ابتدا یک خدمت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lstGSD.Any(x => x.ServiceID == curent.ID))
            {
                MessageBox.Show("!این خدمت قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var gsd = new GivenServiceD()
            {
                Service = curent

            };
            lstGSD.Add(gsd);
            givenServiceDBindingSource.DataSource = lstGSD;
            gridControl3.RefreshDataSource();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                gridControl2.Enabled = false;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            }
            else
            {
                gridControl2.Enabled = true;
                var current = staffBindingSource.Current as Staff;
                if (current == null)
                    return;
                var SpecialityID = current.SpecialityID;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SpecialityID == SpecialityID).ToList();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            if (cur.ID == Guid.Empty)
            {
                lstGSD.Remove(cur);
                cur.Service = null;
                gridControl3.RefreshDataSource();

            }
            else
            {
                MessageBox.Show("!این خدمت توسط پزشک ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView4.DeleteSelectedRows();
        }
    }
}