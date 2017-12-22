CREATE PROCEDURE [dbo].[spUpdateStatus]
AS
	declare @datetime datetime
	select @datetime = getdate()
	declare @date date
	select @date = getdate()
	declare @airportcode char(3)
	select @airportcode = Val from tbConfig where [Param]='AirportCode'
	

	/*status arrived for previos day*/
	update tbActualFlight set StatusFlight = 'arrived' 
	where ActualFlightDate < @date

	/*status new*/
	update tbActualFlight set StatusFlight = 'new' 
	where ActualFlightDate > @date
	
	/*today*/
	select *, 
	SUBSTRING(DepartTime,1,CHARINDEX(':',DepartTime)-1) as DepartHour,
	SUBSTRING(DepartTime,CHARINDEX(':',DepartTime)+1,2) as DepartMinutes,
	SUBSTRING(ArriveTime,1,CHARINDEX(':',ArriveTime)-1) as ArriveHour,
	SUBSTRING(ArriveTime,CHARINDEX(':',ArriveTime)+1,2) as ArriveMinutes,
	DepartDataTime=getdate(), 
	ArriveDateTime=getdate() into #tempFlight from tbFlight

	update #tempFlight set DepartDataTime = DATEADD(hh,Convert(int,DepartHour),DATEADD(mi,Convert(int,DepartMinutes),DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0))),
	ArriveDateTime = DATEADD(hh,Convert(int,ArriveHour),DATEADD(mi,Convert(int,ArriveMinutes),DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)))
	
	/*status departure waiting*/
	update tbActualFlight set StatusFlight = 'waiting'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)>120

	/*status departure checkin*/
	update tbActualFlight set StatusFlight = 'checkin'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)<=120 and
	DATEDIFF(minute,getdate(),DepartDataTime)>30

	/*status departure boarding*/
	update tbActualFlight set StatusFlight = 'boarding'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)<=30 and
	DATEDIFF(minute,getdate(),DepartDataTime)>0

	/*status departure depart*/
	update tbActualFlight set StatusFlight = 'depart'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)<=0 and
	DATEDIFF(minute,getdate(),DepartDataTime)>-10

	/*status departure flying*/
	update tbActualFlight set StatusFlight = 'flying'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)<=-10 and
	DATEDIFF(minute,getdate(),DepartDataTime)>-120

	/*status departure arrived*/
	update tbActualFlight set StatusFlight = 'arrived'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and DepartAirportCode = @airportcode and DATEDIFF(minute,getdate(),DepartDataTime)<=-120

	/*status arrive waiting*/
	update tbActualFlight set StatusFlight = 'waiting'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and ArriveAirportCode = @airportcode and DATEDIFF(minute,getdate(),ArriveDateTime)>120

	/*status arrive flying*/
	update tbActualFlight set StatusFlight = 'flying'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and ArriveAirportCode = @airportcode and DATEDIFF(minute,getdate(),ArriveDateTime)<=120 and
	DATEDIFF(minute,getdate(),ArriveDateTime)>0

	/*status arrive arrived*/
	update tbActualFlight set StatusFlight = 'arrived'
	from  tbActualFlight
	inner join #tempFlight on tbActualFlight.FlightCode = #tempFlight.FlightCode
	where ActualFlightDate = @date and ArriveAirportCode = @airportcode and DATEDIFF(minute,getdate(),ArriveDateTime)<=0