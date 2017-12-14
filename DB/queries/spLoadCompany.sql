USE [dbAirportInfo]
GO

/****** Object:  StoredProcedure [dbo].[spLoadCompany]    Script Date: 06.12.2017 15:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spLoadCompany]
AS
BEGIN
	create table #tempCompanyLoad(
		Code nvarchar(200) null,
		CompanyName nvarchar(200) null,
		Alias nvarchar(200) null,
		CodeIATA nvarchar(200) null,
		CodeICAO nvarchar(200) null,
		Callsign nvarchar(200) null,
		CountryName nvarchar(200) null,
		Active nvarchar(200) null
	);
	BULK INSERT #tempCompanyLoad
    FROM 'D:\Iт-52\5_semestr\ урсач\airlines.dat.txt'
    WITH
    (
    FIELDTERMINATOR = ',' , --CSV field delimiter
    ROWTERMINATOR = '0x0a'   --Use to shift the control to next row
    )

	create table #tempCompany(
			CompanyCode nvarchar(200),
			CompanyName nvarchar(200),
			CountryCode nvarchar(200),
			Callsign nvarchar(200),
			CountryName nvarchar(200));

	
	insert into #tempCompany(CompanyCode,CompanyName,CountryCode,Callsign,CountryName) 
		select REPLACE(CodeIATA,'"',''), REPLACE(CompanyName,'"',''),  '<>',
		REPLACE(Callsign,'"',''), REPLACE(CountryName,'"','') from #tempCompanyLoad where CodeIATA <> '""';

	update  #tempCompany set CountryCode=tbCountry.CountryCode from tbCountry where tbCountry.CountryName = #tempCompany.CountryName;

	insert into tbCompany(CompanyCode,CompanyName,CountryCode,Callsign) 
		select CompanyCode,CompanyName=max(CompanyName),CountryCode=max(CountryCode),Callsign=max(Callsign)
		from #tempCompany where CountryCode <> '<>' and len(CompanyCode)=2 and CompanyCode not in('::','^^',';;','??','++','-+','..','-.','&T','--') and
		not exists (select * from tbCompany a where a.CompanyCode=#tempCompany.CompanyCode)
		group by CompanyCode
END

GO


