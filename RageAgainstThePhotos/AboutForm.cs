using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rage_Against_The_Photos
{
    public partial class AboutForm : Form
    {
        private readonly AppSettings settings;

        public AboutForm(AppSettings settings)
        {
            InitializeComponent();

            this.settings = settings;

            ApplyTheme();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/skrdkrt069/RageAgainstThePhotos",
                UseShellExecute = true
            });

            return;
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
            lblVersion.Text =
                $"{Application.ProductVersion.Split('+')[0]}";
        }

        private void ApplyTheme()
        {
            if (settings.DarkTheme)
            {
                this.BackColor = Color.FromArgb(25, 25, 25);

                lblTitle.ForeColor = Color .White;
                lblTitle2.ForeColor = Color.Indigo;
                lblVersion.ForeColor = Color .White;
                lblEngine.ForeColor = Color .White;
                lblDeveloper.ForeColor = Color .White;
                lblLink.ForeColor = Color.White;
                lblLink.LinkColor = Color.Red;
                lblLink.ActiveLinkColor = Color.Blue;

                btnOK.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = SystemColors.Control;

                lblTitle.ForeColor = Color.Black;
                lblTitle2.ForeColor = Color.Purple;
                lblVersion.ForeColor = Color.Black;
                lblEngine.ForeColor = Color.Black;
                lblDeveloper.ForeColor = Color.Black;
                lblLink.ForeColor = Color.Black;
                lblLink.LinkColor = Color.Blue;
                lblLink.ActiveLinkColor = Color.Red;

                btnOK.ForeColor = Color.Black;
            }
        }
    }
}