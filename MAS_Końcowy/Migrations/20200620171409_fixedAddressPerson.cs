using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS_Końcowy.Migrations
{
    public partial class fixedAddressPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
