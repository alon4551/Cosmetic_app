namespace Cosmetic_App.Forms
{
    partial class Product_Dashbord
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.FlowLayoutPanel();
            this.insert_button = new System.Windows.Forms.Button();
            this.layout_product_all = new System.Windows.Forms.TableLayoutPanel();
            this.product_table_layout = new System.Windows.Forms.TableLayoutPanel();
            this.product_name = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.p_info = new System.Windows.Forms.TextBox();
            this.p_info_label = new System.Windows.Forms.Label();
            this.p_price_label = new System.Windows.Forms.Label();
            this.p_name_label = new System.Windows.Forms.Label();
            this.update_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.layout_product_all.SuspendLayout();
            this.product_table_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.291005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.32804F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.32804F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.291006F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.insert_button, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.layout_product_all, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.853119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.07445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.054326F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.816901F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 491);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.s, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(394, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.58231F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.41769F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(311, 383);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.13115F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.86885F));
            this.tableLayoutPanel4.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(305, 30);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(3, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(223, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "שם";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // s
            // 
            this.s.AutoScroll = true;
            this.s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s.Location = new System.Drawing.Point(3, 39);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(305, 341);
            this.s.TabIndex = 1;
            // 
            // insert_button
            // 
            this.insert_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.insert_button.Location = new System.Drawing.Point(394, 435);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(311, 32);
            this.insert_button.TabIndex = 3;
            this.insert_button.Text = "מוצר / טיפול חדש";
            this.insert_button.UseVisualStyleBackColor = true;
            this.insert_button.Click += new System.EventHandler(this.NewProduct_Click);
            // 
            // layout_product_all
            // 
            this.layout_product_all.ColumnCount = 1;
            this.layout_product_all.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_product_all.Controls.Add(this.product_table_layout, 0, 1);
            this.layout_product_all.Controls.Add(this.update_button, 0, 2);
            this.layout_product_all.Controls.Add(this.label1, 0, 0);
            this.layout_product_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_product_all.Location = new System.Drawing.Point(42, 46);
            this.layout_product_all.Name = "layout_product_all";
            this.layout_product_all.RowCount = 3;
            this.layout_product_all.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.79896F));
            this.layout_product_all.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.03133F));
            this.layout_product_all.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.16971F));
            this.layout_product_all.Size = new System.Drawing.Size(311, 383);
            this.layout_product_all.TabIndex = 4;
            // 
            // product_table_layout
            // 
            this.product_table_layout.ColumnCount = 2;
            this.product_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.16393F));
            this.product_table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.83607F));
            this.product_table_layout.Controls.Add(this.product_name, 0, 0);
            this.product_table_layout.Controls.Add(this.price, 0, 1);
            this.product_table_layout.Controls.Add(this.p_info, 0, 2);
            this.product_table_layout.Controls.Add(this.p_info_label, 1, 2);
            this.product_table_layout.Controls.Add(this.p_price_label, 1, 1);
            this.product_table_layout.Controls.Add(this.p_name_label, 1, 0);
            this.product_table_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product_table_layout.Location = new System.Drawing.Point(3, 75);
            this.product_table_layout.Name = "product_table_layout";
            this.product_table_layout.RowCount = 3;
            this.product_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.17825F));
            this.product_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.2719F));
            this.product_table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.17825F));
            this.product_table_layout.Size = new System.Drawing.Size(305, 131);
            this.product_table_layout.TabIndex = 1;
            // 
            // product_name
            // 
            this.product_name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.product_name.Location = new System.Drawing.Point(3, 19);
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            this.product_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.product_name.Size = new System.Drawing.Size(208, 22);
            this.product_name.TabIndex = 5;
            // 
            // price
            // 
            this.price.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.price.Location = new System.Drawing.Point(3, 60);
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price.Size = new System.Drawing.Size(208, 22);
            this.price.TabIndex = 6;
            // 
            // p_info
            // 
            this.p_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_info.Location = new System.Drawing.Point(3, 106);
            this.p_info.Name = "p_info";
            this.p_info.ReadOnly = true;
            this.p_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.p_info.Size = new System.Drawing.Size(208, 22);
            this.p_info.TabIndex = 7;
            // 
            // p_info_label
            // 
            this.p_info_label.AutoSize = true;
            this.p_info_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_info_label.Location = new System.Drawing.Point(217, 115);
            this.p_info_label.Name = "p_info_label";
            this.p_info_label.Size = new System.Drawing.Size(85, 16);
            this.p_info_label.TabIndex = 1;
            this.p_info_label.Text = "כמות";
            this.p_info_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p_price_label
            // 
            this.p_price_label.AutoSize = true;
            this.p_price_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_price_label.Location = new System.Drawing.Point(217, 69);
            this.p_price_label.Name = "p_price_label";
            this.p_price_label.Size = new System.Drawing.Size(85, 16);
            this.p_price_label.TabIndex = 0;
            this.p_price_label.Text = "מחיר";
            this.p_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p_name_label
            // 
            this.p_name_label.AutoSize = true;
            this.p_name_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_name_label.Location = new System.Drawing.Point(217, 28);
            this.p_name_label.Name = "p_name_label";
            this.p_name_label.Size = new System.Drawing.Size(85, 16);
            this.p_name_label.TabIndex = 1;
            this.p_name_label.Text = "שם";
            this.p_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // update_button
            // 
            this.update_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.update_button.Location = new System.Drawing.Point(3, 212);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(305, 32);
            this.update_button.TabIndex = 2;
            this.update_button.Text = "עדכון פרטים";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(305, 72);
            this.label1.TabIndex = 8;
            this.label1.Text = "פרטים על המוצר";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Product_Dashbord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 491);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Product_Dashbord";
            this.Text = "Product_Dashbord";
            this.Load += new System.EventHandler(this.Product_Dashbord_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.layout_product_all.ResumeLayout(false);
            this.layout_product_all.PerformLayout();
            this.product_table_layout.ResumeLayout(false);
            this.product_table_layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel product_table_layout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label p_name_label;
        private System.Windows.Forms.FlowLayoutPanel s;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label p_price_label;
        private System.Windows.Forms.Label p_info_label;
        private System.Windows.Forms.TextBox product_name;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox p_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel layout_product_all;
    }
}