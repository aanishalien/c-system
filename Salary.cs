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
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salary", cnn))
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
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salary", cnn))
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
            string sql = "SELECT * FROM employee";
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
            cmd = new SqlCommand("SELECT * FROM Employee WHERE employee_id=@employeeid",cnn);
            cmd.Parameters.AddWithValue("@employeeid",cmbemid.Text);
            cnn.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string basicsalary = dr["basic_salary"].ToString();
                string overtimerate = dr["over_time_rate"].ToString();
                string allowance = dr["allowance"].ToString();

                emp_basicsalary.Text = basicsalary;
                emp_overtimerate.Text = overtimerate;
                emp_allowance.Text = allowance;
            }
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
            // Create an instance of the Salary class
            decimal basic_salary = Convert.ToDecimal(emp_basicsalary.Text);
            decimal allowance = Convert.ToDecimal(emp_allowance.Text);
            decimal OvertimeHours = Convert.ToDecimal(overtimehours.Text);
            decimal over_time_rate = Convert.ToDecimal(emp_overtimerate.Text);
            decimal SalaryCycleDays = Convert.ToDecimal(sett_salarycycledays.Text);
            decimal NumberOfLeaves = Convert.ToDecimal(numberofleaves.Text);
            decimal NumberOfAbsent = Convert.ToDecimal(numberofabsent.Text);
            decimal GovernementTax = Convert.ToDecimal(emp_allowance.Text);
            decimal NoPayValue = Nopayvalue(basic_salary, allowance, NumberOfAbsent);
            decimal BasePay = BasePayValue(basic_salary, allowance, over_time_rate, OvertimeHours);
            decimal GrossPay = Grosspayvalue(BasePay, NoPayValue, GovernementTax);
            decimal MonthlySalary = CalculateMonthlySalary(GrossPay, NoPayValue, GovernementTax);

            basepayvalue.Text = GrossPay.ToString("0.00");
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
            if (cmbemid.Text == ""
                || emp_basicsalary.Text == ""
                || emp_overtimerate.Text == ""
                || emp_allowance.Text == ""
                || remaingleaves.Text == ""
                || numberofleaves.Text == ""
                || numberofabsent.Text == ""
                || numberofholidays.Text == ""
                || overtimehours.Text == ""
                || basepayvalue.Text == ""
                || grosspayvalue.Text == ""
                || nopayvalue.Text == "")
            {
                MessageBox.Show("Please fill in the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    try
                    {
                        cnn.Open();
                        string checkemployeeID = "SELECT COUNT(*) FROM salary WHERE employee_id = @employeeID"; // Assuming employee_id is the primary key

                        using (SqlCommand checkEmployee = new SqlCommand(checkemployeeID, cnn))
                        {
                            checkEmployee.Parameters.AddWithValue("@employeeID", cmbemid.Text.Trim());
                            int count = (int)checkEmployee.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(cmbemid.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO salary (NumberOfLeaves, NumberOfAbsent, NumberOfHolidays, OvertimeHours, BasePay, GrossPay, NoPayValue) " +
                                                    "VALUES (@numberofleaves, @numberofabsent, @numberofholidays, @overtimehours, @basepay, @grosspay, @nopayvalue)";

                                using (SqlCommand cmd = new SqlCommand(insertData, cnn))
                                {
                                    cmd.Parameters.AddWithValue("@numberofleaves", numberofleaves.Text.Trim());
                                    cmd.Parameters.AddWithValue("@numberofabsent", numberofabsent.Text.Trim());
                                    cmd.Parameters.AddWithValue("@numberofholidays", numberofholidays.Text.Trim());
                                    cmd.Parameters.AddWithValue("@overtimehours", overtimehours.Text.Trim());
                                    cmd.Parameters.AddWithValue("@basepay", basepayvalue.Text.Trim());
                                    cmd.Parameters.AddWithValue("@grosspay", grosspayvalue.Text.Trim());
                                    cmd.Parameters.AddWithValue("@nopayvalue", nopayvalue.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    displaySalaryData();

                                    MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
            }
        }

    }
}
