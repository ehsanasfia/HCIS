using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;
using System.Data.Linq;

namespace HCISNurse.Dialogs
{
    public partial class dlgGivenServices : DevExpress.XtraEditors.XtraForm
    {
        private Dossier EditingDossier;
        public List<GivenServiceD> lstGSD;
        List<GivenDrug> lstGD;
        private DataClasses1DataContext dc;
        public dlgGivenServices(Dossier EditingDossier, DataClasses1DataContext dc)
        {
            InitializeComponent();
            this.EditingDossier = EditingDossier;
            this.dc = dc;
        }

        private void dlgGivenServices_Load(object sender, EventArgs e)
        {
            try
            {
                radioGroup1_SelectedIndexChanged(null, null);
                lstGSD = dc.GivenServiceDs.Where(x => x.GivenServiceM != null 
                    && (x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_کلینیکی || x.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی ) 
                    && x.GivenServiceM.DossierID == EditingDossier.ID).ToList();

                lstGSD.ForEach(x =>
                {
                    x.GivenServiceM.DoctorName = (x.GivenServiceM.Staff?.Person?.FirstName + " " + x.GivenServiceM.Staff?.Person?.LastName);
                });

                givenServiceDBindingSource.DataSource = lstGSD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Staff functorStf = null;
                if (dc.GetChangeSet().Updates.Any())
                {
                    var dlg = new dlgNurseCode(dc);
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    functorStf = dlg.SelectedStaff;

                    var today = MainModule.GetPersianDate(DateTime.Now);
                    var now = DateTime.Now.ToString("HH:mm");
                    dc.GetChangeSet().Updates.OfType<GivenServiceD>().ToList()
                        .ForEach(x =>
                        {
                            x.LastModificationDate = today;
                            x.LastModificationTime = now;
                            x.LastModificator = MainModule.UserID;
                            if (x.Confirm)
                                x.Staff = functorStf;
                            else
                                x.Staff = null;
                        });
                    if (lstGD == null)
                        lstGD = new List<GivenDrug>();
                    lstGD.ForEach(x => x.FunctorID = functorStf.ID);
                    var insertlstGD = lstGD.Where(x => x.ID == Guid.Empty).ToList();
                    dc.GivenDrugs.InsertAllOnSubmit(insertlstGD);
                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                else
                    {
                        MessageBox.Show("شما هیچ خدمتی را به عنوان انجام شده علامت نزده اید.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;

            if (cur.Payed == false)
                e.Cancel = true;

        }

        private void btnAddGivenDrug_Click(object sender, EventArgs e)
        {
            var CurrentDrug = slkDrugService.EditValue as Service;
            if (CurrentDrug == null)
            {
                MessageBox.Show("ابتدا دارو را انتخاب کنید"); return;
            }
            var CurrentGSD = givenServiceDBindingSource.Current as GivenServiceD;
            if (CurrentGSD == null)
            {
                MessageBox.Show("ابتدا خدمت را انتخاب کنید");
                return;
            }
    if (CurrentGSD.GivenDrugs.Count() > 0)
            {
                MessageBox.Show("خدمات دارویی ثبت شده است امکان ویرایش وجود ندارد."); return;
            }
            if (dc.GivenDrugs.Where(x => x.GsdID == CurrentGSD.ID).ToList().Count() > 0)
            {
                MessageBox.Show("خدمات دارویی ثبت شده است امکان ویرایش وجود ندارد."); return;
            }
            if (CurrentGSD.Service.CategoryID != (int)Category.خدمات_کلینیکی)
            {
                MessageBox.Show("رکورد انتخاب شده مربوط به خدمات کلینکی نمی باشد");
                return;
            }
           
            if (lstGD == null)
                lstGD = new List<GivenDrug>();
            if (lstGD.Any(x => x.Service == CurrentDrug)) return;
            lstGD.Add(new GivenDrug() {GsdID =CurrentGSD.ID,Service=CurrentDrug, ServiceID = CurrentDrug.ID,Amount=1, Date = MainModule.GetPersianDate(DateTime.Now),Time=DateTime.Now.ToString("HH:mm") });
           
            givenDrugBindingSource.DataSource = lstGD;
            gridControl2.RefreshDataSource();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {if (radioGroup1.EditValue as Boolean? == true)

            {
                var fv = dc.FavoriteServices
                    .Where(x => x.Service.CategoryID == (int)Category.دارو).ToList();

                var lstPD = dc.PharmacyDrugs/*.Where(x => x.PharmacyID == dep.ID)*/.ToList();
                var joined = lstPD.Join(fv, pd => pd.DrugID, favor => favor.ServiceID, (pd, favor) => pd.Service).ToList();

                serviceBindingSource.DataSource = joined.OrderBy(x => x.Name);
            }

            else
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو && x.ParentDrugID==null).ToList();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null) return;
            if (lstGD == null)
                lstGD = new List<GivenDrug>();
            lstGD.Clear();
            lstGD.AddRange(dc.GivenDrugs.Where(x => x.GsdID == current.ID).ToList());
            givenDrugBindingSource.DataSource = lstGD;
            gridControl2.RefreshDataSource();
        }

        private void repoDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var CurrentGSD = givenServiceDBindingSource.Current as GivenServiceD;
            if (CurrentGSD == null)
            {
                MessageBox.Show("ابتدا خدمت را انتخاب کنید");
                return;
            }
            if (CurrentGSD.GivenDrugs.Count() > 0)
            {
                MessageBox.Show("خدمات دارویی ثبت شده است امکان ویرایش وجود ندارد."); return;
            }
            if (dc.GivenDrugs.Where(x => x.GsdID == CurrentGSD.ID).ToList().Count() > 0)
            {
                MessageBox.Show("خدمات دارویی ثبت شده است امکان ویرایش وجود ندارد."); return;
            }
            var objInsert = dc.GetChangeSet().Inserts.FirstOrDefault(x => x == (givenDrugBindingSource.Current as GivenDrug));
            if (objInsert!=null)
            {  ChangeSet changes = dc.GetChangeSet();

                    dc.GetTable(objInsert.GetType()).DeleteOnSubmit(objInsert);
                }
               
            lstGD.Remove(givenDrugBindingSource.Current as GivenDrug);
            givenDrugBindingSource.DataSource = lstGD;
            gridControl2.RefreshDataSource();
        }
    }
}