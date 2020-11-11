using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Data
{
    public class DbInitializer
    {
        int _refferenceTableSize;
        int _operationalTableSize;
        public DbInitializer(int refferenceTableSize, int operationalTableSize)
        {
            _refferenceTableSize = refferenceTableSize;
            _operationalTableSize = operationalTableSize;
        }
        public void Initialize(TouristAgencyContext dbContext)
        {
            Random rand = new Random();
        
            dbContext.SaveChanges();
            if (!dbContext.Positions.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    dbContext.Positions.Add(new Position
                    {
                        Name = GetRandomString(50),
                       
                    });
                }
            }
            dbContext.SaveChanges();
            if (!dbContext.Clients.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    dbContext.Clients.Add(new Client
                    {
                        Surname = GetRandomString(50),
                        Name = GetRandomString(50),
                        Patronymic = GetRandomString(50),
                        Birthday = GetRandomDate(new DateTime(1950, 1, 1), DateTime.Now),
                        Gender = rand.Next(0, 2) == 1 ? true : false,
                        Address = GetRandomString(50),
                        Phone = rand.Next(1000000, 9999999),
                        PassportData = GetRandomString(50)

                    });
                }
            }
            dbContext.SaveChanges();
            if (!dbContext.Employees.Any())
            {
                var positions = dbContext.Positions.ToList();
               
                for (int i = 0; i < _operationalTableSize; i++)
                {
                    var position = positions.ElementAt(rand.Next(dbContext.Positions.Count() - 1));
                    
                    dbContext.Employees.Add(new Employee
                    {
                        Surname = GetRandomString(50),
                        Name = GetRandomString(50),
                        Patronymic = GetRandomString(50),
                        Birthday = GetRandomDate(new DateTime(1950, 1, 1), DateTime.Now),
                        PositionId = position.Id,
                        Position = position
                    });
                }
            }
            dbContext.SaveChanges();
        }
        public string GetRandomString(int maxLength)
        {
            Random rand = new Random();
            int length = rand.Next(maxLength / 3, maxLength);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var str = new char[length];
            for (int i = 0; i < length; i++)
            {
                if ((i + 1) % 10 == 0)
                {
                    str[i] = ' ';
                    continue;
                }
                str[i] = chars[rand.Next(chars.Length)];
            }
            return new string(str);
        }
        public DateTime GetRandomDate(DateTime minDate, DateTime maxDate)
        {
            Random rand = new Random();
            int range = (maxDate - minDate).Days;
            return minDate.AddDays(rand.Next(range));
        }
    }
}
