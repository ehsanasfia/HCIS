
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
namespace HCISShareLibrary
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
            
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
//#if (WaterClient)
            MainClinet = Get(0);
//#elif (OliClient)
//            def = Get(6);

//#endif

            Application.Run(new Form1());

        }
        public static  Client MainClinet;
        public static Client Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new OilClass();
                default:
                    return new DefaultClass();
            }

        }
    }
}
