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
using HCISEmail.Data;
using DevExpress.XtraEditors.DXErrorProvider;
using SecurityLoginsAndAccessControl;
using HCISEmail.Classes;
using System.IO;

namespace HCISEmail.Dialog
{
    public partial class dlgNewUser : DevExpress.XtraEditors.XtraForm
    {
        public EmaildbDataContext dc { get; set; }
        public HCISEmail.Data.User EditingUser { get; set; } // useri ke mikhaym virayesh konim

        public bool isEdit { get; set; } // agar true bashad yani virayesh dar qeyre in sorat sabte jadid
        public dlgNewUser()
        {
            InitializeComponent();
        }

        private void btnnjadid_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (isEdit == false)
                {
                    //in ghesmat baraye sabte jadid
                    var NewUser = new HCISEmail.Data.User()
                    {
                        NationalCode = txtCodemeli.Text,
                        FName = txtFname.Text,
                        LName = txtLname.Text,
                        Address = mmdAdres.Text,
                        BirthDay = txtBirth.Text,
                        Mobile = txtTnumber.Text,
                        Email = txtAdresE.Text,
                        GenderID = (lkpJensiyat.EditValue as int?) == null ? null as int? : dc.Definitions.FirstOrDefault(x => x.IDDefinition == (lkpJensiyat.EditValue as int?)).IDDefinition,
                        CityID = (lkpShahr.EditValue as int?) == null ? null as int? : dc.Cities.FirstOrDefault(x => x.IDCity == (lkpShahr.EditValue as int?)).IDCity,
                        EducationID = (lkpCodtahsilat.EditValue as int?) == null ? null as int? : dc.Definitions.FirstOrDefault(x => x.IDDefinition == (lkpCodtahsilat.EditValue as int?)).IDDefinition,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm")
                    };
                    if (pic1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            NewUser.Avatar = binary;
                        }
                    }
                    else
                        NewUser.Avatar = null;
                    dc.Users.InsertOnSubmit(NewUser);
                    dc.SubmitChanges();
                    var main = new HCISEmail.Form.frmMain();
                    var f = new frmManageUsers(MainModule.UserName, main.Name, main.ribbonControl1, "HCISEmail");
                    f.btnNewUser_Click(null, null);
                    HCISEmail.Data.SecDataContext sequrity = new SecDataContext();
                    var app = sequrity.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISEmail");
                    var user = sequrity.tblUsers.FirstOrDefault(x => x.UserName == f.UserName && x.ApplicationID == app.ApplicationID);
                    NewUser.SecurityUserID = user.UserID;
                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                if (isEdit == true)
                {
                    // virayesh
                    EditingUser.FName = txtFname.Text;
                    EditingUser.LName = txtLname.Text;
                    EditingUser.Mobile = txtTnumber.Text;
                    EditingUser.Email = txtAdresE.Text;
                    EditingUser.GenderID = (lkpJensiyat.EditValue as Definition) == null ? null as int? : dc.Definitions.FirstOrDefault(x => x.IDDefinition == (lkpJensiyat.EditValue as Definition).IDDefinition).IDDefinition;
                    EditingUser.CityID = (lkpShahr.EditValue as City) == null ? null as int? : dc.Cities.FirstOrDefault(x => x.IDCity == (lkpShahr.EditValue as City).IDCity).IDCity;
                    EditingUser.EducationID = (lkpCodtahsilat.EditValue as Definition) == null ? null as int? : dc.Definitions.FirstOrDefault(x => x.IDDefinition == (lkpCodtahsilat.EditValue as Definition).IDDefinition).IDDefinition;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GetData()
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 1).ToList();
            definitionBindingSource1.DataSource = dc.Definitions.Where(x => x.ParentID == 4).ToList();
            cityBindingSource.DataSource = dc.Cities.ToList();
        }

        private void frmNew_Load(object sender, EventArgs e)
        {
            GetData();
            //baraye inke az chekbox estefade nakonim...
            // dar avaz kenare harfild alamati miyad ta karbar fild ro por kond
            ConditionValidationRule rangeValidationRule = new ConditionValidationRule();
            rangeValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            rangeValidationRule.ErrorType = ErrorType.Critical;
            rangeValidationRule.ErrorText = "این فیلد را پرکنید";
            dxValidationProvider1.SetValidationRule(txtBirth, rangeValidationRule);
            dxValidationProvider1.SetValidationRule(txtFname, rangeValidationRule);
            dxValidationProvider1.SetValidationRule(txtLname, rangeValidationRule);
            dxValidationProvider1.SetValidationRule(txtCodemeli, rangeValidationRule);

            if (isEdit)
            {
                //braye inke karbar dar sorate virayesh betavanad name qabli khod ra bbinad.
                txtFname.Text = EditingUser.FName;
                txtLname.Text = EditingUser.LName;
                lkpJensiyat.EditValue = EditingUser.GenderID;
                txtAdresE.Text = EditingUser.Address;
                txtBirth.Text = EditingUser.BirthDay;
                txtTnumber.Text = EditingUser.Mobile;
                lkpShahr.EditValue = EditingUser.City;
                txtCodemeli.Text = EditingUser.NationalCode;
                lkpCodtahsilat.EditValue = EditingUser.EducationID;
                lkpJensiyat.EditValue = EditingUser.GenderID;
                lkpShahr.EditValue = EditingUser.CityID;
                if (EditingUser.Avatar != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var data = EditingUser.Avatar.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pic1.Image = Image.FromStream(ms);
                    }
                }
                else
                    pic1.Image = null;
            }
        }
    }
}