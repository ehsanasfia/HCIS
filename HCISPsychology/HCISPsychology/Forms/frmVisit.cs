using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPsychology.Data;
namespace HCISPsychology.Forms
{
    public partial class frmVisit : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public HCISPsychologyClassesDataContext dc = new HCISPsychologyClassesDataContext();
        ImageServerdbmlDataContext im = new ImageServerdbmlDataContext();
        SeqdbmlDataContext sq = new SeqdbmlDataContext();

        public GivenServiceM checkup { get; set; }
        public GivenServiceD GSDCheckup { get; set; }
        public frmPatientList FrmPL { get; internal set; }

        public List<Service> pataintTest = new List<Service>();
        public List<Service> pataintDrug = new List<Service>();
        public List<Service> patientRecService = new List<Service>();
        public List<Service> patientParaClinic = new List<Service>();
        public List<Service> patientPatology = new List<Service>();
        public List<Service> patientPhisio = new List<Service>();
        public List<Optometry> lstOpt = new List<Optometry>();

        string str = "";
        bool Drug, Test, Recognize, Phisio, para, rest, dispatch, patology, DiagHistory, Pcase = false;
        public bool isedit1;
        public bool isedit2;
        public bool isedit3;
        public bool isedit4;
        public bool isedit5;
        public bool isedit6;
        public bool isedit7;
        
      
        public RVPersonalInformation PI { get; set; }
        public RVCauseOfReferral CR { get; set; }
        public RVInitialInterview II { get; set; }
        public RVRecordsOfIntervention RI { get; set; }
        public RVPsychiatricIntervention PIN { get; set; }
        public RVPsychometricRecord PRR { get; set; }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (isedit1 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                //RVPersonalInformation u = new RVPersonalInformation();
                //PI.IDPerson = checkup.Person.ID;
                PI.name = txtName.Text;
                PI.relation = txtNesbat.Text;
                PI.age = txtsen.Text;
                PI.birthday = txttarikhtavalod.Text;
                PI.maritalstatus = txttaahol.Text;
                PI.conditionbirth = txtvaziyattavalod.Text;
                PI.education = txttahsilat.Text;
                PI.fathereducation = txttahsilatpedar.Text;
                PI.brothernumber = txttahsilatmadar.Text;
                PI.sisternumber = txttedadkhahar.Text;
                PI.littlechild = txtfarzandchandom.Text;
                PI.typehusing = txtnomaskan.Text;
                PI.address = txtaddress.Text;
                PI.tel = txttel.Text;
                PI.Marriageterm = txtmodattaahol.Text;
                PI.job = txtShoghl.Text;
                PI.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                PI.LastModificationTime = DateTime.Now.ToString("HH:mm");
                PI.LastModificator = MainModule.UserID;

                PI.mathereducation = txttahsilatmadar.Text;
                //  dc.RVPersonalInformations.InsertOnSubmit(p);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPersonalInformationBindingSource.DataSource = dc.RVPersonalInformations.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtName.Text = "";
                txtsen.Text = "";
                txttarikhtavalod.Text = "";
                txttaahol.Text = "";
                txtvaziyattavalod.Text = "";
                txttahsilat.Text = "";
                txttahsilatpedar.Text = "";
                txttahsilatmadar.Text = "";
                txttedadkhahar.Text = "";
                txtfarzandchandom.Text = "";
                txtnomaskan.Text = "";
                txtaddress.Text = "";
                txttel.Text = "";
                txtmodattaahol.Text = "";
                txtShoghl.Text = "";
                txttahsilatmadar.Text = "";
                txtNesbat.Text = "";
            }
            if (isedit1 == false)
            {

                RVPersonalInformation u = new RVPersonalInformation();
                u.IDPerson = checkup.Person.ID;
                u.name = txtName.Text;
                u.relation = txtNesbat.Text;
                u.age = txtsen.Text;
                u.birthday = txttarikhtavalod.Text;
                u.maritalstatus = txttaahol.Text;
                u.conditionbirth = txtvaziyattavalod.Text;
                u.education = txttahsilat.Text;
                u.fathereducation = txttahsilatpedar.Text;
                u.brothernumber = txttahsilatmadar.Text;
                u.sisternumber = txttedadkhahar.Text;
                u.littlechild = txtfarzandchandom.Text;
                u.typehusing = txtnomaskan.Text;
                u.address = txtaddress.Text;
                u.tel = txttel.Text;
                u.Marriageterm = txtmodattaahol.Text;
                u.job = txtShoghl.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;
                u.mathereducation = txttahsilatmadar.Text;
                dc.RVPersonalInformations.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPersonalInformationBindingSource.DataSource = dc.RVPersonalInformations.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtName.Text = "";
                txtsen.Text = "";
                txttarikhtavalod.Text = "";
                txttaahol.Text = "";
                txtvaziyattavalod.Text = "";
                txttahsilat.Text = "";
                txttahsilatpedar.Text = "";
                txttahsilatmadar.Text = "";
                txttedadkhahar.Text = "";
                txtfarzandchandom.Text = "";
                txtnomaskan.Text = "";
                txtaddress.Text = "";
                txttel.Text = "";
                txtmodattaahol.Text = "";
                txtShoghl.Text = "";
                txttahsilatmadar.Text = "";
                txtNesbat.Text = "";
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (isedit2 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                // RVCauseOfReferral u = new RVCauseOfReferral();
                //  CR.IDPerson = checkup.Person.ID;
                CR.doctor = txtPezeshk.Text;
                CR.Typeofpsychiatricdisorders = txtnoeekhtelalatravanpezeshki.Text;
                CR.Causereferral = txtelatmorajee.Text;
                CR.Medicalhistory = txtsabghedaroie.Text;
                CR.Historydisease = txtsabeghebimari.Text;
                CR.Kindofadvice = txtnoemorajee.Text;
                CR.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                CR.LastModificationTime = DateTime.Now.ToString("HH:mm");
                CR.LastModificator = MainModule.UserID;
                //  CR.CreatorUserFullName = MainModule.UserFullName;
                // dc.RVCauseOfReferrals.InsertOnSubmit(u);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVCauseOfReferralBindingSource.DataSource = dc.RVCauseOfReferrals.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtPezeshk.Text = "";
                txtnoeekhtelalatravanpezeshki.Text = "";
                txtelatmorajee.Text = "";
                txtsabghedaroie.Text = "";
                txtsabeghebimari.Text = "";
                txtnoemorajee.Text = "";
            }
            if (isedit2 == false)
            {
                RVCauseOfReferral u = new RVCauseOfReferral();
                u.IDPerson = checkup.Person.ID;
                u.doctor = txtPezeshk.Text;
                u.Typeofpsychiatricdisorders = txtnoeekhtelalatravanpezeshki.Text;
                u.Causereferral = txtelatmorajee.Text;
                u.Medicalhistory = txtsabghedaroie.Text;
                u.Historydisease = txtsabeghebimari.Text;
                u.Kindofadvice = txtnoemorajee.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;
                dc.RVCauseOfReferrals.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVCauseOfReferralBindingSource.DataSource = dc.RVCauseOfReferrals.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtPezeshk.Text = "";
                txtnoeekhtelalatravanpezeshki.Text = "";
                txtelatmorajee.Text = "";
                txtsabghedaroie.Text = "";
                txtsabeghebimari.Text = "";
                txtnoemorajee.Text = "";
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (isedit3 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                II.CauseOfReferral = txtelatmoraje2.Text;
                II.Personalhistory = txttarikhche2.Text;
                II.Problemstatement = txtsharhmoshkel2.Text;
                II.Familyhistory = txttarikhche2.Text;
                II.MultiaxialSensing = txtsanjesh2.Text;
                II.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                II.LastModificationTime = DateTime.Now.ToString("HH:mm");
                II.LastModificator = MainModule.UserID;
                II.CreatorUserFullName = MainModule.UserFullName;
                //  dc.RVInitialInterviews.InsertOnSubmit(u);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVInitialInterviewBindingSource.DataSource = dc.RVInitialInterviews.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtelatmoraje2.Text = "";
                txttarikhche2.Text = "";
                txtsharhmoshkel2.Text = "";
                txttarikhche2.Text = "";
                txtsanjesh2.Text = "";
            }
            if (isedit3 == false)
            {

                RVInitialInterview u = new RVInitialInterview();
                u.IDPerson = checkup.Person.ID;
                u.CauseOfReferral = txtelatmoraje2.Text;
                u.Personalhistory = txttarikhche2.Text;
                u.Problemstatement = txtsharhmoshkel2.Text;
                u.Familyhistory = txttarikhche2.Text;
                u.MultiaxialSensing = txtsanjesh2.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;
                dc.RVInitialInterviews.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVInitialInterviewBindingSource.DataSource = dc.RVInitialInterviews.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtelatmoraje2.Text = "";
                txttarikhche2.Text = "";
                txtsharhmoshkel2.Text = "";
                txttarikhche2.Text = "";
                txtsanjesh2.Text = "";
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (isedit4 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                RI.Date = txtDate3.Text;
                RI.Treatment = txtNoRavandarmani3.Text;
                RI.description = txtTozihat3.Text;
                RI.History = txtTarikhche3.Text;
                RI.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                RI.LastModificationTime = DateTime.Now.ToString("HH:mm");
                RI.LastModificator = MainModule.UserID;
                RI.CreatorUserFullName = MainModule.UserFullName;
                // dc.RVRecordsOfInterventions.InsertOnSubmit(u);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVRecordsOfInterventionBindingSource.DataSource = dc.RVRecordsOfInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtDate3.Text = "";
                txtNoRavandarmani3.Text = "";
                txtTozihat3.Text = "";
                txtTarikhche3.Text = "";
            }
            if (isedit4 == false)
            {
                RVRecordsOfIntervention u = new RVRecordsOfIntervention();
                u.IDPerson = checkup.Person.ID;
                u.Date = txtDate3.Text;
                u.Treatment = txtNoRavandarmani3.Text;
                u.description = txtTozihat3.Text;
                u.History = txtTarikhche3.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;
                dc.RVRecordsOfInterventions.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVRecordsOfInterventionBindingSource.DataSource = dc.RVRecordsOfInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtDate3.Text = "";
                txtNoRavandarmani3.Text = "";
                txtTozihat3.Text = "";
                txtTarikhche3.Text = "";
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (isedit5 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                PIN.date = txttarikh4.Text;
                PIN.description = txttozihat4.Text;
                PIN.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                PIN.LastModificationTime = DateTime.Now.ToString("HH:mm");
                PIN.LastModificator = MainModule.UserID;
                PIN.CreatorUserFullName = MainModule.UserFullName;

                //dc.RVPsychiatricInterventions.InsertOnSubmit(u);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPsychiatricInterventionBindingSource.DataSource = dc.RVPsychiatricInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txttarikh4.Text = "";
                txttozihat4.Text = "";
            }
            if (isedit5 == false)
            {
                RVPsychiatricIntervention u = new RVPsychiatricIntervention();
                u.IDPerson = checkup.Person.ID;
                u.date = txttarikh4.Text;
                u.description = txttozihat4.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;

                dc.RVPsychiatricInterventions.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPsychiatricInterventionBindingSource.DataSource = dc.RVPsychiatricInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txttarikh4.Text = "";
                txttozihat4.Text = "";
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (isedit6 == true)
            {
                if (MessageBox.Show("آیا از ویرایش اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                //  RVPsychometricRecord u = new RVPsychometricRecord();
                //PR.IDPerson = checkup.Person.ID;
                PRR.TypeOfTest = txtnoetest5.Text;
                PRR.DateOfTest = txttarikhtest5.Text;
                PRR.Result = txtnatije5.Text;

                PRR.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                PRR.LastModificationTime = DateTime.Now.ToString("HH:mm");
                PRR.LastModificator = MainModule.UserID;
                PRR.CreatorUserFullName = MainModule.UserFullName;
                //dc.RVPsychometricRecords.InsertOnSubmit(u);
                MessageBox.Show(" تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPsychometricRecordBindingSource.DataSource = dc.RVPsychometricRecords.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtnoetest5.Text = "";
                txttarikhtest5.Text = "";
                txtnatije5.Text = "";
            }
            if (isedit6 == false)
            {
                RVPsychometricRecord u = new RVPsychometricRecord();
                u.IDPerson = checkup.Person.ID;
                u.TypeOfTest = txtnoetest5.Text;
                u.DateOfTest = txttarikhtest5.Text;
                u.Result = txtnatije5.Text;

                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.CreatorUserFullName = MainModule.UserFullName;
                dc.RVPsychometricRecords.InsertOnSubmit(u);
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dc.SubmitChanges();
                rVPsychometricRecordBindingSource.DataSource = dc.RVPsychometricRecords.Where(c => c.IDPerson == checkup.Person.ID).ToList();
                txtnoetest5.Text = "";
                txttarikhtest5.Text = "";
                txtnatije5.Text = "";
            }

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtNesbat.Text = "";
            txtName.Text = "";
            txtsen.Text = "";
            txttarikhtavalod.Text = "";
            txttaahol.Text = "";
            txtvaziyattavalod.Text = "";
            txttahsilat.Text = "";
            txttahsilatpedar.Text = "";
            txttahsilatmadar.Text = "";
            txttedadkhahar.Text = "";
            txtfarzandchandom.Text = "";
            txtnomaskan.Text = "";
            txtaddress.Text = "";
            txttel.Text = "";
            txtmodattaahol.Text = "";
            txtShoghl.Text = "";
            txttahsilatmadar.Text = "";
            txtPezeshk.Text = "";
            txtnoeekhtelalatravanpezeshki.Text = "";
            txtelatmorajee.Text = "";
            txtsabghedaroie.Text = "";
            txtsabeghebimari.Text = "";
            txtnoemorajee.Text = "";
            txtelatmoraje2.Text = "";
            txttarikhche2.Text = "";
            txtsharhmoshkel2.Text = "";
            txttarikhche2.Text = "";
            txtsanjesh2.Text = "";
            txtDate3.Text = "";
            txtNoRavandarmani3.Text = "";
            txtTozihat3.Text = "";
            txtTarikhche3.Text = "";
            txttarikh4.Text = "";
            txttozihat4.Text = "";
            txtnoetest5.Text = "";
            txttarikhtest5.Text = "";
            txtnatije5.Text = "";
            isedit1 = false;
            isedit2 = false;
            isedit3 = false;
            isedit4 = false;
            isedit5 = false;
            isedit6 = false;
            isedit7 = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = rVPersonalInformationBindingSource.Current as RVPersonalInformation;
            if (current == null)
            {

                return;
            }
            isedit1 = true;
            PI = current;
            //checkup.Person.ID = current.IDPerson + "";
            txtName.Text = current.name;
            txtNesbat.Text = current.relation;
            txtsen.Text = current.age;
            txttarikhtavalod.Text = current.birthday;
            txttaahol.Text = current.maritalstatus;
            txtvaziyattavalod.Text = current.conditionbirth;
            txttahsilat.Text = current.education;
            txttahsilatpedar.Text = current.fathereducation;
            txttahsilatmadar.Text = current.brothernumber;
            txttedadkhahar.Text = current.sisternumber;
            txtfarzandchandom.Text = current.littlechild;
            txtnomaskan.Text = current.typehusing;
            txtaddress.Text = current.address;
            txttel.Text = current.tel;
            txtmodattaahol.Text = current.Marriageterm;
            txtShoghl.Text = current.job;
            txttahsilatmadar.Text = current.mathereducation;
            // MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            //  rVPersonalInformationBindingSource.DataSource = dc.RVPersonalInformations.Where(c => c.IDPerson == checkup.Person.ID).ToList();

        }

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            var current = rVCauseOfReferralBindingSource.Current as RVCauseOfReferral;
            if (current == null)
            {

                return;
            }
            isedit2 = true;
            CR = current;
            //checkup.Person.ID = current.IDPerson + "";
            txtPezeshk.Text = current.doctor;
            txtnoeekhtelalatravanpezeshki.Text = current.Typeofpsychiatricdisorders;
            txtelatmorajee.Text = current.Causereferral;
            txtsabghedaroie.Text = current.Medicalhistory;
            txtsabeghebimari.Text = current.Historydisease;
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            var current = rVInitialInterviewBindingSource.Current as RVInitialInterview;
            if (current == null)
            {

                return;
            }
            isedit3 = true;
            //checkup.Person.ID = current.IDPerson + "";
            II = current;
            txtelatmoraje2.Text = current.CauseOfReferral;
            txttarikhche2.Text = current.Personalhistory;
            txtsharhmoshkel2.Text = current.Problemstatement;
            txttarikhche2.Text = current.Familyhistory;
            txtsanjesh2.Text = current.MultiaxialSensing;
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            var current = rVRecordsOfInterventionBindingSource.Current as RVRecordsOfIntervention;
            if (current == null)
            {

                return;
            }
            isedit4 = true;
            RI = current;
            //checkup.Person.ID = current.IDPerson + "";
            txtDate3.Text = current.Date;
            txtNoRavandarmani3.Text = current.Treatment;
            txtTozihat3.Text = current.description;
            txtTarikhche3.Text = current.History;


        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            var current = rVPsychiatricInterventionBindingSource.Current as RVPsychiatricIntervention;
            if (current == null)
            {

                return;
            }
            isedit5 = true;
            PIN = current;
            //checkup.Person.ID = current.IDPerson + "";
            txttarikh4.Text = current.date;
            txttozihat4.Text = current.description;
        }

        private void txtnatije5_DoubleClick(object sender, EventArgs e)
        {
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

            var current = rVPsychometricRecordBindingSource.Current as RVPsychometricRecord;
            if (current == null)
            {

                return;
            }
            isedit6 = true;
            PRR = current;
            //checkup.Person.ID = current.IDPerson + "";
            txtnoetest5.Text = current.TypeOfTest;
            txttarikhtest5.Text = current.DateOfTest;
            txtnatije5.Text = current.Result;
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
          
            
           
            
         
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var current = rVPersonalInformationBindingSource.Current as RVPersonalInformation;

            if (current == null)
            {
                return;
            }
            //    dc.Dispose();


            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.RVPersonalInformations.DeleteOnSubmit(current);
            dc.SubmitChanges();
            GetData();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            var current1 = rVCauseOfReferralBindingSource.Current as RVCauseOfReferral;
            if (current1 == null)
            {
                return;
            }
            //    dc.Dispose();


            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            dc.RVCauseOfReferrals.DeleteOnSubmit(current1);
   

            dc.SubmitChanges();
            GetData();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            var current2 = rVInitialInterviewBindingSource.Current as RVInitialInterview;

            if (current2 == null )
            {
                return;
            }
            //    dc.Dispose();


            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

        
            dc.RVInitialInterviews.DeleteOnSubmit(current2);
        

            dc.SubmitChanges();
            GetData();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            var current3 = rVRecordsOfInterventionBindingSource.Current as RVRecordsOfIntervention;
            if (current3 == null )
            {
                return;
            }
            //    dc.Dispose();


            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;


            dc.RVRecordsOfInterventions.DeleteOnSubmit(current3);

            dc.SubmitChanges();
            GetData();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            var current4 = rVPsychiatricInterventionBindingSource.Current as RVPsychiatricIntervention;
            if (current4 == null)
            {
                return;
            }



            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            
            dc.RVPsychiatricInterventions.DeleteOnSubmit(current4);

            dc.SubmitChanges();
            GetData();

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

            var current5 = rVPsychometricRecordBindingSource.Current as RVPsychometricRecord;

            if (current5 == null)
            {
                return;
            }



            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;




            dc.RVPsychometricRecords.DeleteOnSubmit(current5);

            dc.SubmitChanges();
            GetData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DevExpress.XtraEditors.ColorWheel.ColorWheelForm f = new DevExpress.XtraEditors.ColorWheel.ColorWheelForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog(this);
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkup.Confirm == true)
            {
                Close();
            }
            else
            {
                if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    checkup.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    checkup.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    checkup.Confirm = true;
                    dc.SubmitChanges();
                    Close();
                    return;
                }
                else
                {
                    exit = true;
                    Close();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmVisit_Load(object sender, EventArgs e)
        {
            txtDate3.Text = MainModule.GetPersianDate(DateTime.Now);
            txttarikh4.Text = MainModule.GetPersianDate(DateTime.Now);
            txttarikhtest5.Text = MainModule.GetPersianDate(DateTime.Now);
            FrmPL.splashScreenManager2.CloseWaitForm();
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            lblFirstName.Caption = "نام :" + checkup.Person.FirstName;
            lblLastName.Caption = "نام خانوادگی :" + checkup.Person.LastName;
            lblNumber.Caption = " کد ملی :" + checkup.Person.NationalCode;
            lblAge.Caption = "سن: " + (BirthDay(checkup.Person.BirthDate) == null ? "" : BirthDay(checkup.Person.BirthDate) + "");
            lblPersonalCode.Caption = " کد پرسنلی :" + checkup.Person.PersonalCode;

            GSDCheckup = dc.GivenServiceDs.Where(x => x.GivenServiceMID == checkup.ID).FirstOrDefault();
            GetData();
            //EditingRV = new RVPersonalInformation();
        }

        private void GetData()
        {
            rVPersonalInformationBindingSource.DataSource = dc.RVPersonalInformations.Where(c => c.IDPerson == checkup.Person.ID).ToList();
            rVCauseOfReferralBindingSource.DataSource = dc.RVCauseOfReferrals.Where(c => c.IDPerson == checkup.Person.ID).ToList();
            rVInitialInterviewBindingSource.DataSource = dc.RVInitialInterviews.Where(c => c.IDPerson == checkup.Person.ID).ToList();
            rVRecordsOfInterventionBindingSource.DataSource = dc.RVRecordsOfInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
            rVPsychiatricInterventionBindingSource.DataSource = dc.RVPsychiatricInterventions.Where(c => c.IDPerson == checkup.Person.ID).ToList();
            rVPsychometricRecordBindingSource.DataSource = dc.RVPsychometricRecords.Where(c => c.IDPerson == checkup.Person.ID).ToList();
        }

        public bool optoVisit = false;
        public bool audio = false;
        public bool exit = false;

        public frmVisit()
        {
            InitializeComponent();
        }
        public int? BirthDay(string birthDate)
        {
            if (string.IsNullOrWhiteSpace(birthDate))
                return null;
            try
            {
                var age = MainModule.GetAge(MainModule.GetDateFromPersianString(birthDate));
                return age;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

}