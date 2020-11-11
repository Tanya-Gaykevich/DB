using System;
using lab2.Model;
using System.Collections;
using System.Linq;
using System.ComponentModel;

namespace lab2
{
    class Program
    {
        static TouristAgencyContext db;
        static void Main(string[] args)
        {
            db = new TouristAgencyContext();
            Problem1(db);
            Problem2(db);
            Problem3(db);
            Problem4(db);
            Problem5(db);
            Problem6(db);
            Problem7(db);
            Problem8(db);
            Problem9(db);
            Problem10(db);
        }

        //Для вывода коллекции
        static void Print(string sqltext, IEnumerable items)
        {
            Console.WriteLine(sqltext);
            Console.WriteLine("Записи: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        static void Problem1(TouristAgencyContext db)
        {
            var clients = db.Clients
                .Select(client => client);
            Print("Вывод всех данныз из таблицы Clients", clients.Take(5).ToList());
        }

        static void Problem2(TouristAgencyContext db)
        {
            var hotels = db.Hotels
                .Where(h => h.NumberOfStars < 4 && h.NumberOfStars > 0)
                .Select(hotel => hotel);
            Print("Результат выборки из таблицы Hotels.\n" +
                "Ограничение на поле NumberOfStars (< 4).", hotels.Take(5).ToList());
        }

        static void Problem3(TouristAgencyContext db)
        {
            var sevises = db.ServicesVouchers
                .GroupBy(c => c.Service.Cost).Average(c => c.Key);
            Console.WriteLine($"Средняя стоимость всех услуг {sevises}");

        }

        static void Problem4(TouristAgencyContext db)
        {
            var sevicesVouchersPlusServices = db.ServicesVouchers
                .Join(db.Services, serviceVoucher => serviceVoucher.Id, service => service.Id,
                (serviceVoucher, service) => new
                {
                    serviceVoucher.ReservationMark,
                    serviceVoucher.PaymentMark,
                    service.Name,
                    service.Description,
                    service.Cost
                  
                })
               ;

            Print("Результат выборки из таблиц ServicesVouchers и Services.", sevicesVouchersPlusServices.Take(10).ToList());
        }

        static void Problem5(TouristAgencyContext db)
        {
            var vouchersPlusClients = db.Vouchers
                .Join(db.Clients, voucher => voucher.Id, client => client.Id,
                 (voucher, client) => new



                 {
                     voucher.Name,
                     voucher.StartDate,
                     voucher.EndDate,
                     client.Surname,
                     client.Birthday,
                     Gender = client.Gender ? "Мужчина" : "Женщина",
                     client.Address,
                     client.Phone,
                     client.PassportData

                 })
                .Where(client => client.Gender == "Женщина")
               ;

            Print("Результат выборки из таблиц Vouchers и Clients с фильтром по полю Gender. " +
                "Вывести клиентов одного пола", vouchersPlusClients.Take(10).ToList());
        }

        static void Problem6(TouristAgencyContext db)
        {
            Service service = new Service
            {
                Name = "TestService",
                Description = "TestServiceDecription",
                Cost = 777
            };
            db.Services.Add(service);
            db.SaveChanges();
            Console.WriteLine("Услуга добавлена");
        }

        static void Problem7(TouristAgencyContext db)
        {
            Random rand = new Random();
            Hotel hotel = db.Hotels.ToList().ElementAt(rand.Next(0, db.Hotels.Count() - 1));
            Employee employee = db.Employees.ToList().ElementAt(rand.Next(0, db.Employees.Count() - 1));
            Client client = db.Clients.ToList().ElementAt(rand.Next(0, db.Clients.Count() - 1));
            TypeOfRest typeOfRest = db.TypesOfRest.ToList().ElementAt(rand.Next(0, db.TypesOfRest.Count() - 1));
            Voucher voucher = new Voucher
            {
                Name = "TestVoucher",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Hotel = hotel,
                HotelId = hotel.Id,
                TypeOfRest = typeOfRest,
                TypeOfRestId = typeOfRest.Id,
                Employee = employee,
                EmployeeId = employee.Id,
                Client = client,
                ClientId = client.Id
            };
            db.Vouchers.Add(voucher);
            db.SaveChanges();
            Console.WriteLine("Путёвка добавлен");
        }

        static void Problem8(TouristAgencyContext db)
        {
            db.Services.Remove(db.Services.ToList()[db.Services.Count() - 1]);
            db.SaveChanges();
            Console.WriteLine("Услуга удалена");
        }

        static void Problem9(TouristAgencyContext db)
        {
            db.Vouchers.Remove(db.Vouchers.ToList()[db.Vouchers.Count() - 1]);
            db.SaveChanges();
            Console.WriteLine("Путёвка удалёна");

        }

        static void Problem10(TouristAgencyContext db)
        {
            var costServices = db.Services.Where(service => service.Cost < 499);
            foreach (var service in costServices)
            {
                service.Cost *= (decimal)1.05;
            }
            db.SaveChanges();
            Console.WriteLine("Стоимость услуг, стоящих меньше 499 увеличена на 5%");
        }
    }
}
