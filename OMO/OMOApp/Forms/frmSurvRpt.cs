using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OMOApp.Data;

namespace OMOApp.Forms
{
    public partial class frmSurvRpt : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSurvRpt()
        {
            InitializeComponent();
        }
        OMOClassesDataContext dc = new OMOClassesDataContext();
        private void frmSurvRpt_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 4).ToList();
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            vwSurveillanceCompanyBindingSource.DataSource = dc.Vw_SurveillanceCompanies.Where(x =>x.SicknessID==Int32.Parse(lookUpEdit1.EditValue.ToString())) /*x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name).*/.ToList();

        }
    }
}