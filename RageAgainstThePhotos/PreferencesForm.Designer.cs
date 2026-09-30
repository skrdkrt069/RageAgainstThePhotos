namespace Rage_Against_The_Photos
{
    partial class PreferencesForm
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
            lblHeic = new Label();
            lblPng = new Label();
            lblJpg = new Label();
            lblWebp = new Label();
            cmbHeic = new ComboBox();
            cmbPng = new ComboBox();
            cmbJpg = new ComboBox();
            cmbWebp = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblIco = new Label();
            cmbIco = new ComboBox();
            Bmplbl = new Label();
            cmbBmp = new ComboBox();
            cmbAvif = new ComboBox();
            Aviflbl = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 15F);
            lblTitle.ForeColor = Color.MediumPurple;
            lblTitle.Location = new Point(43, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Conversões Automáticas";
            // 
            // lblHeic
            // 
            lblHeic.AutoSize = true;
            lblHeic.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lblHeic.ForeColor = SystemColors.ControlText;
            lblHeic.Location = new Point(44, 328);
            lblHeic.Name = "lblHeic";
            lblHeic.Size = new Size(54, 19);
            lblHeic.TabIndex = 1;
            lblHeic.Text = "HEIC";
            // 
            // lblPng
            // 
            lblPng.AutoSize = true;
            lblPng.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lblPng.ForeColor = SystemColors.ControlText;
            lblPng.Location = new Point(44, 186);
            lblPng.Name = "lblPng";
            lblPng.Size = new Size(47, 19);
            lblPng.TabIndex = 2;
            lblPng.Text = "PNG";
            // 
            // lblJpg
            // 
            lblJpg.AutoSize = true;
            lblJpg.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lblJpg.ForeColor = SystemColors.ControlText;
            lblJpg.Location = new Point(44, 234);
            lblJpg.Name = "lblJpg";
            lblJpg.Size = new Size(44, 19);
            lblJpg.TabIndex = 3;
            lblJpg.Text = "JPG";
            // 
            // lblWebp
            // 
            lblWebp.AutoSize = true;
            lblWebp.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lblWebp.ForeColor = SystemColors.ControlText;
            lblWebp.Location = new Point(44, 280);
            lblWebp.Name = "lblWebp";
            lblWebp.Size = new Size(61, 19);
            lblWebp.TabIndex = 5;
            lblWebp.Text = "WEBP";
            // 
            // cmbHeic
            // 
            cmbHeic.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHeic.FormattingEnabled = true;
            cmbHeic.Location = new Point(187, 324);
            cmbHeic.Name = "cmbHeic";
            cmbHeic.Size = new Size(121, 23);
            cmbHeic.TabIndex = 6;
            // 
            // cmbPng
            // 
            cmbPng.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPng.FormattingEnabled = true;
            cmbPng.Location = new Point(186, 182);
            cmbPng.Name = "cmbPng";
            cmbPng.Size = new Size(121, 23);
            cmbPng.TabIndex = 7;
            // 
            // cmbJpg
            // 
            cmbJpg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJpg.FormattingEnabled = true;
            cmbJpg.Location = new Point(186, 230);
            cmbJpg.Name = "cmbJpg";
            cmbJpg.Size = new Size(121, 23);
            cmbJpg.TabIndex = 8;
            // 
            // cmbWebp
            // 
            cmbWebp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWebp.FormattingEnabled = true;
            cmbWebp.Location = new Point(186, 276);
            cmbWebp.Name = "cmbWebp";
            cmbWebp.Size = new Size(121, 23);
            cmbWebp.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(63, 443);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(186, 443);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblIco
            // 
            lblIco.AutoSize = true;
            lblIco.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            lblIco.Location = new Point(44, 139);
            lblIco.Name = "lblIco";
            lblIco.Size = new Size(41, 19);
            lblIco.TabIndex = 13;
            lblIco.Text = "ICO";
            // 
            // cmbIco
            // 
            cmbIco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIco.FormattingEnabled = true;
            cmbIco.Location = new Point(186, 135);
            cmbIco.Name = "cmbIco";
            cmbIco.Size = new Size(121, 23);
            cmbIco.TabIndex = 14;
            // 
            // Bmplbl
            // 
            Bmplbl.AutoSize = true;
            Bmplbl.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            Bmplbl.Location = new Point(44, 92);
            Bmplbl.Name = "Bmplbl";
            Bmplbl.Size = new Size(49, 19);
            Bmplbl.TabIndex = 15;
            Bmplbl.Text = "BMP";
            // 
            // cmbBmp
            // 
            cmbBmp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBmp.FormattingEnabled = true;
            cmbBmp.Location = new Point(186, 88);
            cmbBmp.Name = "cmbBmp";
            cmbBmp.Size = new Size(121, 23);
            cmbBmp.TabIndex = 16;
            // 
            // cmbAvif
            // 
            cmbAvif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvif.FormattingEnabled = true;
            cmbAvif.Location = new Point(188, 379);
            cmbAvif.Name = "cmbAvif";
            cmbAvif.Size = new Size(121, 23);
            cmbAvif.TabIndex = 17;
            // 
            // Aviflbl
            // 
            Aviflbl.AutoSize = true;
            Aviflbl.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            Aviflbl.Location = new Point(44, 383);
            Aviflbl.Name = "Aviflbl";
            Aviflbl.Size = new Size(52, 19);
            Aviflbl.TabIndex = 18;
            Aviflbl.Text = "AVIF";
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 489);
            Controls.Add(Aviflbl);
            Controls.Add(cmbAvif);
            Controls.Add(cmbBmp);
            Controls.Add(Bmplbl);
            Controls.Add(cmbIco);
            Controls.Add(lblIco);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbWebp);
            Controls.Add(cmbJpg);
            Controls.Add(cmbPng);
            Controls.Add(cmbHeic);
            Controls.Add(lblWebp);
            Controls.Add(lblJpg);
            Controls.Add(lblPng);
            Controls.Add(lblHeic);
            Controls.Add(lblTitle);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferencesForm";
            ShowIcon = false;
            Text = "Preferências";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHeic;
        private Label lblPng;
        private Label lblJpg;
        private Label lblWebp;
        private ComboBox cmbHeic;
        private ComboBox cmbPng;
        private ComboBox cmbJpg;
        private ComboBox cmbWebp;
        private Button btnSave;
        private Button btnCancel;
        private Label lblIco;
        private ComboBox cmbIco;
        private Label Bmplbl;
        private ComboBox cmbBmp;
        private ComboBox cmbAvif;
        private Label Aviflbl;
    }
}