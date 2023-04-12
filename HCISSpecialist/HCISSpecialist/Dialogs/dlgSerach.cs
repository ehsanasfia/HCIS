using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgSerach : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        HCISSpecialistClassesDataContext dc = new HCISSpecialistClassesDataContext();
        bool cancelFlag;
        Person EditingPerson;
        public dlgSerach()
        {
            InitializeComponent();
        }

        private void SearchInHCIS(List<Person> myHCISdata, ref bool newPerson)
        {
            cancelFlag = false;
            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK)
                {
                    cancelFlag = true;
                    return;
                }
                EditingPerson = dlgsame.Current;
                newPerson = false;
            }
            else
            {
                newPerson = true;
                return;
            }
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
                    cancelFlag = true;
                    return NewPerson = null;
                }
                NewPerson = dlg2.Current;

                return NewPerson;
            }
            return NewPerson = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            bool showDlg = false;
            cancelFlag = false;
            if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                showDlg = true;
            }

            string nat = null;
            if (!showDlg)
            {
                nat = txtNationalCode.Text.Trim();
            }
            if (!showDlg)
            {
                bool newPerson = false;

                #region PersonalCode
                //اگر کد پرسنلی از کاربر بگیرد ابتدا بیمه را باید انتخاب کند
                #region moshakhas kardane bime
                if (txtNationalCode.Text.Length < 10)
                {
                    var myHCISdata = dc.Persons.Where(c => c.PersonalCode == txtNationalCode.Text).ToList();
                    var AllDBdata = dc.Spu_AllDBPerson(txtNationalCode.Text, "").Where(c => c.NationalCode.Length != 0).ToList();
                    var y = AllDBdata.GroupBy(c => c.InsureName).Distinct();
                    string selectedInsure = "";
                    if (y.Count() > 1)
                    {
                        // انتخاب بیمه
                        var dlgInsure = new Dialogs.dlgSelectInsuree() { dc = dc, insurlist = y.ToList() };
                        if (dlgInsure.ShowDialog() != DialogResult.OK)
                            return;
                        selectedInsure = dlgInsure.Current;
                    }
                    else
                    if (y.Count() == 1)
                        selectedInsure = y.FirstOrDefault().Key;
                    else
                    {
                        SearchInHCIS(myHCISdata, ref newPerson);
                        return;
                    }
                    #endregion
                    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
                    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    if (cancelFlag)
                        return;
                    if (NewPerson == null)
                    {
                        SearchInHCIS(myHCISdata, ref newPerson);
                        if (cancelFlag == true || newPerson == false)
                            return;

                    }
                    if (!dc.Persons.Any(c => c.MedicalID == NewPerson.InsuranceNo))
                    {
                        EditingPerson = new Person()
                        {
                            FirstName = NewPerson.Firstname,
                            LastName = NewPerson.Lastname,
                            BirthDate = NewPerson.BirthDate,
                            FatherName = NewPerson.FatherName,
                            InsuranceName = NewPerson.InsureName,
                            InsuranceNo = NewPerson.InsuranceNo,
                            PersonalCode = NewPerson.PersonnelNo.ToString(),
                            BookletExpireDate = NewPerson.ExpDate,
                        };
                        if (NewPerson.NationalCode.Length == 10)
                        {
                            EditingPerson.NationalCode = NewPerson.NationalCode;
                        }
                        dc.Persons.InsertOnSubmit(EditingPerson);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        EditingPerson = dc.Persons.FirstOrDefault(c => c.MedicalID == NewPerson.InsuranceNo);
                        EditingPerson.FirstName = NewPerson.Firstname;
                        EditingPerson.LastName = NewPerson.Lastname;
                        EditingPerson.BirthDate = NewPerson.BirthDate;
                        EditingPerson.FatherName = NewPerson.FatherName;
                        EditingPerson.InsuranceName = NewPerson.InsureName;
                        EditingPerson.InsuranceNo = NewPerson.InsuranceNo;
                        EditingPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                        EditingPerson.BookletExpireDate = NewPerson.ExpDate;
                        dc.SubmitChanges();
                    }

                }
                #endregion
                #region      // agar codemeli valerd shode bashad
                else
                {
                    var PaitiontNational = dc.Persons.Where(c => c.NationalCode == txtNationalCode.Text).ToList();
                    Spu_AllDBPersonResult NewInsure = new Spu_AllDBPersonResult();
                    // insure haye mojod baraye shakhs ra peyda mikonim
                    var PaitiontsInsuer = dc.Spu_AllDBPerson("", txtNationalCode.Text).ToList();

                    if (PaitiontsInsuer.Count == 0)
                    {
                        if (PaitiontNational.Count == 0)
                        {
                            MessageBox.Show("بیماری با کدشناسایی مورد نظر یافت نشد ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        else
                        {
                            EditingPerson = PaitiontNational.FirstOrDefault();

                        }
                    }
                    else
                    {
                        if (PaitiontsInsuer.Count > 1)
                        {
                            var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                            if (dlg2.ShowDialog() != DialogResult.OK)
                                return;
                            NewInsure = dlg2.Current;
                        }
                        // اگر یک بیمه باشد
                        else if (PaitiontsInsuer.Count == 1)
                            NewInsure = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                        if (PaitiontNational.Count == 1)
                        {
                            EditingPerson = PaitiontNational.FirstOrDefault();
                            if (NewInsure.InsureName != null)
                                EditingPerson.InsuranceName = NewInsure.InsureName;

                            if (NewInsure.InsuranceNo != null)
                                EditingPerson.InsuranceNo = NewInsure.InsuranceNo;

                        }
                        else
                        {
                            EditingPerson = new Person()
                            {
                                FirstName = NewInsure.Firstname,
                                LastName = NewInsure.Lastname,
                                FatherName = NewInsure.FatherName,
                                BirthDate = NewInsure.BirthDate,
                                InsuranceName = NewInsure.InsureName,
                                InsuranceNo = NewInsure.InsuranceNo,
                                NationalCode = NewInsure.NationalCode,
                                PersonalCode = NewInsure.PersonnelNo,
                                BookletExpireDate = NewInsure.ExpDate
                            };
                            dc.Persons.InsertOnSubmit(EditingPerson);

                            dc.SubmitChanges();

                        }
                    }

                }
                #endregion
            }



            var frm = new Forms.frmCheckup();
            frm.IDPersonHistory = EditingPerson.ID;
            frm.ShowHistory = true;
            frm.ShowDialog();

            //GetData();

            //FirstNameTxt.Select();

            //if (showDlg)
            //{
            //    //Show search dialog
            //    var dlg = new dlgPersonSearch() { dc = dc };
            //    if (dlg.ShowDialog() == DialogResult.OK && dlg.EditingPerson != null)
            //    {
            //        EditingPerson = dlg.EditingPerson;
            //        //GetData();
            //    }
            //    //if didn't find:
            //    else
            //    {
            //        EditingPerson = null;
            //        //GetData();
            //    }
            //}




        }

        private void dlgSerach_Load(object sender, EventArgs e)
        {
            if (EditingPerson == null)
            {
                EditingPerson = new Person() { Sex = false };
            }
        }
    }
}