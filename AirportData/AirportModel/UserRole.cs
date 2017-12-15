using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class UserRole : Base<UserRole,string>
    {
        public string UserRoleName;
        public string UserRoleDesc;

        public override bool Delete()
        {
            bool success = false;
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbUserRole
                 where UserRoleName = @UserRoleName";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UserRoleName";
                param1.Value = this.UserRoleName;
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
                    Items.Remove(this.UserRoleName);
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
                string query = @"select * from tbUserRole";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    UserRole temp = new UserRole();
                    temp.UserRoleName = rdr[0].ToString();
                    temp.UserRoleDesc = rdr[1].ToString();
                    //словник об'єктів
                    Items.Add(temp.UserRoleName, temp);
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
                string query = @"insert into tbUserRole
                            (UserRoleName,UserRoleDesc)
                            values (@UserRoleName,@UserRoleDesc)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UserRoleName";
                param1.Value = this.UserRoleName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@UserRoleDesc";
                param2.Value = this.UserRoleDesc;
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
                update tbUserRole
                set UserRoleDesc = @UserRoleDesc
                where UserRoleName = @UserRoleName";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UserRoleName";
                param1.Value = this.UserRoleName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@UserRoleDesc";
                param2.Value = this.UserRoleDesc;
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
