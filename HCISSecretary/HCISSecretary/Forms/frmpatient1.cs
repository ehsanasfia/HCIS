using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecretary.Data;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Classes;
namespace HCISSecretary.Forms
{
    public partial class frmpatient1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        HCISDataContext dc = new HCISDataContext();
        Classes.MainAction MA;
        public frmpatient1()
        {
            InitializeComponent();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void bbiPrintTicket_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Current = givenServiceMBindingSource1.Current as GivenServiceM;
            Print(Current);
        }
        void Print(GivenServiceM GivenServiceM)
        {
            stiReport1.Compile();
            stiReport1.CompiledReport["FName"] = GivenServiceM.Person.FirstName;
            stiReport1.CompiledReport["LName"] = GivenServiceM.Person.LastName;
            stiReport1.CompiledReport["DrName"] = GivenServiceM.Staff.Person.FirstName + " " + GivenServiceM.Staff.Person.LastName;
            stiReport1.CompiledReport["Number"] = GivenServiceM.DailySN.ToString();
            stiReport1.CompiledReport["Date"] = GivenServiceM.Date.ToString();
            stiReport1.CompiledReport["Time"] = GivenServiceM.AdmitTime.ToString();

            // stiReport1.CompiledReport.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (lookUpDoctor.EditValue == null)
            //    MessageBox.Show("!لطفا دکتر را مشخص کنید");
            //else
            //{
            //    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.SendToDr != true && p.Admitted != true && p.Payments.FirstOrDefault().PayBack != true).ToList();
            //    givenServiceMBindingSource_CurrentChanged(null, null);

            //    givenServiceMBindingSource1.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Admitted == true && p.SendToDr != true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.Payments.FirstOrDefault().PayBack != true).ToList();

            //    givenServiceMBindingSource2.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.SendToDr == true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.Payments.FirstOrDefault().PayBack != true).ToList();
            //}
        }

        private void frmpatients_Load(object sender, EventArgs e)
        {
            var Current = givenServiceMBindingSource1.Current as GivenServiceM;
            var d = Classes.MainModule.GetPersianDate(DateTime.Now).ToString();

            personBindingSource.DataSource = dc.Persons.Where(c => c.Staff.UserType == "دکتر" && c.Staff.Agendas.Any(p=>p.DepartmentID==MainModule.MyDepartment.ID && p.Date==d)).ToList();

           searchLookUpEdit1View.EditingValue = dc.Persons.Where(c => c.Staff.UserType == "دکتر").FirstOrDefault();
            // txtdate.Text = Classes.MainModule.GetPersianDate(DateTime.Now).ToString();
            if (Current == null)
                bbiSendToDr.Enabled = false;
            bbiPrintTicket.Enabled = false;
            bbiRecourse.Enabled = false;
            MA = new Classes.MainAction(dc);
        }

