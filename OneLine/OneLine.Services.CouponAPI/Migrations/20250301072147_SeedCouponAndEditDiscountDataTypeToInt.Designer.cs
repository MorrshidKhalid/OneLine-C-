﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneLine.Services.CouponAPI.Data;

#nullable disable

namespace OneLine.Services.CouponAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250301072147_SeedCouponAndEditDiscountDataTypeToInt")]
    partial class SeedCouponAndEditDiscountDataTypeToInt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OneLine.Services.CouponAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("DATE");

                    b.HasKey("CouponId");

                    b.ToTable("Coupon", "oneline");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            Code = "K-INV25",
                            DiscountAmount = 10,
                            ExpirationDate = new DateOnly(2025, 3, 10)
                        },
                        new
                        {
                            CouponId = 2,
                            Code = "Z-CH35",
                            DiscountAmount = 10,
                            ExpirationDate = new DateOnly(2025, 4, 4)
                        },
                        new
                        {
                            CouponId = 3,
                            Code = "MAK-DES",
                            DiscountAmount = 20,
                            ExpirationDate = new DateOnly(2025, 3, 20)
                        },
                        new
                        {
                            CouponId = 4,
                            Code = "DUP",
                            DiscountAmount = 30,
                            ExpirationDate = new DateOnly(2025, 4, 15)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
