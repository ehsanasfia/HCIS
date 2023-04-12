using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISArchives.Classes;
using HCISArchives.Data;

namespace HCISArchives.Dialogs
{
    public partial class dlgCaseTrace2 : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public long dossierID;
        List<GivenServiceM> lst;
        List<Vw_ArchiveCaseTrace> lstView;
        List<Dossier> lstDos;

        public dlgCaseTrace2()
        {
            InitializeComponent();
        }

        private void dlgCaseTrace2_Load(object sender, EventArgs e)
        {
            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
            radioGroup1_SelectedIndexChanged(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lst = new List<GivenServiceM>();
                lstView = new List<Vw_ArchiveCaseTrace>();

                if (int.Parse(radioGroup1.EditValue.ToString()) == 1)
                {
                    if (txtDossier.Text.Trim() == "")
                        txtDossier.Text = "0";

                    lstDos = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10
                    && (((txtNatinalCode.Text == null || txtNatinalCode.Text.Trim() == "") ? false : (y.Person.NationalCode == txtNatinalCode.Text.Trim()))
                    || ((txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "") ? false : (y.Person.PersonalCode == txtPersonalCode.Text.Trim()))
                    || ((txtDossier.Text == "" /*|| txtDossier.Text.Trim() == ""*/ ) ? false : (y.DossierID == long.Parse(txtDossier.Text.Trim().ToString())))
                    ))).ToList();
                    lstDos.ForEach(x =>
                    {
                        var list = x.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department != null && c.Department.Name.Trim() != "" && c.Department.Name.Contains("اتاق عمل")).ToList();
                        if (list.Any())
                        {
                            var list2 = list.Where(h => h.GivenServiceMs.Any(k => k.ServiceCategoryID == (int)Category.خدمات_جراحی || k.ServiceCategoryID == (int)Category.بیهوشی)).ToList();
                            if (list2.Any())
                            {
                                lst.Add(list2.OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                            }
                        }
                        var g = x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10 && y.Department != null && y.Department.Name.Trim() != "" && !y.Department.Name.Contains("اتاق عمل")).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                        if (g != null)
                        {
                            lst.Add(g);
                        }
                    });

                    if (txtDossier.Text.Trim() == "0")
                        txtDossier.Text = "";

