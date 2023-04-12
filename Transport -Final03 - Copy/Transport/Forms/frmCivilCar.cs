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
using Transport.Data;

namespace Transport.Forms
{
    public partial class frmCivilCar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();       
        public bool IsEdit { get; set; }
        public tblMngCivilCar Transport { get; set; }
        public frmCivilCar()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void GetData()
        {
            tblMngCivilCarBindingSource.DataSource = dc.tblMngCivilCars.ToList();
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IsEdit == true)
            {
                Transport.Kind_Car = cmbcartype.Text;
                Transport.Model = txtcarmodel.Text;
                Transport.Captives_No = txtCityNO.Text;
                Transport.Car_No = txtcarno.Text;
                Transport.Chassis_No = txtshasi.Text;
                Transport.Color = txtcalour.Text;
                Transport.Date_DeliveryDepartment = txtHdate.Text;
                Transport.Date_DeliveryDriver = txtdliverDate.Text;
                Transport.description = txtdes.Text;
                Transport.Engine_No = txtnginno.Text;

                dc.SubmitChanges();
                MessageBox.Show("ويرايش انجام شد");
                DialogResult = DialogResult.OK;

            }
            else
            {
                try
                {
                    tblMngCivilCar u = new tblMngCivilCar();

                    u.Kind_Car = cmbcartype.Text;
                    u.Model = txtcarmodel.Text;
                    u.Captives_No = txtCityNO.Text;
                    u.Car_No = txtcarno.Text;
                    u.Chassis_No = txtshasi.Text;
                    u.Color = txtcalour.Text;
                    u.Date_DeliveryDepartment = txtHdate.Text;
                    u.Date_DeliveryDriver = txtdliverDate.Text;
                    u.description = txtdes.Text;
                    u.Engine_No = txtnginno.Text;
                    u.CreationUserID = MainModule.UserID.ToString();
                    u.CreationDate = MainModule.GetPersianDate(DateTime.Now);

                    dc.tblMngCivilCars.InsertOnSubmit(u);
                    dc.SubmitChanges();

                    GetData();

                    txtcalour.Text = " ";
                    txtcarmodel.Text = " ";
                    txtcarno.Text = " ";
                    txtCityNO.Text = " ";
                    txtdes.Text = " ";
                    txtdliverDate.Text = " ";
                    txtHdate.Text = " ";
                    txtnginno.Text = " ";
                    txtshasi.Text = " ";

                    MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }
        private void frmCivilCar_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = tblMngCivilCarBindingSource.Current as Data.tblMngCivilCar;
            if (current == null)
                return;
            var a = new Dialogs.dlgCarDetails();
            a.b = current;
            a.ShowDialog();
        }
    }
}