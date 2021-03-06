﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.SQLite;

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
        public static SqlConnection conn = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=dbAirportInfo;Integrated Security=True");
        //public static SQLiteConnection conn = new SQLiteConnection("Data Source=dbAirportInfoLite;Version=3;");
        public static readonly Regex regStr = new Regex("^[a-zA-Z0-9 ]*$");
        public static readonly Regex regNum = new Regex(@"^-?[0-9]{1,}\.?[0-9]{0,}$");
    }
}
