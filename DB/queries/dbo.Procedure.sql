CREATE PROCEDURE [dbo].[spLoadAirport]
	@param1 int = 0,
	@param2 int =0
AS
	SELECT @param1, @param2
	create table #tempAirportLoad(
		Code nvarchar(200) null,
		AirportName nvarchar(200) null,
		CityName nvarchar(200) null,
		CountryName nvarchar(200) null,
		AirportCode nvarchar(200) null,
		AirportCode2 nvarchar(200) null,
		CoordX nvarchar(200) null,
		CoordY nvarchar(200) null,
		field1 nvarchar(200) null,
		field2 nvarchar(200) null,
		field3 nvarchar(200) null,
		field4 nvarchar(200) null,
		field5 nvarchar(200) null,
		field6 nvarchar(200) null,
	);
	BULK INSERT #tempAirportLoad
    FROM 'D:\Iт-52\5_semestr\Курсач\airports.dat.txt'
    WITH
    (
    FIELDTERMINATOR = ',' , --CSV field delimiter
    ROWTERMINATOR = '0x0a'   --Use to shift the control to next row
    )
	create table #tempCity(
		CityName nvarchar(200) null,
		CountryCode nvarchar(10) null,
		CountryName nvarchar(200) null);

	insert into #tempCity(CityName,CountryCode,CountryName) select distinct REPLACE(CityName,'"',''), '<>', REPLACE(CountryName,'"','') from #tempAirportLoad;

	update  #tempCity set CountryCode=tbCountry.CountryCode from tbCountry where tbCountry.CountryName = #tempCity.CountryName;

	insert into tbCity(CityName,CountryCode) select CityName,CountryCode from #tempCity where CountryCode <> '<>' and 
	  not exists (select * from tbCity a where a.CityName=#tempCity.CityName and a.CountryCode=#tempCity.CountryCode);

	create table #tempAirport(
		AirportCode nvarchar(200) null,
		AirportName nvarchar(200) null,
		CountryCode nvarchar(200) null,
		CityName nvarchar(200) null,
		CountryName nvarchar(200));

	insert into #tempAirport(AirportCode,AirportName,CountryCode,CityName,CountryName) 
		select REPLACE(AirportCode,'"',''), REPLACE(AirportName,'"',''),  '<>',
		REPLACE(CityName,'"',''), REPLACE(CountryName,'"','') from #tempAirportLoad;

	update  #tempAirport set CountryCode=tbCountry.CountryCode from tbCountry where tbCountry.CountryName = #tempAirport.CountryName;

	insert into tbAirport(AirportCode,AirportName,CountryCode,CityName) select AirportCode,AirportName,CountryCode,CityName 
		from #tempAirport where CountryCode <> '<>' and AirportCode <> '\N' and AirportCode<> '' and 
		not exists (select * from tbAirport a where a.AirportCode=#tempAirport.AirportCode);
RETURN 0