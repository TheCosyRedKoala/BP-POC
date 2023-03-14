using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_POC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedTotalAmountInSaleClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Sale",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Sale");
        }
    }
}
