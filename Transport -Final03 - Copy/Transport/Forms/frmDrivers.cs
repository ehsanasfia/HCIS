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

namespace Transport.Forms
{

    public partial class frmDrivers : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public bool IsEdit { get; set; }
        public tblMngtransportPersonel Transport { get; set; }
        public frmDrivers()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            tblMngtransportPersonelBindingSource.DataSource = dc.tblMngtransportPersonels.ToList();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEdit == true)
            {
                Transport.Description = txtDes.Text;
                Transport.Lname = txtLname.Text;
                Transport.Name = txtName.Text;
                Transport.CarType = cmbHireType.Text;
                Transport.StiNum = txtNo.Text;
                Transport.WorkPlace = txtPlace.Text;
                Transport.WorkTime = txtTime.Text;
                Transport.Date_Hired = txtHireDate.Text;
                Transport.Type = txtCarType.Text;


                dc.SubmitChanges();
                MessageBox.Show("ويرايش انجام شد");
                DialogResult = DialogResult.OK;

            }
            else
            {
                try
                {
                    tblMngtransportPersonel u = new tblMngtransportPersonel();

                    u.Description = txtDes.Text;
                    u.Lname = txtLname.Text;
                    u.Name = txtName.Text;
                    u.CarType = txtCarType.Text;
                    u.StiNum = txtNo.Text;
                    u.WorkPlace = txtPlace.Text;
                    u.WorkTime = txtTime.Text;
                    u.Date_Hired = txtHireDate.Text;
                    u.Type = cmbHireType.Text;


                    dc.tblMngtransportPersonels.InsertOnSubmit(u);
                    dc.SubmitChanges();

                    GetData();

                    txtNo.Text = " ";
                    cmbHireType.Text = " ";
                    txtPlace.Text = " ";
                    txtLname.Text = " ";
                    txtDes.Text = " ";
                    txtName.Text = " ";
                    txtTime.Text = " ";
                    txtCarType.Text = " ";
                    txtHireDate.Text = " ";


                    MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");



                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
          

        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            GetData();
         
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
           }
    
  
