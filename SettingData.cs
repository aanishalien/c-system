using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GriffdanManagementsystem
{
    class SettingData
    {
        // Define properties for salary settings
        public DateTime SalaryBeginDate { get; set; }
        public DateTime SalaryEndDate { get; set; }
        public int SalaryCycleDays { get; set; }
        public int NumberOfLeaves { get; set; }
        public decimal GovernmentTax { get; set; }

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gadget Fix\Documents\griffonDb.mdf;Integrated Security=True;Connect Timeout=30");

        public List<SettingData> SettingDatas()
        {
            List<SettingData> listdata = new List<SettingData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM settings";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SettingData sd = new SettingData();

                            sd.SalaryBeginDate = Convert.ToDateTime(reader["SalaryBeginDate"]);
                            sd.SalaryEndDate = Convert.ToDateTime(reader["SalaryEndDate"]);
                            sd.SalaryCycleDays = (int)reader["NumberOfLeaves"];
                            sd.NumberOfLeaves = (int)reader["NumberOfLeaves"];
                            sd.GovernmentTax = (decimal)reader["GovernmentTax"];

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
