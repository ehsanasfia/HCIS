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
using HCISHealthAndFamily.Data;

namespace HCISHealthAndFamily
{
    public partial class frmPrePregnancy : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lstSharh;
        List<QAPlus> lstSharhHistory;
        List<QAPlus> lstBardariFeli;
        List<QAPlus> lstBardariFeliHistory;
        List<QAPlus> lstZaymanGhabli;
        List<QAPlus> lstZaymanGhabliHistory;
        List<QAPlus> lstNahanjari;
        List<QAPlus> lstNahanjariHistory;
        List<QAPlus> lstPorKhatar;
        List<QAPlus> lstPorKhatarHistory;

        public frmPrePregnancy()
        {
            InitializeComponent();
        }

        private void frmPrePregnancy_Load(object sender, EventArgs e)
        {
            //if (lstSharh == null)
            //    lstSharh = new List<QAPlus>();

            //if (lstSharhHistory == null)
            //    lstSharhHistory = new List<QAPlus>();

            //if (lstBardariFeli == null)
            //    lstBardariFeli = new List<QAPlus>();

            //if (lstBardariFeliHistory == null)
            //    lstBardariFeliHistory = new List<QAPlus>();

            //if (lstZaymanGhabli == null)
            //    lstZaymanGhabli = new List<QAPlus>();

            //if (lstZaymanGhabliHistory == null)
            //    lstZaymanGhabliHistory = new List<QAPlus>();

            //if (lstNahanjari == null)
            //    lstNahanjari = new List<QAPlus>();

            //if (lstNahanjariHistory == null)
            //    lstNahanjariHistory = new List<QAPlus>();

            //if (lstPorKhatar == null)
            //    lstPorKhatar = new List<QAPlus>();

            //if (lstPorKhatarHistory == null)
            //    lstPorKhatarHistory = new List<QAPlus>();

            //var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("3ed16100-43d4-4873-b87d-d60f9e74357a")).ToList();
            //foreach (var item in srvList0)
            //{
            //    var qa0 = new QA()
            //    {
            //        PService = item,
            //    };
            //    lstSharh.Add(qa0);
            //}
            //SharhQABindingSource.DataSource = lstSharh.OrderBy(c => c.PService.OldID);

            //var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("bed0fcb7-0ef2-4dcb-bbc2-630951985d53")).ToList();
            //foreach (var item in srvList1)
            //{
            //    var qa1 = new QA()
            //    {
            //        PService = item,
            //    };
            //    lstBardariFeli.Add(qa1);
            //}
            //BardariFeliQABindingSource.DataSource = lstBardariFeli.OrderBy(c => c.PService.OldID);

            //var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("96debf31-39ab-4777-962b-56705cac074d")).ToList();
            //foreach (var item in srvList2)
            //{
            //    var qa2 = new QA()
            //    {
            //        PService = item,
            //    };
            //    lstZaymanGhabli.Add(qa2);
            //}
            //ZaymanGhabliQABindingSource.DataSource = lstZaymanGhabli.OrderBy(c => c.PService.OldID);

            //var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("9f1a2dc1-d505-416e-8670-acd3de52a4ec")).ToList();
            //foreach (var item in srvList3)
            //{
            //    var qa3 = new QA()
            //    {
            //        PService = item,
            //    };
            //    lstNahanjari.Add(qa3);
            //}
            //NahanjariQABindingSource.DataSource = lstNahanjari.OrderBy(c => c.PService.OldID);

            //var srvList4 = dc.Services.Where(x => x.ParentID == Guid.Parse("56001902-7d4b-4d2b-9f91-ab6325d2dad9")).ToList();
            //foreach (var item in srvList4)
            //{
            //    var qa4 = new QA()
            //    {
            //        PService = item,
            //    };
            //    lstPorKhatar.Add(qa4);
            //}
            //PorKhatarQABindingSource.DataSource = lstPorKhatar.OrderBy(c => c.PService.OldID);
        }

        private void btnOkT1_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            //    return;
            //try
            //{
            //    var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
            //    if (gsm == null)
            //        return;

            //    foreach (var item in lstSharh)
            //    {
            //        if (!string.IsNullOrWhiteSpace(item.MResult) || !string.IsNullOrWhiteSpace(item.Description))
            //        {
            //            item.Service = item.PService;
            //            item.GivenServiceM = gsm;
            //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            //            item.CreationUser = MainModule.UserID;
            //            dc.QAs.InsertOnSubmit(item);
            //        }
            //    }
            //    foreach (var item in lstBardariFeli)
            //    {
            //        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
            //        {
            //            item.Service = item.PService;
            //            item.GivenServiceM = gsm;
            //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            //            item.CreationUser = MainModule.UserID;
            //            dc.QAs.InsertOnSubmit(item);
            //        }
            //    }
            //    foreach (var item in lstZaymanGhabli)
            //    {
            //        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
            //        {
            //            item.Service = item.PService;
            //            item.GivenServiceM = gsm;
            //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            //            item.CreationUser = MainModule.UserID;
            //            dc.QAs.InsertOnSubmit(item);
            //        }
            //    }
            //    foreach (var item in lstNahanjari)
            //    {
            //        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
            //        {
            //            item.Service = item.PService;
            //            item.GivenServiceM = gsm;
            //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            //            item.CreationUser = MainModule.UserID;
            //            dc.QAs.InsertOnSubmit(item);
            //        }
            //    }
            //    foreach (var item in lstPorKhatar)
            //    {
            //        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
            //        {
            //            item.Service = item.PService;
            //            item.GivenServiceM = gsm;
            //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            //            item.CreationUser = MainModule.UserID;
            //            dc.QAs.InsertOnSubmit(item);
            //        }
            //    }

            //    dc.SubmitChanges();
            //    SharhQABindingSource.DataSource = null;
            //    BardariFeliQABindingSource.DataSource = null;
            //    ZaymanGhabliQABindingSource.DataSource = null;
            //    NahanjariQABindingSource.DataSource = null;
            //    PorKhatarQABindingSource.DataSource = null;

            //    lstSharhHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("3ed16100-43d4-4873-b87d-d60f9e74357a")).ToList();
            //    SharhHistoryQABindingSource.DataSource = lstSharhHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

            //    lstBardariFeliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("bed0fcb7-0ef2-4dcb-bbc2-630951985d53")).ToList();
            //    BardariFeliHistoryQABindingSource.DataSource = lstBardariFeliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

            //    lstZaymanGhabliHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("96debf31-39ab-4777-962b-56705cac074d")).ToList();
            //    ZaymanGhabliHistoryQABindingSource.DataSource = lstZaymanGhabliHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

            //    lstNahanjariHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("9f1a2dc1-d505-416e-8670-acd3de52a4ec")).ToList();
            //    NahanjariHistoryQABindingSource.DataSource = lstNahanjariHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

            //    lstPorKhatarHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("56001902-7d4b-4d2b-9f91-ab6325d2dad9")).ToList();
            //    PorKhatarHistoryQABindingSource.DataSource = lstPorKhatarHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

            //    gridControl6.RefreshDataSource();
            //    gridControl7.RefreshDataSource();
            //    gridControl8.RefreshDataSource();
            //    gridControl9.RefreshDataSource();
            //    gridControl10.RefreshDataSource();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    return;
            //}
        }
    }
}