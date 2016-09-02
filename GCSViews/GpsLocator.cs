using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.Comms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace MissionPlanner.GCSViews
{
    public class GpsLocator
    {
        public const int READTIMEOUT = 1000;

        public delegate void GpsInfoEventHandler(object sender, PortFoundEventArgs args);
        public static event GpsInfoEventHandler GpsInfoEvent;

        public GpsLocator() { }

        public string[] BaudrateList = { "38400", "4800", "9600", "14400", "19200", "28800", "57600", "115200" };

        PointLatLng currentlocation = new PointLatLng();
        public static SerialPort ProperPort = new SerialPort();

        public static int NumberOfPortsConnected = 0;

        bool CurrentPositionPrinterRun = false;
        public static bool Found = false;

        public static int BaudIterator = 0;
        public static int PortIterator = 0;
        public static int Attempts = 0;

        public static string MessageToSend { get; private set; }
        public static string Dots = "";
        public static int DotsCounter { get; private set; }

        public string FindGpsPort()
        {
            string[] PortList = SerialPort.GetPortNames();

            while (PortIterator < PortList.Count())
            {
                while (BaudIterator < BaudrateList.Count())
                {
                    SerialPort testport = new SerialPort();
                    testport.PortName = PortList[PortIterator];

                    testport.ReadTimeout = READTIMEOUT;

                    try
                    {
                        testport.BaudRate = int.Parse(BaudrateList[BaudIterator]);
                        BaudIterator++;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        break;
                    }

                    if (BaudIterator == 7)
                    {
                        PortIterator++;
                        BaudIterator = 0;
                    }

                    try
                    {
                        Thread.Sleep(500);
                        testport.Open();
                    }
                    catch (Exception e)
                    {
                        BaudIterator--;
                        MainV2.comPort.MAV.cs.MovingBase.Lat = 0;   //if zero, position not displayed
                        MainV2.comPort.MAV.cs.MovingBase.Lng = 0;

                        continue;
                    }

                    try
                    {
                        string line = testport.ReadLine();
                        if (line.StartsWith("$GNGGA"))
                        {
                            testport.DiscardInBuffer();
                            testport.Close();
                            return testport.PortName;
                        }
                        else if (Attempts < 5)
                        {
                            BaudIterator--;
                            Attempts++;
                        }
                    }
                    catch (Exception e)
                    {
                        testport.DiscardInBuffer();
                        testport.Close();
                        //MessageBox.Show(e.Message);
                        break;
                    }
                }
            }
            return "noGPSfound";
        }

        public void portSelector()
        {
            while (!Found)
            {
                int count = SerialPort.GetPortNames().Count();
                if (count > NumberOfPortsConnected)
                {
                    ProperPort.PortName = FindGpsPort();

                    if (ProperPort.PortName == "noGPSfound")
                    {
                        NumberOfPortsConnected = SerialPort.GetPortNames().Count();
                        continue;
                    }

                    NumberOfPortsConnected = SerialPort.GetPortNames().Count();

                    Found = true;

                    ProperPort.BaudRate = int.Parse(BaudrateList[BaudIterator - 1]);
                    try
                    {
                        ProperPort.Open();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                }
                else if (count < NumberOfPortsConnected)
                {
                    if (ProperPort.IsOpen)
                        ProperPort.Close();
                    NumberOfPortsConnected = 0;
                    PortIterator = 0;
                    BaudIterator = 0;
                }
            }
        }

        private void Dotter()
        {
            DotsCounter++;
            if (DotsCounter == 5 || DotsCounter == 10 || DotsCounter == 15)
            {
                Dots += ".";
            }

            if (DotsCounter == 20)
            {
                Dots = "";
                DotsCounter = 0;
            }
        }

        public void PositionParser()
        {
            while (Found)
            {
                if (ProperPort.IsOpen)
                {
                    NumberOfPortsConnected = SerialPort.GetPortNames().Count();

                    //string line = "$GNGGA,131202.40,5016.53091,N,01840.29967,E,1,04,7.76,269.9,M,40.5,M,,*40";

                    string line;
                    try
                    {
                        line = ProperPort.ReadLine();
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        continue;
                    }

                    if (line.StartsWith("$GNGGA"))
                    {

                        string[] items = line.Trim().Split(',', '*');

                        if (items[6] == "0")
                        {
                            MainV2.comPort.MAV.cs.MovingBase.Lat = 0;   //if zero, position not displayed
                            MainV2.comPort.MAV.cs.MovingBase.Lng = 0;

                            Dotter();

                            MessageToSend = "NoFix" + Dots;
                            GpsInfoEvent(this, new PortFoundEventArgs(MessageToSend));

                            Console.WriteLine("NO FIX");
                            continue;
                        }

                        GpsInfoEvent(this, new PortFoundEventArgs("FIX OK"));

                        currentlocation.Lat = double.Parse(items[2], CultureInfo.InvariantCulture) / 100.0;
                        currentlocation.Lat = (int)currentlocation.Lat + ((currentlocation.Lat - (int)currentlocation.Lat) / 0.60);

                        if (items[3] == "S")
                            currentlocation.Lat *= -1;

                        currentlocation.Lng = double.Parse(items[4], CultureInfo.InvariantCulture) / 100.0;
                        currentlocation.Lng = (int)currentlocation.Lng + ((currentlocation.Lng - (int)currentlocation.Lng) / 0.60);

                        if (items[5] == "W")
                            currentlocation.Lng *= -1;

                        MainV2.comPort.MAV.cs.MovingBase.Lat = currentlocation.Lat;
                        MainV2.comPort.MAV.cs.MovingBase.Lng = currentlocation.Lng;
                    }
                }
                else
                {
                    ProperPort.Dispose();
                    NumberOfPortsConnected = 0;
                    PortIterator = 0;
                    BaudIterator = 0;
                    Found = false;
                    break;
                }
            }
        }

        public void CurrentPositionPrinter()
        {
            CurrentPositionPrinterRun = true;
            while (CurrentPositionPrinterRun)
            {
                portSelector();
                PositionParser();
            }
        }
    }
}
