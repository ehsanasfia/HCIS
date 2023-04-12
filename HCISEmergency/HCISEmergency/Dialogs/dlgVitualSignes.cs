using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{
    public partial class dlgVitualSignes : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        GivenServiceD ObjectGSDVS;
        VitalSign ObjectVS;
        public List<GivenServiceD> lstVitalSign { get; set; }
        public GivenServiceM gsm { get; set; }
        public dlgVitualSignes()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var Today = Classes.MainModule.GetPersianDate(DateTime.Now);
                ObjectGSDVS.Date = Today;
                ObjectGSDVS.Time = DateTime.Now.ToString("HH:mm");
                ObjectGSDVS.LastModificationDate = Today;
                ObjectGSDVS.LastModificationTime = DateTime.Now.ToString("HH:mm");
                ObjectGSDVS.ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4");
                ObjectGSDVS.VitalSign = ObjectVS;
                lstVitalSign.Add(ObjectGSDVS);
                givenServiceDBindingSourceVitalSign.DataSource = lstVitalSign;
                gridControl1.RefreshDataSource();
                ObjectGSDVS = new GivenServiceD();
                ObjectVS = new VitalSign();
                VitalSignBindingSource.DataSource = ObjectVS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void dlgVitualSignes_Load(object sender, EventArgs e)
        {
            if (ObjectGSDVS == null)
            {
                ObjectGSDVS = new GivenServiceD();
            }
            if (lstVitalSign == null)
            {
                lstVitalSign = new List<GivenServiceD>();
            }
            if (ObjectVS == null)
            {
                ObjectVS = new VitalSign();
            }
            VitalSignBindingSource.DataSource = ObjectVS;
            VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == gsm.ID && x.Service.Name == "علائم حیاتی").Select(x => x.VitalSign).ToList();
            gridView2.BestFitColumns();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (lstVitalSign.Count > 0)
            {
                lstVitalSign.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = gsm.ID,
                        ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                        gsd.TotalPrice = gsd.InsuranceShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                    dc.SubmitChanges();

                    var vitual = new VitalSign()
                    {
                        ID = gsd.ID,
                        CreatorUserID = MainModule.UserID,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Breathing = x.VitalSign.Breathing,
                        DiastolicBloodPressure = x.VitalSign.DiastolicBloodPressure,
                        NervousSymptoms = x.VitalSign.NervousSymptoms,
                        Pulse = x.VitalSign.Pulse,
                        PupilReflexes = x.VitalSign.PupilReflexes,
                        SystolicBloodPressure = x.VitalSign.SystolicBloodPressure,
                        Temperatures = x.VitalSign.Temperatures,
                        Glucometry = x.VitalSign.Glucometry,
                        SPO2 = x.VitalSign.SPO2,
                        TriageLevelChange = x.VitalSign.TriageLevelChange
                    };
                    dc.VitalSigns.InsertOnSubmit(vitual);
                });

                dc.SubmitChanges();
                VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == gsm.ID && x.Service.Name == "علائم حیاتی").Select(x => x.VitalSign).ToList();
                gridControl2.RefreshDataSource();
                gridView2.RefreshData();
                gridView2.BestFitColumns();
                gridView1.BestFitColumns();
                MessageBox.Show("علائم ذخیره شد");
                lstVitalSign.Clear();
                givenServiceDBindingSourceVitalSign.DataSource = null;
                DialogResult = DialogResult.OK;
            }
        }
    }
}