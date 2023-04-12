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
    public partial class frmTasadof : DevExpress.XtraEditors.XtraForm
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
        public frmTasadof()
        {
            InitializeComponent();
        }

        private void frmTasadof_Load(object sender, EventArgs e)
        {
            txttarikhvogho.Text = MainModule.GetPersianDate(DateTime.Now);

            var Dm3 = dc.TriageEMGAccidents.Where(c => c.GivenMID == ObjectM.ID).FirstOrDefault();


            if (Dm3 == null )
            {
                txttaiedkonande.Text = "";
                txttakmilkonnade.Text = "";
                cmbmahaltasadof.Text = "";
                cmbshedatasibdidegi.Text = "";
                cmbnovasile.Text = "";
                cmbsarneshin.Text = "";
                cmbaber.Text = "";
                cmbrannande.Text = "";
                txttarikhvogho.Text = MainModule.GetPersianDate(DateTime.Now);
                return;
                isedit = false;
            }

            else
            {
                txttaiedkonande.Text = Dm3.Accapply;
                txttakmilkonnade.Text = Dm3.ACCsign;
                cmbmahaltasadof.Text = Dm3.ACCplace;
                cmbshedatasibdidegi.Text = Dm3.ACCInjury;
                cmbnovasile.Text = Dm3.ACCcar;
                cmbsarneshin.Text = Dm3.ACCSarneshin;
                cmbaber.Text = Dm3.ACCAber;
                cmbrannande.Text = Dm3.ACCDriver;
                txttarikhvogho.Text = Dm3.ACCDate;

                isedit = true;

                DmD3 = Dm3;
             
            }

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
                TriageEMGAccident k = new TriageEMGAccident();
                k.IDPerson = ObjectPerson.ID;
            
                k.Accapply = txttaiedkonande.Text;
                k.ACCsign = txttakmilkonnade.Text;
                k.ACCplace = cmbmahaltasadof.Text;
                k.ACCInjury = cmbshedatasibdidegi.Text;
                k.ACCcar = cmbnovasile.Text;
                k.ACCSarneshin = cmbsarneshin.Text;
                k.ACCAber = cmbaber.Text;
                k.ACCDriver = cmbrannande.Text;
                k.ACCDate = txttarikhvogho.Text;
                k.GivenMID = ObjectM.ID;
                k.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                k.CreationTime = DateTime.Now.ToString("HH:mm");
                k.CreatorUserID = MainModule.UserID;
                k.UserFullname = MainModule.UserFullName;

                dc.TriageEMGAccidents.InsertOnSubmit(k);
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
                if ( ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                DmD3.Accapply = txttaiedkonande.Text;
                DmD3.ACCsign = txttakmilkonnade.Text;
                DmD3.ACCplace = cmbmahaltasadof.Text;
                DmD3.ACCInjury = cmbshedatasibdidegi.Text;
                DmD3.ACCcar = cmbnovasile.Text;
                DmD3.ACCSarneshin = cmbsarneshin.Text;
                DmD3.ACCAber = cmbaber.Text;
                DmD3.ACCDriver = cmbrannande.Text;
                DmD3.ACCDate = txttarikhvogho.Text;
                dc.SubmitChanges();

       
                MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}