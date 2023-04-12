using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgComplicationsBB : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Dossier Doss;
        ComplicationsBB ObjectCBB;

        public dlgComplicationsBB()
        {
            InitializeComponent();
        }

        private void dlgComplicationsBB_Load(object sender, EventArgs e)
        {
            if(Doss.ComplicationsBB != null)
                ObjectCBB = Doss.ComplicationsBB;
            else
                ObjectCBB = new ComplicationsBB();

            ComplicationBindingSource.DataSource = ObjectCBB;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(ObjectCBB.ID == 0)
                {
                    ObjectCBB.ID = Doss.ID;
                    ObjectCBB.Dossier = Doss;
                    dc.ComplicationsBBs.InsertOnSubmit(ObjectCBB);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}