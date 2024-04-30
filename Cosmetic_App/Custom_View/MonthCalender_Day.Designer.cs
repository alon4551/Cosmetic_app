namespace Cosmetic_App
{
    partial class MonthCalender_Day
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
            this.treatments_label = new System.Windows.Forms.TextBox();
            this.tablelayout = new System.Windows.Forms.TableLayoutPanel();
            this.tablelayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // treatments_label
            // 
            this.treatments_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treatments_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatments_label.Location = new System.Drawing.Point(2, 35);
            this.treatments_label.Margin = new System.Windows.Forms.Padding(2);
            this.treatments_label.Name = "treatments_label";
            this.treatments_label.ReadOnly = true;
            this.treatments_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treatments_label.Size = new System.Drawing.Size(99, 20);
            this.treatments_label.TabIndex = 1;
            // 
            // tablelayout
            // 
            this.tablelayout.BackColor = System.Drawing.Color.Transparent;
            this.tablelayout.ColumnCount = 1;
            this.tablelayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelayout.Controls.Add(this.label1, 0, 0);
            this.tablelayout.Controls.Add(this.treatments_label, 0, 1);
            this.tablelayout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tablelayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelayout.Location = new System.Drawing.Point(0, 0);
            this.tablelayout.Margin = new System.Windows.Forms.Padding(2);
            this.tablelayout.Name = "tablelayout";
            this.tablelayout.RowCount = 2;
            this.tablelayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelayout.Size = new System.Drawing.Size(103, 66);
            this.tablelayout.TabIndex = 2;
            // 
            // MonthCalender_Day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tablelayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MonthCalender_Day";
            this.Size = new System.Drawing.Size(103, 66);
            this.Load += new System.EventHandler(this.UserControl_Day_Load);
            this.tablelayout.ResumeLayout(false);
            this.tablelayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox treatments_label;
        private System.Windows.Forms.TableLayoutPanel tablelayout;
    }
}