        private void givenServiceMBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            if (givenServiceMBindingSource.Count > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = true;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }
        }
        //private void givenServiceMBindingSource1_DataSourceChanged(object sender, EventArgs e)
        //{
        //    if (givenServiceMBindingSource1.Count > 0)
        //    {
        //        bbiPrintTicket.Enabled = true;
        //        bbiRecourse.Enabled = fals;
        //        bbiSendToDr.Enabled = true;
        //    }
        //    else
        //    {
        //        bbiPrintTicket.Enabled = false;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = false;
        //    }
        //}

        //private void givenServiceMBindingSource2_DataSourceChanged(object sender, EventArgs e)
        //{
        //    if (givenServiceMBindingSource2.Count > 0)
        //    {
        //        bbiPrintTicket.Enabled = true;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = true;
        //    }
        //    else
        //    {
        //        bbiPrintTicket.Enabled = false;
        //        bbiRecourse.Enabled = false;
        //        bbiSendToDr.Enabled = false;
        //    }
        //}

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                var ID = Guid.Parse(View.GetRowCellValue(e.RowHandle, View.Columns[16]).ToString());
                // ServiceCategoryID for paraclinic service is 2
                var list = dc.GivenServiceMs.Where(c => c.ParentID == ID && c.ServiceCategoryID == 2 && c.Payed == true).ToList();
                if (list.Count > 0)
                {
                    e.Appearance.BackColor = Color.Salmon;
                }
            }
            catch
            {

            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Current = givenServiceMBindingSource.Current as GivenServiceM;
            if (Current != null)
            {

                if (Current.Admitted != true)
                {
                    bbiPrintTicket.Enabled = false;
                    bbiRecourse.Enabled = true;
                    bbiSendToDr.Enabled = false;
                }
                else
                {
                    bbiPrintTicket.Enabled = true;
                    bbiSendToDr.Enabled = true;
                    bbiRecourse.Enabled = false;
                }
                if (Current.SendToDr != true)
                {

                }
                else
                {
                    bbiSendToDr.Enabled = false;
                    bbiPrintTicket.Enabled = false;
                }
            }
        }

        //private void givenServiceMBindingSource1_CurrentChanged(object sender, EventArgs e)
        //{
        //    var Current = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (Current != null)
        //    {

        //        if (Current.Admitted != true)
        //        {
        //            bbiPrintTicket.Enabled = false;
        //            bbiRecourse.Enabled = true;
        //            bbiSendToDr.Enabled = false;
        //        }
        //        else
        //        {
        //            bbiPrintTicket.Enabled = true;
        //            bbiSendToDr.Enabled = true;
        //            bbiRecourse.Enabled = false;
        //        }
        //        if (Current.SendToDr != true)
        //        {

        //        }
        //        else
        //        {
        //            bbiSendToDr.Enabled = false;
        //            bbiPrintTicket.Enabled = false;
        //        }
        //    }
        //}


        //private void givenServiceMBindingSource2_CurrentChanged(object sender, EventArgs e)
        //{
        //    var Current = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (Current != null)
        //    {

        //        if (Current.Admitted != true)
        //        {
        //            bbiPrintTicket.Enabled = false;
        //            bbiRecourse.Enabled = true;
        //            bbiSendToDr.Enabled = false;
        //        }
        //        else
        //        {
        //            bbiPrintTicket.Enabled = true;
        //            bbiSendToDr.Enabled = true;
        //            bbiRecourse.Enabled = false;
        //        }
        //        if (Current.SendToDr != true)
        //        {

        //        }
        //        else
        //        {
        //            bbiSendToDr.Enabled = false;
        //            bbiPrintTicket.Enabled = false;
        //        }
        //    }
        //}

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiSendToDr_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = givenServiceMBindingSource1.Current as GivenServiceM;
                if (Current == null)
                {
                    MessageBox.Show("....لطفا ابتدا بیمار را انتخاب کنید");
                }
                else
                {
                    Current.SendToDrTime = DateTime.Now.ToString("HH:mm");
                    Current.SendToDr = true;
                    Current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    Current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    //dc.SubmitChanges();
                    MA.Save();

                  //  givenServiceMBindingSource1.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.Admitted == true && p.SendToDr != true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true).ToList();
                    //givenServiceMBindingSource2.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == txtdate.Text.ToString() && p.SendToDr == true && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void gridControl1_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = true;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;

            }
        }

        private void gridControl2_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource1.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = true;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = true;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }

        }

        private void gridControl3_Enter(object sender, EventArgs e)
        {
            var a = givenServiceMBindingSource2.Count;
            if (a > 0)
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;
            }
            else
            {
                bbiPrintTicket.Enabled = false;
                bbiRecourse.Enabled = false;
                bbiSendToDr.Enabled = false;

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void lookUpDoctor_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpDoctor.EditValue == null)
                MessageBox.Show("!لطفا دکتر را مشخص کنید");
            else
            {
                var d = Classes.MainModule.GetPersianDate(DateTime.Now).ToString();

                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(p => p.Agenda.Date == d && p.RequestStaffID == (lookUpDoctor.EditValue as Person).Staff.ID && p.ServiceCategoryID == 3 && p.Payed == true && p.Confirm != true && p.SendToDr != true && p.Admitted != true && p.Payments.FirstOrDefault().PayBack != true).ToList();
               
                }

        }
    }
}