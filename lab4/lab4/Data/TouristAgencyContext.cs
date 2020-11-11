using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab4
{
    public partial class TouristAgencyContext : DbContext
    {
        public TouristAgencyContext()
        {
        }

        public TouristAgencyContext(DbContextOptions<TouristAgencyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceVoucher> ServicesVouchers { get; set; }
        public virtual DbSet<TypeOfRest> TypesOfRest { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
    }
}