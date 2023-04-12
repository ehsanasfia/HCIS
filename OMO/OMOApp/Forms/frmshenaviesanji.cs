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
    public partial class frmshenaviesanji : DevExpress.XtraEditors.XtraForm
    {
      
        List<Question> lst1 = new List<Question>();
        List<Question> lst2 = new List<Question>();
        List<Question> lst3 = new List<Question>();
        List<Question> lst4 = new List<Question>();
        List<Question> lst5 = new List<Question>();
        List<Question> lst6 = new List<Question>();
        List<Question> lst7 = new List<Question>();
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmshenaviesanji()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmshenaviesanji_Load(object sender, EventArgs e)
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
            lst1 = dc.Questions.Where(c => c.IDParent == 148).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 148 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 148 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 148 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //1تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید2
            lst2 = dc.Questions.Where(c => c.IDParent == 166).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 166 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 166 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 166 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //2تا اینجا
            //کد جدید3
            lst3 = dc.Questions.Where(c => c.IDParent == 165).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 165 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 165 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 165 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //3تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////

            //کد جدید4
            lst4 = dc.Questions.Where(c => c.IDParent == 162).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 162 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 162 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 162 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //4تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            /////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////\\\\\\\\\\\\\\

            //کد جدید5
            lst5 = dc.Questions.Where(c => c.IDParent == 271 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 271 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 271 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource5.DataSource = lst5;
                foreach (var item in lst5)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 271 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //5تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید6
            lst6 = dc.Questions.Where(c => c.IDParent == 272 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 272 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID ))
            {


                qABindingSource6.DataSource = dc.QAs.Where(c => c.Question.IDParent == 272 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource6.DataSource = lst6;
                foreach (var R in lst6)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource6.DataSource = dc.QAs.Where(c => c.Question.IDParent == 272 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID ).OrderBy(c => c.Question.Line).ToList();


            }
            //6تا اینجا
            //کد جدید7
            lst7 = dc.Questions.Where(c => c.IDParent == 273).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 273 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource7.DataSource = dc.QAs.Where(c => c.Question.IDParent == 273 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource7.DataSource = lst7;
                foreach (var R in lst7)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource7.DataSource = dc.QAs.Where(c => c.Question.IDParent == 273 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //7تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////


        }



        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource1.EndEdit();
            qABindingSource2.EndEdit();
            qABindingSource3.EndEdit();
            qABindingSource4.EndEdit();
            qABindingSource5.EndEdit();
            qABindingSource6.EndEdit();
            qABindingSource7.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}