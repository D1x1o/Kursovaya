
namespace Kursovaya.ProdExpert
{
    partial class ExpertMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertMenu));
            this.ProdInStock = new System.Windows.Forms.Button();
            this.FormDocSupplyProd = new System.Windows.Forms.Button();
            this.addPic = new System.Windows.Forms.Button();
            this.EditProdButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProdInStock
            // 
            this.ProdInStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ProdInStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProdInStock.ForeColor = System.Drawing.Color.White;
            this.ProdInStock.Location = new System.Drawing.Point(47, 23);
            this.ProdInStock.Name = "ProdInStock";
            this.ProdInStock.Size = new System.Drawing.Size(227, 62);
            this.ProdInStock.TabIndex = 0;
            this.ProdInStock.Text = "Остатки товара";
            this.ProdInStock.UseVisualStyleBackColor = false;
            this.ProdInStock.Click += new System.EventHandler(this.ProdInStock_Click);
            // 
            // FormDocSupplyProd
            // 
            this.FormDocSupplyProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.FormDocSupplyProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormDocSupplyProd.ForeColor = System.Drawing.Color.White;
            this.FormDocSupplyProd.Location = new System.Drawing.Point(47, 91);
            this.FormDocSupplyProd.Name = "FormDocSupplyProd";
            this.FormDocSupplyProd.Size = new System.Drawing.Size(227, 78);
            this.FormDocSupplyProd.TabIndex = 1;
            this.FormDocSupplyProd.Text = "Формировать запрос поставки товаров";
            this.FormDocSupplyProd.UseVisualStyleBackColor = false;
            this.FormDocSupplyProd.Click += new System.EventHandler(this.FormDocSupplyProd_Click);
            // 
            // addPic
            // 
            this.addPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.addPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPic.ForeColor = System.Drawing.Color.White;
            this.addPic.Location = new System.Drawing.Point(47, 175);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(227, 82);
            this.addPic.TabIndex = 1;
            this.addPic.Text = "Добавить изображения для товаров";
            this.addPic.UseVisualStyleBackColor = false;
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // EditProdButton
            // 
            this.EditProdButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.EditProdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProdButton.ForeColor = System.Drawing.Color.White;
            this.EditProdButton.Location = new System.Drawing.Point(47, 263);
            this.EditProdButton.Name = "EditProdButton";
            this.EditProdButton.Size = new System.Drawing.Size(227, 82);
            this.EditProdButton.TabIndex = 1;
            this.EditProdButton.Text = "Редактирование товаров";
            this.EditProdButton.UseVisualStyleBackColor = false;
            this.EditProdButton.Click += new System.EventHandler(this.EditProdButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(47, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавление категории товаров";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(47, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавление товаров";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ExpertMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(315, 536);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EditProdButton);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.FormDocSupplyProd);
            this.Controls.Add(this.ProdInStock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ExpertMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню товароведа";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProdInStock;
        private System.Windows.Forms.Button FormDocSupplyProd;
        private System.Windows.Forms.Button addPic;
        private System.Windows.Forms.Button EditProdButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}