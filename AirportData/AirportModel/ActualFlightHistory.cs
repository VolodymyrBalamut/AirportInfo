using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData.AirportModel
{
    public class ActualFlightHistory : Base<ActualFlightHistory, int>
    {
        public int ActualFlightHistoryID;
        public string OldStatus;
        public string NewStatus;
        public DateTime DateChange;
        public int ActualFlightID;

        public ActualFlightHistory() { }
        public ActualFlightHistory(string OldStatus, string NewStatus, DateTime DateChange, int ActualFlightID)
        {
            this.OldStatus = OldStatus;
            this.NewStatus = NewStatus;
            this.DateChange = DateChange;
            this.ActualFlightID = ActualFlightID;
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
                 delete from tbActualFlightHistory
                 where ActualFlightHistoryID = @ActualFlightHistoryID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@ActualFlightHistoryID";
                param1.Value = this.ActualFlightHistoryID;
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
                string query = @"select * from tbActualFlightHistory";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    ActualFlightHistory temp = new ActualFlightHistory();
                    temp.ActualFlightHistoryID = Convert.ToInt32(rdr[0]);
                    temp.OldStatus = rdr[1].ToString();
                    temp.NewStatus = rdr[2].ToString();
                    try { temp.DateChange = (DateTime)rdr[3]; } catch { }
                    temp.ActualFlightID = Convert.ToInt32(rdr[4]);
                    //словник об'єктів
                    Items.Add(temp.ActualFlightHistoryID, temp);
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
                string query = @"insert into tbActualFlightHistory
                            (OldStatus,NewStatus,DateChange,ActualFlightID)
                            values (@OldStatus,@NewStatus,@DateChange,@ActualFlightID)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@OldStatus";
                param1.Value = this.OldStatus;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@NewStatus";
                param2.Value = this.NewStatus;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@DateChange";
                param3.Value = this.DateChange;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@ActualFlightID";
                param4.Value = this.ActualFlightID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
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
                update tbActualFlightHistory
                set OldStatus = @OldStatus,
                    NewStatus = @NewStatus,
                    DateChange = @DateChange,
                    ActualFlightID = @ActualFlightID
                where ActualFlightHistoryID = @ActualFlightHistoryID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@OldStatus";
                param1.Value = this.OldStatus;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@NewStatus";
                param2.Value = this.NewStatus;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@DateChange";
                param3.Value = this.DateChange;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@ActualFlightID";
                param4.Value = this.ActualFlightID;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@ActualFlightHistoryID";
                param5.Value = this.ActualFlightHistoryID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
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
