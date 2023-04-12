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
    public partial class frmCPR : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<Spu_CPRResult> lst = new List<Spu_CPRResult>();
        public frmCPR()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmCPR_Load(object sender, EventArgs e)
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

            lst = dc.Spu_CPR(temp, temp2).ToList();
            spuCPRResultBindingSource.DataSource = lst;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spuCPRResultBindingSource.Current as Spu_CPRResult;
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
                        u.Succeeded,
                        u.ID,
                        u.Title,
                        u.BirthDate,
                        u.Sex,
                        u.Date,
                        u.Typeofdisease,
                        //Service = u.Service == null ? "" :
                       


                    };
            stiReport1.Dictionary.Variables.Add("fromdate", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("todate", textEdit2.Text);
            //stiReport1.Dictionary.Variables.Add("countq", q.Count());
            stiReport1.RegData("CPR", q.ToList());

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
         // stiReport1.Design();
        }
    }
}