using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Airport: Base<Airport,string>
    {
        public string AirportCode;
        public string AirportName;
        public string CountryCode;
        public string CityName;

       // public static Dictionary<string, Airport> Items = new Dictionary<string, Airport>();

        public Airport() { }
        public Airport(string AirportCode, string AirportName, string CountryCode, string CityName)
        {
            this.AirportCode = AirportCode;
            this.AirportName = AirportName;
            this.CountryCode = CountryCode;
            this.CityName = CityName;
        }

        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbAirport
                 where AirportCode = @AirportCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@AirportCode";
                param1.Value = this.AirportCode;
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();
                success = true;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                    Items.Remove(this.AirportCode);
                }
            }
            return success;
        }

        public override bool GetAll()
        {
            bool success = false;
            try
            {
                conn.Open();
                string query = @"select * from tbAirport order by AirportName";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Airport temp = new Airport();
                    temp.AirportCode = rdr[0].ToString();
                    temp.AirportName = rdr[1].ToString();
                    temp.CountryCode = rdr[2].ToString();
                    temp.CityName = rdr[3].ToString();
                    //словник об'єктів
                    Items.Add(temp.AirportCode, temp);
                }
                conn.Close();
                success = true;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return success;
        }

        public override bool Insert()
        {
            bool success = false;
            try
            {
                conn.Open();
                string query = @"insert into tbAirport
                            (AirportCode,AirportName,CityName,CountryCode)
                            values (@AirportCode,@AirportName,@CityName,@CountryCode)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@AirportCode";
                param1.Value = this.AirportCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@AirportName";
                param2.Value = this.AirportName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@CityName";
                param3.Value = this.CityName;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@CountryCode";
                param4.Value = this.CountryCode;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.ExecuteNonQuery();
                success = true;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return success;
        }

        public override bool Update()
        {
            bool success = false;
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbAirport
                set AirportName = @AirportName,
                    CountryCode = @CountryCode,
                    CityName = @CityName
                where AirportCode = @AirportCode";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@AirportName";
                param1.Value = this.AirportName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CountryCode";
                param2.Value = this.CountryCode;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@CityName";
                param3.Value = this.CityName;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@AirportCode";
                param4.Value = this.AirportCode;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
                success = true;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return success;
        }

        public override string ToString()
        {
            return AirportName;
        }
        public static void Refresh()
        {
            try
            {
                conn.Open();
                string query = @"exec spLoadAirport";
                SqlCommand cmd = new SqlCommand(query, conn);
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
