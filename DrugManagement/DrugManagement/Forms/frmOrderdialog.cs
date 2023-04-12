using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
using DrugManagement.Dialogs;
namespace DrugManagement.Forms
{
    public partial class frmOrderdialog : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Order> lst = new List<Order>();
        public frmOrderdialog()
        {
            InitializeComponent();
        }

        private void frmOrderdialog_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
          
            lst = dc.Orders.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            orderBindingSource.DataSource = lst;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            lst = dc.Orders.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
            .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            orderBindingSource.DataSource = lst;

        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {

            lst = dc.Orders.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
.OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            orderBindingSource.DataSource = lst;
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        u.Service.Name,
                        u.Service.Shape,
                        u.CreationDate,
                        u.Company.CompanyName,
                        u.Amount
                 


                    };
             stiReport1.Dictionary.Variables.Add("d", txtFromDate.Text);
             stiReport1.Dictionary.Variables.Add("f", txtToDate.Text);
            //stiReport1.Dictionary.Variables.Add("t", textEdit1.Text);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
           // stiReport1.Design();
        }
    }

}