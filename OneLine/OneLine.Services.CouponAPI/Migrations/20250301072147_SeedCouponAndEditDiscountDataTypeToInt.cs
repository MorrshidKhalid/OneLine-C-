using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneLine.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponAndEditDiscountDataTypeToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiscountAmount",
                schema: "oneline",
                table: "Coupon",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.InsertData(
                schema: "oneline",
                table: "Coupon",
                columns: new[] { "CouponId", "Code", "DiscountAmount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "K-INV25", 10, new DateOnly(2025, 3, 10) },
                    { 2, "Z-CH35", 10, new DateOnly(2025, 4, 4) },
                    { 3, "MAK-DES", 20, new DateOnly(2025, 3, 20) },
                    { 4, "DUP", 30, new DateOnly(2025, 4, 15) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "oneline",
                table: "Coupon",
                keyColumn: "CouponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "oneline",
                table: "Coupon",
                keyColumn: "CouponId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "oneline",
                table: "Coupon",
                keyColumn: "CouponId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "oneline",
                table: "Coupon",
                keyColumn: "CouponId",
                keyValue: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                schema: "oneline",
                table: "Coupon",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
