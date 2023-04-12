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
    public partial class frmPath : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public bool IsEdit { get; set; }
        public tblMngDirectionCar Transport { get; set; }
        public frmPath()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            tblMngDirectionCarBindingSource.DataSource = dc.tblMngDirectionCars.ToList();
        }
        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEdit == true)
            {
                Transport.Direction_name = txtName.Text;

                Transport.Kind_Direction = cmbPath.Text;

                dc.SubmitChanges();
                MessageBox.Show("ويرايش انجام شد");
                DialogResult = DialogResult.OK;

            }
            else
            {
                try
                {
                    tblMngDirectionCar u = new tblMngDirectionCar();

                    u.Direction_name = txtName.Text;

                    u.Kind_Direction = cmbPath.Text;


                    dc.tblMngDirectionCars.InsertOnSubmit(u);
                    dc.SubmitChanges();

                    GetData();

                    txtName.Text = " ";
                    cmbPath.Text = " ";



                    MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void frmPath_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
