using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews
{
    public partial class PreFlightCheck : Form
    {

        public PreFlightCheck()
        {
            InitializeComponent();

            Utilities.ThemeManager.ApplyThemeTo(this);
            ReadyButton.Enabled = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            ReadEmployeeData("data.csv");
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
            object SelectedItem = new object();
            SelectedItem = employee_data.SelectedItem; 
            if (SelectedItem == null)
                enabled = false;

            ReadyButton.Enabled = enabled;
        }
    }
}
