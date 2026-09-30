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

            ApplyTheme();

            LoadFormats(cmbHeic, "heic");
            LoadFormats(cmbPng, "png");
            LoadFormats(cmbJpg, "jpg");
            LoadFormats(cmbWebp, "webp");
            LoadFormats(cmbIco, "ico");
            LoadFormats(cmbAvif, "Avif");
            LoadFormats(cmbBmp, "Bmp");  

            LoadPreferences();
        }

        private readonly Dictionary<string, string[]> availableFormats =
                new()
           {
                { "png",  new[] { "jpg", "webp", "ico", "avif", "bmp", "ico" } },

                { "bmp", new[] { "png", "jpg", "webp", "avif"} },

                { "jpg",  new[] { "png", "webp", "avif", "bmp" } },

                { "ico",  new[] { "png"} },

                { "avif", new[] { "png", "jpg", "webp", "bmp"} },

                { "heic", new[] { "png", "jpg", "webp", "avif", "bmp" } },

                { "webp", new[] { "png", "jpg", "avif", "bmp" } }
           };

        private void LoadFormats(ComboBox combo, string originalExtension)
        {
            combo.Items.Clear();

            if (availableFormats.TryGetValue(originalExtension.ToLower(), out string[]? formats))
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
            SetComboValue(cmbWebp, "webp");
            SetComboValue(cmbIco, "ico");
            SetComboValue(cmbAvif, "Avif");
            SetComboValue(cmbBmp, "Bmp");
        }

        private void SetComboValue(ComboBox combo, string extension)
        {
            if (settings.DefaultConversions.TryGetValue(extension, out string? format))
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
            SaveComboValue("webp", cmbWebp);
            SaveComboValue("ico", cmbIco);
            SaveComboValue("Avif", cmbAvif);
            SaveComboValue("Bmp", cmbBmp);

            DialogResult = MessageBox.Show(
                "Pronto! Preferências salvas nas configurações."
           );
            
            Close();
        }

        private void ApplyTheme()
        {
            if (settings.DarkTheme)
            {
                this.BackColor = Color.FromArgb(25, 25, 25);

                foreach (Control control in Controls)
                {
                    if (control is Label label)
                    {
                        label.ForeColor = Color.White;
                        
                    }
                }
            }
            else
            {
                this.BackColor = SystemColors.Control;

                foreach (Control control in Controls)
                {
                    if (control is Label label)
                    {
                        {
                            label.ForeColor = Color.Black;
                            lblTitle.ForeColor = Color.MediumPurple;
                        }
                    }
                }
            }
        }
    }
}