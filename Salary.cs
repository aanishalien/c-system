using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GriffdanManagementsystem
{
    public partial class Salary : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader dr;
       
       
       




        public Salary()
        {
            InitializeComponent();
            displaySettingData();
            displayemployeeData();
            displaySalaryData();
            
        }

        public void displaySalaryData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salaries", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    //dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void displayemployeeData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employee", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    //dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void displaySettingData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Settings", cnn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    //dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Salary_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Employee";
            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbemid.Items.Add(dr["employee_id"]);
            }
            cnn.Close(); // Close the connection after reading data
            Sett_governmenttax_TextChanged(sender, e);
            Sett_salarycycledays_TextChanged(sender, e);
        }



        private void Cmbemid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            cmd = new SqlCommand("SELECT * FROM Employee WHERE employee_id=@employeeid", cnn);
            cmd.Parameters.AddWithValue("@employeeid", cmbemid.Text);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp_name.Text = dr["full_name"].ToString();
                emp_basicsalary.Text = dr["basic_salary"].ToString();
                emp_overtimerate.Text = dr["over_time_rate"].ToString();
                emp_allowance.Text = dr["allowance"].ToString();
            }

            dr.Close(); // Close the DataReader after using it
            cnn.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Setttings_box_Enter(object sender, EventArgs e)
        {
          
        }

        static decimal Nopayvalue(decimal basic_salary, decimal SalaryCycleDays, decimal NumberOfLeaves)
        {
            decimal result = Math.Abs((basic_salary / SalaryCycleDays) * NumberOfLeaves);
            return result;
        }

        static decimal BasePayValue(decimal basic_salary, decimal allowance, decimal Overtimerate, decimal OverTimeHours)
        {
            decimal result = Math.Abs(basic_salary + allowance + (Overtimerate * OverTimeHours));
            return result;
        }

        static decimal Grosspayvalue(decimal BasePay, decimal NoPayValue, decimal GovernmentTax)
        {
            decimal result = Math.Abs(BasePay - (NoPayValue + ((BasePay / 100) * GovernmentTax)));
            return result;
        }
        static decimal CalculateMonthlySalary(decimal grossPayValue, decimal noPayValue, decimal governmentTax)
        {
            decimal result = Math.Abs(grossPayValue + noPayValue / governmentTax);
            return result;
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            // Ensure that all required text boxes contain valid decimal values
            if (!decimal.TryParse(emp_basicsalary.Text, out decimal basic_salary))
            {
                MessageBox.Show("Invalid Basic Salary value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(emp_allowance.Text, out decimal allowance))
            {
                MessageBox.Show("Invalid Allowance value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(overtimehours.Text, out decimal OvertimeHours))
            {
                MessageBox.Show("Invalid Overtime Hours value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(emp_overtimerate.Text, out decimal overtimerate))
            {
                MessageBox.Show("Invalid Overtime Rate value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(sett_salarycycledays.Text, out decimal SalaryCycleDays))
            {
                MessageBox.Show("Invalid Salary Cycle Days value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(numberofleaves.Text, out decimal NumberOfLeaves))
            {
                MessageBox.Show("Invalid Number of Leaves value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(numberofabsent.Text, out decimal NumberOfAbsent))
            {
                MessageBox.Show("Invalid Number of Absent Days value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(sett_governmenttax.Text, out decimal GovernmentTax))
            {
                MessageBox.Show("Invalid Government Tax value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate the various salary components
            decimal NoPayValue = Nopayvalue(basic_salary, SalaryCycleDays, NumberOfAbsent);
            decimal BasePay = BasePayValue(basic_salary, allowance, overtimerate, OvertimeHours);
            decimal GrossPay = Grosspayvalue(BasePay, NoPayValue, GovernmentTax);
            decimal MonthlySalary = CalculateMonthlySalary(GrossPay, NoPayValue, GovernmentTax);

            // Display the calculated values
            basepayvalue.Text = BasePay.ToString("0.00");
            nopayvalue.Text = NoPayValue.ToString("0.00");
            grosspayvalue.Text = GrossPay.ToString("0.00");
            Monthlysalary.Text = MonthlySalary.ToString("0.00");
        }


        static string points(string x)
        {
            double y;
            double.TryParse(x, out y);
            return y.ToString("0.00"); // Format the double value with two decimal places
        }

        public void CalculateSalary(DateTime startDate, DateTime endDate, int numberOfLeaves, int numberOfAbsentDays, int numberOfHolidays, double monthlySalary, double allowances, double overtimeRate, double governmentTax)
        {
            try
            {
                cnn.Open();

                // Check if the entered dates are within the defined salary cycle
                TimeSpan salaryCycle = endDate - startDate;
                int salaryCycleDays = 30; // Default salary cycle days, can be changed in the settings
                if (salaryCycle.Days != salaryCycleDays)
                {
                    throw new Exception("Entered dates are not within the defined salary cycle.");
                }

                // Calculate No-pay value
                double noPayValue = (monthlySalary / salaryCycleDays) * numberOfAbsentDays;

                double OvertimeHours = 0;
                // Calculate Base Pay value
                double basePayValue = monthlySalary + allowances + (overtimeRate * OvertimeHours);

                // Calculate Gross Pay value
                double grossPay = basePayValue - (noPayValue + basePayValue * governmentTax);

                // Save calculated values to the database
                // Code to insert data into the database goes here

                Console.WriteLine("Salary calculated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Sett_governmenttax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT GovernmentTax FROM Settings", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string governmentTax = dr["GovernmentTax"].ToString();
                                sett_governmenttax.Text = governmentTax;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sett_salarycycledays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SalaryCycleDays FROM Settings", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string SalaryCycleDays = dr["SalaryCycleDays"].ToString();
                                sett_salarycycledays.Text = SalaryCycleDays;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insertsalarydetails_Click(object sender, EventArgs e)
        {
            
        }


        private void Sett_salarybegindate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SalaryBeginDate FROM Settings", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string SalaryBeginDate = dr["SalaryBeginDate"].ToString();
                                sett_salarybegindate.Text = SalaryBeginDate;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sett_numberofleaves_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT NumberOfLeaves FROM Settings", cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string NumberOfLeaves = dr["NumberOfLeaves"].ToString();
                                sett_numberofleaves.Text = NumberOfLeaves;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbemid.Text) ||
               string.IsNullOrWhiteSpace(emp_name.Text)||
               string.IsNullOrWhiteSpace(emp_basicsalary.Text) ||
               string.IsNullOrWhiteSpace(emp_overtimerate.Text) ||
               string.IsNullOrWhiteSpace(emp_allowance.Text) ||
               string.IsNullOrWhiteSpace(remaingleaves.Text) ||
               string.IsNullOrWhiteSpace(numberofleaves.Text) ||
               string.IsNullOrWhiteSpace(numberofabsent.Text) ||
               string.IsNullOrWhiteSpace(sett_salarycycledays.Text) ||
               string.IsNullOrWhiteSpace(sett_governmenttax.Text) ||
               string.IsNullOrWhiteSpace(nopayvalue.Text) ||
               string.IsNullOrWhiteSpace(basepayvalue.Text) ||
               string.IsNullOrWhiteSpace(grosspayvalue.Text) ||
               string.IsNullOrWhiteSpace(Monthlysalary.Text))
            {
                MessageBox.Show("All fields must be filled out", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO salaries (employee_id, employee_name,basic_salary, overtimerate, allowance, RemainingLeaves, Numberofleaves, Numberofabsent, SalaryCycleDays, GovernmentTax, NoPayValue, BasePay, GrossPay, monthly_salary,OvertimeHours) " +
                        "VALUES (@employee_id,@employee_name, @basic_salary, @over_time_rate, @allowance, @remaining_leaves, @number_of_leaves, @number_of_absent, @salary_cycle_days, @government_tax, @no_pay_value, @base_pay_value, @gross_pay_value, @monthly_salary,@overtimehours)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@employee_id", cmbemid.Text);
                        cmd.Parameters.AddWithValue("@employee_name", emp_name.Text);
                        cmd.Parameters.AddWithValue("@basic_salary", decimal.Parse(emp_basicsalary.Text));
                        cmd.Parameters.AddWithValue("@over_time_rate", decimal.Parse(emp_overtimerate.Text));
                        cmd.Parameters.AddWithValue("@allowance", decimal.Parse(emp_allowance.Text));
                        cmd.Parameters.AddWithValue("@remaining_leaves", int.Parse(remaingleaves.Text));
                        cmd.Parameters.AddWithValue("@number_of_leaves", int.Parse(numberofleaves.Text));
                        cmd.Parameters.AddWithValue("@number_of_absent", int.Parse(numberofabsent.Text));
                        cmd.Parameters.AddWithValue("@overtimehours", int.Parse(overtimehours.Text));
                        cmd.Parameters.AddWithValue("@salary_cycle_days", int.Parse(sett_salarycycledays.Text));
                        cmd.Parameters.AddWithValue("@government_tax", decimal.Parse(sett_governmenttax.Text));
                        cmd.Parameters.AddWithValue("@no_pay_value", decimal.Parse(nopayvalue.Text));
                        cmd.Parameters.AddWithValue("@base_pay_value", decimal.Parse(basepayvalue.Text));
                        cmd.Parameters.AddWithValue("@gross_pay_value", decimal.Parse(grosspayvalue.Text));
                        cmd.Parameters.AddWithValue("@monthly_salary", decimal.Parse(Monthlysalary.Text));

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            cmbemid.Text = string.Empty;
            emp_name.Text = string.Empty;
            emp_basicsalary.Text = string.Empty;
            emp_overtimerate.Text = string.Empty;
            emp_allowance.Text = string.Empty;
            overtimehours.Text = string.Empty;
            sett_salarycycledays.Text = string.Empty;
            numberofleaves.Text = string.Empty;
            numberofabsent.Text = string.Empty;
            sett_governmenttax.Text = string.Empty;
            basepayvalue.Text = string.Empty;
            nopayvalue.Text = string.Empty;
            grosspayvalue.Text = string.Empty;
            Monthlysalary.Text = string.Empty;
            cmbemid.SelectedIndex = -1;
        }
    }
}
