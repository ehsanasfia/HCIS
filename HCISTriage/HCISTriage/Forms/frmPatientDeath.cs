using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;
namespace HCISTriage.Forms
{
    public partial class frmPatientDeath : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<Spu_PatientDeathResult> lst = new List<Spu_PatientDeathResult>();
        public frmPatientDeath()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmPatientDeath_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            GetData();



        }

        private void GetData()
        {



            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.Spu_PatientDeath(temp, temp2).ToList();
            spuPatientDeathResultBindingSource.DataSource = lst;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spuPatientDeathResultBindingSource.Current as Spu_PatientDeathResult;
            if (current == null)
            {
                return;
            }

            var q = from u in lst
                    select new
                    {
                        u.NationalCode,
                        u.PersonalCode,
                        u.FirstName,
                        u.LastName,
                        // u.ID,
                        u.Title,
                        u.BirthDate,
                        u.Date,
                        u.Typeofdisease,




                    };
            stiReport1.Dictionary.Variables.Add("fromdate", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("todate", textEdit2.Text);
            stiReport1.RegData("PatientDeath", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
           // stiReport1.Design();
        }
    }
}