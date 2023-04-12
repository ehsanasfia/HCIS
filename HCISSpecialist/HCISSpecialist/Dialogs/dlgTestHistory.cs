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
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgTestHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISSpecialistClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public dlgTestHistory()
        {
            InitializeComponent();
        }

        private void dlgTestHistory_Load(object sender, EventArgs e)
        {
            try
            {
                givenServiceMsBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.PersonID == person.ID && x.ServiceCategoryID != null && x.ServiceCategoryID == (int)Category.آزمایش).ToList();
                givenServiceMsBindingSource_CurrentChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void givenServiceMsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                givenServiceDsBindingSource.DataSource = null;
                return;
            }
            givenServiceDsBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == cur.ID).ToList();
        }
    }
}