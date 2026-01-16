
namespace Kursovaya.User
{
    partial class UserProduct
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShowProc = new System.Windows.Forms.Button();
            this.ShowVideoCards = new System.Windows.Forms.Button();
            this.ShowMotherBoard = new System.Windows.Forms.Button();
            this.ShowRam = new System.Windows.Forms.Button();
            this.ShowDrivers = new System.Windows.Forms.Button();
            this.ShowPowerSuplier = new System.Windows.Forms.Button();
            this.ShowCases = new System.Windows.Forms.Button();
            this.ShowCaseFan = new System.Windows.Forms.Button();
            this.ShowCpuFan = new System.Windows.Forms.Button();
            this.ShowTermo = new System.Windows.Forms.Button();
            this.ShowCart = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SortComboBox = new System.Windows.Forms.ComboBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filterLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.resetSelectedItems = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(26, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1207, 517);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // ShowProc
            // 
            this.ShowProc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowProc.ForeColor = System.Drawing.Color.White;
            this.ShowProc.Location = new System.Drawing.Point(26, 23);
            this.ShowProc.Name = "ShowProc";
            this.ShowProc.Size = new System.Drawing.Size(176, 36);
            this.ShowProc.TabIndex = 1;
            this.ShowProc.Text = "Процессоры";
            this.ShowProc.UseVisualStyleBackColor = false;
            this.ShowProc.Click += new System.EventHandler(this.ShowProc_Click);
            // 
            // ShowVideoCards
            // 
            this.ShowVideoCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowVideoCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowVideoCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowVideoCards.ForeColor = System.Drawing.Color.White;
            this.ShowVideoCards.Location = new System.Drawing.Point(26, 65);
            this.ShowVideoCards.Name = "ShowVideoCards";
            this.ShowVideoCards.Size = new System.Drawing.Size(176, 36);
            this.ShowVideoCards.TabIndex = 6;
            this.ShowVideoCards.Text = "Видеокарты";
            this.ShowVideoCards.UseVisualStyleBackColor = false;
            this.ShowVideoCards.Click += new System.EventHandler(this.ShowVideoCards_Click);
            // 
            // ShowMotherBoard
            // 
            this.ShowMotherBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowMotherBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMotherBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowMotherBoard.ForeColor = System.Drawing.Color.White;
            this.ShowMotherBoard.Location = new System.Drawing.Point(208, 23);
            this.ShowMotherBoard.Name = "ShowMotherBoard";
            this.ShowMotherBoard.Size = new System.Drawing.Size(177, 36);
            this.ShowMotherBoard.TabIndex = 2;
            this.ShowMotherBoard.Text = "Материнские платы";
            this.ShowMotherBoard.UseVisualStyleBackColor = false;
            this.ShowMotherBoard.Click += new System.EventHandler(this.ShowMotherBoard_Click);
            // 
            // ShowRam
            // 
            this.ShowRam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRam.ForeColor = System.Drawing.Color.White;
            this.ShowRam.Location = new System.Drawing.Point(208, 65);
            this.ShowRam.Name = "ShowRam";
            this.ShowRam.Size = new System.Drawing.Size(177, 36);
            this.ShowRam.TabIndex = 7;
            this.ShowRam.Text = "Оперативная память";
            this.ShowRam.UseVisualStyleBackColor = false;
            this.ShowRam.Click += new System.EventHandler(this.ShowRam_Click);
            // 
            // ShowDrivers
            // 
            this.ShowDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowDrivers.ForeColor = System.Drawing.Color.White;
            this.ShowDrivers.Location = new System.Drawing.Point(391, 23);
            this.ShowDrivers.Name = "ShowDrivers";
            this.ShowDrivers.Size = new System.Drawing.Size(175, 36);
            this.ShowDrivers.TabIndex = 3;
            this.ShowDrivers.Text = "Накопители";
            this.ShowDrivers.UseVisualStyleBackColor = false;
            this.ShowDrivers.Click += new System.EventHandler(this.ShowDrivers_Click);
            // 
            // ShowPowerSuplier
            // 
            this.ShowPowerSuplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowPowerSuplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPowerSuplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPowerSuplier.ForeColor = System.Drawing.Color.White;
            this.ShowPowerSuplier.Location = new System.Drawing.Point(391, 65);
            this.ShowPowerSuplier.Name = "ShowPowerSuplier";
            this.ShowPowerSuplier.Size = new System.Drawing.Size(175, 36);
            this.ShowPowerSuplier.TabIndex = 8;
            this.ShowPowerSuplier.Text = "Блоки питания";
            this.ShowPowerSuplier.UseVisualStyleBackColor = false;
            this.ShowPowerSuplier.Click += new System.EventHandler(this.ShowPowerSuplier_Click);
            // 
            // ShowCases
            // 
            this.ShowCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowCases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCases.ForeColor = System.Drawing.Color.White;
            this.ShowCases.Location = new System.Drawing.Point(572, 23);
            this.ShowCases.Name = "ShowCases";
            this.ShowCases.Size = new System.Drawing.Size(164, 36);
            this.ShowCases.TabIndex = 4;
            this.ShowCases.Text = "Корпусы";
            this.ShowCases.UseVisualStyleBackColor = false;
            this.ShowCases.Click += new System.EventHandler(this.ShowCases_Click);
            // 
            // ShowCaseFan
            // 
            this.ShowCaseFan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowCaseFan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowCaseFan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCaseFan.ForeColor = System.Drawing.Color.White;
            this.ShowCaseFan.Location = new System.Drawing.Point(742, 23);
            this.ShowCaseFan.Name = "ShowCaseFan";
            this.ShowCaseFan.Size = new System.Drawing.Size(183, 36);
            this.ShowCaseFan.TabIndex = 5;
            this.ShowCaseFan.Text = "Корпусные кулеры";
            this.ShowCaseFan.UseVisualStyleBackColor = false;
            this.ShowCaseFan.Click += new System.EventHandler(this.ShowCaseFan_Click);
            // 
            // ShowCpuFan
            // 
            this.ShowCpuFan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowCpuFan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowCpuFan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCpuFan.ForeColor = System.Drawing.Color.White;
            this.ShowCpuFan.Location = new System.Drawing.Point(572, 65);
            this.ShowCpuFan.Name = "ShowCpuFan";
            this.ShowCpuFan.Size = new System.Drawing.Size(164, 36);
            this.ShowCpuFan.TabIndex = 9;
            this.ShowCpuFan.Text = "Кулеры";
            this.ShowCpuFan.UseVisualStyleBackColor = false;
            this.ShowCpuFan.Click += new System.EventHandler(this.ShowCpuFan_Click);
            // 
            // ShowTermo
            // 
            this.ShowTermo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowTermo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowTermo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowTermo.ForeColor = System.Drawing.Color.White;
            this.ShowTermo.Location = new System.Drawing.Point(742, 65);
            this.ShowTermo.Name = "ShowTermo";
            this.ShowTermo.Size = new System.Drawing.Size(183, 36);
            this.ShowTermo.TabIndex = 10;
            this.ShowTermo.Text = "Термопаста";
            this.ShowTermo.UseVisualStyleBackColor = false;
            this.ShowTermo.Click += new System.EventHandler(this.ShowTermo_Click);
            // 
            // ShowCart
            // 
            this.ShowCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowCart.Enabled = false;
            this.ShowCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowCart.ForeColor = System.Drawing.Color.White;
            this.ShowCart.Location = new System.Drawing.Point(1086, 23);
            this.ShowCart.Name = "ShowCart";
            this.ShowCart.Size = new System.Drawing.Size(147, 136);
            this.ShowCart.TabIndex = 13;
            this.ShowCart.Text = "Корзина";
            this.ShowCart.UseVisualStyleBackColor = false;
            this.ShowCart.Click += new System.EventHandler(this.ShowCart_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.SearchTextBox.ForeColor = System.Drawing.Color.White;
            this.SearchTextBox.Location = new System.Drawing.Point(26, 131);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(464, 29);
            this.SearchTextBox.TabIndex = 14;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SortComboBox
            // 
            this.SortComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.SortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortComboBox.ForeColor = System.Drawing.Color.White;
            this.SortComboBox.FormattingEnabled = true;
            this.SortComboBox.Location = new System.Drawing.Point(726, 127);
            this.SortComboBox.Name = "SortComboBox";
            this.SortComboBox.Size = new System.Drawing.Size(199, 32);
            this.SortComboBox.TabIndex = 16;
            this.SortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterComboBox.ForeColor = System.Drawing.Color.White;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(496, 128);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(224, 32);
            this.FilterComboBox.TabIndex = 15;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(722, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Стоимость";
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.ForeColor = System.Drawing.Color.White;
            this.filterLabel.Location = new System.Drawing.Point(492, 101);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(166, 24);
            this.filterLabel.TabIndex = 4;
            this.filterLabel.Text = "Количество ядер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(26, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Наименование";
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.Location = new System.Drawing.Point(931, 104);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(149, 56);
            this.btnResetFilter.TabIndex = 12;
            this.btnResetFilter.Text = "Сбросить фильтры";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // resetSelectedItems
            // 
            this.resetSelectedItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.resetSelectedItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetSelectedItems.ForeColor = System.Drawing.Color.White;
            this.resetSelectedItems.Location = new System.Drawing.Point(931, 23);
            this.resetSelectedItems.Name = "resetSelectedItems";
            this.resetSelectedItems.Size = new System.Drawing.Size(149, 78);
            this.resetSelectedItems.TabIndex = 11;
            this.resetSelectedItems.Text = "Сбросить выбор";
            this.resetSelectedItems.UseVisualStyleBackColor = false;
            this.resetSelectedItems.Click += new System.EventHandler(this.resetSelectedItems_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.panel1.Controls.Add(this.ShowRam);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.resetSelectedItems);
            this.panel1.Controls.Add(this.ShowProc);
            this.panel1.Controls.Add(this.btnResetFilter);
            this.panel1.Controls.Add(this.ShowVideoCards);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ShowMotherBoard);
            this.panel1.Controls.Add(this.filterLabel);
            this.panel1.Controls.Add(this.ShowDrivers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ShowPowerSuplier);
            this.panel1.Controls.Add(this.FilterComboBox);
            this.panel1.Controls.Add(this.ShowCases);
            this.panel1.Controls.Add(this.SortComboBox);
            this.panel1.Controls.Add(this.ShowCaseFan);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Controls.Add(this.ShowCpuFan);
            this.panel1.Controls.Add(this.ShowCart);
            this.panel1.Controls.Add(this.ShowTermo);
            this.panel1.Location = new System.Drawing.Point(-14, -13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 762);
            this.panel1.TabIndex = 17;
            // 
            // UserProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 682);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserProduct";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигуратор";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ShowProc;
        private System.Windows.Forms.Button ShowVideoCards;
        private System.Windows.Forms.Button ShowMotherBoard;
        private System.Windows.Forms.Button ShowRam;
        private System.Windows.Forms.Button ShowDrivers;
        private System.Windows.Forms.Button ShowPowerSuplier;
        private System.Windows.Forms.Button ShowCases;
        private System.Windows.Forms.Button ShowCaseFan;
        private System.Windows.Forms.Button ShowCpuFan;
        private System.Windows.Forms.Button ShowTermo;
        private System.Windows.Forms.Button ShowCart;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ComboBox SortComboBox;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button resetSelectedItems;
        private System.Windows.Forms.Panel panel1;
    }
}