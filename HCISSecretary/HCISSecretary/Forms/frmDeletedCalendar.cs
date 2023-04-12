using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;

namespace HCISSecretary.Forms
{
    public partial class frmDeletedCalendar : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmDeletedCalendar()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDeletedCalendar_Load(object sender, EventArgs e)
        {
            
            specialityBindingSource_CurrentChanged(null, null);
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality == searchLookUpEdit2.EditValue as Speciality);
            specialityBindingSource.DataSource = dc.Specialities;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از بازگردانی اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            else
            {
                var current = agendaBindingSource.Current as Agenda;
                if (current == null)
                    return;
                current.Deleted = false;
                dc.SubmitChanges();
                Getdata();
            }           
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

            var spc = searchLookUpEdit2.EditValue as Speciality;
            if (spc == null)
            {
                staffBindingSource.DataSource = null;
                slkDoctorName.Enabled = false;
                return;
            }
            slkDoctorName.Enabled = true;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.ID == spc.ID);
        }

        private void Getdata()
        {
            agendaBindingSource.DataSource = dc.Agendas.Where(x => x.Staff == (slkDoctorName.EditValue as Staff) && x.Deleted == true).ToList();
        }

        private void slkDoctorName_EditValueChanged(object sender, EventArgs e)
        {
            Getdata();
        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var spc = searchLookUpEdit2.EditValue as Speciality;
            if (spc == null)
            {
                staffBindingSource.DataSource = null;
                slkDoctorName.Enabled = false;
                return;
            }
            slkDoctorName.Enabled = true;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.ID == spc.ID);
        }
    }
}