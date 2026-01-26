
namespace Kursovaya.User
{
    partial class UserMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMenu));
            this.OpenUserProdButton = new System.Windows.Forms.Button();
            this.OpenUserOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenUserProdButton
            // 
            this.OpenUserProdButton.Location = new System.Drawing.Point(39, 15);
            this.OpenUserProdButton.Margin = new System.Windows.Forms.Padding(6);
            this.OpenUserProdButton.Name = "OpenUserProdButton";
            this.OpenUserProdButton.Size = new System.Drawing.Size(138, 42);
            this.OpenUserProdButton.TabIndex = 0;
            this.OpenUserProdButton.Text = "Товары";
            this.OpenUserProdButton.UseVisualStyleBackColor = true;
            this.OpenUserProdButton.Click += new System.EventHandler(this.OpenUserProdButton_Click);
            // 
            // OpenUserOrder
            // 
            this.OpenUserOrder.Location = new System.Drawing.Point(39, 69);
            this.OpenUserOrder.Margin = new System.Windows.Forms.Padding(6);
            this.OpenUserOrder.Name = "OpenUserOrder";
            this.OpenUserOrder.Size = new System.Drawing.Size(138, 42);
            this.OpenUserOrder.TabIndex = 0;
            this.OpenUserOrder.Text = "Заказы";
            this.OpenUserOrder.UseVisualStyleBackColor = true;
            this.OpenUserOrder.Click += new System.EventHandler(this.OpenUserOrder_Click);
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 207);
            this.Controls.Add(this.OpenUserOrder);
            this.Controls.Add(this.OpenUserProdButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenUserProdButton;
        private System.Windows.Forms.Button OpenUserOrder;
    }
}