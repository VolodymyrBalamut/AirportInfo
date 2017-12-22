using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class ActualFlight : Base<ActualFlight,int>
    {
        public int ActualFlightID;
        private string flightCode;
        public Flight Flight
        {
            get
            {
                if (flightCode == "")
                    return null;
                return Flight.Items[flightCode];
            }
            set
            {
                if (value == null)
                    flightCode = "";
                else
                    flightCode = value.FlightCode;
            }
        }
        public DateTime ActualFlightDate;
        private string planeCode;
        public Plane Plane
        {
            get
            {
                if (planeCode == "")
                    return null;
                return Plane.Items[planeCode];
            }
            set
            {
                if (value == null)
                    planeCode = "";
                else
                    planeCode = value.PlaneCode;
            }
        }
        private string statusFlight;
        public StatusFlight StatusFlight
        {
            get
            {
                if (statusFlight == "")
                    return null;
                return StatusFlight.Items[statusFlight];
            }
            set
            {
                if (value == null)
                    statusFlight = "";
                else
                    statusFlight = value.StatusFlightName;
            }
        }
        private string terminalCode;
        public Terminal Terminal
        {
            get
            {
                if (terminalCode == "")
                    return null;
                return Terminal.Items[terminalCode];
            }
            set
            {
                if (value == null)
                    terminalCode = "";
                else
                    terminalCode = value.TerminalCode;
            }
        }
        public int TimeDifference;

        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbActualFlight
                 where ActualFlightID = @ActualFlightID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@ActualFlightID";
                param1.Value = this.ActualFlightID;
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
                    Items.Remove(this.ActualFlightID);
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
                string query = @"select * from tbActualFlight";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    ActualFlight temp = new ActualFlight();
                    temp.ActualFlightID = Convert.ToInt32(rdr[0]);
                    temp.flightCode = rdr[1].ToString();
                    try { temp.ActualFlightDate = (DateTime)rdr[2]; } catch { }
                    temp.planeCode = rdr[3].ToString();
                    temp.statusFlight = rdr[4].ToString();
                    temp.terminalCode = rdr[5].ToString();
                    temp.TimeDifference = Convert.ToInt32(rdr[6]);
                    //словник об'єктів
                    Items.Add(temp.ActualFlightID, temp);
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
                string query = @"insert into tbActualFlight
                            (FlightCode,ActualFlightDate,PlaneCode,StatusFlight,TerminalCode,TimeDifference)
                            values (@FlightCode,@ActualFlightDate,@PlaneCode,@StatusFlight,@TerminalCode,@TimeDifference)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@FlightCode";
                param1.Value = this.flightCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ActualFlightDate";
                param2.Value = this.ActualFlightDate;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@PlaneCode";
                param3.Value = this.planeCode;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@StatusFlight";
                param4.Value = this.statusFlight;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@TerminalCode";
                param5.Value = this.terminalCode;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@TimeDifference";
                param6.Value = this.TimeDifference;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
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
                update tActualFlight
                set FlightCode = @FlightCode,
                    ActualFlightDate = @ActualFlightDate,
                    PlaneCode = @PlaneCode,
                    StatusFlight = @StatusFlight,
                    TerminalCode = @TerminalCode,
                    TimeDifference = @TimeDifference
                where ActualFlightID = @ActualFlightID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@FlightCode";
                param1.Value = this.flightCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ActualFlightDate";
                param2.Value = this.ActualFlightDate;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@PlaneCode";
                param3.Value = this.planeCode;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@StatusFlight";
                param4.Value = this.statusFlight;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@TerminalCode";
                param5.Value = this.terminalCode;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@TimeDifference";
                param6.Value = this.TimeDifference;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@ActualFlightID";
                param7.Value = this.ActualFlightID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);
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
        public static void RefreshStatus()
        {
            try
            {
                conn.Open();
                string query = @"exec spUpdateStatus";
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
