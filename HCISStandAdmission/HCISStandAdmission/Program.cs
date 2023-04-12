using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Drawing;

namespace HCISStandAdmission
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 12, FontStyle.Bold);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            var dlg = new Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                Application.Run(new Forms.frmMani());
        }
    }
}
