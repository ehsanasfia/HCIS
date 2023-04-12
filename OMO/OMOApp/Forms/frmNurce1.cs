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
    public partial class frmNurce1 : DevExpress.XtraEditors.XtraForm
    {
        List<Question> lst = new List<Question>();
        List<Question> lst2 = new List<Question>();
        List<Question> lst3 = new List<Question>();
        List<Question> lst4 = new List<Question>();
        List<Question> lst5 = new List<Question>();
        List<Question> lst6 = new List<Question>();

        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmNurce1()
        {
            InitializeComponent();
        }

        private void frmNurce_Load(object sender, EventArgs e)
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

            lst = dc.Questions.Where(c => c.IDParent == 233).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 233 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 233 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource1.DataSource = lst;
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

                qABindingSource1.DataSource = dc.QAs.Where(c => c.Question.IDParent == 233 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
               
            }
            //تا اینجا
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //کد جدید1
            lst2 = dc.Questions.Where(c => c.IDParent == 2).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 2 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 2 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource.DataSource = lst2;
                foreach (var item in lst2)
                {
                    QA u = new QA();
                    {
                        u.QuestionID = item.ID;

                        u.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(u);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource.DataSource = dc.QAs.Where(c => c.Question.IDParent == 2 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //1تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید2
            lst3 = dc.Questions.Where(c => c.IDParent == 3).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 3 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 3 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource1.DataSource = lst3;
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

                qABindingSource2.DataSource = dc.QAs.Where(c => c.Question.IDParent == 3 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //2تا اینجا
            //کد جدید3
            lst4 = dc.Questions.Where(c => c.IDParent == 4).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 4 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 4 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource3.DataSource = lst4;
                foreach (var R in lst4)
                {
                    QA m = new QA();
                    {
                        m.QuestionID = R.ID;

                        m.ReferenceFileID = Classes.MainModule.ReferenceFile_Set.ID;
                        dc.QAs.InsertOnSubmit(m);
                        dc.SubmitChanges();

                    }
                }

                qABindingSource3.DataSource = dc.QAs.Where(c => c.Question.IDParent == 4 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //3تا اینجا
            //////////////////////////////////////  پپپپ///////////////////////////////////////////////

            //کد جدید4
            lst5 = dc.Questions.Where(c => c.IDParent == 5).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 5 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 5 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource4.DataSource = lst5;
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

                qABindingSource4.DataSource = dc.QAs.Where(c => c.Question.IDParent == 5 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            //4تا اینجا
            // ---------------------------------------------------------------------------------------------------------
            //کد جدید5
            lst6 = dc.Questions.Where(c => c.IDParent == 6).ToList();
            if (Classes.MainModule.ReferenceFile_Set == null)
            {
                return;

            }
            if (dc.QAs.Any(c => c.Question.IDParent == 6 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID))
            {


                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 6 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();
            }
            else
            {
                questionBindingSource5.DataSource = lst6;
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

                qABindingSource5.DataSource = dc.QAs.Where(c => c.Question.IDParent == 6 && c.ReferenceFileID == Classes.MainModule.ReferenceFile_Set.ID).OrderBy(c => c.Question.Line).ToList();


            }
            //5تا اینجا

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

      

     
        private void questionBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void qABindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

       

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qABindingSource.EndEdit();
            qABindingSource1.EndEdit();
            qABindingSource2.EndEdit();
            qABindingSource3.EndEdit();
            qABindingSource4.EndEdit();
            qABindingSource5.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }
}