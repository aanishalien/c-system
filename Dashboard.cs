using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GriffdanManagementsystem
{
    public partial class Dashboard : UserControl
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Dashboard()
        {
            InitializeComponent();

            DisplayAE();
            DisplayTE();
            DisplayIAE();

            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void DisplayAE_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DisplayTE_Paint(object sender, PaintEventArgs e)
        {

        }

        public void refreshData()
        {

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            DisplayTE();
            DisplayAE();
            DisplayIAE();
        }

        public void DisplayTE()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                    string selecData = "SELECT COUNT(id) FROM employee " +
                        "WHERE status = 'Active' AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selecData, cnn))
                    {
                        // Execute the command and handle the result
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

        public void DisplayAE()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                    string selecData = "SELECT COUNT(id) FROM employee" +
                        "WHERE delete_date IS NULL ";

                    using (SqlCommand cmd = new SqlCommand(selecData, cnn))
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cnn.Close();
                }
            }
        }

        public void DisplayIAE()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                    string selecData = "SELECT COUNT(id) FROM employee" +
                        "WHERE status = 'Active' AND delete_date IS NULL ";

                    using (SqlCommand cmd = new SqlCommand(selecData, cnn))
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cnn.Close();
                }
            }
        }


    }
}
