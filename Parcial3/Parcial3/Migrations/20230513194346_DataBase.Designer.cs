﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial3.DAL;

#nullable disable

namespace Parcial3.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230513194346_DataBase")]
    partial class DataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parcial3.DAL.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Services");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Service");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Parcial3.DAL.Entities.Vehicle", b =>
                {
                    b.HasBaseType("Parcial3.DAL.Entities.Service");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasIndex("NumberPlate")
                        .IsUnique()
                        .HasFilter("[NumberPlate] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Vehicle");
                });

            modelBuilder.Entity("Parcial3.DAL.Entities.VehicleDetail", b =>
                {
                    b.HasBaseType("Parcial3.DAL.Entities.Vehicle");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehiculeId")
                        .HasColumnType("int");

                    b.HasIndex("VehiculeId")
                        .IsUnique()
                        .HasFilter("[VehiculeId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("VehicleDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
