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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cmbHeic = new ComboBox();
            cmbPng = new ComboBox();
            cmbJpg = new ComboBox();
            cmbJpeg = new ComboBox();
            cmbWebp = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label7 = new Label();
            cmbIco = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15F);
            label1.ForeColor = Color.MediumPurple;
            label1.Location = new Point(43, 22);
            label1.Name = "label1";
            label1.Size = new Size(235, 28);
            label1.TabIndex = 0;
            label1.Text = "Conversões Automáticas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(43, 341);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 1;
            label2.Text = "HEIC";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(43, 151);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 2;
            label3.Text = "PNG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(43, 199);
            label4.Name = "label4";
            label4.Size = new Size(44, 19);
            label4.TabIndex = 3;
            label4.Text = "JPG";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(43, 246);
            label5.Name = "label5";
            label5.Size = new Size(56, 19);
            label5.TabIndex = 4;
            label5.Text = "JPEG";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(43, 293);
            label6.Name = "label6";
            label6.Size = new Size(61, 19);
            label6.TabIndex = 5;
            label6.Text = "WEBP";
            // 
            // cmbHeic
            // 
            cmbHeic.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHeic.FormattingEnabled = true;
            cmbHeic.Location = new Point(186, 337);
            cmbHeic.Name = "cmbHeic";
            cmbHeic.Size = new Size(121, 23);
            cmbHeic.TabIndex = 6;
            // 
            // cmbPng
            // 
            cmbPng.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPng.FormattingEnabled = true;
            cmbPng.Location = new Point(185, 147);
            cmbPng.Name = "cmbPng";
            cmbPng.Size = new Size(121, 23);
            cmbPng.TabIndex = 7;
            // 
            // cmbJpg
            // 
            cmbJpg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJpg.FormattingEnabled = true;
            cmbJpg.Location = new Point(185, 195);
            cmbJpg.Name = "cmbJpg";
            cmbJpg.Size = new Size(121, 23);
            cmbJpg.TabIndex = 8;
            // 
            // cmbJpeg
            // 
            cmbJpeg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJpeg.FormattingEnabled = true;
            cmbJpeg.Location = new Point(185, 242);
            cmbJpeg.Name = "cmbJpeg";
            cmbJpeg.Size = new Size(121, 23);
            cmbJpeg.TabIndex = 9;
            // 
            // cmbWebp
            // 
            cmbWebp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWebp.FormattingEnabled = true;
            cmbWebp.Location = new Point(185, 289);
            cmbWebp.Name = "cmbWebp";
            cmbWebp.Size = new Size(121, 23);
            cmbWebp.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(63, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(186, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Schoolbook", 12F, FontStyle.Bold);
            label7.Location = new Point(43, 104);
            label7.Name = "label7";
            label7.Size = new Size(41, 19);
            label7.TabIndex = 13;
            label7.Text = "ICO";
            // 
            // cmbIco
            // 
            cmbIco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIco.FormattingEnabled = true;
            cmbIco.Location = new Point(185, 100);
            cmbIco.Name = "cmbIco";
            cmbIco.Size = new Size(121, 23);
            cmbIco.TabIndex = 14;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 450);
            Controls.Add(cmbIco);
            Controls.Add(label7);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbWebp);
            Controls.Add(cmbJpeg);
            Controls.Add(cmbJpg);
            Controls.Add(cmbPng);
            Controls.Add(cmbHeic);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbHeic;
        private ComboBox cmbPng;
        private ComboBox cmbJpg;
        private ComboBox cmbJpeg;
        private ComboBox cmbWebp;
        private Button btnSave;
        private Button btnCancel;
        private Label label7;
        private ComboBox cmbIco;
    }
}