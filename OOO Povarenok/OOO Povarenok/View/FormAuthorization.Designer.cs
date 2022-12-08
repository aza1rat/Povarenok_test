namespace OOO_Povarenok
{
    partial class FormAuthorization
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthorization));
            this.TableLayPanAuthUp = new System.Windows.Forms.TableLayoutPanel();
            this.ButAuthExit = new System.Windows.Forms.Button();
            this.PicBoxAuthLogo = new System.Windows.Forms.PictureBox();
            this.LabelAuthName = new System.Windows.Forms.Label();
            this.TableLayPanAuthDown = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayPanAuthMain = new System.Windows.Forms.TableLayoutPanel();
            this.LabelAuthLogin = new System.Windows.Forms.Label();
            this.LabelAuthPassword = new System.Windows.Forms.Label();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.PanelAuthButLogin = new System.Windows.Forms.Panel();
            this.ButLoginSystem = new System.Windows.Forms.Button();
            this.ButGuestLogin = new System.Windows.Forms.Button();
            this.PanelCaptcha = new System.Windows.Forms.Panel();
            this.TextBoxCaptcha = new System.Windows.Forms.TextBox();
            this.PicBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.TimerAuthorization = new System.Windows.Forms.Timer(this.components);
            this.TableLayPanAuthUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAuthLogo)).BeginInit();
            this.TableLayPanAuthMain.SuspendLayout();
            this.PanelAuthButLogin.SuspendLayout();
            this.PanelCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayPanAuthUp
            // 
            this.TableLayPanAuthUp.ColumnCount = 3;
            this.TableLayPanAuthUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.38423F));
            this.TableLayPanAuthUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.58448F));
            this.TableLayPanAuthUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.15645F));
            this.TableLayPanAuthUp.Controls.Add(this.ButAuthExit, 2, 0);
            this.TableLayPanAuthUp.Controls.Add(this.PicBoxAuthLogo, 0, 0);
            this.TableLayPanAuthUp.Controls.Add(this.LabelAuthName, 1, 0);
            this.TableLayPanAuthUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayPanAuthUp.Location = new System.Drawing.Point(0, 0);
            this.TableLayPanAuthUp.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayPanAuthUp.Name = "TableLayPanAuthUp";
            this.TableLayPanAuthUp.RowCount = 1;
            this.TableLayPanAuthUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanAuthUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanAuthUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanAuthUp.Size = new System.Drawing.Size(611, 65);
            this.TableLayPanAuthUp.TabIndex = 2;
            // 
            // ButAuthExit
            // 
            this.ButAuthExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButAuthExit.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButAuthExit.Location = new System.Drawing.Point(461, 4);
            this.ButAuthExit.Margin = new System.Windows.Forms.Padding(4);
            this.ButAuthExit.Name = "ButAuthExit";
            this.ButAuthExit.Size = new System.Drawing.Size(146, 57);
            this.ButAuthExit.TabIndex = 2;
            this.ButAuthExit.Text = "Выход";
            this.ButAuthExit.UseVisualStyleBackColor = true;
            this.ButAuthExit.Click += new System.EventHandler(this.ButAuthExit_Click);
            // 
            // PicBoxAuthLogo
            // 
            this.PicBoxAuthLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxAuthLogo.Image = global::OOO_Povarenok.Properties.Resources.logo;
            this.PicBoxAuthLogo.Location = new System.Drawing.Point(4, 4);
            this.PicBoxAuthLogo.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxAuthLogo.MaximumSize = new System.Drawing.Size(69, 57);
            this.PicBoxAuthLogo.MinimumSize = new System.Drawing.Size(69, 57);
            this.PicBoxAuthLogo.Name = "PicBoxAuthLogo";
            this.PicBoxAuthLogo.Size = new System.Drawing.Size(69, 57);
            this.PicBoxAuthLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxAuthLogo.TabIndex = 2;
            this.PicBoxAuthLogo.TabStop = false;
            // 
            // LabelAuthName
            // 
            this.LabelAuthName.AutoSize = true;
            this.LabelAuthName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelAuthName.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelAuthName.Location = new System.Drawing.Point(49, 0);
            this.LabelAuthName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelAuthName.Name = "LabelAuthName";
            this.LabelAuthName.Size = new System.Drawing.Size(404, 65);
            this.LabelAuthName.TabIndex = 3;
            this.LabelAuthName.Text = "Авторизация";
            this.LabelAuthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableLayPanAuthDown
            // 
            this.TableLayPanAuthDown.ColumnCount = 1;
            this.TableLayPanAuthDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanAuthDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayPanAuthDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableLayPanAuthDown.Location = new System.Drawing.Point(0, 446);
            this.TableLayPanAuthDown.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayPanAuthDown.Name = "TableLayPanAuthDown";
            this.TableLayPanAuthDown.RowCount = 1;
            this.TableLayPanAuthDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanAuthDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanAuthDown.Size = new System.Drawing.Size(611, 65);
            this.TableLayPanAuthDown.TabIndex = 3;
            // 
            // TableLayPanAuthMain
            // 
            this.TableLayPanAuthMain.ColumnCount = 2;
            this.TableLayPanAuthMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayPanAuthMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayPanAuthMain.Controls.Add(this.LabelAuthLogin, 0, 0);
            this.TableLayPanAuthMain.Controls.Add(this.LabelAuthPassword, 0, 1);
            this.TableLayPanAuthMain.Controls.Add(this.TextBoxLogin, 1, 0);
            this.TableLayPanAuthMain.Controls.Add(this.TextBoxPassword, 1, 1);
            this.TableLayPanAuthMain.Controls.Add(this.PanelAuthButLogin, 1, 2);
            this.TableLayPanAuthMain.Controls.Add(this.PanelCaptcha, 0, 2);
            this.TableLayPanAuthMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayPanAuthMain.Location = new System.Drawing.Point(0, 65);
            this.TableLayPanAuthMain.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayPanAuthMain.Name = "TableLayPanAuthMain";
            this.TableLayPanAuthMain.RowCount = 3;
            this.TableLayPanAuthMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayPanAuthMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayPanAuthMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayPanAuthMain.Size = new System.Drawing.Size(611, 381);
            this.TableLayPanAuthMain.TabIndex = 4;
            // 
            // LabelAuthLogin
            // 
            this.LabelAuthLogin.AutoSize = true;
            this.LabelAuthLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelAuthLogin.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelAuthLogin.Location = new System.Drawing.Point(206, 0);
            this.LabelAuthLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelAuthLogin.Name = "LabelAuthLogin";
            this.LabelAuthLogin.Size = new System.Drawing.Size(95, 127);
            this.LabelAuthLogin.TabIndex = 0;
            this.LabelAuthLogin.Text = "Логин:";
            this.LabelAuthLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelAuthPassword
            // 
            this.LabelAuthPassword.AutoSize = true;
            this.LabelAuthPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelAuthPassword.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelAuthPassword.Location = new System.Drawing.Point(197, 127);
            this.LabelAuthPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelAuthPassword.Name = "LabelAuthPassword";
            this.LabelAuthPassword.Size = new System.Drawing.Size(104, 127);
            this.LabelAuthPassword.TabIndex = 1;
            this.LabelAuthPassword.Text = "Пароль";
            this.LabelAuthPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxLogin.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.TextBoxLogin.Location = new System.Drawing.Point(309, 4);
            this.TextBoxLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(298, 41);
            this.TextBoxLogin.TabIndex = 2;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxPassword.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.TextBoxPassword.Location = new System.Drawing.Point(309, 131);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(298, 41);
            this.TextBoxPassword.TabIndex = 3;
            // 
            // PanelAuthButLogin
            // 
            this.PanelAuthButLogin.Controls.Add(this.ButLoginSystem);
            this.PanelAuthButLogin.Controls.Add(this.ButGuestLogin);
            this.PanelAuthButLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAuthButLogin.Location = new System.Drawing.Point(309, 258);
            this.PanelAuthButLogin.Margin = new System.Windows.Forms.Padding(4);
            this.PanelAuthButLogin.Name = "PanelAuthButLogin";
            this.PanelAuthButLogin.Size = new System.Drawing.Size(298, 119);
            this.PanelAuthButLogin.TabIndex = 4;
            // 
            // ButLoginSystem
            // 
            this.ButLoginSystem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButLoginSystem.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButLoginSystem.Location = new System.Drawing.Point(0, 69);
            this.ButLoginSystem.Margin = new System.Windows.Forms.Padding(4);
            this.ButLoginSystem.Name = "ButLoginSystem";
            this.ButLoginSystem.Size = new System.Drawing.Size(298, 50);
            this.ButLoginSystem.TabIndex = 1;
            this.ButLoginSystem.Text = "Вход";
            this.ButLoginSystem.UseVisualStyleBackColor = true;
            this.ButLoginSystem.Click += new System.EventHandler(this.ButLoginSystem_Click);
            // 
            // ButGuestLogin
            // 
            this.ButGuestLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButGuestLogin.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButGuestLogin.Location = new System.Drawing.Point(0, 0);
            this.ButGuestLogin.Margin = new System.Windows.Forms.Padding(4);
            this.ButGuestLogin.Name = "ButGuestLogin";
            this.ButGuestLogin.Size = new System.Drawing.Size(298, 59);
            this.ButGuestLogin.TabIndex = 0;
            this.ButGuestLogin.Text = "Гостевой вход";
            this.ButGuestLogin.UseVisualStyleBackColor = true;
            this.ButGuestLogin.Click += new System.EventHandler(this.ButGuestLogin_Click);
            // 
            // PanelCaptcha
            // 
            this.PanelCaptcha.Controls.Add(this.TextBoxCaptcha);
            this.PanelCaptcha.Controls.Add(this.PicBoxCaptcha);
            this.PanelCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCaptcha.Location = new System.Drawing.Point(3, 256);
            this.PanelCaptcha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCaptcha.Name = "PanelCaptcha";
            this.PanelCaptcha.Size = new System.Drawing.Size(299, 123);
            this.PanelCaptcha.TabIndex = 5;
            // 
            // TextBoxCaptcha
            // 
            this.TextBoxCaptcha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxCaptcha.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.TextBoxCaptcha.Location = new System.Drawing.Point(0, 82);
            this.TextBoxCaptcha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxCaptcha.Name = "TextBoxCaptcha";
            this.TextBoxCaptcha.Size = new System.Drawing.Size(299, 41);
            this.TextBoxCaptcha.TabIndex = 1;
            // 
            // PicBoxCaptcha
            // 
            this.PicBoxCaptcha.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicBoxCaptcha.Location = new System.Drawing.Point(0, 0);
            this.PicBoxCaptcha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PicBoxCaptcha.Name = "PicBoxCaptcha";
            this.PicBoxCaptcha.Size = new System.Drawing.Size(299, 60);
            this.PicBoxCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxCaptcha.TabIndex = 0;
            this.PicBoxCaptcha.TabStop = false;
            // 
            // TimerAuthorization
            // 
            this.TimerAuthorization.Interval = 1000;
            this.TimerAuthorization.Tick += new System.EventHandler(this.TimerAuthorization_Tick);
            // 
            // FormAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 511);
            this.Controls.Add(this.TableLayPanAuthMain);
            this.Controls.Add(this.TableLayPanAuthUp);
            this.Controls.Add(this.TableLayPanAuthDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(619, 548);
            this.Name = "FormAuthorization";
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAuthorization_FormClosing);
            this.Load += new System.EventHandler(this.FormAuthorization_Load);
            this.TableLayPanAuthUp.ResumeLayout(false);
            this.TableLayPanAuthUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAuthLogo)).EndInit();
            this.TableLayPanAuthMain.ResumeLayout(false);
            this.TableLayPanAuthMain.PerformLayout();
            this.PanelAuthButLogin.ResumeLayout(false);
            this.PanelCaptcha.ResumeLayout(false);
            this.PanelCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCaptcha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayPanAuthUp;
        private System.Windows.Forms.Button ButAuthExit;
        private System.Windows.Forms.PictureBox PicBoxAuthLogo;
        private System.Windows.Forms.Label LabelAuthName;
        private System.Windows.Forms.TableLayoutPanel TableLayPanAuthDown;
        private System.Windows.Forms.TableLayoutPanel TableLayPanAuthMain;
        private System.Windows.Forms.Label LabelAuthLogin;
        private System.Windows.Forms.Label LabelAuthPassword;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Panel PanelAuthButLogin;
        private System.Windows.Forms.Button ButLoginSystem;
        private System.Windows.Forms.Button ButGuestLogin;
        private System.Windows.Forms.Panel PanelCaptcha;
        private System.Windows.Forms.TextBox TextBoxCaptcha;
        private System.Windows.Forms.PictureBox PicBoxCaptcha;
        private System.Windows.Forms.Timer TimerAuthorization;
    }
}