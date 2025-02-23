using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper
{
    public partial class Helper : Form
    {
        public Helper()
        {
            InitializeComponent();
        }

        private async void btncomplex_Click(object sender, EventArgs e)
        {
            // Показываем форму для выбора задач
            bool[] tasksEnabled = ShowTaskSelectionForm();
            if (tasksEnabled.All(enabled => !enabled))
            {
                MessageBox.Show("Выберите хотя бы одну задачу для выполнения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Список задач и их названий для отображения
            string[] taskNames = new string[]
            {
                "Проверка обновлений системы",
                "Очистка системы Privazer",
                "Обновление браузеров",
                "Запуск Malwarebytes",
                "Скачивание DCureIt",
                "Проверка файлов (sfc)",
                "Перезагрузка"
            };

            int totalTasks = tasksEnabled.Count(enabled => enabled);
            int completedTasks = 0;
            string report = "Отчет о выполненных задачах:\n";

            try
            {
                // Отключаем кнопку во время выполнения
                btncomplex.Enabled = false;

                // 1. Проверка и установка обновлений системы
                if (tasksEnabled[0])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[0]);
                    report += "1. Проверка и установка обновлений системы...\n";
                    await InstallSystemUpdatesAsync();
                    completedTasks++;
                    report += "   Обновления системы установлены.\n";
                }

                // 2. Запуск Privazer
                if (tasksEnabled[1])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[1]);
                    report += "2. Запуск Privazer для очистки системы...\n";
                    await RunPrivazerAsync();
                    completedTasks++;
                    report += "   Privazer завершил сканирование.\n";
                }

                // 3. Обновление браузеров
                if (tasksEnabled[2])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[2]);
                    report += "3. Проверка и обновление браузеров...\n";
                    await UpdateBrowsersAsync();
                    completedTasks++;
                    report += "   Браузеры обновлены.\n";
                }

                // 4. Установка и запуск Malwarebytes
                if (tasksEnabled[3])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[3]);
                    report += "4. Установка и запуск Malwarebytes...\n";
                    await InstallAndRunMalwarebytesAsync();
                    completedTasks++;
                    report += "   Malwarebytes завершил сканирование.\n";
                }

                // 5. Скачивание и запуск DCureIt
                if (tasksEnabled[4])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[4]);
                    report += "5. Скачивание и запуск DCureIt...\n";
                    await DownloadAndRunDCureItAsync();
                    completedTasks++;
                    report += "   DCureIt завершил сканирование и был удален.\n";
                }

                // 6. Запуск sfc /scannow
                if (tasksEnabled[5])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[5]);
                    report += "6. Проверка системных файлов (sfc /scannow)...\n";
                    await RunSfcScanAsync();
                    completedTasks++;
                    report += "   Проверка системных файлов завершена.\n";
                }

                // 7. Перезагрузка компьютера
                if (tasksEnabled[6])
                {
                    UpdateButtonText(completedTasks, totalTasks, taskNames[6]);
                    report += "7. Перезагрузка компьютера...\n";
                    SaveReportToDesktop(report);
                    RebootComputer();
                    completedTasks++;
                }
                else
                {
                    UpdateButtonText(completedTasks, totalTasks, "Завершено");
                    SaveReportToDesktop(report);
                    MessageBox.Show("Задачи выполнены успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                report += $"Ошибка: {ex.Message}\n";
                SaveReportToDesktop(report);
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateButtonText(completedTasks, totalTasks, "Ошибка");
            }
            finally
            {
                if (!tasksEnabled[6]) btncomplex.Enabled = true;
            }
        }

        // Вспомогательный метод для обновления текста кнопки
        private void UpdateButtonText(int completed, int total, string currentTask)
        {
            int progress = total > 0 ? (completed * 100) / total : 0;
            btncomplex.Text = $"Выполнено: {progress}% - {currentTask}";
            Application.DoEvents();
        }

        // Форма для выбора задач
        private bool[] ShowTaskSelectionForm()
        {
            using (Form taskForm = new Form { Text = "Выберите задачи", Size = new Size(300, 400) })
            {
                CheckBox[] checkBoxes = new CheckBox[]
                {
                    new CheckBox { Text = "Обновления системы", Checked = true, Location = new Point(10, 10) },
                    new CheckBox { Text = "Privazer", Checked = true, Location = new Point(10, 40) },
                    new CheckBox { Text = "Обновление браузеров", Checked = true, Location = new Point(10, 70) },
                    new CheckBox { Text = "Malwarebytes", Checked = true, Location = new Point(10, 100) },
                    new CheckBox { Text = "DCureIt", Checked = true, Location = new Point(10, 130) },
                    new CheckBox { Text = "sfc /scannow", Checked = true, Location = new Point(10, 160) },
                    new CheckBox { Text = "Перезагрузка", Checked = true, Location = new Point(10, 190) }
                };

                Button okButton = new Button { Text = "ОК", Location = new Point(10, 220) };
                okButton.Click += (s, e) => taskForm.Close();

                taskForm.Controls.AddRange(checkBoxes);
                taskForm.Controls.Add(okButton);
                taskForm.ShowDialog();

                return checkBoxes.Select(cb => cb.Checked).ToArray();
            }
        }

        // Асинхронные методы для задач
        private async Task InstallSystemUpdatesAsync()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "Install-WindowsUpdate -AcceptAll -IgnoreReboot",
                Verb = "runas",
                UseShellExecute = true
            };

            using (Process? process = Process.Start(psi))
            {
                if (process != null) await process.WaitForExitAsync();
                else throw new InvalidOperationException("Не удалось запустить PowerShell.");
            }
        }

        private async Task RunPrivazerAsync()
        {
            string privazerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Programs", "Privazer.exe");
            if (!File.Exists(privazerPath)) throw new FileNotFoundException("Privazer не найден.");

            Process? process = Process.Start(privazerPath);
            if (process != null) await process.WaitForExitAsync();
            else throw new InvalidOperationException("Не удалось запустить Privazer.");
        }

        private async Task UpdateBrowsersAsync()
        {
            string chromePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Google", "Chrome", "Application", "chrome.exe");
            if (File.Exists(chromePath))
            {
                Process? process = Process.Start(chromePath, "--update");
                if (process != null) await process.WaitForExitAsync();
                else throw new InvalidOperationException("Не удалось обновить Chrome.");
            }
        }

        private async Task InstallAndRunMalwarebytesAsync()
        {
            string installerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Programs", "MalwareInstaller.exe");
            if (!File.Exists(installerPath)) throw new FileNotFoundException("Установщик Malwarebytes не найден.");

            Process? installProcess = Process.Start(installerPath, "/silent");
            if (installProcess != null) await installProcess.WaitForExitAsync();
            else throw new InvalidOperationException("Не удалось установить Malwarebytes.");

            string publicDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            Process? malwarebytesProcess = Process.Start(Path.Combine(publicDesktopPath, "Malwarebytes.exe"));
            if (malwarebytesProcess != null) await malwarebytesProcess.WaitForExitAsync();
            else throw new InvalidOperationException("Не удалось запустить Malwarebytes.");
        }

        private async Task DownloadAndRunDCureItAsync()
        {
            string downloadUrl = "https://free.drweb.ru/download+cureit/gr/?lng=ru"; // Замените на реальную ссылку
            string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Programs", "dcureit.exe");

            using (HttpClient client = new HttpClient())
            {
                byte[] fileBytes = await client.GetByteArrayAsync(downloadUrl);
                File.WriteAllBytes(savePath, fileBytes);
            }

            Process? process = Process.Start(savePath);
            if (process != null) await process.WaitForExitAsync();
            else throw new InvalidOperationException("Не удалось запустить DCureIt.");

            File.Delete(savePath);
        }

        private async Task RunSfcScanAsync()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c sfc /scannow",
                Verb = "runas",
                UseShellExecute = true
            };

            using (Process? process = Process.Start(psi))
            {
                if (process != null) await process.WaitForExitAsync();
                else throw new InvalidOperationException("Не удалось запустить sfc /scannow.");
            }
        }

        private void RebootComputer()
        {
            Process.Start("shutdown.exe", "/r /t 0");
        }

        private void SaveReportToDesktop(string report)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportPath = Path.Combine(desktopPath, "Отчет.txt");
            File.WriteAllText(reportPath, report);
        }

        // Остальные методы остаются без изменений
        private void btnshell_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "irm https://get.activated.win | iex";
            process.StartInfo.Verb = "runas";
            process.StartInfo.UseShellExecute = true;

            try
            {
                process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Для выполнения этой операции требуются права администратора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndriver_Click(object sender, EventArgs e)
        {
            string inputText = tbdriver.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Поле ввода не должно быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string encodedText = System.Web.HttpUtility.UrlEncode(inputText);
            string url = $"https://driverpack.io/ru/search?query={encodedText}";

            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbdriver_Click(object sender, EventArgs e)
        {
            tbdriver.Text = null;
        }

        private void btnsafe_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "shutdown.exe",
                    Arguments = "/r /o /f /t 0",
                    Verb = "runas",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnanydesk_Click(object sender, EventArgs e)
        {
            string anyDeskPath = Path.Combine(Application.StartupPath, "Programs", "AnyDesk.exe");
            if (!File.Exists(anyDeskPath))
            {
                MessageBox.Show("Файл AnyDesk.exe не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string arguments = $"--install \"C:\\Program Files (x86)\\AnyDesk\" --start-with-win --create-shortcuts --create-desktop-icon --silent";
            Process process = new Process();
            process.StartInfo.FileName = anyDeskPath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.Verb = "runas";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                process.Start();
                process.WaitForExit();

                string publicDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
                string shortcutPath = Path.Combine(publicDesktopPath, "AnyDesk.lnk");
                if (File.Exists(shortcutPath))
                {
                    string newShortcutPath = Path.Combine(publicDesktopPath, "Онлайн поддержка Байт Бокс (Валентин) +7-901-417-40-77.lnk");
                    File.Move(shortcutPath, newShortcutPath);
                    MessageBox.Show("AnyDesk установлен и ярлык переименован.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("AnyDesk установлен, но ярлык не найден.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                process.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cmdline = new cmdline();
            cmdline.Show();
        }

        private void btncore_Click(object sender, EventArgs e)
        {
            string coreText = tbcore.Text.Trim();
            if (string.IsNullOrEmpty(coreText))
            {
                MessageBox.Show("Поле не должно быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(coreText, out int coreCount) || coreCount <= 0)
            {
                MessageBox.Show("Введите корректное число ядер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Вы уверены, что хотите установить количество ядер на {coreCount}?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c bcdedit.exe /set numproc {coreCount}",
                        Verb = "runas",
                        UseShellExecute = true
                    };
                    using (Process process = Process.Start(psi))
                        process.WaitForExit();

                    MessageBox.Show("Команда выполнена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}