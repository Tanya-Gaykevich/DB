using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication.Models;

namespace WebApplication.Data
{
    public partial class TouristAgencyContext : DbContext
    {
        public TouristAgencyContext()
            : base("name=SqlConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<TypeOfRest> TypesOfRest { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeOfRest>().ToTable("TypesOfRest");
        }
    }
}