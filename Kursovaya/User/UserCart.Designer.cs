
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
            this.addresTextBox = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryCB
            // 
            this.deliveryCB.AutoSize = true;
            this.deliveryCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.deliveryCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deliveryCB.ForeColor = System.Drawing.Color.White;
            this.deliveryCB.Location = new System.Drawing.Point(15, 468);
            this.deliveryCB.Margin = new System.Windows.Forms.Padding(6);
            this.deliveryCB.Name = "deliveryCB";
            this.deliveryCB.Size = new System.Drawing.Size(111, 28);
            this.deliveryCB.TabIndex = 1;
            this.deliveryCB.Text = "Доставка";
            this.deliveryCB.UseVisualStyleBackColor = false;
            this.deliveryCB.CheckedChanged += new System.EventHandler(this.deliveryCB_CheckedChanged);
            // 
            // buildCheckBox
            // 
            this.buildCheckBox.AutoSize = true;
            this.buildCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.buildCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildCheckBox.ForeColor = System.Drawing.Color.White;
            this.buildCheckBox.Location = new System.Drawing.Point(15, 428);
            this.buildCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.buildCheckBox.Name = "buildCheckBox";
            this.buildCheckBox.Size = new System.Drawing.Size(96, 28);
            this.buildCheckBox.TabIndex = 2;
            this.buildCheckBox.Text = "Сборка ";
            this.buildCheckBox.UseVisualStyleBackColor = false;
            this.buildCheckBox.CheckedChanged += new System.EventHandler(this.buildCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Настройки заказа";
            // 
            // addresTextBox
            // 
            this.addresTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.addresTextBox.ForeColor = System.Drawing.Color.White;
            this.addresTextBox.Location = new System.Drawing.Point(12, 583);
            this.addresTextBox.MaxLength = 252;
            this.addresTextBox.Name = "addresTextBox";
            this.addresTextBox.Size = new System.Drawing.Size(344, 29);
            this.addresTextBox.TabIndex = 4;
            this.addresTextBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес доставки";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(804, 399);
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
            this.makeBuyButton.Location = new System.Drawing.Point(957, 573);
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
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(804, 427);
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
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 381);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // cartSumLabel
            // 
            this.cartSumLabel.AutoEllipsis = true;
            this.cartSumLabel.AutoSize = true;
            this.cartSumLabel.ForeColor = System.Drawing.Color.White;
            this.cartSumLabel.Location = new System.Drawing.Point(977, 399);
            this.cartSumLabel.Name = "cartSumLabel";
            this.cartSumLabel.Size = new System.Drawing.Size(41, 24);
            this.cartSumLabel.TabIndex = 8;
            this.cartSumLabel.Text = "0  ₽";
            this.cartSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(804, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Итого:";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoEllipsis = true;
            this.discountLabel.AutoSize = true;
            this.discountLabel.ForeColor = System.Drawing.Color.White;
            this.discountLabel.Location = new System.Drawing.Point(977, 427);
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
            this.cartEndPrice.ForeColor = System.Drawing.Color.White;
            this.cartEndPrice.Location = new System.Drawing.Point(977, 455);
            this.cartEndPrice.Name = "cartEndPrice";
            this.cartEndPrice.Size = new System.Drawing.Size(41, 24);
            this.cartEndPrice.TabIndex = 8;
            this.cartEndPrice.Text = "0  ₽";
            this.cartEndPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deliveryPrice
            // 
            this.deliveryPrice.AutoSize = true;
            this.deliveryPrice.ForeColor = System.Drawing.Color.White;
            this.deliveryPrice.Location = new System.Drawing.Point(288, 470);
            this.deliveryPrice.Name = "deliveryPrice";
            this.deliveryPrice.Size = new System.Drawing.Size(71, 24);
            this.deliveryPrice.TabIndex = 3;
            this.deliveryPrice.Text = "3 000 ₽";
            this.deliveryPrice.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(114, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "(Скидка на доставку)";
            // 
            // buildPrice
            // 
            this.buildPrice.AutoSize = true;
            this.buildPrice.ForeColor = System.Drawing.Color.White;
            this.buildPrice.Location = new System.Drawing.Point(288, 430);
            this.buildPrice.Name = "buildPrice";
            this.buildPrice.Size = new System.Drawing.Size(71, 24);
            this.buildPrice.TabIndex = 3;
            this.buildPrice.Text = "3 000 ₽";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(386, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Дата доставки";
            this.label5.Visible = false;
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.Location = new System.Drawing.Point(390, 450);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 9;
            this.calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.calendar.Visible = false;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // UserCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1083, 624);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.cartEndPrice);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.cartSumLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.makeBuyButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addresTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buildPrice);
            this.Controls.Add(this.deliveryPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buildCheckBox);
            this.Controls.Add(this.deliveryCB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корзина";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox deliveryCB;
        private System.Windows.Forms.CheckBox buildCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addresTextBox;
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
    }
}