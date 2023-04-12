using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgTodayPatient : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public GivenServiceM GSM { get; set; }

        //public bool nurse { get; set; }
        //public Guid nursedep { get; set; }

        public dlgTodayPatient()
        {
            InitializeComponent();
        }

        private void dlgTodayPatient_Load(object sender, EventArgs e)
        {
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);

            //if (nurse)
            //{
            //    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Agenda.Date == today && x.Agenda.DepartmentID == nursedep && x.GivenServiceMs.Any(c => c.ServiceCategoryID == (int)Classes.Category.خدمات_کلینیکی));

            //}
            //else
            //{
            //    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Agenda.Date == today && x.Agenda.DepartmentID == Classes.MainModule.MyDepartment.ID && x.GivenServiceMs.Any(c => c.ServiceCategoryID == (int)Classes.Category.خدمات_کلینیکی));

            //}

            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Agenda.Date == today && x.Agenda.DepartmentID == Classes.MainModule.MyDepartment.ID && x.GivenServiceMs.Any(c => c.ServiceCategoryID == (int)Classes.Category.خدمات_کلینیکی)).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            GSM = current;
            DialogResult = DialogResult.OK;
        }
    }
}