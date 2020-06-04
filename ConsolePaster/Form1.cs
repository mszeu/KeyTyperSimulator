﻿// PROGRAM NAME:     
//      KeyTyper Simulator

// DESCRIPTION:
//     The program switches to the indicated process and simulate typing a sequence of 
//     characters as when they are typed using the keyboard with a selectable frequency.

//    Copyright(C) 2020  Marco S. Zuppone - msz@msz.eu- http://msz.eu

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Affero General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or any later version.

//   This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU Affero General Public License for more details.

//    You should have received a copy of the GNU Affero General Public License
//    along with this program.If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace KeyTyperSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MandaCaratteri(string daMandare)
        {
            DialogResult dAnswer = DialogResult.OK;


            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                dAnswer = MessageBox.Show("CAPS Lock is enabled. The characters case sent to the application will be inverted",
                    "ATTENTION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (dAnswer == DialogResult.OK)
            {
                try
                {
                    if (!checkBoxHasFocus.Checked)
                    {

                        try
                        {
                            Microsoft.VisualBasic.Interaction.AppActivate(textApp.Text);
                            toolStripStatusLastError.Text = "";
                        }
                        catch (Exception ex) { toolStripStatusLastError.Text = ex.Message + " sending to process that has focus"; }
                    }
                    else
                    { 
                        toolStripStatusLastError.Text = "";
                    }
                    Thread.Sleep(trackBarInitialDelay.Value);
                    foreach (char carattere in daMandare)
                    {
                        SendKeys.SendWait(carattere.ToString());
                        Thread.Sleep(trackBarTypeFreq.Value);

                    }
                    if (checkBoxEnter.Checked)
                    {
                        SendKeys.SendWait("{ENTER}");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Error");
                }
            }
        }
      
       
       
        private void trackBar1_Scroll(object sender, EventArgs e) => labelTypeFreq.Text = trackBarTypeFreq.Value.ToString() + " ms";

        private void trackBar2_Scroll(object sender, EventArgs e) => labelInitialDelay.Text = trackBarInitialDelay.Value.ToString() + " ms";

        private void button1_Click(object sender, EventArgs e) => MandaCaratteri(textBox1.Text);
        private void button2_Click(object sender, EventArgs e) => MandaCaratteri(textBox2.Text);

        private void button3_Click(object sender, EventArgs e) => MandaCaratteri(textBox3.Text);

        private void button4_Click(object sender, EventArgs e) => MandaCaratteri(textBox4.Text);

        private void button5_Click(object sender, EventArgs e) => MandaCaratteri(textBox5.Text);

        private void button6_Click(object sender, EventArgs e) => MandaCaratteri(textBox6.Text);

        private void Form1_Load(object sender, EventArgs e)
        {
            labelTypeFreq.Text = trackBarTypeFreq.Value.ToString() + " ms"; 
            labelInitialDelay.Text = trackBarInitialDelay.Value.ToString() + " ms";
            toolStripStatusVersion.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLastError.Text = "";
            if (!Properties.Settings.Default.LicenseAgreementAccepted)
            {

                AboutBox1 frm = new AboutBox1();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.LicenseAgreementAccepted = true;
                    Properties.Settings.Default.Save();
                }
                else
                    this.Close();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void checkBoxEnter_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxEnter.Checked) 
            { checkBoxEnter.ForeColor = Color.DarkRed;
                checkBoxEnter.Font = new Font(textBox1.Font, FontStyle.Bold);
            } else
            {
                checkBoxEnter.ForeColor = Color.Black;
                checkBoxEnter.Font = new Font(textBox1.Font, FontStyle.Regular);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

            try {
                System.Diagnostics.Process.Start("http://msz.eu");
            }
            catch (Exception ecce) {
                _ = MessageBox.Show(ecce.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void checkBoxHasFocus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHasFocus.Checked)
            {
                textApp.Enabled = false;

            }
            else
            {
                textApp.Enabled = true;
            }
        }
    }
}
