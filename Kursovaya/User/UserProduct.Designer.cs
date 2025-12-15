
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1207, 512);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ShowProc
            // 
            this.ShowProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowProc.Location = new System.Drawing.Point(12, 12);
            this.ShowProc.Name = "ShowProc";
            this.ShowProc.Size = new System.Drawing.Size(176, 36);
            this.ShowProc.TabIndex = 1;
            this.ShowProc.Text = "Процессоры";
            this.ShowProc.UseVisualStyleBackColor = true;
            this.ShowProc.Click += new System.EventHandler(this.ShowProc_Click);
            // 
            // ShowVideoCards
            // 
            this.ShowVideoCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowVideoCards.Location = new System.Drawing.Point(12, 54);
            this.ShowVideoCards.Name = "ShowVideoCards";
            this.ShowVideoCards.Size = new System.Drawing.Size(176, 36);
            this.ShowVideoCards.TabIndex = 1;
            this.ShowVideoCards.Text = "Видеокарты";
            this.ShowVideoCards.UseVisualStyleBackColor = true;
            this.ShowVideoCards.Click += new System.EventHandler(this.ShowVideoCards_Click);
            // 
            // ShowMotherBoard
            // 
            this.ShowMotherBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowMotherBoard.Location = new System.Drawing.Point(194, 12);
            this.ShowMotherBoard.Name = "ShowMotherBoard";
            this.ShowMotherBoard.Size = new System.Drawing.Size(177, 36);
            this.ShowMotherBoard.TabIndex = 1;
            this.ShowMotherBoard.Text = "Материнские платы";
            this.ShowMotherBoard.UseVisualStyleBackColor = true;
            this.ShowMotherBoard.Click += new System.EventHandler(this.ShowMotherBoard_Click);
            // 
            // ShowRam
            // 
            this.ShowRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRam.Location = new System.Drawing.Point(194, 54);
            this.ShowRam.Name = "ShowRam";
            this.ShowRam.Size = new System.Drawing.Size(177, 36);
            this.ShowRam.TabIndex = 1;
            this.ShowRam.Text = "Оперативная память";
            this.ShowRam.UseVisualStyleBackColor = true;
            this.ShowRam.Click += new System.EventHandler(this.ShowRam_Click);
            // 
            // ShowDrivers
            // 
            this.ShowDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowDrivers.Location = new System.Drawing.Point(377, 12);
            this.ShowDrivers.Name = "ShowDrivers";
            this.ShowDrivers.Size = new System.Drawing.Size(175, 36);
            this.ShowDrivers.TabIndex = 1;
            this.ShowDrivers.Text = "Накопители";
            this.ShowDrivers.UseVisualStyleBackColor = true;
            this.ShowDrivers.Click += new System.EventHandler(this.ShowDrivers_Click);
            // 
            // ShowPowerSuplier
            // 
            this.ShowPowerSuplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPowerSuplier.Location = new System.Drawing.Point(377, 54);
            this.ShowPowerSuplier.Name = "ShowPowerSuplier";
            this.ShowPowerSuplier.Size = new System.Drawing.Size(175, 36);
            this.ShowPowerSuplier.TabIndex = 1;
            this.ShowPowerSuplier.Text = "Блоки питания";
            this.ShowPowerSuplier.UseVisualStyleBackColor = true;
            this.ShowPowerSuplier.Click += new System.EventHandler(this.ShowPowerSuplier_Click);
            // 
            // ShowCases
            // 
            this.ShowCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCases.Location = new System.Drawing.Point(558, 12);
            this.ShowCases.Name = "ShowCases";
            this.ShowCases.Size = new System.Drawing.Size(164, 36);
            this.ShowCases.TabIndex = 1;
            this.ShowCases.Text = "Корпусы";
            this.ShowCases.UseVisualStyleBackColor = true;
            this.ShowCases.Click += new System.EventHandler(this.ShowCases_Click);
            // 
            // ShowCaseFan
            // 
            this.ShowCaseFan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCaseFan.Location = new System.Drawing.Point(728, 12);
            this.ShowCaseFan.Name = "ShowCaseFan";
            this.ShowCaseFan.Size = new System.Drawing.Size(183, 36);
            this.ShowCaseFan.TabIndex = 1;
            this.ShowCaseFan.Text = "Корпусные кулеры";
            this.ShowCaseFan.UseVisualStyleBackColor = true;
            this.ShowCaseFan.Click += new System.EventHandler(this.ShowCaseFan_Click);
            // 
            // ShowCpuFan
            // 
            this.ShowCpuFan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCpuFan.Location = new System.Drawing.Point(558, 54);
            this.ShowCpuFan.Name = "ShowCpuFan";
            this.ShowCpuFan.Size = new System.Drawing.Size(164, 36);
            this.ShowCpuFan.TabIndex = 1;
            this.ShowCpuFan.Text = "Кулеры";
            this.ShowCpuFan.UseVisualStyleBackColor = true;
            this.ShowCpuFan.Click += new System.EventHandler(this.ShowCpuFan_Click);
            // 
            // ShowTermo
            // 
            this.ShowTermo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowTermo.Location = new System.Drawing.Point(728, 54);
            this.ShowTermo.Name = "ShowTermo";
            this.ShowTermo.Size = new System.Drawing.Size(183, 36);
            this.ShowTermo.TabIndex = 1;
            this.ShowTermo.Text = "Термопаста";
            this.ShowTermo.UseVisualStyleBackColor = true;
            this.ShowTermo.Click += new System.EventHandler(this.ShowTermo_Click);
            // 
            // ShowCart
            // 
            this.ShowCart.Location = new System.Drawing.Point(1020, 10);
            this.ShowCart.Name = "ShowCart";
            this.ShowCart.Size = new System.Drawing.Size(199, 58);
            this.ShowCart.TabIndex = 1;
            this.ShowCart.Text = "Корзина";
            this.ShowCart.UseVisualStyleBackColor = true;
            this.ShowCart.Click += new System.EventHandler(this.ShowCart_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(12, 120);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(498, 29);
            this.SearchTextBox.TabIndex = 2;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SortComboBox
            // 
            this.SortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortComboBox.FormattingEnabled = true;
            this.SortComboBox.Location = new System.Drawing.Point(864, 120);
            this.SortComboBox.Name = "SortComboBox";
            this.SortComboBox.Size = new System.Drawing.Size(199, 32);
            this.SortComboBox.TabIndex = 3;
            this.SortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(634, 121);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(224, 32);
            this.FilterComboBox.TabIndex = 3;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(860, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Стоимость";
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(630, 94);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(166, 24);
            this.filterLabel.TabIndex = 4;
            this.filterLabel.Text = "Количество ядер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Наименование";
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(1069, 96);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(150, 57);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "Сбросить фильтры";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // UserProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 682);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.SortComboBox);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ShowCart);
            this.Controls.Add(this.ShowTermo);
            this.Controls.Add(this.ShowCpuFan);
            this.Controls.Add(this.ShowCaseFan);
            this.Controls.Add(this.ShowCases);
            this.Controls.Add(this.ShowPowerSuplier);
            this.Controls.Add(this.ShowDrivers);
            this.Controls.Add(this.ShowRam);
            this.Controls.Add(this.ShowMotherBoard);
            this.Controls.Add(this.ShowVideoCards);
            this.Controls.Add(this.ShowProc);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserProduct";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигуратор";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}