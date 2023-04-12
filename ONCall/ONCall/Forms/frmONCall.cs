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
using ONCall.Forms;
using ONCall.Dialogs;


namespace ONCall.Forms
{
    public partial class frmONCall : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OncallDataClassesDataContext dc = new OncallDataClassesDataContext();

   
        public frmONCall()
        {
            InitializeComponent();
        }

     //   private object CurrentView;
      
        private void GetData()
        {

            oNcallBindingSource.DataSource = dc.ONcalls.ToList();
            shiftBindingSource.DataSource = dc.Shifts.ToList();
            gridControl1.RefreshDataSource();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fr = new dlgPeriodicCalender();
            fr.Show();

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dc.GetChangeSet().Updates.OfType<ONcall>().ToList().ForEach(c =>
            {
                c.History = c.History + " " + MainModule.GetPersianDate(DateTime.Now) + ' ' + DateTime.Now.ToString("HH:MM") + ' ' + MainModule.UserFullName;
            });

            GetData();
            dc.SubmitChanges();
        }

        private void frmONCall_Load(object sender, EventArgs e)
        {
            var query = from c in dc.vwMemGroups
                        where c.HeadUserID == MainModule.UserID //dc.Staffs.FirstOrDefault(x => x.UserID == MainModule.UserID).ID

                        select c;

            vwMemGroupBindingSource.DataSource = query;
            GetData();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dc.GetChangeSet().Updates.OfType<ONcall>().ToList().ForEach(c =>
            {
                c.History = c.History + " " + MainModule.GetPersianDate(DateTime.Now) + ' ' + DateTime.Now.ToString("HH:MM") + ' ' + MainModule.UserFullName;
            });

            GetData();
            dc.SubmitChanges();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
          
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}