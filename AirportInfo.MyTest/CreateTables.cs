using AirportData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfo.MyTest
{
    public class CreateTables
    {
        public static void createTables()
        {
            Plane.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
            try
            {
                // Open the connection
                Plane.conn.Open();

                // prepare command string
                string query = @"if not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = N'tbAirport')
begin 
	create table tbAirport(
	AirportCode char(3) PRIMARY KEY,
	AirportName nvarchar(100) not null,
	CountryCode char(2) not null,
	CityName nvarchar(50) not null,
)
create table tbCity(
	CountryCode char(2) not null,
	CityName nvarchar(50) not null,
	CONSTRAINT PK_CountryCity PRIMARY KEY (CountryCode,CityName)
);
create table tbCountry(
	CountryCode char(2) PRIMARY KEY,
	CountryName nvarchar(50) 
);
create table tbCompany(
	CompanyCode nvarchar(3) PRIMARY KEY,
	CompanyName nvarchar(70),
	CountryCode char(2) not null,
	Callsign nvarchar(50)
);
create table tbPlane(
	PlaneCode nvarchar(10) PRIMARY KEY,
	PlaneName nvarchar(50),
	Speed nvarchar(20),
	Distance nvarchar(20),
	Seats int
);
create table tbStatusFlight(
	StatusFlight nvarchar(20) PRIMARY KEY,
	Description nvarchar(50)
);
create table tbTerminal(
	TerminalCode nvarchar(3) PRIMARY KEY
);
create table tbActualFlight(
	ActualFlightID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FlightCode nvarchar(5) not null,
	ActualFlightDate date not null,
	PlaneCode nvarchar(10) not null,
	StatusFlight nvarchar(20) not null,
	TerminalCode nvarchar(3) not null,
	TimeDifference int not null default 0
);
create table tbActualFlightHistory(
	ActualFlightHistoryID int IDENTITY(1,1) PRIMARY KEY,
	OldStatus nvarchar(20) not null,
	NewStatus nvarchar(20) not null,
	DateChange datetime not null,
	ActualFlightID int not null
);
create table tbFlight(
	FlightCode nvarchar(5) PRIMARY KEY,
	DepartTime nvarchar(5) not null,
	ArriveTime nvarchar(5) not null,
	DepartAirportCode char(3) not null,
	ArriveAirportCode char(3) not null,
	CompanyCode nvarchar(3) not null,
	PlaneCode nvarchar(10) not null,
	WeekDay nvarchar(7) not null
);
create table tbUser(
	UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Login] nvarchar(50) NOT NULL UNIQUE,
	[Password] nvarchar(20) NOT NULL,
	UserRoleName nvarchar(10) not null
);
create table tbUserRole(
	UserRoleName nvarchar(10) PRIMARY KEY,
	UserRoleDesc nvarchar(100)
);
create table tbConfig(
	Param nvarchar(50) PRIMARY KEY,
	Val nvarchar(50)
);
end";
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query, Plane.conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (Plane.conn != null)
                {
                    Plane.conn.Close();
                }
            }
        }
    }
}
