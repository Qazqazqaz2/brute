
using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BruteForce
{
    public partial class BruteForm : Form
    {
        public BruteForm()
        {
            InitializeComponent();
        }

        Point LastPoint;

        static string[] ReadFileAndSendData(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            return lines;
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bruteforce_Click(object sender, EventArgs e)
        {
            string inputPassword = input.Text;
            if (inputPassword.Length == 0)
            {
                MessageBox.Show("Пароль не указан", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (inputPassword.Length > 8)
            {
                MessageBox.Show("Пароль слишком большой", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string[] passwords = ReadFileAndSendData("password.txt");
                // Запуск перебора пароля для длин от 1 до 8
                foreach (string passw in passwords)
                {
                    RecursiveBruteForce(passw, inputPassword, stopwatch);
                }

                stopwatch.Stop();
                MessageBox.Show("Пароль не найден.");
            }
        }

            private void RecursiveBruteForce(string prefix, string targetPassword, Stopwatch stopwatch)
        {
            // Если длина префикса равна требуемой длине, проверяем его на соответствие целевому паролю
            if (prefix == targetPassword)
            {
                stopwatch.Stop();
                MessageBox.Show($"Пароль взломан: {prefix}. Затраченное время: {stopwatch.ElapsedMilliseconds} мс.");
                Application.DoEvents();
                Environment.Exit(0);
            }
            return;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
