using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Classes;
using OMOApp.Data;

namespace OMOApp.Dialogs
{
    public partial class dlgPersonSearch : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext om = new OMOClassesDataContext();
        JamiatClassesDataContext jdc = new JamiatClassesDataContext();
        Data.HCISData.HCISClassesDataContext hdc = new Data.HCISData.HCISClassesDataContext();

        List<PersonViewModel> lstPersonViewModel = new List<PersonViewModel>();

        public string GivenNationalCode { get; set; }
        public string GivenPersonalCode { get; set; }

        public Person SelectedPerson { get; set; }

        private bool CanConnectToHCIS = false;

        public dlgPersonSearch()
        {
            InitializeComponent();
        }

        private void dlgPersonSearch_Load(object sender, EventArgs e)
        {
            CanConnectToHCIS = OMOApp.Properties.Settings.Default.ConnectToHcis;

            personViewModelBindingSource.DataSource = lstPersonViewModel;
            if (GivenNationalCode != null)
            {
                txtNationalCode.Text = GivenNationalCode;
                btnSearchNationalCode_Click(null, null);
                if (lstPersonViewModel.Count == 1)
                {
                    btnOk_Click(null, null);
                }
            }
            else if (GivenPersonalCode != null)
            {
                txtPersonalCode.Text = GivenPersonalCode;
                btnSearchPersonalCode_Click(null, null);
                if (lstPersonViewModel.Count == 1)
                {
                    btnOk_Click(null, null);
                }
            }
        }

        private void btnSearchNationalCode_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtNationalCode.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                lstPersonViewModel.Clear();

                var NationalCode = text.Trim();
                var lstOm = GetOMOPersons(NationalCode, null, null, null, null);
                if (lstOm != null && lstOm.Any()) // show
                {
                    lstPersonViewModel = lstOm;
                }
                else // search in jamiat
                {
                    var lstJam = GetJamiatPersons(NationalCode, null, null, null, null);
                    if (lstJam != null && lstJam.Any())
                    {
                        lstPersonViewModel = lstJam;
                    }
                }

                personViewModelBindingSource.DataSource = lstPersonViewModel;
                gridControl1.RefreshDataSource();

