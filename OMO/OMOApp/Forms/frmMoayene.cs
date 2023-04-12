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
    public partial class frmMoayene : DevExpress.XtraEditors.XtraForm
    {
        List<Question> lst = new List<Question>();
        List<Question> lst1 = new List<Question>();
        List<Question> lst2 = new List<Question>();
        List<Question> lst3 = new List<Question>();
        List<Question> lst4 = new List<Question>();
        List<Question> lst5 = new List<Question>();
        List<Question> lst6 = new List<Question>();
        List<Question> lst7 = new List<Question>();
        List<Question> lst8 = new List<Question>();
        List<Question> lst9 = new List<Question>();
        List<Question> lst10 = new List<Question>();
        List<Question> lst11 = new List<Question>();
        List<Question> lst12 = new List<Question>();
        List<Question> lst13 = new List<Question>();
        List<Question> lst14 = new List<Question>();
        List<Question> lst15 = new List<Question>();
        List<Question> lst16 = new List<Question>();
        List<Question> lst17 = new List<Question>();
        List<Question> lst18 = new List<Question>();
        List<Question> lst19 = new List<Question>();
        List<Question> lst20 = new List<Question>();
        List<Question> lst21 = new List<Question>();
        List<Question> lst22 = new List<Question>();
        List<Question> lst23 = new List<Question>();
        List<Question> lst24 = new List<Question>();
        List<Question> lst25 = new List<Question>();
        List<Question> lst26 = new List<Question>();
        List<Question> lst27 = new List<Question>();
        List<Question> lst28 = new List<Question>();
        List<Question> lst29 = new List<Question>();
        List<Question> lst30 = new List<Question>();
        List<Question> lst31 = new List<Question>();
        List<Question> lst32 = new List<Question>();
        List<Question> lst33 = new List<Question>();
        List<Question> lst34 = new List<Question>();
        List<Question> lst35 = new List<Question>();
        List<Question> lst36 = new List<Question>();
        List<Question> lst37 = new List<Question>();
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmMoayene()
        {
            InitializeComponent();
        }

        private void frmMoayene_Load(object sender, EventArgs e)
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

            lst = dc.Questions.Where(c => c.IDParent == 264).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 264 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 264 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 264 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
                //تا اینجا
            }

            ////    پایان اطلاعات شاخص فرد گرید////


            //کد جدید1
            lst1 = dc.Questions.Where(c => c.IDParent == 284).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 284 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 284 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 284 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //1تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید2
            lst2 = dc.Questions.Where(c => c.IDParent == 285).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 285 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 285 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 285 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //2تا اینجا
            //کد جدید3
            lst3 = dc.Questions.Where(c => c.IDParent == 270).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 270 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 270 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 270 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //3تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////

            //کد جدید4
            lst4 = dc.Questions.Where(c => c.IDParent == 110).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 110 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 110 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 110 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //4تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            /////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////\\\\\\\\\\\\\\

            //کد جدید5
            lst5 = dc.Questions.Where(c => c.IDParent == 121 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 121 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 121 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 121 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //5تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید6
            lst6 = dc.Questions.Where(c => c.IDParent == 128 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 128 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource6.DataSource = dc.QAs.Where(c => c.Question.IDParent == 128 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource6.DataSource = dc.QAs.Where(c => c.Question.IDParent == 128 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //6تا اینجا
            //کد جدید7
            lst7 = dc.Questions.Where(c => c.IDParent == 291).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 291 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource7.DataSource = dc.QAs.Where(c => c.Question.IDParent == 291 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
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

                qABindingSource7.DataSource = dc.QAs.Where(c => c.Question.IDParent == 291 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //7تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////









            //کد جدید8
            lst8 = dc.Questions.Where(c => c.IDParent == 292).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 292 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource8.DataSource = dc.QAs.Where(c => c.Question.IDParent == 292 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource8.DataSource = lst8;
                foreach (var item in lst8)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource8.DataSource = dc.QAs.Where(c => c.Question.IDParent == 292 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //8تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید9
            lst9 = dc.Questions.Where(c => c.IDParent == 290).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 290 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource9.DataSource = dc.QAs.Where(c => c.Question.IDParent == 290 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource9.DataSource = lst9;
                foreach (var R in lst9)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource9.DataSource = dc.QAs.Where(c => c.Question.IDParent == 290 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //9تا اینجا
            //کد جدید10
            lst10 = dc.Questions.Where(c => c.IDParent == 294).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 294 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource10.DataSource = dc.QAs.Where(c => c.Question.IDParent == 294 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource10.DataSource = lst10;
                foreach (var R in lst10)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource10.DataSource = dc.QAs.Where(c => c.Question.IDParent == 294 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //10تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////

            //کد جدید11
            lst11 = dc.Questions.Where(c => c.IDParent == 295).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 295 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource11.DataSource = dc.QAs.Where(c => c.Question.IDParent == 295 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource11.DataSource = lst11;
                foreach (var item in lst11)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource11.DataSource = dc.QAs.Where(c => c.Question.IDParent == 295 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //11تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            /////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////\\\\\\\\\\\\\\

            //کد جدید12
            lst12 = dc.Questions.Where(c => c.IDParent == 293 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 293 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource12.DataSource = dc.QAs.Where(c => c.Question.IDParent == 293 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource12.DataSource = lst12;
                foreach (var item in lst12)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource12.DataSource = dc.QAs.Where(c => c.Question.IDParent == 293 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //12تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید13
            lst13 = dc.Questions.Where(c => c.IDParent == 297 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 297 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource13.DataSource = dc.QAs.Where(c => c.Question.IDParent == 297 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource13.DataSource = lst13;
                foreach (var R in lst13)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource13.DataSource = dc.QAs.Where(c => c.Question.IDParent == 297 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //13تا اینجا
            ////کد جدید14
     
            lst14 = dc.Questions.Where(c => c.IDParent == 298 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 298 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource14.DataSource = dc.QAs.Where(c => c.Question.IDParent == 298 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource14.DataSource = lst14;
                foreach (var R in lst14)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource14.DataSource = dc.QAs.Where(c => c.Question.IDParent == 298 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //14تا اینجا
            //کد جدید15
            lst15= dc.Questions.Where(c => c.IDParent == 296).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 296 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource15.DataSource = dc.QAs.Where(c => c.Question.IDParent == 296 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource15.DataSource = lst15;
                foreach (var R in lst15)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource15.DataSource = dc.QAs.Where(c => c.Question.IDParent == 296 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //15تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////
            //1کد جدید6
            lst16 = dc.Questions.Where(c => c.IDParent == 300 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 300 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource16.DataSource = dc.QAs.Where(c => c.Question.IDParent == 300 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource16.DataSource = lst16;
                foreach (var R in lst16)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource16.DataSource = dc.QAs.Where(c => c.Question.IDParent == 300 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //16تا اینجا
            //1کد جدید7
            lst17 = dc.Questions.Where(c => c.IDParent == 301).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 301 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource17.DataSource = dc.QAs.Where(c => c.Question.IDParent == 301 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource17.DataSource = lst17;
                foreach (var R in lst17)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource17.DataSource = dc.QAs.Where(c => c.Question.IDParent == 301 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //17تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////
            //1کد جدید8
            lst18 = dc.Questions.Where(c => c.IDParent == 299).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 299 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource18.DataSource = dc.QAs.Where(c => c.Question.IDParent == 299 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource18.DataSource = lst18;
                foreach (var item in lst18)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource18.DataSource = dc.QAs.Where(c => c.Question.IDParent == 299 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //18تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            // ---------------------------------------------------------------------------------------------------------
            //1کد جدید9
            lst19 = dc.Questions.Where(c => c.IDParent == 303).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 303 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource19.DataSource = dc.QAs.Where(c => c.Question.IDParent == 303 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource19.DataSource = lst19;
                foreach (var R in lst19)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource19.DataSource = dc.QAs.Where(c => c.Question.IDParent == 303 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //19تا اینجا
            //کد جدید20
            lst20 = dc.Questions.Where(c => c.IDParent == 304).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 304 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource20.DataSource = dc.QAs.Where(c => c.Question.IDParent == 304 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource20.DataSource = lst20;
                foreach (var R in lst20)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource20.DataSource = dc.QAs.Where(c => c.Question.IDParent == 304 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //20تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////
            //کد جدید21
            lst21 = dc.Questions.Where(c => c.IDParent == 302).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 302 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource21.DataSource = dc.QAs.Where(c => c.Question.IDParent == 302 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource21.DataSource = lst21;
                foreach (var item in lst21)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource21.DataSource = dc.QAs.Where(c => c.Question.IDParent == 302 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //21تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            /////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////\\\\\\\\\\\\\\
            //کد جدید22
            lst22 = dc.Questions.Where(c => c.IDParent == 306 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 306 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource22.DataSource = dc.QAs.Where(c => c.Question.IDParent == 306 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource22.DataSource = lst22;
                foreach (var item in lst22)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource22.DataSource = dc.QAs.Where(c => c.Question.IDParent == 306 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //22تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید23
            lst23 = dc.Questions.Where(c => c.IDParent == 307 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 307 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource23.DataSource = dc.QAs.Where(c => c.Question.IDParent == 307 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource23.DataSource = lst23;
                foreach (var R in lst23)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource23.DataSource = dc.QAs.Where(c => c.Question.IDParent == 307 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //23تا اینجا
            ////کد جدید24

            lst24 = dc.Questions.Where(c => c.IDParent == 305 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 305 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource24.DataSource = dc.QAs.Where(c => c.Question.IDParent == 305 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource24.DataSource = lst24;
                foreach (var R in lst24)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource24.DataSource = dc.QAs.Where(c => c.Question.IDParent == 305 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //24تا اینجا
            //کد جدید25
            lst25 = dc.Questions.Where(c => c.IDParent == 309).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 309 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource25.DataSource = dc.QAs.Where(c => c.Question.IDParent == 309 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource25.DataSource = lst25;
                foreach (var R in lst25)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource25.DataSource = dc.QAs.Where(c => c.Question.IDParent == 309 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //25تا اینجا
            //2کد جدید6
            lst26 = dc.Questions.Where(c => c.IDParent == 310 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 310 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource26.DataSource = dc.QAs.Where(c => c.Question.IDParent == 310 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource26.DataSource = lst26;
                foreach (var R in lst26)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource26.DataSource = dc.QAs.Where(c => c.Question.IDParent == 310 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //26تا اینجا
            //2کد جدید7
            lst27 = dc.Questions.Where(c => c.IDParent == 308).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 308 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource27.DataSource = dc.QAs.Where(c => c.Question.IDParent == 308 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource27.DataSource = lst27;
                foreach (var R in lst27)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource27.DataSource = dc.QAs.Where(c => c.Question.IDParent == 308 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //27تا اینجا
            //2کد جدید8
            lst28 = dc.Questions.Where(c => c.IDParent == 312).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 312 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource28.DataSource = dc.QAs.Where(c => c.Question.IDParent == 312 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource18.DataSource = lst28;
                foreach (var item in lst28)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource28.DataSource = dc.QAs.Where(c => c.Question.IDParent == 312 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //28تا اینجا
            //2کد جدید9
            lst29 = dc.Questions.Where(c => c.IDParent == 313).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 313 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource29.DataSource = dc.QAs.Where(c => c.Question.IDParent == 313 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource29.DataSource = lst29;
                foreach (var R in lst29)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource29.DataSource = dc.QAs.Where(c => c.Question.IDParent == 313 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //29تا اینجا
            //کد جدید30
            lst30 = dc.Questions.Where(c => c.IDParent == 311).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 311 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource30.DataSource = dc.QAs.Where(c => c.Question.IDParent == 311 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource30.DataSource = lst30;
                foreach (var R in lst30)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource30.DataSource = dc.QAs.Where(c => c.Question.IDParent == 311 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //30تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////
            //کد جدید31
            lst31 = dc.Questions.Where(c => c.IDParent == 315).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 315 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource31.DataSource = dc.QAs.Where(c => c.Question.IDParent == 315 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource31.DataSource = lst31;
                foreach (var item in lst31)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource31.DataSource = dc.QAs.Where(c => c.Question.IDParent == 315 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //31تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            /////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////\\\\\\\\\\\\\\
            //کد جدید32
            lst32 = dc.Questions.Where(c => c.IDParent == 316 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 316 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource32.DataSource = dc.QAs.Where(c => c.Question.IDParent == 316 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource32.DataSource = lst32;
                foreach (var item in lst32)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource32.DataSource = dc.QAs.Where(c => c.Question.IDParent == 316 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //32تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید33
            lst33 = dc.Questions.Where(c => c.IDParent == 314 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 314 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource33.DataSource = dc.QAs.Where(c => c.Question.IDParent == 314 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource33.DataSource = lst33;
                foreach (var R in lst33)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource33.DataSource = dc.QAs.Where(c => c.Question.IDParent == 314 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //33تا اینجا
            ////کد جدید34

            lst34 = dc.Questions.Where(c => c.IDParent == 318 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 318 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource34.DataSource = dc.QAs.Where(c => c.Question.IDParent == 318 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource34.DataSource = lst34;
                foreach (var R in lst34)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource34.DataSource = dc.QAs.Where(c => c.Question.IDParent == 318 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //34تا اینجا

            //کد جدید35
            lst35 = dc.Questions.Where(c => c.IDParent == 319).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 319 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource35.DataSource = dc.QAs.Where(c => c.Question.IDParent == 319 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource35.DataSource = lst35;
                foreach (var R in lst35)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource35.DataSource = dc.QAs.Where(c => c.Question.IDParent == 319 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //35تا اینجا
            //3کد جدید6
            lst36 = dc.Questions.Where(c => c.IDParent == 317 && c.Name != "AC" && c.Name != "BC").ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 317 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource36.DataSource = dc.QAs.Where(c => c.Question.IDParent == 317 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource36.DataSource = lst36;
                foreach (var R in lst36)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource36.DataSource = dc.QAs.Where(c => c.Question.IDParent == 317 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //36تا اینجا
            //3کد جدید7
            lst37 = dc.Questions.Where(c => c.IDParent == 269).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 269 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource37.DataSource = dc.QAs.Where(c => c.Question.IDParent == 269 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource37.DataSource = lst37;
                foreach (var R in lst37)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource37.DataSource = dc.QAs.Where(c => c.Question.IDParent == 269 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //37تا اینجا
        }




        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource.EndEdit();
            qABindingSource1.EndEdit();
            qABindingSource2.EndEdit();
            qABindingSource3.EndEdit();
            qABindingSource4.EndEdit();
            qABindingSource5.EndEdit();
            qABindingSource6.EndEdit();
            qABindingSource7.EndEdit();
            qABindingSource8.EndEdit();
            qABindingSource9.EndEdit();
            qABindingSource10.EndEdit();
            qABindingSource11.EndEdit();
            qABindingSource12.EndEdit();
            qABindingSource13.EndEdit();
            qABindingSource14.EndEdit();
            qABindingSource15.EndEdit();
            qABindingSource16.EndEdit();
            qABindingSource17.EndEdit();
            qABindingSource18.EndEdit();
            qABindingSource19.EndEdit();
            qABindingSource20.EndEdit();
            qABindingSource21.EndEdit();
            qABindingSource22.EndEdit();
            qABindingSource23.EndEdit();
            qABindingSource24.EndEdit();
            qABindingSource25.EndEdit();
            qABindingSource26.EndEdit();
            qABindingSource27.EndEdit();
            qABindingSource28.EndEdit();
            qABindingSource29.EndEdit();
            qABindingSource30.EndEdit();
            qABindingSource31.EndEdit();
            qABindingSource32.EndEdit();
            qABindingSource33.EndEdit();
            qABindingSource34.EndEdit();
            qABindingSource35.EndEdit();
            qABindingSource36.EndEdit();
            qABindingSource37.EndEdit();
 
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }


    }
}