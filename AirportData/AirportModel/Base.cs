using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AirportData
{
    public abstract class Base<T,V>
        where T : Base<T,V>
    {
        public abstract bool Insert();
        public abstract bool GetAll();
        public abstract bool Update();
        public abstract bool Delete();
        public static Dictionary<V, T> Items = new Dictionary<V, T>();
        public override string ToString() { return ""; }
        public static readonly SqlConnection conn = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=dbAirportInfo;Integrated Security=True");
  
    }
}
