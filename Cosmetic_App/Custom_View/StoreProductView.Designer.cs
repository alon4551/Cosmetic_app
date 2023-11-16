namespace Cosmetic_App.Custom_View
{
    partial class StoreProductView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.price_box = new System.Windows.Forms.TextBox();
            this.name_box = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.count_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "שם";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "מחיר";
            // 
            // price_box
            // 
            this.price_box.Location = new System.Drawing.Point(125, 38);
            this.price_box.Name = "price_box";
            this.price_box.ReadOnly = true;
            this.price_box.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price_box.Size = new System.Drawing.Size(72, 22);
            this.price_box.TabIndex = 3;
            // 
            // name_box
            // 
            this.name_box.Location = new System.Drawing.Point(55, 10);
            this.name_box.Name = "name_box";
            this.name_box.ReadOnly = true;
            this.name_box.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.name_box.Size = new System.Drawing.Size(145, 22);
            this.name_box.TabIndex = 4;
            this.name_box.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "כמות";
            // 
            // count_box
            // 
            this.count_box.Location = new System.Drawing.Point(55, 38);
            this.count_box.Name = "count_box";
            this.count_box.Size = new System.Drawing.Size(30, 22);
            this.count_box.TabIndex = 8;
            this.count_box.Text = "1";
            this.count_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StoreProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.count_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.name_box);
            this.Controls.Add(this.price_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StoreProductView";
            this.Size = new System.Drawing.Size(249, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox price_box;
        private System.Windows.Forms.RichTextBox name_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox count_box;
    }
}
