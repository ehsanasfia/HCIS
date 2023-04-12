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
using HCISPatientCase.Data;

namespace HCISPatientCase.Forms
{
    public partial class frmPatient : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public List<PatientCaseResult> Pcase = new List<PatientCaseResult>();
        public frmPatient()
        {
            InitializeComponent();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            colDate.Group();
            //grdMaster.DataSource = Pcase;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cur = dc.PatientCase(txtNationalCode.Text).FirstOrDefault();
            staticFname.Caption = cur.Pfirstname;
            staticLname.Caption = cur.PlastName;
            staticCode.Caption = cur.NationalCode;
            patientCaseResultBindingSource.DataSource = (dc.PatientCase(txtNationalCode.Text));
            grdMaster.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void patientCaseResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = patientCaseResultBindingSource.Current as PatientCaseResult;
            //if (current.Category != "ویزیت")
            //{
            //    gridColumn2.Visible = false;
            //}
            //if(current.Category == "ویزیت")
            //{
            //    gridColumn2.Visible = true;
            //}
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                colCategory.UnGroup();
                gridColumn1.UnGroup();
                colDate.Group();

            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                colCategory.UnGroup();
                colDate.UnGroup();
                gridColumn1.Group();
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                colDate.UnGroup();
                gridColumn1.UnGroup();
                colCategory.UnGroup();

            }
            //else if (radioGroup1.SelectedIndex == 3)
            //{
            //    colDate.UnGroup();
            //    gridColumn1.UnGroup();
            //    colCategory.Group();
            //}
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdDetail.ExportToPdf("D:Doc1.pdf");
            string filename = "D:Doc1.pdf";
            System.Diagnostics.Process.Start(filename);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = patientCaseResultBindingSource.Current as PatientCaseResult;
            patientCaseResultBindingSource1.DataSource = (dc.PatientCase(txtNationalCode.Text)).Where(x => x.Date == current.Date);
            colCategory1.Group();
            grdDetail.DataSource = patientCaseResultBindingSource1;
            grdDetail.RefreshDataSource();
        }
    }
}