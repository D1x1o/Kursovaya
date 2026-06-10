
namespace Kursovaya.User
{
    partial class UserCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCart));
            this.deliveryCB = new System.Windows.Forms.CheckBox();
            this.buildCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.makeBuyButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cartSumLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.discountLabel = new System.Windows.Forms.Label();
            this.cartEndPrice = new System.Windows.Forms.Label();
            this.deliveryPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buildPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addresTextBox = new System.Windows.Forms.RichTextBox();
            this.chooseCheck = new System.Windows.Forms.ComboBox();
            this.checkbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryCB
            // 
            this.deliveryCB.AutoSize = true;
            this.deliveryCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.deliveryCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deliveryCB.ForeColor = System.Drawing.Color.White;
            this.deliveryCB.Location = new System.Drawing.Point(17, 510);
            this.deliveryCB.Margin = new System.Windows.Forms.Padding(6);
            this.deliveryCB.Name = "deliveryCB";
            this.deliveryCB.Size = new System.Drawing.Size(120, 29);
            this.deliveryCB.TabIndex = 1;
            this.deliveryCB.Text = "Доставка";
            this.deliveryCB.UseVisualStyleBackColor = false;
            this.deliveryCB.CheckedChanged += new System.EventHandler(this.deliveryCB_CheckedChanged);
            // 
            // buildCheckBox
            // 
            this.buildCheckBox.AutoSize = true;
            this.buildCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.buildCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buildCheckBox.ForeColor = System.Drawing.Color.White;
            this.buildCheckBox.Location = new System.Drawing.Point(17, 470);
            this.buildCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.buildCheckBox.Name = "buildCheckBox";
            this.buildCheckBox.Size = new System.Drawing.Size(105, 29);
            this.buildCheckBox.TabIndex = 2;
            this.buildCheckBox.Text = "Сборка ";
            this.buildCheckBox.UseVisualStyleBackColor = false;
            this.buildCheckBox.CheckedChanged += new System.EventHandler(this.buildCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Настройки заказа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 598);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес доставки";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(806, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стоимость:";
            // 
            // makeBuyButton
            // 
            this.makeBuyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.makeBuyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeBuyButton.ForeColor = System.Drawing.Color.White;
            this.makeBuyButton.Location = new System.Drawing.Point(957, 667);
            this.makeBuyButton.Name = "makeBuyButton";
            this.makeBuyButton.Size = new System.Drawing.Size(114, 39);
            this.makeBuyButton.TabIndex = 6;
            this.makeBuyButton.Text = "Заказать";
            this.makeBuyButton.UseVisualStyleBackColor = false;
            this.makeBuyButton.Click += new System.EventHandler(this.makeBuyButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(806, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Скидка:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 425);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // cartSumLabel
            // 
            this.cartSumLabel.AutoEllipsis = true;
            this.cartSumLabel.AutoSize = true;
            this.cartSumLabel.ForeColor = System.Drawing.Color.Black;
            this.cartSumLabel.Location = new System.Drawing.Point(979, 441);
            this.cartSumLabel.Name = "cartSumLabel";
            this.cartSumLabel.Size = new System.Drawing.Size(41, 24);
            this.cartSumLabel.TabIndex = 8;
            this.cartSumLabel.Text = "0  ₽";
            this.cartSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(806, 497);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Итого:";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoEllipsis = true;
            this.discountLabel.AutoSize = true;
            this.discountLabel.ForeColor = System.Drawing.Color.Black;
            this.discountLabel.Location = new System.Drawing.Point(979, 469);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(41, 24);
            this.discountLabel.TabIndex = 8;
            this.discountLabel.Text = "0  ₽";
            this.discountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cartEndPrice
            // 
            this.cartEndPrice.AutoEllipsis = true;
            this.cartEndPrice.AutoSize = true;
            this.cartEndPrice.ForeColor = System.Drawing.Color.Black;
            this.cartEndPrice.Location = new System.Drawing.Point(979, 497);
            this.cartEndPrice.Name = "cartEndPrice";
            this.cartEndPrice.Size = new System.Drawing.Size(41, 24);
            this.cartEndPrice.TabIndex = 8;
            this.cartEndPrice.Text = "0  ₽";
            this.cartEndPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deliveryPrice
            // 
            this.deliveryPrice.AutoSize = true;
            this.deliveryPrice.ForeColor = System.Drawing.Color.Black;
            this.deliveryPrice.Location = new System.Drawing.Point(308, 510);
            this.deliveryPrice.Name = "deliveryPrice";
            this.deliveryPrice.Size = new System.Drawing.Size(71, 24);
            this.deliveryPrice.TabIndex = 3;
            this.deliveryPrice.Text = "3 000 ₽";
            this.deliveryPrice.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(103, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "(Скидка на доставку)";
            // 
            // buildPrice
            // 
            this.buildPrice.AutoSize = true;
            this.buildPrice.ForeColor = System.Drawing.Color.Black;
            this.buildPrice.Location = new System.Drawing.Point(308, 472);
            this.buildPrice.Name = "buildPrice";
            this.buildPrice.Size = new System.Drawing.Size(71, 24);
            this.buildPrice.TabIndex = 3;
            this.buildPrice.Text = "3 000 ₽";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(598, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Дата доставки";
            this.label5.Visible = false;
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.Location = new System.Drawing.Point(602, 470);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 9;
            this.calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.Visible = false;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.phoneTextBox.ForeColor = System.Drawing.Color.White;
            this.phoneTextBox.Location = new System.Drawing.Point(18, 570);
            this.phoneTextBox.Mask = "+7 (000) 000-00-00";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(173, 29);
            this.phoneTextBox.TabIndex = 10;
            this.phoneTextBox.Click += new System.EventHandler(this.phoneTextBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "Номер телефона";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(535, 677);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addresTextBox
            // 
            this.addresTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.addresTextBox.ForeColor = System.Drawing.Color.White;
            this.addresTextBox.Location = new System.Drawing.Point(18, 625);
            this.addresTextBox.Name = "addresTextBox";
            this.addresTextBox.Size = new System.Drawing.Size(511, 81);
            this.addresTextBox.TabIndex = 12;
            this.addresTextBox.Text = "";
            this.addresTextBox.Visible = false;
            // 
            // chooseCheck
            // 
            this.chooseCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.chooseCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseCheck.ForeColor = System.Drawing.Color.White;
            this.chooseCheck.FormattingEnabled = true;
            this.chooseCheck.Items.AddRange(new object[] {
            "MS Word",
            "PDF"});
            this.chooseCheck.Location = new System.Drawing.Point(885, 625);
            this.chooseCheck.Name = "chooseCheck";
            this.chooseCheck.Size = new System.Drawing.Size(186, 32);
            this.chooseCheck.TabIndex = 13;
            this.chooseCheck.Visible = false;
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.checkbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkbox.ForeColor = System.Drawing.Color.White;
            this.checkbox.Location = new System.Drawing.Point(1005, 572);
            this.checkbox.Margin = new System.Windows.Forms.Padding(6);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(66, 29);
            this.checkbox.TabIndex = 1;
            this.checkbox.Text = "Чек";
            this.checkbox.UseVisualStyleBackColor = false;
            this.checkbox.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(945, 598);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "Формат чека";
            this.label8.Visible = false;
            // 
            // UserCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1083, 715);
            this.Controls.Add(this.chooseCheck);
            this.Controls.Add(this.addresTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.cartEndPrice);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.cartSumLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.makeBuyButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buildPrice);
            this.Controls.Add(this.deliveryPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buildCheckBox);
            this.Controls.Add(this.checkbox);
            this.Controls.Add(this.deliveryCB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корзина";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserCart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox deliveryCB;
        private System.Windows.Forms.CheckBox buildCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button makeBuyButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label cartSumLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label cartEndPrice;
        private System.Windows.Forms.Label deliveryPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label buildPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox addresTextBox;
        private System.Windows.Forms.ComboBox chooseCheck;
        private System.Windows.Forms.CheckBox checkbox;
        private System.Windows.Forms.Label label8;
    }
}