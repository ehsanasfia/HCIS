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
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgHistory : DevExpress.XtraEditors.XtraForm
    {
        public dlgHistory()
        {
            InitializeComponent();
        }
        public DataClasses1DataContext dc { get; set; }
        public Person EditingPerson { get; set; }
        public bool HistoryType;//برای اینکه موقع فراخوانی بدونه برای بستری سابقه رو میخواد یا سرپایی
        private void frmHistory_Load(object sender, EventArgs e)
        {
            if (EditingPerson == null) return;
            lblPersonName.Text = "نام بیمار: " + EditingPerson.FirstName + " " + EditingPerson.LastName;

            if (HistoryType)
            {
                //  var s = dc.Services.FirstOrDefault(c => c.ID == Guid.Parse("0145dd61-6226-47a9-bc79-6422771de48a"));

                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(c => c.PersonID == EditingPerson.ID).ToList();
            }
            else
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(c => c.PersonID == EditingPerson.ID).ToList();

        }

        private void پ_Click(object sender, EventArgs e)
        {
            //var mydata = from c in dc.GivenServiceMs.Where(c => c.PersonID == EditingPerson.ID)
            //             select new { c.Person.FirstName, c.Person.LastName, c.Person.NationalCode, PFName = c.Staff.Person.FirstName, PLName = c.Staff.Person.LastName, dep = c.Agenda.Department.Name, c.CreationDate, Servicename = c.ServiceCategory.Name };
            //stiReport1.RegData("mydata", mydata);
            //stiReport1.Design();
        }

        private void پ_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}