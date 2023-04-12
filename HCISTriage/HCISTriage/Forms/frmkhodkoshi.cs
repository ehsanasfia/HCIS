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
    public partial class frmkhodkoshi : DevExpress.XtraEditors.XtraForm
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
        public frmkhodkoshi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if ( ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                TriageEMGkhodkoshi j = new TriageEMGkhodkoshi();
                j.IDPerson = ObjectPerson.ID;
                j.Taeedkonande = txtTaiedkonnde.Text;
                j.Takmilkonande = textEdit42.Text;
                j.EghdamBackgrand = txtsabeghkhodkosh.Text;
                j.JesmiBackgrand = txtbimarijesmani.Text;
                j.RavaniBackgrand = txtbimariravani.Text;
                j.ResultID = cmbnatijekhodkoshi.Text;
                j.Vasile = cmbvasilekhodkoshi.Text;
                j.Reason = cmbelatkhodkoshi.Text;
                j.Time = txtsaatekhodkoshi.Text;
                j.Date = txttarikhkhodkoshi.Text;
                j.GivenMID = ObjectM.ID;
                j.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                j.CreationTime = DateTime.Now.ToString("HH:mm");
                j.CreatorUserID = MainModule.UserID;
                j.UserFullname = MainModule.UserFullName;

                dc.TriageEMGkhodkoshis.InsertOnSubmit(j);
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
                DmD4.Taeedkonande = txtTaiedkonnde.Text;
                DmD4.Takmilkonande = textEdit42.Text;
                DmD4.EghdamBackgrand = txtsabeghkhodkosh.Text;
                DmD4.JesmiBackgrand = txtbimarijesmani.Text;
                DmD4.RavaniBackgrand = txtbimariravani.Text;
                DmD4.ResultID = cmbnatijekhodkoshi.Text;
                DmD4.Vasile = cmbvasilekhodkoshi.Text;
                DmD4.Reason = cmbelatkhodkoshi.Text;
                DmD4.Time = txtsaatekhodkoshi.Text;
                DmD4.Date = txttarikhkhodkoshi.Text;

                dc.SubmitChanges();

                MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }

        private void frmkhodkoshi_Load(object sender, EventArgs e)
        {
         
            txttarikhkhodkoshi.Text = MainModule.GetPersianDate(DateTime.Now);
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
            var Dm4 = dc.TriageEMGkhodkoshis.Where(c => c.GivenMID == ObjectM.ID).FirstOrDefault();

            if (Dm4 == null)
            {



                txtTaiedkonnde.Text = "";
                txtTaiedkonnde.Text = "";
                textEdit42.Text = "";
                txtsabeghkhodkosh.Text = "";
                txtbimarijesmani.Text = "";
                txtbimariravani.Text = "";
                cmbnatijekhodkoshi.Text = "";
                cmbvasilekhodkoshi.Text = "";
                cmbelatkhodkoshi.Text = "";
                txtsaatekhodkoshi.Text = "";

                txttarikhkhodkoshi.Text = MainModule.GetPersianDate(DateTime.Now);
                return;
                isedit = false;
            }

            else
            {





                txtTaiedkonnde.Text = Dm4.Taeedkonande;
                textEdit42.Text = Dm4.Takmilkonande;
                txtsabeghkhodkosh.Text = Dm4.EghdamBackgrand;
                txtbimarijesmani.Text = Dm4.JesmiBackgrand;
                txtbimariravani.Text = Dm4.RavaniBackgrand;
                cmbnatijekhodkoshi.Text = Dm4.ResultID;
                cmbvasilekhodkoshi.Text = Dm4.Vasile;
                cmbelatkhodkoshi.Text = Dm4.Reason;
                txtsaatekhodkoshi.Text = Dm4.Time;
                txttarikhkhodkoshi.Text = Dm4.Date;
                isedit = true;

                DmD4 = Dm4;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}