CREATE PROCEDURE [dbo].[spLoadActualFlight]
	@date date
AS
	/*starting from monday*/
		set datefirst 1
		
		insert into tbActualFlight(FlightCode,ActualFlightDate,PlaneCode,StatusFlight,TerminalCode,TimeDifference)
		select FlightCode,@date,PlaneCode,'waiting','D',0 from tbFlight
			where DepartAirportCode='KBP' and (CHARINDEX(CONVERT(nvarchar(1),DATEPART(dw,getdate())),WeekDay) <> 0)

		insert into tbActualFlight(FlightCode,ActualFlightDate,PlaneCode,StatusFlight,TerminalCode,TimeDifference)
		select FlightCode,@date,PlaneCode,'waiting','D',0 from tbFlight
			where ArriveAirportCode='KBP' and (CHARINDEX(CONVERT(nvarchar(1),DATEPART(dw,getdate())),WeekDay) <> 0)


