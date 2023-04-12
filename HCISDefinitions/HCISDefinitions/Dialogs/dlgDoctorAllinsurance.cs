using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgDoctorAllinsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public dlgDoctorAllinsurance()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dc.DoctorInsurances.DeleteAllOnSubmit(dc.DoctorInsurances);
            dc.SubmitChanges();
            var stf = dc.Staffs.Where(x => x.UserType == "دکتر" || x.UserType == "ماما").ToList();
            foreach (var item in gridView1.GetSelectedRows())
            {
                var insure = gridView1.GetRow(item) as Insurance;
                foreach (var stfs in stf)
                {
                    var docInsure = new DoctorInsurance()
                    {
                        StaffID = stfs.ID,
                        InsuranceID = insure.ID,
                    };
                    dc.DoctorInsurances.InsertOnSubmit(docInsure);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("تغییرات با موفقیت ثبت شد");
        }

        private void dlgDoctorAllinsurance_Load(object sender, EventArgs e)
        {
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
        }
    }
}