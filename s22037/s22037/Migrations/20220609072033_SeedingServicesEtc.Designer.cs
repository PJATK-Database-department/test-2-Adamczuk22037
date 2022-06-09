﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using s22037.Context;

namespace s22037.Migrations
{
    [DbContext(typeof(PjatkDbContext))]
    [Migration("20220609072033_SeedingServicesEtc")]
    partial class SeedingServicesEtc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("s22037.Models.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.HasKey("IdCar");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            IdCar = -1,
                            Name = "Car1",
                            ProductionYear = 1998
                        },
                        new
                        {
                            IdCar = -2,
                            Name = "Car2",
                            ProductionYear = 2011
                        });
                });

            modelBuilder.Entity("s22037.Models.Inspection", b =>
                {
                    b.Property<int>("IdInspection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdMechanic")
                        .HasColumnType("int");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdInspection");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdMechanic");

                    b.ToTable("Inspections");

                    b.HasData(
                        new
                        {
                            IdInspection = -1,
                            IdCar = -1,
                            IdMechanic = -1,
                            InspectionDate = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdInspection = -2,
                            Comment = "Post Accident",
                            IdCar = -1,
                            IdMechanic = -1,
                            InspectionDate = new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdInspection = -3,
                            IdCar = -2,
                            IdMechanic = -1,
                            InspectionDate = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("s22037.Models.Mechanic", b =>
                {
                    b.Property<int>("IdMechanic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdMechanic");

                    b.ToTable("Mechanics");

                    b.HasData(
                        new
                        {
                            IdMechanic = -1,
                            FirstName = "Fname1",
                            LastName = "Lname1"
                        });
                });

            modelBuilder.Entity("s22037.Models.ServiceTypeDict", b =>
                {
                    b.Property<int>("IdServiceType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdServiceType");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            IdServiceType = -1,
                            Price = 350.49f,
                            ServiceType = "ServiceType1"
                        },
                        new
                        {
                            IdServiceType = -2,
                            Price = 500f,
                            ServiceType = "ServiceType2"
                        },
                        new
                        {
                            IdServiceType = -3,
                            Price = 100f,
                            ServiceType = "ServiceType3"
                        },
                        new
                        {
                            IdServiceType = -4,
                            Price = 235.75f,
                            ServiceType = "ServiceType4"
                        });
                });

            modelBuilder.Entity("s22037.Models.ServiceTypeDict_Inspection", b =>
                {
                    b.Property<int>("IdServiceType")
                        .HasColumnType("int");

                    b.Property<int>("IdInspection")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("IdServiceType", "IdInspection");

                    b.HasIndex("IdInspection");

                    b.ToTable("ServiceTypeDict_Inspections");

                    b.HasData(
                        new
                        {
                            IdServiceType = -1,
                            IdInspection = -1
                        },
                        new
                        {
                            IdServiceType = -1,
                            IdInspection = -2,
                            Comments = "Comments"
                        },
                        new
                        {
                            IdServiceType = -3,
                            IdInspection = -2
                        },
                        new
                        {
                            IdServiceType = -4,
                            IdInspection = -2,
                            Comments = "OtherComments"
                        },
                        new
                        {
                            IdServiceType = -2,
                            IdInspection = -3,
                            Comments = "YetMoreComments"
                        });
                });

            modelBuilder.Entity("s22037.Models.Inspection", b =>
                {
                    b.HasOne("s22037.Models.Car", "Car")
                        .WithMany("Inspections")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("s22037.Models.Mechanic", "Mechanic")
                        .WithMany("Inspections")
                        .HasForeignKey("IdMechanic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("s22037.Models.ServiceTypeDict_Inspection", b =>
                {
                    b.HasOne("s22037.Models.Inspection", "Inspection")
                        .WithMany("ServiceTypeDict_Inspections")
                        .HasForeignKey("IdInspection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("s22037.Models.ServiceTypeDict", "ServiceType")
                        .WithMany("ServiceTypeDict_Inspections")
                        .HasForeignKey("IdServiceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inspection");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("s22037.Models.Car", b =>
                {
                    b.Navigation("Inspections");
                });

            modelBuilder.Entity("s22037.Models.Inspection", b =>
                {
                    b.Navigation("ServiceTypeDict_Inspections");
                });

            modelBuilder.Entity("s22037.Models.Mechanic", b =>
                {
                    b.Navigation("Inspections");
                });

            modelBuilder.Entity("s22037.Models.ServiceTypeDict", b =>
                {
                    b.Navigation("ServiceTypeDict_Inspections");
                });
#pragma warning restore 612, 618
        }
    }
}
