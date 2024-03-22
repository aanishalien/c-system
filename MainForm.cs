using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GriffdanManagementsystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?"
              , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void Dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void Employee_btn_Click(object sender, EventArgs e)
        {
            Addemployee emp = new Addemployee();
            emp.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Settings sett = new Settings();
            sett.Show();
            this.Hide();
        }

        private void Reports_btn_Click(object sender, EventArgs e)
        {
            Reports rs = new Reports();
            rs.Show();
            this.Hide();
        }

        private void Salary_btn_Click(object sender, EventArgs e)
        {
            Salary sl = new Salary();
            sl.Show();
            this.Hide();
        }
    }
}
