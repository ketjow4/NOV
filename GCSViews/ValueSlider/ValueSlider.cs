using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Validators;
using System.Collections.Generic;
using MissionPlanner.Controls;
using MissionPlanner.Controls.Modification;

namespace MissionPlanner.GCSViews.ValueSlider
{
	public partial class ValueSlider : Form
	{
		IValidator<int> Validator;

        public event EventHandler<Modification.ChangeValueEventArgs<int>> OnValidValueSet;

		public int Result { get; set; }
		private bool isValid;
		Color borderColor = Color.FromArgb(100, Color.White);

		public ValueSlider(IValidator<int> validator, string infoLabelText, string initialValue)
		{
			Validator = validator;
			InitializeComponent();
			InfoLabel.Text = infoLabelText;
			InputValue.Text = initialValue;
			trackBar.MinValue = IntValidator.Min;
			trackBar.MaxValue = IntValidator.Max;
			SetFonts();

			List<Control> controls = new List<Control>() { InfoLabel, trackBar, buttonMinus10, buttonMinus1,
				buttonPlus1, buttonPlus10, ButtonCancel, ButtonOk };
			controls.ForEach(c => c.Paint += Control_Paint);
		}

		private void Control_Paint(object sender, PaintEventArgs e)
		{
			Control ctl = sender as Control;
			ControlPaint.DrawBorder(e.Graphics, ctl.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
		}

		public void SetFonts()
		{
			InputValue.Font = new Font("Century Gothic", ResolutionManager.InputTextBoxFontSize, FontStyle.Regular);
			InfoLabel.Font = InfoLabel.Font = new Font("Century Gothic", ResolutionManager.InputInfoFontSize, FontStyle.Regular);

			IEnumerable<Control> buttons1 = ControlHelpers.GetAll(tableLayoutPanel3, typeof(Button));
			IEnumerable<Control> buttons2 = ControlHelpers.GetAll(tableLayoutPanel4, typeof(Button));
			List<Control> buttonsList1 = new List<Control>(buttons1);
			List<Control> buttonsList2 = new List<Control>(buttons2);
			buttonsList1.ForEach(b => buttonsList2.Add(b));
			buttonsList2.ForEach(b =>
				b.Font = new Font("Century Gothic", ResolutionManager.InputButtonsFontSize, FontStyle.Regular));
		}

		private void buttonMinus10_Click(object sender, EventArgs e)
		{
			setValue(Result - 10);
		}

		private void buttonMinus1_Click(object sender, EventArgs e)
		{
			setValue(Result - 1);
		}

		private void buttonPlus1_Click(object sender, EventArgs e)
		{
			setValue(Result + 1);
		}

		private void buttonPlus10_Click(object sender, EventArgs e)
		{
			setValue(Result + 10);
		}

		private void trackBar_ValueChanged(object sender, EventArgs e)
		{
			setValue(trackBar.Value);
		}

		private void setValue(int value)
		{
			if (!value.ToString().Equals(InputValue.Text))
			{
				InputValue.Text = value.ToString();
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (isValid)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				NovMessageBox.Show(MessageBoxType.WARNING, MessageBoxButtons.OK, String.Format("Value should be between {0} and {1}", Min, Max), "Error");
			}	
		}

		private void InputValue_TextChanged(object sender, EventArgs e)
		{
			isValid = Validator.Validate(InputValue.Text);
			if (!isValid)
			{
				InputValue.BackColor = Color.Red;
			}
			else
			{
				InputValue.BackColor = Color.FromArgb(255, 255, 255, 255);
				Result = IntValidator.Value;
				trackBar.Value = IntValidator.Value;
                if (OnValidValueSet != null)
                    OnValidValueSet(this, new Modification.ChangeValueEventArgs<int>(Result));
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
