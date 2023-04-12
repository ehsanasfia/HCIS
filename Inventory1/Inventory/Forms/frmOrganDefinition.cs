﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Dialogs;
using Inventory.Forms;
using Inventory.Data;
namespace Inventory.Forms
{
    public partial class frmOrganDefinition : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmOrganDefinition()
        {
            InitializeComponent();
        }

        private void frmOrganDefinition_Load(object sender, EventArgs e)
        {
            
            GetData();

        }
        private void GetData()
        {
            organsBindingSource.DataSource = dc.Organs.Where(c=> c.Warehouse == false).OrderBy(c=>c.Name).ToList();
            userBindingSource.DataSource = dc.Users.ToList();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = organsBindingSource.Current as Organ;
            if (d == null)
            {
                return;
            }
            dc.Organs.DeleteOnSubmit(d);
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.SubmitChanges();
            GetData();


        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = organsBindingSource.Current as Organ;
            if (cu == null)
            {
                return;
            }
            var a = new dlgOrganDefinition();
            a.dc = dc;
            a.isEdit = true;
            a.Or = cu;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = organsBindingSource.Current as Organ;
            if (cu == null)
                return;
            var a = new frmBossOrgan();
            a.dc = dc;
          //  a.isEdit = true;
             a.Or = cu;
            a.Text = "تعریف رئیس واحد";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = organsBindingSource.Current as Organ;
            if (cu == null)
            {
                return;
            }
            var a = new dlgOrganDefinition();
            a.dc = dc;
            a.isEdit = false;
            a.Or = cu;
            a.Text = "تعریف واحد";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var cu = organsBindingSource.Current as Organ;
            //if (cu == null)
            //    return;
            var a = new dlgUserB();
            a.dc = dc;
            //  a.isEdit = true;
            // a.Or = cu;
            a.Text = "مشاهده رئیس واحدها";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
               // G();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var cu = organsBindingSource.Current as Organ;
            //if (cu == null)
            //    return;
            var a = new dlgOrganB();
            a.dc = dc;
            a.usero = true;
            //  a.isEdit = true;
            // a.Or = cu;
            a.Text = "مشاهده پرسنل واحدها";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                // G();
            }
        }
    }
}