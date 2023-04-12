using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Forms
{
    public partial class frmExcelFile : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        List<FileExcel> lst;

        public frmExcelFile()
        {
            InitializeComponent();
        }

        private void frmExcelFile_Load(object sender, EventArgs e)
        {
            if (lst == null)
                lst = new List<FileExcel>();         

            /////// اول قرار بود بر حسب خانواده کار کند
            //GSM = dc.GivenServiceMs.FirstOrDefault(c => c.ID == MainModule.GSM_Set.ID);

            //foreach (var item in dc.Persons.Where(x => x.PersonalCode == GSM.Person.PersonalCode))
            //{
            //    if(item.FileExcels.Any())
            //    {
            //        lst.Add(item.FileExcels.FirstOrDefault());
            //    }
            //    else
            //    {
            //        var fe = new FileExcel();
            //        fe.Person = item;
            //        lst.Add(fe);
            //        dc.FileExcels.InsertOnSubmit(fe);
            //    }
            //}

            lst = dc.FileExcels.Where(c => c.DepartmentHCIS == MainModule.InstallLocation.ID).ToList();
            fileExcelBindingSource.DataSource = lst;

            lst.ForEach(x => x.IsHealthDiabet = CheckHD(x));
            lst.ForEach(x => x.IsIFGDiabet = CheckIFG(x));
            lst.ForEach(x => x.IsIGTDiabet = CheckIGT(x));
            lst.ForEach(x => x.IsBloodFat = CheckBF(x));
            lst.ForEach(x => x.IsBloodPressure = CheckBP(x));
            lst.ForEach(x => x.IsPreHypertension = CheckPH(x));
            lst.ForEach(x => x.IsObesity = CheckOB(x));
        }

        private bool CheckHD(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (FE.HealthyDRDate == null)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - (int)FE.HealthyDRDate >= 3)
                return true;
            else
                return false;
        }

        private bool CheckIFG(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (string.IsNullOrWhiteSpace(FE.ifgDRDate) || FE.ifgDRDate.Trim().Length != 4)
                return false;
            int a = -1;
            bool valid = int.TryParse(FE.ifgDRDate.Trim(), out a);
            if (!valid || a == -1)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - a >= 1)
                return true;
            else
                return false;
        }

        private bool CheckIGT(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (string.IsNullOrWhiteSpace(FE.igtDRDate) || FE.igtDRDate.Trim().Length != 4)
                return false;
            int a = -1;
            bool valid = int.TryParse(FE.igtDRDate.Trim(), out a);
            if (!valid || a == -1)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - a >= 1)
                return true;
            else
                return false;
        }

        private bool CheckBF(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (FE.HealthyBFDRDate == null)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - (int)FE.HealthyBFDRDate >= 3)
                return true;
            else
                return false;
        }

        private bool CheckBP(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (FE.HealthyHBPRDate == null)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - (int)FE.HealthyHBPRDate >= 2)
                return true;
            else
                return false;
        }

        private bool CheckPH(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (FE.PreHipertansiyonHBPRDate == null)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - (int)FE.PreHipertansiyonHBPRDate >= 1)
                return true;
            else
                return false;
        }

        private bool CheckOB(FileExcel FE)
        {
            if (FE == null)
                return false;
            if (FE.NormalOWDate == null)
                return false;
            if (int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4)) - (int)FE.NormalOWDate >= 2)
                return true;
            else
                return false;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            lst.ForEach(x => x.IsHealthDiabet = CheckHD(x));
            lst.ForEach(x => x.IsIFGDiabet = CheckIFG(x));
            lst.ForEach(x => x.IsIGTDiabet = CheckIGT(x));
            lst.ForEach(x => x.IsBloodFat = CheckBF(x));
            lst.ForEach(x => x.IsBloodPressure = CheckBP(x));
            lst.ForEach(x => x.IsPreHypertension = CheckPH(x));
            lst.ForEach(x => x.IsObesity = CheckOB(x));

        }

        private void advBandedGridView1_CustomDrawBandHeader(object sender, DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs e)
        {
            if (e.Band == null) return;
            if (e.Band.AppearanceHeader.BackColor != Color.Empty)
                e.Info.AllowColoring = true;
        }
    }
}