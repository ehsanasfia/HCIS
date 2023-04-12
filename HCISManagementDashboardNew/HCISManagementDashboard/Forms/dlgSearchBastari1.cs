using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;


namespace HCISManagementDashboard.Dialogs
{
    public partial class dlgSearchBastari1 : DevExpress.XtraEditors.XtraForm
    {
        public dlgSearchBastari1()
        {
            InitializeComponent();
        }
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public long dossierID;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch { }
        }

        private void GetData()
        {
            if (comboBoxEdit1.EditValue == null)
            {
                MessageBox.Show("ناریخ را وارد کنید");
                return;
            }

            if (txtToDate.Text.Trim() == "")
            {
                MessageBox.Show("ناریخ را وارد کنید");
                return;
            }
            var ward = slkWard.EditValue as Department;

            //if (lookUpEdit1.EditValue == null)
            //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }

            if (comboBoxEdit1.EditValue.ToString() == "تاریخ پذیرش")
            {
                if(ward==null)
                vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => ((y.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && y.AdmitDate.CompareTo(txtToDate.Text) <= 0) || (y.Date.CompareTo(txtFromDate.Text) >= 0 && y.Date.CompareTo(txtToDate.Text) <= 0)) );

                else
                    vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y =>y.depName==ward.Name && ((y.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && y.AdmitDate.CompareTo(txtToDate.Text) <= 0) || (y.Date.CompareTo(txtFromDate.Text) >= 0 && y.Date.CompareTo(txtToDate.Text) <= 0)));

            }
            else if (comboBoxEdit1.EditValue.ToString() == "تاریخ ترخیص")
            {
                if (ward == null)
                    vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => y.DischargeDate != null
                && ((y.DischargeDate.CompareTo(txtFromDate.Text) >= 0 && y.DischargeDate.CompareTo(txtToDate.Text) <= 0) ) );
          else
                    vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y =>  y.DisDep == ward.Name && y.DischargeDate != null
              && ((y.DischargeDate.CompareTo(txtFromDate.Text) >= 0 && y.DischargeDate.CompareTo(txtToDate.Text) <= 0)));

            }


            else if (comboBoxEdit1.EditValue.ToString() == "بیماران فعلی بخش ها")
            {
               vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => ((y.AdmitDate!=null)) && (y.AdmitDate.CompareTo("1397/07/19") >= 0) && y.DischargeDate==null );
            }


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();

            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            comboBoxEdit1.SelectedIndex = 0;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Count")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<Data.Vw_DossierBastari> lst = new List<Data.Vw_DossierBastari>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var datarow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Data.Vw_DossierBastari;

                lst.Add(datarow);
            }

            var MyData = from x in lst
                         select new
                         {
                             x.FirstName,
                             x.LastName,
                             PersonalCode = x.MedicalID,
                             x.ID,
                             WardName = x.depName,
                             InsuranceName = x.InsurName,
                             x.NationalCode,
                         };
            Report.RegData("MyData", MyData);

            Report.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            Report.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            //  Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
            Report.Dictionary.Synchronize();
            // stiViewerControl1.Report = Report;
            Report.Compile();
            Report.Render();
            // Report.Design();
            Report.ShowWithRibbonGUI();
        }

       
        private void btnRptPetientWard_Click(object sender, EventArgs e)
        {
            List<Data.Vw_DossierBastari> lst = new List<Data.Vw_DossierBastari>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var datarow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Data.Vw_DossierBastari;

                lst.Add(datarow);
            }
            var MyData = from x in lst
                         select new
                         {
                             x.FirstName,
                             x.LastName,
                             PersonalCode = x.MedicalID,
                             x.ID,
                             WardName = x.depName,
                             InsuranceName = x.InsurName,
                             x.NationalCode,
                             x.AdmitDate
                         };
            StiBakhsheFeli.RegData("MyData", MyData);
            StiBakhsheFeli.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            StiBakhsheFeli.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            //  Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
            StiBakhsheFeli.Dictionary.Synchronize();
            // stiViewerControl1.Report = Report;
       //     StiBakhsheFeli.Design();
            StiBakhsheFeli.Compile();
            StiBakhsheFeli.Render();
            // Report.Design();
            StiBakhsheFeli.ShowWithRibbonGUI();
        }
    }
}