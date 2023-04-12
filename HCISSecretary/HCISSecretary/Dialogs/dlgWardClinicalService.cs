using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgWardClinicalService : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        public dlgWardClinicalService()
        {
            InitializeComponent();
        }

        private void dlgWardClinicalService_Load(object sender, EventArgs e)
        {
            textEdit1.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            //var testvarzesh = Guid.Parse("50c4922f-1998-4d66-94da-7d4ed5161bfe");
            //var TestRieh = Guid.Parse("4a9778e3-6054-4232-a512-fe77aa178253");
            //var navarmaghz = Guid.Parse("28b37f8f-2fb2-4908-a809-fe409f31f11c");
            //var binayisanji = Guid.Parse("d34b0fdc-0557-47d6-b314-20fb8959027e");
            //var ERCP = Guid.Parse("8bf396cb-b882-4a44-9842-fbfcaa82ba82");
            //var kolonbayobsi = Guid.Parse("30e597c8-eb01-413b-b1fb-0a7da7ff1b59");
            //var kolon = Guid.Parse("94dd57ce-8c0b-4785-ac28-a5f01965adda");
            //serviceBindingSource.DataSource = dc.Services.Where(x => x.ID == testvarzesh ||
            //x.ID == TestRieh ||
            //x.ID == navarmaghz ||
            //x.ID == ERCP ||
            //x.ID == kolon ||
            //x.ID == kolonbayobsi ||
            //x.SalamatBookletCode =="400615" ||
            //x.SalamatBookletCode == "901255" ||
            //x.SalamatBookletCode == "901270" ||
            //x.SalamatBookletCode == "901265" ||
            //x.SalamatBookletCode == "901260" ||
            //x.SalamatBookletCode == "900771" || 
            //x.SalamatBookletCode == "400615" ||
            //x.SalamatBookletCode == "900771" ||
            //x.SalamatBookletCode == "900770" || 
            //x.SalamatBookletCode == "900785");

            serviceBindingSource.DataSource = dc.Services.Where(x => (x.SalamatBookletCode == "401360" ||
               x.SalamatBookletCode == "400565" ||
               x.SalamatBookletCode == "401380" ||
               x.SalamatBookletCode == "400645" ||
               x.SalamatBookletCode == "400740" ||
               x.SalamatBookletCode == "900785" ||
               x.SalamatBookletCode == "900771" ||
               x.SalamatBookletCode == "900770" ||
               x.SalamatBookletCode == "900800" ||
               x.SalamatBookletCode == "901255" ||
               x.SalamatBookletCode == "901260" ||
               x.SalamatBookletCode == "901265" ||
               x.SalamatBookletCode == "901270" ||
               x.SalamatBookletCode == "901220" ||
               x.SalamatBookletCode == "900985" ||
               x.SalamatBookletCode == "900475" ||
               x.SalamatBookletCode == "901640" ||
               x.SalamatBookletCode == "901635") && x.ServiceCategory.ID == 2
               );
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var date = textEdit1.Text;
            var srv = lookUpEdit1.EditValue as Service;
            if (srv == null)
                return;

            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.GivenServiceM1 != null && x.GivenServiceM.GivenServiceM1.ServiceCategoryID == (int)Classes.Category.خدمات_انجام_شده_در_بخش_بستری && x.ServiceID == srv.ID && x.Date.CompareTo(date) == 0).ToList();
            gridControl1.RefreshDataSource();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
            {
                MessageBox.Show("لطفا یک نفر را انتخاب کنید");
                return;
            }
            GSD = current;
            DialogResult = DialogResult.OK;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}