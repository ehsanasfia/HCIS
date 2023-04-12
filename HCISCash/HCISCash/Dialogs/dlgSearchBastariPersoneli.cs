using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Classes;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgSearchBastariPersoneli : DevExpress.XtraEditors.XtraForm
    {
        public dlgSearchBastariPersoneli()
        {
            InitializeComponent();
        }
        public bool AllowDeleteServices { get; set; } = false;
        public bool AllowEditRefrences { get; set; } = false;
        public string PCode { get; internal set; }
        public Data.HCISCashDataContextDataContext dc {  get; set; }
        public long dossierID;
        List<GivenServiceM> lst;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try { 
                lst = new List<GivenServiceM>();
                var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10
                && ((txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "") ? false : (y.Person.PersonalCode == txtPersonalCode.Text.Trim()))
                )).ToList();
                d.ForEach(x =>
                {
                    lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                });
                givenServiceMBindingSource.DataSource = lst;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as Data.GivenServiceM;
          if(cur!=null)
           dossierID=(long)cur.DossierID;
            DialogResult = DialogResult.OK;
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            txtPersonalCode.Text =PCode;
            btnSearch_Click(null, null);
            var g = new GivenServiceM();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;

            //var f = new Forms.frmEditReference() { Dossier = gsm.Dossier };
            //f.ShowDialog();
        }

       
        }
}
