using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace GriffdanManagementsystem
{
    public partial class Settings : Form
    {
        SqlConnection cnn =
           new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Settings()
        {
            InitializeComponent();
            displaysalaryData();
            displaySettingData();


        }
        public void displaySettingData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Settings", cnn)) ;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displaysalaryData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM salary", cnn)) ;

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

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void Sett_update_Click(object sender, EventArgs e)
        {
            if (sett_salarybegindate.Text == ""
                || sett_salaryenddate.Text == ""
                || sett_salarycycledays.Text == ""
                || sett_numberofleaves.Text == ""
                || sett_governmenttax.Text == "")
            {
                MessageBox.Show("Please fill in the blank fields"
                   , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Settings?"
                    , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        cnn.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE Settings SET SalaryBeginDate = @salarybegindate, " +
                      "SalaryEndDate = @salaryenddate, SalaryCycleDays = @salarycycledays, " +
                      "NumberOfLeaves = @numberofleaves, GovernmentTax = @governmenttax " +
                      "WHERE SalaryBeginDate =@salarybegindate"; // Specify a condition for the update operation




                        using (SqlCommand cmd = new SqlCommand(updateData, cnn))
                        {

                            cmd.Parameters.AddWithValue("@salarybegindate", sett_salarybegindate.Text.Trim());
                            cmd.Parameters.AddWithValue("@salaryenddate", sett_salaryenddate.Text.Trim());
                            cmd.Parameters.AddWithValue("@salarycycledays", sett_salarycycledays.Text.Trim());
                            cmd.Parameters.AddWithValue("@numberofleaves", sett_numberofleaves.Text.Trim());
                            cmd.Parameters.AddWithValue("@governmenttax", sett_governmenttax.Text.Trim());


                            cmd.ExecuteNonQuery();

                            displaySettingData();

                            MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void Sett_clear_Click(object sender, EventArgs e)
        {
            sett_salarybegindate.Text = "";
            sett_salaryenddate.Text = "";
            sett_salarycycledays.Text = "";
            sett_numberofleaves.Text = "";
            sett_governmenttax.Text = "";

            MessageBox.Show("Fields Cleared Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Sett_insert_Click(object sender, EventArgs e)
        {
            if (sett_salarybegindate.Text == ""
                || sett_salaryenddate.Text == ""
                || sett_salarycycledays.Text == ""
                || sett_numberofleaves.Text == ""
                || sett_governmenttax.Text == "")
            {
                MessageBox.Show("Please fill in the blank fields"
                   , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Settings?"
                    , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        cnn.Open();
                        DateTime today = DateTime.Today;
                        string insertData = "INSERT INTO Settings" +
                           "(SalaryBeginDate, SalaryEndDate, SalaryCycleDays, NumberOfLeaves, GovernmentTax)" +
                           "VALUES(@salarybegindate, @salaryenddate, @salarycycledays, @numberofleaves, @governmenttax)";




                        using (SqlCommand cmd = new SqlCommand(insertData, cnn))
                        {

                            cmd.Parameters.AddWithValue("@salarybegindate", sett_salarybegindate.Text.Trim());
                            cmd.Parameters.AddWithValue("@salaryenddate", sett_salaryenddate.Text.Trim());
                            cmd.Parameters.AddWithValue("@salarycycledays", sett_salarycycledays.Text.Trim());
                            cmd.Parameters.AddWithValue("@numberofleaves", sett_numberofleaves.Text.Trim());
                            cmd.Parameters.AddWithValue("@governmenttax", sett_governmenttax.Text.Trim());


                            cmd.ExecuteNonQuery();

                            displaySettingData();

                            MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
