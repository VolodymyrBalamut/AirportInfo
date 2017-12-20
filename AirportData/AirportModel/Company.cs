using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Company : Base<Company,string>
    {
        public string CompanyCode;
        public string CompanyName;
        public string CountryCode;
        public string Callsign;
        public Company() { }
        public Company(string CompanyCode,string CompanyName, string CountryCode, string Callsign)
        {
            this.CompanyCode = CompanyCode;
            this.CompanyName = CompanyName;
            this.CountryCode = CountryCode;
            this.Callsign = Callsign;
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
                 delete from tbCompany
                 where CompanyCode = @CompanyCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CompanyCode";
                param1.Value = this.CompanyCode;
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
                    Items.Remove(this.CompanyCode);
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
                string query = @"select * from tbCompany";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Company temp = new Company();
                    temp.CompanyCode = rdr[0].ToString();
                    temp.CompanyName = rdr[1].ToString();
                    temp.CountryCode = rdr[2].ToString();
                    temp.Callsign = rdr[3].ToString();
                    //словник об'єктів
                    Items.Add(temp.CompanyCode, temp);
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
                string query = @"insert into tbCompany
                            (CompanyCode,CompanyName,CountryCode,Callsign)
                            values (@CompanyCode,@CompanyName,@CountryCode,@Callsign)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CompanyCode";
                param1.Value = this.CompanyCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CompanyName";
                param2.Value = this.CompanyName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@CountryCode";
                param3.Value = this.CountryCode;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Callsign";
                param4.Value = this.Callsign;
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
                update tbCompany
                set CompanyName = @CompanyName,
                    CountryCode = @CountryCode,
                    Callsign = @Callsign
                where CompanyCode = @CompanyCode";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CompanyName";
                param1.Value = this.CompanyName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CountryCode";
                param2.Value = this.CountryCode;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Callsign";
                param3.Value = this.Callsign;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@CompanyCode";
                param4.Value = this.CompanyCode;

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
            return CompanyName;
        }
        public static void Refresh()
        {
            try
            {
                conn.Open();
                string query = @"exec spLoadCompany";
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
