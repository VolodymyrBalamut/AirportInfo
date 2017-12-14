using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AirportInfo.model
{
    public abstract class Base<T>
        where T : Base<T>
    {
       
        public abstract void Insert();
        public abstract void Get();
        public abstract void Update();
        public abstract void Delete();
        public override string ToString()
        {
            return "";
        }
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
    }
}
