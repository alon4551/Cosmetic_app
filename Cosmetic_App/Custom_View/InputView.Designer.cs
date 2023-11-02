namespace Cosmetic_App.Custom_View
{
    partial class InputView
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
            this.Fname = new System.Windows.Forms.Label();
            this.input_box = new System.Windows.Forms.TextBox();
            this.hint = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.2F));
            this.tableLayoutPanel1.Controls.Add(this.Fname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.input_box, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hint, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Fname
            // 
            this.Fname.AutoSize = true;
            this.Fname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Fname.Location = new System.Drawing.Point(185, 14);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(62, 16);
            this.Fname.TabIndex = 0;
            this.Fname.Text = "label1";
            // 
            // input_box
            // 
            this.input_box.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.input_box.Location = new System.Drawing.Point(3, 5);
            this.input_box.Name = "input_box";
            this.input_box.Size = new System.Drawing.Size(176, 22);
            this.input_box.TabIndex = 1;
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Dock = System.Windows.Forms.DockStyle.Top;
            this.hint.Location = new System.Drawing.Point(3, 30);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(176, 16);
            this.hint.TabIndex = 2;
            this.hint.Text = "label2";
            // 
            // InputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InputView";
            this.Size = new System.Drawing.Size(250, 60);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Fname;
        private System.Windows.Forms.TextBox input_box;
        private System.Windows.Forms.Label hint;
    }
}
