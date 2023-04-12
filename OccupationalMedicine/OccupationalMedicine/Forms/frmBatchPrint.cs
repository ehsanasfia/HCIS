using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OccupationalMedicine.Data;
using OccupationalMedicine.Classes;
using OccupationalMedicine.Forms;

namespace OccupationalMedicine.Forms
{
    public partial class frmBatchPrint : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmBatchPrint()
        {
            InitializeComponent();
        }
        
        private void frmBatchPrint_Load(object sender, EventArgs e)
        {
          
           // finalOpinionBindingSource.DataSource = dc.FinalOpinions.ToList();
            contractBindingSource.DataSource = dc.Contracts.ToList();

        }

        private void lkeContractNumber_EditValueChanged(object sender, EventArgs e)
        {
           
          var x= dc.ViewHealthCards.Where(v => v.ContractNumber == lkeContractNumber.EditValue.ToString()).OrderBy(c => c.FileNumber).ToList();
            viewHealthCardBindingSource.DataSource = x;
        }

        private void bbiBatchPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiPrintAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ListCount1 = viewHealthCardBindingSource.Count/2;
            var ListCount2 = viewHealthCardBindingSource.Count - viewHealthCardBindingSource.Count / 2;
            sPCardList1TableAdapter.Fill(mylist1.SPCardList1, lkeContractNumber.EditValue.ToString(), ListCount1);
            sPCardList2TableAdapter.Fill(mylist1.SPCardList2, lkeContractNumber.EditValue.ToString(), ListCount2);

            // stiReport1.Dictionary.Synchronize();
            //stiReport1.Dictionary.BusinessObjects.Clear();//.Clear();
            //  var mylist = dc.ViewHealthCards.Where(v=>v.ContractNumber == lkeContractNumber.EditValue.ToString()).OrderBy(c=>c.FileNumber).ToList();

            ////  mylist3.ge
            //  var mylist1 = from c in mylist.GetRange(0, mylist.Count / 2)
            //                select new
            //                {
            //                    c.ContractNumber,
            //                    c.Name,
            //                    c.LastName,
            //                    c.FileNumber,
            //                    c.Date,
            //                    c.Conditions,
            //                    c.Address,
            //                    c.MedicalAdvice,
            //                    c.PersonalCode,
            //                    c.PersonStatus,
            //                    c.Reasons,
            //                    c.HealthCenter,
            //                    c.University,
            //                    c.DoctorName,
            //                    c.JobTitle,
            //                    c.BirthDate//,
            //                    //c.PersonalPicture
            //                };
            //  var mylist2 = from c in mylist.GetRange( mylist.Count / 2,mylist.Count- mylist.Count / 2)
            //                select new
            //                {
            //                    c.ContractNumber,
            //                    c.Name,
            //                    c.LastName,
            //                    c.FileNumber,
            //                    c.Date,
            //                    c.Conditions,
            //                    c.Address,
            //                    c.MedicalAdvice,
            //                    c.PersonalCode,
            //                    c.PersonStatus,
            //                    c.Reasons,
            //                    c.HealthCenter,
            //                    c.University,
            //                    c.DoctorName,
            //                    c.JobTitle,
            //                    c.BirthDate//,
            //                    //c.PersonalPicture
            //                };
            
            stiReport1.BusinessObjectsStore.Clear();
            stiReport1.Dictionary.Clear();
            stiReport1.RegData(mylist1);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Render();
           
            stiReport1.ShowWithRibbonGUI();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}