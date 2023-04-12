﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgSelectInsuree : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc = new HCISClassesDataContext();
        public string Current;
        public List<IGrouping<string, Spu_AllDBPersonResult>> insurlist = new List<IGrouping<string, Spu_AllDBPersonResult>>();
        public dlgSelectInsuree()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = insurlist;
            insuranceBindingSource.DataSource = insurlist;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var cur = insuranceBindingSource.Current as IGrouping<string, Spu_AllDBPersonResult>;
            if (cur == null)
                return;

            Current = cur.Key;
            DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gridControl1_DoubleClick(null, null);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                gridControl1_DoubleClick(null, null);
            }
        }
    }
}