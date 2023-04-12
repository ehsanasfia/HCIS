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
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgInsertTest : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        //HospitalClassesDataContext dcHos = new HospitalClassesDataContext();

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public dlgInsertTest()
        {
            InitializeComponent();
        }

        private void dlgInsertTest_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //var hemat = dc.Services.FirstOrDefault(x => x.Name == "هماتولوژی");
            //var lstRBC = dc.Services.Where(x => x.Service1 != null && x.Service1.Service1 != null && x.Service1.Service1.ParentID == hemat.ID).ToList();
            //var lstR = dc.Services.Where(x => x.CategoryID == 1 && x.Name == "R.B.C").ToList();
            //int a = 5;

            splashScreenManager2.ShowWaitForm();
            try
            {

                var cat = (int)Category.آزمایش;
                InsertUncategorized();
                //DeleteNotLabs();

                /*
                foreach (var gp in dcHos.lab_param__groups)
                {
                    var hcGP = new Service() { Name = gp.name, CategoryID = cat };
                    dc.Services.InsertOnSubmit(hcGP);
                }
                dc.SubmitChanges();
                */


                /*
                foreach (var item in dcHos.lab_param_subgroups)
                {
                    var a = new Service() { Name = item.name, CategoryID = cat };
                    var gp = dcHos.lab_param__groups.FirstOrDefault(x => x.group_id == item.group_id);
                    if (gp == null)
                    {
                        MessageBox.Show("Test");
                        return;
                    }
                    var gpHC = dc.Services.FirstOrDefault(x => x.Name == gp.name);
                    if (gpHC == null)
                    {
                        MessageBox.Show("Test2");
                        return;
                    }
                    a.ParentID = gpHC.ID;
                    dc.Services.InsertOnSubmit(a);
                }
                dc.SubmitChanges();
                */

                /*
                var lstParents = dcHos.lab_subgroup_items.ToList();
                foreach (var item in lstParents)
                {

                    var lbTst = dcHos.labTests.FirstOrDefault(x => x.Test_ID == item.test_id);
                    if (lbTst == null)
                    {
                        if (MessageBox.Show("No test for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var subGp = dcHos.lab_param_subgroups.FirstOrDefault(x => x.subgroup_id == item.subgroup_id);
                    if (subGp == null)
                    {
                        if (MessageBox.Show("No sub gp for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var gp = dcHos.lab_param__groups.FirstOrDefault(x => x.group_id == subGp.group_id);
                    if (gp == null)
                    {
                        if (MessageBox.Show("No gp for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var sub = dc.Services.FirstOrDefault(x => x.ParentID != null && x.Name == subGp.name && x.Service1.Name == gp.name);
                    if (sub == null)
                    {
                        if (MessageBox.Show("No sub in hcis for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var srv = new Service()
                    {
                        CategoryID = cat,
                        Name = lbTst.Name,
                        SalamatBookletCode = lbTst.NationalID == null ? null : lbTst.NationalID + "",
                        ParentID = sub.ID
                    };
                    var det = new LaboratoryServiceDetail()
                    {
                        AbbreviationName = string.IsNullOrWhiteSpace(lbTst.Abbr) ? null : lbTst.Abbr.Trim(),
                        LowerBound = lbTst.lo_critical == null ? null : lbTst.lo_critical + "",
                        UpperBound = lbTst.hi_critical == null ? null : lbTst.hi_critical + "",
                        MeasurementUnit = string.IsNullOrWhiteSpace(lbTst.Msr_Unit) ? null : lbTst.Msr_Unit.Trim(),
                        NormalRange = string.IsNullOrWhiteSpace(lbTst.Norm) ? null : lbTst.Norm,
                        TestNo = lbTst.TestCount,
                        TestOnly = lbTst.Show,
                        TestType = lbTst.Head == 0 ? "تست" : (lbTst.Head == 1 ? "پانل" : (lbTst.Head == 2 ? "توضيحي" : null))
                    };

                    srv.LaboratoryServiceDetail = det;
                    dc.Services.InsertOnSubmit(srv);
                    dc.LaboratoryServiceDetails.InsertOnSubmit(det);
                }
                dc.SubmitChanges();
                */

                /*
                var lstSubGpItems = dcHos.lab_subgroup_items.ToList();
                var tests = new List<labTest>();
                foreach (var subgpItem in lstSubGpItems)
                {
                    var tst = dcHos.labTests.FirstOrDefault(x => x.Test_ID == subgpItem.test_id);
                    if (tst == null)
                        continue;
                    tests.Add(tst);
                }

                var lstParentTests = dcHos.labTests.Where(x => x.Parent == 0 && !tests.Contains(x)).ToList();
                foreach (var lbTst in lstParentTests)
                {
                    var gp = dcHos.lab_param__groups.FirstOrDefault(x => x.group_id == lbTst.Group_id);
                    if (gp == null)
                    {
                        if (MessageBox.Show("No gp for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var hcisGp = dc.Services.FirstOrDefault(x => x.ParentID == null && x.Name == gp.name);
                    if (hcisGp == null)
                    {
                        if (MessageBox.Show("No sub in hcis for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var srv = new Service()
                    {
                        CategoryID = cat,
                        Name = lbTst.Name,
                        SalamatBookletCode = lbTst.NationalID == null ? null : lbTst.NationalID + "",
                        ParentID = hcisGp.ID
                    };
                    var det = new LaboratoryServiceDetail()
                    {
                        AbbreviationName = string.IsNullOrWhiteSpace(lbTst.Abbr) ? null : lbTst.Abbr.Trim(),
                        LowerBound = lbTst.lo_critical == null ? null : lbTst.lo_critical + "",
                        UpperBound = lbTst.hi_critical == null ? null : lbTst.hi_critical + "",
                        MeasurementUnit = string.IsNullOrWhiteSpace(lbTst.Msr_Unit) ? null : lbTst.Msr_Unit.Trim(),
                        NormalRange = string.IsNullOrWhiteSpace(lbTst.Norm) ? null : lbTst.Norm,
                        TestNo = lbTst.TestCount,
                        TestOnly = lbTst.Show,
                        TestType = lbTst.Head == 0 ? "تست" : (lbTst.Head == 1 ? "پانل" : (lbTst.Head == 2 ? "توضيحي" : null))
                    };

                    srv.LaboratoryServiceDetail = det;
                    dc.Services.InsertOnSubmit(srv);
                    dc.LaboratoryServiceDetails.InsertOnSubmit(det);
                }
                dc.SubmitChanges();
                */

                /*
                var lstSubGpItems = dcHos.lab_subgroup_items.ToList();
                var tests = new List<labTest>();
                foreach (var subgpItem in lstSubGpItems)
                {
                    var tst = dcHos.labTests.FirstOrDefault(x => x.Test_ID == subgpItem.test_id);
                    if (tst == null)
                        continue;
                    tests.Add(tst);
                }

                var lstSingleTests = dcHos.labTests.Where(x => x.Parent != 0 && !tests.Contains(x)).ToList();

                foreach (var lbTst in lstSingleTests)
                {
                    var parent = dcHos.labTests.FirstOrDefault(x => x.Test_ID == lbTst.Parent);
                    if (parent == null)
                    {
                        if (MessageBox.Show("No gp for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }
                    var prntHCIS = dc.Services.FirstOrDefault(x => x.CategoryID == (int)Category.آزمايش
                    && x.Name == parent.Name
                    && x.LaboratoryServiceDetail != null
                    && x.LaboratoryServiceDetail.AbbreviationName == parent.Abbr
                    && parent.NationalID == null ? x.SalamatBookletCode == null : x.SalamatBookletCode == parent.NationalID + ""
                    && x.LaboratoryServiceDetail.MeasurementUnit == parent.Msr_Unit
                    && x.LaboratoryServiceDetail.NormalRange == parent.Norm
                    && x.LaboratoryServiceDetail.TestNo == parent.TestCount);
                    if (prntHCIS == null)
                    {
                        if (MessageBox.Show("No gp for " + item.id, "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                        continue;
                    }

                    var srv = new Service()
                    {
                        CategoryID = cat,
                        Name = lbTst.Name,
                        SalamatBookletCode = lbTst.NationalID == null ? null : lbTst.NationalID + "",
                        ParentID = prntHCIS.ID
                    };
                    var det = new LaboratoryServiceDetail()
                    {
                        AbbreviationName = string.IsNullOrWhiteSpace(lbTst.Abbr) ? null : lbTst.Abbr.Trim(),
                        LowerBound = lbTst.lo_critical == null ? null : lbTst.lo_critical + "",
                        UpperBound = lbTst.hi_critical == null ? null : lbTst.hi_critical + "",
                        MeasurementUnit = string.IsNullOrWhiteSpace(lbTst.Msr_Unit) ? null : lbTst.Msr_Unit.Trim(),
                        NormalRange = string.IsNullOrWhiteSpace(lbTst.Norm) ? null : lbTst.Norm,
                        TestNo = lbTst.TestCount,
                        TestOnly = lbTst.Show,
                        TestType = lbTst.Head == 0 ? "تست" : (lbTst.Head == 1 ? "پانل" : (lbTst.Head == 2 ? "توضيحي" : null))
                    };

                    srv.LaboratoryServiceDetail = det;
                    dc.Services.InsertOnSubmit(srv);
                    dc.LaboratoryServiceDetails.InsertOnSubmit(det);
                }
                dc.SubmitChanges();
                */

                /*
                var lst = dc.Services.Where(x => x.CategoryID == 1 && (x.Name == null || x.Name.Trim() == "")).ToList();
                foreach (var item in lst)
                {
                    if (item.LaboratoryServiceDetail != null)
                    {
                        dc.LaboratoryServiceDetails.DeleteOnSubmit(item.LaboratoryServiceDetail);
                    }
                }
                dc.Services.DeleteAllOnSubmit(lst);
                dc.SubmitChanges();
                */

                /*
                var lst = dc.Services.Where(x => x.CategoryID == cat && (x.LaboratoryServiceDetail == null || x.LaboratoryServiceDetail.AbbreviationName == null || x.LaboratoryServiceDetail.AbbreviationName.Trim() == "")).ToList();
                foreach (var item in lst)
                {
                    if (item.LaboratoryServiceDetail == null)
                    {
                        item.LaboratoryServiceDetail = new LaboratoryServiceDetail() { AbbreviationName = item.Name };
                    }
                    else
                    {
                        item.LaboratoryServiceDetail.AbbreviationName = item.Name;
                    }
                }

                dc.SubmitChanges();
                */
                MessageBox.Show(dc.LaboratoryServiceDetails.Count() + "");




            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void DeleteNotLabs()
        {
            //var lstTestGps = dc.LabTestGroups.Where(x => x.Service.CategoryID != (int)Category.آزمایش).ToList();
            //dc.LabTestGroups.DeleteAllOnSubmit(lstTestGps);
            //dc.SubmitChanges();
        }

        private void InsertUncategorized()
        {
            //var cat = (int)Category.آزمایش;

            //var lstNoGp = dcHos.labTests.Where(x => !x.lab_subgroup_items.Any()
            //&& x.Group_id != null && x.Name != null && x.Name.Trim() != "").ToList();

            //foreach (var nogp in lstNoGp)
            //{
            //    var gp = dcHos.lab_param__groups.FirstOrDefault(x => x.group_id == nogp.Group_id);
            //    if (gp == null)
            //        MessageBox.Show("no gp");

            //    var labgp = dc.LabGroups.FirstOrDefault(x => x.OldID == gp.group_id);

            //    var firstSub = dcHos.lab_param_subgroups.Where(x => x.group_id == gp.group_id).OrderBy(x => x.group_id).FirstOrDefault();


            //    LabSubGroup sbgp;
            //    if (firstSub != null)
            //    {
            //        sbgp = dc.LabSubGroups.FirstOrDefault(x => x.OldID == firstSub.subgroup_id);
            //    }
            //    else
            //    {
            //        sbgp = new LabSubGroup() { OldID = null, SubGroupName = gp.name, LabGroup = labgp };
            //        dc.LabSubGroups.InsertOnSubmit(sbgp);
            //    }


            //    var srv = dc.Services.FirstOrDefault(x => x.OldID == nogp.Test_ID && x.CategoryID == (int)Category.آزمایش);
            //    if (srv == null)
            //    {
            //        //MessageBox.Show("no srv");
            //        Service hcisParent = null;
            //        if (nogp.Parent != 0)
            //            hcisParent = dc.Services.FirstOrDefault(x => x.OldID == nogp.Parent && x.CategoryID == (int)Category.آزمایش);

            //        srv = new Service()
            //        {
            //            CategoryID = cat,
            //            Name = nogp.Name.Trim(),
            //            Name_En = nogp.Name.Trim(),
            //            SalamatBookletCode = nogp.NationalID == null ? null : nogp.NationalID + "",
            //            OldParentID = nogp.Parent,
            //            OldID = nogp.Test_ID,
            //            Service1 = hcisParent,
            //        };


            //        var det = new LaboratoryServiceDetail()
            //        {
            //            AbbreviationName = string.IsNullOrWhiteSpace(nogp.Abbr) ? srv.Name : nogp.Abbr.Trim(),
            //            LowerBound = nogp.lo_critical == null ? null : nogp.lo_critical + "",
            //            UpperBound = nogp.hi_critical == null ? null : nogp.hi_critical + "",
            //            MeasurementUnit = string.IsNullOrWhiteSpace(nogp.Msr_Unit) ? null : nogp.Msr_Unit.Trim(),
            //            NormalRange = string.IsNullOrWhiteSpace(nogp.Norm) ? null : nogp.Norm.Trim(),
            //            TestNo = nogp.TestCount,
            //            TestOnly = nogp.Show,
            //            Show = nogp.Show,
            //            TestType = nogp.Head == 0 ? "تست" : (nogp.Head == 1 ? "پانل" : (nogp.Head == 2 ? "توضيحي" : null))
            //        };

            //        srv.LaboratoryServiceDetail = det;
            //        dc.Services.InsertOnSubmit(srv);
            //        dc.LaboratoryServiceDetails.InsertOnSubmit(det);
            //    }

            //    LabTestGroup lbtstgp = null;
            //    if (sbgp.ID != 0)
            //    {
            //        lbtstgp = dc.LabTestGroups.FirstOrDefault(x => x.ServiceID == srv.ID && x.LabSubGroupID == sbgp.ID);
            //    }
            //    if (lbtstgp == null)
            //    {
            //        lbtstgp = new LabTestGroup() { LabSubGroup = sbgp, Service = srv, Flg = true };
            //        dc.LabTestGroups.InsertOnSubmit(lbtstgp);
            //    }


            //}

            //dc.SubmitChanges();
        }
    }
}