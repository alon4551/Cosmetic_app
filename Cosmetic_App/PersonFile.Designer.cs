namespace Cosmetic_App
{
    partial class PersonFile
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
            this.id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.birthday = new System.Windows.Forms.DateTimePicker();
            this.profile_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Profile_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Worker_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.RePassword = new System.Windows.Forms.TextBox();
            this.Admin_checkBox = new System.Windows.Forms.CheckBox();
            this.profile_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Profile_Layout.SuspendLayout();
            this.Worker_Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id.Location = new System.Drawing.Point(24, 113);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(336, 22);
            this.id.TabIndex = 0;
            this.id.TextChanged += new System.EventHandler(this.TextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(24, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "שם פרטי";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(24, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "שם משפחה";
            // 
            // firstname
            // 
            this.firstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstname.Location = new System.Drawing.Point(24, 170);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(336, 22);
            this.firstname.TabIndex = 2;
            this.firstname.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "תעודת זהות";
            // 
            // lastname
            // 
            this.lastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastname.Location = new System.Drawing.Point(24, 226);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(336, 22);
            this.lastname.TabIndex = 4;
            this.lastname.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(24, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(336, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "יום הולדת";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(24, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(336, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "פאלפון";
            // 
            // phone
            // 
            this.phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phone.Location = new System.Drawing.Point(24, 334);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(336, 22);
            this.phone.TabIndex = 8;
            this.phone.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(24, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "דואר אלקטרוני";
            // 
            // email
            // 
            this.email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.email.Location = new System.Drawing.Point(24, 380);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(336, 22);
            this.email.TabIndex = 10;
            this.email.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(200, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 42);
            this.button2.TabIndex = 14;
            this.button2.Text = "מחיקה";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 42);
            this.button3.TabIndex = 15;
            this.button3.Text = "שמירה";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // birthday
            // 
            this.birthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.birthday.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthday.Location = new System.Drawing.Point(24, 282);
            this.birthday.Name = "birthday";
            this.birthday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.birthday.RightToLeftLayout = true;
            this.birthday.Size = new System.Drawing.Size(336, 22);
            this.birthday.TabIndex = 16;
            // 
            // profile_control
            // 
            this.profile_control.Controls.Add(this.tabPage1);
            this.profile_control.Controls.Add(this.tabPage2);
            this.profile_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profile_control.Location = new System.Drawing.Point(3, 3);
            this.profile_control.Name = "profile_control";
            this.profile_control.RightToLeftLayout = true;
            this.profile_control.SelectedIndex = 0;
            this.profile_control.Size = new System.Drawing.Size(394, 494);
            this.profile_control.TabIndex = 17;
            this.profile_control.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Profile_Layout);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "פרופיל אדם";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Worker_Layout);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "פרופיל עובד";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.profile_control, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.25271F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.747293F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 554);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 503);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 48);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // Profile_Layout
            // 
            this.Profile_Layout.ColumnCount = 3;
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.2381F));
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Profile_Layout.Controls.Add(this.label3, 1, 1);
            this.Profile_Layout.Controls.Add(this.label6, 1, 11);
            this.Profile_Layout.Controls.Add(this.birthday, 1, 8);
            this.Profile_Layout.Controls.Add(this.email, 1, 12);
            this.Profile_Layout.Controls.Add(this.label1, 1, 3);
            this.Profile_Layout.Controls.Add(this.phone, 1, 10);
            this.Profile_Layout.Controls.Add(this.label5, 1, 9);
            this.Profile_Layout.Controls.Add(this.label2, 1, 5);
            this.Profile_Layout.Controls.Add(this.lastname, 1, 6);
            this.Profile_Layout.Controls.Add(this.firstname, 1, 4);
            this.Profile_Layout.Controls.Add(this.label4, 1, 7);
            this.Profile_Layout.Controls.Add(this.id, 1, 2);
            this.Profile_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Profile_Layout.Location = new System.Drawing.Point(3, 3);
            this.Profile_Layout.Name = "Profile_Layout";
            this.Profile_Layout.RowCount = 14;
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.38532F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.61468F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.Profile_Layout.Size = new System.Drawing.Size(380, 459);
            this.Profile_Layout.TabIndex = 17;
            // 
            // Worker_Layout
            // 
            this.Worker_Layout.ColumnCount = 3;
            this.Worker_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.Worker_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.Worker_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.Worker_Layout.Controls.Add(this.label7, 1, 1);
            this.Worker_Layout.Controls.Add(this.label8, 1, 3);
            this.Worker_Layout.Controls.Add(this.Password, 1, 2);
            this.Worker_Layout.Controls.Add(this.RePassword, 1, 4);
            this.Worker_Layout.Controls.Add(this.Admin_checkBox, 1, 6);
            this.Worker_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Worker_Layout.Location = new System.Drawing.Point(3, 3);
            this.Worker_Layout.Name = "Worker_Layout";
            this.Worker_Layout.RowCount = 8;
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Worker_Layout.Size = new System.Drawing.Size(380, 459);
            this.Worker_Layout.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(36, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "סיסמא";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(36, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(310, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "וידוא סיסמא";
            // 
            // Password
            // 
            this.Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Password.Location = new System.Drawing.Point(36, 117);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(310, 22);
            this.Password.TabIndex = 3;
            // 
            // RePassword
            // 
            this.RePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RePassword.Location = new System.Drawing.Point(36, 231);
            this.RePassword.Name = "RePassword";
            this.RePassword.Size = new System.Drawing.Size(310, 22);
            this.RePassword.TabIndex = 4;
            // 
            // Admin_checkBox
            // 
            this.Admin_checkBox.AutoSize = true;
            this.Admin_checkBox.Location = new System.Drawing.Point(246, 345);
            this.Admin_checkBox.Name = "Admin_checkBox";
            this.Admin_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Admin_checkBox.Size = new System.Drawing.Size(100, 20);
            this.Admin_checkBox.TabIndex = 5;
            this.Admin_checkBox.Text = "מנהל מערכת";
            this.Admin_checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Admin_checkBox.UseVisualStyleBackColor = true;
            // 
            // PersonFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PersonFile";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "PersonFile";
            this.Load += new System.EventHandler(this.PersonFile_Load);
            this.profile_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.Profile_Layout.ResumeLayout(false);
            this.Profile_Layout.PerformLayout();
            this.Worker_Layout.ResumeLayout(false);
            this.Worker_Layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker birthday;
        private System.Windows.Forms.TabControl profile_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel Profile_Layout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel Worker_Layout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox RePassword;
        private System.Windows.Forms.CheckBox Admin_checkBox;
    }
}