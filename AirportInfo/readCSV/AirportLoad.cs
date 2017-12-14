using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.readCSV
{
    public class AirportLoad
    {
        protected static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        public static void loadData()
        {
            using (var reader = new StreamReader(@"D:\Iт-52\5_semestr\Курсач\airports.dat.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    try
                    {
                        conn.Open();
                        string query = @"insert into tbAirportLoad
                            (AirportCode,AirportName,CityName,CountryName)
                            values (@AirportCode,@AirportName,@CityName,@CountryName)";
                        // 2. define parameters used in command object
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@AirportCode";
                        param1.Value = values[4].ToString();
                        SqlParameter param2 = new SqlParameter();
                        param2.ParameterName = "@AirportName";
                        param2.Value = values[1].ToString();
                        SqlParameter param3 = new SqlParameter();
                        param3.ParameterName = "@CityName";
                        param3.Value = values[2].ToString();
                        SqlParameter param4 = new SqlParameter();
                        param4.ParameterName = "@CountryName";
                        param4.Value = values[3].ToString();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        // Close the connection
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
    }
}
