namespace Cosmetic_App.Custom_View
{
    partial class stat_item
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sumbox = new System.Windows.Forms.TextBox();
            this.amountbox = new System.Windows.Forms.TextBox();
            this.pricebox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sumbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.amountbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pricebox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.namebox, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(372, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "שם מוצר";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(249, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "מחיר ליחידה";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "סה\"כ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(126, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "כמות";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sumbox
            // 
            this.sumbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumbox.Location = new System.Drawing.Point(3, 29);
            this.sumbox.Name = "sumbox";
            this.sumbox.ReadOnly = true;
            this.sumbox.Size = new System.Drawing.Size(117, 20);
            this.sumbox.TabIndex = 4;
            this.sumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amountbox
            // 
            this.amountbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amountbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountbox.Location = new System.Drawing.Point(126, 29);
            this.amountbox.Name = "amountbox";
            this.amountbox.ReadOnly = true;
            this.amountbox.Size = new System.Drawing.Size(117, 20);
            this.amountbox.TabIndex = 5;
            this.amountbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pricebox
            // 
            this.pricebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pricebox.Location = new System.Drawing.Point(249, 29);
            this.pricebox.Name = "pricebox";
            this.pricebox.ReadOnly = true;
            this.pricebox.Size = new System.Drawing.Size(117, 20);
            this.pricebox.TabIndex = 6;
            this.pricebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // namebox
            // 
            this.namebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namebox.Location = new System.Drawing.Point(372, 29);
            this.namebox.Name = "namebox";
            this.namebox.ReadOnly = true;
            this.namebox.Size = new System.Drawing.Size(117, 20);
            this.namebox.TabIndex = 7;
            this.namebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stat_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "stat_item";
            this.Size = new System.Drawing.Size(492, 52);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sumbox;
        private System.Windows.Forms.TextBox amountbox;
        private System.Windows.Forms.TextBox pricebox;
        private System.Windows.Forms.TextBox namebox;
    }
}
