using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISMedicalDoc.Data;
using HCISMedicalDoc.Classes;
namespace HCISMedicalDoc.Dialogs
{
    public partial class TechnicalContract : DevExpress.XtraBars.TabForm
    {
        public OccupationalMedicineOilDataContexDataContext dc { get; set; }
        public DefinitionContract C { get; set; }
        public bool isEdit { get; set; }

        public TechnicalContract()
        {
            InitializeComponent();
        }

        private void TechnicalContract_Load(object sender, EventArgs e)
        {
            OccupationalMedicineOilDataContexDataContext lp = new OccupationalMedicineOilDataContexDataContext();
            technicalContractBindingSource.DataSource = lp.TechnicalContractMs.Where(x => x.ContractID == C.ID).ToList();
            if (isEdit == true)
            {
                //txtmoshakhasatmasoolfani.Text = C.TypeContract;

                //txtShift.Text = C.NumberAddendum;
                //txtshomaregharardad.Text = C.ContractNumber;
                //txttarikhshoro.Text = C.Startdate;
                //txtnoetavafogh.Text = C.Agreementtype;
                //txttarikhanjam.Text = C.Enddate;
                //txttedadjamiyattahteposhesh.Text = C.PopulationAmount;
                //txtasnadghabelghabol.Text = C.Acceptabledocuments;
                //txtbenamayandegi.Text = C.Representing;
                //txtnoejamiyat.Text = C.TypeOfPopulation;

                //C.Description = txttozihat.Text;



            }
            else
            {
                //txtDoDate.Text = MainModule.GetPersianDate(DateTime.Now);

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TechnicalContractM u = new TechnicalContractM();
            u.ContractID = C.ID;
            u.Fname = txtName.Text;
            u.Lname = txtLastName.Text;
            u.Tel = txtTel.Text;
            u.Shift = txtShift.Text;
            u.time = txtsaathozor.Text;
            u.Totime = txtta.Text;
            u.dateresponsibility = txtaztarikhmasoliyat.Text;
            u.dateresponsibilityTo = txttatarikh.Text;
            ////u.Clause = mmdMohatavyband.Text;
            dc.TechnicalContractMs.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            OccupationalMedicineOilDataContexDataContext lp = new OccupationalMedicineOilDataContexDataContext();
            technicalContractBindingSource.DataSource = lp.TechnicalContractMs.Where(x => x.ContractID == C.ID).ToList();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtName.Text = "";
             txtLastName.Text = "";
            txtTel.Text = "";
            txtShift.Text = "";
            txtsaathozor.Text = "";
            txtta.Text = "";
            txtaztarikhmasoliyat.Text = "";
            txttatarikh.Text = "";
        }
    }
}