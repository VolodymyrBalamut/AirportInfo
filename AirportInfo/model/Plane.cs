using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.model
{
    public class Plane : Base<Plane>
    {
        public string PlaneCode;
        public string PlaneName;
        public string Speed;
        public string Distance;
        public int Seats;
        public static Dictionary<string, Plane> Items = new Dictionary<string, Plane>();
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
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
                    temp.Seats = Convert.ToInt32(rdr[4]);
                    //словник об'єктів
                    Items.Add(temp.PlaneCode, temp);
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
            return PlaneCode;
        }
    }
}
