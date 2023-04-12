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
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgSurgeryOthers : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public double? sum = 0;
        public GivenServiceD GSD { get; set; }
        public List<ModularService> lstMSS { get; set; }
        public List<ModularService> lstDel = new List<ModularService>();
        public List<Service> lstNew = new List<Service>();
        List<Service> lstSRV;
        public bool isEdit;

        public dlgSurgeryOthers()
        {
            InitializeComponent();
        }

        private void dlgSurgeryOthers_Load(object sender, EventArgs e)
        {
            if(lstMSS == null)
            {
                lstMSS = new List<ModularService>();
            }

            if(lstSRV == null)
            {
                lstSRV = new List<Service>();
            }

            lstSRV = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Service1.Name == "خدمات تعدیلی").OrderBy(c => c.Name).ToList();
            serviceBindingSource.DataSource = lstSRV;
            foreach (var item in lstSRV)
            {
                item.Finance = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var a = gridView1.GetSelectedRows().ToList();
            if(isEdit == false)
                GSD.ModularServices.Clear();
            if (isEdit == true)
            {
                foreach (var item in a)
                {
                    var row = gridView1.GetRow(item) as Service;
                    lstNew.Add(row);
                }
                foreach (var item in GSD.ModularServices)
                {
                    if(!lstNew.Any(c => c.ID == item.ServiceID))
                    {
                        lstDel.Add(item);
                    }
                }
            }
            foreach (var item in a)
            {
                var row = gridView1.GetRow(item) as Service;
                sum = sum + row.K;
                if (isEdit == true)
                {
                    if (GSD.ModularServices.Any(c => c.ServiceID == row.ID))
                        continue;
                }
                var mss = new ModularService()
                {
                    Name = row.Name,
                    K = row.K,
                    FinanceConfirm = row.Finance,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    GivenServiceD = GSD,
                    Service = row,
                };
                lstMSS.Add(mss);
            }          
            DialogResult = DialogResult.OK;
        }

        private void dlgSurgeryOthers_Shown(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                foreach (var item in GSD.ModularServices)
                {
                    var srv = lstSRV.FirstOrDefault(c => c.ID == item.ServiceID);
                    var index = serviceBindingSource.IndexOf(srv);
                    int rowHandle = gridView1.GetRowHandle(index);
                    if(gridView1.IsValidRowHandle(rowHandle))
                        gridView1.SelectRow(rowHandle);
                }
            }
        }

        //private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        //{
        //    var hndl = e.ControllerRow;
        //    var selected = gridView1.GetSelectedRows().ToList();
        //    var row = gridView1.GetRow(hndl) as Service;
        //    if (row == null)
        //        return;
        //    if (selected.Contains(hndl))
        //    {
        //        row.Finance = true;
        //    }
        //    else
        //    {
        //        row.Finance = false;
        //    }
        //    gridControl1.RefreshDataSource();
        //}
    }
}