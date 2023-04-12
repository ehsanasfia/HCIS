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
    public partial class frmcheshm : DevExpress.XtraEditors.XtraForm
    {
        List<Question> lst1 = new List<Question>();
        List<Question> lst2 = new List<Question>();
        List<Question> lst3 = new List<Question>();
        List<Question> lst4 = new List<Question>();
        List<Question> lst5 = new List<Question>();
        List<Question> lst6 = new List<Question>();
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmcheshm()
        {
            InitializeComponent();
        }

        private void frmcheshm_Load(object sender, EventArgs e)
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
            {
            }

                if (Classes.MainModule.ReferenceFile_Set == null) 
            {

            }
            else
            {
                barStaticItem1.Caption = "نام: " + Classes.MainModule.ReferenceFile_Set.Person.FirstName ?? "";
                barStaticItem2.Caption = "نام خانوادگی: " + Classes.MainModule.ReferenceFile_Set.Person.LastName ?? "";
            }


            //کد جدید1
            lst1 = dc.Questions.Where(c => c.IDParent == 131).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 131 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 131 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource1.DataSource = lst1;
                foreach (var item in lst1)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 131 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //1تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید2
            lst2 = dc.Questions.Where(c => c.IDParent == 132).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 132 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 132 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource2.DataSource = lst2;
                foreach (var R in lst2)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 132 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //2تا اینجا
            //کد جدید3
            lst3 = dc.Questions.Where(c => c.IDParent == 133).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 133 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 133 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource3.DataSource = lst3;
                foreach (var R in lst3)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 133 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //3تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////

            //کد جدید4
            lst4 = dc.Questions.Where(c => c.IDParent == 146).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 146 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 146 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource4.DataSource = lst4;
                foreach (var item in lst4)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 146 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
                //4تا اینجا
                // ---------------------------------------------------------------------------------------------------------


            }
            
          

        private void gridControl2_Click(object sender, EventArgs e)
        {
            
            var C = questionBindingSource.Current as Question;
            if (C == null)
                return;
            questionBindingSource.DataSource = dc.Questions.Where(c => c.IDParent == C.ID).ToList();
        }

      

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }


        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource.EndEdit();
            qABindingSource1.EndEdit();
            qABindingSource2.EndEdit();
            qABindingSource3.EndEdit();
            qABindingSource4.EndEdit();
           // qABindingSource5.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource.EndEdit();
            qABindingSource1.EndEdit();
            qABindingSource2.EndEdit();
            qABindingSource3.EndEdit();
            qABindingSource4.EndEdit();
            // qABindingSource5.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}