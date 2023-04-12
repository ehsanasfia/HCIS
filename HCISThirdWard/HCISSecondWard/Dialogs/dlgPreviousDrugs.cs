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

namespace HCISSecondWard.Dialogs
{
    public partial class dlgPreviousDrugs : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Dossier Dos { get; set; }
        public List<GivenServiceD> lstgsd = new List<GivenServiceD>();
        public dlgPreviousDrugs()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgPreviousDrugs_Load(object sender, EventArgs e)
        {
         var lst= dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == Dos.ID && x.GivenServiceM.ServiceCategoryID == 4).OrderBy(x => x.GivenServiceM.SerialNumber).ToList();
            lst.ForEach(c => c.EditabelAmount =c.Amount);
            givenServiceDBindingSource.DataSource = lst; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                var Gsd = gridView1.GetRow(item) as GivenServiceD;
               // Gsd.Amount = Gsd.EditabelAmount;
                lstgsd.Add(Gsd);
            }
            DialogResult = DialogResult.OK;
        }
    }
}