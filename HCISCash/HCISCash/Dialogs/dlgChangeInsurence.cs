using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgChangeInsurence : DevExpress.XtraEditors.XtraForm
    {   
        public dlgChangeInsurence()
        {
            InitializeComponent();
        }

        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();

        public long dossierID { get; internal set; }

        private void dlgChangeInsurence_Load(object sender, EventArgs e)
        {
            insuranceBindingSource.DataSource = dc.Insurances;
            lookUpEdit1.SelectionStart = 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            try
            {
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossierID);
                var MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                MainGSM.InsuranceID = Int32.Parse(lookUpEdit1.EditValue.ToString());

                var allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                dossier.XInsuranceID = Int32.Parse(lookUpEdit1.EditValue.ToString());
                allGSM.Where(z => z.ServiceCategoryID != 1).ToList().ForEach(x => 
               {

                   x.InsuranceID = Int32.Parse(lookUpEdit1.EditValue.ToString());
                   x.GivenServiceDs.Where(c=>c.ServiceID!=null).ToList().ForEach(c =>
                   {
                       var tarefee = (c.ServiceID != null) ?( dc.Tariffs.Where(z => z.ServiceID == c.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(c.Date??today) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()):null;
                       if (tarefee == null)
                       {
                           c.Payed = true;
                           c.PaymentPrice = 0;
                           c.PatientShare = 0;
                           c.InsuranceShare = 0;
                           c.TotalPrice = 0;
                       }

                       else if (tarefee.PatientShare == 0)
                       {
                           c.Payed = true;
                           c.PaymentPrice = 0;
                           c.PatientShare = 0;
                           c.InsuranceShare = tarefee.OrganizationShare ?? 0;
                           c.TotalPrice = c.InsuranceShare;
                       }
                       else
                       {
                           c.PaymentPrice = tarefee.PatientShare ?? 0;
                           c.PatientShare = tarefee.PatientShare ?? 0;
                           c.InsuranceShare = tarefee.OrganizationShare ?? 0;
                           c.TotalPrice = c.InsuranceShare + c.PatientShare;
                       }

                   });
                   x.PaymentPrice = x.GivenServiceDs.Sum(c => c.PatientShare);
                   x.TotalPrice = x.GivenServiceDs.Sum(c => c.TotalPrice);
                   if (x.PaymentPrice == 0)
                   {
                       x.Payed = true;
                       x.PayedPrice = 0;
                   }

               });

                allGSM.Where(x => x.ServiceCategoryID == 1).ToList().ForEach(x =>
                {
                    x.PayedPrice = 0;
                    x.PaymentPrice = 0;
                    x.TotalPrice = 0;
                    x.GivenServiceDs.Where(z => z.ServiceID != null).ToList().ForEach(c =>
                    {
                        if (!(dc.IsChildLabService(c.GivenServiceMID, c.ID)) ?? false)
                        {
                            var tarefee = (c.ServiceID != null) ? dc.Tariffs.Where(z => z.ServiceID == c.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(c.Date ?? today) <= 0).OrderByDescending(y => y.Date).FirstOrDefault() : null;
                            if (tarefee == null)
                            {
                                c.Payed = true;
                                c.PaymentPrice = 0;
                                c.PatientShare = 0;
                                c.InsuranceShare = 0;
                                c.TotalPrice = 0;
                            }

                            else if (tarefee.PatientShare == 0)
                            {
                                c.Payed = true;
                                c.PaymentPrice = 0;
                                c.PatientShare = 0;
                                c.InsuranceShare = (decimal)c.Amount * (tarefee.OrganizationShare ?? 0);
                                c.TotalPrice = c.InsuranceShare;
                            }
                            else
                            {
                                c.PaymentPrice = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                c.PatientShare = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                c.InsuranceShare = (decimal)c.Amount * tarefee.OrganizationShare ?? 0;
                                c.TotalPrice = c.InsuranceShare + c.PatientShare;
                            }
                            x.PayedPrice += c.PatientShare;
                            x.PaymentPrice += c.PatientShare;
                            x.TotalPrice += c.TotalPrice;
                        }
                        else
                        {
                            x.PayedPrice += 0;
                            x.PaymentPrice += 0;
                            x.TotalPrice += 0;
                        }


                    });
                });

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } }
    }
}