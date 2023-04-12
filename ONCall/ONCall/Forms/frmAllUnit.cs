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
using ONCall.Data;

namespace ONCall.Forms
{
   
    public partial class frmAllUnit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OncallDataClassesDataContext dc = new OncallDataClassesDataContext();
        public frmAllUnit()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            var q = from p in dc.vwONCalls
                    where (p.Date.CompareTo(txtDate1.Text) >= 0 && p.Date.CompareTo(txtDate2.Text) <= 0)
                    select p;
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmAllUnit_Load(object sender, EventArgs e)
        {
            //var qq = from pp in dc.Specialities
            //         select pp;
            //specialityBindingSource.DataSource = qq;

            txtDate1.Text = MainModule.GetPersianDate(DateTime.Now);
            txtDate2.Text = MainModule.GetPersianDate(DateTime.Now);

            var q = from p in dc.vwONCalls
                    where (p.Date.CompareTo(txtDate1.Text) >= 0 && p.Date.CompareTo(txtDate2.Text) <= 0)
                    select p;
            vwONCallBindingSource.DataSource = q;
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            var q = from p in dc.vwONCalls
                    where (p.Date.CompareTo(txtDate1.Text)>=0 && p.Date.CompareTo(txtDate2.Text)<=0)//p.Date =< txtDate1.Text//&& p.Date <= txtDate2.Text
                    select p;
            vwONCallBindingSource.DataSource = q;
        }
    }
}