                    if (!string.IsNullOrWhiteSpace(txtDossier.Text) && !string.IsNullOrWhiteSpace(txtNatinalCode.Text) && !string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.DossID.CompareTo(txtDossier.Text) == 0 && x.NationalCode.CompareTo(txtNatinalCode.Text) == 0 && x.PersonalCode.CompareTo(txtPersonalCode.Text) == 0).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(txtDossier.Text) && !string.IsNullOrWhiteSpace(txtNatinalCode.Text) && string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.DossID.CompareTo(txtDossier.Text) == 0 && x.NationalCode.CompareTo(txtNatinalCode.Text) == 0).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(txtDossier.Text) && string.IsNullOrWhiteSpace(txtNatinalCode.Text) && !string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.DossID.CompareTo(txtDossier.Text) == 0 && x.PersonalCode.CompareTo(txtPersonalCode.Text) == 0).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(txtDossier.Text) && string.IsNullOrWhiteSpace(txtNatinalCode.Text) && string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.DossID.CompareTo(txtDossier.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtDossier.Text) && !string.IsNullOrWhiteSpace(txtNatinalCode.Text) && !string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.NationalCode.CompareTo(txtNatinalCode.Text) == 0 && x.PersonalCode.CompareTo(txtPersonalCode.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtDossier.Text) && !string.IsNullOrWhiteSpace(txtNatinalCode.Text) && string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.NationalCode.CompareTo(txtNatinalCode.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtDossier.Text) && string.IsNullOrWhiteSpace(txtNatinalCode.Text) && !string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.PersonalCode.CompareTo(txtPersonalCode.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtDossier.Text) && string.IsNullOrWhiteSpace(txtNatinalCode.Text) && string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    {
                        lstView = null;
                    }
                }
                else if (int.Parse(radioGroup1.EditValue.ToString()) == 2)
                {
                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && (((txtName.Text != null && txtName.Text.Trim() != "") ? y.Person.FirstName == txtName.Text.Trim() : false) && ((txtLastName.Text != null && txtLastName.Text.Trim() != "") ? y.Person.LastName == txtLastName.Text.Trim() : false)))).ToList();
                    d.ForEach(x =>
                    {
                        var list = x.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department != null && c.Department.Name.Trim() != "" && c.Department.Name.Contains("اتاق عمل")).ToList();
                        if (list.Any())
                        {
                            var list2 = list.Where(h => h.GivenServiceMs.Any(k => k.ServiceCategoryID == (int)Category.خدمات_جراحی || k.ServiceCategoryID == (int)Category.بیهوشی)).ToList();
                            if (list2.Any())
                            {
                                lst.Add(list2.OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                            }
                        }
                        var g = x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10 && y.Department != null && y.Department.Name.Trim() != "" && !y.Department.Name.Contains("اتاق عمل")).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                        if (g != null)
                        {
                            lst.Add(g);
                        }
                    });

                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.FirstName.CompareTo(txtName.Text) == 0 && x.LastName.CompareTo(txtLastName.Text) == 0).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.FirstName.CompareTo(txtName.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.LastName.CompareTo(txtLastName.Text) == 0).ToList();
                    }
                    if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        lstView = null;
                    }
                }
                else if (int.Parse(radioGroup1.EditValue.ToString()) == 3)
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

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.Date.CompareTo(txtFromDate.Text) >= 0 && c.Date.CompareTo(txtToDate.Text) <= 0 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && y.DepartmentID == Guid.Parse(lkpWard.EditValue.ToString()))).ToList();
                    d.ForEach(x =>
                    {
                        var list = x.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department != null && c.Department.Name.Trim() != "" && c.Department.Name.Contains("اتاق عمل")).ToList();
                        if (list.Any())
                        {
                            var list2 = list.Where(h => h.GivenServiceMs.Any(k => k.ServiceCategoryID == (int)Category.خدمات_جراحی || k.ServiceCategoryID == (int)Category.بیهوشی)).ToList();
                            if (list2.Any())
                            {
                                lst.Add(list2.OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                            }
                        }
                        var g = x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10 && y.Department != null && y.Department.Name.Trim() != "" && !y.Department.Name.Contains("اتاق عمل")).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                        if (g != null)
                        {
                            lst.Add(g);
                        }
                    });

                    var ward = (lkpWard.EditValue as Department).Name;
                    lstView = dc.Vw_ArchiveCaseTraces.Where(x => x.Bakhsh.CompareTo(ward) == 0 && x.TarikheBastari.CompareTo(txtFromDate.Text) >= 0 && x.TarikheBastari.CompareTo(txtToDate.Text) <= 0).ToList();
                }

                vwArchiveCaseTraceBindingSource.DataSource = lstView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = vwArchiveCaseTraceBindingSource.Current as Vw_ArchiveCaseTrace;
            if (current == null)
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                labelControl1.Text = "";
                return;
            }

            var dos = dc.Dossiers.FirstOrDefault(x => x.ID == current.DossID);

            if (dos.ArchiveDashboards.Any() == false)
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "بیمار بستری است.";
            }
            else if (dos.ArchiveDashboards.Any() && (dos.ArchiveDashboards.FirstOrDefault().SecretaryAccept == null || dos.ArchiveDashboards.FirstOrDefault().SecretaryAccept == false))
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "بیمار از بخش ترخیص شده ولی پرونده ای به بایگانی ارسال نشده است.";
            }
            else if (dos.ArchiveDashboards.Any() && dos.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true &&
                    (dos.ArchiveDashboards.FirstOrDefault().ArchivistAccept == null || dos.ArchiveDashboards.FirstOrDefault().ArchivistAccept == false) &&
                    (dos.ArchiveDashboards.FirstOrDefault().CodingAccept == null || dos.ArchiveDashboards.FirstOrDefault().CodingAccept == false))
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی چک لیست است.";
            }
            else if (dos.ArchiveDashboards.Any() && dos.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true &&
                     dos.ArchiveDashboards.FirstOrDefault().ArchivistAccept == true &&
                    (dos.ArchiveDashboards.FirstOrDefault().CodingAccept == null || dos.ArchiveDashboards.FirstOrDefault().CodingAccept == false))
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی کدینگ است.";
            }
            else if (dos.ArchiveDashboards.Any() && dos.ArchiveDashboards.FirstOrDefault().SecretaryAccept == true &&
                     dos.ArchiveDashboards.FirstOrDefault().ArchivistAccept == true &&
                     dos.ArchiveDashboards.FirstOrDefault().CodingAccept == true)
            {
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                labelControl1.Text = "پرونده ی بیمار در مرحله ی بایگانی است.";
            }

            if (dos.GivenServiceMs.Any(x => x.ServiceCategoryID == 9 || x.ServiceCategoryID == 11))
            {
                layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == dos.ID && x.GivenServiceM.ServiceCategoryID == 11);
                givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == dos.ID && x.GivenServiceM.ServiceCategoryID == 9);
            }
            else
            {
                layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                txtNatinalCode.Enabled = true;
                txtPersonalCode.Enabled = true;
                txtDossier.Enabled = true;
                txtName.Enabled = false;
                txtLastName.Enabled = false;
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                lkpWard.Enabled = false;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                txtNatinalCode.Enabled = false;
                txtPersonalCode.Enabled = false;
                txtDossier.Enabled = false;
                txtName.Enabled = true;
                txtLastName.Enabled = true;
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                lkpWard.Enabled = false;
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                txtNatinalCode.Enabled = false;
                txtPersonalCode.Enabled = false;
                txtDossier.Enabled = false;
                txtName.Enabled = false;
                txtLastName.Enabled = false;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                lkpWard.Enabled = true;
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            var dlg = new dlgTraceDetails() { dc = dc, lstDos = lstDos };
            dlg.ShowDialog();
        }
    }
}
