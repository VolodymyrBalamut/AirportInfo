using System.Data.SqlClient;

namespace AirportData.AirportModel
{
    public class Config : Base<Config, string>
    {
        private string Param;
        private string Val;

        public Config() { }
        public Config(string Param, string Val)
        {
            this.Param = Param;
            this.Val = Val;
        }
        public string getVal()
        {
            return Val;
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
                 delete from tbConfig
                 where Param = @Param";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Param";
                param1.Value = this.Param;
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
                    Items.Remove(this.Param);
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
                string query = @"select * from tbConfig";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Config temp = new Config();
                    temp.Param = rdr[0].ToString();
                    temp.Val = rdr[1].ToString();
                    //словник об'єктів
                    Items.Add(temp.Param, temp);
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
                string query = @"insert into tbConfig
                            (Param,Val)
                            values (@Param,@Val)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Param";
                param1.Value = this.Param;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Val";
                param2.Value = this.Val;
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
                update tbConfig
                set Val = @Val
                where Param = @Param";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Val";
                param1.Value = this.Val;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Param";
                param2.Value = this.Param;
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

        public static Config getAirportCurrent()
        {
           
            try
            {
                conn.Open();
                string query = @"select * from tbConfig where Param = 'AirportCode'";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Config temp = new Config();
                    temp.Param = rdr[0].ToString();
                    temp.Val = rdr[1].ToString();
                    //словник об'єктів
                    return temp;
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
            return null;
        }
    }
}
