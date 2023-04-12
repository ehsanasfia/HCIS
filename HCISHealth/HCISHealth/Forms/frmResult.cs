using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISHealth.Dialogs;
using HCISHealth.Forms;
using HCISHealth.Data;
using HCISHealth.Classes;
namespace HCISHealth.Forms
{
    public partial class frmResult : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<GivenServiceD> lst = new List<GivenServiceD>();
        List<GivenServiceD> del = new List<GivenServiceD>();
        public frmResult()
        {
            InitializeComponent();
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
     
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtNationalCode.Text.Length == 10)
            {
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(c =>c.Category == "1" &&
              c.GivenServiceM.Person.NationalCode == txtNationalCode.Text)
              .OrderByDescending(c => c.GivenServiceM.CreationDate).ThenByDescending(c => c.GivenServiceM.CreationTime).ToList();
            }
            else
            {
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(c => c.Category == "1" &&
           c.GivenServiceM.Person.PersonalCode == txtNationalCode.Text)
             .OrderByDescending(c => c.GivenServiceM.CreationDate).ThenByDescending(c => c.GivenServiceM.CreationTime).ToList();
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {



            //if (Guid.Parse(temp) == null)
            //{
            //    MessageBox.Show("شخص را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;

            //}
            //if (dc.QAs.Any(c => c.ReferenceFileID == Guid.Parse(temp)))
            //{

            var cu = givenServiceDBindingSource.Current as GivenServiceD;
                qABindingSource.DataSource = dc.QAs.Where(c => c.GivenServiceM.DossierID == cu.GivenServiceM.DossierID)
                    .OrderBy(c => c.CreationDate).ToList();
            //}
        }
    }
}