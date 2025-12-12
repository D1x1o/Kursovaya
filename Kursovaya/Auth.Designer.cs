
namespace Kursovaya
{
    partial class Auth
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Button();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.connedit = new System.Windows.Forms.Button();
            this.ReCaptcha = new System.Windows.Forms.Button();
            this.CaptcaImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CaptcaImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добро пожаловать!";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(41, 99);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(167, 29);
            this.loginTextBox.TabIndex = 1;
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(41, 189);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.Size = new System.Drawing.Size(167, 29);
            this.pwdTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(38, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Введите пароль";
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(62, 244);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(129, 32);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "Войти";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Location = new System.Drawing.Point(41, 435);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(106, 29);
            this.CaptchaTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(38, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Введите капчу";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // connedit
            // 
            this.connedit.Location = new System.Drawing.Point(197, 273);
            this.connedit.Name = "connedit";
            this.connedit.Size = new System.Drawing.Size(26, 23);
            this.connedit.TabIndex = 9;
            this.connedit.Text = "button2";
            this.connedit.UseVisualStyleBackColor = true;
            this.connedit.Click += new System.EventHandler(this.connedit_Click);
            // 
            // ReCaptcha
            // 
            this.ReCaptcha.Image = global::Kursovaya.Properties.Resources._83733882;
            this.ReCaptcha.Location = new System.Drawing.Point(153, 435);
            this.ReCaptcha.Name = "ReCaptcha";
            this.ReCaptcha.Size = new System.Drawing.Size(55, 29);
            this.ReCaptcha.TabIndex = 7;
            this.ReCaptcha.UseVisualStyleBackColor = true;
            this.ReCaptcha.Click += new System.EventHandler(this.ReCaptcha_Click);
            // 
            // CaptcaImg
            // 
            this.CaptcaImg.Location = new System.Drawing.Point(41, 328);
            this.CaptcaImg.Name = "CaptcaImg";
            this.CaptcaImg.Size = new System.Drawing.Size(167, 92);
            this.CaptcaImg.TabIndex = 5;
            this.CaptcaImg.TabStop = false;
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 311);
            this.Controls.Add(this.connedit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReCaptcha);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.CaptcaImg);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Auth";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.CaptcaImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.PictureBox CaptcaImg;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ReCaptcha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button connedit;
    }
}

