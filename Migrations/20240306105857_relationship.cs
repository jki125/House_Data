using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House_Data.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_salesId",
                table: "Order",
                column: "salesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Sales_salesId",
                table: "Order",
                column: "salesId",
                principalTable: "Sales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Sales_salesId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_salesId",
                table: "Order");
        }
    }
}
