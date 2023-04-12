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
    public partial class frmPatientList : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmPatientList()
        {
            InitializeComponent();
        }

        private void frmPatientList_Load(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true && x.Dossier.IOtype ==1
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && (x.Confirm != true || x.WardEdit == true)).OrderByDescending(x => x.AdmitTime).OrderByDescending(x => x.AdmitDate).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var curent = givenServiceMBindingSource.Current as GivenServiceM;
            if (curent == null)
                return;
            MainModule.GSM_Set = curent;
            DialogResult = DialogResult.OK;
            if (MainModule.Action == null)
            {
                var dlg = new Dialogs.dlgSelectAction();
                if (dlg.ShowDialog() != DialogResult.OK) return;
            }

            if (MainModule.Action == "Nurse")
                ((frmMain)MdiParent).barButtonItem2.PerformClick();

            if (MainModule.Action == "Secretary")
                ((frmMain)MdiParent).barButtonItem1.PerformClick();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var curent = givenServiceMBindingSource.Current as GivenServiceM;
            if (curent == null)
                return;
            MainModule.GSM_Set = curent;
            DialogResult = DialogResult.OK;
            if (MainModule.Action == null)
            {
                var dlg = new Dialogs.dlgSelectAction();
                if (dlg.ShowDialog() != DialogResult.OK) return;
            }
            if (MainModule.Action == "Nurse")
                ((frmMain)MdiParent).barButtonItem2.PerformClick();

            if (MainModule.Action == "Secretary")
                ((frmMain)MdiParent).barButtonItem1.PerformClick();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar == (char)Keys.Enter))
            //{
            //    var curent = givenServiceMBindingSource.Current as GivenServiceM;
            //    if (curent == null)
            //        return;
            //    MainModule.GSM_Set = curent;
            //    DialogResult = DialogResult.OK;
            //    if (MainModule.Action == null)
            //    {
            //        var dlg = new Dialogs.dlgSelectAction();
            //        if (dlg.ShowDialog() != DialogResult.OK) return;
            //    }
            //    if (MainModule.Action == "Nurse")
            //        ((frmMain)MdiParent).barButtonItem2.PerformClick();

            //    if (MainModule.Action == "Secretary")
            //        ((frmMain)MdiParent).barButtonItem1.PerformClick();
            //}
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
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