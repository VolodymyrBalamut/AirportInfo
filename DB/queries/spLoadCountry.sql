CREATE PROCEDURE [dbo].[spLoadCoutry] 

AS
BEGIN
	create table #tempCountryLoad(
		CountryName nvarchar(200) null,
		Code nvarchar(200) null,
		CountryCode nvarchar(200) null,
		field1 nvarchar(200) null
	);
	BULK INSERT #tempCountryLoad
    FROM 'D:\Iт-52\5_semestr\ урсач\countries.dat.txt'
    WITH
    (
    FIELDTERMINATOR = ',' , --CSV field delimiter
    ROWTERMINATOR = '0x0a'   --Use to shift the control to next row
    )

	insert into tbCountry(CountryCode,CountryName) select CountryCode,CountryName from #tempCountryLoad where CountryCode <> '\N' and 
	  not exists (select * from tbCountry a where a.CountryCode=#tempCountryLoad.CountryCode and a.CountryName=#tempCountryLoad.CountryName)
END
GO
