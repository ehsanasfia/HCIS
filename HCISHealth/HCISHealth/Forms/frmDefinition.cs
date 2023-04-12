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
using HCISHealth.Forms;
using HCISHealth.Data;

namespace HCISHealth.Forms
{
    public partial class frmDefinition : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmDefinition()
        {
            InitializeComponent();
        }

        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            Service u = new Service();

            //u.ParentID = item.p.ParentID;
            //u.QuestionnariID = item.p.ID;


            //dc.QAs.InsertOnSubmit(u);
            //dc.SubmitChanges();
            //GetData();
        }
    }
}