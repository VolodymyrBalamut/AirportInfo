using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.model
{
    public class Country : Base<Country>
    {
        public string CountryCode;
        public string CountryName;

        public Country(string CountryCode, string CountryName)
        {
            this.CountryCode = CountryCode;
            this.CountryName = CountryName;
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
            try
            {
                conn.Open();
                string query = @"insert into tbCountry
                            (CountryCode,CountryName)
                            values (@CountryCode,@CountryName)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@CountryCode";
                param1.Value = this.CountryCode;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CountryName";
                param2.Value = this.CountryName;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
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

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public static void LoadCSV()
        {
            using (var reader = new StreamReader(@"D:\Iт-52\5_semestr\Курсач\countries.dat.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (!(values[2].ToString() == "\\N"))
                    {
                        Country temp = new Country(values[2].ToString(), values[0].ToString());
                        temp.Insert();
                    }
                   
                }
            }
        }
    }
}
