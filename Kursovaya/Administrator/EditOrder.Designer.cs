namespace Kursovaya.Administrator
{
    partial class EditOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrder));
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfOrderLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressTextBox
            // 
            this.addressTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.addressTextBox.ForeColor = System.Drawing.Color.White;
            this.addressTextBox.Location = new System.Drawing.Point(15, 62);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addressTextBox.MaxLength = 255;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(343, 29);
            this.addressTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес доставки";
            // 
            // numberOfOrderLabel
            // 
            this.numberOfOrderLabel.AutoSize = true;
            this.numberOfOrderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberOfOrderLabel.Location = new System.Drawing.Point(12, 8);
            this.numberOfOrderLabel.Name = "numberOfOrderLabel";
            this.numberOfOrderLabel.Size = new System.Drawing.Size(104, 25);
            this.numberOfOrderLabel.TabIndex = 2;
            this.numberOfOrderLabel.Text = "Заказ № ";
            // 
            // statusComboBox
            // 
            this.statusComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusComboBox.ForeColor = System.Drawing.Color.White;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(17, 189);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(241, 32);
            this.statusComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Статус заказа";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.phoneNumberTextBox.ForeColor = System.Drawing.Color.White;
            this.phoneNumberTextBox.Location = new System.Drawing.Point(17, 124);
            this.phoneNumberTextBox.Mask = "+7 (000) 000-00-00";
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(174, 29);
            this.phoneNumberTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Номер телефона";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 274);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Дата выполнения заказа";
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.ForeColor = System.Drawing.Color.White;
            this.saveChangesButton.Location = new System.Drawing.Point(207, 371);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(151, 65);
            this.saveChangesButton.TabIndex = 6;
            this.saveChangesButton.Text = "Сохранить";
            this.saveChangesButton.UseVisualStyleBackColor = false;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // EditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(374, 448);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.numberOfOrderLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "EditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование заказа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numberOfOrderLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox phoneNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveChangesButton;
    }
}