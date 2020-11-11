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

declare @PositionsCount int = @ReferenceRecordCount
declare @EmployeesCount int = @OperationRecordCount
declare @ClientsCount int = @ReferenceRecordCount

begin tran
-- Заполнение таблицы Должности 
declare @Name varchar(50)
set @RowCount = 1
	while @RowCount <= @PositionsCount
	begin
		set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- длина строки от 5 до 50
        set @Name = ''
        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
			set @i = @i + 1
        end
        exec InsertPosition @Name
		set @RowCount += 1
	end

--Заполнение таблицы Сотрудники
declare @Surname varchar(50),
        @Patronymic varchar(50),
        @Birthday date,
        @PositionId int
set @RowCount = 1
    while @RowCount <= @EmployeesCount
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- длина строки от 5 до 50
        set @Surname  = ''
        set @Name = ''
        set @Patronymic = ''
        set @PositionId = rand() * @PositionsCount
        set @Birthday = dateadd(day,-8000 - RAND()*10000,GETDATE()) 
        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @Surname = @Surname + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
            set @Patronymic = @Patronymic + substring(@Symbol, @Position, 1)
			set @i = @i + 1
        end
    exec InsertEmployee @Surname,
                        @Name,
                        @Patronymic,
                        @Birthday,
                        @PositionId
    set @RowCount += 1
end

--Заполнение таблицы Клиенты
declare @Gender bit, 
        @Address varchar(50),
        @Phone int,
        @PassportData varchar(50) 
set @RowCount = 1
    while @RowCount <= @ClientsCount
    begin 
        set @NameLimit=@MinNumberSymbols + rand() * (@MaxNumberSymbols-@MinNumberSymbols) -- длина строки от 5 до 50
        set @Surname  = ''
        set @Name = ''
        set @Patronymic = ''
        set @Birthday = dateadd(day,-5000-RAND()*10000,GETDATE()) 
        set @Gender = cast(round(rand(), 0) as bit)
        set @Address = ''
        set @Phone = rand() * 7 
        set @PassportData = ''

        set @i = 1
        while @i < @NameLimit
        begin 
            set @Position = rand() * 52
			set @Surname = @Surname + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
			set @Name = @Name + substring(@Symbol, @Position, 1)
            set @Position = rand() * 52
            set @Patronymic = @Patronymic + substring(@Symbol, @Position, 1)        
            set @Position = rand() * 52
			set @Address = @Address + substring(@Symbol, @Position, 1)
			set @Position = rand() * 52
			set @PassportData = @PassportData + substring(@Symbol, @Position, 1)
			set @i = @i + 1
        end
    exec InsertClient @Surname,
                      @Name,
                      @Patronymic,
                      @Birthday,
                      @Gender, 
                      @Address,
                      @Phone,
                      @PassportData
    set @RowCount += 1
end 


commit tran