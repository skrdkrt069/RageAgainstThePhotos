namespace Rage_Against_The_Photos
{
    partial class ConversionDialog
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
            lblFileTitle = new Label();
            lblFileName = new Label();
            lblConvertTo = new Label();
            cmbFormat = new ComboBox();
            lblIcoSize = new Label();
            cmbIcoSize = new ComboBox();
            chkRememberChoice = new CheckBox();
            btnConvert = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFileTitle
            // 
            lblFileTitle.AutoSize = true;
            lblFileTitle.Font = new Font("Segoe UI Semibold", 10F);
            lblFileTitle.ForeColor = Color.MediumPurple;
            lblFileTitle.Location = new Point(88, 9);
            lblFileTitle.Name = "lblFileTitle";
            lblFileTitle.Size = new Size(61, 19);
            lblFileTitle.TabIndex = 0;
            lblFileTitle.Text = "Arquivo:";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(88, 28);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(97, 15);
            lblFileName.TabIndex = 1;
            lblFileName.Text = "Nenhum arquivo";
            // 
            // lblConvertTo
            // 
            lblConvertTo.AutoSize = true;
            lblConvertTo.Font = new Font("Segoe UI Semibold", 10F);
            lblConvertTo.ForeColor = Color.MediumPurple;
            lblConvertTo.Location = new Point(82, 82);
            lblConvertTo.Name = "lblConvertTo";
            lblConvertTo.Size = new Size(104, 19);
            lblConvertTo.TabIndex = 2;
            lblConvertTo.Text = "Converter para:";
            // 
            // cmbFormat
            // 
            cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormat.FormattingEnabled = true;
            cmbFormat.Items.AddRange(new object[] { "png", "jpg", "jpeg", "ico", "webp" });
            cmbFormat.Location = new Point(88, 104);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(121, 23);
            cmbFormat.TabIndex = 3;
            cmbFormat.SelectedIndexChanged += cmbFormat_SelectedIndexChanged;
            // 
            // lblIcoSize
            // 
            lblIcoSize.AutoSize = true;
            lblIcoSize.Font = new Font("Segoe UI Semibold", 10F);
            lblIcoSize.ForeColor = Color.MediumPurple;
            lblIcoSize.Location = new Point(82, 169);
            lblIcoSize.Name = "lblIcoSize";
            lblIcoSize.Size = new Size(127, 19);
            lblIcoSize.TabIndex = 4;
            lblIcoSize.Text = "Tamanho do ícone:";
            lblIcoSize.Visible = false;
            // 
            // cmbIcoSize
            // 
            cmbIcoSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIcoSize.FormattingEnabled = true;
            cmbIcoSize.Items.AddRange(new object[] { "Automático", "16x16", "23+1x23+1", "32x32", "48x48", "64x64", "128x128", "256x256" });
            cmbIcoSize.Location = new Point(88, 191);
            cmbIcoSize.Name = "cmbIcoSize";
            cmbIcoSize.Size = new Size(121, 23);
            cmbIcoSize.TabIndex = 5;
            cmbIcoSize.Visible = false;
            // 
            // chkRememberChoice
            // 
            chkRememberChoice.AutoSize = true;
            chkRememberChoice.Location = new Point(68, 289);
            chkRememberChoice.Name = "chkRememberChoice";
            chkRememberChoice.Size = new Size(166, 19);
            chkRememberChoice.TabIndex = 6;
            chkRememberChoice.Text = "Não perguntar novamente";
            chkRememberChoice.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(68, 314);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(75, 23);
            btnConvert.TabIndex = 7;
            btnConvert.Text = "Converter";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(163, 314);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ConversionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 349);
            Controls.Add(btnCancel);
            Controls.Add(btnConvert);
            Controls.Add(chkRememberChoice);
            Controls.Add(cmbIcoSize);
            Controls.Add(lblIcoSize);
            Controls.Add(cmbFormat);
            Controls.Add(lblConvertTo);
            Controls.Add(lblFileName);
            Controls.Add(lblFileTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConversionDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Converter Arquivos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFileTitle;
        private Label lblFileName;
        private Label lblConvertTo;
        private ComboBox cmbFormat;
        private Label lblIcoSize;
        private ComboBox cmbIcoSize;
        private CheckBox chkRememberChoice;
        private Button btnConvert;
        private Button btnCancel;
    }
}