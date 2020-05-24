// PROGRAM NAME:     
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
using System.Threading;
using System.Windows.Forms;

namespace KeyTyperSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {

           
            MandaCaratteri(textBox1.Text);
            

            }
        public void MandaCaratteri(string daMandare) {
            try
            {
                Microsoft.VisualBasic.Interaction.AppActivate(textApp.Text);
                Thread.Sleep(trackBar2.Value);
                foreach (char carattere in daMandare)
                {
                    SendKeys.SendWait(carattere.ToString());
                    Thread.Sleep(trackBar1.Value);

                }
            }
            catch (Exception E) {

                MessageBox.Show(E.Message, "Error");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            MandaCaratteri(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
         

            MandaCaratteri(textBox3.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.Interaction.AppActivate(textApp.Text);

            MandaCaratteri(textBox4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MandaCaratteri(textBox5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MandaCaratteri(textBox6.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            label2.Text = trackBar2.Value.ToString();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }
    }
}
