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
using HCISContracts.Data;


namespace HCISContracts.Forms
{
    public partial class frmDoctorContract : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmDoctorContract()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            if (barToggleSwitchItem1.Checked == true)
            {
                doctorContractMBindingSource.DataSource = dc.DoctorContractMs.Where(x => x.Rasmi == true).ToList();
                colSalaryBase.Visible = colPositionPercentage.Visible = true;
            }
            else
            {

                doctorContractMBindingSource.DataSource = dc.DoctorContractMs.Where(x => x.Rasmi == false).ToList();
                colSalaryBase.Visible = colPositionPercentage.Visible = false;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //while (true)
            //{
            var a = new Dialogs.dlgDoctorContract();
            a.dc = dc;
            a.IsEdit = false;
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }

            //    else
            //        break;
            //}            
        }

        private void cmbMonth1_EditValueChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmDoctorContract_Load(object sender, EventArgs e)
        {
            GetData();
        }


        private void gridView2_Click(object sender, EventArgs e)
        {
            var cu = doctorContractMBindingSource.Current as DoctorContractM;
            if (cu == null)
            {
                return;
            }
            doctorContractDBindingSource.DataSource = dc.DoctorContractDs.Where(x => x.DoctorContractM.ID == cu.ID).ToList();
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }


        private void barToggleSwitchItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Current = doctorContractMBindingSource.Current as DoctorContractM;
            if (Current == null)
            {
                MessageBox.Show("هیچ قراردادی انتخاب نشده است");
                return;
            }

            if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading)) != DialogResult.Yes)
                return;

            dc.DoctorContractMs.DeleteOnSubmit(Current);
            dc.SubmitChanges();
            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Current = doctorContractMBindingSource.Current as DoctorContractM;
            if (Current == null)
            {
                MessageBox.Show("هیچ قراردادی انتخاب نشده است");
                return;
            }
            var a = new Dialogs.dlgDoctorContract();
            a.dc = dc;
            a.IsEdit = false;
            a.EditingDoctorM = Current;
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }


        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading));
        }

    }
}