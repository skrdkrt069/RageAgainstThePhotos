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
        public ChangelogForm()
        {
            InitializeComponent();

            LoadChangelog();
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
    }
}