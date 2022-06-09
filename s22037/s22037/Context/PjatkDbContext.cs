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
            seedData(modelBuilder);
        }

        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.Mechanic> Mechanics { get; set; }
        public DbSet<Models.Inspection> Inspections { get; set; }
        public DbSet<Models.ServiceTypeDict> ServiceTypes { get; set; }
        public DbSet<Models.ServiceTypeDict_Inspection> ServiceTypeDict_Inspections { get; set; }

        //Negative ids as per VisualStudio error's suggestion, to easily tell them apart from actual data.
        private void seedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Car>(c =>
            {
                c.HasData(
                    new Models.Car { IdCar = -1, Name = "Car1", ProductionYear = 1998 },
                    new Models.Car { IdCar = -2, Name = "Car2", ProductionYear = 2011 },
                    new Models.Car { IdCar = -3, Name = "Car3", ProductionYear = 2018 }
                );
            });

            modelBuilder.Entity<Models.Mechanic>(m =>
            {
                m.HasData(
                    new Models.Mechanic {  IdMechanic = -1, FirstName = "Fname1", LastName = "Lname1" }
                 );
            });

            modelBuilder.Entity<Models.Inspection>(i =>
            {
                i.HasData(
                    new Models.Inspection {  IdInspection = -1, IdCar = -1, IdMechanic = -1, InspectionDate = new DateTime(2021, 11, 18) },
                    new Models.Inspection { IdInspection = -2, IdCar = -1, IdMechanic = -1, InspectionDate = new DateTime(2022, 01, 21), Comment = "Post Accident" },
                    new Models.Inspection { IdInspection = -3, IdCar = -2, IdMechanic = -1, InspectionDate = new DateTime(2022, 03, 02) },
                    new Models.Inspection { IdInspection = -4, IdCar = -3, IdMechanic = -1, InspectionDate = new DateTime(2025, 09, 15), Comment = "Yearly Inspection" }
                 );
            });

            modelBuilder.Entity<Models.ServiceTypeDict>(st =>
            {
                st.HasData(
                    new Models.ServiceTypeDict {  IdServiceType = -1, ServiceType = "ServiceType1", Price = (float)350.49 },
                    new Models.ServiceTypeDict { IdServiceType = -2, ServiceType = "ServiceType2", Price = (float)500 },
                    new Models.ServiceTypeDict { IdServiceType = -3, ServiceType = "ServiceType3", Price = (float)100 },
                    new Models.ServiceTypeDict { IdServiceType = -4, ServiceType = "ServiceType4", Price = (float)235.75 }
                 );
            });

            modelBuilder.Entity<Models.ServiceTypeDict_Inspection>(sti =>
            {
                sti.HasData(
                    new Models.ServiceTypeDict_Inspection { IdInspection = -1, IdServiceType = -1},
                    new Models.ServiceTypeDict_Inspection { IdInspection = -2, IdServiceType = -1, Comments = "Comments" },
                    new Models.ServiceTypeDict_Inspection { IdInspection = -2, IdServiceType = -3 },
                    new Models.ServiceTypeDict_Inspection { IdInspection = -2, IdServiceType = -4, Comments = "OtherComments" },
                    new Models.ServiceTypeDict_Inspection { IdInspection = -3, IdServiceType = -2, Comments = "YetMoreComments" },
                    new Models.ServiceTypeDict_Inspection { IdInspection = -4, IdServiceType = -2},
                    new Models.ServiceTypeDict_Inspection { IdInspection = -4, IdServiceType = -1, Comments = "IfNecessary" }
                 );
            });
        }

    }
}
