using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.model
{
    public class City :  Base<City>
    {
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Get()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
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
