﻿// <auto-generated />
using System;
using CustomerModules.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerModuleService.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("CustomerModule", b =>
                {
                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("DATETIME");

                    b.HasKey("ModuleId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerModule");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PortalUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("CustomerModule", b =>
                {
                    b.HasOne("CustomerModules.Models.Entities.Customer", "Customer")
                        .WithMany("CustomerModules")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerModules.Models.Entities.Module", "Module")
                        .WithMany("CustomerModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.Customer", b =>
                {
                    b.HasOne("CustomerModules.Models.Entities.City", "City")
                        .WithMany("Customers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.City", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.Customer", b =>
                {
                    b.Navigation("CustomerModules");
                });

            modelBuilder.Entity("CustomerModules.Models.Entities.Module", b =>
                {
                    b.Navigation("CustomerModules");
                });
#pragma warning restore 612, 618
        }
    }
}
