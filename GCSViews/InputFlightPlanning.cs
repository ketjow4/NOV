using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class InputFlightPlanning : Form
    {
        private Size WindowSize { get; set; }
        private bool DotButtonEnabled { get; set; }

        public String ResultString { get; set; }
        public int Result { get; set; }

        private int MaxValue { get; set; }
        private int MinValue { get; set; }


        public InputFlightPlanning(String infoLabelText, bool dotEnabled, String initialValue, int min, int max, Size? windowSize = null)
        {
            InitializeComponent();
            if (windowSize != null)
            {
                this.WindowSize = windowSize.Value;
                this.Size = WindowSize;
            }
            InputTextBox.Text = ResultString = initialValue;
            Result = Convert.ToInt32(ResultString);
            DotButton.Enabled = dotEnabled;
            MaxValue = max;
            MinValue = min;
            MinMaxLabel.Text = "MIN " + MinValue.ToString() + " - MAX " + MaxValue.ToString();
            InfoLabel.Text = infoLabelText;
            ValidateInput();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ResultString = InputTextBox.Text;
                Result = Convert.ToInt32(ResultString);
                this.Close();
            }
            else
               CustomMessageBox.Show("Value should be in min - max boundaries", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text.Length > 0)
                InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 1);
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (!(InputTextBox.Text == "0"))
                InputTextBox.Text += "0";
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "1";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "2";
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "3";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "5";
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "6";
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            DeleteNonMeaningZero();
            InputTextBox.Text += "9";
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text += ".";
        }

        private void DeleteNonMeaningZero()
        {
            if (InputTextBox.Text == "0")
                InputTextBox.Text = "";
        }

        private bool ValidateInput()
        {
            if (InputTextBox.Text == "")
                return false;

            int temp = 0;
            try
            {
                temp = Convert.ToInt32(InputTextBox.Text);
            }
            catch(Exception ex)
            {
                return false;
            }
            
            if (temp > MaxValue || temp < MinValue)
            {
                InputTextBox.BackColor = Color.Red;
                return false;
            }
            else
            {
                InputTextBox.BackColor = Color.FromArgb(255, 255, 255, 255);
                return true;
            }
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }
    }
}
