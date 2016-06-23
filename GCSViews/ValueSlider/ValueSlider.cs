using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Validators;
using System.Windows.Threading;

namespace MissionPlanner.GCSViews.ValueSlider
{
	public partial class ValueSlider : Form
	{
		IValidator<int> Validator;

        public event EventHandler<Modification.ChangeValueEventArgs<int>> OnValidValueSet;

		public int Result { get; set; }
		private bool isValid;
		
		public ValueSlider(IValidator<int> validator, string infoLabelText, string initialValue)
		{
			Validator = validator;
			InitializeComponent();
			InfoLabel.Text = infoLabelText;
			InputValue.Text = initialValue;
			trackBar.MinValue = IntValidator.Min;
			trackBar.MaxValue = IntValidator.Max;
			SetFonts();
		}
		
		public void SetFonts()
		{
			InputValue.Font = new Font("Century Gothic", Modification.ResolutionManager.InputTextBoxFontSize, FontStyle.Regular);
			InfoLabel.Font = InfoLabel.Font = new Font("Century Gothic", Modification.ResolutionManager.InputInfoFontSize, FontStyle.Regular);

			TableLayoutPanel[] panels = new TableLayoutPanel[] {
				tableLayoutPanel3,
				tableLayoutPanel4
			};

			foreach(TableLayoutPanel panel in panels)
			{
				foreach (var element in panel.Controls)
				{
					if (element is Button)
					{
						(element as Button).Font = new Font("Century Gothic", Modification.ResolutionManager.InputButtonsFontSize, FontStyle.Regular);
					}
				}
			}
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
				CustomMessageBox.Show(String.Format("Value should be between {0} and {1}", Min, Max), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
