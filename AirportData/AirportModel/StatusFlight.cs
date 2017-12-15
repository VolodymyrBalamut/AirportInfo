using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class StatusFlight : Base<StatusFlight,string>
    {
        public string StatusFlightName;
        public string Description;

        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbStatusFlight
                 where StatusFlight = @StatusFlight";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@StatusFlight";
                param1.Value = this.StatusFlightName;
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
                    Items.Remove(this.StatusFlightName);
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
                string query = @"select * from tbStatusFlight";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    StatusFlight temp = new StatusFlight();
                    temp.StatusFlightName = rdr[0].ToString();
                    temp.Description = rdr[1].ToString();
                    //словник об'єктів
                    Items.Add(temp.StatusFlightName, temp);
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
                string query = @"insert into tbStatusFlight
                            (StatusFlight,Description)
                            values (@StatusFlight,@Description)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@StatusFlight";
                param1.Value = this.StatusFlightName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Description";
                param2.Value = this.Description;
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
                update tbAirport
                set Description = @Description
                where StatusFlight = @StatusFlight";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@StatusFlight";
                param1.Value = this.StatusFlightName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Description";
                param2.Value = this.Description;
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
    }
}
