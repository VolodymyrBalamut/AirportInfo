using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Country : Base<Country,string>
    {
        public string CountryCode;
        public string CountryName;
        public Country() { }
        public Country(string CountryCode, string CountryName)
        {
            this.CountryCode = CountryCode;
            this.CountryName = CountryName;
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
                 delete from tbCountry
                 where CountryCode = @CountryCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
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
                    Items.Remove(this.CountryCode);
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
                string query = @"select * from tbCountry";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Country temp = new Country();
                    temp.CountryCode = rdr[0].ToString();
                    temp.CountryName = rdr[1].ToString();
                    //словник об'єктів
                    Items.Add(temp.CountryCode, temp);
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
                string query = @"insert into tbCountry
                            (CountryCode,CountryName)
                            values (@CountryCode,@CountryName)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CountryName";
                param2.Value = this.CountryName;
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
                update tbCountry
                set CountryName = @CountryName
                where CountryCode = @CountryCode";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CountryName";
                param2.Value = this.CountryName;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
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
                string query = @"exec spLoadCoutry";
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
