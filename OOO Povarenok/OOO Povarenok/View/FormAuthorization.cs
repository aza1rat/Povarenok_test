using OOO_Povarenok.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOO_Povarenok

{
    public partial class FormAuthorization : Form
    {
        private String rigthCaptchaText;
        private int secondsOfBlock;
        public FormAuthorization()
        {
            InitializeComponent();
            
        }
        private void ButAuthExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Вход в систему от лица гостя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButGuestLogin_Click(object sender, EventArgs e)
        {
            if(TextBoxCaptcha.Text != rigthCaptchaText && rigthCaptchaText != null)
            {
                ButGuestLogin.Enabled = false;
                ButLoginSystem.Enabled = false;
                TimerAuthorization.Start();
                Helper.ShowMessage("Попробуйте ввести капчу через 10 секунд", "Неправильный ввод капчи", MessageBoxIcon.Error);
                return;
            }
            Helper.ShowMessage("Выполнен вход в гостевой аккаунт", "Успешная авторизация", MessageBoxIcon.Information);
            Helper.User = null;
            Helper.PointAdress = null;
            FormViewProduct formViewProduct = new FormViewProduct();
            this.Hide();
            formViewProduct.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Создание и вывод изображения CAPTCHA
        /// </summary>
        /// <param name="captchaText"></param>
        private void GenerateCaptcha (string captchaText)
        {
            int fontSize = 18;
            int symbolPlaceX = 0;
            int symbolPlaceY = 0;
            Random random = new Random();
            Bitmap captchaBitmap = new Bitmap(PicBoxCaptcha.Width, PicBoxCaptcha.Height);
            Graphics captchaGraphics = Graphics.FromImage(captchaBitmap);
            Font captchaFont = new Font("Georgia", fontSize);
            captchaGraphics.Clear(Color.White);
            captchaGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < captchaText.Length; i++)
            {
                symbolPlaceX = random.Next(symbolPlaceX + fontSize / 2, symbolPlaceX + fontSize * 2);
                symbolPlaceY = random.Next(0, PicBoxCaptcha.Height - fontSize * 2);
                captchaGraphics.DrawString(captchaText[i].ToString(), captchaFont, Brushes.Black, symbolPlaceX, symbolPlaceY);
                captchaGraphics.DrawLine(Pens.Black, symbolPlaceX, symbolPlaceY, random.Next(symbolPlaceX,PicBoxCaptcha.Width),
                    random.Next(symbolPlaceY,PicBoxCaptcha.Height));
            }
            captchaGraphics.Flush();
            PicBoxCaptcha.Image = captchaBitmap;


        }
        /// <summary>
        /// Генерация текста CAPTCHA
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GenerateTextCaptcha(int length)
        {
            string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string generated = "";
            Random randomSymbol = new Random();
            for (int i = 0; i < length;i++)
            {
                int gettedSymbol = randomSymbol.Next(0, 36);
                generated += symbols[gettedSymbol];
            }
            return generated;
        }
        /// <summary>
        /// Вход в систему от лица пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButLoginSystem_Click(object sender, EventArgs e)
        {
            
            if (TextBoxCaptcha.Text != rigthCaptchaText && rigthCaptchaText != null)
            {
                ButGuestLogin.Enabled = false;
                ButLoginSystem.Enabled = false;
                TimerAuthorization.Start();
                Helper.ShowMessage("Попробуйте ввести капчу через 10 секунд", "Неправильный ввод капчи", MessageBoxIcon.Error);
                return;
            }

            if (TextBoxLogin.Text == "")
            {
                Helper.ShowMessage("Поле логин не должно быть пустым", "Ошибка ввода", MessageBoxIcon.Error);
                SetCaptha();
                return;
            }
            User account = SQLHelper.GetUser("[UserLogin]", TextBoxLogin.Text);
            if (account is null)
            {
                Helper.ShowMessage("Введенный логин не найден", "Аккаунт не найден", MessageBoxIcon.Error);
                SetCaptha();
                return;
            }
            if (TextBoxPassword.Text == "")
            {
                Helper.ShowMessage("Поле пароль не должно быть пустым", "Ошибка ввода", MessageBoxIcon.Error);
                SetCaptha();
                return;
            }
            if (account.userPassword != TextBoxPassword.Text)
            {
                Helper.ShowMessage("Пароль неверный", "Неуспешная авторизация", MessageBoxIcon.Error);
                SetCaptha();
                return;
            }
            Helper.User = account;
            Helper.ShowMessage("Выполнен вход в аккаунт", "Успешная авторизация", MessageBoxIcon.Information);
            Helper.PointAdress = null;
            rigthCaptchaText = null;
            FormViewProduct formViewProduct = new FormViewProduct();
            this.Hide();
            formViewProduct.ShowDialog();
            this.Show();
        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {
            TableLayPanAuthUp.BackColor = Color.FromArgb(255, 204, 153);
            TableLayPanAuthDown.BackColor = Color.FromArgb(255, 204, 153);
            if (SQLHelper.IsConnected() == false)
                Application.Restart();
        }
        /// <summary>
        /// Появление CAPTCHA
        /// </summary>
        private void SetCaptha()
        {
            rigthCaptchaText = GenerateTextCaptcha(4);
            GenerateCaptcha(rigthCaptchaText);
        }

        private void FormAuthorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLHelper.CloseConnection();
            Helper.ShowMessage("Связь с БД разорвана", "Отключение с БД", MessageBoxIcon.Information);
        }
        /// <summary>
        /// Таймер на блокировку системы при неправильном вводе CAPTCHA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAuthorization_Tick(object sender, EventArgs e)
        {
            secondsOfBlock++;
            if (secondsOfBlock == 10)
            {
                ButGuestLogin.Enabled = true;
                ButLoginSystem.Enabled = true;
                secondsOfBlock = 0;
                SetCaptha();
                Helper.ShowMessage("Повторите ввод капчи", "Повторная попытка", MessageBoxIcon.Information);
                TimerAuthorization.Stop();
            }    
        }
    }
}
