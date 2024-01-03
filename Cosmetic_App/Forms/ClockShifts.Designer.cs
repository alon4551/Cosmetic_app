namespace Cosmetic_App
{
    partial class ClockShifts
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
            this.interaction_layout = new System.Windows.Forms.TableLayoutPanel();
            this.clockout_button = new System.Windows.Forms.Button();
            this.clockin_button = new System.Windows.Forms.Button();
            this.Clock_Label = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.inform_user_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.interaction_layout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.502636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7645F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.557118F));
            this.tableLayoutPanel1.Controls.Add(this.interaction_layout, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Clock_Label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.date_label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inform_user_label, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.92337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.02682F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.3908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.83908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.195402F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 219);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // interaction_layout
            // 
            this.interaction_layout.ColumnCount = 5;
            this.interaction_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.interaction_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.1708F));
            this.interaction_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.47658F));
            this.interaction_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.1405F));
            this.interaction_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.interaction_layout.Controls.Add(this.clockout_button, 1, 0);
            this.interaction_layout.Controls.Add(this.clockin_button, 3, 0);
            this.interaction_layout.Controls.Add(this.button1, 2, 0);
            this.interaction_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interaction_layout.Location = new System.Drawing.Point(29, 150);
            this.interaction_layout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.interaction_layout.Name = "interaction_layout";
            this.interaction_layout.RowCount = 1;
            this.interaction_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.interaction_layout.Size = new System.Drawing.Size(363, 44);
            this.interaction_layout.TabIndex = 0;
            // 
            // clockout_button
            // 
            this.clockout_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockout_button.Enabled = false;
            this.clockout_button.Font = new System.Drawing.Font("David", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockout_button.Location = new System.Drawing.Point(40, 2);
            this.clockout_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clockout_button.Name = "clockout_button";
            this.clockout_button.Size = new System.Drawing.Size(91, 40);
            this.clockout_button.TabIndex = 1;
            this.clockout_button.Text = "לצאת מהמשמרת";
            this.clockout_button.UseVisualStyleBackColor = true;
            this.clockout_button.Click += new System.EventHandler(this.clockout_button_Click);
            // 
            // clockin_button
            // 
            this.clockin_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockin_button.Enabled = false;
            this.clockin_button.Font = new System.Drawing.Font("David", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockin_button.Location = new System.Drawing.Point(242, 2);
            this.clockin_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clockin_button.Name = "clockin_button";
            this.clockin_button.Size = new System.Drawing.Size(80, 40);
            this.clockin_button.TabIndex = 0;
            this.clockin_button.Text = "להכנס למשמרת";
            this.clockin_button.UseVisualStyleBackColor = true;
            this.clockin_button.Click += new System.EventHandler(this.clockin_button_Click);
            // 
            // Clock_Label
            // 
            this.Clock_Label.AutoSize = true;
            this.Clock_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clock_Label.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Clock_Label.Location = new System.Drawing.Point(29, 36);
            this.Clock_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Clock_Label.Name = "Clock_Label";
            this.Clock_Label.Size = new System.Drawing.Size(363, 44);
            this.Clock_Label.TabIndex = 1;
            this.Clock_Label.Text = "label1";
            this.Clock_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_label.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.date_label.Location = new System.Drawing.Point(29, 0);
            this.date_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(363, 36);
            this.date_label.TabIndex = 2;
            this.date_label.Text = "label2";
            this.date_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.82158F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.12863F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.85714F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.id, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(29, 82);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(363, 24);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(2, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 20);
            this.button3.TabIndex = 0;
            this.button3.Text = "חיפוש";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(300, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "תעודת זהות";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            this.id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id.Location = new System.Drawing.Point(85, 2);
            this.id.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(211, 20);
            this.id.TabIndex = 2;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_KeyDown);
            // 
            // inform_user_label
            // 
            this.inform_user_label.AutoSize = true;
            this.inform_user_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inform_user_label.Location = new System.Drawing.Point(29, 108);
            this.inform_user_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.inform_user_label.Name = "inform_user_label";
            this.inform_user_label.Size = new System.Drawing.Size(363, 40);
            this.inform_user_label.TabIndex = 4;
            this.inform_user_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(136, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "כל המשמרות";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClockShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 219);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(444, 258);
            this.Name = "ClockShifts";
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.ManageShifts_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.interaction_layout.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel interaction_layout;
        private System.Windows.Forms.Button clockout_button;
        private System.Windows.Forms.Button clockin_button;
        private System.Windows.Forms.Label Clock_Label;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label inform_user_label;
        private System.Windows.Forms.Button button1;
    }
}