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
using HCISDentist.Data;
using System.IO;
using HCISDentist.Classes;

namespace HCISDentist.Forms
{
    public partial class frmDentits : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HCISDentisClassesDataContext dc = new HCISDentisClassesDataContext();
        SecuritydbmlDataContext sq = new SecuritydbmlDataContext();
        imageDataContext im = new imageDataContext();

        public GivenServiceD checkup { get; set; }
        private GivenServiceM editingGsm;
        private bool isShowing = false;
        private bool gsmInserted = false;
        public List<Service> pataintDrug = new List<Service>();
        public List<GivenServiceD> lstGSD = new List<GivenServiceD>();
        string str = "";


        public frmDentits()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkup.GivenServiceM.Confirm == true)
            {
                Close();
            }
            else
            {
                if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    checkup.GivenServiceM.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.GivenServiceM.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    checkup.GivenServiceM.Confirm = true;
                    checkup.GivenServiceM.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.GivenServiceM.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    dc.SubmitChanges();
                    Close();
                    return;
                }
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            try
            {
                lstGSD = editingGsm.GivenServiceDs.ToList();
                givenServiceDBindingSource.DataSource = lstGSD;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmDentits_Load(object sender, EventArgs e)
        {
            lblFname.Caption = "نام: " + checkup.GivenServiceM.Person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + checkup.GivenServiceM.Person.LastName;
            lblNationalCode.Caption = "کد ملی : " + checkup.GivenServiceM.Person.NationalCode;
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID);
            lookUpEdit1.EditValue = MainModule.MyDepartment;

            if (checkup.GivenServiceM.Person.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = checkup.GivenServiceM.Person.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    picPatient.EditValue = Image.FromStream(ms);
                }
            }
            else
            {
                picPatient.EditValue = null;
            }
            editingGsm = dc.GivenServiceMs.FirstOrDefault(x => x.ParentID == checkup.GivenServiceMID && x.ServiceCategoryID == (int)Category.دندانپزشکی);
            if (editingGsm == null)
            {
                editingGsm = new GivenServiceM()
                {
                    ServiceCategoryID = (int)Category.دندانپزشکی,
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ParentID = checkup.GivenServiceMID,
                    DepartmentID = MainModule.InstallLocation.ID,
                    DossierID = checkup.GivenServiceM.DossierID,
                    InsuranceID = checkup.GivenServiceM.InsuranceID,
                    FunctorID = checkup.GivenServiceM.RequestStaffID,
                    Person = checkup.GivenServiceM.Person,
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Confirm = true,
                };
            }
            else
                gsmInserted = true;

            serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.پاراکلینیکی && x.SpecialityID == 31 && x.Hide == false);
            //serviceBindingSource1.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.دندانپزشکی);
            DrugbindingSource.DataSource = dc.PharmacyDrugs.Where(x => x.PharmacyID == MainModule.MyDepartment.ID).Select(x => x.Service).OrderBy(x => x.Name).ToList();
            pcaseViewBindingSource.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.دارو && x.NationalCode == checkup.GivenServiceM.Person.NationalCode).ToList();
            var srv = Guid.Parse("f990684e-dee3-4a6d-a44d-ca9bc28bb4ca");
            GSMBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == checkup.GivenServiceM.PersonID && x.GivenServiceM.ServiceCategoryID == 5 && x.ServiceID == srv);
            GetData();

            foreach (var record in (IEnumerable<GivenServiceD>)givenServiceDBindingSource.DataSource)
            {
                string teeth = record.Comment;
                if (teeth.Contains("-"))
                    teeth = record.Comment.Split('-')[0].Trim();
                foreach (var item in layoutControl1.Controls.OfType<CheckButton>().ToList())
                {
                    if (item.Tag.ToString() == teeth)
                    {
                        item.Checked = true;
                        break;
                    }
                }
            }
            isShowing = true;
            btnAddService.Enabled = false;
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabbedControlGroup2.SelectedTabPageIndex == 0)
            {
                if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                else
                {

                    if (!gsmInserted && editingGsm.ID == Guid.Empty)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(editingGsm);
                    }

                    foreach (var gsd in lstGSD)
                    {
                        if (gsd.ID == Guid.Empty)
                        {
                            dc.GivenServiceDs.InsertOnSubmit(gsd);
                        }
                    }
                    dc.SubmitChanges();

                }
            }
            else if (tabbedControlGroup2.SelectedTabPageIndex == 1)
            {
                if (lookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("!ابتدا داروخانه را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var gsm = new GivenServiceM()
                {
                    GivenServiceM1 = checkup.GivenServiceM,
                    Priority = false,
                    PersonID = checkup.GivenServiceM.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = checkup.GivenServiceM.InsuranceID,
                    Staff = checkup.GivenServiceM.Staff,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    DossierID = checkup.GivenServiceM.DossierID,
                    CreatorUserID = MainModule.UserID,
                    DepartmentID = (lookUpEdit1.EditValue as Department).ID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.دارو,
                };
                pataintDrug.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        NIS = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == x.ID && c.PharmacyID == (lookUpEdit1.EditValue as Department).ID).NIS,
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        HIXCode = x.HIX.ID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Amount,
                        GivenAmount = x.Amount
                    };
                    var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.GivenServiceM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs.Where(x => x.ID == Guid.Empty));
                dc.SubmitChanges();
                MessageBox.Show("داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                PatinetDrugBindingSource.DataSource = null;
                pataintDrug.Clear();
                btnOK.Enabled = false;
                pcaseViewBindingSource.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.دارو && x.NationalCode == checkup.GivenServiceM.Person.NationalCode).ToList();
            }
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (isShowing)
            {
                var chk = sender as CheckButton;
                if (chk == null)
                    return;
                bool check = chk.Checked;
                foreach (var item in layoutControl1.Controls.OfType<CheckButton>().ToList())
                {
                    item.Checked = false;
                }

                chk.Checked = check;
                btnAddService.Enabled = true;
                isShowing = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
                {
                    MessageBox.Show("ابتدا یک دندان را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (slkpService.EditValue == null)
                {
                    MessageBox.Show("ابتدا یک خدمت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var gsd = new GivenServiceD()
                {
                    Comment =" دندان شیری "  + comboBoxEdit1.Text.ToString() + " - " + memComment.Text,
                    GivenServiceM = editingGsm,
                    Amount = 1,
                    GivenAmount = 1,
                    FunctorID = checkup.GivenServiceM.RequestStaffID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Service = slkpService.EditValue as Service,
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };
                lstGSD.Add(gsd);
                grdHistori.RefreshDataSource();

            }
            else
            {

                if (isShowing)
                    return;
                if (slkpService.EditValue == null)
                {
                    MessageBox.Show("ابتدا یک خدمت را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                foreach (var item in layoutControl1.Controls.OfType<CheckButton>().ToList())
                {
                    if (!item.Checked)
                        continue;
                    var gsd = new GivenServiceD()
                    {
                        Comment = item.Tag.ToString() + " - " + memComment.Text,
                        GivenServiceM = editingGsm,
                        Amount = 1,
                        GivenAmount = 1,
                        FunctorID = checkup.GivenServiceM.RequestStaffID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        Service = slkpService.EditValue as Service,
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    lstGSD.Add(gsd);
                    grdHistori.RefreshDataSource();
                    //dc.GivenServiceDs.InsertOnSubmit(gsd);
                }
            }

            //GetData();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
                return;
            string teeth = current.Comment;
            if (teeth.Contains("-"))
                teeth = current.Comment.Split('-')[0].Trim();
            foreach (var item in layoutControl1.Controls.OfType<CheckButton>().ToList())
            {
                if (item.Tag.ToString() == teeth)
                    item.Checked = true;
                else
                    item.Checked = false;
            }
            isShowing = true;
            btnAddService.Enabled = false;
        }

        private void frmDentits_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkup.GivenServiceM.Confirm == true)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    checkup.GivenServiceM.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.GivenServiceM.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    checkup.GivenServiceM.Confirm = true;
                    dc.SubmitChanges();
                    return;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var MyData = from c in dc.DentistCases
                         where c.NationalCode == checkup.GivenServiceM.Person.NationalCode
                         select new
                         {
                             c.NationalCode,
                             Date = c.AgendaDate ?? c.CreationDate,
                             c.ServiceName,
                             prise = c.PatientShare,
                             c.PayedPrice,
                             baqimande = c.PatientShare - c.PayedPrice,
                             fullname = c.FirstName + " " + c.LastName,
                             c.Comment,
                             c.BirthDate,
                             c.Phone,
                             c.gsdComment
                         };
            PrintAll.RegData("MyData", MyData);
            PrintAll.Compile();
            PrintAll.Render();
            PrintAll.Show();
        }

        private void tabbedControlGroup2_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            var index = tabbedControlGroup2.SelectedTabPageIndex;
            if (index == 0)
            {
                btnOK.Caption = "ثبت تغییرات";
                btnOK.Enabled = true;
            }

            else if (index == 1)
            {
                btnOK.Caption = "ثبت دارو ها";
                btnOK.Enabled = false;
            }
            else if (index == 2)
            {
                //if (!Test)
                //{
                //  TestsBindingSource.DataSource = MainModule.Tests.ToList();
                spuFullLabHistoryMResultBindingSource.DataSource = dc.Spu_FullLabHistoryM(checkup.GivenServiceM.Person.NationalCode).ToList();
                //   }
                // Test = true;
            }
            if (index == 1 && pataintDrug.Any())
                btnOK.Enabled = true;
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            var current = DrugbindingSource.Current as Service;
            if (current == null)
                return;
            var a = new Dialogs.dlgDrugPlan();
            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;
            if (!pataintDrug.Contains(current))
            {
                pataintDrug.Add(current);
                btnOK.Enabled = true;
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var drug = gridView5.GetFocusedRow() as Service;
            if (drug == null)
                return;
            str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
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
            PatinetDrugBindingSource.DataSource = pataintDrug;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            gridControl4.RefreshDataSource();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                colDate1.Group();
                gridColumn7.Group();
                gridView4.ExpandAllGroups();
            }
            else
            {
                colDate1.UnGroup();
                gridColumn7.UnGroup();
            }
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == false)
            {
                var current = pcaseViewBindingSource.Current as PcaseView;

                if (current == null)
                    return;
                var serv = dc.Services.FirstOrDefault(x => x.ID == current.ServiceID);
                if (serv == null)
                    return;
                if (!pataintDrug.Contains(serv))
                {
                    serv.Comment = current.Comment;
                    serv.Amount = (int)current.Amount;
                    serv.HIXCode = current.FName;
                    pataintDrug.Add(serv);
                    btnOK.Enabled = true;
                    PatinetDrugBindingSource.DataSource = pataintDrug;
                    gridControl4.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            else
                return;
        }

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            gridView6.DeleteSelectedRows();
            btnOK.Enabled = pataintDrug.Any();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3090).UserID;
                DrugbindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.دارو && x.UserID == user).Select(x => x.Service).OrderBy(x => x.Name).ToList();
            }
            else if (radioGroup1.SelectedIndex == 0)
            {
                DrugbindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).OrderBy(x => x.Name).ToList();
            }
        }

        private void btnOKPic_Click(object sender, EventArgs e)
        {

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
                grdHistori.RefreshDataSource();

            }
            else if (cur.Date == MainModule.GetPersianDate(DateTime.Now))
            {
                dc.GivenServiceDs.DeleteOnSubmit(cur);
                dc.SubmitChanges();
                GetData();
            }
            else
            {
                MessageBox.Show("!این خدمت جزو سوابق میباشد نمیتوانید آنرا حذف کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var srv = Guid.Parse("f990684e-dee3-4a6d-a44d-ca9bc28bb4ca");
                var hos = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
                var gsm = new GivenServiceM()
                {
                    GivenServiceM1 = checkup.GivenServiceM,
                    Priority = false,
                    PersonID = checkup.GivenServiceM.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = checkup.GivenServiceM.InsuranceID,
                    DepartmentID = hos,
                    RequestStaffID = checkup.GivenServiceM.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    DossierID = checkup.GivenServiceM.DossierID,
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.خدمات_تشخیصی,
                };
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    ServiceID = srv,
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };
                var tarefee = dc.Tariffs.Where(z => z.ServiceID == srv && z.InsuranceID == checkup.GivenServiceM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.SubmitChanges();
                MessageBox.Show("رادیوگرافی با موفقیت ثبت گردید");
                GSMBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == checkup.GivenServiceM.PersonID && x.GivenServiceM.ServiceCategoryID == 5 && x.ServiceID == srv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curent = GSMBindingSource.Current as GivenServiceD;
            if (curent == null)
                return;
            if (curent.GivenServiceM.ServiceCategoryID != 5)
            {
                simpleButton1.Enabled = false;
                return;
            }
            // if (im.Studies.Any(x => x.PatientId != null && x.PatientId.Contains(curent.GivenServiceM.SerialNumber.ToString())))
            if(MainModule.GetServerMarkoPacs(curent.GivenServiceM.SerialNumber.ToString())== "OK")
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var curent = GSMBindingSource.Current as GivenServiceD;
            if (curent == null)
                return;

            var result = "http://172.30.1.80/metric/hisintegration.aspx?ID=";
            result += curent.GivenServiceM.SerialNumber.ToString();
            System.Diagnostics.Process.Start(result);
            //var image = im.Studies.Where(x => x.PatientId != null && x.PatientId.Contains(curent.GivenServiceM.SerialNumber.ToString())).ToList();
            //if (image.Count == 1)
            //{
            //    var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
            //    result += image.FirstOrDefault().StudyInstanceUid;
            //    System.Diagnostics.Process.Start(result);
            //}
            //else
            //{
            //    var dlg = new Dialogs.dlgImages();
            //    dlg.serial = curent.GivenServiceM.SerialNumber.ToString();
            //    dlg.lstStudy = image;
            //    dlg.ShowDialog();
            //}
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (pataintDrug.Any())
            {
                if (MessageBox.Show("با تعویض داروخانه لیست دارو های وارد شده خالی میشود آیا مایل به عوض کردن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                PatinetDrugBindingSource.DataSource = null;
                pataintDrug.Clear();
                btnOK.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryMResultBindingSource.Current as Spu_FullLabHistoryMResult;
            if (current == null)
                return;
            else if (current.gsmID == null)
            {
                MessageBox.Show("این آزمایش قابل چاپ شدن نیست");
                return;
            }
            var cur = dc.GivenServiceMs.FirstOrDefault(x => x.ID == current.gsmID);
            var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();
            var lstGsd = new List<GivenServiceD>();
            GivenServiceM labGSM = null;

            if (TestGSMs.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }
            else if (TestGSMs.Count == 1)
            {
                lstGsd.AddRange(TestGSMs.FirstOrDefault().GivenServiceDs);
                labGSM = TestGSMs.FirstOrDefault();
            }
            //else
            //{
            //    var dlg = new Dialogs.dlgAllPateintTest() { dc = dc, TestGSM = TestGSMs };
            //    if (dlg.ShowDialog() == DialogResult.OK)
            //    {
            //        lstGsd.AddRange(dlg.SelectedGMS.GivenServiceDs);
            //        labGSM = dlg.SelectedGMS;
            //    }
            //    else
            //        return;
            //}

            Stimulsoft.Report.StiReport sti = stiAnswer;

            var answer =
                from c in lstGsd
                select new
                {
                    TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
                    Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
                    Normal = (c.GivenLaboratoryServiceD == null) ? "" : c.GivenLaboratoryServiceD.NormalRange,
                    GroupName = c.Service.LabTestGroups.Any() ? c.Service.LabTestGroups.FirstOrDefault().LabSubGroup.LabGroup.EName : "Uncategorized",
                    Unit = c.Service.LaboratoryServiceDetail == null ? "" : c.Service.LaboratoryServiceDetail.MeasurementUnit,
                    OldID = c.Service.OldID
                };

            sti.Dictionary.Variables.Add("AdmitDate", "");
            sti.Dictionary.Variables.Add("Doctor", "");
            sti.Dictionary.Variables.Add("Person", "");
            sti.Dictionary.Variables.Add("SerialNumber", "");
            sti.Dictionary.Variables.Add("AnsweringDate", "");
            sti.Dictionary.Variables.Add("DailySN", "");
            sti.Dictionary.Variables.Add("MedicalID", "");
            sti.Dictionary.Variables.Add("NationalCode", "");
            sti.Dictionary.Variables.Add("UserName", "");
            sti.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            sti.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));

            sti.Dictionary.Variables.Add("Person", labGSM.Person.FirstName + " " + labGSM.Person.LastName);
            if (labGSM.Staff != null)
            {
                sti.Dictionary.Variables.Add("Doctor", labGSM.Staff.Person.FirstName + " " + labGSM.Staff.Person.LastName);
            }
            sti.Dictionary.Variables.Add("AdmitDate", labGSM.AdmitDate ?? "");
            sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");
            sti.RegData("Answer", answer);
            sti.Dictionary.Synchronize();
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();
        }

        private void spuFullLabHistoryMResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryMResultBindingSource.Current as Spu_FullLabHistoryMResult;
            if (current == null)
                return;
            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(checkup.GivenServiceM.Person.NationalCode).Where(x => (x.gsmID != null) ? (x.gsmID == current.gsmID) : (x.gsmHospital == current.gsmHospital));
            gridView3.ExpandAllGroups();
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgDentistHistory();
            dlg.dc = dc;
            dlg.prs = checkup.GivenServiceM.Person;
            dlg.ShowDialog();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
                comboBoxEdit1.Enabled = true;
            else
                comboBoxEdit1.Enabled = false;

        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var srv = Guid.Parse("60c3a6d0-1b40-482b-bdd9-47d117a73615");
                var hos = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
                var gsm = new GivenServiceM()
                {
                    GivenServiceM1 = checkup.GivenServiceM,
                    Priority = false,
                    PersonID = checkup.GivenServiceM.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = checkup.GivenServiceM.InsuranceID,
                    DepartmentID = hos,
                    RequestStaffID = checkup.GivenServiceM.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    DossierID = checkup.GivenServiceM.DossierID,
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.خدمات_تشخیصی,
                };
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    ServiceID = srv,
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };
                var tarefee = dc.Tariffs.Where(z => z.ServiceID == srv && z.InsuranceID == checkup.GivenServiceM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.SubmitChanges();
                MessageBox.Show("رادیوگرافی با موفقیت ثبت گردید");
                GSMBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == checkup.GivenServiceM.PersonID && x.GivenServiceM.ServiceCategoryID == 5 && x.ServiceID == srv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}