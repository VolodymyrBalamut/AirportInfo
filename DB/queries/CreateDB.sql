ALTER TABLE tbFlight DROP CONSTRAINT FK_FlightDepartAirport;
ALTER TABLE tbFlight DROP CONSTRAINT FK_FlightPlane;
ALTER TABLE tbFlight DROP CONSTRAINT FK_FlightArriveAirport;
ALTER TABLE tbFlight DROP CONSTRAINT FK_FlightCompany;
ALTER TABLE tbTerminal DROP CONSTRAINT FK_TerminalAirport;
ALTER TABLE tbAirport DROP CONSTRAINT FK_AirportCity;
ALTER TABLE tbCity DROP CONSTRAINT FK_CityCountry;
ALTER TABLE tbCompany DROP CONSTRAINT FK_CompanyCountry;
ALTER TABLE tbActualFlight DROP CONSTRAINT FK_ActualFlightFlight;
ALTER TABLE tbActualFlight DROP CONSTRAINT FK_ActualFlightPlane;
ALTER TABLE tbActualFlight DROP CONSTRAINT FK_ActualFlightStatusFlight;
ALTER TABLE tbUser DROP CONSTRAINT FK_UserRole;
ALTER TABLE tbActualFlightHistory DROP CONSTRAINT FK_ActualFlightHistory
ALTER TABLE tbActualFlightHistory DROP CONSTRAINT FK_ActualFlightHistoryOldStatus
ALTER TABLE tbActualFlightHistory DROP CONSTRAINT FK_ActualFlightHistoryNewStatus
drop table tbFlight;
drop table tbActualFlight;
drop table tbActualFlightHistory;
drop table tbAirport;
drop table tbCity;
drop table tbCountry;
drop table tbTerminal;
drop table tbStatusFlight;
drop table tbPlane;
drop table tbCompany;
drop table tbUser;
drop table tbUserRole;
drop table tbConfig;

create table tbAirport(
	AirportCode char(3) PRIMARY KEY,
	AirportName nvarchar(100) not null,
	CountryCode char(2) not null,
	CityName nvarchar(50) not null,
);
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
ALTER TABLE tbFlight
ADD CONSTRAINT FK_FlightDepartAirport
FOREIGN KEY (DepartAirportCode) 
REFERENCES tbAirport(AirportCode);
ALTER TABLE tbFlight
ADD CONSTRAINT FK_FlightArriveAirport
FOREIGN KEY (ArriveAirportCode) 
REFERENCES tbAirport(AirportCode);
ALTER TABLE tbFlight
ADD CONSTRAINT FK_FlightCompany
FOREIGN KEY (CompanyCode) REFERENCES tbCompany(CompanyCode);
ALTER TABLE tbFlight
ADD CONSTRAINT FK_FlightPlane
FOREIGN KEY (PlaneCode) REFERENCES tbPlane(PlaneCode);
ALTER TABLE tbAirport
ADD CONSTRAINT FK_AirportCity
FOREIGN KEY (CountryCode,CityName) REFERENCES tbCity(CountryCode,CityName);
ALTER TABLE tbCity
ADD CONSTRAINT FK_CityCountry
FOREIGN KEY (CountryCode) REFERENCES tbCountry(CountryCode);
ALTER TABLE tbCompany
ADD CONSTRAINT FK_CompanyCountry
FOREIGN KEY (CountryCode) REFERENCES tbCountry(CountryCode);
ALTER TABLE tbActualFlight
ADD CONSTRAINT FK_ActualFlightFlight
FOREIGN KEY (FlightCode) REFERENCES tbFlight(FlightCode);
ALTER TABLE tbActualFlight
ADD CONSTRAINT FK_ActualFlightPlane
FOREIGN KEY (PlaneCode) REFERENCES tbPlane(PlaneCode);
ALTER TABLE tbActualFlight
ADD CONSTRAINT FK_ActualFlightTerminal
FOREIGN KEY (TerminalCode) REFERENCES tbTerminal(TerminalCode);
ALTER TABLE tbActualFlight
ADD CONSTRAINT FK_ActualFlightStatusFlight
FOREIGN KEY (StatusFlight) REFERENCES tbStatusFlight(StatusFlight);
ALTER TABLE tbUser
ADD CONSTRAINT FK_UserRole
FOREIGN KEY (UserRoleName) REFERENCES tbUserRole(UserRoleName);
ALTER TABLE tbActualFlightHistory
ADD CONSTRAINT FK_ActualFlightHistory
FOREIGN KEY (ActualFlightID) REFERENCES tbActualFlight(ActualFlightID);
ALTER TABLE tbActualFlightHistory
ADD CONSTRAINT FK_ActualFlightHistoryOldStatus
FOREIGN KEY (OldStatus) REFERENCES tbStatusFlight(StatusFlight);
ALTER TABLE tbActualFlightHistory
ADD CONSTRAINT FK_ActualFlightHistoryNewStatus
FOREIGN KEY (NewStatus) REFERENCES tbStatusFlight(StatusFlight);

insert into tbUserRole(UserRoleName,UserRoleDesc) values('admin','Адміністратор')
insert into tbUserRole(UserRoleName,UserRoleDesc) values('operator','Оператор')
insert into tbUserRole(UserRoleName,UserRoleDesc) values('user','Користувач')

insert into tbUser(Login,Password,UserRoleName) values('admin','1111','admin')
insert into tbUser(Login,Password,UserRoleName) values('operator','1111','operator')
insert into tbUser(Login,Password,UserRoleName) values('user','1111','user')

insert into tbStatusFlight(StatusFlight,Description) values('waiting','Очікуання')
insert into tbStatusFlight(StatusFlight,Description) values('checkin','Реєстрація')
insert into tbStatusFlight(StatusFlight,Description) values('boarding','Посадка')
insert into tbStatusFlight(StatusFlight,Description) values('depart','Виліт')
insert into tbStatusFlight(StatusFlight,Description) values('flying','Політ')
insert into tbStatusFlight(StatusFlight,Description) values('arrived','Прибув')

insert into tbConfig(Param,Val) values('AirportCode','KBP')
insert into tbTerminal(TerminalCode) values('A')
insert into tbTerminal(TerminalCode) values('B')
insert into tbTerminal(TerminalCode) values('C')
insert into tbTerminal(TerminalCode) values('D')

create TRIGGER trgActualFlightInsert ON  [tbActualFlight]
FOR insert
AS  
begin
	insert into [tbActualFlightHistory]
		(OldStatus,NewStatus,DateChange,ActualFlightID) 
	SELECT 
		i.StatusFlight, i.StatusFlight, GetDate(),i.ActualFlightID
	FROM 
		inserted i	
end

create TRIGGER trgActualFlightUpdate ON  [tbActualFlight]
FOR UPDATE
AS  
begin
	if update(StatusFlight)
	begin
		insert into [tbActualFlightHistory]
			(OldStatus,NewStatus,DateChange,ActualFlightID) 
		SELECT 
			d.StatusFlight, i.StatusFlight, GetDate(),i.ActualFlightID
		FROM 
			inserted i
			inner join deleted d on i.ActualFlightID = d.ActualFlightID
	end
end