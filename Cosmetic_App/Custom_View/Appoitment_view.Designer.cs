namespace Cosmetic_App.Custom_View
{
    partial class Appoitment_view
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
            this.description = new System.Windows.Forms.RichTextBox();
            this.worker_name = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.SystemColors.HighlightText;
            this.description.Font = new System.Drawing.Font("David", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(14, 50);
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(329, 47);
            this.description.TabIndex = 4;
            this.description.Text = "";
            // 
            // worker_name
            // 
            this.worker_name.BackColor = System.Drawing.SystemColors.HighlightText;
            this.worker_name.Font = new System.Drawing.Font("David", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worker_name.Location = new System.Drawing.Point(14, 14);
            this.worker_name.Name = "worker_name";
            this.worker_name.ReadOnly = true;
            this.worker_name.Size = new System.Drawing.Size(329, 30);
            this.worker_name.TabIndex = 5;
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.SystemColors.HighlightText;
            this.time.Font = new System.Drawing.Font("David", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(349, 14);
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Size = new System.Drawing.Size(81, 83);
            this.time.TabIndex = 6;
            this.time.Text = "";
            // 
            // Appoitment_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.time);
            this.Controls.Add(this.worker_name);
            this.Controls.Add(this.description);
            this.Name = "Appoitment_view";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(455, 111);
            this.Load += new System.EventHandler(this.Appoitment_view_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.TextBox worker_name;
        private System.Windows.Forms.RichTextBox time;
    }
}
