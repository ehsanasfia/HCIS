using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DrugManagement.Dialogs
{
    public partial class diagPV : DevExpress.XtraEditors.XtraForm
    {
        public diagPV()
        {
            InitializeComponent();
        }
        public string DrugN { get; set; }
        public Guid DrugID { get; set; }
        public string DepartmentName { get; set; }
        public Guid DepartmentID { get; set; }
        Data.HCISDataContexDataContext dc = new Data.HCISDataContexDataContext();
        public bool Exists { get; set; }
        private void diagPV_Load(object sender, EventArgs e)
        {
            labelControl1.Text = dc.Services.SingleOrDefault(c => c.ID == DrugID).Name;
            labelControl2.Text = DepartmentName;
            DepartmentID = dc.Departments.SingleOrDefault(c => c.Name.CompareTo(DepartmentName)==0).ID;
            checkEdit1.EditValue = Exists;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
                if (checkEdit1.Checked == false)
                {
                    var toDelete = dc.PharmacyDrugs.SingleOrDefault(c => c.DrugID == DrugID && c.PharmacyID == DepartmentID);
                    dc.PharmacyDrugs.DeleteOnSubmit(toDelete);
                    dc.SubmitChanges();
                }
                else
                {
                    var d = dc.PharmacyDrugs.Where(c => c.DrugID == DrugID && c.PharmacyID == DepartmentID).Count();
                    if (d == 0)
                    {
                        var pd = new Data.PharmacyDrug()
                        {
                            DrugID = DrugID,
                            PharmacyID = DepartmentID
                        };
                        dc.PharmacyDrugs.InsertOnSubmit(pd);
                        dc.SubmitChanges();
                    }
                }
                DialogResult = DialogResult.OK;
       
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (checkEdit1.Checked == false)
                {
                    var toDelete = dc.PharmacyDrugs.SingleOrDefault(c => c.DrugID == DrugID && c.PharmacyID == DepartmentID);
                    dc.PharmacyDrugs.DeleteOnSubmit(toDelete);
                    dc.SubmitChanges();
                }
                else
                {
                    var d = dc.PharmacyDrugs.Where(c => c.DrugID == DrugID && c.PharmacyID == DepartmentID).Count();
                    if (d == 0)
                    {
                        var pd = new Data.PharmacyDrug()
                        {
                            DrugID = DrugID,
                            PharmacyID = DepartmentID
                        };
                        dc.PharmacyDrugs.InsertOnSubmit(pd);
                        dc.SubmitChanges();
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }
    }
}