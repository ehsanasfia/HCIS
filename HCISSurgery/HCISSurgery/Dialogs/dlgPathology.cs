using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgPathology : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        GivenServiceM CheckUp;
        List<GivenServiceD> New = new List<GivenServiceD>();
        List<GivenServiceD> all = new List<GivenServiceD>();
        List<GivenServiceD> isInDb = new List<GivenServiceD>();
        List<GivenServiceD> shouldDelete = new List<GivenServiceD>();
        List<Service> lstSRV = new List<Service>();
      
        public dlgPathology()
        {
            InitializeComponent();
        }

        private void dlgPathology_Load(object sender, EventArgs e)
        {
            CheckUp = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);

            var gsmPath = CheckUp.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == (int)Category.پاتولوژی);
            if (gsmPath != null)
            {
                all.AddRange(gsmPath.GivenServiceDs.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.پاتولوژی));
            }
            isInDb.AddRange(all);
            GSDPathologyBindingSource.DataSource = all;
            lstSRV = dc.Services.Where(x => x.CategoryID == (int)Category.پاتولوژی).ToList();
            ServicePathologyBindingSource.DataSource = lstSRV;
        }

        private void add()
        {
            var current = ServicePathologyBindingSource.Current as Service;
            if (current == null)
                return;

            if (all.Any(x => x.ServiceID == current.ID))
            {
                MessageBox.Show("این خدمت را قبلا انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            GivenServiceD gsd = isInDb.FirstOrDefault(x => x.ServiceID == current.ID);
            if (gsd == null)
            {
                gsd = new GivenServiceD()
                {
                    Service = current,
                };
                New.Add(gsd);
            }
            all.Add(gsd);
            shouldDelete.RemoveAll(x => x.ServiceID == gsd.ServiceID);
            gridControl2.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (all == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                try
                {
                    var gsmPath = CheckUp.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == (int)Category.پاتولوژی);
                    if(gsmPath == null)
                    {
                        gsmPath = new GivenServiceM()
                        {
                            GivenServiceM1 = CheckUp,
                            Person = CheckUp.Person,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            InsuranceID = CheckUp.InsuranceID,
                            RequestStaffID = CheckUp.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            Dossier = CheckUp.Dossier,
                            Comment = memDescription.Text,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.پاتولوژی,
                        };
                    }

                    foreach (var gsd in all)
                    {

                        gsd.GivenServiceM = gsmPath;

                        gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                        gsd.Time = DateTime.Now.ToString("HH:mm");
                        gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        
                        var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                        }
                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        }
                    }

                    gsmPath.PaymentPrice = gsmPath.GivenServiceDs.Sum(x => x.PatientShare);
                    if (gsmPath.PaymentPrice == 0)
                    {
                        gsmPath.Payed = true;
                        gsmPath.PayedPrice = 0;
                    }

                    dc.GivenServiceDs.DeleteAllOnSubmit(shouldDelete);
                    dc.GivenServiceDs.InsertAllOnSubmit(New);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            
            DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            add();
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fs = gridView2.GetFocusedRow() as GivenServiceD;
            if (fs == null)
                return;
            New.RemoveAll(x => x.ServiceID == fs.ServiceID);
            if (isInDb.Any(x => x.ServiceID == fs.ServiceID))
                shouldDelete.Add(fs);
            gridView2.DeleteSelectedRows();
        }
    }
}