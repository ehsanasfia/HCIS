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
using OMOApp.Data.ParsiData;
namespace OMOApp.Forms
{
    public partial class frmAzmayesh : DevExpress.XtraEditors.XtraForm
    {
        List<Question> lst = new List<Question>();
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmAzmayesh()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmAzmayesh_Load(object sender, EventArgs e)
        {
            try
            {
                if (Classes.MainModule.ReferenceFile_Set.Person.Photo != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = Classes.MainModule.ReferenceFile_Set.Person.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        barEditItem1.EditValue = Image.FromStream(ms);
                    }
                }
                else if (Classes.MainModule.ReferenceFile_Set.Person.Photo == null)
                {
                    barEditItem1.EditValue = null;
                }
            }
            catch
            { }

                if (Classes.MainModule.ReferenceFile_Set == null)
            {

            }
            else
            {
                barStaticItem1.Caption = "نام: " + Classes.MainModule.ReferenceFile_Set.Person.FirstName ?? "";
                barStaticItem2.Caption = "نام خانوادگی: " + Classes.MainModule.ReferenceFile_Set.Person.LastName ?? "";
            }
            GetDataLoad();


            //کد جدید
            lst = dc.Questions.Where(c => c.IDParent == 11).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 11 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 11 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource.DataSource = lst;
                foreach (var item in lst)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 11 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
                //تا اینجا
            }

        }
        private void GetDataLoad()
        {
          //  questionBindingSource.DataSource = dc.Questions.Where(c => c.IDParent == 11).ToList();

        }
   
        

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}