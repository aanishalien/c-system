using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace GriffdanManagementsystem
{
    public partial class Reports : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Reports()
        {
            InitializeComponent();
            displaySalariesData();
            OverallData();
            monthlysalary();
            LoadData();
            
        }

        public void displaySalaryData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void displaySalariesData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Emp_view_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                displaySalaryData(row);
            }
        }
        private void displaySalaryData(DataGridViewRow row)
        {
            string employee_id = row.Cells["employee_id"].Value.ToString();
            string employee_name = row.Cells["employee_name"].Value.ToString();
            string basicSalary = row.Cells["basic_salary"].Value.ToString();
            string monthly_salary = row.Cells["monthly_salary"].Value.ToString();
        }

        private void LoadData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT employee_id, employee_name, basic_salary, monthly_salary FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Rep_emp_TextChanged(object sender, EventArgs e)
        {
            if (rep_emp.TextLength >= 4)
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    cnn.Open();

                    string sql = "SELECT * FROM employee ";
                    sql += "WHERE employee_id LIKE @param";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Add parameter to the SqlCommand
                        cmd.Parameters.AddWithValue("@param", rep_emp.Text + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        } // Automatically disposes cmd and da when out of scope
                    }
                }
            }
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                displaySalaryData(row);
            }
        }

        private void OverallData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                displaySalaryData(row);
            }
        }

        private void monthlysalary()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT employee_id,employee_name,monthly_salary FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
