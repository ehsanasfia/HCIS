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
    public partial class dlgEditDoc : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        public dlgEditDoc()
        {
            InitializeComponent();
        }

        private void dlgEditDoc_Load(object sender, EventArgs e)
        {
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var doc = staffBindingSource.Current as Staff;
            if (doc == null)
                return;
            if (GSD.FunctorID != null)
            {
                var gsd = dc.GivenServiceDs.FirstOrDefault(x => x.ID == GSD.ID);
                gsd.FunctorID = doc.ID;
                gsd.LastModificationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                gsd.LastModificator = Classes.MainModule.UserID;
            }
            else
            {

                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == GSD.GivenServiceM.ID);
                if (gsm == null)
                    return;
                gsm.RequestStaffID = doc.ID;
                gsm.LastModificationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                gsm.LastModificator = Classes.MainModule.UserID;
            }
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}