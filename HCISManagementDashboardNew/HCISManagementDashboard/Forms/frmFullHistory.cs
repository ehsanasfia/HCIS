using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmFullHistory : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        bool cancelflag = false;
        Person ObjectPerson;
        List<View_SarpaeiServiceUnion> lstSarpaei;

        public frmFullHistory()
        {
            InitializeComponent();
        }

        private void frmFullHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void GetData()
        {
            if (ObjectPerson == null || ObjectPerson.MedicalID == null)
            {
                MessageBox.Show("بیمار یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool newPerson = false;
            if (txtPersonalCode.EditValue == null || string.IsNullOrWhiteSpace(txtPersonalCode.Text))
            {
                MessageBox.Show("لطفا یک کد پرسنلی انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            string nat = null;
            if (!newPerson)
            {
                nat = txtPersonalCode.Text.Trim();
            }
            
            if (!newPerson)
            {
                cancelflag = false;
                #region PersonalCode
                //اگر کد پرسنلی از کاربر بگیرد ابتدا بیمه را باید انتخاب کند
                #region moshakhas kardane bime
                if (txtPersonalCode.Text.Length < 10)
                {
                    var myHCISdata = dc.Persons.Where(c => c.PersonalCode == txtPersonalCode.Text).ToList();
                    var AllDBdata = dc.Spu_AllDBPerson(txtPersonalCode.Text, "").Where(c => c.NationalCode.Length != 0).ToList();
                    var y = AllDBdata.GroupBy(c => c.InsureName).Distinct();
                    string selectedInsure = "";
                    if (y.Count() > 1)
                    {
                        // انتخاب بیمه
                        var dlgInsure = new Dialogs.dlgSelectInsuree() { dc = dc, insurlist = y.ToList() };
                        if (dlgInsure.ShowDialog() != DialogResult.OK) return;
                        selectedInsure = dlgInsure.Current;
                    }
                    else
                    if (y.Count() == 1)
                        selectedInsure = y.FirstOrDefault().Key;
                    else
                    {
                        SearchInHCIS(myHCISdata, ref newPerson);
                        GetData();
                        return;
                    }
                    #endregion
                    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    if (cancelflag == true)
                    {
                        return;
                    }
                    if (NewPerson == null)
                    {
                        SearchInHCIS(myHCISdata, ref newPerson);
                        if (cancelflag == true)
                            return;
                        GetData();
                        return;
                    }
                    if (!dc.Persons.Any(c => c.NationalCode == NewPerson.NationalCode))
                    {
                        ObjectPerson = new Person()
                        {
                            FirstName = NewPerson.Firstname,
                            LastName = NewPerson.Lastname,
                            BirthDate = NewPerson.BirthDate,
                            FatherName = NewPerson.FatherName,
                            InsuranceName = NewPerson.InsureName,
                            InsuranceNo = NewPerson.InsuranceNo,
                            PersonalCode = NewPerson.PersonnelNo.ToString(),
                            BookletExpireDate = NewPerson.ExpDate,
                            MedicalID = NewPerson.InsuranceNo,
                            Phone = NewPerson.HomePhone,
                            Sex = NewPerson.Sex == 0 ? true : false,
                        };
                        if (NewPerson.NationalCode.Length == 10)
                        {
                            ObjectPerson.NationalCode = NewPerson.NationalCode;
                        }
                        dc.Persons.InsertOnSubmit(ObjectPerson);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        ObjectPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewPerson.NationalCode);
                    }

                }
                #endregion
            }
            if (!newPerson)
            {
                GetData();
            }
            if (newPerson)
            {
                BuildNewPerson();
            }


            if (ObjectPerson == null || ObjectPerson.MedicalID == null)
            {
                MessageBox.Show("بیمار یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            lstSarpaei = dc.View_SarpaeiServiceUnions.Where(x => x.MedicalID == ObjectPerson.MedicalID
            && ((x.CatID == 7 && x.AgendaDate == null) || (x.DepOldID == 5000 || x.CatID == 5 ? x.Admitted : x.Confirm) != false)).ToList();
            foreach (var item in lstSarpaei)
            {
                if(item.DepTypeID == 12 || (item.CatID == 7 && item.AgendaDate == null))
                {
                    item.MyDate = item.GsdDate;
                }
                else if(item.CatID == 3 || (item.CatID == 7 && item.AgendaDate != null))
                {
                    item.MyDate = item.AgendaDate;
                }
                else if(item.CatID == 5)
                {
                    item.MyDate = item.AdmitDate;
                }
                else
                {
                    item.MyDate = item.VisitDate;
                }

                if(item.DepOldID == 5000)
                {
                    item.MyDep = item.DepartmentName ?? item.AgendaDepartmentName;
                }
                else if(item.CatID == 7)
                {
                    if(item.AgendaDepartmentID != null)
                    {
                        item.MyDep = item.AgendaDepartmentName;
                    }
                    else
                    {
                        item.MyDep = item.DepartmentName;
                    }
                }
                else if(item.CatID == 5)
                {
                    item.MyDep = item.ServiceParentID == null ? "" : dc.Services.FirstOrDefault(x => x.ID == item.ServiceParentID).Name;
                }
                else if(item.CatID == 3)
                {
                    item.MyDep = item.AgendaDepartmentName;
                }
                else
                {
                    item.MyDep = item.DepartmentName;
                }
                item.Amount = item.CatID == 4 || item.CatID == 12 ? item.Amount : (item.Amount <= 0 ? 1 : item.Amount); 
            }

            lstSarpaei = lstSarpaei.OrderBy(c => c.Name).OrderByDescending(c => c.MyDate).ToList();
            viewSarpaeiServiceUnionBindingSource.DataSource = lstSarpaei;
        }

        private Spu_AllDBPersonResult FindePersonWithInsureInAllDB(List<Spu_AllDBPersonResult> mydata, List<Person> myHCISdata, string selectedInsure, ref bool newPerson)
        {
            Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
            var PaitiontsInsuer = mydata.Where(c => c.InsureName == selectedInsure.ToString()).ToList();

            if (PaitiontsInsuer.Count == 0)
            {
                SearchInHCIS(myHCISdata, ref newPerson);
                return NewPerson = null;
            }
            else if (PaitiontsInsuer.Count == 1)
            {
                NewPerson = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                return NewPerson;
            }

            else if (PaitiontsInsuer.Count > 1)
            {
                var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                if (dlg2.ShowDialog() != DialogResult.OK)
                {
                    cancelflag = true;
                    return NewPerson = null;
                }
                NewPerson = dlg2.Current;
                return NewPerson;
            }
            return NewPerson = null;
        }

        private void SearchInHCIS(List<Person> myHCISdata, ref bool newPerson)
        {
            cancelflag = false;
            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK)
                {
                    cancelflag = true;
                    return;
                }
                ObjectPerson = dlgsame.Current;
            }
            else
            {
                if (MessageBox.Show(this, "بیماری باکد شناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
                newPerson = true;
                BuildNewPerson();
                return;
            }
        }

        private void BuildNewPerson()
        {
            ObjectPerson = null;
            GetData();
            ObjectPerson.PersonalCode = txtPersonalCode.Text;
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            dossierBindingSource.DataSource = dc.Dossiers.Where(c => c.PersonID == ObjectPerson.ID && c.IOtype == 1).ToList();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var dosseir = dossierBindingSource.Current as Dossier;
            vwDoctorInstractionBindingSource.DataSource = dc.VwDoctorInstractions.Where(c => c.DossierID == dosseir.ID).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}