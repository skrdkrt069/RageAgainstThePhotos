namespace Rage_Against_The_Photos
{
    partial class ChangelogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            richChangelog = new RichTextBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Old English Text MT", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(98, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(499, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Rage Against The Photos — Changelog";
            // 
            // richChangelog
            // 
            richChangelog.Cursor = Cursors.IBeam;
            richChangelog.Font = new Font("Segoe UI", 12F);
            richChangelog.Location = new Point(21, 64);
            richChangelog.Name = "richChangelog";
            richChangelog.ReadOnly = true;
            richChangelog.ScrollBars = RichTextBoxScrollBars.Vertical;
            richChangelog.Size = new Size(643, 348);
            richChangelog.TabIndex = 2;
            richChangelog.Text = "";
            // 
            // btnOK
            // 
            btnOK.Cursor = Cursors.Hand;
            btnOK.Location = new Point(589, 418);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // ChangelogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 450);
            Controls.Add(btnOK);
            Controls.Add(richChangelog);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangelogForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Changelog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private RichTextBox richChangelog;
        private Button btnOK;
    }
}