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
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily.Dialogs
{
    public partial class dlgParaClinichistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgParaClinichistory()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc { set; get; }
        public Person MyPerson { set; get; }
        public Person SelectedPerson { get; internal set; }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            paraClinicServiceHistoryBindingSource.EndEdit();
       var NewPara=paraClinicServiceHistoryBindingSource.Current as ParaClinicServiceHistory;
            NewPara.Person = SelectedPerson;
            NewPara.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            NewPara.CreationTime = DateTime.Now.ToString("HH:mm");
            NewPara.CreatorUserID = MainModule.UserID;
            dc.ParaClinicServiceHistories.InsertOnSubmit(NewPara);
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

     
        private void dlgParaClinichistory_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 2).ToList();

            paraClinicServiceHistoryBindingSource.DataSource = new ParaClinicServiceHistory();
        }
    }
}