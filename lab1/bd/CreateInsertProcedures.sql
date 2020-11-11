begin tran
use TouristAgency;
go

create procedure InsertPosition
     @Name varchar(50)
as 
    begin 
    insert into Positions(Name)
    values (@Name)
    end
go

create procedure InsertEmployee
    @Surname varchar(50),
    @Name varchar(50),
    @Patronymic varchar(50),
    @Birthday date,
    @PositionId int
as 
    begin 
    if  exists(select * from Positions where Id = @PositionId)
    insert into Employees(Surname,
    Name,
    Patronymic,
    Birthday,
    PositionId)
    values (@Surname,
    @Name,
    @Patronymic,
    @Birthday,
    @PositionId)
    end
go

create procedure InsertClient
    @Surname varchar(50),
    @Name varchar(50),
    @Patronymic varchar(50),
    @Birthday date,
    @Gender bit,
    @Address varchar(50),
    @Phone int,
    @PassportData varchar(50)
    as 
    begin 
        insert into Clients(Surname,
    Name,
    Patronymic,
    Birthday,
    Gender,
    Address,
    Phone,
    PassportData)
    values (@Surname,
    @Name,
    @Patronymic,
    @Birthday,
    @Gender,
    @Address,
    @Phone,
    @PassportData)
    end 
go

create procedure InsertTypeOfRest
    @Name varchar(50),
    @Description varchar(150),
    @Limitation varchar(100)
as 
    begin 
        insert into TypesOfRest(Name,
                                Description,
                                Limitation)
        values (@Name,
                @Description,
                @Limitation)
    end 
go

commit tran