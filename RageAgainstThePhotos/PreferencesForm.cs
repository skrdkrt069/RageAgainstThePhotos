using Rage_Against_The_Photos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Rage_Against_The_Photos
{
    public partial class PreferencesForm : Form
    {
        private readonly AppSettings settings;

        public PreferencesForm(AppSettings settings)
        {
            InitializeComponent();

            this.settings = settings;

            LoadFormats(cmbHeic, "heic");
            LoadFormats(cmbPng, "png");
            LoadFormats(cmbJpg, "jpg");
            LoadFormats(cmbJpeg, "jpeg");
            LoadFormats(cmbWebp, "webp");
            LoadFormats(cmbIco, "ico");

            LoadPreferences();
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

        private void LoadFormats(ComboBox combo, string originalExtension)
        {
            combo.Items.Clear();

            if (availableFormats.TryGetValue(originalExtension.ToLower(), out string[] formats))
            {
                foreach (string format in formats)
                    combo.Items.Add(format);
            }

            combo.SelectedIndex = 0;
        }        

        private void LoadPreferences()
        {
            SetComboValue(cmbHeic, "heic");
            SetComboValue(cmbPng, "png");
            SetComboValue(cmbJpg, "jpg");
            SetComboValue(cmbJpeg, "jpeg");
            SetComboValue(cmbWebp, "webp");
            SetComboValue(cmbIco, "ico");
        }

        private void SetComboValue(ComboBox combo, string extension)
        {
            if (settings.DefaultConversions.TryGetValue(extension, out string format))
            {
                combo.SelectedItem = format;
            }
        }

        private void SaveComboValue(string extension,  ComboBox combo)
        {
            if (!string.IsNullOrWhiteSpace(combo.Text))
            {
                settings.DefaultConversions[extension] =
                combo.Text.ToLower();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.DefaultConversions.Clear();

            SaveComboValue("png", cmbPng);
            SaveComboValue("jpg", cmbJpg);
            SaveComboValue("heic", cmbHeic);
            SaveComboValue("jpeg", cmbJpeg);
            SaveComboValue("webp", cmbWebp);
            SaveComboValue("ico", cmbIco);

            DialogResult = MessageBox.Show(
                "Pronto! Preferências salvas nas configurações."
           );
            
            Close();
        }
    }
}