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

namespace HCISNurse.Dialogs
{
    public partial class dlgForm7Detail : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public QA cur { get; set; }

        public bool isPhysic = false;
        public bool isFeed = false;
        public bool isHeart = false;

        public dlgForm7Detail()
        {
            InitializeComponent();
        }

        private void dlgForm7Detail_Load(object sender, EventArgs e)
        {
            List<string> lst1 = new List<string>();
            List<string> lst2 = new List<string>();
            if(isPhysic)
            {
                lst1.Add("کم");
                lst1.Add("متوسط");
                lst1.Add("زیاد");
                lst1.Add("ارزیابی نشده است.");
            }
            if (isFeed)
            {
                lst1.Add("سالم");
                lst1.Add("در معرض خطر");
                lst1.Add("ناسالم");
                lst1.Add("ارزیابی نشده است.");

                lst2.Add("ارجاع به پزشک");
                lst2.Add("ارجاع به کارشناس تغذیه");
                lst2.Add("آموزش، مراقبت و پیگیری");
            }
            if (isHeart)
            {
                lst1.Add("1");
                lst1.Add("0");
                lst1.Add("ارزیابی نشده است.");
            }

            cmbResult.Properties.Items.AddRange(lst1);
            cmbNextAction.Properties.Items.AddRange(lst2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtDiagnosis.Text) && !string.IsNullOrWhiteSpace(cmbNextAction.Text) && !string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "تشخیص احتمالی: " + txtDiagnosis.Text + " " + "اقدام بعدی: " + cmbNextAction.Text + " " + "نتیجه معاینات: " + cmbResult.Text;

            if (!string.IsNullOrWhiteSpace(txtDiagnosis.Text) && !string.IsNullOrWhiteSpace(cmbNextAction.Text) && string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "تشخیص احتمالی: " + txtDiagnosis.Text + " " + "اقدام بعدی: " + cmbNextAction.Text;

            if (!string.IsNullOrWhiteSpace(txtDiagnosis.Text) && string.IsNullOrWhiteSpace(cmbNextAction.Text) && !string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "تشخیص احتمالی: " + txtDiagnosis.Text + " " + "نتیجه معاینات: " + cmbResult.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text) && !string.IsNullOrWhiteSpace(cmbNextAction.Text) && !string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "اقدام بعدی: " + cmbNextAction.Text + " " + "نتیجه معاینات: " + cmbResult.Text;

            if (!string.IsNullOrWhiteSpace(txtDiagnosis.Text) && string.IsNullOrWhiteSpace(cmbNextAction.Text) && string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "تشخیص احتمالی: " + txtDiagnosis.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text) && !string.IsNullOrWhiteSpace(cmbNextAction.Text) && string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "اقدام بعدی: " + cmbNextAction.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text) && string.IsNullOrWhiteSpace(cmbNextAction.Text) && !string.IsNullOrWhiteSpace(cmbResult.Text))
                cur.Description = "نتیجه معاینات: " + cmbResult.Text;

            DialogResult = DialogResult.OK;
        }
    }
}