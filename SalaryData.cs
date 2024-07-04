using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffdanManagementsystem
{
    class SalaryData
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }

        public double BasicSalary { get; set; }
        public double OvertimeRate { get; set; }

        public double Allowances { get; set; }

        public int RemainingLeaves { get; set; }
        public DateTime Salarybegindate { get; set; }
        public DateTime Salaryenddate { get; set; }
        public int NumberOfLeaves { get; set; }
        public int NumberOfAbsent { get; set; }
        public int NumberOfHolidays { get; set; }
        public int OvertimeHours { get; set; }

        // Monthly salary, allowances, and tax rates (replace these with your actual values)
        public double MonthlySalary { get; set; }
     
        public double GovernmentTaxRate { get; set; }
       

        // Calculated properties
        public double BasePay => MonthlySalary + Allowances + (OvertimeRate * OvertimeHours);

        public double GrossPay
        {
            get
            {
                double noPayValue = (MonthlySalary / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) * NumberOfAbsent;
                double basePayValue = BasePay;
                return basePayValue - (noPayValue + basePayValue * GovernmentTaxRate);
            }
        }
        SqlConnection connect =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");
        public List<SalaryData> SalaryListDatas()
        {
            List<SalaryData> listdata = new List<SalaryData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM salary ";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SalaryData sd = new SalaryData();
                            sd.EmployeeID = reader["employee_id"].ToString();
                            sd.BasicSalary = (int)reader["basicsalary"];
                            sd.OvertimeRate = double.Parse(reader["over_time_rate"].ToString());
                            sd.NumberOfLeaves = (int)reader["NumberOfLeaves"];
                            sd.NumberOfAbsent = (int)reader["NumberOfAbsent"];
                            sd.NumberOfHolidays = (int)reader["NumberOfHoliday"];
                            sd.OvertimeHours = (int)reader["Overtimehours"];
                            sd.Allowances = (double)reader["Allowance"];
                            sd.GovernmentTaxRate = (double)reader["GovermentTax"];
                            
                            listdata.Add(sd);

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
