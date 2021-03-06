﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews
{
    public partial class PreFlightCheck : Form
    {
        private Thread thread;
        private volatile bool stop = false;

        public PreFlightCheck()
        {
            InitializeComponent();

            Utilities.ThemeManager.ApplyThemeTo(this);
            ReadyButton.Enabled = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            ReadEmployeeData("data.csv");

            AutoCheck();
            thread = new Thread(new ThreadStart(Do_AutoCheck));
            thread.Start();
        }

        public void Do_AutoCheck()
        {
            try
            {
                while(!stop)
                {
                Boolean enabled = true;
                String text = "";
                float gpsfix = 0;
                float gpshdop = 0;

                FlightData.instance.hud1.Invoke(new MethodInvoker(delegate { gpsfix =  FlightData.instance.hud1.gpsfix; gpshdop = FlightData.instance.hud1.gpshdop;}));

                if (gpsfix != 0 && gpsfix != 1 && gpshdop < 2.21)
                {
                    Gps_fix.Invoke(new MethodInvoker(delegate{ Gps_fix.BackColor = Color.Green;}));
                }
                else
                {
                    enabled = false;
                    Gps_fix.Invoke(new MethodInvoker(delegate{ Gps_fix.BackColor = Color.Red;}));
                }
                if (FlightData.instance.hud1.lowvoltagealert)
                {
                    enabled = false;
                    batteryVoltage.Invoke(new MethodInvoker(delegate { batteryVoltage.BackColor = Color.Red;}));
                }
                else
                    batteryVoltage.Invoke(new MethodInvoker(delegate { batteryVoltage.BackColor = Color.Green;}));
                
                warning_label.Invoke(new MethodInvoker(delegate { warning_label.Text = FlightData.instance.hud1.warning;
                                                              text   = warning_label.Text;}));

            if (text != "")
                enabled = false;


            if (enabled == false)
            {
                ReadyButton.Invoke(new MethodInvoker(delegate { ReadyButton.Enabled = enabled; }));
            }
            if(stop)
                break;

            Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                //silnet errors here because of no waiting to kill process before close window
                //MessageBox.Show("Transparent Label error" + ex.Message);
                // log errors
            }
        }
        

        private void ReadEmployeeData(string FilePath)
        {
            string[] allLines = File.ReadAllLines(FilePath);

            var query = from line in allLines
                        let data = line.Split(',')
                        select new
                        {
                            Name = data[0],
                            SurName = data[1],
                            ID = data[2],
                        };
            foreach (var s in query.ToList())
            {
                employee_data.Items.Add(s.Name + " " + s.SurName + " Id:" + s.ID);
            }  
        }


        private void ReadyButton_Click(object sender, EventArgs e)
        {
            SaveLogFile();
            stop = true;
            DialogResult = DialogResult.OK;
        }


        private void SaveLogFile()
        {
            String pathString = CreateLogFile();

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamWriter outfile = new StreamWriter(pathString))
            {
                outfile.WriteLine("Done Preflight check");
                outfile.WriteLine("Time: " + DateTime.Now.ToString());
                outfile.WriteLine("Employee data: " + employee_data.SelectedItem);
                outfile.WriteLine("All system are checked and ready to fly.");
                outfile.Close();
            }
            // Set the IsReadOnly property.
            fInfo.IsReadOnly = true;
        }


        private String CreateLogFile()
        {
            String folderName = "PreFlightLog";
            System.IO.Directory.CreateDirectory(folderName);

            String FileName = "ArmLog_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + 
                               DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".txt";
            String pathString = System.IO.Path.Combine(folderName, FileName);
            return pathString;
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show("Manufacturer don't take resposibility for flight without preFlight Check\n" +
                                  "Take it into consideration! (warranty is not included when flying without preFlighCheck)");

            DialogResult = DialogResult.OK;

            String pathString = CreateLogFile();
            FileInfo fInfo = new FileInfo(pathString);

            using (StreamWriter outfile = new StreamWriter(pathString))
            {
                outfile.WriteLine("Skipped Preflight check");
                outfile.WriteLine("Time: " + DateTime.Now.ToString());
                outfile.Close();
            }
            // Set the IsReadOnly property.
            fInfo.IsReadOnly = true;
        }

        private void CanBeArmed(object sender, EventArgs e)
        {
            Boolean enabled = true;
            foreach (var checkbox in this.tableLayoutPanel1.Controls)
            {
                if ((checkbox as CheckBox).Checked == false)
                {
                    enabled = false;
                }
            }

            if (!AutoCheck())
            {
                enabled = false;
            }

            object SelectedItem = new object();
            SelectedItem = employee_data.SelectedItem; 
            if (SelectedItem == null)
                enabled = false;

            ReadyButton.Enabled = enabled;
        }

        private bool AutoCheck()
        {
            Boolean enabled = true;
            if (FlightData.instance.hud1.gpsfix != 0 && FlightData.instance.hud1.gpsfix != 1 && FlightData.instance.hud1.gpshdop < 2.21)
            {
                Gps_fix.BackColor = Color.Green;
            }
            else
            {
                enabled = false;
                Gps_fix.BackColor = Color.Red;
            }
            if (FlightData.instance.hud1.lowvoltagealert)
            {
                enabled = false;
                batteryVoltage.BackColor = Color.Red;
            }
            else
                batteryVoltage.BackColor = Color.Green;
            warning_label.Text = FlightData.instance.hud1.warning;

            if (warning_label.Text != "")
                enabled = false;
            return enabled;
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Do you want to do compass calibration", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MagCalib.DoGUIMagCalib();
            }
        }
    }
}
