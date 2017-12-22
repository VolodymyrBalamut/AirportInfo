using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirportData
{
    public class Plane : Base<Plane,string>
    {
        private string planeCode;
        public string PlaneCode
        {
            get
            {
                return planeCode;
            }
            set
            {
                if(value.Length>0 && value.Length <= 10)
                {
                    planeCode = value;
                }
            }
        }
        private string planeName;
        public string PlaneName
        {
            get
            {
                return planeName;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                {
                    if (regStr.IsMatch(value))
                    {
                        planeName = value;
                    }
                } 
            }
        }
        private string speed;
        public string Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    if (regStr.IsMatch(value))
                    {
                        speed = value;
                    }
                }
            }
        }
        public string distance;
        public string Distance
        {
            get
            {
                return speed;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    if (regStr.IsMatch(value))
                    {
                        distance = value;
                    }
                }
            }
        }
        private int seats;
        public string Seats
        {
            get
            {
                return seats.ToString();
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    if (regNum.Match(value).Success)
                    {
                        seats = Convert.ToInt32(value);
                    }
                }
            }
        }

        public Plane() { }
        public Plane(string PlaneCode, string PlaneName,string Speed, string Distance, string Seats)
        {
            this.planeCode = PlaneCode;
            this.planeName = PlaneName;
            this.speed = Speed;
            this.distance = Distance;
            this.Seats = Seats;
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
                 delete from tbPlane
                 where PlaneCode = @PlaneCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PlaneCode";
                param1.Value = this.PlaneCode;
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
                    Items.Remove(this.PlaneCode);
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
                string query = @"select * from tbPlane";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Plane temp = new Plane();
                    temp.PlaneCode = rdr[0].ToString();
                    temp.PlaneName = rdr[1].ToString();
                    temp.Speed = rdr[2].ToString();
                    temp.Distance = rdr[3].ToString();
                    temp.Seats = rdr[4].ToString();
                    //словник об'єктів
                    Items.Add(temp.PlaneCode, temp);
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
                string query = @"insert into tbPlane
                            (PlaneCode,PlaneName,Speed,Distance,Seats)
                            values (@PlaneCode,@PlaneName,@Speed,@Distance,@Seats)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PlaneCode";
                param1.Value = this.PlaneCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@PlaneName";
                param2.Value = this.PlaneName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Speed";
                param3.Value = this.Speed;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Distance";
                param4.Value = this.Distance;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Seats";
                param5.Value = this.Seats;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
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
                update tbPlane
                set PlaneName = @PlaneName,
                    Speed = @Speed,
                    Distance = @Distance,
                    Seats = @Seats
                where PlaneCode = @PlaneCode";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PlaneCode";
                param1.Value = this.PlaneCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@PlaneName";
                param2.Value = this.PlaneName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Speed";
                param3.Value = this.Speed;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Distance";
                param4.Value = this.Distance;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Seats";
                param5.Value = this.Seats;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
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
            return PlaneCode;
        }

        public static void Refresh()
        {
            try
            {
                conn.Open();
                string query = @"exec spLoadPlane";
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

        public String getPlaneName()
        {
            return this.PlaneName;
        }
    }
}
