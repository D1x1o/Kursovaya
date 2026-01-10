
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
            this.ProdInStock = new System.Windows.Forms.Button();
            this.FormDocSupplyProd = new System.Windows.Forms.Button();
            this.addPic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProdInStock
            // 
            this.ProdInStock.Location = new System.Drawing.Point(47, 23);
            this.ProdInStock.Name = "ProdInStock";
            this.ProdInStock.Size = new System.Drawing.Size(227, 62);
            this.ProdInStock.TabIndex = 0;
            this.ProdInStock.Text = "Остатки товара";
            this.ProdInStock.UseVisualStyleBackColor = true;
            this.ProdInStock.Click += new System.EventHandler(this.ProdInStock_Click);
            // 
            // FormDocSupplyProd
            // 
            this.FormDocSupplyProd.Location = new System.Drawing.Point(47, 91);
            this.FormDocSupplyProd.Name = "FormDocSupplyProd";
            this.FormDocSupplyProd.Size = new System.Drawing.Size(227, 78);
            this.FormDocSupplyProd.TabIndex = 1;
            this.FormDocSupplyProd.Text = "Формировать запрос поставки товаров";
            this.FormDocSupplyProd.UseVisualStyleBackColor = true;
            this.FormDocSupplyProd.Click += new System.EventHandler(this.FormDocSupplyProd_Click);
            // 
            // addPic
            // 
            this.addPic.Location = new System.Drawing.Point(47, 175);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(227, 82);
            this.addPic.TabIndex = 1;
            this.addPic.Text = "Добавить изображения для товаров";
            this.addPic.UseVisualStyleBackColor = true;
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // ExpertMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 294);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.FormDocSupplyProd);
            this.Controls.Add(this.ProdInStock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ExpertMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню товароведа";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProdInStock;
        private System.Windows.Forms.Button FormDocSupplyProd;
        private System.Windows.Forms.Button addPic;
    }
}