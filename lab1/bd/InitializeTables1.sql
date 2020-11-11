use TouristAgency
go 

declare @ReferenceRecordCount int = 500,
    @OperationRecordCount int = 20000

declare @Symbol char(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
    	@Digit char(10) = '0123456789',
	    @Position int,
		@i int,
		@NameLimit int,
		@RowCount int,
		@MinNumberSymbols int = 5,
		@MaxNumberSymbols int = 50


declare @TypesOfRestCount int = @ReferenceRecordCount
declare @HotelsCount int = @ReferenceRecordCount
declare @ServicesCount int = @ReferenceRecordCount
declare @ServicesVouchersCount int = @OperationRecordCount
declare @VouchersCount int = @OperationRecordCount

declare @EmployeesCount int = @OperationRecordCount
declare @ClientsCount int = @ReferenceRecordCount


begin tran

--ÐÐ°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ðµ ÑÐ°Ð±Ð»Ð¸ÑÑ ÐÐ¸Ð´Ñ Ð¾ÑÐ´ÑÑÐ°
declare @Name varchar(50),
        @Description varchar(150),
        @Limitation varchar(100)
set @RowCount = 1
    while @RowCount <= @TypesOfRestCount
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- Ð´Ð»Ð¸Ð½Ð° ÑÑÑÐ¾ÐºÐ¸ Ð¾Ñ 5 Ð´Ð¾ 50
        set @Name = ''
        set @Description = ''
        set @Limitation = ''
        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Description = @Description + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
            set @Limitation = @Limitation + substring(@Symbol, @Position, 1)
            set @i = @i + 1
        end
    exec InsertTypeOfRest @Name,
                          @Description,
                          @Limitation 
    set @RowCount += 1
end 

--ÐÐ°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ðµ ÑÐ°Ð±Ð»Ð¸ÑÑ ÐÑÐµÐ»Ð¸
declare @Country varchar(50),
        @Town varchar(50),
        @Address varchar(50),
        @Phone int,
        @NumberOfStars int,
        @ContactPerson varchar(50),
        @HotelPhoto varchar(100),     
        @RoomFoto varchar(100)        
set @RowCount = 1
    while @RowCount <= @HotelsCount
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- Ð´Ð»Ð¸Ð½Ð° ÑÑÑÐ¾ÐºÐ¸ Ð¾Ñ 5 Ð´Ð¾ 50
        set @Name = ''
        set @Country = ''
        set @Town = ''
        set @Address = ''
        set @Phone = rand() * 7 
        set @NumberOfStars = rand() * 5
        set @ContactPerson = ''
        set @HotelPhoto = ''
        set @RoomFoto = ''
        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Country = @Country + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Town = @Town + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Address = @Address + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @ContactPerson = @ContactPerson + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @HotelPhoto = @HotelPhoto + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @RoomFoto = @RoomFoto + substring(@Symbol, @Position, 1)
            set @i = @i + 1
        end
    exec InsertHotel @Name,
                     @Country,
                     @Town,
                     @Address,
                     @Phone,
                     @NumberOfStars,
                     @ContactPerson,
                     @HotelPhoto,   
                     @RoomFoto                   
    set @RowCount += 1
end

--ÐÐ°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ðµ ÑÐ°Ð±Ð»Ð¸ÑÑ ÐÐ¾Ð¿Ð¾Ð»Ð½Ð¸ÑÐµÐ»ÑÐ½ÑÐµ ÑÑÐ»ÑÐ³Ð¸
declare @Cost money
set @RowCount = 1
    while @RowCount < @ServicesCount
    begin
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- Ð´Ð»Ð¸Ð½Ð° ÑÑÑÐ¾ÐºÐ¸ Ð¾Ñ 5 Ð´Ð¾ 50
        set @Name = ''
        set @Description = ''
        set @Cost = rand()*(1000-500) + 500
        set @i = 1
        while @i < @NameLimit
         begin 
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
            set @Description = @Description + substring(@Symbol, @Position, 1)
            set @i = @i + 1
        end
    exec InsertService @Name,
                       @Description,
                       @Cost
    set @RowCount += 1
end

--ÐÐ°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ðµ ÑÐ°Ð±Ð»Ð¸ÑÑ Ð£ÑÐ»ÑÐ³Ð¸/ÐÑÑÑÐ²ÐºÐ¸
declare @ReservationMark varchar(50),
        @PaymentMark varchar(50),
        @VoucherId int,
        @ServiceId int
set @RowCount = 1
    while @RowCount < @ServicesVouchersCount 
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- Ð´Ð»Ð¸Ð½Ð° ÑÑÑÐ¾ÐºÐ¸ Ð¾Ñ 5 Ð´Ð¾ 50
        set @ReservationMark = '' 
        set @PaymentMark = ''
        set @VoucherId = rand() * @VouchersCount
        set @ServiceId = rand() * @ServicesCount
        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @ReservationMark = @ReservationMark + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
            set @PaymentMark = @PaymentMark + substring(@Symbol, @Position, 1)
            set @i = @i + 1
        end
    exec InsertServiceVoucher @ReservationMark,
                              @PaymentMark,
                              @VoucherId,
                              @ServiceId
    set @RowCount += 1
end

--ÐÐ°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ðµ ÑÐ°Ð±Ð»Ð¸ÑÑ ÐÑÑÑÐ²ÐºÐ¸
declare @StartDate date,
        @EndDate date,
        @HotelId int,
        @TypeOfRestId int,
        @EmployeeId int,
        @ClientId int
set @RowCount = 1
while @RowCount < @VouchersCount 
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- Ð´Ð»Ð¸Ð½Ð° ÑÑÑÐ¾ÐºÐ¸ Ð¾Ñ 5 Ð´Ð¾ 50
        set @Name = ''
        set @StartDate = dateadd(day,-8000 - RAND()*10000,GETDATE()) 
        set @EndDate = dateadd(day,-8000 - RAND()*10000,GETDATE())
        set @HotelId = rand() * @HotelsCount
        set @TypeOfRestId = rand() * @TypesOfRestCount
        set @EmployeeId = rand() * @EmployeesCount
        set @ClientId = rand() * @ClientsCount

        set @i = 1
        while @i < @NameLimit
        begin
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @i = @i + 1
        end 
    exec InsertVoucher  @Name,
                        @StartDate,
                        @EndDate,
                        @HotelId,
                        @TypeOfRestId,
                        @EmployeeId,
                        @ClientId
    set @RowCount += 1
end
commit tran