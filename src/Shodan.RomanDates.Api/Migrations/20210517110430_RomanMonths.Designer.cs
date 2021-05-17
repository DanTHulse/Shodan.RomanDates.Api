﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shodan.RomanDates.Api.Dto;

namespace Shodan.RomanDates.Api.Migrations
{
    [DbContext(typeof(RomanusDbContext))]
    [Migration("20210517110430_RomanMonths")]
    partial class RomanMonths
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shodan.RomanDates.Api.Dto.Models.RomanMonth", b =>
                {
                    b.Property<int>("MonthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("month_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AverageDaytimeHourLength")
                        .HasColumnType("decimal(3,2)")
                        .HasColumnName("average__daytime_hour_length");

                    b.Property<string>("LatinMonthName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("latin_month_name");

                    b.Property<int>("MonthLengthDays")
                        .HasColumnType("int")
                        .HasColumnName("month_length_days");

                    b.Property<string>("MonthName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("month_name");

                    b.HasKey("MonthId")
                        .HasName("pk_month_month_id");

                    b.ToTable("month", "romanus");

                    b.HasData(
                        new
                        {
                            MonthId = 1,
                            AverageDaytimeHourLength = 0.82m,
                            LatinMonthName = "Ianuarias",
                            MonthLengthDays = 29,
                            MonthName = "January"
                        },
                        new
                        {
                            MonthId = 2,
                            AverageDaytimeHourLength = 0.91m,
                            LatinMonthName = "Februarias",
                            MonthLengthDays = 28,
                            MonthName = "February"
                        },
                        new
                        {
                            MonthId = 3,
                            AverageDaytimeHourLength = 1m,
                            LatinMonthName = "Martias",
                            MonthLengthDays = 31,
                            MonthName = "March"
                        },
                        new
                        {
                            MonthId = 4,
                            AverageDaytimeHourLength = 1.09m,
                            LatinMonthName = "Apriles",
                            MonthLengthDays = 29,
                            MonthName = "April"
                        },
                        new
                        {
                            MonthId = 5,
                            AverageDaytimeHourLength = 1.18m,
                            LatinMonthName = "Maias",
                            MonthLengthDays = 31,
                            MonthName = "May"
                        },
                        new
                        {
                            MonthId = 6,
                            AverageDaytimeHourLength = 1.27m,
                            LatinMonthName = "Iunias",
                            MonthLengthDays = 29,
                            MonthName = "June"
                        },
                        new
                        {
                            MonthId = 7,
                            AverageDaytimeHourLength = 1.18m,
                            LatinMonthName = "Quintilis",
                            MonthLengthDays = 31,
                            MonthName = "July"
                        },
                        new
                        {
                            MonthId = 8,
                            AverageDaytimeHourLength = 1.09m,
                            LatinMonthName = "Sextilis",
                            MonthLengthDays = 29,
                            MonthName = "August"
                        },
                        new
                        {
                            MonthId = 9,
                            AverageDaytimeHourLength = 1m,
                            LatinMonthName = "Septembres",
                            MonthLengthDays = 29,
                            MonthName = "September"
                        },
                        new
                        {
                            MonthId = 10,
                            AverageDaytimeHourLength = 0.91m,
                            LatinMonthName = "Octobres",
                            MonthLengthDays = 31,
                            MonthName = "October"
                        },
                        new
                        {
                            MonthId = 11,
                            AverageDaytimeHourLength = 0.82m,
                            LatinMonthName = "Novembres",
                            MonthLengthDays = 29,
                            MonthName = "November"
                        },
                        new
                        {
                            MonthId = 12,
                            AverageDaytimeHourLength = 0.73m,
                            LatinMonthName = "Decembres",
                            MonthLengthDays = 29,
                            MonthName = "December"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}