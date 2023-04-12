using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;
using HCISContracts.Classes;

namespace HCISContracts.Dialogs
{
    public partial class dlgReportBeRiz : DevExpress.XtraEditors.XtraForm
    {
        public string From { get; set; }
        public string To { get; set; }
        public DoctorFunction DocFunc { get; set; }
        public HCISDataContexDataContext dc { get; set; }
        public dlgReportBeRiz()
        {
            InitializeComponent();
        }

        private void dlgReportBeRiz_Load(object sender, EventArgs e)
        {
            spuReportForDocContractResultBindingSource.DataSource = dc.Spu_ReportForDocContract(DocFunc.ServiceID, DocFunc.StaffID, From, To).ToList();
        }
    }
}