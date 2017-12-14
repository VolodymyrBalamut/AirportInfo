drop table #tempDepartFlightsLoad
drop table #tempFlight
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
	select * from #tempDepartFlightsLoad where len(LTRIM(RTRIM(Weekdays)))=38
	select Weekdays,len(LTRIM(RTRIM(Weekdays))) from #tempDepartFlightsLoad order by len(LTRIM(RTRIM(Weekdays))) desc

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
	select * from #tempFlight
	update  #tempFlight set ArriveTime='00:00'
	update  #tempFlight set PlaneCode=tbPlane.PlaneCode from tbPlane

	insert into tbFlight(FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay) 
		select FlightCode,DepartTime,ArriveTime,DepartAirportCode,ArriveAirportCode,CompanyCode,PlaneCode,WeekDay
		from #tempFlight where not exists (select * from tbFlight a where a.FlightCode=#tempFlight.FlightCode)

	select  FlightCode,CompanyCode,count(*) from #tempFlight
	group by FlightCode,CompanyCode
	order by count(*) desc

	select * from #tempFlight
	where CompanyCode not in (select CompanyCode from tbCompany)

	select * from tbAirport where CityName='Doha'

	select * from tbFlight
	drop table tbActualFlight
        /*starting from monday*/
		set datefirst 1;
		select DATEPART(dw,getdate()) as weekday
		
		insert into tbActualFlight(FlightCode,ActualFlightDate,PlaneCode,StatusFlight,TerminalCode,TimeDifference)
		select FlightCode,GETDATE(),PlaneCode,'waiting','D',0 from tbFlight
			where DepartAirportCode='KBP' and (CHARINDEX(CONVERT(nvarchar(1),DATEPART(dw,getdate())),WeekDay) <> 0)

		insert into tbActualFlight(FlightCode,ActualFlightDate,PlaneCode,StatusFlight,TerminalCode,TimeDifference)
		select FlightCode,GETDATE(),PlaneCode,'waiting','D',0 from tbFlight
			where ArriveAirportCode='KBP' and (CHARINDEX(CONVERT(nvarchar(1),DATEPART(dw,getdate())),WeekDay) <> 0)
		

		select * from tbActualFlight
		DECLARE @param int
		select @param =  DATEPART(dw,getdate())
		select CHARINDEX(CONVERT(nvarchar(1),@param),'1234567')
		
		exec spLoadActualFlight '2017-12-12'
