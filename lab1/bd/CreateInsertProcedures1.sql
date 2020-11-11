begin tran
use TouristAgency;
go


create procedure InsertTypeOfRest
    @Name varchar(50),
    @Description varchar(150),     
    @Limitation varchar(100)
as 
    begin 
    insert into TypesOfRest(Name, Description, Limitation)
    values (@Name,
            @Description,
            @Limitation)
    end
go


create procedure InsertHotel
    @Name varchar(50),
    @Country varchar(50),
    @Town varchar(50),
    @Address varchar(50),       
    @Phone int,
    @NumberOfStars int,
    @ContactPerson varchar(50),
    @HotelPhoto varbinary(max),     
    @RoomFoto varbinary(max)    
as 
    begin
    insert into Hotels(Name, Country, Town, Address, Phone, 
                        NumberOfStars, ContactPerson, HotelPhoto,
                        RoomFoto)
    values(@Name,
    @Country,
    @Town,
    @Address,       
    @Phone,
    @NumberOfStars,
    @ContactPerson,
    @HotelPhoto,     
    @RoomFoto)  
    end
go


create procedure InsertServiceVoucher
    @ReservationMark varchar(50),
    @PaymentMark varchar(50),
    @VoucherId int,
    @ServiceId int
as
    begin
    if exists(select * from Services where Id = @ServiceId)
    if exists(select * from Vouchers where Id = @VoucherId)
    insert into ServicesVouchers (ReservationMark, 
    PaymentMark,
    VoucherId,
    ServiceId)
    values (@ReservationMark, 
    @PaymentMark,
    @VoucherId,
    @ServiceId)
    end
go
    

create procedure InsertVoucher
    @Name varchar(50),
    @StartDate date,
    @EndDate date,
    @HotelId int,
    @TypeOfRestId int,
    @EmployeeId int,
    @ClientId int
as
    begin
    if exists(select * from Hotels where Id = @HotelId)
    if exists(select * from TypesOfRest where Id = @TypeOfRestId)
    if exists(select * from Employees where Id = @EmployeeId)
    if exists(select * from Clients where Id = @ClientId)
    insert into Vouchers (Name,
    StartDate,
    EndDate,
    HotelId,
    TypeOfRestId,
    EmployeeId,
    ClientId)
    values (@Name,
    @StartDate,
    @EndDate,
    @HotelId,
    @TypeOfRestId,
    @EmployeeId,
    @ClientId)
    end
go

create procedure InsertService
    @Name varchar(50),
    @Description varchar(150),
    @Cost money 
as 
    begin
    insert into Services
    (Name,
    Description,
    Cost)
    values 
    (@Name,
     @Description,
     @Cost)
    end
go

commit tran