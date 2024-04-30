namespace Cosmetic_App.Custom_View
{
    partial class Cart_Schedule_View
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
            this.treatment_box = new System.Windows.Forms.RichTextBox();
            this.SetDate_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.worker_namebox = new System.Windows.Forms.TextBox();
            this.time_box = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.57728F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.treatment_box, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SetDate_btn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_btn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.worker_namebox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.time_box, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(274, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "סוג טיפול";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(274, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "שעה ותאריך";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treatment_box
            // 
            this.treatment_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatment_box.Location = new System.Drawing.Point(152, 3);
            this.treatment_box.Name = "treatment_box";
            this.treatment_box.ReadOnly = true;
            this.treatment_box.Size = new System.Drawing.Size(116, 23);
            this.treatment_box.TabIndex = 5;
            this.treatment_box.Text = "";
            // 
            // SetDate_btn
            // 
            this.SetDate_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetDate_btn.Location = new System.Drawing.Point(3, 3);
            this.SetDate_btn.Name = "SetDate_btn";
            this.SetDate_btn.Size = new System.Drawing.Size(74, 23);
            this.SetDate_btn.TabIndex = 1;
            this.SetDate_btn.Text = "לקבוע";
            this.SetDate_btn.UseVisualStyleBackColor = true;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_btn.Location = new System.Drawing.Point(3, 32);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(74, 24);
            this.Cancel_btn.TabIndex = 0;
            this.Cancel_btn.Text = "ביטול";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(83, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "עובד";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // worker_namebox
            // 
            this.worker_namebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worker_namebox.Location = new System.Drawing.Point(83, 32);
            this.worker_namebox.Name = "worker_namebox";
            this.worker_namebox.Size = new System.Drawing.Size(63, 20);
            this.worker_namebox.TabIndex = 11;
            // 
            // time_box
            // 
            this.time_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.time_box.Location = new System.Drawing.Point(152, 32);
            this.time_box.Name = "time_box";
            this.time_box.ReadOnly = true;
            this.time_box.Size = new System.Drawing.Size(116, 20);
            this.time_box.TabIndex = 12;
            // 
            // Cart_Schedule_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Cart_Schedule_View";
            this.Size = new System.Drawing.Size(360, 59);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SetDate_btn;
        private System.Windows.Forms.RichTextBox treatment_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox worker_namebox;
        private System.Windows.Forms.TextBox time_box;
    }
}