                if (!lstPersonViewModel.Any())
                {
                    btnNewPerson_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSearchPersonalCode_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtPersonalCode.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                int PersonalCode = -1;
                bool valid = int.TryParse(text, out PersonalCode);
                if (!valid || PersonalCode == -1)
                {
                    MessageBox.Show("کد پرسنلی وارد شده معتبر نمیباشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                lstPersonViewModel.Clear();

                var lstOm = GetOMOPersons(null, PersonalCode, null, null, null);
                if (lstOm != null && lstOm.Any()) // show
                {
                    lstPersonViewModel = lstOm;
                }
                else // search in jamiat
                {
                    var lstJam = GetJamiatPersons(null, PersonalCode, null, null, null);
                    if (lstJam != null && lstJam.Any())
                    {
                        lstPersonViewModel = lstJam;
                    }
                }

                personViewModelBindingSource.DataSource = lstPersonViewModel;
                gridControl1.RefreshDataSource();

                if (!lstPersonViewModel.Any())
                {
                    btnNewPerson_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSearchFLname_Click(object sender, EventArgs e)
        {
            try
            {
                var textF = txtFname.Text;
                var textL = txtLname.Text;
                if (string.IsNullOrWhiteSpace(textF) && string.IsNullOrWhiteSpace(textL))
                {
                    return;
                }

                lstPersonViewModel.Clear();

                var FirstName = textF.Trim();
                var LastName = textL.Trim();
                if (!string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName))
                {
                    var lstOm = GetOMOPersons(null, null, FirstName, null, null);
                    if (lstOm != null && lstOm.Any()) // show
                    {
                        lstPersonViewModel = lstOm;
                    }
                    else // search in jamiat
                    {
                        var lstJam = GetJamiatPersons(null, null, FirstName, null, null);
                        if (lstJam != null && lstJam.Any())
                        {
                            lstPersonViewModel = lstJam;
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(LastName) && string.IsNullOrWhiteSpace(FirstName))
                {
                    var lstOm = GetOMOPersons(null, null, null, LastName, null);
                    if (lstOm != null && lstOm.Any()) // show
                    {
                        lstPersonViewModel = lstOm;
                    }
                    else // search in jamiat
                    {
                        var lstJam = GetJamiatPersons(null, null, null, LastName, null);
                        if (lstJam != null && lstJam.Any())
                        {
                            lstPersonViewModel = lstJam;
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(FirstName))
                {
                    var lstOm = GetOMOPersons(null, null, FirstName, LastName, null);
                    if (lstOm != null && lstOm.Any()) // show
                    {
                        lstPersonViewModel = lstOm;
                    }
                    else // search in jamiat
                    {
                        var lstJam = GetJamiatPersons(null, null, FirstName, LastName, null);
                        if (lstJam != null && lstJam.Any())
                        {
                            lstPersonViewModel = lstJam;
                        }
                    }
                }

                personViewModelBindingSource.DataSource = lstPersonViewModel;
                gridControl1.RefreshDataSource();

                if (!lstPersonViewModel.Any())
                {
                    btnNewPerson_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSearchIdentityNum_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtIdentityNum.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                lstPersonViewModel.Clear();

                var IdentityNumber = text.Trim();
                var lstOm = GetOMOPersons(null, null, null, null, IdentityNumber);
                if (lstOm != null && lstOm.Any()) // show
                {
                    lstPersonViewModel = lstOm;
                }
                else // search in jamiat
                {
                    var lstJam = GetJamiatPersons(null, null, null, null, IdentityNumber);
                    if (lstJam != null && lstJam.Any())
                    {
                        lstPersonViewModel = lstJam;
                    }
                }

                personViewModelBindingSource.DataSource = lstPersonViewModel;
                gridControl1.RefreshDataSource();

                if (!lstPersonViewModel.Any())
                {
                    btnNewPerson_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private List<PersonViewModel> GetOMOPersons(string NationalCode, int? PersonalCode, string FirstName, string LastName, string IdentityNumber)
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            List<Person> lstPerson = new List<Person>();

            if (string.IsNullOrWhiteSpace(NationalCode) && PersonalCode == null && string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName) && string.IsNullOrWhiteSpace(IdentityNumber))
                return lst;
            else if (NationalCode != null)
            {
                lstPerson = om.Persons.Where(x => x.NationalCode == NationalCode).ToList();
            }
            else if (PersonalCode != null)
            {
                lstPerson = om.Persons.Where(x => x.PersonalNo == PersonalCode).ToList();
            }
            else if (FirstName != null && LastName == null)
            {
                lstPerson = om.Persons.Where(x => x.FirstName != null && x.FirstName.Contains(FirstName)).ToList();
            }
            else if (LastName != null && FirstName == null)
            {
                lstPerson = om.Persons.Where(x => x.LastName != null && x.LastName.Contains(LastName)).ToList();
            }
            else if (FirstName != null && LastName != null)
            {
                lstPerson = om.Persons.Where(x => x.FirstName != null && x.LastName != null && x.FirstName.Contains(FirstName) && x.LastName.Contains(LastName)).ToList();
            }
            else if (IdentityNumber != null)
            {
                lstPerson = om.Persons.Where(x => x.IdentityNumber == IdentityNumber).ToList();
            }

            lst = lstPerson.Select(x => new PersonViewModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                FatherName = x.FatherName,
                NationalCode = x.NationalCode,
                PersonalCode = MainModule.PersonalNoToString(x.PersonalNo),
                OMOID = x.ID,
                OmoPerson = x
            }).ToList();

            return lst;
        }

        private List<PersonViewModel> GetJamiatPersons(string NationalCode, int? PersonalCode, string FirstName, string LastName, string IdentityNumber)
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            List<PersonTbl> lstPerson = new List<PersonTbl>();

            if (string.IsNullOrWhiteSpace(NationalCode) && PersonalCode == null && string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName) && string.IsNullOrWhiteSpace(IdentityNumber))
                return lst;
            else if (NationalCode != null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.NationalCode == NationalCode).ToList();
            }
            else if (PersonalCode != null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.PersonnelNo == PersonalCode && x.RelationOrderNo == 0).ToList();
            }
            else if (FirstName != null && LastName == null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.Firstname != null && x.Firstname.Contains(FirstName) && x.RelationOrderNo == 0).ToList();
            }
            else if (LastName != null && FirstName == null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.Lastname != null && x.Lastname.Contains(LastName) && x.RelationOrderNo == 0).ToList();
            }
            else if (FirstName != null && LastName != null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.Firstname != null && x.Lastname != null && x.Firstname.Contains(FirstName) && x.Lastname.Contains(LastName) && x.RelationOrderNo == 0).ToList();
            }
            else if (IdentityNumber != null)
            {
                lstPerson = jdc.PersonTbls.Where(x => x.IdentityNo == IdentityNumber).ToList();
            }

            lst = lstPerson.Select(x => new PersonViewModel()
            {
                FirstName = x.Firstname,
                LastName = x.Lastname,
                BirthDate = x.BirthDate == 0 || x.BirthDate.ToString().Length != 8 ? null : x.BirthDate.ToString().Substring(0, 4) + "/" + x.BirthDate.ToString().Substring(4, 2) + "/" + x.BirthDate.ToString().Substring(6, 2),
                FatherName = x.FatherName,
                NationalCode = x.NationalCode,
                PersonalCode = MainModule.PersonalNoToString(x.PersonnelNo),
                JamiatID = x.IDPerson,
                JamiatPerson = x
            }).ToList();

            return lst;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = personViewModelBindingSource.Current as PersonViewModel;
                if (cur == null)
                    return;

                if (cur.JamiatPerson != null && cur.JamiatPerson.RelationOrderNo != 0)
                {
                    MessageBox.Show("شخص انتخاب شده، جزء شاغلین نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var prs = CheckOMO(cur);
                if (prs == null)
                    return;
                Person omoPerson = om.Persons.FirstOrDefault(x => x.ID == prs.ID);

                if (CanConnectToHCIS)
                {
                    var hcisOK = CheckHCIS(omoPerson);
                    if (hcisOK == null)
                        return;
                }

                SelectedPerson = omoPerson;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private Person CheckOMO(PersonViewModel CurPerson)
        {
            try
            {
                Person omoPerson = CurPerson.OmoPerson;
                if (CurPerson.OmoPerson != null)
                    return omoPerson;

                var dlgprs = new dlgPerson() { JamiatPerson = CurPerson.JamiatPerson };
                if (dlgprs.ShowDialog() == DialogResult.OK)
                {
                    return dlgprs.EditingPerson;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }
        }

        private Data.HCISData.Person CheckHCIS(Person omoPrs)
        {
            try
            {
                var hprs = hdc.Persons.FirstOrDefault(x => x.NationalCode == omoPrs.NationalCode);
                if (hprs != null)
                    return hprs;

                var dlgIns = new dlgHCIS() { OmoPerson = omoPrs };
                if (dlgIns.ShowDialog() == DialogResult.OK)
                {
                    return dlgIns.EditingPerson;
                }
                else
                {
                    return null;
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("network-related"))
                {
                    MessageBox.Show("امکان دسترسی به HCIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return null;
                }
                else
                {
                    MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk_Click(null, null);
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            var dlg = new dlgPerson()
            {
                PersonalCode = txtPersonalCode.Text.Trim() == "" ? null : txtPersonalCode.Text.Trim(),
                NationalCode = txtNationalCode.Text.Trim() == "" ? null : txtNationalCode.Text.Trim()
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var prs = dlg.EditingPerson;

                txtPersonalCode.Text = "";
                txtNationalCode.Text = prs.NationalCode;

                btnSearchNationalCode_Click(null, null);
            }
        }
    }
}