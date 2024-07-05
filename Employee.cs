using GriffdanEmployeeManagement;
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

namespace GriffdanManagementsystem
{
    public partial class Employee : Form
    {

        private SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Employee()
        {
            InitializeComponent();

            displayEmployeeData();
        }

        public void displayEmployeeData()
        {
            EmployeeData ed = new EmployeeData();
            List<EmployeeData> listData = ed.employeeListData(); // Set breakpoint here

            dataGridView1.DataSource = listData;
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
                 || emp_overtimerate.Text == ""
                 || emp_status.Text == ""
                 || emp_position.Text == ""
                 || emp_image.Image == null
                 )
            {
                MessageBox.Show("Please fill in the blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkEmID = "SELECT COUNT(*) FROM employee WHERE employee_id = @emID AND delete_date IS NULL";


                        using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                        {
                            checkEm.Parameters.AddWithValue("@emID", emp_ID.Text.Trim());
                            int count = (int)checkEm.ExecuteScalar();

                            if(count >= 1)
                            {
                                MessageBox.Show(emp_ID.Text.Trim() + "is already taken"
                                    , "Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO employee" +
    "(employee_id, full_name, contact, address, gender, date_joined" +
    ", basic_salary, allowance, status, position, over_time_rate, insert_date, image)" +
    "VALUES(@employeeID, @fullName, @contact, @address, @gender, @date_joined" +
    ", @basic_salary, @allowance, @status, @position, @over_time_rate, @insertDate, @image)";



                                string path = Path.Combine(@"C:\Users\Gadget Fix\source\repos\GriffdanManagementsystem\Directory\"
                                + emp_ID.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if(!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                File.Copy(emp_image.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@employeeID",emp_ID.Text.Trim());
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
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error : " + ex
                            , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void Emp_import_Click(object sender, EventArgs e)
        {

        }

        private void Emp_import_Click_1(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    emp_image.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                emp_ID.Text = row.Cells[1].Value.ToString();
                emp_fullname.Text = row.Cells[2].Value.ToString();
                emp_contact.Text = row.Cells[3].Value.ToString();
                emp_gender.Text = row.Cells[4].Value.ToString();
                emp_dateTimePicker1.Text = row.Cells[5].Value.ToString();
                emp_basicsalary.Text = row.Cells[6].Value.ToString();
                emp_allowance.Text = row.Cells[7].Value.ToString();
                emp_status.Text = row.Cells[8].Value.ToString();
                emp_position.Text = row.Cells[9].Value.ToString();
                emp_status.Text = row.Cells[10].Value.ToString();
                emp_overtimerate.Text = row.Cells[11].Value.ToString();

                string imagePath = row.Cells[12].Value.ToString();

                if (imagePath != null)
                {
                    emp_image.Image = Image.FromFile(imagePath);
                }
                else
                {
                    emp_image.Image = null;
                }

                
            }
        }
        

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                emp_ID.Text = row.Cells[1].Value.ToString();
                emp_fullname.Text = row.Cells[2].Value.ToString();
                emp_contact.Text = row.Cells[3].Value.ToString();
                emp_gender.Text = row.Cells[4].Value.ToString();
                emp_dateTimePicker1.Text = row.Cells[5].Value.ToString();
                emp_basicsalary.Text = row.Cells[6].Value.ToString();
                emp_allowance.Text = row.Cells[7].Value.ToString();
                emp_status.Text = row.Cells[8].Value.ToString();
                emp_position.Text = row.Cells[9].Value.ToString();
                emp_status.Text = row.Cells[10].Value.ToString();
                emp_overtimerate.Text = row.Cells[11].Value.ToString();

                string imagePath = row.Cells[12].Value.ToString();

                if (imagePath != null)
                {
                    emp_image.Image = Image.FromFile(imagePath);
                }
                else
                {
                    emp_image.Image = null;
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
            emp_overtimerate.Text = "";
            emp_status.SelectedIndex = -1;
            emp_position.Text = "";
            emp_overtimerate.Text = "";
            emp_image.Image = null;
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void Searchempid_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void Emp_update_Click(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
