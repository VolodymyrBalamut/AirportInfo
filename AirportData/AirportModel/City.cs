using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class City :  Base<City,string>
    {
        private string CountryCode;
        private string CityName;
        private string CountryCodeOld;
        private string CityNameOld;

        public void setNewCity(string CountryCode,string CityName)
        {
            this.CountryCode = CountryCode;
            this.CityName = CityName;
        }
        public void setOldCity(string CountryCode, string CityName)
        {
            this.CountryCodeOld = CountryCode;
            this.CityNameOld = CityName;
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
                 delete from tbCity
                 where CountryCode = @CountryCode and CityName = @CityName";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CityName";
                param2.Value = this.CityName;
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
                    //Items.Remove(this.ID);
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
                string query = @"select * from tbCity order by CityName";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    City temp = new City();
                    temp.CountryCode = rdr[0].ToString();
                    temp.CityName = rdr[1].ToString();
                    //словник об'єктів
                    Items.Add(temp.CityName, temp);
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
                string query = @"insert into tbCity
                            (CountryCode,CityName)
                            values (@CountryCode,@CityName)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CityName";
                param2.Value = this.CityName;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
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
                update tbCity
                set CountryCode = @CountryCode,
                    CityName = @CityName
                where CountryCode = @CountryCodeOld and CityName = @CityNameOld";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CityName";
                param2.Value = this.CityName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@CountryCodeOld";
                param3.Value = this.CountryCodeOld;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@CityNameOld";
                param4.Value = this.CityNameOld;
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

        public static void Refresh()
        {
            try
            {
                conn.Open();
                string query = @"exec spLoadCity";
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
