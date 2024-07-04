namespace GriffdanManagementsystem
{
    partial class Settings
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
            this.sett_salaryenddate = new System.Windows.Forms.DateTimePicker();
            this.sett_salarycycledays = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sett_salarybegindate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.sett_numberofleaves = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sett_governmenttax = new System.Windows.Forms.TextBox();
            this.sett_update = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Label();
            this.sett_clear = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Label();
            this.sett_insert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sett_salaryenddate
            // 
            this.sett_salaryenddate.Location = new System.Drawing.Point(208, 154);
            this.sett_salaryenddate.Name = "sett_salaryenddate";
            this.sett_salaryenddate.Size = new System.Drawing.Size(210, 20);
            this.sett_salaryenddate.TabIndex = 12;
            // 
            // sett_salarycycledays
            // 
            this.sett_salarycycledays.Location = new System.Drawing.Point(208, 204);
            this.sett_salarycycledays.Name = "sett_salarycycledays";
            this.sett_salarycycledays.Size = new System.Drawing.Size(210, 20);
            this.sett_salarycycledays.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(75, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Salary cycle Days ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(75, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Salary End Date ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Salary Begin Date ";
            // 
            // sett_salarybegindate
            // 
            this.sett_salarybegindate.Location = new System.Drawing.Point(208, 107);
            this.sett_salarybegindate.Name = "sett_salarybegindate";
            this.sett_salarybegindate.Size = new System.Drawing.Size(210, 20);
            this.sett_salarybegindate.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Leaves Per Year";
            // 
            // sett_numberofleaves
            // 
            this.sett_numberofleaves.Location = new System.Drawing.Point(208, 250);
            this.sett_numberofleaves.Name = "sett_numberofleaves";
            this.sett_numberofleaves.Size = new System.Drawing.Size(210, 20);
            this.sett_numberofleaves.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(75, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Government Tax";
            // 
            // sett_governmenttax
            // 
            this.sett_governmenttax.Location = new System.Drawing.Point(208, 289);
            this.sett_governmenttax.Name = "sett_governmenttax";
            this.sett_governmenttax.Size = new System.Drawing.Size(210, 20);
            this.sett_governmenttax.TabIndex = 11;
            // 
            // sett_update
            // 
            this.sett_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sett_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sett_update.ForeColor = System.Drawing.Color.White;
            this.sett_update.Location = new System.Drawing.Point(478, 444);
            this.sett_update.Name = "sett_update";
            this.sett_update.Size = new System.Drawing.Size(79, 25);
            this.sett_update.TabIndex = 13;
            this.sett_update.Text = "Update ";
            this.sett_update.UseVisualStyleBackColor = true;
            this.sett_update.Click += new System.EventHandler(this.Sett_update_Click);
            // 
            // back_btn
            // 
            this.back_btn.AutoSize = true;
            this.back_btn.ForeColor = System.Drawing.Color.White;
            this.back_btn.Location = new System.Drawing.Point(12, 21);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(25, 13);
            this.back_btn.TabIndex = 14;
            this.back_btn.Text = "<==";
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // sett_clear
            // 
            this.sett_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sett_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sett_clear.ForeColor = System.Drawing.Color.White;
            this.sett_clear.Location = new System.Drawing.Point(584, 444);
            this.sett_clear.Name = "sett_clear";
            this.sett_clear.Size = new System.Drawing.Size(79, 25);
            this.sett_clear.TabIndex = 13;
            this.sett_clear.Text = "clear";
            this.sett_clear.UseVisualStyleBackColor = true;
            this.sett_clear.Click += new System.EventHandler(this.Sett_clear_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.AutoSize = true;
            this.exit_btn.ForeColor = System.Drawing.Color.White;
            this.exit_btn.Location = new System.Drawing.Point(677, 9);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(10, 13);
            this.exit_btn.TabIndex = 15;
            this.exit_btn.Text = " ";
            this.exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // sett_insert
            // 
            this.sett_insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sett_insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sett_insert.ForeColor = System.Drawing.Color.White;
            this.sett_insert.Location = new System.Drawing.Point(352, 444);
            this.sett_insert.Name = "sett_insert";
            this.sett_insert.Size = new System.Drawing.Size(75, 23);
            this.sett_insert.TabIndex = 16;
            this.sett_insert.Text = "Insert";
            this.sett_insert.UseVisualStyleBackColor = true;
            this.sett_insert.Click += new System.EventHandler(this.Sett_insert_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(701, 518);
            this.Controls.Add(this.sett_insert);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.sett_clear);
            this.Controls.Add(this.sett_update);
            this.Controls.Add(this.sett_salarybegindate);
            this.Controls.Add(this.sett_governmenttax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sett_numberofleaves);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sett_salaryenddate);
            this.Controls.Add(this.sett_salarycycledays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker sett_salaryenddate;
        private System.Windows.Forms.TextBox sett_salarycycledays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker sett_salarybegindate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sett_numberofleaves;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sett_governmenttax;
        private System.Windows.Forms.Button sett_update;
        private System.Windows.Forms.Label back_btn;
        private System.Windows.Forms.Button sett_clear;
        private System.Windows.Forms.Label exit_btn;
        private System.Windows.Forms.Button sett_insert;
    }
}