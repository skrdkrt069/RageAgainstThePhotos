using ImageMagick;
using Rage_Against_The_Photos;
using Rage_Against_The_Photos.Properties;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Windows.Forms.Design.Behavior;

namespace RageAgainstThePhotos
{
    #region Campos privados
    public partial class RATP : Form
    {
        private string[] startupArgs = Array.Empty<string>();

        private const string PipeName = "RageAgainstThePhotos_FilePipe";

        private readonly List<string> pendingFiles = new();

        private readonly object pendingFilesLock = new();

        private System.Windows.Forms.Timer? incomingFilesTimer;

        private readonly SemaphoreSlim contextMenuConversionLock = new(1, 1);

        private string? lastConvertFolder;

        private AppSettings settings = new AppSettings();

        private bool settingsRecovered = false;

        private readonly string settingsFolder =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "RageAgainstThePhotos"
            );

        private readonly string settingsPath;

        private readonly string lastFolderPath;

    #endregion

    #region Construtor
        public RATP(string[] args)
        {
            InitializeComponent();

            settingsPath = Path.Combine(settingsFolder, "settings.json");

            lastFolderPath = Path.Combine(settingsFolder, "lastfolder.txt");

            Directory.CreateDirectory(settingsFolder);

            LoadSettings();

            ApplyTheme();

            startupArgs = args;

            this.Shown += RATP_Shown;

            StartPipeServer();

            this.KeyDown += RATP_KeyDown;

            Directory.CreateDirectory(
                Path.GetDirectoryName(settingsPath)!
            );

            if (File.Exists(lastFolderPath))
            {
                lastConvertFolder = File.ReadAllText(lastFolderPath);
            }

            cmbFormat.Items.Add("png");
            cmbFormat.Items.Add("jpg");
            cmbFormat.Items.Add("webp");
            cmbFormat.Items.Add("avif");
            cmbFormat.Items.Add("bmp");
            cmbFormat.Items.Add("ico");

            cmbFormat.SelectedIndex = 0;

            if (args.Length > 0)
            {
                string ext = Path.GetExtension(args[0]).ToLower();

                if (ext == ".png")
                {
                    cmbFormat.SelectedItem = "jpg";
                }
                else if (
                    ext == ".jpg" ||
                    ext == ".jpeg" ||
                    ext == ".webp" ||
                    ext == ".heic" ||
                    ext == ".avif" ||
                    ext == ".bmp" ||
                    ext == ".ico"
                )

                {
                    cmbFormat.SelectedItem = "png";
                }
            }

        }
        #endregion

    #region Configuração
        private void LoadSettings()
        {
            if (!File.Exists(settingsPath))
            {
                settings = new AppSettings();

                SaveSettings();

                return;
            }
            try
            {
                settings = JsonSerializer.Deserialize<AppSettings>(
                  File.ReadAllText(settingsPath)
                ) ?? new AppSettings();
            }
            catch
            {
                settingsRecovered = true;

                settings = new AppSettings();

                SaveSettings();
            }
        }

