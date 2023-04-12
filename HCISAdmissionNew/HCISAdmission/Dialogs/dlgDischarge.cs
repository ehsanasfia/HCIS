using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Dialogs
{
    public partial class dlgDischarge : DevExpress.XtraEditors.XtraForm
    {
        public dlgDischarge()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public long dossierID;
        List<GivenServiceM> lst;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                lst = new List<GivenServiceM>();
                //if (lookUpEdit1.EditValue == null)
                //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }
                if (Int16.Parse(radioGroup1.EditValue.ToString()) == 1)
                {
                    if (txtDossier.Text.Trim() == "")
                        txtDossier.Text = "0";
                    var d = dc.Dossiers.Where(c => c.IOtype == 1  && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 
                   && (((txtNatinalCode.Text == null || txtNatinalCode.Text.Trim() == "") ? false : (y.Person.NationalCode == txtNatinalCode.Text.Trim()))
                   || ((txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "") ? false : (y.Person.PersonalCode == txtPersonalCode.Text.Trim()))
                   || ((txtDossier.Text == null || txtDossier.Text.Trim() == "" ) ? false : (y.DossierID == long.Parse(txtDossier.Text.Trim().ToString())))
                   ))).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.SerialNumber).FirstOrDefault());
                    });
                }
                else if (Int16.Parse(radioGroup1.EditValue.ToString()) == 2)
                {

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.Discharge != true && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && y.Confirm != true && (((txtName.Text != null && txtName.Text.Trim() != "") ? y.Person.FirstName == txtName.Text.Trim() : false) && ((txtLastName.Text != null && txtLastName.Text.Trim() != "") ? y.Person.LastName == txtLastName.Text.Trim() : false)))).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.SerialNumber).FirstOrDefault());
                    });
                }
                else if (Int16.Parse(radioGroup1.EditValue.ToString()) == 3)
                {
                    if (lkpWard.EditValue == null)
                    {
                        MessageBox.Show("بخش را انتخاب کنید");
                        return;
                    }

                    if (txtToDate.Text.Trim() == "")
                    {
                        MessageBox.Show("ناریخ پایان را وارد کنید");
                        return;
                    }
                    if (txtFromDate.Text.Trim() == "")
                    {
                        MessageBox.Show("ناریخ شروع را وارد کنید");
                        return;
                    }

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.Discharge != true && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && y.Confirm != true && y.DepartmentID == Guid.Parse(lkpWard.EditValue.ToString()) && y.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && y.AdmitDate.CompareTo(txtToDate.Text) >= 0)).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.SerialNumber).FirstOrDefault());
                    });
                }
                givenServiceMBindingSource.DataSource = lst.ToList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = dossierBindingSource.Current as Dossier;
            dossierID = cur.ID;
            DialogResult = DialogResult.OK;
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 || x.TypeID == 15).ToList();
            lkpWard.EditValue = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            current.Dossier.Discharge = true;
            current.Confirm = true;
            current.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
            current.ConfirmTime = DateTime.Now.ToString("HH:mm");
            current.LastModificator = MainModule.UserID;
            current.LastModificationTime = DateTime.Now.ToString("HH:mm");
            current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            dc.SubmitChanges();

            MessageBox.Show(".بیمار با موفقیت ترخیص شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            btnSearch_Click(null, null);
        }
    }
}