namespace GriffdanManagementsystem
{
    partial class Addemployee
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.emp_import = new System.Windows.Forms.Button();
            this.emp_position = new System.Windows.Forms.TextBox();
            this.emp_dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.emp_status = new System.Windows.Forms.ComboBox();
            this.emp_gender = new System.Windows.Forms.ComboBox();
            this.emp_picture = new System.Windows.Forms.PictureBox();
            this.exit_btn = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Label();
            this.emp_update = new System.Windows.Forms.Button();
            this.emp_clear = new System.Windows.Forms.Button();
            this.emp_delete = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.emp_insert = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.emp_overtimerate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.emp_allowance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.emp_basicsalary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emp_address = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.emp_contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchempname = new System.Windows.Forms.Label();
            this.emp_fullname = new System.Windows.Forms.TextBox();
            this.searchempid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.emp_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchemlname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emp_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(326, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 362);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // emp_import
            // 
            this.emp_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_import.ForeColor = System.Drawing.Color.White;
            this.emp_import.Location = new System.Drawing.Point(649, 90);
            this.emp_import.Name = "emp_import";
            this.emp_import.Size = new System.Drawing.Size(77, 23);
            this.emp_import.TabIndex = 45;
            this.emp_import.Text = "Import";
            this.emp_import.UseVisualStyleBackColor = true;
            this.emp_import.Click += new System.EventHandler(this.Emp_import_Click);
            // 
            // emp_position
            // 
            this.emp_position.Location = new System.Drawing.Point(140, 362);
            this.emp_position.Name = "emp_position";
            this.emp_position.Size = new System.Drawing.Size(144, 20);
            this.emp_position.TabIndex = 44;
            // 
            // emp_dateTimePicker1
            // 
            this.emp_dateTimePicker1.Location = new System.Drawing.Point(140, 199);
            this.emp_dateTimePicker1.Name = "emp_dateTimePicker1";
            this.emp_dateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.emp_dateTimePicker1.TabIndex = 43;
            this.emp_dateTimePicker1.ValueChanged += new System.EventHandler(this.Emp_dateTimePicker1_ValueChanged);
            // 
            // emp_status
            // 
            this.emp_status.FormattingEnabled = true;
            this.emp_status.Items.AddRange(new object[] {
            "Active ",
            "Inactive"});
            this.emp_status.Location = new System.Drawing.Point(140, 321);
            this.emp_status.Name = "emp_status";
            this.emp_status.Size = new System.Drawing.Size(144, 21);
            this.emp_status.TabIndex = 42;
            // 
            // emp_gender
            // 
            this.emp_gender.FormattingEnabled = true;
            this.emp_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.emp_gender.Location = new System.Drawing.Point(140, 161);
            this.emp_gender.Name = "emp_gender";
            this.emp_gender.Size = new System.Drawing.Size(144, 21);
            this.emp_gender.TabIndex = 41;
            // 
            // emp_picture
            // 
            this.emp_picture.BackColor = System.Drawing.Color.Gray;
            this.emp_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.emp_picture.Location = new System.Drawing.Point(649, 24);
            this.emp_picture.Name = "emp_picture";
            this.emp_picture.Size = new System.Drawing.Size(77, 60);
            this.emp_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emp_picture.TabIndex = 40;
            this.emp_picture.TabStop = false;
            // 
            // exit_btn
            // 
            this.exit_btn.AutoSize = true;
            this.exit_btn.ForeColor = System.Drawing.Color.White;
            this.exit_btn.Location = new System.Drawing.Point(741, 9);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(12, 13);
            this.exit_btn.TabIndex = 39;
            this.exit_btn.Text = "x";
            this.exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.AutoSize = true;
            this.back_btn.ForeColor = System.Drawing.Color.White;
            this.back_btn.Location = new System.Drawing.Point(12, 9);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(25, 13);
            this.back_btn.TabIndex = 38;
            this.back_btn.Text = "<==";
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // emp_update
            // 
            this.emp_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_update.ForeColor = System.Drawing.Color.White;
            this.emp_update.Location = new System.Drawing.Point(203, 436);
            this.emp_update.Name = "emp_update";
            this.emp_update.Size = new System.Drawing.Size(68, 26);
            this.emp_update.TabIndex = 37;
            this.emp_update.Text = "Update ";
            this.emp_update.UseVisualStyleBackColor = true;
            this.emp_update.Click += new System.EventHandler(this.Emp_update_Click);
            // 
            // emp_clear
            // 
            this.emp_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_clear.ForeColor = System.Drawing.Color.White;
            this.emp_clear.Location = new System.Drawing.Point(203, 498);
            this.emp_clear.Name = "emp_clear";
            this.emp_clear.Size = new System.Drawing.Size(68, 26);
            this.emp_clear.TabIndex = 36;
            this.emp_clear.Text = "Clear";
            this.emp_clear.UseVisualStyleBackColor = true;
            this.emp_clear.Click += new System.EventHandler(this.Emp_clear_Click);
            // 
            // emp_delete
            // 
            this.emp_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_delete.ForeColor = System.Drawing.Color.White;
            this.emp_delete.Location = new System.Drawing.Point(56, 498);
            this.emp_delete.Name = "emp_delete";
            this.emp_delete.Size = new System.Drawing.Size(68, 26);
            this.emp_delete.TabIndex = 35;
            this.emp_delete.Text = "Delete ";
            this.emp_delete.UseVisualStyleBackColor = true;
            this.emp_delete.Click += new System.EventHandler(this.Emp_delete_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(49, 365);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Position";
            // 
            // emp_insert
            // 
            this.emp_insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_insert.ForeColor = System.Drawing.Color.White;
            this.emp_insert.Location = new System.Drawing.Point(56, 436);
            this.emp_insert.Name = "emp_insert";
            this.emp_insert.Size = new System.Drawing.Size(68, 26);
            this.emp_insert.TabIndex = 34;
            this.emp_insert.Text = "Insert ";
            this.emp_insert.UseVisualStyleBackColor = true;
            this.emp_insert.Click += new System.EventHandler(this.Emp_insert_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(49, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Status";
            // 
            // emp_overtimerate
            // 
            this.emp_overtimerate.Location = new System.Drawing.Point(140, 399);
            this.emp_overtimerate.Name = "emp_overtimerate";
            this.emp_overtimerate.Size = new System.Drawing.Size(144, 20);
            this.emp_overtimerate.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(49, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Over Time Rate ";
            // 
            // emp_allowance
            // 
            this.emp_allowance.Location = new System.Drawing.Point(140, 273);
            this.emp_allowance.Name = "emp_allowance";
            this.emp_allowance.Size = new System.Drawing.Size(144, 20);
            this.emp_allowance.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(52, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Allowance";
            // 
            // emp_basicsalary
            // 
            this.emp_basicsalary.Location = new System.Drawing.Point(140, 234);
            this.emp_basicsalary.Name = "emp_basicsalary";
            this.emp_basicsalary.Size = new System.Drawing.Size(144, 20);
            this.emp_basicsalary.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(52, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Basic Salary";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(52, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date Joined";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(52, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Gender";
            // 
            // emp_address
            // 
            this.emp_address.Location = new System.Drawing.Point(140, 124);
            this.emp_address.Name = "emp_address";
            this.emp_address.Size = new System.Drawing.Size(144, 20);
            this.emp_address.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(52, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Address";
            // 
            // emp_contact
            // 
            this.emp_contact.Location = new System.Drawing.Point(140, 85);
            this.emp_contact.Name = "emp_contact";
            this.emp_contact.Size = new System.Drawing.Size(144, 20);
            this.emp_contact.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Contact";
            // 
            // searchempname
            // 
            this.searchempname.AutoSize = true;
            this.searchempname.ForeColor = System.Drawing.Color.White;
            this.searchempname.Location = new System.Drawing.Point(327, 96);
            this.searchempname.Name = "searchempname";
            this.searchempname.Size = new System.Drawing.Size(121, 13);
            this.searchempname.TabIndex = 20;
            this.searchempname.Text = "Serach Employee Name";
            this.searchempname.Click += new System.EventHandler(this.Searchempname_Click);
            // 
            // emp_fullname
            // 
            this.emp_fullname.Location = new System.Drawing.Point(140, 59);
            this.emp_fullname.Name = "emp_fullname";
            this.emp_fullname.Size = new System.Drawing.Size(144, 20);
            this.emp_fullname.TabIndex = 29;
            // 
            // searchempid
            // 
            this.searchempid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchempid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchempid.Location = new System.Drawing.Point(454, 25);
            this.searchempid.Name = "searchempid";
            this.searchempid.Size = new System.Drawing.Size(144, 20);
            this.searchempid.TabIndex = 30;
            this.searchempid.TextChanged += new System.EventHandler(this.Searchempid_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Full Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(327, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Search Employee ID";
            // 
            // emp_ID
            // 
            this.emp_ID.Location = new System.Drawing.Point(140, 22);
            this.emp_ID.Name = "emp_ID";
            this.emp_ID.Size = new System.Drawing.Size(144, 20);
            this.emp_ID.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Employee ID";
            // 
            // searchemlname
            // 
            this.searchemlname.Location = new System.Drawing.Point(454, 93);
            this.searchemlname.Name = "searchemlname";
            this.searchemlname.Size = new System.Drawing.Size(144, 20);
            this.searchemlname.TabIndex = 47;
            this.searchemlname.TextChanged += new System.EventHandler(this.Searchemlname_TextChanged);
            // 
            // Addemployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(765, 548);
            this.Controls.Add(this.searchemlname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.emp_import);
            this.Controls.Add(this.emp_position);
            this.Controls.Add(this.emp_dateTimePicker1);
            this.Controls.Add(this.emp_status);
            this.Controls.Add(this.emp_gender);
            this.Controls.Add(this.emp_picture);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.emp_update);
            this.Controls.Add(this.emp_clear);
            this.Controls.Add(this.emp_delete);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.emp_insert);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.emp_overtimerate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emp_allowance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.emp_basicsalary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emp_address);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.emp_contact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchempname);
            this.Controls.Add(this.emp_fullname);
            this.Controls.Add(this.searchempid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.emp_ID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Addemployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addemployee";
            this.Load += new System.EventHandler(this.Addemployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emp_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button emp_import;
        private System.Windows.Forms.TextBox emp_position;
        private System.Windows.Forms.DateTimePicker emp_dateTimePicker1;
        private System.Windows.Forms.ComboBox emp_status;
        private System.Windows.Forms.ComboBox emp_gender;
        private System.Windows.Forms.PictureBox emp_picture;
        private System.Windows.Forms.Label exit_btn;
        private System.Windows.Forms.Label back_btn;
        private System.Windows.Forms.Button emp_update;
        private System.Windows.Forms.Button emp_clear;
        private System.Windows.Forms.Button emp_delete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button emp_insert;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox emp_overtimerate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emp_allowance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emp_basicsalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emp_address;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox emp_contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label searchempname;
        private System.Windows.Forms.TextBox emp_fullname;
        private System.Windows.Forms.TextBox searchempid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox emp_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchemlname;
    }
}