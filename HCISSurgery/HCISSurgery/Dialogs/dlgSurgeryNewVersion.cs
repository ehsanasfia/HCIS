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
using HCISSurgery.Dialogs;
using HCISSurgery.Data;
using HCISSurgery.Classes;
using System.Globalization;

namespace HCISSurgery.Dialogs
{
    public partial class dlgSurgeryNewVersion : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSDSurgery;
        public GivenServiceD ObjectGSDAnesthesia;
        public Surgery ObjectSurgery;
        public Surgery ObjectAnesthesia;
        public List<GivenServiceD> lstGSD;
        public GivenServiceD crnt { get; set; }
        public bool isEdit;
        public bool isNext;
        Staff STF = new Staff();
        bool isLoading = false;

        public dlgSurgeryNewVersion()
        {
            InitializeComponent();
        }

        private void EndEdit()
        {
            GSDAnesthesiaBindingSource.EndEdit();
            GSDSurgeryBindingSource.EndEdit();
            AnesthesiaBindingSource.EndEdit();
            SurgeryBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (ObjectGSDSurgery == null)
                {
                    ObjectGSDSurgery = new GivenServiceD();
                    ObjectSurgery = new Surgery();
                }
                ObjectSurgery.PropertyChanged += ObjectSurgery_PropertyChanged;

                if (ObjectGSDAnesthesia == null)
                {
                    ObjectGSDAnesthesia = new GivenServiceD();
                    ObjectAnesthesia = new Surgery();
                }

                if (lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }

                GSDAnesthesiaBindingSource.DataSource = ObjectGSDAnesthesia;
                GSDSurgeryBindingSource.DataSource = ObjectGSDSurgery;
                AnesthesiaBindingSource.DataSource = ObjectAnesthesia;
                SurgeryBindingSource.DataSource = ObjectSurgery;
                if(isLoading)
                {
                    ObjectGSDSurgery.Date = MainModule.GetPersianDate(DateTime.Now);
                    ObjectGSDAnesthesia.Date = MainModule.GetPersianDate(DateTime.Now);
                    ObjectGSDSurgery.Time = DateTime.Now.ToString("HH:mm");
                    ObjectGSDAnesthesia.Time = DateTime.Now.ToString("HH:mm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void ObjectSurgery_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Joze_Fanni")
            {
                ChangeValueS();
            }
            else if (e.PropertyName == "Joze_Herfei")
            {
                ChangeValueS();
            }
        }

        private void dlgSurgeryNewVersion_Load(object sender, EventArgs e)
        {
            lblNationalCode.Text = "کد ملی:" + " " + MainModule.GSM_Set.Person.NationalCode;
            lblName.Text = "نام:" + " " + MainModule.GSM_Set.Person.FirstName;
            lblLastName.Text = "نام خانوادگی:" + " " + MainModule.GSM_Set.Person.LastName;
            if (MainModule.GSM_Set.Person.BirthDate != null)
            {
                var age = MainModule.GetAge(MainModule.GetDateFromPersianString(MainModule.GSM_Set.Person.BirthDate));
                lblAge.Text = "سن:" + " " + age;
            }
            else
            {
                lblAge.Text = "سن:" + " ";
            }
            lblNationalCode2.Text = "کد ملی:" + " " + MainModule.GSM_Set.Person.NationalCode;
            lblName2.Text = "نام:" + " " + MainModule.GSM_Set.Person.FirstName;
            lblLastName2.Text = "نام خانوادگی:" + " " + MainModule.GSM_Set.Person.LastName;
            if (MainModule.GSM_Set.Person.BirthDate != null)
            {
                var age = MainModule.GetAge(MainModule.GetDateFromPersianString(MainModule.GSM_Set.Person.BirthDate));
                lblAge2.Text = "سن:" + " " + age;
            }
            else
            {
                lblAge2.Text = "سن:" + " ";
            }

            tadilAreaBindingSource.DataSource = dc.TadilAreas.OrderBy(c => c.SortColumn).ToList();
            personSurgeryBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            staffSurgeryCodeBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            serviceSurgeryBindingSource.DataSource = MainModule.DepSRV;
            serviceSurgeryCodeBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_جراحی).ToList();
            personAnesthesiaBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر" && (x.Staff.Speciality.ID == 24 || x.Staff.Speciality.ID == 39)).ToList();
            staffAnesthesiaCodeBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            serviceAnesthesiaBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بیهوشی && x.ParentID != null && x.Service1.Name == "عمل").ToList();
            serviceAnesthesiaCodeBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.بیهوشی).ToList();
            givenServiceDBindingSource.DataSource = lstGSD;

            if (isEdit)
            {
                var anesthesia = crnt.GivenServiceM.GivenServiceM1.GivenServiceMs.FirstOrDefault(x => x.CreationDate == crnt.Date && x.CreationTime == crnt.Time && x.ServiceCategoryID == 11);
                if (anesthesia != null)
                {
                    ObjectGSDAnesthesia = anesthesia.GivenServiceDs.FirstOrDefault();
                    if (ObjectGSDAnesthesia != null)
                        ObjectAnesthesia = ObjectGSDAnesthesia.Surgery;
                }
                ObjectGSDSurgery = crnt;
                ObjectSurgery = crnt.Surgery;
                var lst = crnt.GivenServiceM.GivenServiceDs;
                lstGSD = new List<GivenServiceD>();
                lstGSD.AddRange(lst);
                givenServiceDBindingSource.DataSource = lstGSD;
                gridControl2.RefreshDataSource();
            }
            if (isNext)
            {
                ObjectGSDSurgery = new GivenServiceD()
                {
                    TadilArea = crnt.TadilArea,
                    Staff = crnt.Staff,
                    Service = crnt.Service,
                };
                ObjectGSDAnesthesia = new GivenServiceD();
                ObjectSurgery = new Surgery();
                ObjectAnesthesia = new Surgery();
            }
            isLoading = true;
            GetData();
            isLoading = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ObjectGSDSurgery.Staff == null)
            {
                MessageBox.Show("لطفا جراح را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (ObjectGSDSurgery.Service == null)
            {
                MessageBox.Show("لطفا عمل را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (ObjectGSDSurgery.TadilArea == null)
            {
                MessageBox.Show("لطفا جزئیات عمل را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectGSDSurgery.Surgery = ObjectSurgery;
            STF = ObjectGSDSurgery.Staff;
            lstGSD.Add(ObjectGSDSurgery);
            givenServiceDBindingSource.DataSource = lstGSD;
            gridControl2.RefreshDataSource();

            //ObjectSurgery.ConfirmBasicSurgicalUnit = ObjectSurgery.BasicSurgicalUnit;
            //ObjectSurgery.ConfirmServiceID = ObjectSurgery.GivenServiceD.ServiceID;
            //ObjectSurgery.ConfirmFinalSupplementalUnit = ObjectSurgery.FinalSupplementalUnit;
            //ObjectSurgery.ConfirmOther = ObjectSurgery.ConfirmOther;
            //ObjectSurgery.ConfirmSupplementaryUnit = ObjectSurgery.SupplementaryUnit;
            //ObjectSurgery.ConfirmTadilAreaID = ObjectSurgery.GivenServiceD.TadilAreaID;
            //ObjectSurgery.ConfirmUltimateSurgicalUnit = ObjectSurgery.UltimateSurgicalUnit;
            //ObjectSurgery.FinanceConfirm = true;

            ObjectGSDSurgery = new GivenServiceD();
            ObjectSurgery = new Surgery();
            ObjectSurgery.PropertyChanged += ObjectSurgery_PropertyChanged;

            ObjectGSDSurgery.Staff = STF;
            ObjectGSDSurgery.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSDSurgery.Time = DateTime.Now.ToString("HH:mm");
            GSDSurgeryBindingSource.DataSource = ObjectGSDSurgery;
            SurgeryBindingSource.DataSource = ObjectSurgery;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                if (isNext)
                {
                    if (lstGSD.Any())
                    {
                        var gsmSIN = new GivenServiceM()
                        {
                            ParentID = crnt.GivenServiceMID,
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            PersonID = MainModule.GSM_Set.PersonID,
                            DossierID = MainModule.GSM_Set.DossierID,
                            LastModificationDate = today,
                            LastModificationTime = now,
                            LastModificator = MainModule.UserID,
                            ServiceCategoryID = (int)Category.خدمات_جراحی,
                            DepartmentID = MainModule.MyDepartment.ID,
                            InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                            InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                            Date = today,
                            Time = now
                        };
                        foreach (var item in lstGSD)
                        {
                            item.GivenServiceM = gsmSIN;
                            item.Amount = 1;
                            item.GivenAmount = 1;
                            item.LastModificationDate = today;
                            item.LastModificationTime = now;
                            item.LastModificator = MainModule.UserID;

                            if (item.ID == Guid.Empty)
                            {
                                dc.GivenServiceDs.InsertOnSubmit(item);
                                if (item.Surgery != null)
                                    dc.Surgeries.InsertOnSubmit(item.Surgery);
                            }
                            else if (item.Surgery != null && item.Surgery.ID == Guid.Empty)
                            {
                                dc.Surgeries.InsertOnSubmit(item.Surgery);
                            }
                        }
                        if (gsmSIN.ID == Guid.Empty)
                        {
                            dc.GivenServiceMs.InsertOnSubmit(gsmSIN);
                        }
                    }
                    if (ObjectGSDAnesthesia.Service != null && ObjectGSDAnesthesia.Staff != null)
                    {
                        var gsmAIN = new GivenServiceM()
                        {
                            ParentID = crnt.GivenServiceMID,
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            PersonID = MainModule.GSM_Set.PersonID,
                            DossierID = MainModule.GSM_Set.DossierID,
                            LastModificationDate = today,
                            LastModificationTime = now,
                            LastModificator = MainModule.UserID,
                            ServiceCategoryID = (int)Category.بیهوشی,
                            DepartmentID = MainModule.MyDepartment.ID,
                            InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                            InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                            Date = today,
                            Time = now
                        };
                        ObjectGSDAnesthesia.GivenServiceM = gsmAIN;
                        ObjectGSDAnesthesia.Amount = 1;
                        ObjectGSDAnesthesia.GivenAmount = 1;
                        ObjectGSDAnesthesia.LastModificationDate = today;
                        ObjectGSDAnesthesia.LastModificationTime = now;
                        ObjectGSDAnesthesia.LastModificator = MainModule.UserID;
                        ObjectAnesthesia.GivenServiceD = ObjectGSDAnesthesia;

                        if (ObjectAnesthesia.ID == Guid.Empty)
                        {
                            dc.Surgeries.InsertOnSubmit(ObjectAnesthesia);
                        }
                        if (ObjectGSDAnesthesia.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(ObjectGSDAnesthesia);
                        }
                        if (gsmAIN.ID == Guid.Empty)
                        {
                            dc.GivenServiceMs.InsertOnSubmit(gsmAIN);
                        }
                    }
                }
                else
                {
                    if (lstGSD.Any())
                    {
                        var gsmS = new GivenServiceM()
                        {
                            ParentID = MainModule.GSM_Set.ID,
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            PersonID = MainModule.GSM_Set.PersonID,
                            DossierID = MainModule.GSM_Set.DossierID,
                            LastModificationDate = today,
                            LastModificationTime = now,
                            LastModificator = MainModule.UserID,
                            ServiceCategoryID = (int)Category.خدمات_جراحی,
                            DepartmentID = MainModule.MyDepartment.ID,
                            InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                            InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                            Date = today,
                            Time = now
                        };
                        foreach (var item in lstGSD)
                        {
                            item.GivenServiceM = gsmS;
                            item.Amount = 1;
                            item.GivenAmount = 1;
                            item.LastModificationDate = today;
                            item.LastModificationTime = now;
                            item.LastModificator = MainModule.UserID;

                            if (item.ID == Guid.Empty)
                            {
                                dc.GivenServiceDs.InsertOnSubmit(item);
                                if (item.Surgery != null)
                                    dc.Surgeries.InsertOnSubmit(item.Surgery);
                            }
                            else if (item.Surgery != null && item.Surgery.ID == Guid.Empty)
                            {
                                dc.Surgeries.InsertOnSubmit(item.Surgery);
                            }
                        }
                        if (gsmS.ID == Guid.Empty)
                        {
                            dc.GivenServiceMs.InsertOnSubmit(gsmS);
                        }
                    }
                    if (ObjectGSDAnesthesia.Service != null && ObjectGSDAnesthesia.Staff != null)
                    {
                        var gsmA = new GivenServiceM()
                        {
                            ParentID = MainModule.GSM_Set.ID,
                            CreationDate = today,
                            CreationTime = now,
                            CreatorUserID = MainModule.UserID,
                            PersonID = MainModule.GSM_Set.PersonID,
                            DossierID = MainModule.GSM_Set.DossierID,
                            LastModificationDate = today,
                            LastModificationTime = now,
                            LastModificator = MainModule.UserID,
                            ServiceCategoryID = (int)Category.بیهوشی,
                            DepartmentID = MainModule.MyDepartment.ID,
                            InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                            InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                            Date = today,
                            Time = now
                        };
                        ObjectGSDAnesthesia.GivenServiceM = gsmA;
                        ObjectGSDAnesthesia.Amount = 1;
                        ObjectGSDAnesthesia.GivenAmount = 1;
                        ObjectGSDAnesthesia.LastModificationDate = today;
                        ObjectGSDAnesthesia.LastModificationTime = now;
                        ObjectGSDAnesthesia.LastModificator = MainModule.UserID;
                        ObjectAnesthesia.GivenServiceD = ObjectGSDAnesthesia;

                        if (ObjectAnesthesia.ID == Guid.Empty)
                        {
                            dc.Surgeries.InsertOnSubmit(ObjectAnesthesia);
                        }
                        if (ObjectGSDAnesthesia.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(ObjectGSDAnesthesia);
                        }
                        if (gsmA.ID == Guid.Empty)
                        {
                            dc.GivenServiceMs.InsertOnSubmit(gsmA);
                        }
                    }
                }
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceD>().Where(x => x.GivenServiceMID == null).ToList();
                foreach (var gsd in lstToDelete)
                {
                    if (gsd.Surgery != null && dc.GetChangeSet().Inserts.Contains(gsd.Surgery))
                        dc.Surgeries.DeleteOnSubmit(gsd.Surgery);
                    if (gsd.AnesthesiaReport != null && dc.GetChangeSet().Inserts.Contains(gsd.AnesthesiaReport))
                        dc.AnesthesiaReports.DeleteOnSubmit(gsd.AnesthesiaReport);
                    if (gsd.AfterSurgeryReport != null && dc.GetChangeSet().Inserts.Contains(gsd.AfterSurgeryReport))
                        dc.AfterSurgeryReports.DeleteOnSubmit(gsd.AfterSurgeryReport);

                    dc.GivenServiceDs.DeleteOnSubmit(gsd);
                }
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void ChangeValueS()
        {
            if (ObjectSurgery != null && ObjectSurgery.Joze_Fanni != null && ObjectSurgery.Joze_Herfei != null)
            {
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
            }
            else
            {
                ObjectSurgery.UltimateSurgicalUnit = null;
            }
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            if (MessageBox.Show("آیا مایلید عمل را حذف کنید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            gridView2.DeleteSelectedRows();
        }

        private void txtSurgeryFinishTime_Validated(object sender, EventArgs e)
        {
            if (ObjectSurgery == null || ObjectSurgery.StartTime == null || ObjectSurgery.EndTime == null)
                ObjectSurgery.SurgeryTime = null;
            else
            {
                DateTime dt1 = DateTime.ParseExact(ObjectSurgery.EndTime, "HH:mm", new DateTimeFormatInfo());
                DateTime dt2 = DateTime.ParseExact(ObjectSurgery.StartTime, "HH:mm", new DateTimeFormatInfo());
                TimeSpan ts = dt1.Subtract(dt2);
                ObjectSurgery.SurgeryTime = new DateTime(ts.Ticks).ToString("HH:mm");
            }
        }

        private void txtAnesthesiaFinishTime_Validated(object sender, EventArgs e)
        {
            if (ObjectAnesthesia == null || ObjectAnesthesia.StartTime == null || ObjectAnesthesia.EndTime == null)
                ObjectAnesthesia.SurgeryTime = null;
            else
            {
                DateTime dt1 = DateTime.ParseExact(ObjectAnesthesia.EndTime, "HH:mm", new DateTimeFormatInfo());
                DateTime dt2 = DateTime.ParseExact(ObjectAnesthesia.StartTime, "HH:mm", new DateTimeFormatInfo());
                TimeSpan ts = dt1.Subtract(dt2);
                ObjectAnesthesia.SurgeryTime = new DateTime(ts.Ticks).ToString("HH:mm");
            }
        }

        private void lkpAnesthesia_EditValueChanged(object sender, EventArgs e)
        {
            var srv = lkpAnesthesia.EditValue as Service;
            ObjectAnesthesia.UltimateSurgicalUnit = 0;
        }

        private void slkSurgeon_EditValueChanged(object sender, EventArgs e)
        {
            var vluID = slkSurgeon.EditValue as Guid?;
            if (vluID != null)
            {
                var vlu = dc.Services.FirstOrDefault(x => x.ID == vluID);
                ObjectGSDSurgery.Service = vlu;

                if (ObjectGSDSurgery.TadilArea == null)
                {
                    ObjectSurgery.Joze_Fanni = 0;
                    ObjectSurgery.Joze_Herfei = 0;
                    ObjectSurgery.UltimateSurgicalUnit = 0;
                }
                else
                {
                    double? jf = 0;
                    double? jh = 0;
                    //if (ObjectSurgery.Joze_Fanni == null || ObjectSurgery.Joze_Fanni == 0.0 || ObjectSurgery.Joze_Herfei == null || ObjectSurgery.Joze_Herfei == 0.0)
                    //{
                    var jfh = dc.RVUs.FirstOrDefault(x => x.NationalID == ObjectGSDSurgery.Service.SalamatBookletCode);
                    if (jfh == null)
                    {
                        jf = 0;
                        jh = 0;
                    }
                    else
                    {
                        jf = jfh.Joze_Fanni_27 == null ? 0 : jfh.Joze_Fanni_27;
                        jh = jfh.Joze_Herfeyi_26 == null ? 0 : jfh.Joze_Herfeyi_26;
                    }
                    //}
                    var prc = ObjectGSDSurgery.TadilArea.TadilpercentValue / 100.0d;
                    ObjectSurgery.Joze_Fanni = jf * prc;
                    ObjectSurgery.Joze_Herfei = jh * prc;
                    ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
                }
            }
            else
            {
                ObjectGSDSurgery.Service = null;
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
            }
        }

        private void lkpSurgeonCode_EditValueChanged(object sender, EventArgs e)
        {
            var vluID = lkpSurgeonCode.EditValue as Guid?;
            if (vluID != null)
            {
                var vlu = dc.Services.FirstOrDefault(x => x.ID == vluID);
                ObjectGSDSurgery.Service = vlu;
            }
            else
            {
                ObjectGSDSurgery.Service = null;
            }
        }

        private void slkDetail_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkDetail.EditValue as TadilArea;
            if (ObjectGSDSurgery.Service == null)
            {
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
            }
            else if (cur == null)
            {
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
            }
            else
            {
                double? jf = 0;
                double? jh = 0;
                //if (ObjectSurgery.Joze_Fanni == null || ObjectSurgery.Joze_Fanni == 0.0 || ObjectSurgery.Joze_Herfei == null || ObjectSurgery.Joze_Herfei == 0.0)
                //{
                var jfh = dc.RVUs.FirstOrDefault(x => x.NationalID == ObjectGSDSurgery.Service.SalamatBookletCode);
                if (jfh == null)
                {
                    jf = 0;
                    jh = 0;
                }
                else
                {
                    jf = jfh.Joze_Fanni_27 == null ? 0 : jfh.Joze_Fanni_27;
                    jh = jfh.Joze_Herfeyi_26 == null ? 0 : jfh.Joze_Herfeyi_26;
                }
                //}
                var prc = cur.TadilpercentValue / 100.0d;
                ObjectSurgery.Joze_Fanni = jf * prc;
                ObjectSurgery.Joze_Herfei = jh * prc;
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
            }
        }
    }
}