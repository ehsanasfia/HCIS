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
    public partial class frmHadese : DevExpress.XtraEditors.XtraForm
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
        public frmHadese()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c => c.IDPerson == ObjectPerson.ID
            && c.AccureDate.CompareTo(txtFromDate.Text) >= 0 && c.AccureDate.CompareTo(txtToDate.Text) <= 0)
                 .OrderByDescending(c => c.AccureDate).ToList();
        }

        private void frmHadese_Load(object sender, EventArgs e)
        {
            txtdatehadese.Text = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            var Dm2 = dc.TriageEMGincidents.Where(c => c.GivenMID == ObjectM.ID).FirstOrDefault();
            if (Dm2 == null )
            {

               // txtdatehadese.Text = "";
                txtmahal.Text = "";
                txtnohadese.Text = "";
                txtmantaghehadese.Text = "";
                txtshahr.Text = "";
                txtnatije.Text = "";
                txtdatehadese.Text = MainModule.GetPersianDate(DateTime.Now);
                return;
                isedit = false;
            }

            else
            { 
                txtdatehadese.Text = Dm2.AccureDate;
                txtmahal.Text = Dm2.AccuerPlace;
                txtnohadese.Text = Dm2.AccuerKind;
                txtmantaghehadese.Text = Dm2.AccuerReg;
                txtshahr.Text = Dm2.AccuerCity;
                txtnatije.Text = Dm2.AccuerResult;
                isedit = true;
                DmD2 = Dm2;
               
            }

            triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c => c.IDPerson == ObjectPerson.ID
            && c.AccureDate.CompareTo(txtFromDate.Text) >= 0 && c.AccureDate.CompareTo(txtToDate.Text) <= 0)
                 .OrderByDescending(c => c.AccureDate).ToList();
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



                TriageEMGincident h = new TriageEMGincident();
                h.IDPerson = ObjectPerson.ID;
                h.AccureDate = txtdatehadese.Text;
                h.AccuerPlace = txtmahal.Text;
                h.AccuerKind = txtnohadese.Text;
                h.AccuerReg = txtmantaghehadese.Text;
                h.AccuerCity = txtshahr.Text;
                h.AccuerResult = txtnatije.Text;
                h.GivenMID = ObjectM.ID;
                h.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                h.CreationTime = DateTime.Now.ToString("HH:mm");
                h.CreatorUserID = MainModule.UserID;
                //u.UserFullname = MainModule.UserFullName;

                dc.TriageEMGincidents.InsertOnSubmit(h);
                dc.SubmitChanges();
                triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c => c.IDPerson == ObjectPerson.ID
                 && c.AccureDate.CompareTo(txtFromDate.Text) >= 0 && c.AccureDate.CompareTo(txtToDate.Text) <= 0)
               .OrderByDescending(c => c.AccureDate).ToList();

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

                DmD2.AccureDate = txtdatehadese.Text;
                DmD2.AccuerPlace = txtmahal.Text;
                DmD2.AccuerKind = txtnohadese.Text;
                DmD2.AccuerReg = txtmantaghehadese.Text;
                DmD2.AccuerCity = txtshahr.Text;
                DmD2.AccuerResult = txtnatije.Text;
                dc.SubmitChanges();
                triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c => c.IDPerson == ObjectPerson.ID
                && c.AccureDate.CompareTo(txtFromDate.Text) >= 0 && c.AccureDate.CompareTo(txtToDate.Text) <= 0)
               .OrderByDescending(c => c.AccureDate).ToList();

                MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}