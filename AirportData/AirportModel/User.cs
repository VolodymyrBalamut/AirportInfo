using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class User : Base<User,int>
    {
        public int UserID;
        public string Login;
        public string Password;
        public string UserRoleName;

        public User() { }
        public User(string Login, string Password, string UserRoleName)
        {
            this.Login = Login;
            this.Password = Password;
            this.UserRoleName = UserRoleName;
        }
        public static User getUser(string Login,string Password)
        {
            User user = new User();
            try
            {
                conn.Open();
                string query = @"select UserID, Login, Password, UserRoleName from tbUser
                                    where Login = @Login and Password = @Password";
                // 1. Instantiate a new command with a query and connection
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Login";
                param1.Value = Login;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Password";
                param2.Value = Password;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    user.UserID = Convert.ToInt32(rdr[0]);
                    user.Login = Convert.ToString(rdr[1]);
                    user.Password = Convert.ToString(rdr[2]);
                    user.UserRoleName = Convert.ToString(rdr[3]);
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
            return user;
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
                 delete from tbUser
                 where UserID = @UserID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UserID";
                param1.Value = this.UserID;
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
                    Items.Remove(this.UserID);
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
                string query = @"select * from tbUser";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    User temp = new User();
                    temp.UserID = Convert.ToInt32(rdr[0]);
                    temp.Login = rdr[1].ToString();
                    temp.Password = rdr[2].ToString();
                    temp.UserRoleName = rdr[3].ToString();
                    //словник об'єктів
                    Items.Add(temp.UserID, temp);
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
                string query = @"insert into tbUser
                            (Login,Password,UserRoleName)
                            values (@Login,@Password,@UserRoleName)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Login";
                param1.Value = this.Login;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Password";
                param2.Value = this.Password;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@UserRoleName";
                param3.Value = this.UserRoleName;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
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
                update tbUser
                set Login = @Login,
                    Password = @Password,
                    UserRoleName = @UserRoleName
                where UserID = @UserID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Login";
                param1.Value = this.Login;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Password";
                param2.Value = this.Password;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@UserRoleName";
                param3.Value = this.UserRoleName;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@UserID";
                param4.Value = this.UserID;
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
