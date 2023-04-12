using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Classes;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class frmPardakhtBastari : DevExpress.XtraEditors.XtraForm
    {
        public frmPardakhtBastari()
        {
            InitializeComponent();
        }
        Data.HCISCashDataContextDataContext dc = new Data.HCISCashDataContextDataContext();
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
                {if (txtDossier.Text.Trim() == "")
                        txtDossier.Text = "0";
                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 
                    && (((txtNatinalCode.Text == null || txtNatinalCode.Text.Trim()=="")?false: (y.Person.NationalCode == txtNatinalCode.Text.Trim()))
                    || ((txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "") ? false: (y.Person.PersonalCode == txtPersonalCode.Text.Trim()))
                    || ((txtDossier.Text == "" /*|| txtDossier.Text.Trim() == ""*/ )? false: (y.DossierID == long.Parse(txtDossier.Text.Trim().ToString())))
                    ))).ToList();
                    d.ForEach(x =>
                    { lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.SerialNumber).FirstOrDefault());
                    });
                }
                else if (Int16.Parse(radioGroup1.EditValue.ToString()) == 2)
                {

                    var d = dc.Dossiers.Where(c =>c.IOtype==1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && (((txtName.Text !=null && txtName.Text.Trim() != "" )? y.Person.FirstName == txtName.Text.Trim() : false )&& ((txtLastName.Text!=null && txtLastName.Text.Trim() != "" )? y.Person.LastName == txtLastName.Text.Trim(): false)))).ToList();
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

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && y.DepartmentID ==Guid.Parse( lkpWard.EditValue.ToString()) && y.AdmitDate .CompareTo(txtFromDate.Text)>=0 && y.AdmitDate.CompareTo(txtToDate.Text) >= 0)).ToList();
                    d.ForEach(x =>
                    { lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.SerialNumber).FirstOrDefault());
                    });
                }
                givenServiceMBindingSource.DataSource = lst;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as Data.GivenServiceM;
            dossierID = cur.DossierID ?? 0;
            var dlg = new dlgDossierPay() { dc = dc, Dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossierID) };
            if (dlg.ShowDialog() == DialogResult.OK)
            { }
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 && x.TypeID == 15).ToList();
           
        }
    }
}