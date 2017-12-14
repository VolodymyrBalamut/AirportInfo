ALTER PROCEDURE [dbo].[spLoadPlane] 
AS
BEGIN
	create table #tempPlaneLoad(
		PlaneCode nvarchar(200) null,
		PlaneName nvarchar(200) null,
		Speed nvarchar(200) null,
		Distance nvarchar(200) null,
		Seats int null
	);
	BULK INSERT #tempPlaneLoad
    FROM 'D:\Iт-52\5_semestr\ урсач\planes.dat.txt'
    WITH
    (
    FIELDTERMINATOR = ',' , --CSV field delimiter
    ROWTERMINATOR = '0x0a'   --Use to shift the control to next row
    )

	insert into tbPlane(PlaneCode,PlaneName,Speed,Distance,Seats) select PlaneCode,PlaneName,Speed,Distance,Seats from #tempPlaneLoad 
		where not exists (select * from tbPlane a where a.PlaneCode=#tempPlaneLoad.PlaneCode)
END
GO
