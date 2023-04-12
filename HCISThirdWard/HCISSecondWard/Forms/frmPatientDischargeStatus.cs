using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class frmPatientDischargeStatus : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<Spu_PatientDischargeStatusResult> lst = new List<Spu_PatientDischargeStatusResult>();

        public frmPatientDischargeStatus()
        {
            InitializeComponent();
        }

        private void frmPatientDischargeStatus_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 33).ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var def = lkpStatus.EditValue as Definition;
            if (def == null)
            {
                MessageBox.Show("لطفا وضعیت بیمار را مشخص کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var ward = slkWard.EditValue as Department;
            if(ward == null)
            {
                lst = dc.Spu_PatientDischargeStatus(txtFrom.Text, txtTo.Text, def.ID).ToList();
            }
            else
            {
                lst = dc.Spu_PatientDischargeStatus(txtFrom.Text, txtTo.Text, def.ID).Where(x => x.Name == ward.Name).ToList();
            }
            
            stiReport1.RegData("MyData", lst);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            //stiReport1.Design();
            stiViewerControl1.Report = stiReport1.CompiledReport;
            stiViewerControl1.Report.Render();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}