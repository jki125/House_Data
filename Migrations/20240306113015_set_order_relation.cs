using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House_Data.Migrations
{
    /// <inheritdoc />
    public partial class set_order_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_HouseId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_HouseId",
                table: "Order",
                column: "HouseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_HouseId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_HouseId",
                table: "Order",
                column: "HouseId");
        }
    }
}
