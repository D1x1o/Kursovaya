namespace Kursovaya
{
    partial class EditConn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverAddres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serverUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverPassword = new System.Windows.Forms.TextBox();
            this.saveConnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Настройки подключения \nк базе данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адрес сервера";
            // 
            // serverAddres
            // 
            this.serverAddres.Location = new System.Drawing.Point(29, 102);
            this.serverAddres.MaxLength = 20;
            this.serverAddres.Name = "serverAddres";
            this.serverAddres.Size = new System.Drawing.Size(196, 29);
            this.serverAddres.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя пользователя";
            // 
            // serverUser
            // 
            this.serverUser.Location = new System.Drawing.Point(29, 163);
            this.serverUser.MaxLength = 100;
            this.serverUser.Name = "serverUser";
            this.serverUser.Size = new System.Drawing.Size(196, 29);
            this.serverUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Пароль";
            // 
            // serverPassword
            // 
            this.serverPassword.Location = new System.Drawing.Point(29, 226);
            this.serverPassword.MaxLength = 100;
            this.serverPassword.Name = "serverPassword";
            this.serverPassword.Size = new System.Drawing.Size(196, 29);
            this.serverPassword.TabIndex = 2;
            // 
            // saveConnData
            // 
            this.saveConnData.Location = new System.Drawing.Point(29, 306);
            this.saveConnData.Name = "saveConnData";
            this.saveConnData.Size = new System.Drawing.Size(196, 40);
            this.saveConnData.TabIndex = 3;
            this.saveConnData.Text = "Сохранить";
            this.saveConnData.UseVisualStyleBackColor = true;
            this.saveConnData.Click += new System.EventHandler(this.saveConnData_Click);
            // 
            // EditConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 359);
            this.Controls.Add(this.saveConnData);
            this.Controls.Add(this.serverPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverAddres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "EditConn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки подключения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverAddres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverPassword;
        private System.Windows.Forms.Button saveConnData;
    }
}