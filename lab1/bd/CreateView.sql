create view GetFormattedEmployees
	as 
	select Employees.*, Positions.Name as Position
	   from Employees join Positions on
			Employees.PositionId = Positions.Id