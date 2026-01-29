namespace Kursovaya.ProdExpert
{
    partial class FormAddPic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddPic));
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackPageButton = new System.Windows.Forms.Button();
            this.ForwardPageButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.actualPageLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.allPageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryComboBox.ForeColor = System.Drawing.Color.White;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(599, 12);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(180, 28);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Категория";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(768, 327);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.searchTextBox.Enabled = false;
            this.searchTextBox.ForeColor = System.Drawing.Color.White;
            this.searchTextBox.Location = new System.Drawing.Point(69, 12);
            this.searchTextBox.MaxLength = 50;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(379, 26);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Поиск";
            // 
            // BackPageButton
            // 
            this.BackPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.BackPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackPageButton.Location = new System.Drawing.Point(647, 387);
            this.BackPageButton.Name = "BackPageButton";
            this.BackPageButton.Size = new System.Drawing.Size(63, 40);
            this.BackPageButton.TabIndex = 4;
            this.BackPageButton.Text = "<";
            this.BackPageButton.UseVisualStyleBackColor = false;
            this.BackPageButton.Click += new System.EventHandler(this.BackPageButton_Click);
            // 
            // ForwardPageButton
            // 
            this.ForwardPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ForwardPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardPageButton.Location = new System.Drawing.Point(716, 387);
            this.ForwardPageButton.Name = "ForwardPageButton";
            this.ForwardPageButton.Size = new System.Drawing.Size(63, 40);
            this.ForwardPageButton.TabIndex = 4;
            this.ForwardPageButton.Text = ">";
            this.ForwardPageButton.UseVisualStyleBackColor = false;
            this.ForwardPageButton.Click += new System.EventHandler(this.ForwardPageButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Страница";
            // 
            // actualPageLabel
            // 
            this.actualPageLabel.AutoSize = true;
            this.actualPageLabel.Location = new System.Drawing.Point(534, 397);
            this.actualPageLabel.Name = "actualPageLabel";
            this.actualPageLabel.Size = new System.Drawing.Size(18, 20);
            this.actualPageLabel.TabIndex = 5;
            this.actualPageLabel.Text = "n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "из";
            // 
            // allPageLabel
            // 
            this.allPageLabel.AutoSize = true;
            this.allPageLabel.Location = new System.Drawing.Point(590, 397);
            this.allPageLabel.Name = "allPageLabel";
            this.allPageLabel.Size = new System.Drawing.Size(47, 20);
            this.allPageLabel.TabIndex = 5;
            this.allPageLabel.Text = "nmax";
            // 
            // FormAddPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(792, 439);
            this.Controls.Add(this.allPageLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.actualPageLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ForwardPageButton);
            this.Controls.Add(this.BackPageButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormAddPic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление изображения";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BackPageButton;
        private System.Windows.Forms.Button ForwardPageButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label actualPageLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label allPageLabel;
    }
}