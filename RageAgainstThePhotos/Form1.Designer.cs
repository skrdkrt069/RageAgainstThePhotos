using System.ComponentModel;

namespace RageAgainstThePhotos
{
    partial class RATP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RATP));
            paneldrop = new Panel();
            lblTitle = new Label();
            cmbFormat = new ComboBox();
            btnOpenFolder = new Button();
            lblFormat = new Label();
            btnClearLogs = new Button();
            btnTheme = new Button();
            richLogs = new RichTextBox();
            linkLabel1 = new LinkLabel();
            cmbIcoSize = new ComboBox();
            lblIcoSize = new Label();
            menuStrip1 = new MenuStrip();
            arquivoMenuItem = new ToolStripMenuItem();
            preferênciasToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            limparToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            sairToolStripMenuItem = new ToolStripMenuItem();
            sobreMenuItem = new ToolStripMenuItem();
            atualizaçõesMenuItem = new ToolStripMenuItem();
            changelogToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // paneldrop
            // 
            paneldrop.AllowDrop = true;
            paneldrop.BackColor = Color.WhiteSmoke;
            paneldrop.BorderStyle = BorderStyle.FixedSingle;
            paneldrop.ForeColor = Color.MediumPurple;
            paneldrop.Location = new Point(126, 66);
            paneldrop.Name = "paneldrop";
            paneldrop.Size = new Size(550, 300);
            paneldrop.TabIndex = 0;
            paneldrop.DragDrop += panelDrop_DragDrop;
            paneldrop.DragEnter += panelDrop_DragEnter;
            paneldrop.DragLeave += paneldrop_DragLeave;
            paneldrop.Paint += paneldrop_Paint;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F);
            lblTitle.ForeColor = Color.MediumPurple;
            lblTitle.Location = new Point(282, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "⬇ Cole ou arraste a foto ⬇";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += label1_Click;
            // 
            // cmbFormat
            // 
            cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormat.FormattingEnabled = true;
            cmbFormat.Location = new Point(682, 126);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(121, 23);
            cmbFormat.TabIndex = 3;
            cmbFormat.SelectedIndexChanged += comboFormat_SelectedIndexChanged;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.BackColor = Color.MediumPurple;
            btnOpenFolder.Cursor = Cursors.Hand;
            btnOpenFolder.FlatAppearance.BorderSize = 0;
            btnOpenFolder.FlatStyle = FlatStyle.Flat;
            btnOpenFolder.Font = new Font("Segoe UI", 10F);
            btnOpenFolder.ForeColor = Color.White;
            btnOpenFolder.Location = new Point(738, 471);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(100, 35);
            btnOpenFolder.TabIndex = 4;
            btnOpenFolder.Text = "Abrir pasta";
            btnOpenFolder.UseVisualStyleBackColor = false;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.Font = new Font("Segoe UI Semibold", 10F);
            lblFormat.ForeColor = Color.MediumPurple;
            lblFormat.Location = new Point(678, 104);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(125, 19);
            lblFormat.TabIndex = 5;
            lblFormat.Text = "Escolha o formato:";
            lblFormat.TextAlign = ContentAlignment.MiddleCenter;
            lblFormat.Click += label2_Click;
            // 
            // btnClearLogs
            // 
            btnClearLogs.FlatStyle = FlatStyle.System;
            btnClearLogs.Location = new Point(126, 425);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(82, 23);
            btnClearLogs.TabIndex = 6;
            btnClearLogs.Text = "Limpar logs";
            btnClearLogs.UseVisualStyleBackColor = true;
            btnClearLogs.Click += btnClearLogs_Click_1;
            // 
            // btnTheme
            // 
            btnTheme.BackColor = Color.White;
            btnTheme.BackgroundImageLayout = ImageLayout.Center;
            btnTheme.Cursor = Cursors.Hand;
            btnTheme.FlatStyle = FlatStyle.Popup;
            btnTheme.Location = new Point(775, 27);
            btnTheme.Name = "btnTheme";
            btnTheme.Size = new Size(61, 30);
            btnTheme.TabIndex = 7;
            btnTheme.Text = "lâmpada";
            btnTheme.UseVisualStyleBackColor = false;
            btnTheme.Click += btnDarkTheme_Click;
            // 
            // richLogs
            // 
            richLogs.BackColor = Color.White;
            richLogs.Cursor = Cursors.IBeam;
            richLogs.Font = new Font("Consolas", 9F);
            richLogs.ForeColor = Color.Red;
            richLogs.Location = new Point(126, 372);
            richLogs.Name = "richLogs";
            richLogs.ReadOnly = true;
            richLogs.Size = new Size(550, 47);
            richLogs.TabIndex = 8;
            richLogs.Text = "";
            richLogs.WordWrap = false;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Red;
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Help;
            linkLabel1.Font = new Font("Times New Roman", 13.69F, FontStyle.Bold);
            linkLabel1.Location = new Point(-1, 484);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.RightToLeft = RightToLeft.No;
            linkLabel1.Size = new Size(109, 22);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "© skrr 2026";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // cmbIcoSize
            // 
            cmbIcoSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIcoSize.FormattingEnabled = true;
            cmbIcoSize.Items.AddRange(new object[] { "Automático", "16x16", "23+1x23+1", "32x32", "48x48", "64x64", "128x128", "256x256" });
            cmbIcoSize.Location = new Point(682, 178);
            cmbIcoSize.Name = "cmbIcoSize";
            cmbIcoSize.Size = new Size(121, 23);
            cmbIcoSize.TabIndex = 10;
            cmbIcoSize.Visible = false;
            cmbIcoSize.SelectedIndexChanged += cmbIcoSize_SelectedIndexChanged;
            // 
            // lblIcoSize
            // 
            lblIcoSize.AutoSize = true;
            lblIcoSize.Font = new Font("Segoe UI Semibold", 10F);
            lblIcoSize.ForeColor = Color.MediumPurple;
            lblIcoSize.Location = new Point(678, 156);
            lblIcoSize.Name = "lblIcoSize";
            lblIcoSize.Size = new Size(127, 19);
            lblIcoSize.TabIndex = 11;
            lblIcoSize.Text = "Tamanho do ícone:";
            lblIcoSize.TextAlign = ContentAlignment.MiddleCenter;
            lblIcoSize.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { arquivoMenuItem, sobreMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(836, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // arquivoMenuItem
            // 
            arquivoMenuItem.DropDownItems.AddRange(new ToolStripItem[] { preferênciasToolStripMenuItem, toolStripSeparator1, sairToolStripMenuItem });
            arquivoMenuItem.Name = "arquivoMenuItem";
            arquivoMenuItem.Size = new Size(61, 20);
            arquivoMenuItem.Text = "Arquivo";
            // 
            // preferênciasToolStripMenuItem
            // 
            preferênciasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editarToolStripMenuItem, limparToolStripMenuItem });
            preferênciasToolStripMenuItem.Name = "preferênciasToolStripMenuItem";
            preferênciasToolStripMenuItem.Size = new Size(138, 22);
            preferênciasToolStripMenuItem.Text = "Preferências";
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(111, 22);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // limparToolStripMenuItem
            // 
            limparToolStripMenuItem.Name = "limparToolStripMenuItem";
            limparToolStripMenuItem.Size = new Size(111, 22);
            limparToolStripMenuItem.Text = "Limpar";
            limparToolStripMenuItem.Click += limparToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(135, 6);
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(138, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // sobreMenuItem
            // 
            sobreMenuItem.DropDownItems.AddRange(new ToolStripItem[] { atualizaçõesMenuItem, changelogToolStripMenuItem, toolStripSeparator2, sobreToolStripMenuItem });
            sobreMenuItem.Name = "sobreMenuItem";
            sobreMenuItem.Size = new Size(50, 20);
            sobreMenuItem.Text = "Ajuda";
            // 
            // atualizaçõesMenuItem
            // 
            atualizaçõesMenuItem.Name = "atualizaçõesMenuItem";
            atualizaçõesMenuItem.Size = new Size(183, 22);
            atualizaçõesMenuItem.Text = "Verificar atualizações";
            atualizaçõesMenuItem.Click += atualizaçõesMenuItem_Click;
            // 
            // changelogToolStripMenuItem
            // 
            changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            changelogToolStripMenuItem.Size = new Size(183, 22);
            changelogToolStripMenuItem.Text = "Changelog";
            changelogToolStripMenuItem.Click += changelogMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(180, 6);
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(183, 22);
            sobreToolStripMenuItem.Text = "Sobre";
            sobreToolStripMenuItem.Click += sobreMenuItem_Click;
            // 
            // RATP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(836, 505);
            Controls.Add(lblIcoSize);
            Controls.Add(cmbIcoSize);
            Controls.Add(linkLabel1);
            Controls.Add(richLogs);
            Controls.Add(btnTheme);
            Controls.Add(btnClearLogs);
            Controls.Add(lblFormat);
            Controls.Add(btnOpenFolder);
            Controls.Add(cmbFormat);
            Controls.Add(lblTitle);
            Controls.Add(paneldrop);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "RATP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rage Against The Photos";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel paneldrop;
        private Label lblTitle;
        private ComboBox cmbFormat;
        private Button btnOpenFolder;
        private Label lblFormat;
        private Button btnClearLogs;
        private Button btnTheme;
        private RichTextBox richLogs;
        private LinkLabel linkLabel1;
        private ComboBox cmbIcoSize;
        private Label lblIcoSize;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem arquivoMenuItem;
        private ToolStripMenuItem preferênciasToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem sobreMenuItem;
        private ToolStripMenuItem atualizaçõesMenuItem;
        private ToolStripMenuItem changelogToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem limparToolStripMenuItem;
    }
}
