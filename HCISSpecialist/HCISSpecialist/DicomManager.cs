using HCISSpecialist.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HCISSpecialist
{
    public class DicomManager
    {
        private static string CacheDir = null;

        private static void init()
        {
            CacheDir = @"Cache\";
            if (!Directory.Exists(CacheDir))
            {
                Directory.CreateDirectory(CacheDir);
            }
        }

        public static List<Series> GetSeries(string StudyID)
        {
            if (string.IsNullOrWhiteSpace(CacheDir))
                init();
            //var cacheStudyInfo = GetCacheStudyInfo(StudyID);
            var serverStudyInfo = GetServerStudyInfo(StudyID);
            var lstSeries = ExtractXML(serverStudyInfo, StudyID);
            
            FillWithImage(lstSeries, StudyID);

            return lstSeries;
        }


        private static string GetCacheStudyInfo(string StudyID)
        {
            if (Directory.Exists(CacheDir + StudyID))
            {
                if (File.Exists(CacheDir + StudyID + @"\" + StudyID + ".xml"))
                {
                    var str = File.ReadAllText(CacheDir + StudyID + @"\" + StudyID + ".xml");
                    return str;
                }
                else
                    return null;
            }
            else
                return null;
        }

        private static string GetServerStudyInfo(string StudyID)
        {
            string info = string.Empty;
            string url = @"http://172.30.1.145/aminapi/api/DicomManager/GetStudyInfoFile?StudyID=" + StudyID;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                info = reader.ReadToEnd();
            }

            return info;
        }

        private static List<Series> ExtractXML(string xml, string StudyID)
        {
            List<Series> lstSeries = new List<Series>();
            var doc = XElement.Parse(xml);
            var xstudy = doc.Element("Study");
            foreach (XElement xsri in xstudy.Elements("Series"))
            {
                var sri = new Series()
                {
                    Instances = new List<Instance>(),
                    UID = xsri.Attribute("UID").Value
                };

                foreach (var xinst in xsri.Element("BaseInstance").Elements("Instance"))
                {
                    var a = xinst.Elements("Attribute").FirstOrDefault(x => x.Attributes("Tag").FirstOrDefault(c => c.Value == "00080020") != null);
                    if (a != null)
                    {
                        sri.StudyDate = a.Value;
                        break;
                    }
                }
                
                int i = 0;
                foreach (var xinst in xsri.Elements("Instance"))
                {
                    var inst = new Instance()
                    {
                        InstanceUID = xinst.Attribute("UID").Value,
                        RelativeIndex = i,
                        Series = sri
                    };
                    sri.Instances.Add(inst);
                    i++;
                }

                lstSeries.Add(sri);
            }


            return lstSeries;
        }

        private static void FillWithImage(List<Series> lstSeries, string StudyID)
        {
            List<Task> lstTasks = new List<Task>();
            foreach (var sri in lstSeries)
            {
                foreach (var inst in sri.Instances)
                {
                    string localDir = CacheDir + StudyID;
                    string localPath = localDir + @"\" + inst.InstanceUID + ".png";
                    if (Directory.Exists(localDir))
                    {
                        if (File.Exists(localPath))
                        {
                            //inst.Bitmap = new Bitmap(localPath);
                            inst.PNGLocalPath = localPath;
                            continue;
                        }
                    }

                    using (var client = new WebClient())
                    {
                        client.DownloadFileAsync(new Uri(@"http://172.30.1.145/aminapi/api/DicomManager/GetConvertedInstancePNG?StudyID=" + StudyID), localPath);
                        client.DownloadFileCompleted += (s, a) => inst.PNGLocalPath = localPath;
                    }
                }
            }
            
        }
    }
}
