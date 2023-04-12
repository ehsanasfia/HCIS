using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HcisDispatchConfirm.Data;
namespace HcisDispatchConfirm.Dialogs
{
    public partial class dlgRequest : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Vw_HcisDispatchConfirmMain Doc { get; set; }
        List<QA> Parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        public bool isEditt { get; set; }
        List<QA> FilterdChild = new List<QA>();
        // List<DossierDentall> lst = new List<DossierDentall>();
        // public DossierDentall DD { get; set; }
        public dlgRequest()
        {
            InitializeComponent();
        }

        private void dlgRequest_Load(object sender, EventArgs e)
        {
            vwHcisDispatchConfirmBindingSource.DataSource = dc.Vw_HcisDispatchConfirms.Where(c => c.ID == Doc.ID).ToList();
            var today = MainModule.GetPersianDate(DateTime.Now);
            var req = dc.QAs.Where(c => c.GivenServiceDID == Doc.ID).ToList();
            if (req.Count>0)
            {
                MessageBox.Show("شما قبلا این درخواست را پاسخ داده اید");
                simpleButton3.Enabled = false;
                qABindingSource1.DataSource = req;
                return;
            }
            var myreq = dc.Services.Where(x => x.ParentID == null && x.OldID==1 && x.CategoryID == 18).ToList();
            foreach (var item in myreq)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);

                foreach (var service in item.Services)
                {

                    var qa2 = new QA()
                    {
                        Service = service,
                    };
                    AllChild.Add(qa2);
                }

            }
            qABindingSource.DataSource = Parents;

            gridControl6.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            var cur = qABindingSource.Current as QA;
            if (cur == null)
                return;

            FilterdChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            qABindingSource1.DataSource = FilterdChild;
            gridControl9.RefreshDataSource();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (var item in AllChild)
            {
                if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                {
                    // item.IDGivenServiceM = gsm.ID;
                    item.GivenServiceDID = Doc.ID;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;
                }
                dc.QAs.InsertOnSubmit(item);
            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource.DataSource = null;
            qABindingSource1.DataSource = null;
        }
    }
}