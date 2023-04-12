using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.IMData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class frmSurveillance : BaseForm
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        public Person CurrentPerson { get; set; }

        IMClassesDataContext dc = new IMClassesDataContext();

        public frmSurveillance(Document doc,ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();
            this.CurrentDocument = dc.Documents.SingleOrDefault(c => c.ID == doc.ID);
            CurrentPerson = CurrentDocument.Person;
            this.FormType = FormViewType;

        }

        public enum ViewType
        {
            New,
            View,
            Edit
        }

        internal bool SaveChanges(bool ShowMessage)
        {
            bool result = false;
            try
            {
                surveillanceBindingSource.EndEdit();
                Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                    {
                        var surv = surveillanceBindingSource.Current as Surveillance;
                        surv.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        surv.ModificationUser = MainModule.UserID;
                    } 
                    dc.SubmitChanges();
                    if (ShowMessage)
                        MessageBox.Show("اطلاعات وارد شده با موفقیت ذخیره گردید", "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                result = true;
                surveillanceBindingSource1.DataSource = dc.Surveillances.Where(c => c.Person == CurrentPerson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            return result;
        }

        private void frmSurveillance_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            //if (FormType != ViewType.View)
            //    FormType = CurrentPerson.Surveillances.Any() ? ViewType.Edit : ViewType.New;


            surveillanceIllnessBindingSource.DataSource = dc.SurveillanceIllnesses;
            surviellanceIllnessLevelBindingSource.DataSource = dc.SurviellanceIllnessLevels;
            surveillanceBindingSource.DataSource = dc.Surveillances.Where(c => c.Person == CurrentPerson && (c.Deleted == null || c.Deleted == false)).OrderByDescending(c => c.FirstDiagnoseDate).ToList();
            surveillanceBindingSource_CurrentChanged(null, null);
            switch (FormType)
            {
                case ViewType.New:
                    /*
                    var diag = new DialogSearch() { FormType = DialogSearch.DialogType.JustFindPerson };
                    if (CurrentDocument != null)
                    {
                        diag.SelectedPerson = CurrentDocument.Person;
                    }
                    
                    if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        switch (diag.SelectedRecieptionType)
                        {
                            case frmReception.ReceptionType.NewReceptionFromJamiat:

                                CurrentPerson = new Person()
                                {
                                    GUID = diag.SelectedPerson.GUID,
                                    FirstName = diag.SelectedPerson.FirstName,
                                    LastName = diag.SelectedPerson.LastName,
                                    Address = diag.SelectedPerson.Address,
                                    PostalCode = diag.SelectedPerson.PostalCode,
                                    Sex = diag.SelectedPerson.Sex,
                                    PhoneNumber = diag.SelectedPerson.PhoneNumber,
                                    PersonalNo = diag.SelectedPerson.PersonalNo,
                                    NationalCode = diag.SelectedPerson.NationalCode,
                                    BirthDate = diag.SelectedPerson.BirthDate,
                                    BirthCertificateNo = diag.SelectedPerson.BirthCertificateNo,
                                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                    CreationUser = MainModule.UserID,
                                    FatherName = diag.SelectedPerson.FatherName,
                                    CompanyID = diag.SelectedPerson.CompanyID,
                                    ValidCenterID = diag.SelectedPerson.ValidCenterID,
                                    Deleted = false
                                };

                                dc.Persons.InsertOnSubmit(CurrentPerson);
                                break;
                            case frmReception.ReceptionType.NewReception:
                                CurrentPerson = dc.Persons.Single(c => c == diag.SelectedPerson);
                                break;
                            default:
                                break;

                        }

                    }
                     */
                    if (CurrentPerson == null) 
                    {
                        dc = new IMClassesDataContext();
                        return;
                    }

                    //CurrentPerson.Surveillances.Add(surveillance);
                    //surveillanceBindingSource.DataSource = surveillance;
                    break;
                default:
                    break;
            }
            //((frmMain)MdiParent).ShowPhoto(CurrentPerson.GUID);
            gridView1.BestFitColumns();
        }

        private void frmSurveillance_Shown(object sender, EventArgs e)
        {
            if(CurrentPerson == null) Close();
            surveillanceBindingSource.Position = surveillanceBindingSource.IndexOf(Surveillance);
        }

        public Surveillance Surveillance { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //var today = MainModule.GetPersianDate(DateTime.Now);
            //var surveillance = new Surveillance()
            //{
            //    Deleted = false,
            //    CreationUser = MainModule.UserID,
            //    CreationDate = today,
            //    FirstDiagnoseDate = today,
            //    SurviellanceIllnessLevel = dc.SurviellanceIllnessLevels.First(),
            //    DoctorID = MainModule.UserID,
            //    PersonID = CurrentPerson.ID,
            //    NextReferDate = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddYears(1)),
            //    Active = true,
            //    FromJob = false
            //};

            //dc.Surveillances.InsertOnSubmit(surveillance);
            //surveillanceBindingSource.Add(surveillance);
            //surveillanceBindingSource.Position = surveillanceBindingSource.IndexOf(surveillance);
            //MainModule.MakeReadOnly(layoutControlGroup5, false);
        }

        private void surveillanceIllnessBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //MainModule.MakeReadOnly(layoutControlGroup5, surviellanceIllnessLevelBindingSource.Current == null ? true : false);
        }

        private void surveillanceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var surv = surviellanceIllnessLevelBindingSource.Current as Surveillance;
            var inserted = dc.GetChangeSet().Inserts.OfType<Surveillance>().Any(c => c == surv);

            //MainModule.MakeReadOnly(layoutControlGroup5, !inserted);
        }
    }
}