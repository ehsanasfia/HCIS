using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;
namespace HCISContracts.Forms
{
    public partial class frmDoctorPaymentsAndDeductions : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<DoctorPaymentsAndDeduction> lst = new List<DoctorPaymentsAndDeduction>();
        public frmDoctorPaymentsAndDeductions()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDoctorPaymentsAndDeductions_Load(object sender, EventArgs e)
        {
            lst.AddRange(dc.DoctorPaymentsAndDeductions.ToList());
            doctorPaymentsAndDeductionBindingSource.DataSource = lst;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
            {
                if (item.ID == 0)
                {
                    dc.DoctorPaymentsAndDeductions.InsertOnSubmit(item);
                }
            }
            doctorPaymentsAndDeductionBindingSource.EndEdit();
            dc.SubmitChanges();
        }
    }
}