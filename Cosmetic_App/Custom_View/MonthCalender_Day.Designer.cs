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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(107, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "00";
            // 
            // treatments_label
            // 
            this.treatments_label.Location = new System.Drawing.Point(23, 45);
            this.treatments_label.Name = "treatments_label";
            this.treatments_label.ReadOnly = true;
            this.treatments_label.Size = new System.Drawing.Size(111, 22);
            this.treatments_label.TabIndex = 1;
            this.treatments_label.Click += new System.EventHandler(this.treatments_label_Click);
            // 
            // MonthCalender_Day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treatments_label);
            this.Controls.Add(this.label1);
            this.Name = "MonthCalender_Day";
            this.Size = new System.Drawing.Size(137, 81);
            this.Load += new System.EventHandler(this.UserControl_Day_Load);
            this.Click += new System.EventHandler(this.MonthCalender_Day_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox treatments_label;
    }
}
