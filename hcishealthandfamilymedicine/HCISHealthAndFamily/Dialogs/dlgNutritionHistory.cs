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
    public partial class dlgNutritionHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { set; get; }
        public Person SelectedPerson { get; set; }

        NutritionHistory ObjectNUH;

        public dlgNutritionHistory()
        {
            InitializeComponent();
        }

        private void dlgNutritionHistory_Load(object sender, EventArgs e)
        {
            if (ObjectNUH == null)
                ObjectNUH = new NutritionHistory();

            NutritionBindingSource.DataSource = ObjectNUH;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectNUH.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectNUH.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectNUH.CreatorUserID = MainModule.UserID;
            ObjectNUH.Person = SelectedPerson;
            if (ObjectNUH.ID == 0)
                dc.NutritionHistories.InsertOnSubmit(ObjectNUH);

            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}