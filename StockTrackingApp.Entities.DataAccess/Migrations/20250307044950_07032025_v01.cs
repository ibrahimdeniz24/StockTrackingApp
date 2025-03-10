using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTrackingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _07032025_v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalExcludingVATAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVATAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceExcludingVAT",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceIncludingVAT",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VATAmount",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalExcludingVATAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalVATAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPriceExcludingVAT",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalPriceIncludingVAT",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "VATAmount",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "VatRate",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
