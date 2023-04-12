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
using HCISLaundry.Data;
using HCISLaundry.Classes;

namespace HCISLaundry.Dialogs
{
    public partial class dlgLaundry : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }
        GivenServiceD ObjectGSD;
        List<GivenServiceD> lstGSD;

        public dlgLaundry()
        {
            InitializeComponent();
        }

        private void dlgLaundry_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void EndEdit()
        {
            GivenDBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (ObjectGSD == null)
                {
                    ObjectGSD = new GivenServiceD();
                }
                if(lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }
                givenServiceDBindingSource.DataSource = lstGSD;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.مدیریت_داخلی && x.Service1 != null && x.Service1.Service1 != null && x.Service1.Service1.Name == "البسه" && x.Service1.Name == "البسه بیمار").ToList();
                GivenDBindingSource.DataSource = ObjectGSD;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectGSD.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.Time = DateTime.Now.ToString("HH:mm");
            ObjectGSD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.LastModificationTime = DateTime.Now.ToString("HH:mm");

            if (ObjectGSD.Service != null)
            {
                lstGSD.Add(ObjectGSD);
            }
            else
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectGSD = null;
            GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var item in lstGSD)
            {
                item.GivenServiceM = GSM;
                dc.GivenServiceDs.InsertOnSubmit(item);
            }

            DialogResult = DialogResult.OK;
        }
    }
}