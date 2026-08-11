using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rage_Against_The_Photos
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "O repositório ainda não foi publicado.",
                "GitHub",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return;
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
            lblVersion.Text =
                $"{Application.ProductVersion}";
        }
    }
}