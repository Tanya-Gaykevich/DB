using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication.Models;

namespace WebApplication.Data
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}