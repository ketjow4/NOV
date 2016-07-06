using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MissionPlanner.Controls.Modification;
using MissionPlanner.Controls;
using MissionPlanner.Validators;
using System.Runtime.InteropServices;

namespace MissionPlanner.GCSViews
{
    public partial class PreFlightCheck : Form, INotifyPropertyChanged
    {
        private double gpsfix;
        private double gpshdop;
        private string warningText;
        private bool lowVoltageWarning;

        public double Gpsfix
        {
            get
            {
                return gpsfix;
            }

            set
            {
                gpsfix = value;
                OnPropertyChanged("Gpsfix");
            }
        }

        public double Gpshdop
        {
            get
            {
                return gpshdop;
            }

            set
            {
                gpshdop = value;
                OnPropertyChanged("Gpshdop");
            }
        }

        public string WarningText
        {
            get
            {
                return warningText;
            }

            set
            {
                warningText = value;
                OnPropertyChanged("WarningText");
            }
        }

        public bool LowVoltageWarning
        {
            get
            {
                return lowVoltageWarning;
            }

            set
            {
                lowVoltageWarning = value;
                OnPropertyChanged("LowVoltageWarning");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public PreFlightCheck()
        {
            InitializeComponent();
            
            Utilities.ThemeManager.ApplyThemeTo(this);
            ReadyButton.Enabled = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            DataBindings.Add(new Binding("Gpshdop", FlightData.instance.bindingSource1, "gpshdop", true));
            DataBindings.Add(new Binding("Gpsfix", FlightData.instance.bindingSource1, "gpsstatus", true));
            DataBindings.Add(new Binding("WarningText", FlightData.instance.hud1.data, "warning", true));
            DataBindings.Add(new Binding("LowVoltageWarning", FlightData.instance.hud1.data, "lowvoltagealert", true));
            warning_label.DataBindings.Add(new Binding("Text", FlightData.instance.hud1.data, "warning", true));

            ReadEmployeeData("data.csv");

            PropertyChanged += AutoCheck;

            this.Size = ResolutionManager.PreFlightCheckSize;
            SetFonts();
        }


        private void SetFonts()
        {
            Font ButtonFont = new Font("Century Gothic", ResolutionManager.PreFlightCheckFontButton, FontStyle.Regular);
            Font CheckBoxFont = new Font("Century Gothic", ResolutionManager.PreFlightCheckFontCheckBox, FontStyle.Regular);
            foreach (var element in this.tableLayoutPanel1.Controls)
            {
                if (element is MyButton)
                    (element as MyButton).Font = ButtonFont;
            }
            foreach (var element in this.tableLayoutPanel3.Controls)
            {
                if (element is MyButton)
                    (element as MyButton).Font = ButtonFont;
            }
            foreach (var element in this.tableLayoutPanel4.Controls)
            {
                if (element is MyButton)
                    (element as MyButton).Font = ButtonFont;
            }
            foreach (var checkbox in this.CheckBoxTableLayout.Controls)
            {
                (checkbox as CheckBox).Font = CheckBoxFont;
            }
            EmployeeLabel.Font = CheckBoxFont;      //this font is used because is the same as for checkbox
            employee_data.Font = ButtonFont;         //this font is used because is the same as for buttons
            warning_label.Font = new Font("Century Gothic", ResolutionManager.PreFlightCheckFontWarning, FontStyle.Regular); 
        }

        private void ReadEmployeeData(string FilePath)
        {
            StreamReader sr = new StreamReader("Amplify.rex");
            String sSecretKey = sr.ReadToEnd().Trim();

            byte[] tempforhex = Decryption.FromHex(sSecretKey);
            string keyinascii = Encoding.ASCII.GetString(tempforhex);

            GCHandle gch = GCHandle.Alloc(keyinascii, GCHandleType.Pinned);

            string[] allLines = Decryption.DecryptFile("data.rex", keyinascii);
            allLines = allLines.Take(allLines.Length - 1).ToArray();

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
            StreamReader sr = new StreamReader("Amplify.rex");
            String sSecretKey = sr.ReadToEnd().Trim();

            byte[] tempforhex = Decryption.FromHex(sSecretKey);
            string keyinascii = Encoding.ASCII.GetString(tempforhex);

            GCHandle gch = GCHandle.Alloc(keyinascii, GCHandleType.Pinned);
            
            string[] allLines = Decryption.DecryptFile("data.rex", keyinascii);

            var query = from line in allLines
                        let data = line.Split(',')
                        select new
                        {
                            ID = data[2],
                            PIN = data[3]
                        };

            var intValidator = new NumericValidator<int>(0, 9999);
            InputFlightPlanning<int> pinForm = new InputFlightPlanning<int>(intValidator, "ENTER PIN", false, "",'*');
            this.Hide();
            pinForm.ShowDialog();
            int result;
            int temp = employee_data.SelectedItem.ToString().LastIndexOf(":");
            int.TryParse(employee_data.SelectedItem.ToString().Substring(temp+1),out result);   //+1 bo następny znak za znakiem ':'

            var b = query.Where(a => a.ID == result.ToString());

            if (b.FirstOrDefault() != null)
                if (pinForm.Result.ToString() != b.FirstOrDefault().PIN)
                {
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            SaveLogFile();
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
            fInfo.IsReadOnly = true;
        }

        private void CanBeArmed(object sender, EventArgs e)
        {
            Boolean enabled = true;
            foreach (var checkbox in this.CheckBoxTableLayout.Controls)
            {
                if ((checkbox as CheckBox).Checked == false)
                {
                    enabled = false;
                    break;
                }
            }

            object SelectedItem = new object();
            SelectedItem = employee_data.SelectedItem; 
            if (SelectedItem == null)
                enabled = false;

            ReadyButton.Enabled = enabled;
        }

        private void AutoCheck(object obj, PropertyChangedEventArgs e)
        {
            Boolean enabled = true;

            if (gpsfix != 0 && gpsfix != 1 && gpshdop < 2.21)
            {
                GPSFixToGreen();
                enabled = true;
            }
            else
            {
                GPSFixToRed();
                enabled = false;
            }
            if (warning_label.Text != "")
                enabled = false;
            else
                enabled = true;
            if(LowVoltageWarning)
                enabled = false;
            else
                enabled = true;
            ReadyButton.Enabled = enabled;
        }

        private void CompassCalibrationButton_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Do you want to do compass calibration", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MagCalib.DoGUIMagCalib();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreFlightCheck_Load(object sender, EventArgs e)
        {
            Location = new Point(Location.X, Location.Y + 50);

            BatteryVolToRed();
            GPSFixToRed();
        }

        private void GPSFixToRed()
        {
            GPSFix.BGGradBot = Color.Red;
            GPSFix.BGGradTop = Color.Red;
            GPSFix.Outline = Color.Red;
        }

        private void GPSFixToGreen()
        {
            GPSFix.BGGradBot = Color.Green;
            GPSFix.BGGradTop = Color.Green;
            GPSFix.Outline = Color.Green;
        }

        private void BatteryVolToRed()
        {
            BatteryVol.BGGradBot = Color.Red;
            BatteryVol.BGGradTop = Color.Red;
            BatteryVol.Outline = Color.Red;
        }

        private void BatteryVolToGreen()
        {
            BatteryVol.BGGradBot = Color.Green;
            BatteryVol.BGGradTop = Color.Green;
            BatteryVol.Outline = Color.Green;
        }
    }
}
