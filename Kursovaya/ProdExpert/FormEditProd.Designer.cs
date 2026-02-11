namespace Kursovaya.ProdExpert
{
    partial class FormEditProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProd));
            this.allPageLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.actualPageLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ForwardPageButton = new System.Windows.Forms.Button();
            this.BackPageButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // allPageLabel
            // 
            this.allPageLabel.AutoSize = true;
            this.allPageLabel.ForeColor = System.Drawing.Color.White;
            this.allPageLabel.Location = new System.Drawing.Point(598, 444);
            this.allPageLabel.Name = "allPageLabel";
            this.allPageLabel.Size = new System.Drawing.Size(57, 24);
            this.allPageLabel.TabIndex = 13;
            this.allPageLabel.Text = "nmax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(564, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "из";
            // 
            // actualPageLabel
            // 
            this.actualPageLabel.AutoSize = true;
            this.actualPageLabel.ForeColor = System.Drawing.Color.White;
            this.actualPageLabel.Location = new System.Drawing.Point(540, 444);
            this.actualPageLabel.Name = "actualPageLabel";
            this.actualPageLabel.Size = new System.Drawing.Size(21, 24);
            this.actualPageLabel.TabIndex = 15;
            this.actualPageLabel.Text = "n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(437, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Страница";
            // 
            // ForwardPageButton
            // 
            this.ForwardPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ForwardPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardPageButton.ForeColor = System.Drawing.Color.White;
            this.ForwardPageButton.Location = new System.Drawing.Point(732, 434);
            this.ForwardPageButton.Name = "ForwardPageButton";
            this.ForwardPageButton.Size = new System.Drawing.Size(63, 40);
            this.ForwardPageButton.TabIndex = 11;
            this.ForwardPageButton.Text = ">";
            this.ForwardPageButton.UseVisualStyleBackColor = false;
            this.ForwardPageButton.Click += new System.EventHandler(this.ForwardPageButton_Click);
            // 
            // BackPageButton
            // 
            this.BackPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.BackPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackPageButton.ForeColor = System.Drawing.Color.White;
            this.BackPageButton.Location = new System.Drawing.Point(663, 434);
            this.BackPageButton.Name = "BackPageButton";
            this.BackPageButton.Size = new System.Drawing.Size(63, 40);
            this.BackPageButton.TabIndex = 12;
            this.BackPageButton.Text = "<";
            this.BackPageButton.UseVisualStyleBackColor = false;
            this.BackPageButton.Click += new System.EventHandler(this.BackPageButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.searchTextBox.Enabled = false;
            this.searchTextBox.ForeColor = System.Drawing.Color.White;
            this.searchTextBox.Location = new System.Drawing.Point(78, 8);
            this.searchTextBox.MaxLength = 50;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(363, 29);
            this.searchTextBox.TabIndex = 10;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(783, 372);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Поиск";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(463, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Категория";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryComboBox.ForeColor = System.Drawing.Color.White;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(575, 6);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(220, 32);
            this.categoryComboBox.TabIndex = 6;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // FormEditProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(824, 492);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.allPageLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.actualPageLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ForwardPageButton);
            this.Controls.Add(this.BackPageButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FormEditProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование товаров";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label allPageLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label actualPageLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ForwardPageButton;
        private System.Windows.Forms.Button BackPageButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
    }
}