using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecretary.Classes;
namespace HCISSecretary.Forms
{
    public partial class frmpatientBastari : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmpatientBastari()
        {
            InitializeComponent();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void frmpatientBastari_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void PatientList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}