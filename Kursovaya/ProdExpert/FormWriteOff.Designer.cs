namespace Kursovaya.ProdExpert
{
    partial class FormWriteOff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWriteOff));
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.IncButton = new System.Windows.Forms.Button();
            this.DecButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.AmountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountTextBox.ForeColor = System.Drawing.Color.White;
            this.AmountTextBox.Location = new System.Drawing.Point(96, 58);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.AmountTextBox.MaxLength = 3;
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(90, 40);
            this.AmountTextBox.TabIndex = 0;
            this.AmountTextBox.Text = "1";
            this.AmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemNameLabel.Location = new System.Drawing.Point(10, 5);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(40, 24);
            this.itemNameLabel.TabIndex = 1;
            this.itemNameLabel.Text = "123";
            // 
            // IncButton
            // 
            this.IncButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.IncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IncButton.ForeColor = System.Drawing.Color.White;
            this.IncButton.Location = new System.Drawing.Point(195, 58);
            this.IncButton.Name = "IncButton";
            this.IncButton.Size = new System.Drawing.Size(73, 40);
            this.IncButton.TabIndex = 2;
            this.IncButton.Text = "+";
            this.IncButton.UseVisualStyleBackColor = false;
            this.IncButton.Click += new System.EventHandler(this.IncButton_Click);
            // 
            // DecButton
            // 
            this.DecButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.DecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecButton.ForeColor = System.Drawing.Color.White;
            this.DecButton.Location = new System.Drawing.Point(14, 58);
            this.DecButton.Name = "DecButton";
            this.DecButton.Size = new System.Drawing.Size(73, 40);
            this.DecButton.TabIndex = 2;
            this.DecButton.Text = "-";
            this.DecButton.UseVisualStyleBackColor = false;
            this.DecButton.Click += new System.EventHandler(this.DecButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(273, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Списать";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Укажите сколько необходимо списать товаров";
            // 
            // FormWriteOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(387, 176);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DecButton);
            this.Controls.Add(this.IncButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormWriteOff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Списание товаров";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Button IncButton;
        private System.Windows.Forms.Button DecButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
    }
}