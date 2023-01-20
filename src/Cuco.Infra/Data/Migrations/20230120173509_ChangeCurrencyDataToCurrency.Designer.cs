﻿// <auto-generated />
using System;
using Cuco.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cuco.Infra.Data.Migrations
{
    [DbContext(typeof(CucoDbContext))]
    [Migration("20230120173509_ChangeCurrencyDataToCurrency")]
    partial class ChangeCurrencyDataToCurrency
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cuco.Domain.Currencies.Models.Entities.Currency", b =>
                {
                    b.Property<string>("Symbol")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("ValueInDollar")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Symbol");

                    b.ToTable("Currency", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}