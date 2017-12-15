using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Company : Base<Company>
    {
        public string CompanyCode;
        public string CompanyName;
        public string CountryCode;
        public string Callsign;
        public static Dictionary<string, Company> Items = new Dictionary<string, Company>();

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
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

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
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
