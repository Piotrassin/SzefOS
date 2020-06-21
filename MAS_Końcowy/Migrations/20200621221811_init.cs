using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MAS_Końcowy.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "People",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   Name = table.Column<string>(nullable: true),
                   Lastname = table.Column<string>(nullable: true),
                   PhoneNumber = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_People", x => x.Id);
               });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HireDate = table.Column<DateTime>(nullable: false),
                    PESEL = table.Column<string>(nullable: true),
                    SanepidBookExpirationDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    PricePerKg = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "IngredientSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NIP = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    HasRefrigeratedTrailers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_IngredientSuppliers_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfitMargin = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooks_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliverers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DrivingLicense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waiters_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfSigning = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    NumberOfDeliveries = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_IngredientSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "IngredientSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AnimalOrigin = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractIngredients",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractIngredients", x => new { x.ContractId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ContractIngredients_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishContents",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishContents", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishContents_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishContents_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TableNumber = table.Column<int>(nullable: true),
                    DeliveryAddressId = table.Column<int>(nullable: true),
                    CookId = table.Column<int>(nullable: true),
                    WaiterId = table.Column<int>(nullable: true),
                    DelivererId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cooks_CookId",
                        column: x => x.CookId,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Deliverers_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Deliverers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Waiters_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "Waiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderContents",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    Number = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContents", x => new { x.DishId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderContents_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderContents_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractIngredients_IngredientId",
                table: "ContractIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SupplierId",
                table: "Contracts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DishContents_IngredientId",
                table: "DishContents",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_OrderId",
                table: "OrderContents",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CookId",
                table: "Orders",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DelivererId",
                table: "Orders",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders",
                column: "WaiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractIngredients");

            migrationBuilder.DropTable(
                name: "DishContents");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "OrderContents");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "IngredientSuppliers");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Deliverers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
