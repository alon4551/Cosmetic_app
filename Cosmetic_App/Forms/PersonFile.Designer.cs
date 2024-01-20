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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonFile));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.profile_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Profile_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.birthday = new System.Windows.Forms.DateTimePicker();
            this.email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.profile_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Profile_Layout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(202, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 48);
            this.button2.TabIndex = 14;
            this.button2.Text = "מחיקה";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(4, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 48);
            this.button3.TabIndex = 15;
            this.button3.Text = "שמירה";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.profile_control, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.25271F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.747293F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 608);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // profile_control
            // 
            this.profile_control.Controls.Add(this.tabPage1);
            this.profile_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profile_control.Location = new System.Drawing.Point(4, 3);
            this.profile_control.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.profile_control.Name = "profile_control";
            this.profile_control.RightToLeftLayout = true;
            this.profile_control.SelectedIndex = 0;
            this.profile_control.Size = new System.Drawing.Size(395, 542);
            this.profile_control.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Profile_Layout);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(387, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "פרופיל אדם";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Profile_Layout
            // 
            this.Profile_Layout.ColumnCount = 3;
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.2381F));
            this.Profile_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Profile_Layout.Controls.Add(this.label3, 1, 0);
            this.Profile_Layout.Controls.Add(this.label6, 1, 10);
            this.Profile_Layout.Controls.Add(this.birthday, 1, 7);
            this.Profile_Layout.Controls.Add(this.email, 1, 11);
            this.Profile_Layout.Controls.Add(this.label1, 1, 2);
            this.Profile_Layout.Controls.Add(this.phone, 1, 9);
            this.Profile_Layout.Controls.Add(this.label5, 1, 8);
            this.Profile_Layout.Controls.Add(this.label2, 1, 4);
            this.Profile_Layout.Controls.Add(this.lastname, 1, 5);
            this.Profile_Layout.Controls.Add(this.firstname, 1, 3);
            this.Profile_Layout.Controls.Add(this.label4, 1, 6);
            this.Profile_Layout.Controls.Add(this.id, 1, 1);
            this.Profile_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Profile_Layout.Location = new System.Drawing.Point(4, 3);
            this.Profile_Layout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Profile_Layout.Name = "Profile_Layout";
            this.Profile_Layout.RowCount = 13;
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.Profile_Layout.Size = new System.Drawing.Size(379, 503);
            this.Profile_Layout.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(45, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "תעודת זהות";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(45, 399);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "דואר אלקטרוני";
            // 
            // birthday
            // 
            this.birthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.birthday.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthday.Location = new System.Drawing.Point(45, 269);
            this.birthday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.birthday.Name = "birthday";
            this.birthday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.birthday.RightToLeftLayout = true;
            this.birthday.Size = new System.Drawing.Size(314, 26);
            this.birthday.TabIndex = 16;
            // 
            // email
            // 
            this.email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.email.Location = new System.Drawing.Point(45, 421);
            this.email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(314, 26);
            this.email.TabIndex = 10;
            this.email.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(45, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "שם פרטי";
            // 
            // phone
            // 
            this.phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phone.Location = new System.Drawing.Point(45, 345);
            this.phone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(314, 26);
            this.phone.TabIndex = 8;
            this.phone.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(45, 323);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(314, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "פאלפון";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(45, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "שם משפחה";
            // 
            // lastname
            // 
            this.lastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastname.Location = new System.Drawing.Point(45, 193);
            this.lastname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(314, 26);
            this.lastname.TabIndex = 4;
            this.lastname.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // firstname
            // 
            this.firstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstname.Location = new System.Drawing.Point(45, 117);
            this.firstname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(314, 26);
            this.firstname.TabIndex = 2;
            this.firstname.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(45, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "יום הולדת";
            // 
            // id
            // 
            this.id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id.Location = new System.Drawing.Point(45, 41);
            this.id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(314, 26);
            this.id.TabIndex = 0;
            this.id.TextChanged += new System.EventHandler(this.TextBox_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 551);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 54);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // PersonFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("David", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PersonFile";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "פרופיל אדם";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonFile_FormClosing);
            this.Load += new System.EventHandler(this.PersonFile_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.profile_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Profile_Layout.ResumeLayout(false);
            this.Profile_Layout.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl profile_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel Profile_Layout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker birthday;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id;
    }
}