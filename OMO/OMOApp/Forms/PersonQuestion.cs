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
using OMOApp.Classes;
namespace OMOApp.Forms
{
    public partial class PersonQuestion : DevExpress.XtraEditors.XtraForm
    {
        public PersonQuestion()
        {
            InitializeComponent();
        }

        private void PersonQuestion_Load(object sender, EventArgs e)
        {
            //if (Classes.MainModule.ReferenceFile_Set == null)
            //{

            //}
            //else
            //{
            //    barStaticItem1.Caption = "نام: " + Classes.MainModule.ReferenceFile_Set.Person.FirstName ?? "";
            //    barStaticItem2.Caption = "نام خانوادگی: " + Classes.MainModule.ReferenceFile_Set.Person.LastName ?? "";
            // }


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}