using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISOnCall.Data;

namespace HCISOnCall.Forms
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        HCISOnCallDataContext dc = new HCISOnCallDataContext();

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            var lst = dc.Vw_OncallRpts
                .GroupBy(x => new
                {
                    x.Year,
                    x.Month,
                    x.Day,
                    x.Speciality
                })
                .ToList()
                .Select(x => new 
                {
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Day = x.Key.Day,
                    Speciality = x.Key.Speciality,
                    lstPersons = x.Count() < 1 ? new List<string>()
                                            : (x.Count() == 1
                                                ? x.Select(c => c.Person).ToList()
                                                : x.Where(c => c.ONCall == "نفر اصلی").Select(c => c.Person).ToList().Concat(
                                                   x.Where(c => c.ONCall != "نفر اصلی").Select(c => c.Person).ToList()).ToList()
                    )
                })
                .ToList();

            var lstOnc = new List<Vw_OncallRpt>();
            foreach (var item in lst)
            {
                var oc = new Vw_OncallRpt()
                {
                    Year = item.Year,
                    Month = item.Month,
                    Day = item.Day,
                    Speciality = item.Speciality,
                    Person = ""
                };

                var i = 0;
                foreach (var prs in item.lstPersons)
                {
                    oc.Person += prs;
                    if (i != (item.lstPersons.Count - 1))
                        oc.Person += "/";
                    i++;
                }

                lstOnc.Add(oc);
            }
            vwOncallRptBindingSource.DataSource = lstOnc;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}