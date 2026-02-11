
namespace Kursovaya.Administrator
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userSurnameTextBox = new System.Windows.Forms.TextBox();
            this.userPatronymicTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userLoginTextBox = new System.Windows.Forms.TextBox();
            this.userPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userPasswordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.userSaveChanges = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.userRoleComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.userSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(950, 237);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(396, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Отчество";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userNameTextBox.ForeColor = System.Drawing.Color.White;
            this.userNameTextBox.Location = new System.Drawing.Point(208, 338);
            this.userNameTextBox.MaxLength = 100;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(186, 29);
            this.userNameTextBox.TabIndex = 2;
            this.userNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userNameTextBox_KeyPress);
            this.userNameTextBox.Leave += new System.EventHandler(this.userNameTextBox_Leave);
            // 
            // userSurnameTextBox
            // 
            this.userSurnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userSurnameTextBox.ForeColor = System.Drawing.Color.White;
            this.userSurnameTextBox.Location = new System.Drawing.Point(16, 338);
            this.userSurnameTextBox.MaxLength = 100;
            this.userSurnameTextBox.Name = "userSurnameTextBox";
            this.userSurnameTextBox.Size = new System.Drawing.Size(186, 29);
            this.userSurnameTextBox.TabIndex = 2;
            this.userSurnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userSurnameTextBox_KeyPress);
            this.userSurnameTextBox.Leave += new System.EventHandler(this.userSurnameTextBox_Leave);
            // 
            // userPatronymicTextBox
            // 
            this.userPatronymicTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userPatronymicTextBox.ForeColor = System.Drawing.Color.White;
            this.userPatronymicTextBox.Location = new System.Drawing.Point(400, 338);
            this.userPatronymicTextBox.MaxLength = 100;
            this.userPatronymicTextBox.Name = "userPatronymicTextBox";
            this.userPatronymicTextBox.Size = new System.Drawing.Size(211, 29);
            this.userPatronymicTextBox.TabIndex = 2;
            this.userPatronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userPatronymicTextBox_KeyPress);
            this.userPatronymicTextBox.Leave += new System.EventHandler(this.userPatronymicTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(204, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Пароль";
            // 
            // userLoginTextBox
            // 
            this.userLoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userLoginTextBox.ForeColor = System.Drawing.Color.White;
            this.userLoginTextBox.Location = new System.Drawing.Point(16, 405);
            this.userLoginTextBox.MaxLength = 100;
            this.userLoginTextBox.Name = "userLoginTextBox";
            this.userLoginTextBox.Size = new System.Drawing.Size(186, 29);
            this.userLoginTextBox.TabIndex = 2;
            this.userLoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userLoginTextBox_KeyPress);
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.userPasswordTextBox.Location = new System.Drawing.Point(208, 405);
            this.userPasswordTextBox.MaxLength = 100;
            this.userPasswordTextBox.Name = "userPasswordTextBox";
            this.userPasswordTextBox.Size = new System.Drawing.Size(186, 29);
            this.userPasswordTextBox.TabIndex = 2;
            this.userPasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userPasswordTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(396, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Подтвердите пароль";
            // 
            // userPasswordConfirmTextBox
            // 
            this.userPasswordConfirmTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userPasswordConfirmTextBox.ForeColor = System.Drawing.Color.White;
            this.userPasswordConfirmTextBox.Location = new System.Drawing.Point(400, 405);
            this.userPasswordConfirmTextBox.MaxLength = 100;
            this.userPasswordConfirmTextBox.Name = "userPasswordConfirmTextBox";
            this.userPasswordConfirmTextBox.Size = new System.Drawing.Size(211, 29);
            this.userPasswordConfirmTextBox.TabIndex = 2;
            this.userPasswordConfirmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userPasswordConfirmTextBox_KeyPress);
            // 
            // userSaveChanges
            // 
            this.userSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userSaveChanges.ForeColor = System.Drawing.Color.White;
            this.userSaveChanges.Location = new System.Drawing.Point(809, 317);
            this.userSaveChanges.Name = "userSaveChanges";
            this.userSaveChanges.Size = new System.Drawing.Size(153, 121);
            this.userSaveChanges.TabIndex = 3;
            this.userSaveChanges.Text = "Создать";
            this.userSaveChanges.UseVisualStyleBackColor = false;
            this.userSaveChanges.Click += new System.EventHandler(this.userSaveChanges_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(491, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "не обязательное поле";
            // 
            // userRoleComboBox
            // 
            this.userRoleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userRoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRoleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userRoleComboBox.ForeColor = System.Drawing.Color.White;
            this.userRoleComboBox.FormattingEnabled = true;
            this.userRoleComboBox.Location = new System.Drawing.Point(617, 402);
            this.userRoleComboBox.Name = "userRoleComboBox";
            this.userRoleComboBox.Size = new System.Drawing.Size(186, 32);
            this.userRoleComboBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(613, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Роль";
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.deleteUserButton.Enabled = false;
            this.deleteUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteUserButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteUserButton.Location = new System.Drawing.Point(617, 317);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(186, 50);
            this.deleteUserButton.TabIndex = 3;
            this.deleteUserButton.Text = "Удалить";
            this.deleteUserButton.UseVisualStyleBackColor = false;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // userSearch
            // 
            this.userSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.userSearch.ForeColor = System.Drawing.Color.White;
            this.userSearch.Location = new System.Drawing.Point(12, 36);
            this.userSearch.MaxLength = 100;
            this.userSearch.Name = "userSearch";
            this.userSearch.Size = new System.Drawing.Size(432, 29);
            this.userSearch.TabIndex = 2;
            this.userSearch.TextChanged += new System.EventHandler(this.userSearch_TextChanged);
            this.userSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userSearch_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(307, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "Поиск пользователя по фамилии";
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(974, 449);
            this.Controls.Add(this.userRoleComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.userSaveChanges);
            this.Controls.Add(this.userPasswordConfirmTextBox);
            this.Controls.Add(this.userSearch);
            this.Controls.Add(this.userPasswordTextBox);
            this.Controls.Add(this.userLoginTextBox);
            this.Controls.Add(this.userPatronymicTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.userSurnameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userSurnameTextBox;
        private System.Windows.Forms.TextBox userPatronymicTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.TextBox userPasswordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userPasswordConfirmTextBox;
        private System.Windows.Forms.Button userSaveChanges;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox userRoleComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.TextBox userSearch;
        private System.Windows.Forms.Label label9;
    }
}