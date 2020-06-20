using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MAS_Końcowy.Migrations
{
    public partial class mappedAssociations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_People_IngredientsSupplierId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_People_CookId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_People_DelivererId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_DeliveryAddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_People_WaiterId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContent_Order_OrderId",
                table: "OrderContent");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Address_AddressId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AddressId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_IngredientsSupplierId",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IngredientsSupplierId",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Order_WaiterId",
                table: "Orders",
                newName: "IX_Orders_WaiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Orders",
                newName: "IX_Orders_DeliveryAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DelivererId",
                table: "Orders",
                newName: "IX_Orders_DelivererId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CookId",
                table: "Orders",
                newName: "IX_Orders_CookId");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContractIngredient",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractIngredient", x => new { x.ContractId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ContractIngredient_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SupplierId",
                table: "Contracts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractIngredient_IngredientId",
                table: "ContractIngredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_People_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_People_SupplierId",
                table: "Contracts",
                column: "SupplierId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContent_Orders_OrderId",
                table: "OrderContent",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_People_CookId",
                table: "Orders",
                column: "CookId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_People_DelivererId",
                table: "Orders",
                column: "DelivererId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_People_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_People_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_People_SupplierId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderContent_Orders_OrderId",
                table: "OrderContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_People_CookId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_People_DelivererId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_People_WaiterId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ContractIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_SupplierId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_WaiterId",
                table: "Order",
                newName: "IX_Order_WaiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Order",
                newName: "IX_Order_DeliveryAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DelivererId",
                table: "Order",
                newName: "IX_Order_DelivererId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CookId",
                table: "Order",
                newName: "IX_Order_CookId");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "People",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IngredientsSupplierId",
                table: "Contract",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Address",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IngredientsSupplierId",
                table: "Contract",
                column: "IngredientsSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_People_IngredientsSupplierId",
                table: "Contract",
                column: "IngredientsSupplierId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_People_CookId",
                table: "Order",
                column: "CookId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_People_DelivererId",
                table: "Order",
                column: "DelivererId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_People_WaiterId",
                table: "Order",
                column: "WaiterId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContent_Order_OrderId",
                table: "OrderContent",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Address_AddressId",
                table: "People",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
