CREATE PROCEDURE [dbo].[spLoadDepartFlights]
AS
	create table #tempDepartFlightsLoad(
		CityName nvarchar(200) null,
		AirportCode nvarchar(200) null,
		CompanyName nvarchar(200) null,
		CompanyCode nvarchar(200) null,
		FlightCode nvarchar(200) null,
		FlightTime nvarchar(200) null,
		Weekdays nvarchar(200) null,
		field nvarchar(200) null
	);
	BULK INSERT #tempDepartFlightsLoad
    FROM 'D:\Iт-52\5_semestr\Курсач\flight-departures.dat'
    WITH
    (
    FIELDTERMINATOR = ',' , --CSV field delimiter
    ROWTERMINATOR = '0x0a'   --Use to shift the control to next row
    )

	create table #tempFlight(
		FlightCode nvarchar(5) null,
		DepartTime nvarchar(5) null,
		ArriveTime nvarchar(5) null,
		DepartAirportCode char(3) null,
		ArriveAirportCode char(3) null,
		CompanyCode nvarchar(3) null,
		PlaneCode nvarchar(10) null,
		WeekDay nvarchar(7) null
	);
	
	insert into #tempFlight(FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay) 
		select LTRIM(RTRIM(FlightCode)),MAX(LTRIM(RTRIM(FlightTime))),'<>','KBP',MAX(LTRIM(RTRIM(AirportCode))),MAX(LTRIM(RTRIM(CompanyCode))),'<>',
		MAX(LTRIM(RTRIM(Weekdays))) from #tempDepartFlightsLoad group by FlightCode 

	update  #tempFlight set ArriveTime='0:00'
	update  #tempFlight set PlaneCode=tbPlane.PlaneCode from tbPlane

	insert into tbFlight(FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay) 
		select FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay
		from #tempFlight where not exists (select * from tbFlight a where a.FlightCode=#tempFlight.FlightCode)
RETURN 0