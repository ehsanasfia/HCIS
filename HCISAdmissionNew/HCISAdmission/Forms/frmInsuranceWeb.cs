using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Threading.Tasks;

namespace HCISAdmission.Forms
{
    public partial class frmInsuranceWeb : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Insurance Ins { get; set; }
        public string NationalCode { get; set; }
        public System.Uri LastURL { get; set; }
        public bool flag { get; set; }
        public InsuracneWeb web { get; set; }
        public frmInsuranceWeb()
        {
            InitializeComponent();
        }

        private void frmInsuranceWeb_Load(object sender, EventArgs e)
        {
            web = dc.InsuracneWebs.FirstOrDefault(x => x.IDInsur == 80/* Ins.ID*/);
            if (web == null)
            {
                return;
            }
            var URL = new Uri(web.URL);
            webBrowser1.Url = URL;

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.OriginalString == "https://darman.tamin.ir/captchaCheck.aspx?pagename=")//LOGIN Page
            {
                this.WindowState = FormWindowState.Normal;
                webBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtUID").SetAttribute("value", web.UserName);
                webBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtPass").SetAttribute("value", web.PassWord);
            }
            else if (webBrowser1.Url.OriginalString == "https://darman.tamin.ir/index.aspx")
            {
                var URL = new Uri("https://darman.tamin.ir/Forms/AsnadOfficeUser/insure_war.aspx?pagename=hdpInsure_war");
                webBrowser1.Url = URL;
                this.WindowState = FormWindowState.Minimized;

            }

        }

        public bool CheckCode(string nationalcdoe)
        {
            var web = dc.InsuracneWebs.FirstOrDefault(x => x.IDInsur == 80/* Ins.ID*/);
            if (webBrowser1.Url.OriginalString == "https://darman.tamin.ir/Forms/AsnadOfficeUser/insure_war.aspx?pagename=hdpInsure_war")
            {

                webBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtNatCode").SetAttribute("value", nationalcdoe);
                webBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_btnOk").InvokeMember("click");


                while (this.webBrowser1.Document.Body.InnerHtml.Contains("ctl00_ContentPlaceHolder1_grdMain_cell0_9_Label17") == false)
                {
                    Thread.Sleep(200);
                }



                if (this.webBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_grdMain_cell0_9_Label17").GetAttribute("InnerText") == web.ConfirmText)
                    return true;

                else
                    return false;

            }

            this.WindowState = FormWindowState.Minimized;
            return false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            LastURL = webBrowser1.Url;
            webBrowser1.Url = LastURL;
        }
    }
}