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
            //This is how to create composite keys:
            //modelBuilder.Entity<PrescriptionMedicament>().HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        }

        //public DbSet<Entity> FutureTableName { get; set; }
        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.Mechanic> Mechanics { get; set; }
    }
}
