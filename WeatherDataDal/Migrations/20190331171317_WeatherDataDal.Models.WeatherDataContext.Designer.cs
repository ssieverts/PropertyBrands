﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherDataDal.Models;

namespace WeatherDataDal.Migrations
{
    [DbContext(typeof(WeatherDataContext))]
    [Migration("20190331171317_WeatherDataDal.Models.WeatherDataContext")]
    partial class WeatherDataDalModelsWeatherDataContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherDataDal.Models.Clouds", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<long>("All");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId")
                        .IsUnique();

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Coord", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<double>("Lat");

                    b.Property<double>("Lon");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId")
                        .IsUnique();

                    b.ToTable("Coord");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Main", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<long>("Humidity");

                    b.Property<long>("Pressure");

                    b.Property<double>("Temp");

                    b.Property<double>("TempMax");

                    b.Property<double>("TempMin");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId")
                        .IsUnique();

                    b.ToTable("Main");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Sys", b =>
                {
                    b.Property<Guid>("RefId");

                    b.Property<string>("Country");

                    b.Property<long>("Id");

                    b.Property<double>("Message");

                    b.Property<long>("Sunrise");

                    b.Property<long>("Sunset");

                    b.Property<long>("Type");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId")
                        .IsUnique();

                    b.ToTable("Sys");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Weather", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Description");

                    b.Property<string>("Icon");

                    b.Property<long>("Id");

                    b.Property<string>("Main");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("WeatherDataDal.Models.WeatherData", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Base");

                    b.Property<long>("Cod");

                    b.Property<long>("Dt");

                    b.Property<long>("Id");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Visibility");

                    b.HasKey("RefId");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Wind", b =>
                {
                    b.Property<Guid>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<long>("Deg");

                    b.Property<double>("Gust");

                    b.Property<double>("Speed");

                    b.Property<Guid>("WeatherDataRefId");

                    b.HasKey("RefId");

                    b.HasIndex("WeatherDataRefId")
                        .IsUnique();

                    b.ToTable("Wind");
                });

            modelBuilder.Entity("WeatherDataDal.Models.Clouds", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithOne("Clouds")
                        .HasForeignKey("WeatherDataDal.Models.Clouds", "WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherDataDal.Models.Coord", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithOne("Coord")
                        .HasForeignKey("WeatherDataDal.Models.Coord", "WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherDataDal.Models.Main", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithOne("Main")
                        .HasForeignKey("WeatherDataDal.Models.Main", "WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherDataDal.Models.Sys", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithOne("Sys")
                        .HasForeignKey("WeatherDataDal.Models.Sys", "WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherDataDal.Models.Weather", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithMany("Weathers")
                        .HasForeignKey("WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherDataDal.Models.Wind", b =>
                {
                    b.HasOne("WeatherDataDal.Models.WeatherData", "WeatherDataRef")
                        .WithOne("Wind")
                        .HasForeignKey("WeatherDataDal.Models.Wind", "WeatherDataRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
