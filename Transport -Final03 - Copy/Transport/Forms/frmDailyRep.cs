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
    public partial class frmDailyRep : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public frmDailyRep()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void GetData()
        {
            tblMngDailyRepBindingSource.DataSource = dc.tblMngDailyReps.ToList();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblMngDailyRep u = new tblMngDailyRep();
            
            u.carType = cmbType.Text;
            u.CreationUserID = MainModule.UserID.ToString();
            u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            u.ExitDate = txtDate.Text;
            u.ExitTime = txtEXTime.Text;
            u.ExtraMission = txtOutMission.Text;
            u.IDCar = Int32.Parse(lkpCar.EditValue.ToString());
            u.IDDriver = Int32.Parse(lkpDriver.EditValue.ToString());
            u.IDPath = Int32.Parse(lkpMainPath.EditValue.ToString());
            u.Mission = txtMisionType.Text;
            u.OtherWork = txtOtherPath.Text;
            u.TypeMission = txtMisionType.Text;
            

            dc.tblMngDailyReps.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtDate.Text = " ";
            txtEXTime.Text = " ";
            txtInTime.Text = " ";
            txtMisionType.Text = " ";
            txtOtherPath.Text = " ";
            txtOutMission.Text = " ";
            lkpCar.EditValue = " ";
            lkpDriver.EditValue = " ";
            lkpMainPath.EditValue = " ";
            cmbType.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void frmDailyRep_Load(object sender, EventArgs e)
        {
            tblMngDirectionCarBindingSource.DataSource = dc.tblMngDirectionCars.ToList();
            tblMngtransportPersonelBindingSource.DataSource = dc.tblMngtransportPersonels.ToList();
            tblMngCivilCarBindingSource.DataSource = dc.tblMngCivilCars.ToList();
            GetData();
        }
    }
    }
