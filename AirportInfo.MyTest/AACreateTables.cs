using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    [Order(1)]
    public class AACreateTables
    {
        public AACreateTables()
        {
            Plane.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
            //Plane.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
        }

        [Fact]
        public void createTables()
        {
            bool flag = false;
            try
            {
                // Open the connection
                Plane.conn.Open();

                // prepare command string
                string query = @"create table tbTerminal(
	                                TerminalCode nvarchar(3) PRIMARY KEY)
                                create table tbCountry(
	                                    CountryCode char(2) PRIMARY KEY,
	                                    CountryName nvarchar(50) 
                                    )
                                create table tbPlane(
	                                    PlaneCode nvarchar(10) PRIMARY KEY,
	                                    PlaneName nvarchar(50),
	                                    Speed nvarchar(20),
	                                    Distance nvarchar(20),
	                                    Seats int
                                    )
                                create table tbAirport(
	                                    AirportCode char(3) PRIMARY KEY,
	                                    AirportName nvarchar(100) not null,
	                                    CountryCode char(2) not null,
	                                    CityName nvarchar(50) not null,
                                    )";
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query, Plane.conn);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            finally
            {
                // Close the connection
                if (Plane.conn != null)
                {
                    Plane.conn.Close();
                }
            }
            Assert.True(flag);
        }
    }
}
