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
    public partial class frmTahvilgirande : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineOilDataContexDataContext dc { get; set; }
        public DefinitionContract C { get; set; }
        public bool isEdit { get; set; }
        public frmTahvilgirande()
        {
            InitializeComponent();
        }

        private void frmTahvilgirande_Load(object sender, EventArgs e)
        {
            //companyBindingSource.DataSource = dc.Companies.ToList();
            //medicalCenterBindingSource.DataSource = dc.MedicalCenters.ToList();
            if (isEdit == true)
            {
                txtnoegharardad.Text = C.TypeContract;

               txtshomareelhaghiye.Text = C.NumberAddendum;
                txtshomaregharardad.Text = C.ContractNumber;
                txttarikhshoro.Text = C.Startdate;
                txtnoetavafogh.Text = C.Agreementtype;
               txttarikhanjam.Text = C.Enddate;
                txttedadjamiyattahteposhesh.Text = C.PopulationAmount;
                txtasnadghabelghabol.Text = C.Acceptabledocuments;
                txtbenamayandegi.Text = C.Representing;
                txtnoejamiyat.Text = C.TypeOfPopulation;

                C.Description = txttozihat.Text;



            }
            else
            {
                //txtDoDate.Text = MainModule.GetPersianDate(DateTime.Now);

            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                C.TypeContract = txtnoegharardad.Text;

                C.NumberAddendum = txtshomareelhaghiye.Text;
                C.ContractNumber = txtshomaregharardad.Text;
                C.Startdate = txttarikhshoro.Text;
                C.Agreementtype = txtnoetavafogh.Text;
                C.Enddate = txttarikhanjam.Text;
                C.PopulationAmount = txttedadjamiyattahteposhesh.Text;
                C.Acceptabledocuments = txtasnadghabelghabol.Text;
                C.Representing = txtbenamayandegi.Text;
                C.TypeOfPopulation = txtnoejamiyat.Text;

                C.Description = txttozihat.Text;
                C.LastModificationDate = Classes.MainModule.UserFullName;
                C.LastModificator = Classes.MainModule.UserID;
                C.LastModificationTime = DateTime.Now.ToString("HH:mm");
                //C.Number = txtMNumber.Text;
                //C.DateDo = txtDoDate.Text;
                ////  C.IDMedicalCenter = Int32.Parse(lkpMedicalid.EditValue.ToString());
                //C.Company = (lkpcompany.EditValue as Company);
                dc.SubmitChanges();
            }
            if (isEdit == false)
            {
                DefinitionContract u = new DefinitionContract();
                u.TypeContract = txtnoegharardad.Text;

                u.NumberAddendum = txtshomareelhaghiye.Text;
                u.ContractNumber = txtshomaregharardad.Text;
                u.Startdate = txttarikhshoro.Text;
                u.Agreementtype = txtnoetavafogh.Text;
                u.Enddate = txttarikhanjam.Text;
                u.PopulationAmount = txttedadjamiyattahteposhesh.Text;
                u.Acceptabledocuments = txtasnadghabelghabol.Text;
                u.Representing = txtbenamayandegi.Text;
                u.TypeOfPopulation = txtnoejamiyat.Text;

                u.Description = txttozihat.Text;
                u.CreatorUserFullName = Classes.MainModule.UserFullName;
                u.CreatorUserID = Classes.MainModule.UserID;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
           
                dc.DefinitionContracts.InsertOnSubmit(u);
                dc.SubmitChanges();
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }
    }
}