using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Data
{
    public class ModelDB : DbContext
    {
        public ModelDB(DbContextOptions<ModelDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<CallRecord> CallRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Начальные данные
            modelBuilder.Entity<Tariff>().HasData(
                new Tariff { Id = 1, CityCode = "001", CityName = "Город A", CostPerMinute = 0.5M },
                new Tariff { Id = 2, CityCode = "002", CityName = "Город B", CostPerMinute = 0.75M }
                // Добавьте больше тарифов...
            );

            modelBuilder.Entity<CallRecord>().HasData(
                new CallRecord { Id = 1, OwnerName = "Алиса", CityCode = "001", CityName = "Город A", DurationInMinutes = 10, TotalCost = 5.0M },
                new CallRecord { Id = 2, OwnerName = "Боб", CityCode = "002", CityName = "Город B", DurationInMinutes = 20, TotalCost = 15.0M }
                // Добавьте больше записей разговоров...
            );
        }
    }
}