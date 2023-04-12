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
using HCISLab.Dialogs;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmTestAnsweringE : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();

        public frmTestAnsweringE()
        {
            InitializeComponent();
        }

        private void frmTestAnswering_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null,null);
            // With Groups:
            //var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.Service1 == null).OrderBy(x => x.Name).ToList();
            //servicesGroupsBindingSource.DataSource = lst;
            //groupLkp.EditValue = lst.FirstOrDefault();
        }

        private void bbiTestAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GivenLaboratoryServiceD glsd;

            List<VLabtest> mylist = new List<VLabtest>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var dataRow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                mylist.Add((VLabtest)dataRow);

            }
            foreach (var item in mylist)
                if (item.Result != null)
                {
                    glsd = dc.GivenLaboratoryServiceDs.Where(i => i.ID ==item.ID).FirstOrDefault();// = new GivenLaboratoryServiceD();
                    glsd.Result = item.Result;
                    glsd.NormalRange = item.NormalRange;
                    glsd.GivenServiceD.Confirm = true;
                    
                }
            dc.SubmitChanges();
            //vLabtestBindingSource.DataSource = dc.VLabtests.Where(t => string.Compare(t.CreationDate, FromDtp.Date.ToString()) > 0 && string.Compare(t.CreationDate, ToDtp.Date.ToString()) < 0); //>FromDtp.Date.ToString() &&   t.CreationDate  ToDtp.Date.ToString() ) ;            
            btnSearch.PerformClick();

        }

        private void bbiTestGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void groupLkp_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void childGroupLkp_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            vLabtestBindingSource.DataSource = dc.VLabtests.Where(t => string.Compare(t.AdmitDate, FromDtp.Date.ToString()) == 0);// && string.Compare(t.CreationDate, ToDtp.Date.ToString()) < 0); //>FromDtp.Date.ToString() &&   t.CreationDate  ToDtp.Date.ToString() ) ;            

        }
    }
}