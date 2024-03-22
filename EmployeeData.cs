using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GriffdanEmployeeManagement
{
    class EmployeeData
    {
        
            public int ID { get; set; }
            public string EmployeeID { get; set; }
            public string FullName { get; set; }
            public string Contact { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public DateTime DateJoined { get; set; }
            public int BasicSalary { get; set; }
            public decimal Allowance { get; set; }
            public string Status { get; set; }
            public string Position { get; set; }
            public decimal OvertimeRate { get; set; }
            public string Image { get; set; }
        


        SqlConnection connect =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");

        public List<GriffdanEmployeeManagement.EmployeeData> employeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employee WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.ID = (int)reader["id"];
                            ed.EmployeeID = reader["employee_id"].ToString();
                            ed.FullName = reader["full_name"].ToString();
                            ed.Contact = reader["contact"].ToString();
                            ed.Gender = reader["gender"].ToString();
                            ed.DateJoined = DateTime.Parse(reader["datejoined"].ToString());
                            ed.BasicSalary = int.Parse(reader["datejoined"].ToString());
                            ed.Allowance = int.Parse(reader["allowance"].ToString());
                            ed.Status = reader["status"].ToString();
                            ed.Position = reader["position"].ToString();
                            ed.OvertimeRate = decimal.Parse(reader["over_time_rate"].ToString());
                            ed.Image = reader["image"].ToString();

                            listdata.Add(ed);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);

                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }
    }
}
