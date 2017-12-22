using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class Flight : Base<Flight,string>
    {
        public string FlightCode{ get; set; }
        public string DepartTime { get; set; }
        
        //Depart Airport
        private string DepartAirportCode;
       
        public Airport DepartAirport
        {
            get
            {
                if (DepartAirportCode == "")
                    return null;
                return Airport.Items[DepartAirportCode];
            }
            set
            {
                if (value == null)
                    DepartAirportCode = "";
                else
                    DepartAirportCode = value.AirportCode;
            }
        }
        public string ArriveTime { get; set; }
        //Arrive Airport
        private string ArriveAirportCode;
        public Airport ArriveAirport
        {
            get
            {
                if (ArriveAirportCode == "")
                    return null;
                return Airport.Items[ArriveAirportCode];
            }
            set
            {
                if (value == null)
                    ArriveAirportCode = "";
                else
                    ArriveAirportCode = value.AirportCode;
            }
        }
        //Company
        private string CompanyCode;
        public Company Company
        {
            get
            {
                if (CompanyCode == "")
                    return null;
                return Company.Items[CompanyCode];
            }
            set
            {
                if (value == null)
                    CompanyCode = "";
                else
                    CompanyCode = value.CompanyCode;
            }
        }
        //Plane
        private string PlaneCode;
        public Plane Plane
        {
            get
            {
                if (PlaneCode == "")
                    return null;
                return Plane.Items[PlaneCode];
            }
            set
            {
                if (value == null)
                    PlaneCode = "";
                else
                    PlaneCode = value.PlaneCode;
            }
        }
        public string WeekDay { get; set; }


        public bool Monday
        {
            get
            {
                if (WeekDay.Substring(0,1)=="1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = "1" + WeekDay.Substring(1, 6);
                    WeekDay = temp;
                }
            }
        }
        public bool Tuesday
        {
            get
            {
                if (WeekDay.Substring(1, 1) == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 1) + "2" + WeekDay.Substring(2, 5);
                    WeekDay = temp;
                }
            }
        }
        public bool Wednesday
        {
            get
            {
                if (WeekDay.Substring(2, 1) == "3")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 2) + "3" + WeekDay.Substring(3, 4);
                    WeekDay = temp;
                }
            }
        }
        public bool Thursday
        {
            get
            {
                if (WeekDay.Substring(3, 1) == "4")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 3) + "4" + WeekDay.Substring(4, 3);
                    WeekDay = temp;
                }
            }
        }
        public bool Friday
        {
            get
            {
                if (WeekDay.Substring(4, 1) == "5")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 4) + "5" + WeekDay.Substring(5, 2);
                    WeekDay = temp;
                }
            }
        }
        public bool Suterday
        {
            get
            {
                if (WeekDay.Substring(5, 1) == "6")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 5) + "6" + WeekDay.Substring(6, 1);
                    WeekDay = temp;
                }
            }
        }
        public bool Sunday
        {
            get
            {
                if (WeekDay.Substring(6, 1) == "7")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    string temp = WeekDay.Substring(0, 6) + "7";
                    WeekDay = temp;
                }
            }
        }

        public string DepartHour
        {
            get
            {
                string hour = "";
                try
                {
                    string[] arr = DepartTime.Split(':');
                    hour = arr[0];
                }
                catch { }
                return hour;
              
            }
        }
        public string ArriveHour
        {
            get
            {
                string hour = "";
                try
                {
                    string[] arr = ArriveTime.Split(':');
                    hour = arr[0];
                }
                catch { }
                return hour;

            }
        }
        public string DepartMinutes
        {
            get
            {
                string minutes = "";
                try
                {
                    string[] arr = DepartTime.Split(':');
                    minutes = arr[1];
                }
                catch { }
                return minutes;

            }
        }
        public string ArriveMinutes
        {
            get
            {
                string minutes = "";
                try
                {
                    string[] arr = ArriveTime.Split(':');
                    minutes = arr[1];
                }
                catch { }
                return minutes;

            }
        }

        public Flight() { }
        public Flight(string FlightCode) { this.FlightCode = FlightCode; }
        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbFlight
                 where FlightCode = @FlightCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@FlightCode";
                param1.Value = this.FlightCode;
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
                    Items.Remove(this.FlightCode);
                }
            }
            return success;
    }

        public static Flight GetFlight(string FlightCode)
        {
            try
            {
                conn.Open();
                Flight temp = new Flight();
                string query = @"select * from tbFlight where FlightCode = @FlightCode";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@FlightCode";
                param10.Value = FlightCode;
                cmd.Parameters.Add(param10);
                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    temp.FlightCode = rdr[0].ToString();
                    temp.DepartTime = rdr[1].ToString();
                    temp.ArriveTime = rdr[2].ToString();
                    temp.DepartAirportCode = rdr[3].ToString();
                    temp.ArriveAirportCode = rdr[4].ToString();
                    temp.CompanyCode = rdr[5].ToString();
                    temp.PlaneCode = rdr[6].ToString();
                    temp.WeekDay = rdr[7].ToString();
                    //словник об'єктів
                   
                }
                conn.Close();
                return temp;
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
        public override bool GetAll()
        {
            bool success = false;
            try
            {
                conn.Open();
                string query = @"select * from tbFlight";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Flight temp = new Flight();
                    temp.FlightCode = rdr[0].ToString();
                    temp.DepartTime = rdr[1].ToString();
                    temp.ArriveTime = rdr[2].ToString();
                    temp.DepartAirportCode = rdr[3].ToString();
                    temp.ArriveAirportCode = rdr[4].ToString();
                    temp.CompanyCode = rdr[5].ToString();
                    temp.PlaneCode = rdr[6].ToString();
                    temp.WeekDay = rdr[7].ToString();
                    //словник об'єктів
                    Items.Add(temp.FlightCode, temp);
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
                string query = @"insert into tbFlight
                            (FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay)
                            values (@FlightCode,@DepartTime,@ArriveTime,@DepartAirportCode,@ArriveAirportCode,@CompanyCode,@PlaneCode,@WeekDay)";
                // 2. define parameters used in command object
                SqlParameter param0 = new SqlParameter();
                param0.ParameterName = "@FlightCode";
                param0.Value = this.FlightCode;
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@DepartTime";
                param1.Value = this.DepartTime;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ArriveTime";
                param2.Value = this.ArriveTime;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@DepartAirportCode";
                param3.Value = this.DepartAirport.AirportCode;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@ArriveAirportCode";
                param5.Value = this.ArriveAirport.AirportCode;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@CompanyCode";
                param7.Value = this.Company.CompanyCode;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@PlaneCode";
                param8.Value = this.Plane.PlaneCode;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@WeekDay";
                param9.Value = this.WeekDay;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param0);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param7);
                cmd.Parameters.Add(param8);
                cmd.Parameters.Add(param9);
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
                update tbFlight
                set DepartTime = @DepartTime,
                    ArriveTime = @ArriveTime,
                    DepartAirportCode = @DepartAirportCode,
                    ArriveAirportCode = @ArriveAirportCode,
                    CompanyCode = @CompanyCode,
                    PlaneCode = @PlaneCode,
                    WeekDay = @WeekDay
                where FlightCode = @FlightCode";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@DepartTime";
                param1.Value = this.DepartTime;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ArriveTime";
                param2.Value = this.ArriveTime;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@DepartAirportCode";
                param3.Value = this.DepartAirport.AirportCode;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@ArriveAirportCode";
                param5.Value = this.ArriveAirport.AirportCode;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@CompanyCode";
                param7.Value = this.Company.CompanyCode;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@PlaneCode";
                param8.Value = this.Plane.PlaneCode;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@WeekDay";
                param9.Value = this.WeekDay;
                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@FlightCode";
                param10.Value = this.FlightCode;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param7);
                cmd.Parameters.Add(param8);
                cmd.Parameters.Add(param9);
                cmd.Parameters.Add(param10);
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
