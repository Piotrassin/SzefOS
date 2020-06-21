using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS_Końcowy.Migrations
{
    public partial class fixContractIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderContent_Dishes_DishId",
                table: "OrderContent");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContent_Orders_OrderId",
                table: "OrderContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderContent",
                table: "OrderContent");

            migrationBuilder.RenameTable(
                name: "OrderContent",
                newName: "OrderContents");

            migrationBuilder.RenameIndex(
                name: "IX_OrderContent_OrderId",
                table: "OrderContents",
                newName: "IX_OrderContents_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_Dishes_DishId",
                table: "OrderContents",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContents_Orders_OrderId",
                table: "OrderContents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_Dishes_DishId",
                table: "OrderContents");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContents_Orders_OrderId",
                table: "OrderContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderContents",
                table: "OrderContents");

            migrationBuilder.RenameTable(
                name: "OrderContents",
                newName: "OrderContent");

            migrationBuilder.RenameIndex(
                name: "IX_OrderContents_OrderId",
                table: "OrderContent",
                newName: "IX_OrderContent_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderContent",
                table: "OrderContent",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContent_Dishes_DishId",
                table: "OrderContent",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContent_Orders_OrderId",
                table: "OrderContent",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
