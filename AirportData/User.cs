using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData
{
    public class User : Base<User>
    {
        public int UserID;
        public string Login;
        public string Password;
        public string UserRoleName;

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
    }
}
