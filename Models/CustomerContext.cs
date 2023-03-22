using CustomerModules.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerModules.Models
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CustomerModule> CustomerModules { get; set; }

        public string DbPath { get; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "dbCustomerModule.db");
        }
        //public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(cu => cu.Modules)
                .WithMany(cu => cu.Customers)
                .UsingEntity<CustomerModule>("CustomerModule",
                j => j
                        .HasOne(cm => cm.Module)
                        .WithMany(m => m.CustomerModules)
                        .HasForeignKey(cm => cm.ModuleId),
                    j => j
                        .HasOne(cm => cm.Customer)
                        .WithMany(cu => cu.CustomerModules)
                        .HasForeignKey(cm => cm.CustomerId),
                    j =>
                    {
                        j.Property(cm => cm.ActivationDate).HasColumnType("DATETIME");
                        j.HasKey(m => new { m.ModuleId, m.CustomerId });
                    });
        }
    }



}
