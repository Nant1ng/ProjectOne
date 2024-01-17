﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectLibrary.Data;

#nullable disable

namespace ProjectLibrary.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240117181415_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectLibrary.Models.Calculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("A")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("CalculationDate")
                        .HasColumnType("date");

                    b.Property<byte>("MathOperator")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Calculator");
                });

            modelBuilder.Entity("ProjectLibrary.Models.GameStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageWins")
                        .HasColumnType("float");

                    b.Property<int>("TotalDraws")
                        .HasColumnType("int");

                    b.Property<int>("TotalGamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("TotalLoses")
                        .HasColumnType("int");

                    b.Property<int>("TotalWins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameStatistics");
                });

            modelBuilder.Entity("ProjectLibrary.Models.RockPaperSicssorGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("ComputerChoice")
                        .HasColumnType("tinyint");

                    b.Property<DateOnly>("GameDate")
                        .HasColumnType("date");

                    b.Property<byte>("PlayerChoice")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Result")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("RockPaperScissorGame");
                });

            modelBuilder.Entity("ProjectLibrary.Models.Shape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<DateOnly>("CalculationDate")
                        .HasColumnType("date");

                    b.Property<double>("Lenght")
                        .HasColumnType("float");

                    b.Property<double>("Perimeter")
                        .HasColumnType("float");

                    b.Property<byte>("TypeOfShape")
                        .HasColumnType("tinyint");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Shape");
                });
#pragma warning restore 612, 618
        }
    }
}
