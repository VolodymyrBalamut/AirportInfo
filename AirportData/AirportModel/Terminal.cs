using System.Data.SqlClient;

namespace AirportData
{
    public class Terminal : Base<Terminal,string>
    {
        public string TerminalCode;
        public string TerminalCodeOld;

        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbTerminal
                 where TerminalCode = @TerminalCode";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@TerminalCode";
                param1.Value = this.TerminalCode;
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
                    Items.Remove(this.TerminalCode);
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
                string query = @"select * from tbTerminal";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Terminal temp = new Terminal();
                    temp.TerminalCode = rdr[0].ToString();
                    //словник об'єктів
                    Items.Add(temp.TerminalCode, temp);
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
                string query = @"insert into tbTerminal
                            (TerminalCode)
                            values (@TerminalCode)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@TerminalCode";
                param1.Value = this.TerminalCode;
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
                update tbTerminal
                set TerminalCode = @TerminalCode
                where TerminalCode = @TerminalCodeOld";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@TerminalCode";
                param1.Value = this.TerminalCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@TerminalCodeOld";
                param2.Value = this.TerminalCodeOld;

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
