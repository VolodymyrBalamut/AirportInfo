drop table tbAirportLoad;
create table tbAirportLoad(
	AirportCode nvarchar(200) null,
	AirportName nvarchar(200) null,
	CityName nvarchar(200) null,
	CountryName nvarchar(200) null
);
select count(*) from tbAirportLoad;