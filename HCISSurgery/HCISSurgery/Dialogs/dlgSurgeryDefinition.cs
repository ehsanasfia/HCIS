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
    public partial class dlgSurgeryDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { set; get; }
        public Service ObjectSRV;
        public DiagnosticServiceDetail ObjectDSD;
        int? Wcode;
        public dlgSurgeryDefinition() 
        {
            InitializeComponent();
        }

        private void dlgServiceDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectSRV == null)
            {
                ObjectSRV = new Service();
            }
            if(ObjectDSD == null)
            {
                ObjectDSD = new DiagnosticServiceDetail();
            }
            else
            {
                Wcode = ObjectDSD.Code;
            }
            ServiceBindingSource.DataSource = ObjectSRV;
            DetailBindingSource.DataSource = ObjectDSD;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjectDSD.Code != Wcode)
                {
                    if (dc.Services.Any(x => x.SalamatBookletCode == ObjectSRV.SalamatBookletCode && x.CategoryID == (int)Category.خدمات_جراحی))
                    {
                        MessageBox.Show("این نام کوتاه قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                if(ObjectSRV.BasicK == null)
                {
                    MessageBox.Show("لطفا K را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectSRV.SupplementBasicK == null)
                {
                    MessageBox.Show("لطفا K را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                ObjectDSD.Service = ObjectSRV;
                var srv = dc.Services.FirstOrDefault(c => c.ParentID == null && c.CategoryID == (int)Category.خدمات_جراحی && c.Name == "عمل");
                if (srv == null)
                {
                    srv = new Service()
                    {
                        ParentID = null,
                        Name = "عمل",
                        CategoryID = (int)Category.خدمات_جراحی,
                    };
                    dc.Services.InsertOnSubmit(srv);
                }
                var DepsOR = dc.Services.FirstOrDefault(c => c.CategoryID == (int)Category.خدمات_جراحی && c.ParentID != null && c.Service1.Name == "عمل" && c.Name == "اتاق عمل اورژانس");
                var DepsGE = dc.Services.FirstOrDefault(c => c.CategoryID == (int)Category.خدمات_جراحی && c.ParentID != null && c.Service1.Name == "عمل" && c.Name == "اتاق عمل");
                var DepsGH = dc.Services.FirstOrDefault(c => c.CategoryID == (int)Category.خدمات_جراحی && c.ParentID != null && c.Service1.Name == "عمل" && c.Name == "اتاق عمل قلب");

                if (DepsOR == null)
                {
                    DepsOR = new Service()
                    {
                        ParentID = srv.ID,
                        Name = "اتاق عمل اورژانس",
                        CategoryID = (int)Category.خدمات_جراحی
                    };
                    dc.Services.InsertOnSubmit(DepsOR);
                }
                if (DepsGE == null)
                {
                    DepsGE = new Service()
                    {
                        ParentID = srv.ID,
                        Name = "اتاق عمل",
                        CategoryID = (int)Category.خدمات_جراحی
                    };
                    dc.Services.InsertOnSubmit(DepsGE);
                }
                if (DepsGH == null)
                {
                    DepsGH = new Service()
                    {
                        ParentID = srv.ID,
                        Name = "اتاق عمل قلب",
                        CategoryID = (int)Category.خدمات_جراحی
                    };
                    dc.Services.InsertOnSubmit(DepsGH);
                }
                var mdName = MainModule.MyDepartment.Name;
                var searchDep = dc.Services.FirstOrDefault(x => x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Name == mdName);

                if (!dc.Services.Any(x => x.ID == ObjectSRV.ID) && !dc.DiagnosticServiceDetails.Any(x => x.ID == ObjectDSD.ID))
                {
                    ObjectSRV.CategoryID = (int)Category.خدمات_جراحی;
                    ObjectSRV.Service1 = searchDep;
                    dc.Services.InsertOnSubmit(ObjectSRV);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}