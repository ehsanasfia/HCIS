using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISEmail.Data;

namespace HCISEmail.Form
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        EmaildbDataContext dc = new EmaildbDataContext();
        public frmUser()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curentUser = userBindingSource.Current as User;
            var dlgnew = new Dialog.dlgNewUser();
            dlgnew.isEdit = true;
            dlgnew.EditingUser = curentUser;
            dlgnew.ShowDialog();
            GetData();
        }
        //tabei tarif kardim ba name GetData.
        //zamani ke bekhahim ke vaqri virayesh anjam midahim ya chizi be form ezafe konim
        //az code userBindingSource.DataSource = dc.Users.ToList();   estefade mikonim va dar in 
        //tabe ma baraye jilogiri az afzonegi esme in khat kod ro GetData gozashtim va dar mavaqe
        //niyaz seda mizanim...
        private void GetData()
        {
            userBindingSource.DataSource = dc.Users.ToList();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmEmail_Activated(object sender, EventArgs e)
        {
            //namayeshe liste user ha
            var q = from p in dc.Users
                    select p;
            GetData();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curentUser = userBindingSource.Current as User;
            var dlgnew = new Dialog.dlgUserRole();
            dlgnew.CurrentUser = curentUser;
            dlgnew.ShowDialog();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlgnew = new Dialog.dlgNewUser();
            dlgnew.dc = dc;
            dlgnew.ShowDialog();
            GetData();
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curentUser = userBindingSource.Current as User;
            if (curentUser == null)
                return;
            var dlgnew = new Dialog.dlgNewUser();
            dlgnew.isEdit = true;
            dlgnew.dc = dc;
            dlgnew.EditingUser = curentUser;
            dlgnew.ShowDialog();
            GetData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curentUser = userBindingSource.Current as User;
            if (curentUser == null)
                return;
            var frm = new Dialog.dlgUserRole();
            frm.CurrentUser = curentUser;
            frm.ShowDialog();
            GetData();
        }
    }
}
