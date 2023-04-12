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
using HCISEmergency.Data;

namespace HCISEmergency.Dialogs
{
    public partial class dlgBedDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { set; get; }
        public Bed ObjectBed { get; set; }

        List<Department> lstDep = new List<Department>();

        int? BNum;
        int? RNum;
        public dlgBedDefinition()
        {
            InitializeComponent();
        }

        private void dlgBedDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectBed == null)
            {
                ObjectBed = new Bed();
            }

            else
            {
                BNum = ObjectBed.BedNumber;
                RNum = ObjectBed.RoomNumber;
            }

            BedBindingSource.DataSource = ObjectBed;
            lstDep = dc.Departments.Where(x => x.TypeID == 11).ToList();
            departmentBindingSource.DataSource = lstDep;
            var dep = lstDep.FirstOrDefault(c => c.ID == Classes.MainModule.MyDepartment.ID);
            ObjectBed.Department = dep;
            ObjectBed.Condition = "خالی";
            ObjectBed.Type = "یک تخت";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjectBed.BedNumber != BNum)
                {
                    if (dc.Beds.Any(x => x.BedNumber == ObjectBed.BedNumber && x.DepartmentID == ObjectBed.DepartmentID))
                    {  
                        MessageBox.Show("این تخت قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                //if (ObjectBed.RoomNumber != RNum)
                //{
                //    if (dc.Beds.Any(x => x.RoomNumber == ObjectBed.RoomNumber))
                //    {
                //        MessageBox.Show("این اتاق قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //        return;
                //    }
                //}

                if (!dc.Beds.Any(x => x.ID == ObjectBed.ID))
                {
                    ObjectBed.DepartmentID = (slkDepartment.EditValue as Department).ID;
                    if (ObjectBed.Bed1 == null)
                    {
                        ObjectBed.Bed1 = 1;
                    }
                    else
                        ObjectBed.Bed1 = ObjectBed.Bed1 + 1;
                    dc.Beds.InsertOnSubmit(ObjectBed);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}