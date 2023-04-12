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
    public partial class dlgMentalHealthHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { set; get; }
        public Person SelectedPerson { get; set; }

        MentalHealthHistory ObjectMHH;

        public dlgMentalHealthHistory()
        {
            InitializeComponent();
        }

        private void dlgMentalHealthHistory_Load(object sender, EventArgs e)
        {
            if (ObjectMHH == null)
                ObjectMHH = new MentalHealthHistory();

            MentalHealthBindingSource.DataSource = ObjectMHH;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectMHH.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectMHH.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectMHH.CreatorUserID = MainModule.UserID;
            ObjectMHH.Person = SelectedPerson;
            if (ObjectMHH.ID == 0)
                dc.MentalHealthHistories.InsertOnSubmit(ObjectMHH);

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}