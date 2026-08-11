namespace Rage_Against_The_Photos
{
    partial class AboutForm
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
            picLogo = new PictureBox();
            lblTitle = new Label();
            lblEngine = new Label();
            lblDeveloper = new Label();
            btnOK = new Button();
            lblLink = new LinkLabel();
            lblTitle2 = new Label();
            lblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackgroundImageLayout = ImageLayout.Center;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = Properties.Resources.RATP1;
            picLogo.Location = new Point(154, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(78, 75);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F);
            lblTitle.Location = new Point(57, 117);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 26);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Rage Against The";
            // 
            // lblEngine
            // 
            lblEngine.AutoSize = true;
            lblEngine.Font = new Font("Microsoft Sans Serif", 9F);
            lblEngine.ForeColor = SystemColors.ControlDarkDark;
            lblEngine.Location = new Point(111, 163);
            lblEngine.Name = "lblEngine";
            lblEngine.Size = new Size(152, 15);
            lblEngine.TabIndex = 4;
            lblEngine.Text = "Powered by: ImageMagick";
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.BorderStyle = BorderStyle.Fixed3D;
            lblDeveloper.Font = new Font("Microsoft Sans Serif", 14F);
            lblDeveloper.ForeColor = Color.Black;
            lblDeveloper.Location = new Point(96, 226);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(193, 26);
            lblDeveloper.TabIndex = 5;
            lblDeveloper.Text = "Developed by: skrdkrt";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(154, 415);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(78, 23);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.Location = new Point(154, 276);
            lblLink.Name = "lblLink";
            lblLink.Size = new Size(78, 15);
            lblLink.TabIndex = 7;
            lblLink.TabStop = true;
            lblLink.Text = "Visitar Github";
            lblLink.LinkClicked += lblLink_LinkClicked;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Microsoft Sans Serif", 16F);
            lblTitle2.ForeColor = Color.Indigo;
            lblTitle2.Location = new Point(238, 117);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(80, 26);
            lblTitle2.TabIndex = 8;
            lblTitle2.Text = "Photos";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Cursor = Cursors.No;
            lblVersion.Font = new Font("Microsoft Sans Serif", 10F);
            lblVersion.Location = new Point(170, 143);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(36, 17);
            lblVersion.TabIndex = 9;
            lblVersion.Text = " ???";
            lblVersion.Click += lblVersion_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 450);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle2);
            Controls.Add(lblLink);
            Controls.Add(btnOK);
            Controls.Add(lblEngine);
            Controls.Add(lblTitle);
            Controls.Add(picLogo);
            Controls.Add(lblDeveloper);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sobre";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblEngine;
        private Label lblDeveloper;
        private Button btnOK;
        private LinkLabel lblLink;
        private Label lblTitle2;
        private Label lblVersion;
    }
}