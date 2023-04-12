using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgDoctorOrder : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }

        public dlgDoctorOrder()
        {
            InitializeComponent();
        }

        private void dlgDoctorOrder_Load(object sender, EventArgs e)
        {
            if (MainModule.GSM_Set.ParentID != null)
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ParentID);
                if (gsm.Department != null && gsm.Department.Name == "اورژانس")
                {
                    vwDoctorInstractionBindingSource.DataSource =
                        dc.VwDoctorInstractions.Where(x => x.DossierID == gsm.DossierID && x.ServiceCategoryID == 23).OrderByDescending(x => x.Time).OrderByDescending(x => x.Date).ToList();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}