        private void SaveSettings()
        {
            File.WriteAllText(
                settingsPath,
                JsonSerializer.Serialize(settings, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            );
        }

        private bool TryGetDefaultConversion(string originalExtension, out string selectedFormat)
        {
            if (originalExtension.Equals("jpeg", StringComparison.OrdinalIgnoreCase))
                originalExtension = "jpg";

            return settings.DefaultConversions.TryGetValue(
                originalExtension,
                out selectedFormat!
            );
        }
        #endregion

    #region Inicialização & Eventos da Janela
        private async void RATP_Shown(object? sender, EventArgs e)
        {
            if (settingsRecovered)
            {
                MessageBox.Show(
                "O arquivo de configurações estava corrompido, mas foi recriado automaticamente.",
                "Configurações",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );

                settingsRecovered = false;
            }

            if (startupArgs.Length > 0)
            {
                QueueIncomingFiles(startupArgs);
            }
        }
        private async void RATP_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Arquivos copiados do Explorer
                if (Clipboard.ContainsFileDropList())
                {
                    string[] files =
                        Clipboard.GetFileDropList()
                        .Cast<string>()
                        .ToArray();

                    richLogs.AppendText("📋 Arquivos colados!\n");

                    richLogs.ScrollToCaret();

                    await ConvertFiles(files);

                    return;
                }

                //Imagem copiada
                if (Clipboard.ContainsImage())
                {
                    System.Drawing.Image? image = Clipboard.GetImage();

                    if (image == null)
                    {
                        return;
                    }

                    string tempPath = Path.Combine(
                        Path.GetTempPath(),
                        $"rath_paste_{Guid.NewGuid()}.png"
                    );

                    image.Save(tempPath, ImageFormat.Png);

                    image.Dispose();

                    string[] files = { tempPath };

                    richLogs.AppendText("📋 Imagem colada!\n");

                    richLogs.ScrollToCaret();

                    await ConvertFiles(files);

                    return;
                }

                MessageBox.Show(
                    "Nenhuma imagem ou arquivo encontrado no Ctrl+V."
                );
            }
        }
        #endregion

    #region Single Instance & Arquivos Recebidos
        private async void StartPipeServer()
        {
            while (!IsDisposed)
            {
                try
                {
                    using NamedPipeServerStream server = new NamedPipeServerStream(
                        PipeName,
                        PipeDirection.In
                    );

                    await server.WaitForConnectionAsync();

                    using StreamReader reader = new StreamReader(
                        server,
                        Encoding.UTF8
                    );

                    List<string> receivedFiles = new();

                    string? line;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            receivedFiles.Add(line);
                    }

                    if (receivedFiles.Count > 0 && !IsDisposed)
                    {
                        BeginInvoke(() =>
                        {
                            QueueIncomingFiles(receivedFiles); //Agrupador
                        });
                    }
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch
                {
                    // Mantém o servidor vivo caso uma chamada morra.
                }
            }
        }

        private void QueueIncomingFiles(IEnumerable<string> files)
        {
            lock (pendingFilesLock)
            {
                pendingFiles.AddRange(files);
            }

            incomingFilesTimer?.Stop();
            incomingFilesTimer?.Dispose();

            incomingFilesTimer = new System.Windows.Forms.Timer
            {
                Interval = 300
            };

            incomingFilesTimer.Tick += async (_, _) =>
            {
                incomingFilesTimer.Stop();
                incomingFilesTimer.Dispose();
                incomingFilesTimer = null;

                string[] filesToProcess;

                lock (pendingFilesLock)
                {
                    filesToProcess = pendingFiles
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToArray();

                    pendingFiles.Clear();
                }

                if (filesToProcess.Length == 0)
                    return;

                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }

                Show();
                BringToFront();
                Activate();

                await contextMenuConversionLock.WaitAsync();

                try
                {
                    await ConvertFiles(filesToProcess, true);
                }
                finally
                {
                    contextMenuConversionLock.Release();
                }
            };

            incomingFilesTimer.Start();
        }
        #endregion

    #region Conversão de Imagens
        private async Task ConvertFiles(string[] files, bool fromContextMenu = false)
        {
            richLogs.Clear();

            int convertedCount = 0;

            bool arquivoInvalido = false;

            List<Task> tasks = new List<Task>();

            Dictionary<string, (string Format, string IcoSize)> batchChoices = new();

            HashSet<string> cancelledBatchExtensions =
                new(StringComparer.OrdinalIgnoreCase);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                string originalExtension = extension.TrimStart('.');

                string selectedFormat;

                string icoSize;

                if (fromContextMenu)
                {
                    string preferenceExtension = originalExtension;

                    if (preferenceExtension.Equals("jpeg", StringComparison.OrdinalIgnoreCase))
                        preferenceExtension = "jpg";

                    if (cancelledBatchExtensions.Contains(preferenceExtension))
                        continue;

                    if (batchChoices.TryGetValue(preferenceExtension,out var batchChoice))
                    {
                        selectedFormat = batchChoice.Format;
                        icoSize = batchChoice.IcoSize;
                    }

                    else if (TryGetDefaultConversion(preferenceExtension, out string defaultFormat))
                    {
                        selectedFormat = defaultFormat;
                        icoSize = "Automático";

                        batchChoices[preferenceExtension] =
                            (selectedFormat, icoSize);
                    }

                    else
                    {
                        using (ConversionDialog dialog = new ConversionDialog(file))
                        {
                            if (dialog.ShowDialog(this) != DialogResult.OK)
                            {
                                cancelledBatchExtensions.Add(preferenceExtension);
                                continue;
                            }

                            selectedFormat = dialog.SelectedFormat;
                            icoSize = dialog.SelectedIcoSize;

                            batchChoices[preferenceExtension] =
                                (selectedFormat, icoSize);

                            if (dialog.RememberChoice)
                            {
                                settings.DefaultConversions[preferenceExtension] =
                                    selectedFormat;

                                SaveSettings();
                            }
                        }
                    }
                }
                else
                {
                    selectedFormat =
                        cmbFormat.SelectedItem?.ToString()?.ToLower() ?? "png";

                    icoSize = cmbIcoSize.Text;
                }

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        string outputExtension = "." + selectedFormat;

                        string[] supportedFormats =
                        {
                            ".heic",
                            ".png",
                            ".jpg",
                            ".jpeg",
                            ".ico",
                            ".avif",
                            ".bmp",
                            ".webp"
                        };

                        if (extension == outputExtension)
                        {
                            Invoke(() =>
                            {
                                richLogs.AppendText(
                                    $"⚠ Formato já existente: {Path.GetFileName(file)}\n"
                                );

                                richLogs.ScrollToCaret();
                            });

                            return;
                        }


                        if (!supportedFormats.Contains(extension))
                        {
                            arquivoInvalido = true;

                            return;
                        }


                        if (selectedFormat == "ico" && extension != ".png")
                        {
                            MessageBox.Show(
                                "Pra virar ícone, o arquivo precisa ser PNG.\n" +
                                "Ele pode ser redimensionado automaticamente também.",
                                "Conversão para ICO"
                            );

                            return;
                        }

                        string directory = Path.GetDirectoryName(file)!;

                        string convertFolder =
                            Path.Combine(directory, "Fotos Convertidas");

                        string fileName =
                            Path.GetFileNameWithoutExtension(file);

                        string output =
                            Path.Combine(convertFolder, fileName + outputExtension);

                        lastConvertFolder = convertFolder;

                        int counter = 1;

                        while (File.Exists(output))
                        {
                            output = Path.Combine(
                                convertFolder,
                                $"{fileName} ({counter}){outputExtension}"
                            );

                            counter++;
                        }

                        //Tamanho padrão
                        uint size = 256;

                        switch (icoSize)
                        {
                            case "16x16":
                                size = 16;
                                break;

                            case "23+1x23+1":
                                size = 23 + 1;
                                break;

                            case "32x32":
                                size = 32;
                                break;

                            case "48x48":
                                size = 48;
                                break;

                            case "64x64":
                                size = 64;
                                break;

                            case "128x128":
                                size = 128;
                                break;

                            case "256x256":
                                size = 256;
                                break;
                        }

                        if (selectedFormat == "ico")
                        {
                            using (MagickImage preview = new MagickImage(file))
                            {
                                uint maiorlado = (uint)Math.Max(preview.Width, preview.Height);

                                if (icoSize == "Automático")
                                {
                                    uint maiorLado = (uint)Math.Max(preview.Width, preview.Height);

                                    if (maiorLado >= 256)
                                        size = 256;
                                    else if (maiorLado >= 128)
                                        size = 128;
                                    else if (maiorLado >= 64)
                                        size = 64;
                                    else if (maiorLado >= 48)
                                        size = 48;
                                    else if (maiorLado >= 32)
                                        size = 32;
                                    else if (maiorLado >= 24)
                                        size = 24;
                                    else
                                        size = 16;
                                }

                                if (selectedFormat == "ico" && preview.Width < 16 && preview.Height < 16)
                                {
                                    MessageBox.Show(
                                        $"A imagem possui apenas {preview.Width}x{preview.Height} pixels.\n" +
                                        $"Não é possível gerar um arquivo menor que {size}x{size} pixels.\n\n" +
                                        "Selecione outra imagem com uma resolução maior.",
                                        "Tamanho inválido",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );

                                    return;
                                }

                                else if (size > maiorlado)
                                {
                                    DialogResult result = MessageBox.Show(
                                       $"A imagem original possui {preview.Width}x{preview.Height} pixels.\n" +
                                       $"Você escolheu converter para {size}x{size} pixels.\n" +
                                       "Isso pode resultar na perda de qualidade da imagem.\n\n" +
                                       "Deseja continuar?",
                                       "Redução de qualidade",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning
                                    );

                                    if (result == DialogResult.No)
                                    {
                                        Invoke(() =>
                                        {
                                            richLogs.AppendText("⚠ Conversão cancelada pelo usuário.\n");
                                            richLogs.ScrollToCaret();
                                        });

                                        return;
                                    }
                                }
                            }
                        }

                        Directory.CreateDirectory(convertFolder);

                        await Task.Run(() =>
                        {
                            using (MagickImage image = new MagickImage(file))
                            {
                                if (selectedFormat == "ico")
                                {
                                    image.Resize(size, size);
                                    image.Format = MagickFormat.Icon;
                                }

                                image.Write(output);
                            }
                        });

                        convertedCount++;

                        Invoke(() =>
                        {
                            richLogs.AppendText(
                                $"✔ Convertido: {Path.GetFileName(output)}\n"
                            );

                            richLogs.ScrollToCaret();
                        });
                    }
                    catch (Exception ex)
                    {
                        Invoke(() =>
                        {
                            Clipboard.SetText(ex.ToString());

                            MessageBox.Show(
                                "Erro copiado automaticamente!\n\n" + ex.Message
                            );
                        });

                        Invoke(() =>
                        {
                            richLogs.AppendText(
                                $"❌ Erro: {ex.Message}\n"
                            );

                            richLogs.ScrollToCaret();
                        });
                    }
                }));
            }

            await Task.WhenAll(tasks);

            if (lastConvertFolder != null)
            {
                File.WriteAllText(lastFolderPath, lastConvertFolder);
            }
            if (convertedCount > 1)
            {
                MessageBox.Show(
                    $"Feito! {convertedCount} arquivos convertidos."
                );
            }
            else if (convertedCount == 1)
            {
                MessageBox.Show(
                    $"Pronto! {convertedCount} arquivo convertido."
                );
            }
            else if (arquivoInvalido)
            {
                MessageBox.Show(
                    "Somente png, jpg, jpeg, heic, ico, avif, bmp e webp"
                );
            }
        }
        private void cmbIcoSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool icoSelecionado =
                cmbFormat.Text.Equals("ico", StringComparison.OrdinalIgnoreCase);

            lblIcoSize.Visible = icoSelecionado;
            cmbIcoSize.Visible = icoSelecionado;

            if (icoSelecionado && cmbIcoSize.SelectedIndex == -1)
            {
                cmbIcoSize.SelectedIndex = 0;
            }
        }
        #endregion

    #region Arrastar & Soltar
        private void panelDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }

            paneldrop.BackColor = Color.Lavender;
        }

        private async void panelDrop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                string[]? files =
                    e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files == null)
                {
                    return;
                }

                await ConvertFiles(files);
            }
        }
        private void paneldrop_DragLeave(object sender, EventArgs e)
        {
            if (settings.DarkTheme)
                paneldrop.BackColor = Color.FromArgb(35, 35, 35);
            else
            {
                paneldrop.BackColor = SystemColors.Control;
            }
        }
        #endregion

    #region Tema
        private void ApplyTheme()
        {
            if (settings.DarkTheme)
            {
                this.BackColor = Color.FromArgb(25, 25, 25);

                paneldrop.BackColor = Color.FromArgb(35, 35, 35);

                richLogs.BackColor = Color.FromArgb(45, 45, 45);
                richLogs.ForeColor = Color.White;

                cmbFormat.BackColor = Color.FromArgb(45, 45, 45);
                cmbFormat.ForeColor = Color.White;
                cmbIcoSize.BackColor = Color.FromArgb(45, 45, 45);
                cmbIcoSize.ForeColor = Color.White;

                btnOpenFolder.BackColor = Color.FromArgb(60, 60, 60);
                btnOpenFolder.ForeColor = Color.White;

                lblTitle.ForeColor = Color.White;
                lblFormat.ForeColor = Color.White;
                lblIcoSize.ForeColor = Color.White;

                menuStrip.BackColor = Color.FromArgb(45, 45, 45);
                menuStrip.ForeColor = Color.White;
                arquivoMenuItem.BackColor = Color.FromArgb(45, 45, 45);
                arquivoMenuItem.ForeColor = Color.White;
                sobreMenuItem.BackColor = Color.FromArgb(45, 45, 45);
                sobreMenuItem.ForeColor = Color.White;

                linkLabel.LinkColor = Color.White;
                linkLabel.ActiveLinkColor = Color.Red;
                linkLabel.ForeColor = Color.Blue;
            }
            else
            {
                this.BackColor = SystemColors.Control;

                paneldrop.BackColor = Color.WhiteSmoke;

                richLogs.BackColor = Color.White;
                richLogs.ForeColor = Color.Black;

                cmbFormat.BackColor = Color.White;
                cmbFormat.ForeColor = Color.Black;
                cmbIcoSize.BackColor = Color.White;
                cmbIcoSize.ForeColor = Color.Black;

                btnOpenFolder.BackColor = Color.MediumPurple;
                btnOpenFolder.ForeColor = Color.Black;

                lblTitle.ForeColor = Color.MediumPurple;
                lblFormat.ForeColor = Color.MediumPurple;
                lblIcoSize.ForeColor = Color.MediumPurple;

                menuStrip.ForeColor = Color.Black;
                menuStrip.BackColor = SystemColors.Control;
                arquivoMenuItem.ForeColor = Color.Black;
                arquivoMenuItem.BackColor = SystemColors.Control;
                sobreMenuItem.ForeColor = Color.Black;
                sobreMenuItem.BackColor = SystemColors.Control;

                linkLabel.LinkColor = Color.Blue;
                linkLabel.ActiveLinkColor = Color.Black;
                linkLabel.ForeColor = Color.Black;
            }
        }
        private void btnDarkTheme_Click(object sender, EventArgs e)
        {
            settings.DarkTheme = !settings.DarkTheme;

            SaveSettings();

            ApplyTheme();

            btnTheme.Text = settings.DarkTheme ? "off" : "on";
        }
        #endregion

    #region Pastas, Logs & Controles
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (lastConvertFolder != null && Directory.Exists(lastConvertFolder))
            {
                Process.Start("explorer.exe", lastConvertFolder);
            }
            else
            {
                MessageBox.Show("Nenhuma pasta disponível ainda.");
            }
        }

        private void btnOpenFolder_MouseEnter(object sender, EventArgs e)
        {
            btnOpenFolder.BackColor = Color.MediumPurple;
        }

        private void btnOpenFolder_MouseLeave(object sender, EventArgs e)
        {
            if (settings.DarkTheme)
            {
                btnOpenFolder.BackColor = Color.FromArgb(60, 60, 60);
            }
            else
            {
                btnOpenFolder.BackColor = Color.MediumPurple;
            }
        }

        private void btnClearLogs_Click_1(object sender, EventArgs e)
        {
            richLogs.Clear();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://linktr.ee/skrdkrt",
                UseShellExecute = true
            });
        }
        #endregion

    #region Menus & Preferências
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm(settings))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SaveSettings();
                }
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Essa opção limpará todas as preferências de conversão.\n\n" +
              "Tem certeza que deseja continuar?\n",
              "Limpar preferências",
              MessageBoxButtons.OKCancel,
              MessageBoxIcon.Exclamation
            );
            if (settings.DefaultConversions.Count == 0)
            {
                MessageBox.Show(
                    "Não há nenhuma preferência salva.",
                    "Limpar preferências",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }
            if (result == DialogResult.OK)
            {
                settings.DefaultConversions.Clear();

                cmbFormat.SelectedIndex = 0;

                SaveSettings();

                MessageBox.Show(
                    "Todas as preferências foram apagadas da configuração.",
                    "Limpar preferências",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (result == DialogResult.Cancel)
            {
                richLogs.AppendText("⚠ Limpeza de preferências cancelada pelo usuário.\n");
                richLogs.ScrollToCaret();

                return;
            }
        }

        private void sobreMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm form = new AboutForm(this.settings))
            {
                form.ShowDialog(this);
            }
        }

        private void changelogMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangelogForm form = new ChangelogForm(this.settings))
            {
                form.ShowDialog(this);
            }
        }
        #endregion

    #region Atualizações
        private async Task CheckForUpdates()
        {
            try
            {
                UpdateService updateService = new UpdateService();

                UpdateInfo latestVersion =
                    await updateService.GetLatestVersionAsync();

                string productVersion =
                    Application.ProductVersion.TrimStart('v').Split('+')[0];

                Version currentVersion =
                    Version.Parse(productVersion);

                Version availableVersion =
                    Version.Parse(latestVersion.Version);

                if (availableVersion > currentVersion)
                {
                    DialogResult result = MessageBox.Show(
                        $"Uma nova versão do Rage Against The Photos está disponível!\n\n" +
                        $"Versão atual: {currentVersion}\n" +
                        $"Nova versão: {availableVersion}\n\n" +
                        $"Deseja abrir a página de download?",
                        "Verificar Atualizações",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(
                            new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = latestVersion.DownloadUrl,
                                UseShellExecute = true
                            }
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        $"Você já está usando a versão mais recente.\n\n" +
                        $"Versão atual: {currentVersion}",
                        "Verificar Atualizações",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível verificar atualizações.\n\n" +
                    $"Detalhes: {ex.Message}",
                    "Verificar Atualizações",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private async void atualizaçõesMenuItem_Click(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }
        #endregion
    }
}