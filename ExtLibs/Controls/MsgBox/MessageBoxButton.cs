﻿using System;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
	public partial class MessageBoxButton : UserControl
	{
		public delegate void ButtonClickEventHandler(object sender, ButtonClickEventArgs args);
		public event ButtonClickEventHandler ButtonClick;

		private DialogResult result;

		public MessageBoxButton(string caption, DialogResult result, ButtonClickEventHandler clickHandler)
		{
			InitializeComponent();
			button1.Text = caption;
			this.result = result;
			ButtonClick += clickHandler;
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			if(ButtonClick != null)
			{
				ButtonClick(this, new ButtonClickEventArgs(result));
			}
		}
	}
}
