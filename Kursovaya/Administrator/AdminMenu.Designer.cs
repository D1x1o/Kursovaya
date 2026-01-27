
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
            this.ShowUsers = new System.Windows.Forms.Button();
            this.ShowOrders = new System.Windows.Forms.Button();
            this.ShowProducts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowUsers
            // 
            this.ShowUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowUsers.ForeColor = System.Drawing.Color.White;
            this.ShowUsers.Location = new System.Drawing.Point(48, 15);
            this.ShowUsers.Margin = new System.Windows.Forms.Padding(6);
            this.ShowUsers.Name = "ShowUsers";
            this.ShowUsers.Size = new System.Drawing.Size(149, 42);
            this.ShowUsers.TabIndex = 0;
            this.ShowUsers.Text = "Пользователи";
            this.ShowUsers.UseVisualStyleBackColor = false;
            this.ShowUsers.Click += new System.EventHandler(this.ShowUsers_Click);
            // 
            // ShowOrders
            // 
            this.ShowOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowOrders.ForeColor = System.Drawing.Color.White;
            this.ShowOrders.Location = new System.Drawing.Point(48, 69);
            this.ShowOrders.Margin = new System.Windows.Forms.Padding(6);
            this.ShowOrders.Name = "ShowOrders";
            this.ShowOrders.Size = new System.Drawing.Size(149, 42);
            this.ShowOrders.TabIndex = 0;
            this.ShowOrders.Text = "Заказы";
            this.ShowOrders.UseVisualStyleBackColor = false;
            this.ShowOrders.Click += new System.EventHandler(this.ShowOrders_Click);
            // 
            // ShowProducts
            // 
            this.ShowProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(150)))), ((int)(((byte)(125)))));
            this.ShowProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowProducts.ForeColor = System.Drawing.Color.White;
            this.ShowProducts.Location = new System.Drawing.Point(48, 123);
            this.ShowProducts.Margin = new System.Windows.Forms.Padding(6);
            this.ShowProducts.Name = "ShowProducts";
            this.ShowProducts.Size = new System.Drawing.Size(149, 42);
            this.ShowProducts.TabIndex = 0;
            this.ShowProducts.Text = "Товары";
            this.ShowProducts.UseVisualStyleBackColor = false;
            this.ShowProducts.Click += new System.EventHandler(this.ShowProducts_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(91)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(250, 227);
            this.Controls.Add(this.ShowProducts);
            this.Controls.Add(this.ShowOrders);
            this.Controls.Add(this.ShowUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "AdminMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowUsers;
        private System.Windows.Forms.Button ShowOrders;
        private System.Windows.Forms.Button ShowProducts;
    }
}