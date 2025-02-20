using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTrackingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _20022025_v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VatRate",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Products");
        }
    }
}
