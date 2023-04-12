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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class dlgReference : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public GivenServiceM gsm = new GivenServiceM();
        public Department Dep { get; set; }
        public Reference refrence { get; set; }
        public bool Hospital { get; set; }
        public Person RefPerson { get; set; }
        public dlgReference()
        {
            InitializeComponent();
        }

        private void dlgReference_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.Department1.Name == "بیمارستان" && x.TypeID == 10).ToList();
            var today = MainModule.GetPersianDate(DateTime.Now);
            //referenceBindingSource.DataSource = dc.References.Where(x => x.Confirm != true && x.StartDateLicense.CompareTo(today) <= 0 && x.EndDateLicense.CompareTo(today) >= 0 &&  x.Department1.Parent == MainModule.InstallLocation.ID).ToList();
            //if (Hospital == false)
            //{
            //    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    referenceBindingSource.DataSource = dc.References.Where(x => x.Confirm != true && x.StartDateLicense.CompareTo(today) <= 0 && x.EndDateLicense.CompareTo(today) >= 0 && x.Department1.Parent == MainModule.InstallLocation.ID).ToList();
            //}
            //else
            //{
            Getdata();
            //}
        }
        private void Getdata()
        {
            var dep = lookUpEdit1.EditValue as Department;
            if (dep == null)
                return;
            var today = MainModule.GetPersianDate(DateTime.Now);
            referenceBindingSource.DataSource = dc.References.Where(x => x.Confirm != true && x.StartDateLicense.CompareTo(today) <= 0 && x.EndDateLicense.CompareTo(today) >= 0 && x.DepartmentID == dep.ID).ToList();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            var cur = referenceBindingSource.Current as Reference;
            if (cur == null)
                return;
            gsm = cur.GivenServiceM;
            Dep = cur.Department1;
            RefPerson = cur.GivenServiceM.Person;
            refrence = cur;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            var cur = referenceBindingSource.Current as Reference;
            if (cur == null)
                return;
            gsm = cur.GivenServiceM;
            RefPerson = cur.GivenServiceM.Person;
            Dep = cur.Department1;
            refrence = cur;
            DialogResult = DialogResult.OK;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Getdata();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                var today = MainModule.GetPersianDate(DateTime.Now);

                layoutControlItem2.Enabled = false;
                referenceBindingSource.DataSource = dc.References.Where(x => x.Confirm != true && x.StartDateLicense.CompareTo(today) <= 0 && x.EndDateLicense.CompareTo(today) >= 0 && x.Department1.Parent == MainModule.InstallLocation.ID).ToList();
            }
            else
            {
                layoutControlItem2.Enabled = true;

                Getdata();
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }
    }
}