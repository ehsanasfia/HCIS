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
using System.IO;
using HealthAndFamilyReportHCIS.Data;

namespace HealthAndFamilyReportHCIS.Forms
{
    public partial class frmMap : DevExpress.XtraEditors.XtraForm
    {
        public JamiatDataContext jdc = new JamiatDataContext();
        HCISHealthDataContext hdc = new HCISHealthDataContext();
        IMPHODataContext idc = new IMPHODataContext();
        List<tmpSexPyramid> allSexPyramid;
        int[] lstIDs = new int[] { 30, 31, 32, 33, 35 };
        string[] lstNames = new string[] { "اهواز", "آبادان", "ماهشهر", "آغاجاری", "مسجد سلیمان" };

        public Tbl_ValidCenterZone SelectedZone { get; set; }

        private MapInfo mapInfo;
        private int CurrentIndex = -1;
        private string currentText = "";
        public frmMap()
        {
            InitializeComponent();
        }

        private void frmMap_Load(object sender, EventArgs e)
        {
            mapInfo = new MapInfo(Application.StartupPath + "\\IranMap.set");
            pibIran.Image = mapInfo.Main;
            tmpSexPyramidsBindingSource.DataSource = allSexPyramid = hdc.tmpSexPyramids.ToList();
        }

        private void frmMap_Shown(object sender, EventArgs e)
        {

        }

        private void pibIran_MouseMove(object sender, MouseEventArgs e)
        {

            hdc.CommandTimeout = 10 * 60;
            int Cur = mapInfo.InArea(e.X, e.Y);
            if (Cur != CurrentIndex)
            {
                CurrentIndex = Cur;
                if (CurrentIndex != -1)
                {
                    pibIran.Image = mapInfo.Hit(CurrentIndex);
                    lytMap.Text = mapInfo.GetDescription(CurrentIndex);
                    currentText = mapInfo.GetDescription(CurrentIndex);
                    Cursor = Cursors.Hand;
                    List<tmpSexPyramid> lstFiltered = null;
                    if (currentText == "خوزستان")
                    {
                        lstFiltered = allSexPyramid.Where(x => x.Zone != null && lstNames.Contains(x.Zone)).ToList();
                        chartControl1.Titles[0].Text = "هرم سن-جنسیت " + "خوزستان";

                        var city = jdc.Tbl_ValidCenterZones.FirstOrDefault(x => x.Name.Contains("اهواز"));
                        if (city != null)
                        {
                            var imphocity = idc.Tbl_ValidCenterZoneIMPHOs.FirstOrDefault(x => x.NewIDValidCenterZone == city.IDValidCenterZone);
                            if (imphocity != null)
                                spuHealthUnderMapIndexResultBindingSource.DataSource = hdc.Spu_HealthUnderMapIndex(Classes.MainModule.GetPersianDate(DateTime.Now), Classes.MainModule.GetPersianDate(DateTime.Now), null, imphocity.IDValidCenterZone);
                        }

                    }
                    else
                    {
                        lstFiltered = allSexPyramid.Where(x => x.Zone != null && x.Zone.Contains(currentText)).ToList();
                        
                        if (lstFiltered.Any())
                        {
                            chartControl1.Titles[0].Text = "هرم سن-جنسیت " + lstFiltered[0].Zone;
                        }
                        else
                        {
                            chartControl1.Titles[0].Text = "هرم سن-جنسیت";
                        }

                        var city = jdc.Tbl_ValidCenterZones.FirstOrDefault(x => x.Name.Contains(currentText));
                        if(city != null)
                        {
                            var imphocity = idc.Tbl_ValidCenterZoneIMPHOs.FirstOrDefault(x => x.NewIDValidCenterZone == city.IDValidCenterZone);
                            if (imphocity != null)
                                spuHealthUnderMapIndexResultBindingSource.DataSource = hdc.Spu_HealthUnderMapIndex(Classes.MainModule.GetPersianDate(DateTime.Now), Classes.MainModule.GetPersianDate(DateTime.Now), null, imphocity.IDValidCenterZone);
                            else
                                spuHealthUnderMapIndexResultBindingSource.DataSource = null;
                        }
                        else
                            spuHealthUnderMapIndexResultBindingSource.DataSource = null;


                    }
                    tmpSexPyramidsBindingSource.DataSource = lstFiltered;
                }
                else
                {
                    pibIran.Image = mapInfo.Main;
                    lytMap.Text = "ایران";
                    currentText = "ایران";
                    Cursor = Cursors.Default;
                    tmpSexPyramidsBindingSource.DataSource = allSexPyramid;
                    chartControl1.Titles[0].Text = "هرم سن-جنسیت ایران";
                    spuHealthUnderMapIndexResultBindingSource.DataSource = null;
                }
            }
        }

