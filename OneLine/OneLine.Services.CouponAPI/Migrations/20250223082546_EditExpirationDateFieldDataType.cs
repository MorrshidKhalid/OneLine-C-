using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneLine.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditExpirationDateFieldDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                schema: "oneline",
                table: "Coupon",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                schema: "oneline",
                table: "Coupon",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
