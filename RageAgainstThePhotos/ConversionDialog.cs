using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Rage_Against_The_Photos
{
    public partial class ConversionDialog : Form
    {
        public string SelectedFormat { get; private set; }

        public string SelectedIcoSize { get; private set; }

        public bool RememberChoice { get; private set; }

        public string OriginalExtension => originalExtension;

        private readonly string originalExtension;

        public ConversionDialog(string filename)
        {
            InitializeComponent();

            originalExtension = Path.GetExtension(filename).TrimStart('.').ToLower();

            LoadFormats(originalExtension); 

            lblFileName.Text = filename;

            lblIcoSize.Visible = false;
            cmbIcoSize.Visible = false;
        }

        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormat.Text.ToLower() == "ico")
            {
                lblIcoSize.Visible = true;
                cmbIcoSize.Visible = true;
                chkRememberChoice.Visible = false;
            }
            else
            {
                lblIcoSize.Visible = false;
                cmbIcoSize.Visible = false;
                chkRememberChoice.Visible = true;
            }
        }
        private readonly Dictionary<string, string[]> availableFormats =
        new()
        {
                { "heic", new[] { "png", "jpg", "jpeg", "webp" } },

                { "png",  new[] { "jpg", "jpeg", "webp", "ico" } },

                { "jpg",  new[] { "png", "jpeg", "webp" } },

                { "jpeg", new[] { "png", "jpg", "webp" } },

                { "webp", new[] { "png", "jpg", "jpeg" } },

                { "ico",  new[] { "png", "jpg", "jpeg", "webp" } }
        };

        private void LoadFormats(string originalExtension)
        {
            cmbFormat.Items.Clear();

            if (availableFormats.TryGetValue(originalExtension.ToLower(), out string[] formats))
            {
                foreach (string format in formats)
                    cmbFormat.Items.Add(format);
            }

            cmbFormat.SelectedIndex = 0;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            SelectedFormat = cmbFormat.Text;

            RememberChoice = chkRememberChoice.Checked;

            if (SelectedFormat == "ico")
            {
                SelectedIcoSize = cmbIcoSize.Text;
            }
            else
            {
                SelectedIcoSize = "";
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();
        }
    }
}