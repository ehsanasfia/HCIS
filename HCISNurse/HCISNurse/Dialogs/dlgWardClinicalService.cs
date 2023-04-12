using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgWardClinicalService : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        public dlgWardClinicalService()
        {
            InitializeComponent();
        }

        private void dlgWardClinicalService_Load(object sender, EventArgs e)
        {
            textEdit1.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            var testvarzesh = Guid.Parse("50c4922f-1998-4d66-94da-7d4ed5161bfe");
            var TestRieh = Guid.Parse("4a9778e3-6054-4232-a512-fe77aa178253");
            var navarmaghz = Guid.Parse("28b37f8f-2fb2-4908-a809-fe409f31f11c");
            var binayisanji = Guid.Parse("d34b0fdc-0557-47d6-b314-20fb8959027e");
            var ERCP = Guid.Parse("8bf396cb-b882-4a44-9842-fbfcaa82ba82");
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ID == testvarzesh || x.ID == TestRieh || x.ID == navarmaghz || x.ID == ERCP);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var date = textEdit1.Text;
            var srv = lookUpEdit1.EditValue as Service;
            if (srv == null)
                return;

            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.GivenServiceM1.ServiceCategoryID == 10 && x.ServiceID == srv.ID).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if(current == null)
            {
                MessageBox.Show("لطفا یک نفر را انتخاب کنید");
                return;
            }
            GSD = current;
            DialogResult = DialogResult.OK;
        }
    }
}