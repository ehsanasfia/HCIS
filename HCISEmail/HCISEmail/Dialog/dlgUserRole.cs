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
using HCISEmail.Data;

namespace HCISEmail.Dialog
{
    public partial class dlgUserRole : DevExpress.XtraEditors.XtraForm
    {
        EmaildbDataContext dc = new EmaildbDataContext();
        //dar qesmate PAEIN OMADIM PUBLIC USER RA TARIF KARDIM
        public User CurrentUser { get; set; }
        public dlgUserRole()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
            MessageBox.Show("Taqirat nadide gerefte shodand");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkpSemat.EditValue == null)
                return;
            var newRoleuser = new RoleUser()
            {
                //Dar bala currentuser ra moarefi kardim va dar inja besh meqdar dadim
                UserID = CurrentUser.IDUser,
                RoleID = (lkpSemat.EditValue as Role).IDRole
            };
            dc.RoleUsers.InsertOnSubmit(newRoleuser);
            dc.SubmitChanges();
            MessageBox.Show("Saabt Shod");
        }

        private void dlgRole_Load(object sender, EventArgs e)
        {
            roleBindingSource.DataSource = dc.Roles.ToList();
        }
    }
}