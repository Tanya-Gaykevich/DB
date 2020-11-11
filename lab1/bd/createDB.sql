begin tran
use TouristAgency;
GO

CREATE TABLE [Employees] (
  [Id] int IDENTITY(1,1) PRIMARY KEY,
  [Surname] varchar(50) not null,
  [Name] varchar(50) not null,
  [Patronymic] varchar(50) not null,
  [Birthday] date not null,
  [PositionId] int not null
)
GO

CREATE TABLE [Positions] (
  [Id] int IDENTITY(1,1) PRIMARY KEY,
  [Name] varchar(50) not null
)
GO

CREATE TABLE [Hotels] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Name] varchar(50) not null,
  [Country] varchar(50) not null,
  [Town] varchar(50) not null,
  [Address] varchar(50) not null,
  [Phone] int not null,
  [NumberOfStars] int not null,
  [ContactPerson] varchar(50) not null,
  [HotelPhoto] varchar(100) not null,     
  [RoomFoto] varchar(100) not null    
)

GO

CREATE TABLE [ServicesVouchers] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [ReservationMark] varchar(50) not null,
  [PaymentMark] varchar(50) not null,
  [VoucherId] int not null,
  [ServiceId] int not null
)
GO

CREATE TABLE [Clients] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Surname] varchar(50) not null,
  [Name] varchar(50) not null,
  [Patronymic] varchar(50) not null,
  [Birthday] date not null,
  [Gender] bit not null,
  [Address] varchar(50) not null,
  [Phone] int not null,
  [PassportData] varchar(50) not null 
)
GO

CREATE TABLE [TypesOfRest] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Name] varchar(50) not null,
  [Description] varchar(150) not null,
  [Limitation] varchar(100) not null
)
GO

CREATE TABLE [Services] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Name] varchar(50) not null,
  [Description] varchar(150) not null,
  [Cost] money not null
)
GO

CREATE TABLE [Vouchers] (
  [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Name] varchar(50) not null,
  [StartDate] date not null,
  [EndDate] date not null,
  [HotelId] int not null,
  [TypeOfRestId] int not null,
  [EmployeeId] int not null,
  [ClientId] int not null
)
GO

ALTER TABLE [ServicesVouchers] ADD FOREIGN KEY ([VoucherId]) REFERENCES [Vouchers] ([Id]) on delete cascade
GO

ALTER TABLE [ServicesVouchers] ADD FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) on delete cascade
GO

ALTER TABLE [Vouchers] ADD FOREIGN KEY ([HotelId]) REFERENCES [Hotels] ([Id]) on delete cascade
GO

ALTER TABLE [Vouchers] ADD FOREIGN KEY ([TypeOfRestId]) REFERENCES [TypesOfRest] ([Id]) on delete cascade
GO

ALTER TABLE [Vouchers] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) on delete cascade
GO

ALTER TABLE [Vouchers] ADD FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) on delete cascade
GO

commit tran
