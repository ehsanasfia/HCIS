using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;
namespace HCISTriage.Forms
{
    public partial class frmEM : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public Person ObjectPerson { get; set; }
        public Triage ObjectTG { get; set; }
        Insurance freeInsurance;
        bool cancelflag = false;
        public GivenServiceM ObjectM { get; set; }
        public TriageDossierEM DmD { get; set; }

        public TriageCPR DmD1 { get; set; }
        public TriageEMGincident DmD2 { get; set; }
        public TriageEMGAccident DmD3 { get; set; }
        public TriageEMGkhodkoshi DmD4 { get; set; }
        public Person PR { get; set; }
        public bool isedit { get; set; }
        public frmEM()
        {
            InitializeComponent();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (ckbLeavepersonalconsent.Checked == true)
            {

                if (txtCausetoleave.Text == "" || txtCausetoleave.Text == null)
                { MessageBox.Show("علت ترک اورژانس را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

            }
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (dc.TriageDossierEMs.Any(c => c.Person.ID == ObjectPerson.ID && c.GivenMID == ObjectM.ID)) { MessageBox.Show("برای این پرونده ی بیمار اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

                TriageDossierEM u = new TriageDossierEM();
                u.PersonID = ObjectPerson.ID;
                u.redcartDate = txtredcartDate.Text;
                u.Typeofpatient = comboBoxEdit1.Text;
                u.Lackofvitalsigns = checkBox1.Checked;
               // u.AgeUnder12 = checkBox2.Checked;
                u.AdmitType = radioGroup2.Text;
                u.Detach = radioGroup1.Text;
                u.Blood = checkBox3.Checked;
                u.OperaingRoom = checkBox4.Checked;
                u.redcarttime = txtredcarttime.Text;
                u.datebastrighati = txtdatebastrighati.Text;
                u.timebastarighati = txttimebastarighati.Text;
                u.datebastrimovaghat = txtdatebastrimovaghat.Text;
                u.timebastarimovaghat = txttimebastarimovaghat.Text;
                u.dateezam = txtdateezam.Text;
                u.timeEzam = txttimeEzam.Text;
                u.dateOutpation = txtdateOutpation.Text;
                u.Leavepersonalconsent = ckbLeavepersonalconsent.Checked;
                u.Rejecttreatment = chRejecttreatment.Checked;
                u.Causetoleave = txtCausetoleave.Text;
                u.Descrptionleave = mmdDescrptionleave.Text;
                u.timeOutpation = txttimeOutpation.Text;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.CreatorUserID = MainModule.UserID;
                u.UserFullname = MainModule.UserFullName;
                u.GivenMID = ObjectM.ID;
                dc.TriageDossierEMs.InsertOnSubmit(u);
                dc.SubmitChanges();


                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            if (isedit == true)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماان پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                DmD.redcartDate = txtredcartDate.Text;
                DmD.Typeofpatient = comboBoxEdit1.Text;
                DmD.Lackofvitalsigns = checkBox1.Checked;
                //DmD.AgeUnder12 = checkBox2.Checked;
                DmD.AdmitType = radioGroup2.Text;
                DmD.Detach = radioGroup1.Text;
                DmD.Blood = checkBox3.Checked;
                DmD.OperaingRoom = checkBox4.Checked;
                DmD.redcarttime = txtredcarttime.Text;
                DmD.datebastrighati = txtdatebastrighati.Text;
                DmD.timebastarighati = txttimebastarighati.Text;
                DmD.datebastrimovaghat = txtdatebastrimovaghat.Text;
                DmD.timebastarimovaghat = txttimebastarimovaghat.Text;
                DmD.dateezam = txtdateezam.Text;
                DmD.timeEzam = txttimeEzam.Text;
                DmD.dateOutpation = txtdateOutpation.Text;
                DmD.Leavepersonalconsent = ckbLeavepersonalconsent.Checked;
                DmD.Rejecttreatment = chRejecttreatment.Checked;
                DmD.Causetoleave = txtCausetoleave.Text;
                DmD.Descrptionleave = mmdDescrptionleave.Text;
                DmD.timeOutpation = txttimeOutpation.Text;
                DmD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                DmD.LastModificationTime = DateTime.Now.ToString("HH:mm");
                DmD.LastModificator = MainModule.UserID;
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }

        private void frmEM_Load(object sender, EventArgs e)
        {
            checkEdit1.EditValue = true;
            txtDateCprE.Text = MainModule.GetPersianDate(DateTime.Now);
            txtredcartDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtdatebastrimovaghat.Text = MainModule.GetPersianDate(DateTime.Now);
            txtdatebastrighati.Text = MainModule.GetPersianDate(DateTime.Now);
     
            txtCausetoleave.Enabled = false;
            mmdDescrptionleave.Enabled = false;
            if (ckbLeavepersonalconsent.Checked == true)
            {

                txtCausetoleave.Enabled = true;
                mmdDescrptionleave.Enabled = true;
            }
            else
            {

                txtCausetoleave.Enabled = false;
                mmdDescrptionleave.Enabled = false;
            }
            triageEmergencyCPRBindingSource.DataSource = dc.TriageEmergencyCPRs.Where(c => c.IDPerson == ObjectPerson.ID).ToList();
            triageCPRTypeBindingSource.DataSource = dc.TriageCPRTypes.ToList();
            if (ObjectM == null)
            {
                MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
    
            var Dm = dc.TriageDossierEMs.Where(c => c.GivenMID == ObjectM.ID).FirstOrDefault();
            if (Dm == null )
            {
                txtredcartDate.Text = MainModule.GetPersianDate(DateTime.Now);
                //txtredcartDate.Text = "";
                comboBoxEdit1.Text = "";
                checkBox1.Checked = false;
                //checkBox2.Checked = false;
                radioGroup2.Text = "";
                radioGroup1.Text = "";
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                txtredcarttime.Text = "";
                txtdatebastrighati.Text = "";
                txttimebastarighati.Text = "";
                txtdatebastrimovaghat.Text = "";
                txttimebastarimovaghat.Text = "";
                txtdateezam.Text = "";
                txttimeEzam.Text = "";
                txtdateOutpation.Text = "";
                txttimeOutpation.Text = "";
                ckbLeavepersonalconsent.Checked = false;
                chRejecttreatment.Checked = false;
                txtCausetoleave.Text = "";
                mmdDescrptionleave.Text = "";
                return;
                isedit = false;
            }

            else
            {
                txtredcartDate.Text = Dm.redcartDate;
                comboBoxEdit1.Text = Dm.Typeofpatient;
                checkBox1.Checked = Dm.Lackofvitalsigns;
                //checkBox2.Checked = Dm.AgeUnder12;
                radioGroup2.EditValue = Dm.AdmitType;
                radioGroup1.EditValue = Dm.Detach;
                checkBox3.Checked = Dm.Blood;
                checkBox4.Checked = Dm.OperaingRoom;
                txtredcarttime.Text = Dm.redcarttime;
                txtdatebastrighati.Text = Dm.datebastrighati;
                txttimebastarighati.Text = Dm.timebastarighati;
                txtdatebastrimovaghat.Text = Dm.datebastrimovaghat;
                txttimebastarimovaghat.Text = Dm.timebastarimovaghat;
                txtdateezam.Text = Dm.dateezam;
                txttimeEzam.Text = Dm.timeEzam;
                txtdateOutpation.Text = Dm.dateOutpation;
                ckbLeavepersonalconsent.Checked = Dm.Leavepersonalconsent;
                chRejecttreatment.Checked = Dm.Rejecttreatment;
                txtCausetoleave.Text = Dm.Causetoleave;
                mmdDescrptionleave.Text = Dm.Descrptionleave;
                txttimeOutpation.Text = Dm.timeOutpation;
                isedit = true;
                DmD = Dm;
             
            }

       
         

        }

        private void ckbLeavepersonalconsent_EditValueChanged(object sender, EventArgs e)
        {

            if (ckbLeavepersonalconsent.Checked == true)
            {

                txtCausetoleave.Enabled = true;
                mmdDescrptionleave.Enabled = true;
            }
            else
            {

                txtCausetoleave.Enabled = false;
                mmdDescrptionleave.Enabled = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ObjectM == null)
            {
                MessageBox.Show("از لیست بیماان پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if ( ObjectPerson.NationalCode == null)
            {
                MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            TriageEmergencyCPR u = new TriageEmergencyCPR();
            u.IDPerson = ObjectPerson.ID;
            u.TriageCPRType = (lkpCPRType.EditValue as TriageCPRType);
            u.Succeeded = checkEdit1.Checked;
            u.time = txtTimeCprE.Text;
            u.Date = txtDateCprE.Text;
            u.Typeofdisease = txtTypeofdisease.Text;
            u.GivenMID = ObjectM.ID;
            u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            u.CreationTime = DateTime.Now.ToString("HH:mm");
            u.CreatorUserID = MainModule.UserID;
            u.UserFullname = MainModule.UserFullName;
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            dc.TriageEmergencyCPRs.InsertOnSubmit(u);
            dc.SubmitChanges();
            triageEmergencyCPRBindingSource.DataSource = dc.TriageEmergencyCPRs.Where(c => c.IDPerson == ObjectPerson.ID).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var cur = triageEmergencyCPRBindingSource.Current as TriageEmergencyCPR;
            if (cur == null)
            {
                return;
            }
            dc.TriageEmergencyCPRs.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            triageEmergencyCPRBindingSource.DataSource = dc.TriageEmergencyCPRs.ToList();
        }
    }
}