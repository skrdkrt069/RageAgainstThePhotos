using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rage_Against_The_Photos
{
    public partial class ChangelogForm : Form
    {
        private readonly AppSettings settings;

        public ChangelogForm(AppSettings settings)
        {
            InitializeComponent();

            this.settings = settings;

            LoadChangelog();

            ApplyTheme();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadChangelog()
        {
            string changelogPath = Path.Combine(
                AppContext.BaseDirectory,
                "Changelog.txt"
            );

            if (File.Exists(changelogPath))
            {
                richChangelog.Text = File.ReadAllText(changelogPath);
            }
            else
            {
                richChangelog.Text =
                    "Não foi possível carregar o changelog.";
            }
        }

        private void ApplyTheme()
        {
            if (settings.DarkTheme)
            {
                this.BackColor = Color.FromArgb(25, 25, 25);

                foreach(Control control in Controls)
                {
                    if (control is Label label)
                    {
                        label.ForeColor = Color.White;
                    }
                }

                richChangelog.BackColor = Color.FromArgb(45, 45, 45);
                richChangelog.ForeColor = Color.White;

                btnOK.BackColor = Color.FromArgb(60, 60, 60);
                btnOK.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;

                foreach(Control control in Controls)
                {
                    if (control is Label label)
                    {
                        label.ForeColor = Color.Black;
                    }
                }

                richChangelog.BackColor = Color.White;
                richChangelog.ForeColor = Color.Black;

                btnOK.BackColor = Color.White;
                btnOK.ForeColor = Color.Black;
            }
        }
    }
}