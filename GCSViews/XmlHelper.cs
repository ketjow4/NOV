using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MissionPlanner.GCSViews
{
    class XmlHelper
    {
        public struct camerainfo
        {
            public string name;
            public float focallen;
            public float sensorwidth;
            public float sensorheight;
            public float imagewidth;
            public float imageheight;
        }

        static public Dictionary<string, camerainfo> cameras = new Dictionary<string, camerainfo>();

        static public void ReadCameraName(string filename = "noveltyCam.xml")
        {
            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + filename))
                {
                    while (xmlreader.Read())
                    {
                        xmlreader.MoveToElement();
                        try
                        {
                            switch (xmlreader.Name)
                            {
                                case "Camera":
                                    {
                                        camerainfo camera = new camerainfo();

                                        while (xmlreader.Read())
                                        {
                                            bool dobreak = false;
                                            xmlreader.MoveToElement();
                                            switch (xmlreader.Name)
                                            {
                                                case "name":
                                                    camera.name = xmlreader.ReadString();
                                                    break;
                                                case "imgw":
                                                    camera.imagewidth = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                    break;
                                                case "imgh":
                                                    camera.imageheight = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                    break;
                                                case "senw":
                                                    camera.sensorwidth = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                    break;
                                                case "senh":
                                                    camera.sensorheight = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                    break;
                                                case "flen":
                                                    camera.focallen = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                    break;
                                                case "Camera":
                                                    cameras[camera.name] = camera;
                                                    dobreak = true;
                                                    break;
                                            }
                                            if (dobreak)
                                                break;
                                        }
                                        string temp = xmlreader.ReadString();
                                    }
                                    break;
                                case "Config":
                                    break;
                                case "xml":
                                    break;
                                default:
                                    if (xmlreader.Name == "") // line feeds
                                        break;
                                    //config[xmlreader.Name] = xmlreader.ReadString();
                                    break;
                            }
                        }
                        catch (Exception ee) { Console.WriteLine(ee.Message); } // silent fail on bad entry

                    }

                }
            }
            catch (Exception ee) { Console.WriteLine(ee.Message); }
        } 
    }
}
