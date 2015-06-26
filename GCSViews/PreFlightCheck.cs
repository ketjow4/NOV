using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            employee_data.Items.AddRange(new object[] {"Jan Kowalski - 123456",});
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == checkBox2.Checked == checkBox3.Checked == true && employee_data.SelectedItem != null)
            {
                ReadyButton.Enabled = true;
            }
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
