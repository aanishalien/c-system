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
using System.IO;
using GriffdanEmployeeManagement;

namespace GriffdanManagementsystem
{
    public partial class Addemployee : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");


        public Addemployee()
        {
            InitializeComponent();

            displayEmployeeData();
        }

        public void displayEmployeeData()
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM employee", cnn))
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


        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void Emp_insert_Click(object sender, EventArgs e)
        {
            if (emp_ID.Text == ""
                 || emp_fullname.Text == ""
                 || emp_contact.Text == ""
                 || emp_address.Text == ""
                 || emp_gender.Text == ""
                 || emp_dateTimePicker1.Text == ""
                 || emp_basicsalary.Text == ""
                 || emp_allowance.Text == ""
                 
                 || emp_status.Text == ""
                 || emp_position.Text == ""
                 || emp_overtimerate.Text == ""
                 || emp_picture.Image == null
                 )
            {
                MessageBox.Show("Please fill in the blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    try
                    {
                        cnn.Open();
                        string checkEmID = "SELECT COUNT(*) FROM employee WHERE employee_id = @emID AND delete_date IS NULL";


                        using (SqlCommand checkEm = new SqlCommand(checkEmID, cnn))
                        {
                            checkEm.Parameters.AddWithValue("@emID", emp_ID.Text.Trim());
                            int count = (int)checkEm.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(emp_ID.Text.Trim() + "is already taken"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO employee" +
    "(employee_id, full_name, contact, address, gender, date_joined" +
    ", basic_salary, allowance , over_time_rate, status, position, insert_date, image)" +
    "VALUES(@employeeID, @fullName, @contact, @address, @gender, @date_joined" +
    ", @basic_salary, @allowance, @status, @position, @over_time_rate, @insertDate, @image)";



                                string path = Path.Combine(@"C:\Users\Gadget Fix\source\repos\GriffdanManagementsystem\Directory\"
                                + emp_ID.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                File.Copy(emp_picture.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, cnn))
                                {
                                    cmd.Parameters.AddWithValue("@employeeID", emp_ID.Text.Trim());
                                    cmd.Parameters.AddWithValue("@fullName", emp_fullname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@contact", emp_contact.Text.Trim());
                                    cmd.Parameters.AddWithValue("@address", emp_address.Text.Trim());
                                    cmd.Parameters.AddWithValue("@gender", emp_gender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date_joined", emp_dateTimePicker1.Text.Trim());
                                    cmd.Parameters.AddWithValue("@basic_salary", 0);
                                    cmd.Parameters.AddWithValue("@allowance", emp_allowance.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", emp_status.Text.Trim());
                                    cmd.Parameters.AddWithValue("@position", emp_position.Text.Trim());
                                    cmd.Parameters.AddWithValue("@over_time_rate", emp_overtimerate.Text.Trim());
                                    cmd.Parameters.AddWithValue("@insertDate", today);
                                    cmd.Parameters.AddWithValue("@image", path);

                                    cmd.ExecuteNonQuery();

                                    displayEmployeeData();

                                    MessageBox.Show("Added Successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex
                            , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
            }
        }

        private void Emp_import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    emp_picture.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Searchempname_Click(object sender, EventArgs e)
        {
            if (searchempid.TextLength >= 4)
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    cnn.Open();

                    string sql = "SELECT * FROM employee ";
                    sql += "WHERE full_name LIKE @param";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Add parameter to the SqlCommand
                        cmd.Parameters.AddWithValue("@param", searchempname.Text + "%");

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

        private void Searchempid_TextChanged(object sender, EventArgs e)
        {
            if (searchempid.TextLength >= 4)
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    cnn.Open();

                    string sql = "SELECT * FROM employee ";
                    sql += "WHERE employee_id LIKE @param";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Add parameter to the SqlCommand
                        cmd.Parameters.AddWithValue("@param", searchempid.Text + "%");

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



        private void Search_btn_Click(object sender, EventArgs e)
        {
            string searchTerm = searchempid.Text.Trim();

            // Assuming you have a DataTable as the data source for your DataGridView
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            if (searchTerm == searchempid.Text.Trim())
            {
                // Reset the filter and show all data
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                // Filter the DataTable based on user input
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = $"EmployeeID LIKE '%{searchTerm}%'";

                // Update the DataGridView with the filtered data
                dataGridView1.DataSource = dataView.ToTable();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                emp_ID.Text = row.Cells[1].Value.ToString();
                emp_fullname.Text = row.Cells[2].Value.ToString();
                emp_contact.Text = row.Cells[3].Value.ToString();
                emp_address.Text = row.Cells[4].Value.ToString();
                emp_gender.Text = row.Cells[5].Value.ToString();

                if (row.Cells[6].Value is DateTime)
                {
                    emp_dateTimePicker1.Value = (DateTime)row.Cells[6].Value;
                }
                else
                {
                    // Handle the case where the value is not a DateTime
                    MessageBox.Show("Invalid DateTime value in the cell.");
                }

                emp_basicsalary.Text = row.Cells[7].Value.ToString();
                emp_allowance.Text = row.Cells[8].Value.ToString();
                emp_status.Text = row.Cells[9].Value.ToString();
                emp_position.Text = row.Cells[10].Value.ToString();
                emp_overtimerate.Text = row.Cells[11].Value.ToString();

                // Adjust the order of assignments if needed

                string imagePath = row.Cells[12].Value.ToString();

                if (File.Exists(imagePath))
                {
                    emp_picture.Image = Image.FromFile(imagePath);
                }
                else
                {
                    emp_picture.Image = null;
                    // Handle the case where the file does not exist
                }
            }
        }


        public void clearFields()
        {
            emp_ID.Text = "";
            emp_fullname.Text = "";
            emp_contact.Text = "";
            emp_address.Text = "";
            emp_gender.SelectedIndex = -1;
            emp_dateTimePicker1.Text = "";
            emp_basicsalary.Text = "";
            emp_allowance.Text = "";
           
            emp_status.Text = "";
            emp_position.Text = "";
            emp_overtimerate.Text = "";
            emp_picture.Image = null;
        }

        private void Emp_update_Click(object sender, EventArgs e)
        {
            if (emp_ID.Text == ""
                || emp_fullname.Text == ""
                || emp_contact.Text == ""
                || emp_address.Text == ""
                || emp_gender.Text == ""
                || emp_dateTimePicker1.Text == ""
                || emp_basicsalary.Text == ""
                || emp_allowance.Text == ""
                || emp_overtimerate.Text == ""
                || emp_status.Text == ""
                || emp_position.Text == ""
                || emp_picture.Image == null
                )
            {
                MessageBox.Show("Please fill in the blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are u sure want to UPDATE"+
                    "Employee ID: "+ emp_ID.Text.Trim() + "?"
                    ,"Confirmation Message",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                if(check == DialogResult.Yes)
                {
                    try
                    {
                        cnn.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE employee SET full_name = @fullname" +
    " ,contact = @contact ,address = @address ,gender = @gender" +
    ", date_joined = @date_joined, basic_salary=@basic_salary ,allowance = @allowance" +
    ",  status=@status, position=@position, over_time_rate=@over_time_rate ,update_date =@updatedate" +
    " WHERE employee_id= @employeeID";




                        using (SqlCommand cmd = new SqlCommand(updateData, cnn))
                        {
                            cmd.Parameters.AddWithValue("@employeeID", emp_ID.Text.Trim());
                            cmd.Parameters.AddWithValue("@fullName", emp_fullname.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", emp_contact.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", emp_address.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", emp_gender.Text.Trim());
                            cmd.Parameters.AddWithValue("@date_joined", emp_dateTimePicker1.Text.Trim());
                            cmd.Parameters.AddWithValue("@basic_salary", emp_basicsalary.Text.Trim());
                            cmd.Parameters.AddWithValue("@allowance", emp_allowance.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", emp_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@position", emp_position.Text.Trim());
                            cmd.Parameters.AddWithValue("@over_time_rate", emp_overtimerate.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("Added Successfully!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                            ,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
            }
        }

        private void Emp_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void Emp_delete_Click(object sender, EventArgs e)
        {
            if (emp_ID.Text == ""
               || emp_fullname.Text == ""
               || emp_contact.Text == ""
               || emp_address.Text == ""
               || emp_gender.Text == ""
               || emp_dateTimePicker1.Text == ""
               || emp_basicsalary.Text == ""
               || emp_allowance.Text == ""
               || emp_overtimerate.Text == ""
               || emp_status.Text == ""
               || emp_position.Text == ""
               || emp_picture.Image == null
               )
            {
                MessageBox.Show("Please fill in the blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want tp DELETE" +
                    "Employee ID:" + emp_ID.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(check == DialogResult.Yes)
                {
                    try
                    {
                        cnn.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE employee SET delete_date=@deleteDate" +
                     " WHERE employee_id = @employeeID"; // Added space before WHERE

                        using (SqlCommand cmd = new SqlCommand(updateData, cnn))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@employeeID", emp_ID.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayEmployeeData();

                            MessageBox.Show("DELETE successful!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                            , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Addemployee_Load(object sender, EventArgs e)
        {
            //try
            {
               // loadResult();
            }
            //catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadResult()
        {
            
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Searchemlname_TextChanged(object sender, EventArgs e)
        {
            if (searchemlname.TextLength >= 4)
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    cnn.Open();

                    string sql = "SELECT * FROM employee ";
                    sql += "WHERE full_name LIKE @param";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Add parameter to the SqlCommand
                        cmd.Parameters.AddWithValue("@param", searchemlname.Text + "%");

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

        private void Emp_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
