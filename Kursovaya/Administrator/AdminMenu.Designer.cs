
namespace Kursovaya.Administrator
{
    partial class AdminMenu
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
            this.ShowUsers = new System.Windows.Forms.Button();
            this.ShowOrders = new System.Windows.Forms.Button();
            this.ShowProducts = new System.Windows.Forms.Button();
            this.AddProdPicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowUsers
            // 
            this.ShowUsers.Location = new System.Drawing.Point(48, 15);
            this.ShowUsers.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ShowUsers.Name = "ShowUsers";
            this.ShowUsers.Size = new System.Drawing.Size(149, 42);
            this.ShowUsers.TabIndex = 0;
            this.ShowUsers.Text = "Пользователи";
            this.ShowUsers.UseVisualStyleBackColor = true;
            this.ShowUsers.Click += new System.EventHandler(this.ShowUsers_Click);
            // 
            // ShowOrders
            // 
            this.ShowOrders.Location = new System.Drawing.Point(48, 69);
            this.ShowOrders.Margin = new System.Windows.Forms.Padding(6);
            this.ShowOrders.Name = "ShowOrders";
            this.ShowOrders.Size = new System.Drawing.Size(149, 42);
            this.ShowOrders.TabIndex = 0;
            this.ShowOrders.Text = "Заказы";
            this.ShowOrders.UseVisualStyleBackColor = true;
            this.ShowOrders.Click += new System.EventHandler(this.ShowOrders_Click);
            // 
            // ShowProducts
            // 
            this.ShowProducts.Location = new System.Drawing.Point(48, 123);
            this.ShowProducts.Margin = new System.Windows.Forms.Padding(6);
            this.ShowProducts.Name = "ShowProducts";
            this.ShowProducts.Size = new System.Drawing.Size(149, 42);
            this.ShowProducts.TabIndex = 0;
            this.ShowProducts.Text = "Товары";
            this.ShowProducts.UseVisualStyleBackColor = true;
            this.ShowProducts.Click += new System.EventHandler(this.ShowProducts_Click);
            // 
            // AddProdPicture
            // 
            this.AddProdPicture.Location = new System.Drawing.Point(48, 177);
            this.AddProdPicture.Margin = new System.Windows.Forms.Padding(6);
            this.AddProdPicture.Name = "AddProdPicture";
            this.AddProdPicture.Size = new System.Drawing.Size(149, 58);
            this.AddProdPicture.TabIndex = 0;
            this.AddProdPicture.Text = "Изображения товаров";
            this.AddProdPicture.UseVisualStyleBackColor = true;
            this.AddProdPicture.Click += new System.EventHandler(this.AddProdPicture_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 337);
            this.Controls.Add(this.AddProdPicture);
            this.Controls.Add(this.ShowProducts);
            this.Controls.Add(this.ShowOrders);
            this.Controls.Add(this.ShowUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "AdminMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowUsers;
        private System.Windows.Forms.Button ShowOrders;
        private System.Windows.Forms.Button ShowProducts;
        private System.Windows.Forms.Button AddProdPicture;
    }
}