        private void pibIran_MouseLeave(object sender, EventArgs e)
        {
            pibIran.Image = mapInfo.Main;
            CurrentIndex = -1;
            lytMap.Text = "ایران";
            currentText = "ایران";
            Cursor = Cursors.Default;
            tmpSexPyramidsBindingSource.DataSource = allSexPyramid;
            chartControl1.Titles[0].Text = "هرم سن-جنسیت ایران";
        }

        private void pibIran_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(currentText);
            Tbl_ValidCenterZone zone = null;
            if (currentText == "خوزستان")
            {
                var dlg = new Dialogs.dlgSelectCity() { jdc = jdc };
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                zone = dlg.SelectedZone;
            }
            else
                zone = jdc.Tbl_ValidCenterZones.FirstOrDefault(x => x.Name != null && x.Name.Contains(currentText));
            if (zone == null)
                return;

            SelectedZone = zone;
            Close();
        }
    }

    internal class MapInfo
    {
        private Bitmap bmpMain = null;
        private Bitmap bmpSecond = null;
        private ItemMapInfo[] item;
        private Color ColorMain;

        public Bitmap Main { get { return bmpMain; } }
        public Color Color { get { return ColorMain; } }

        public MapInfo(string fileName)
        {
            string s;
            int count, i;

            using (TextReader file = new StringReader(Properties.Resources.MySet))
            {
                s = file.ReadLine();
                string[] ss = s.Split(new char[] { '\"' });
                if (ss.Length < 2 && ss[0] != "MainPicture=")
                    throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                else
                {
                    bmpMain = new Bitmap(Properties.Resources.iran_map);
                    s = file.ReadLine();
                    ss = s.Split(new char[] { '\"' });
                    if (ss.Length < 2 && ss[0] != "SecondPicture=")
                        throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                    else
                    {
                        bmpSecond = new Bitmap(Properties.Resources.MySecond);

                        s = file.ReadLine();
                        ss = s.Split(new char[] { ' ' });
                        if (ss.Length < 4 && ss[0] != "Color=")
                            throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                        else
                        {
                            ColorMain = Color.FromArgb(Byte.Parse(ss[1]), Byte.Parse(ss[2]), Byte.Parse(ss[3]));
                            s = file.ReadLine();
                            ss = s.Split(new char[] { ' ' });
                            if (ss.Length < 2 && ss[0] != "Count=")
                                throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                            else
                            {
                                count = int.Parse(ss[1], System.Globalization.NumberStyles.Integer);

                                item = new ItemMapInfo[count];

                                for (i = 0; i < count; i++)
                                {
                                    s = file.ReadLine();
                                    ss = s.Split(new char[] { ' ' });
                                    if (ss.Length < 8)
                                        throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                                    else
                                    {
                                        item[i].DrawX = int.Parse(ss[0]);
                                        item[i].DrawY = int.Parse(ss[1]);
                                        item[i].BeginX = int.Parse(ss[2]);
                                        item[i].BeginY = int.Parse(ss[3]);
                                        item[i].Width = int.Parse(ss[4]);
                                        item[i].Height = int.Parse(ss[5]);
                                        item[i].Text = ss[6];
                                        item[i].PersianText = ss[7].Replace("_", " ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public int InArea(int x, int y)
        {
            int i, j, k;
            Color c;
            k = 0;
            foreach (ItemMapInfo imi in item)
            {
                i = x - imi.DrawX;
                j = y - imi.DrawY;
                if (i >= 0 && i <= imi.Width && j >= 0 && j <= imi.Height)
                {
                    i += imi.BeginX;
                    j += imi.BeginY;
                    if (i < bmpSecond.Width && j < bmpSecond.Height)
                    {
                        c = bmpSecond.GetPixel(i, j);
                        if (c.A != 0)
                        {
                            return k;
                        }
                    }
                }
                k++;
            }
            return -1;
        }

        public Image Hit(int Index)
        {
            Bitmap bmpHelper = new Bitmap(Main);
            ItemMapInfo imi = item[Index];

            using (Graphics g = Graphics.FromImage(bmpHelper))
            {
                g.DrawImage(bmpSecond, new Rectangle(imi.DrawX, imi.DrawY, imi.Width, imi.Height),
                               imi.BeginX, imi.BeginY, imi.Width, imi.Height, GraphicsUnit.Pixel);
            }
            return bmpHelper;
        }

        internal string GetDescription(int Index)
        {
            return item[Index].PersianText;
        }
    }

    internal struct ItemMapInfo
    {
        public int DrawX, DrawY;
        public int Width, Height;
        public int BeginX, BeginY;
        public string Text, PersianText;
    }
}