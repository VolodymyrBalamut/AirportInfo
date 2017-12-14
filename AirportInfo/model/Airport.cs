using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.model
{
    public class Airport: Base<Airport>
    {
        public string AirportCode;
        public string AirportName;
        public string CountryCode;
        public string CityName;

        public static Dictionary<string, Airport> Items = new Dictionary<string, Airport>();

        public Airport() { }
        public Airport(string AirportCode, string AirportName, string CountryCode, string CityName)
        {
            this.AirportCode = AirportCode;
            this.AirportName = AirportName;
            this.CountryCode = CountryCode;
            this.CityName = CityName;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
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
            try
            {
                conn.Open();
                string query = @"insert into tbAirport
                            (AirportCode,AirportName,CityName)
                            values (@AirportCode,@AirportName,@CityName)";
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
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
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

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return AirportName;
        }
    }


}
