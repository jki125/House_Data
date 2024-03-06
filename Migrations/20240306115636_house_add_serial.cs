using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House_Data.Migrations
{
    /// <inheritdoc />
    public partial class house_add_serial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "House",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "House");
        }
    }
}
