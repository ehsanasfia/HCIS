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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;
using DevExpress.XtraEditors.Repository;

namespace HCISHealthAndFamily
{
    public partial class RptQaDone : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        IMPHOClassesDataContext IM = new IMPHOClassesDataContext();
        List<Spu_PersonQaResult> report = new List<Spu_PersonQaResult>();

        public RptQaDone()
        {
            InitializeComponent();
        }

        private void frmPregnancy_Load(object sender, EventArgs e)
        {

            questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.ToList();
            tblValidCenterZoneBindingSource.DataSource = IM.Tbl_ValidCenterZones.ToList();

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {



        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {


        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var valid = searchLookUpEdit2.EditValue as Tbl_ValidCenter;
            if (treeList1.GetAllCheckedNodes() == null || valid == null)
            {
                MessageBox.Show("لطفا سوالات مورد نظر را انتخاب کنید");
                return;
            }
            report.Clear();
            var date = datePicker1.Date;
            if (date == null)
                return;
            var FAge = (int)spinEdit1.Value;
            var TAge = (int)spinEdit2.Value;
            bool Status = false;
            bool big = false;
            if (radioGroup1.SelectedIndex == 1)
                Status = false;
            else
                Status = true;

            if (radioGroup2.SelectedIndex == 0)
                big = false;
            else
                big = true;

            foreach (var item in treeList1.GetAllCheckedNodes())
            {
                var qp = treeList1.GetDataRecordByNode(item) as QuestionnaireGroup;
                var person = dc.Spu_PersonQa(qp.IDint, date, FAge, TAge, Status,big,valid.IDValidCenter);
                foreach (var per in person)
                {
                    report.Add(per);

                }
            }

            spuPersonQaResultBindingSource.DataSource = report.Select(x => new { x.FirstName, x.LastName, x.Age, x.Sex }).Distinct();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var editvalue = searchLookUpEdit1.EditValue as Tbl_ValidCenterZone;
            if (editvalue == null)
                return;
            tblValidCenterBindingSource.DataSource = IM.Tbl_ValidCenters.Where(x => x.IDValidCenterZone == editvalue.IDValidCenterZone);
        }
    }
}