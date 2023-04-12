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
using HCISHealth.Data;
using HCISHealth.Classes;


namespace HCISHealth.Forms
{
    public partial class frmProfile : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstSharh;
        List<QA> lstSharhHistory;
        List<QA> lstBardariFeli;
        List<QA> lstBardariFeliHistory;
        List<QA> lstZaymanGhabli;
        List<QA> lstZaymanGhabliHistory;
        List<QA> lstNahanjari;
        List<QA> lstNahanjariHistory;
        List<QA> lstPorKhatar;
        List<QA> lstPorKhatarHistory;

        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstSharh == null)
                lstSharh = new List<QA>();

            if (lstSharhHistory == null)
                lstSharhHistory = new List<QA>();

            if (lstBardariFeli == null)
                lstBardariFeli = new List<QA>();

            if (lstBardariFeliHistory == null)
                lstBardariFeliHistory = new List<QA>();

            if (lstZaymanGhabli == null)
                lstZaymanGhabli = new List<QA>();

            if (lstZaymanGhabliHistory == null)
                lstZaymanGhabliHistory = new List<QA>();

            if (lstNahanjari == null)
                lstNahanjari = new List<QA>();

            if (lstNahanjariHistory == null)
                lstNahanjariHistory = new List<QA>();

            if (lstPorKhatar == null)
                lstPorKhatar = new List<QA>();

            if (lstPorKhatarHistory == null)
                lstPorKhatarHistory = new List<QA>();

            var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("d0e137fc-d0b1-48b8-95b2-fb2d9951bd19")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QA()
                {
                    PService = item,
                };
                lstSharh.Add(qa0);
            }
            SharhQABindingSource.DataSource = lstSharh.OrderBy(c => c.PService.OldID);

            var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("2fe43cfb-8c5a-4d36-8e15-d9513fef1b80")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QA()
                {
                    PService = item,
                };
                lstBardariFeli.Add(qa1);
            }
            BardariFeliQABindingSource.DataSource = lstBardariFeli.OrderBy(c => c.PService.OldID);

            var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("b47fcf4f-e154-412d-8cdb-1112a47aeda7")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QA()
                {
                    PService = item,
                };
                lstZaymanGhabli.Add(qa2);
            }
            ZaymanGhabliQABindingSource.DataSource = lstZaymanGhabli.OrderBy(c => c.PService.OldID);

            var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("e634fef1-712f-4716-a15d-acfe4b49a1bb")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QA()
                {
                    PService = item,
                };
                lstNahanjari.Add(qa3);
            }
            NahanjariQABindingSource.DataSource = lstNahanjari.OrderBy(c => c.PService.OldID);

            var srvList4 = dc.Services.Where(x => x.ParentID == Guid.Parse("b7ba408e-6801-4f78-bcfc-3b21f4d92364")).ToList();
            foreach (var item in srvList4)
            {
                var qa4 = new QA()
                {
                    PService = item,
                };
                lstPorKhatar.Add(qa4);
            }
            PorKhatarQABindingSource.DataSource = lstPorKhatar.OrderBy(c => c.PService.OldID);
        }

        private void btnOk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
                if (gsm == null)
                    return;

                foreach (var item in lstSharh)
                {
                    if (!string.IsNullOrWhiteSpace(item.MResult) || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstBardariFeli)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstZaymanGhabli)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstNahanjari)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstPorKhatar)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                SharhQABindingSource.DataSource = null;
                BardariFeliQABindingSource.DataSource = null;
                ZaymanGhabliQABindingSource.DataSource = null;
                NahanjariQABindingSource.DataSource = null;
                PorKhatarQABindingSource.DataSource = null;

                lstSharhHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("d0e137fc-d0b1-48b8-95b2-fb2d9951bd19")).ToList();
                SharhHistoryQABindingSource.DataSource = lstSharhHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstBardariFeliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("2fe43cfb-8c5a-4d36-8e15-d9513fef1b80")).ToList();
                BardariFeliHistoryQABindingSource.DataSource = lstBardariFeliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstZaymanGhabliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b47fcf4f-e154-412d-8cdb-1112a47aeda7")).ToList();
                ZaymanGhabliHistoryQABindingSource.DataSource = lstZaymanGhabliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstNahanjariHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("e634fef1-712f-4716-a15d-acfe4b49a1bb")).ToList();
                NahanjariHistoryQABindingSource.DataSource = lstNahanjariHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstPorKhatarHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b7ba408e-6801-4f78-bcfc-3b21f4d92364")).ToList();
                PorKhatarHistoryQABindingSource.DataSource = lstPorKhatarHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl6.RefreshDataSource();
                gridControl7.RefreshDataSource();
                gridControl8.RefreshDataSource();
                gridControl9.RefreshDataSource();
                gridControl10.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup2.Expanded = !layoutControlGroup2.Expanded;

            if (!lstSharhHistory.Any())
            {
                lstSharhHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("d0e137fc-d0b1-48b8-95b2-fb2d9951bd19")).ToList();
            }
            SharhHistoryQABindingSource.DataSource = lstSharhHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl6.RefreshDataSource();
        }

        private void layoutControlGroup8_Click(object sender, EventArgs e)
        {
            layoutControlGroup8.Expanded = !layoutControlGroup8.Expanded;

            if (!lstBardariFeliHistory.Any())
            {
                lstBardariFeliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("2fe43cfb-8c5a-4d36-8e15-d9513fef1b80")).ToList();
            }
            BardariFeliHistoryQABindingSource.DataSource = lstBardariFeliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl7.RefreshDataSource();
        }

        private void layoutControlGroup11_Click(object sender, EventArgs e)
        {
            layoutControlGroup11.Expanded = !layoutControlGroup11.Expanded;

            if (!lstZaymanGhabliHistory.Any())
            {
                lstZaymanGhabliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b47fcf4f-e154-412d-8cdb-1112a47aeda7")).ToList();
            }
            ZaymanGhabliHistoryQABindingSource.DataSource = lstZaymanGhabliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl8.RefreshDataSource();
        }

        private void layoutControlGroup10_Click(object sender, EventArgs e)
        {
            layoutControlGroup10.Expanded = !layoutControlGroup10.Expanded;

            if (!lstNahanjariHistory.Any())
            {
                lstNahanjariHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("e634fef1-712f-4716-a15d-acfe4b49a1bb")).ToList();
            }
            NahanjariHistoryQABindingSource.DataSource = lstNahanjariHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl9.RefreshDataSource();
        }

        private void layoutControlGroup9_Click(object sender, EventArgs e)
        {
            layoutControlGroup9.Expanded = !layoutControlGroup9.Expanded;

            if (!lstPorKhatarHistory.Any())
            {
                lstPorKhatarHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b7ba408e-6801-4f78-bcfc-3b21f4d92364")).ToList();
            }
            PorKhatarHistoryQABindingSource.DataSource = lstPorKhatarHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl10.RefreshDataSource();
        }
    }
}