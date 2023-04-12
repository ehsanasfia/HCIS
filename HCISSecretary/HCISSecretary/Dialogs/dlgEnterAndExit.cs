using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;
using HCISSecretary.Classes;

namespace HCISSecretary.Dialogs
{
    public partial class dlgEnterAndExit : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Person Doc { get; set; }
        public string today { get; set; }
        public dlgEnterAndExit()
        {
            InitializeComponent();
        }

        private void dlgEnterAndExit_Load(object sender, EventArgs e)
        {


            if (MainModule.UserName == "l.bahrami")
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            txtFirstVisit.Text = dc.GivenServiceMs.Where(x => x.Agenda.Date == today && x.Agenda.StaffID == Doc.ID && x.ServiceCategoryID == (int)Category.ویزیت && x.SendToDr == true).Min(x => x.SendToDrTime);
            txtLastVisit.Text = dc.GivenServiceMs.Where(x => x.Agenda.Date == today && x.Agenda.StaffID == Doc.ID && x.ServiceCategoryID == (int)Category.ویزیت && x.SendToDr == true).Max(x => x.SendToDrTime);
            txtFirstDrug.Text = dc.GivenServiceMs.Where(x => x.RequestStaffID == Doc.ID && x.ServiceCategoryID == (int)Category.دارو && x.CreationDate == today).Min(x => x.CreationTime);
            txtLastDrug.Text = dc.GivenServiceMs.Where(x => x.RequestStaffID == Doc.ID && x.ServiceCategoryID == (int)Category.دارو && x.CreationDate == today).Max(x => x.CreationTime);
            List<ArrivalsAndDeparture> enter = new List<ArrivalsAndDeparture>();
            enter = dc.ArrivalsAndDepartures.Where(x => x.StaffID == Doc.ID && x.Date == today).ToList();
            if (enter.Any())
            {
                if (!string.IsNullOrWhiteSpace(enter.FirstOrDefault().EnterTime))
                {
                    txtEnter.Text = enter.FirstOrDefault().EnterTime;
                    txtEnter.ReadOnly = true;
                    layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //txtExit.Text = DateTime.Now.ToString("HH:mm");
                    //txtExit.Select();
                }
                if (!string.IsNullOrWhiteSpace(enter.FirstOrDefault().ExitTime))
                {
                    txtExit.Text = enter.FirstOrDefault().ExitTime;
                    layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    txtExit.ReadOnly = true;
                }
            }
            else
            {
                //txtEnter.Text = DateTime.Now.ToString("HH:mm");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtEnter.Text) && !string.IsNullOrEmpty(txtExit.Text))
            //{
            //    MessageBox.Show(".ساعت ورود و خروج پزشک ثبت شده است");
            //    return;
            //}
            //List<ArrivalsAndDeparture> enter = new List<ArrivalsAndDeparture>();
            //enter = dc.ArrivalsAndDepartures.Where(x => x.StaffID == Doc.ID && x.Date == today).ToList();
            //if (dc.ArrivalsAndDepartures.Any(x => x.Date == today && ((x.EnterTime != null | x.EnterTime != "") | (x.ExitTime != null | x.EnterTime != "")) && x.StaffID == Doc.ID))
            //{
            //    enter.FirstOrDefault().EnterTime = txtEnter.Text;
            //    enter.FirstOrDefault().ExitTime = txtExit.Text;
            //    enter.FirstOrDefault().LastModifator = MainModule.UserID;
            //    enter.FirstOrDefault().LastModificationDate = today;
            //    enter.FirstOrDefault().LastModificationTime = DateTime.Now.ToString("HH:mm");
            //    dc.SubmitChanges();
            //    DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    var arrive = new ArrivalsAndDeparture()
            //    {
            //        Date = today,
            //        EnterTime = txtEnter.Text,
            //        ExitTime = txtExit.Text,
            //        CreatorUserID = MainModule.UserID,
            //        CreationDate = today,
            //        CreationTime = DateTime.Now.ToString("HH:mm"),
            //        StaffID = Doc.ID
            //    };
            //    dc.ArrivalsAndDepartures.InsertOnSubmit(arrive);
            //    dc.SubmitChanges();
            //    DialogResult = DialogResult.OK;
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var enter = dc.ArrivalsAndDepartures.FirstOrDefault(x => x.StaffID == Doc.ID && x.Date == today);
            if (enter != null)
            {
                if (string.IsNullOrWhiteSpace(enter.EnterTime))
                {
                    txtEnter.Text = DateTime.Now.ToString("HH:mm");
                    enter.EnterTime = txtEnter.Text;
                    dc.SubmitChanges();
                    txtEnter.ReadOnly = true;
                    layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                }
                else
                {
                    enter.EnterTime = txtEnter.Text;
                    dc.SubmitChanges();
                    txtEnter.ReadOnly = true;
                    layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                }
            }
            else
            {
                txtEnter.Text = DateTime.Now.ToString("HH:mm");
                var arrive = new ArrivalsAndDeparture()
                {
                    Date = today,
                    EnterTime = txtEnter.Text,
                    ExitTime = txtExit.Text,
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    StaffID = Doc.ID
                };
                dc.ArrivalsAndDepartures.InsertOnSubmit(arrive);
                dc.SubmitChanges();
                txtEnter.ReadOnly = true;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var enter = dc.ArrivalsAndDepartures.FirstOrDefault(x => x.StaffID == Doc.ID && x.Date == today);
            if (enter != null)
            {
                if (string.IsNullOrWhiteSpace(enter.ExitTime))
                {
                    txtExit.Text = DateTime.Now.ToString("HH:mm");
                    enter.ExitTime = txtExit.Text;
                    dc.SubmitChanges();
                    layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    txtExit.ReadOnly = true;
                }
                else
                {
                    enter.ExitTime = txtExit.Text;
                    dc.SubmitChanges();
                    layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    txtExit.ReadOnly = true;
                }
            }
            else
            {
                txtExit.Text = DateTime.Now.ToString("HH:mm");
                var arrive = new ArrivalsAndDeparture()
                {
                    Date = today,
                    EnterTime = txtEnter.Text,
                    ExitTime = txtExit.Text,
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    StaffID = Doc.ID
                };
                dc.ArrivalsAndDepartures.InsertOnSubmit(arrive);
                dc.SubmitChanges();
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                txtExit.ReadOnly = true;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            txtExit.ReadOnly = false;

            txtEnter.ReadOnly = false;
            layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }
    }
}