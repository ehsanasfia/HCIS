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
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgDosLavazemHistory1 : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Dossier dos { get; set; }

        public dlgDosLavazemHistory1()
        {
            InitializeComponent();
        }

        private void dlgDosLavazemHistory_Load(object sender, EventArgs e)
        {
            dc = new DataClasses1DataContext();
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text.Length != 10 || txtTo.Text.Length != 10) return;
            viewConsumerBindingSource.DataSource = dc.ViewConsumers.Where(c => c.VisitDate.CompareTo(txtFrom.Text) >= 0 && c.VisitDate.CompareTo(txtTo.Text) <= 0 && c.MedicalCenter == MainModule.InstallLocation.Name && c.DepartmentName == MainModule.MyDepartment.Name).ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printableComponentLink1.ClearDocument();
            var F = txtFrom.Text;
            var t = txtTo.Text;
            ////   ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی لوازم مصرفی از تاریخ {0} لغایت {1}",F,t);
            //printableComponentLink1.CreateDocument();
            //printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

            var MyData = from c in ((IEnumerable<ViewConsumer>)viewConsumerBindingSource.DataSource).ToList()
                         select new { c.DepartmentName, c.DossierID, c.FirstName, c.LastName, c.FunctorName, c.MedicalCenter, c.FullName, c.Name, c.VisitDate , c.Amount, c.PersonalNo, c.InsuranceName };
            stiReport1.Dictionary.Variables.Add("DateFrom", F);
            stiReport1.Dictionary.Variables.Add("DateTo", t);
            stiReport1.Dictionary.Variables.Add("DateNow", Classes.MainModule.GetPersianDate(DateTime.Now).ToString());
            stiReport1.RegData("MyData", MyData);
            stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}