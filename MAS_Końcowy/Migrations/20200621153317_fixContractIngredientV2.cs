using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS_Końcowy.Migrations
{
    public partial class fixContractIngredientV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractIngredient_Contracts_ContractId",
                table: "ContractIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractIngredient_Ingredients_IngredientId",
                table: "ContractIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractIngredient",
                table: "ContractIngredient");

            migrationBuilder.RenameTable(
                name: "ContractIngredient",
                newName: "ContractIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_ContractIngredient_IngredientId",
                table: "ContractIngredients",
                newName: "IX_ContractIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractIngredients",
                table: "ContractIngredients",
                columns: new[] { "ContractId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractIngredients_Contracts_ContractId",
                table: "ContractIngredients",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractIngredients_Ingredients_IngredientId",
                table: "ContractIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractIngredients_Contracts_ContractId",
                table: "ContractIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractIngredients_Ingredients_IngredientId",
                table: "ContractIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractIngredients",
                table: "ContractIngredients");

            migrationBuilder.RenameTable(
                name: "ContractIngredients",
                newName: "ContractIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_ContractIngredients_IngredientId",
                table: "ContractIngredient",
                newName: "IX_ContractIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractIngredient",
                table: "ContractIngredient",
                columns: new[] { "ContractId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractIngredient_Contracts_ContractId",
                table: "ContractIngredient",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractIngredient_Ingredients_IngredientId",
                table: "ContractIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
