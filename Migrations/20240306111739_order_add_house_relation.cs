using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House_Data.Migrations
{
    /// <inheritdoc />
    public partial class order_add_house_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_HouseId",
                table: "Order",
                column: "HouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_House_HouseId",
                table: "Order",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_House_HouseId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_HouseId",
                table: "Order");
        }
    }
}
