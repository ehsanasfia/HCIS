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
using HCISPhysiotherapy.Data;
using HCISPhysiotherapy.Dialogs;

namespace HCISPhysiotherapy.Forms
{
    public partial class frmPhysiotherapist : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        GivenServiceM ObjectGSM;
        public frmPhysiotherapist()
        {
            InitializeComponent();
        }

        private void frmPhysiotherapist_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;
            personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست" && x.Staff.Hide != true).OrderBy(x => x.LastName).ToList();
            if (personsBindingSource.Count > 0)
            {
                lkpPHT.EditValue = ((List<Person>)personsBindingSource.DataSource).FirstOrDefault().Staff;
            }
            ObjectGSM = new GivenServiceM();
        }

        private void lkpPHT_EditValueChanged(object sender, EventArgs e)
        {
            var PHT = lkpPHT.EditValue as Staff;

            if (PHT == null)
            {
                return;
            }

            givenServiceMsBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.FunctorID == PHT.ID && x.TurningDate == txtDate.Text && x.ParentID != null && (x.Admitted == true && !x.GivenServiceMs.Any()) && x.Payed == true).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                return;
            }
            var dlg = new dlgPhysiotherapist() { dc = dc , GSM = cur };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                gridControl1.RefreshDataSource();
            }
            else
            {
                var stfID = (lkpPHT.EditValue as Staff).ID;
                dc.Dispose();
                dc = new HCISClassesDataContext();
                personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست" && x.Staff.Hide != true).ToList();
                //lkpPHT.EditValue = ((IEnumerable<Person>)personsBindingSource.DataSource).FirstOrDefault(x => x.ID == stfID);
                lkpPHT.EditValue = dc.Staffs.FirstOrDefault(x => x.ID == stfID);
                lkpPHT_EditValueChanged(null, null);
            }
        }

        private void btnWork_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                MessageBox.Show("لطفا یک مراجعه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgPhysiotherapist() { dc = dc, GSM = cur };
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                gridControl1.RefreshDataSource();
            }
            else
            {
                var stfID = (lkpPHT.EditValue as Staff).ID;
                dc.Dispose();
                dc = new HCISClassesDataContext();
                personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست" && x.Staff.Hide != true).ToList();
                //lkpPHT.EditValue = ((IEnumerable<Person>)personsBindingSource.DataSource).FirstOrDefault(x => x.ID == stfID);
                lkpPHT.EditValue = dc.Staffs.FirstOrDefault(x => x.ID == stfID);
                lkpPHT_EditValueChanged(null, null);
            }
        }
    }
}