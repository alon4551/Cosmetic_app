namespace Cosmetic_App.Custom_View
{
    partial class ProductView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.product_name = new System.Windows.Forms.Label();
            this.table_product_layout = new System.Windows.Forms.TableLayoutPanel();
            this.product_price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.table_product_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // product_name
            // 
            this.product_name.AutoSize = true;
            this.product_name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.product_name.Font = new System.Drawing.Font("David", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.product_name.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.product_name.Location = new System.Drawing.Point(74, 6);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(178, 23);
            this.product_name.TabIndex = 0;
            this.product_name.Text = "שם";
            this.product_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // table_product_layout
            // 
            this.table_product_layout.ColumnCount = 2;
            this.table_product_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.23529F));
            this.table_product_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.76471F));
            this.table_product_layout.Controls.Add(this.product_name, 1, 0);
            this.table_product_layout.Controls.Add(this.product_price, 0, 0);
            this.table_product_layout.Controls.Add(this.label1, 1, 1);
            this.table_product_layout.Controls.Add(this.label2, 0, 1);
            this.table_product_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_product_layout.Location = new System.Drawing.Point(0, 0);
            this.table_product_layout.Name = "table_product_layout";
            this.table_product_layout.RowCount = 2;
            this.table_product_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.92032F));
            this.table_product_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.11196F));
            this.table_product_layout.Size = new System.Drawing.Size(255, 84);
            this.table_product_layout.TabIndex = 4;
            this.table_product_layout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // product_price
            // 
            this.product_price.AutoSize = true;
            this.product_price.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.product_price.Font = new System.Drawing.Font("David", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.product_price.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.product_price.Location = new System.Drawing.Point(3, 6);
            this.product_price.Name = "product_price";
            this.product_price.Size = new System.Drawing.Size(65, 23);
            this.product_price.TabIndex = 2;
            this.product_price.Text = "מחיר";
            this.product_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(74, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(178, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(65, 55);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.table_product_layout);
            this.Name = "ProductView";
            this.Size = new System.Drawing.Size(255, 84);
            this.Load += new System.EventHandler(this.ProductView_Load);
            this.table_product_layout.ResumeLayout(false);
            this.table_product_layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label product_name;
        private System.Windows.Forms.TableLayoutPanel table_product_layout;
        private System.Windows.Forms.Label product_price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
