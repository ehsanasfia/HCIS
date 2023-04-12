using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Dialogs
{
    public partial class dlgAngiography : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD GSDg;
        public GivenServiceD GSDp;
        public GivenServiceD crnt;
        Angio ANGg;
        Angio ANGp;
        List<GivenServiceD> lstGSD;
        List<GivenServiceD> lstGSDG;
        List<GivenServiceD> lstGSDP;
        public bool isNext;

        public dlgAngiography()
        {
            InitializeComponent();
        }
        private void EndEdit()
        {
            GSDAngioGBindingSource.EndEdit();
            GSDAngioPBindingSource.EndEdit();
            AngioGBindingSource.EndEdit();
            AngioPBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (GSDg == null)
                {
                    GSDg = new GivenServiceD();
                }
                if (GSDp == null)
                {
                    GSDp = new GivenServiceD();
                }
                if (ANGg == null)
                {
                    ANGg = new Angio();
                }
                if (ANGp == null)
                {
                    ANGp = new Angio();
                }
                if (lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }
                if (lstGSDG == null)
                {
                    lstGSDG = new List<GivenServiceD>();
                }
                if (lstGSDP == null)
                {
                    lstGSDP = new List<GivenServiceD>();
                }

                GSDAngioGBindingSource.DataSource = GSDg;
                GSDAngioPBindingSource.DataSource = GSDp;
                AngioGBindingSource.DataSource = ANGg;
                AngioPBindingSource.DataSource = ANGp;
                givenServiceDBindingSource.DataSource = lstGSD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void dlgAngiography_Load(object sender, EventArgs e)
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

            personGBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            personPBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            serviceGBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوگرافی).ToList();
            serviceGSalamatCodeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوگرافی).ToList();
            servicePBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوپلاستی).ToList();
            servicePSalamatCodeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوپلاستی).ToList();
            angioResultBindingSource.DataSource = dc.AngioResults.ToList();

            //if(isEdit == true)
            //{
            //GivenServiceM GSMG = null;
            //GSMG = GSDg.GivenServiceM.GivenServiceM1.GivenServiceMs.FirstOrDefault(x => x.CreationDate == GSDg.Date && x.CreationTime == GSDg.Time && x.ServiceCategoryID == (int)Category.آنژیوگرافی);

            //GivenServiceM GSMP = null;
            //GSMP = GSDp.GivenServiceM.GivenServiceM1.GivenServiceMs.FirstOrDefault(x => x.CreationDate == GSDp.Date && x.CreationTime == GSDp.Time && x.ServiceCategoryID == (int)Category.آنژیوپلاستی);

            //if (GSMG != null)
            //{
            //    ANGg = GSMG.Angio;
            //    var gsmP = dc.GivenServiceMs.FirstOrDefault(c => c.ServiceCategoryID == (int)Category.آنژیوپلاستی && c.GivenServiceM1 == GSDg.GivenServiceM.GivenServiceM1);
            //    if (gsmP != null)
            //    {
            //        GSDp = gsmP.GivenServiceDs.FirstOrDefault();
            //        ANGp = gsmP.Angio;
            //    }
            //    lstGSDG = new List<GivenServiceD>();
            //    lstGSDG.AddRange(GSMG.GivenServiceDs.ToList());
            //    lstGSDG.AddRange(gsmP.GivenServiceDs.ToList());
            //}
            //if (GSMP != null)
            //{
            //    ANGp = GSMP.Angio;
            //    var gsmG = dc.GivenServiceMs.FirstOrDefault(c => c.ServiceCategoryID == (int)Category.آنژیوگرافی && c.GivenServiceM1 == GSDp.GivenServiceM.GivenServiceM1);
            //    if (gsmG != null)
            //    {
            //        GSDg = gsmG.GivenServiceDs.FirstOrDefault();
            //        ANGg = gsmG.Angio;
            //    }
            //    lstGSDP = new List<GivenServiceD>();
            //    lstGSDP.AddRange(GSMP.GivenServiceDs.ToList());
            //    lstGSDP.AddRange(gsmG.GivenServiceDs.ToList());
            //}

            //lstGSD = new List<GivenServiceD>();

            //if (lstGSDG != null)
            //    lstGSD.AddRange(lstGSDG);
            //if (lstGSDP != null)
            //    lstGSD.AddRange(lstGSDP);
            //}
            if (isNext)
            {
                if (crnt.Service.CategoryID == (int)Category.آنژیوگرافی)
                {
                    GSDg = new GivenServiceD()
                    {
                        Service = crnt.Service,
                        Staff = crnt.Staff,
                        Comment = crnt.Comment
                    };
                    GSDp = new GivenServiceD();
                }
                if (crnt.Service.CategoryID == (int)Category.آنژیوپلاستی)
                {
                    GSDp = new GivenServiceD()
                    {
                        Service = crnt.Service,
                        Staff = crnt.Staff,
                        Comment = crnt.Comment
                    };
                    GSDg = new GivenServiceD();
                }
                ANGg = new Angio();
                ANGp = new Angio();
            }

            GetData();
        }

        private void btnAddAngio_Click(object sender, EventArgs e)
        {
            if ((slkAngiographist.EditValue as Staff) == null)
            {
                MessageBox.Show("لطفا آنژیوگرافیست را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if ((slkKindOfAngiography.EditValue as Service) == null)
            {
                MessageBox.Show("لطفا نوع آنژیوگرافی را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == GSDg.Service.ID && x.InsuranceID == MainModule.GSM_Set.InsuranceID);
            if (trf == null)
            {
                GSDg.PaymentPrice = 0;
                GSDg.PatientShare = 0;
                GSDg.InsuranceShare = 0;
                GSDg.TotalPrice = 0;
            }
            else if (trf.PatientShare == 0)
            {
                GSDg.Payed = true;
                GSDg.PaymentPrice = 0;
                GSDg.PatientShare = 0;
                GSDg.InsuranceShare = trf.OrganizationShare ?? 0;
                GSDg.TotalPrice = trf.OrganizationShare ?? 0;
            }
            else
            {
                GSDg.PaymentPrice = trf.PatientShare ?? 0;
                GSDg.PatientShare = trf.PatientShare ?? 0;
                GSDg.InsuranceShare = trf.OrganizationShare ?? 0;
                GSDg.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
            }

            if ((slkAngiographist.EditValue as Staff) != null && (slkKindOfAngiography.EditValue as Service) != null)
            {
                lstGSD.Add(GSDg);
                lstGSDG.Add(GSDg);
            }

            givenServiceDBindingSource.DataSource = lstGSD;
            grdSurgery.RefreshDataSource();
            GSDg = null;
            GSDp = null;
            GetData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((slkInteronshenist.EditValue as Staff) == null)
            {
                MessageBox.Show("لطفا اینترونشنیست را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if ((slkKindeOfAngioplasty.EditValue as Service) == null)
            {
                MessageBox.Show("لطفا نوع آنژیوپلاستی را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == GSDp.Service.ID && x.InsuranceID == MainModule.GSM_Set.InsuranceID);
            if (trf == null)
            {
                GSDp.PaymentPrice = 0;
                GSDp.PatientShare = 0;
                GSDp.InsuranceShare = 0;
                GSDp.TotalPrice = 0;
            }
            else if (trf.PatientShare == 0)
            {
                GSDp.Payed = true;
                GSDp.PaymentPrice = 0;
                GSDp.PatientShare = 0;
                GSDp.InsuranceShare = trf.OrganizationShare ?? 0;
                GSDp.TotalPrice = trf.OrganizationShare ?? 0;
            }
            else
            {
                GSDp.PaymentPrice = trf.PatientShare ?? 0;
                GSDp.PatientShare = trf.PatientShare ?? 0;
                GSDp.InsuranceShare = trf.OrganizationShare ?? 0;
                GSDp.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
            }

            if ((slkInteronshenist.EditValue as Staff) != null && (slkKindeOfAngioplasty.EditValue as Service) != null)
            {
                lstGSD.Add(GSDp);
                lstGSDP.Add(GSDp);
            }
            givenServiceDBindingSource.DataSource = lstGSD;
            grdSurgery.RefreshDataSource();
            GSDg = null;
            GSDp = null;
            GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            if (isNext)
            {
                if (lstGSDG.Any())
                {
                    var gsmGIN = new GivenServiceM()
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
                        ServiceCategoryID = (int)Category.آنژیوگرافی,
                        Angio = ANGg,
                        InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                        InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                        Date = today,
                        Time = now,
                        DepartmentID = Guid.Parse("07cd0272-b884-4d38-9ff4-feaf82274beb"),
                    };
                    foreach (var item in lstGSDG)
                    {
                        if (gsmGIN.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == item.ServiceID && x.InsuranceID == gsmGIN.InsuranceID);
                            if (trf == null)
                            {
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = 0;
                                item.TotalPrice = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                item.Payed = true;
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                item.PaymentPrice = trf.PatientShare ?? 0;
                                item.PatientShare = trf.PatientShare ?? 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
                            }
                        }
                        item.GivenServiceM = gsmGIN;
                        item.Amount = 1;
                        item.GivenAmount = 1;
                        item.Date = today;
                        item.Time = now;
                        item.LastModificationDate = today;
                        item.LastModificationTime = now;
                        item.LastModificator = MainModule.UserID;

                        if (item.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(item);
                        }
                    }
                    gsmGIN.PaymentPrice = gsmGIN.GivenServiceDs.Sum(x => x.PatientShare);
                    gsmGIN.TotalPrice = gsmGIN.GivenServiceDs.Sum(x => x.TotalPrice);
                    if (gsmGIN.PaymentPrice == 0)
                    {
                        gsmGIN.Payed = true;
                        gsmGIN.PayedPrice = 0;
                    }
                    ANGg.CreationDate = today;
                    ANGg.CreationTime = now;
                    ANGg.CreatorUserID = MainModule.UserID;
                    ANGg.GivenServiceM = gsmGIN;
                    if (ANGg.ID == Guid.Empty)
                    {
                        dc.Angios.InsertOnSubmit(ANGg);
                    }
                    if (gsmGIN.ID == Guid.Empty)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(gsmGIN);
                    }
                }
                if (lstGSDP.Any())
                {
                    var gsmPIN = new GivenServiceM()
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
                        ServiceCategoryID = (int)Category.آنژیوپلاستی,
                        Angio = ANGp,
                        InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                        InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                        Date = today,
                        Time = now,
                        DepartmentID = Guid.Parse("07cd0272-b884-4d38-9ff4-feaf82274beb"),
                    };
                    foreach (var item in lstGSDP)
                    {
                        if (gsmPIN.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == item.ServiceID && x.InsuranceID == gsmPIN.InsuranceID);
                            if (trf == null)
                            {
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = 0;
                                item.TotalPrice = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                item.Payed = true;
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                item.PaymentPrice = trf.PatientShare ?? 0;
                                item.PatientShare = trf.PatientShare ?? 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
                            }
                        }
                        item.GivenServiceM = gsmPIN;
                        item.Amount = 1;
                        item.GivenAmount = 1;
                        item.Date = today;
                        item.Time = now;
                        item.LastModificationDate = today;
                        item.LastModificationTime = now;
                        item.LastModificator = MainModule.UserID;

                        if (item.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(item);
                        }
                    }
                    gsmPIN.PaymentPrice = gsmPIN.GivenServiceDs.Sum(x => x.PatientShare);
                    gsmPIN.TotalPrice = gsmPIN.GivenServiceDs.Sum(x => x.TotalPrice);
                    if (gsmPIN.PaymentPrice == 0)
                    {
                        gsmPIN.Payed = true;
                        gsmPIN.PayedPrice = 0;
                    }
                    ANGp.CreationDate = today;
                    ANGp.CreationTime = now;
                    ANGp.CreatorUserID = MainModule.UserID;
                    ANGp.GivenServiceM = gsmPIN;
                    if (ANGp.ID == Guid.Empty)
                    {
                        dc.Angios.InsertOnSubmit(ANGp);
                    }
                    if (gsmPIN.ID == Guid.Empty)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(gsmPIN);
                    }
                }
            }
            else
            {
                if (lstGSDG.Any())
                {
                    var gsmG = new GivenServiceM()
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
                        ServiceCategoryID = (int)Category.آنژیوگرافی,
                        Angio = ANGg,
                        InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                        InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                        Date = today,
                        Time = now,
                        DepartmentID = Guid.Parse("07cd0272-b884-4d38-9ff4-feaf82274beb"),
                    };
                    foreach (var item in lstGSDG)
                    {
                        if (gsmG.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == item.ServiceID && x.InsuranceID == gsmG.InsuranceID);
                            if (trf == null)
                            {
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = 0;
                                item.TotalPrice = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                item.Payed = true;
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                item.PaymentPrice = trf.PatientShare ?? 0;
                                item.PatientShare = trf.PatientShare ?? 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
                            }
                        }
                        item.GivenServiceM = gsmG;
                        item.Amount = 1;
                        item.GivenAmount = 1;
                        item.Date = today;
                        item.Time = now;
                        item.LastModificationDate = today;
                        item.LastModificationTime = now;
                        item.LastModificator = MainModule.UserID;

                        if (item.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(item);
                        }
                    }
                    gsmG.PaymentPrice = gsmG.GivenServiceDs.Sum(x => x.PatientShare);
                    gsmG.TotalPrice = gsmG.GivenServiceDs.Sum(x => x.TotalPrice);
                    if (gsmG.PaymentPrice == 0)
                    {
                        gsmG.Payed = true;
                        gsmG.PayedPrice = 0;
                    }
                    ANGg.CreationDate = today;
                    ANGg.CreationTime = now;
                    ANGg.CreatorUserID = MainModule.UserID;
                    ANGg.GivenServiceM = gsmG;
                    if (ANGg.ID == Guid.Empty)
                    {
                        dc.Angios.InsertOnSubmit(ANGg);
                    }
                    if (gsmG.ID == Guid.Empty)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(gsmG);
                    }
                }
                if (lstGSDP.Any())
                {
                    var gsmP = new GivenServiceM()
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
                        ServiceCategoryID = (int)Category.آنژیوپلاستی,
                        Angio = ANGp,
                        InsuranceID = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceID : MainModule.GSM_Set.InsuranceID,
                        InsuranceNo = MainModule.GSM_Set.InsuranceID == null ? MainModule.GSM_Set.GivenServiceM1.InsuranceNo : MainModule.GSM_Set.InsuranceNo,
                        Date = today,
                        Time = now,
                        DepartmentID = Guid.Parse("07cd0272-b884-4d38-9ff4-feaf82274beb"),
                    };
                    foreach (var item in lstGSDP)
                    {
                        if (gsmP.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == item.ServiceID && x.InsuranceID == gsmP.InsuranceID);
                            if (trf == null)
                            {
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = 0;
                                item.TotalPrice = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                item.Payed = true;
                                item.PaymentPrice = 0;
                                item.PatientShare = 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                item.PaymentPrice = trf.PatientShare ?? 0;
                                item.PatientShare = trf.PatientShare ?? 0;
                                item.InsuranceShare = trf.OrganizationShare ?? 0;
                                item.TotalPrice = (trf.PatientShare + trf.OrganizationShare) ?? 0;
                            }
                        }
                        item.GivenServiceM = gsmP;
                        item.Amount = 1;
                        item.GivenAmount = 1;
                        item.Date = today;
                        item.Time = now;
                        item.LastModificationDate = today;
                        item.LastModificationTime = now;
                        item.LastModificator = MainModule.UserID;

                        if (item.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(item);
                        }
                    }
                    gsmP.PaymentPrice = gsmP.GivenServiceDs.Sum(x => x.PatientShare);
                    gsmP.TotalPrice = gsmP.GivenServiceDs.Sum(x => x.TotalPrice);
                    if (gsmP.PaymentPrice == 0)
                    {
                        gsmP.Payed = true;
                        gsmP.PayedPrice = 0;
                    }
                    ANGp.CreationDate = today;
                    ANGp.CreationTime = now;
                    ANGp.CreatorUserID = MainModule.UserID;
                    ANGp.GivenServiceM = gsmP;
                    if (ANGp.ID == Guid.Empty)
                    {
                        dc.Angios.InsertOnSubmit(ANGp);
                    }
                    if (gsmP.ID == Guid.Empty)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(gsmP);
                    }
                }
            }

            var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceD>().Where(x => x.GivenServiceMID == null).ToList();
            foreach (var gsd in lstToDelete)
            {
                dc.GivenServiceDs.DeleteOnSubmit(gsd);
            }

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}