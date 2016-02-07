﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public class InputBox
    {
        public delegate void ThemeManager(Control ctl);

        public static event ThemeManager ApplyTheme;

        public static string value = "";

        public static event EventHandler TextChanged;

        //from http://www.csharp-examples.net/inputbox/
        public static DialogResult Show(string title, string promptText, ref string value, bool password = false)
        {
            DialogResult answer = DialogResult.Cancel;

            InputBox.value = value;
            string passin = value;

            // ensure we run this on the right thread - mono - mac
            if (Application.OpenForms.Count > 0 && Application.OpenForms[0].InvokeRequired)
            {
                Application.OpenForms[0].Invoke((MethodInvoker)delegate
                {
                    answer = ShowUI(title, promptText, passin, password);
                });
            }
            else
            {
                answer = ShowUI(title, promptText, passin, password);
            }

            value = InputBox.value;

            return answer;
        }

        static DialogResult ShowUI(string title, string promptText, string value, bool password = false)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            if (password)
                textBox.UseSystemPasswordChar = true;
            MyButton buttonOk = new MyButton();
            MyButton buttonCancel = new MyButton();
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            //form.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            // Suspend form layout.
            form.SuspendLayout();
            const int yMargin = 10;

            //
            // label
            //
            var y = 20;
            label.AutoSize = true;
            label.Location = new Point(9, y);
            label.Size = new Size(372, 13);
            label.Text = promptText;
            label.MaximumSize = new Size(372, 0);

            //
            // textBox
            //
            textBox.Size = new Size(372, 20);
            textBox.Text = value;
            textBox.TextChanged += textBox_TextChanged;

            //
            // buttonOk
            //
            buttonOk.Size = new Size(75, 23);
            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;
            
            //
            // buttonCancel
            //
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.Text = "Cancel";
            buttonCancel.DialogResult = DialogResult.Cancel;
            
            //
            // form
            //
            form.TopMost = true;
            form.TopLevel = true;
            form.Text = title;
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            // Resume form layout
            form.ResumeLayout(false);
            form.PerformLayout();

            // Adjust the location of textBox, buttonOk, buttonCancel based on the content of the label.
            y = y + label.Height + yMargin;
            textBox.Location = new Point(12, y);
            y = y + textBox.Height + yMargin;
            buttonOk.Location = new Point(228, y);
            buttonCancel.Location = new Point(309, y);
            // Increase the size of the form.
            form.ClientSize = new Size(396, y + buttonOk.Height + yMargin);

            if (ApplyTheme != null)
                ApplyTheme(form);
            

            Console.WriteLine("Input Box " + System.Threading.Thread.CurrentThread.Name);

            Application.DoEvents();

            form.ShowDialog();

            Console.WriteLine("Input Box 2 " + System.Threading.Thread.CurrentThread.Name);

            DialogResult dialogResult = form.DialogResult;

            if (dialogResult == DialogResult.OK)
            {
                value = textBox.Text;
                InputBox.value = value;
            }

            form.Dispose();

            TextChanged = null;

            form = null;

            return dialogResult;
        }
        
        
        static void textBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }
    }



    public class InputBox2
    {
        public delegate void ThemeManager(Control ctl);

        public static event ThemeManager ApplyTheme;

        public static string value = "";


        public  static DialogResult Show(string title, string promptText, ref string value, bool password = false)
        {
            DialogResult answer = DialogResult.Cancel;

            InputBox.value = value;
            string passin = value;

            // ensure we run this on the right thread - mono - mac
            if (Application.OpenForms.Count > 0 && Application.OpenForms[0].InvokeRequired)
            {
                Application.OpenForms[0].Invoke((MethodInvoker)delegate
                {
                    answer = ShowUI(title, promptText, passin, password);
                });
            }
            else
            {
                answer = ShowUI(title, promptText, passin, password);
            }

            value = InputBox.value;

            return answer;
        }

        static DialogResult ShowUI(string title, string promptText, string value, bool password = false)
        {
            Form form = new Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            TextBox textBox = new TextBox();
            if (password)
                textBox.UseSystemPasswordChar = true;
            Controls.MyButton buttonOk = new Controls.MyButton();
            Controls.MyButton buttonCancel = new Controls.MyButton();

            form.TopMost = true;
            form.TopLevel = true;

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.Enabled = false;

            var btUp = new Controls.MyButton();
            var btDown = new Controls.MyButton();
            btUp.Text = "+1";
            btUp.Click += (sender, args) => { int temp = int.Parse(textBox.Text); temp++; textBox.Text = temp.ToString(); };
            btDown.Text = "-1";
            btDown.Click += (sender, args) => { int temp = int.Parse(textBox.Text); temp--; textBox.Text = temp.ToString(); };

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 26);
            textBox.SetBounds(12, 46, 100, 20);
            btUp.SetBounds(132, 40, 75, 23);
            btDown.SetBounds(213, 40, 75, 23);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel, btUp, btDown });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.AutoScaleMode = AutoScaleMode.None;

            if (ApplyTheme != null)
                ApplyTheme(form);

            DialogResult dialogResult = DialogResult.Cancel;

            //Console.WriteLine("Input Box " + System.Threading.Thread.CurrentThread.Name);

            Application.DoEvents();

            form.ShowDialog();

            //Console.WriteLine("Input Box 2 " + System.Threading.Thread.CurrentThread.Name);

            dialogResult = form.DialogResult;

            if (dialogResult == DialogResult.OK)
            {
                value = textBox.Text;
                InputBox.value = value;
            }

            form.Dispose();

            form = null;

            return dialogResult;
        }
    }
}
