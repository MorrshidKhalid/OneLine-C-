using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneLine.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovMinAmountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinAmount",
                schema: "oneline",
                table: "Coupon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinAmount",
                schema: "oneline",
                table: "Coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
