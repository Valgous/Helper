using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper
{
    public partial class cmdline : Form
    {
        public cmdline()
        {
            InitializeComponent();
        }

        private void btncmd1_Click(object sender, EventArgs e)
        {
            // Создаем новый процесс
            Process process = new Process();

            // Настраиваем параметры запуска
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe"; // Запускаем командную строку
            startInfo.Arguments = "/c ipconfig /flushdns"; // Команда для выполнения
            startInfo.Verb = "runas"; // Запуск с правами администратора
            startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Скрываем окно командной строки

            // Присваиваем параметры запуска процессу
            process.StartInfo = startInfo;

            try
            {
                // Запускаем процесс
                process.Start();

                // Ждем завершения выполнения команды
                process.WaitForExit();

                // Выводим сообщение об успешном выполнении
                MessageBox.Show("DNS кэш успешно очищен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Освобождаем ресурсы
                process.Dispose();
            }
        }

        private void btncmd2_Click(object sender, EventArgs e)
        {
            // Создаем новый процесс
            Process process = new Process();

            // Настраиваем параметры запуска
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe"; // Запускаем командную строку
            startInfo.Arguments = "/c wsreset.exe"; // Команда для выполнения
            startInfo.Verb = "runas"; // Запуск с правами администратора
            startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Скрываем окно командной строки

            // Присваиваем параметры запуска процессу
            process.StartInfo = startInfo;

            try
            {
                // Запускаем процесс
                process.Start();

                // Ждем завершения выполнения команды
                process.WaitForExit();

                // Выводим сообщение об успешном выполнении
                MessageBox.Show("Кэш хранилища Windows успешно очищен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Освобождаем ресурсы
                process.Dispose();
            }
        }

        private void btncmd3_Click(object sender, EventArgs e)
        {
            // Проверка, что хотя бы один чекбокс выбран
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Выберите хотя бы один пункт для выполнения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Диалоговое окно с подтверждением
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выполнить выбранные действия? Это приведет к удалению файлов.",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Если пользователь не подтвердил, выходим
            if (result != DialogResult.Yes)
            {
                return;
            }

            // Создаем процесс для выполнения команд
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Verb = "runas"; // Запуск от имени администратора
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // Скрыть окно командной строки
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = true;

            try
            {
                // Запускаем процесс
                process.Start();

                // Если выбран первый чекбокс, выполняем команды для очистки папок Temp
                if (checkBox1.Checked)
                {
                    process.StandardInput.WriteLine("del /q /f /s %WINDIR%\\Temp\\*.*");
                    process.StandardInput.WriteLine("del /q /f /s %SYSTEMDRIVE%\\Temp\\*.*");
                    process.StandardInput.WriteLine("del /q /f /s %Temp%\\*.*");
                    process.StandardInput.WriteLine("del /q /f /s %Tmp%\\*.*");
                }

                // Если выбран второй чекбокс, выполняем команду для очистки папки Prefetch
                if (checkBox2.Checked)
                {
                    process.StandardInput.WriteLine("del /q /f /s %WINDIR%\\Prefetch\\*.*");
                }

                // Если выбран третий чекбокс, выполняем команды для очистки бортового журнала
                if (checkBox3.Checked)
                {
                    process.StandardInput.WriteLine("del /q /f /s %SYSTEMDRIVE%\\*.log");
                    process.StandardInput.WriteLine("del /q /f /s %SYSTEMDRIVE%\\*.bak");
                    process.StandardInput.WriteLine("del /q /f /s %SYSTEMDRIVE%\\*.gid");
                }

                // Закрываем поток ввода
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();

                // Выводим сообщение об успешном выполнении
                MessageBox.Show("Команды выполнены успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Освобождаем ресурсы
                process.Dispose();
            }
        }

    }
}

