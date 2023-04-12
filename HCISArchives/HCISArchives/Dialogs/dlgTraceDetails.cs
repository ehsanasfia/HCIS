using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISArchives.Data;
using HCISArchives.Classes;

namespace HCISArchives.Dialogs
{
    public partial class dlgTraceDetails : DevExpress.XtraEditors.XtraForm
    {
        public List<Dossier> lstDos { get; set; }
        public HCISDataContext dc { get; set; }

        private List<GivenServiceM> lstGSM = new List<GivenServiceM>();

        public dlgTraceDetails()
        {
            InitializeComponent();
        }

        private void dlgTraceDetails_Load(object sender, EventArgs e)
        {
            lstDos.ForEach(x =>
            {
                var list = x.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department != null && c.Department.Name.Trim() != "" && c.Department.Name.Contains("اتاق عمل")).ToList();
                if (list.Any())
                {
                    var list2 = list.Where(h => h.GivenServiceMs.Any(k => k.ServiceCategoryID == (int)Category.خدمات_جراحی || k.ServiceCategoryID == (int)Category.بیهوشی)).ToList();
                    if (list2.Any())
                    {
                        lstGSM.Add(list2.OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                    }
                }
                var g = x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10 && y.Department != null && y.Department.Name.Trim() != "" && !y.Department.Name.Contains("اتاق عمل")).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                if (g != null)
                {
                    lstGSM.Add(g);
                }
            });

            givenServiceMBindingSource.DataSource = lstGSM;
            gridControl1.RefreshDataSource();
        }
    }
}