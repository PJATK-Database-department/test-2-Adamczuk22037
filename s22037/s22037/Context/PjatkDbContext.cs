using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Context
{
    public class PjatkDbContext : DbContext
    {
        public PjatkDbContext() { }
        public PjatkDbContext(DbContextOptions options) : base(options)   { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ServiceTypeDict_Inspection>().HasKey(sti => new { sti.IdServiceType, sti.IdInspection });
            //seedData(modelBuilder);
        }

        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.Mechanic> Mechanics { get; set; }
        public DbSet<Models.Inspection> Inspections { get; set; }
        public DbSet<Models.ServiceTypeDict> ServiceTypes { get; set; }
        public DbSet<Models.ServiceTypeDict_Inspection> ServiceTypeDict_Inspections { get; set; }

        private void seedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Car>(c =>
            {
                c.HasData(
                    new Models.Car { IdCar = -1, Name = "Car1", ProductionYear = 1998 },
                    new Models.Car { IdCar = -2, Name = "Car2", ProductionYear = 2011 }
                );
            });
        }
    }
}
