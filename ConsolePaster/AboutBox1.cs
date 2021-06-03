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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using KeyTyperSimulator.Properties;

namespace KeyTyperSimulator
{
    internal partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            Text = string.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings.Default.LicenseAgreementAccepted = true;
            Settings.Default.Save();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.LicenseAgreementAccepted)
            {
                button1.Hide();
                label1.Text = "The license agreement has been accepted. Thanks";
                okButton.Text = "Ok";
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title != "") return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        #endregion
    }
}