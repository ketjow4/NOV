using MissionPlanner.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.GCSViews.Modification;

namespace MissionPlanner.GCSViews
{
    public partial class InputFlightPlanning : Form
    {
		IValidator<int> Validator; 
        private bool DotButtonEnabled { get; set; }
		private bool isValid;

        public event EventHandler<ChangeValueEventArgs<int>> OnValidValueSet;

        public int Result { get; set; }
		
        public InputFlightPlanning(IValidator<int> validator, String infoLabelText, bool dotEnabled, String initialValue,Size? windowSize = null)
        {
			Validator = validator;
            InitializeComponent();
            InputTextBox.Text = initialValue;
            DotButton.Enabled = dotEnabled;
            MinMaxLabel.Text = "MIN " + Min.ToString() + " - MAX " + Max.ToString();
            InfoLabel.Text = infoLabelText;
            SetFonts();
        }

        public void SetFonts()
        {
            InputTextBox.Font = new Font("Century Gothic", ResolutionManager.InputTextBoxFontSize, FontStyle.Regular);
            MinMaxLabel.Font = InfoLabel.Font = new Font("Century Gothic", ResolutionManager.InputInfoFontSize, FontStyle.Regular);

            foreach(var element in this.tableLayoutPanel1.Controls)
            {
                if(element is Button)
                    (element as Button).Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular);
            }
            foreach (var element in this.tableLayoutPanel2.Controls)
            {
                if (element is Button)
                    (element as Button).Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (isValid)
            {
				DialogResult = DialogResult.OK;
				Close();
            }
            else
               CustomMessageBox.Show(String.Format("Value should be between {0} and {1}", Min, Max), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
			Close();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text.Length > 0)
			{
				InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 1);
			}
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
			write("0");
		}

        private void OneButton_Click(object sender, EventArgs e)
        {
			write("1");
		}

        private void TwoButton_Click(object sender, EventArgs e)
        {
			write("2");
		}

        private void ThreeButton_Click(object sender, EventArgs e)
        {
			write("3");
		}

        private void FourButton_Click(object sender, EventArgs e)
        {
			write("4");
		}

        private void FiveButton_Click(object sender, EventArgs e)
        {
			write("5");
		}

        private void SixButton_Click(object sender, EventArgs e)
        {
			write("6");
		}

        private void SevenButton_Click(object sender, EventArgs e)
        {
			write("7");
		}

        private void EightButton_Click(object sender, EventArgs e)
        {
			write("8");
		}

        private void NineButton_Click(object sender, EventArgs e)
        {
			write("9");
		}

        private void DotButton_Click(object sender, EventArgs e)
        {
            write(".");
        }

        private void DeleteNonMeaningZero()
        {
            if (InputTextBox.Text == "0")
                InputTextBox.Text = "";
        }

		private void write(string value)
		{
			DeleteNonMeaningZero();
			InputTextBox.Text += value;
		}

		private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
			isValid = Validator.Validate(InputTextBox.Text);
			if (!isValid)
			{
				InputTextBox.BackColor = Color.Red;
			}
			else
			{
				InputTextBox.BackColor = Color.FromArgb(255, 255, 255, 255);
				Result = IntValidator.Value;
                if (OnValidValueSet != null)
                    OnValidValueSet(this, new ChangeValueEventArgs<int>(Result));
			}
        }

		public NumericValidator<int> IntValidator
		{
			get
			{
				return Validator as NumericValidator<int>;
			}
		}

		public Size WindowSize
		{
			get
			{
				return Size;
			}
			set
			{
				Size = WindowSize;
			}
		}

		public int Min
		{
			get
			{
				return IntValidator.Min;
			}
		}

		public int Max
		{
			get
			{
				return IntValidator.Max;
			}
		}
	}
}
