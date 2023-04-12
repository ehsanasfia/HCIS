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
    public partial class frmCPRO : DevExpress.XtraEditors.XtraForm
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
        public frmCPRO()
        {
            InitializeComponent();
        }

        private void frmCPRO_Load(object sender, EventArgs e)
        {
            txtTarikhiestghalbi.Text = MainModule.GetPersianDate(DateTime.Now);
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
            }
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
            staffBindingSource1.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
            staffBindingSource3.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
            var Dm1 = dc.TriageCPRs.Where(c => c.GivenMID == ObjectM.ID).FirstOrDefault();


            if (Dm1 == null)
            {
                lkpPezeshkhazzer.EditValue = "";
                lkppezeshbihoshi.EditValue = "";

                lkpDakheli1.EditValue = "";

                txtsayerpezshkan.Text = "";
                txtZamanElamCod.Text = "";
                txtSaateIstghalbi.Text = "";
                //txtTarikhiestghalbi.Text = "";
                txtZamanhoZorCpr.Text = "";
                txtElatiestghalbi.Text = "";
                txtvaziyatbalini.Text = "";
                txtsaateetmamCpr.Text = "";
                ckbCprNamovafagh.Checked = false;
                txtnatijenahaie.Text = "";
                txtTarikhiestghalbi.Text = MainModule.GetPersianDate(DateTime.Now);
                return;
                isedit = false;
            }

            else
            {
                lkpPezeshkhazzer.EditValue = Dm1.Staff3;
                //var Staffs111 = dc.Staffs.Where(c => c.UserType == "دکتر" && c.ID == Dm1.IDStaffAnesthesia).FirstOrDefault();
                //staffBindingSource1.DataSource = Staffs111;
                lkppezeshbihoshi.EditValue = Dm1.Staff1;
                //var Staffs112 = dc.Staffs.Where(c => c.UserType == "دکتر" && c.ID == Dm1.IDStaffInternal).FirstOrDefault();
                //staffBindingSource2.DataSource = Staffs112.ID;
                lkpDakheli1.EditValue = Dm1.Staff4;
                //// var Staffs112 = dc.Staffs.Where(c => c.UserType == "دکتر" && c.ID == Dm1.IDStaffInternal).ToList();
                //// DossierEM = Dm;




                txtsayerpezshkan.Text = Dm1.OtherStaff;
                txtZamanElamCod.Text = Dm1.timeCode;
                txtSaateIstghalbi.Text = Dm1.timeStopHeart;
                txtTarikhiestghalbi.Text = Dm1.DateStopHeart;
                txtZamanhoZorCpr.Text = Dm1.timePresenceCPR;
                txtElatiestghalbi.Text = Dm1.CauseStopHeart;
                txtvaziyatbalini.Text = Dm1.ConditionDescription;
                txtsaateetmamCpr.Text = Dm1.timeEnd;
                ckbCprNamovafagh.EditValue = Dm1.CprUnsuccessful;
                txtnatijenahaie.Text = Dm1.Result;
                txtelatCprNamovafagh.Text = Dm1.causeCprUnsuccessful;
                isedit = true;
               
                DmD1 = Dm1;
               
            }


            //var temp = Dm.timebastarighati.Substring(0, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var temp2 = Dm.timebastarimovaghat.Substring(0, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var temp3 = Dm.timebastarighati.Substring(3, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var temp4 = Dm.timebastarimovaghat.Substring(3, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var time = (Int32.Parse(temp) - Int32.Parse(temp2)).ToString();
            //var time1 = (Int32.Parse(temp3) - Int32.Parse(temp4)).ToString();
            //var temp5 = Dm.timebastarighati.Substring(6, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var temp6 = Dm.timebastarimovaghat.Substring(6, 2);
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var time2 = (Int32.Parse(temp5) - Int32.Parse(temp6)).ToString();
            //textEdit8.Text = time + ":" +time1+":"+time2;
   
    
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

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
                TriageCPR m = new TriageCPR();
                m.IDPerson = ObjectPerson.ID;
                m.Staff3 = (lkpPezeshkhazzer.EditValue as Staff);
                m.Staff1 = (lkppezeshbihoshi.EditValue as Staff);
                m.Staff4 = (lkpDakheli1.EditValue as Staff);
                m.OtherStaff = txtsayerpezshkan.Text;
                m.timeCode = txtZamanElamCod.Text;
                m.timeStopHeart = txtSaateIstghalbi.Text;
                m.DateStopHeart = txtTarikhiestghalbi.Text;
                m.timePresenceCPR = txtZamanhoZorCpr.Text;
                m.CauseStopHeart = txtElatiestghalbi.Text;
                m.ConditionDescription = txtvaziyatbalini.Text;
                m.timeEnd = txtsaateetmamCpr.Text;
                m.CprUnsuccessful = ckbCprNamovafagh.Checked;
                m.Result = txtnatijenahaie.Text;
                m.causeCprUnsuccessful = txtelatCprNamovafagh.Text;
                m.GivenMID = ObjectM.ID;
                m.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                m.CreationTime = DateTime.Now.ToString("HH:mm");
                m.CreatorUserID = MainModule.UserID;
                m.UserFullname = MainModule.UserFullName;

                dc.TriageCPRs.InsertOnSubmit(m);
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
                DmD1.Staff3 = (lkpPezeshkhazzer.EditValue as Staff);
                DmD1.Staff1 = (lkppezeshbihoshi.EditValue as Staff);
                DmD1.Staff4 = (lkpDakheli1.EditValue as Staff);
                DmD1.OtherStaff = txtsayerpezshkan.Text;
                DmD1.timeCode = txtZamanElamCod.Text;
                DmD1.timeStopHeart = txtSaateIstghalbi.Text;
                DmD1.DateStopHeart = txtTarikhiestghalbi.Text;
                DmD1.timePresenceCPR = txtZamanhoZorCpr.Text;
                DmD1.CauseStopHeart = txtElatiestghalbi.Text;
                DmD1.ConditionDescription = txtvaziyatbalini.Text;
                DmD1.timeEnd = txtsaateetmamCpr.Text;
                DmD1.CprUnsuccessful = ckbCprNamovafagh.Checked;
                DmD1.Result = txtnatijenahaie.Text;
                DmD1.causeCprUnsuccessful = txtelatCprNamovafagh.Text;
                DmD1.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                DmD1.LastModificationTime = DateTime.Now.ToString("HH:mm");
                DmD1.LastModificator = MainModule.UserID;
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }
        }

}