using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Transport.Data;

namespace Transport.Dialogs
{
    public partial class dlgCarDetails : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public bool IsEdit { get; set; }
        public tblMngFuelCar Transport { get; set; }
        public Data.tblMngCivilCar b { get; set; }
        public dlgCarDetails()
        {
            InitializeComponent();
        }

        private void dlgCarDetails_Load(object sender, EventArgs e)
        {
            tblMngtransportPersonelBindingSource.DataSource = dc.tblMngtransportPersonels.ToList();

            GetData();
        }

        private void GetData()
        {
          
            var q = from p in dc.tblMngCarInsurances
                    where (p.IDCar == b.ID_Car)
                    select p;
            tblMngCarInsuranceBindingSource.DataSource = q;

            var a = from c in dc.tblMngFactorRepairs
                    where (c.IDCar == b.ID_Car)
                    select c;
            tblMngFactorRepairBindingSource.DataSource = a;

            var d = from e in dc.tblMngFuelCars
                    where (e.IDCar == b.ID_Car)
                    select e;
            tblMngFuelCarBindingSource.DataSource = d;

            var f = from g in dc.tblMngCarDrivers
                    where (g.IDCar == b.ID_Car)
                    select g;
            tblMngCarDriverBindingSource.DataSource = f;

         }
        private void btnOK_Click(object sender, EventArgs e)
        {
            
                    tblMngFuelCar u = new tblMngFuelCar();

                    u.Date_Fuel = txtDate.Text;
                    u.Description = txtDes.Text;
                    u.driverID = Int32.Parse(lkpdriver.EditValue.ToString());
                    u.Kilometer_No = Int32.Parse(txtKM.Text);
                    u.Time_fuel = txtClock.Text;
                    u.IDCar = b.ID_Car;                             

                    dc.tblMngFuelCars.InsertOnSubmit(u);
                    dc.SubmitChanges();
           

                    MessageBox.Show("اطلاعات ثبت گرديد");
 GetData();
            txtDate.Text = " ";
            txtDes.Text = " ";
            lkpdriver.EditValue = " ";
            txtKM.Text = " ";
            txtClock.Text = " ";

                
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
                    tblMngCarInsurance u = new tblMngCarInsurance();

                    u.InsurNO =txtInsNO.Text;
                    u.Date_Insurance = txtInsDate.Text;
                  
                    u.Kind_INsurance = txtInsType.Text;
                    u.IDCar = b.ID_Car;
                    
                
                    dc.tblMngCarInsurances.InsertOnSubmit(u);
                    dc.SubmitChanges();

                    MessageBox.Show("اطلاعات ثبت گرديد");
                 
                    GetData();
            txtInsDate.Text = " ";
            txtInsNO.Text = " " ;
            txtInsType.Text = " ";
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tblMngCarDriver u = new tblMngCarDriver();

            u.Date_Delivery = txtDatee.Text;
            u.Description = txtDes.Text;
            u.Driver_ID = Int32.Parse(lkpDriverr.EditValue.ToString());
            u.IDCar = b.ID_Car;
            

            dc.tblMngCarDrivers.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtDes.Text = " ";
            txtDatee.Text = " ";
            lkpDriverr.Text = " ";


            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            tblMngFactorRepair u = new tblMngFactorRepair();

            u.IDDriver = Int32.Parse(lkpDriver2.EditValue.ToString());
            u.Addres = txtaddress.Text;
            u.Date_Failure = txtRepProb.Text;
            u.Date_Repairer = txtRepairDate.Text;
            u.Description = txtDesssss.Text;
            u.failureOrProblem = txtProblem.Text;
            u.Phone = txtTele.Text;
            u.Price = Int32.Parse(txtPrice.Text);
            u.FactorID = Int32.Parse(txtFacNO.Text);
            u.Repairman = txtRepairer.Text;
            u.ServiceOrDevice = txtDevice.Text;
            u.IDCar = b.ID_Car;

            dc.tblMngFactorRepairs.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtaddress.Text = " ";
            txtRepProb.Text = " ";
            txtRepairDate.Text = " ";
            txtDesssss.Text = " ";
            txtProblem.Text = " ";
            txtTele.Text = " ";
            txtPrice.Text = " ";
            txtFacNO.Text = " ";
            txtRepairer.Text = " ";
            txtDevice.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }
    }
    }
