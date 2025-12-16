
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buildCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cartSumLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.discountLabel = new System.Windows.Forms.Label();
            this.cartEndPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(608, 77);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 28);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Доставка";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buildCheckBox
            // 
            this.buildCheckBox.AutoSize = true;
            this.buildCheckBox.Location = new System.Drawing.Point(608, 45);
            this.buildCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.buildCheckBox.Name = "buildCheckBox";
            this.buildCheckBox.Size = new System.Drawing.Size(288, 28);
            this.buildCheckBox.TabIndex = 2;
            this.buildCheckBox.Text = "Сборка (Скидка на доставку)";
            this.buildCheckBox.UseVisualStyleBackColor = true;
            this.buildCheckBox.CheckedChanged += new System.EventHandler(this.buildCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(604, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Настройки заказа";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(608, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 29);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(604, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес доставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(604, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стоимость:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(838, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Заказать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 391);
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(578, 541);
            this.dataGridView1.TabIndex = 7;
            // 
            // cartSumLabel
            // 
            this.cartSumLabel.AutoEllipsis = true;
            this.cartSumLabel.AutoSize = true;
            this.cartSumLabel.Location = new System.Drawing.Point(762, 363);
            this.cartSumLabel.Name = "cartSumLabel";
            this.cartSumLabel.Size = new System.Drawing.Size(41, 24);
            this.cartSumLabel.TabIndex = 8;
            this.cartSumLabel.Text = "0  ₽";
            this.cartSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Итого:";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoEllipsis = true;
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(762, 391);
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
            this.cartEndPrice.Location = new System.Drawing.Point(762, 419);
            this.cartEndPrice.Name = "cartEndPrice";
            this.cartEndPrice.Size = new System.Drawing.Size(41, 24);
            this.cartEndPrice.TabIndex = 8;
            this.cartEndPrice.Text = "0  ₽";
            this.cartEndPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 565);
            this.Controls.Add(this.cartEndPrice);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.cartSumLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buildCheckBox);
            this.Controls.Add(this.checkBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserCart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корзина";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox buildCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label cartSumLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label cartEndPrice;
    }
}