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

namespace HCISSecondWard.Dialogs
{
    public partial class dlgStaffCure : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Dossier Dos;
        List<Person> lst;

        public dlgStaffCure()
        {
            InitializeComponent();
        }

        private void dlgStaffCure_Load(object sender, EventArgs e)
        {
            lst = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            personBindingSource.DataSource = lst;      
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = personBindingSource.Current as Person;
            if (cur == null)
                return;

            Dos.Staff = cur.Staff;
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void dlgStaffCure_Shown(object sender, EventArgs e)
        {
            if (Dos.StaffCure != null)
            {
                var stf = lst.FirstOrDefault(x => x.ID == Dos.StaffCure);
                if (stf != null)
                {
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(personBindingSource.IndexOf(stf));
                }
            }
        }
    }
}