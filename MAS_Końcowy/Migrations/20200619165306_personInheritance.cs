using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MAS_Końcowy.Migrations
{
    public partial class personInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetName = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: true),
                    PESEL = table.Column<string>(nullable: true),
                    SanepidBookExpirationDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    DrivingLicense = table.Column<string>(nullable: true),
                    NIP = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    HasRefrigeratedTrailers = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfSigning = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    NumberOfDeliveries = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IngredientsSupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_People_IngredientsSupplierId",
                        column: x => x.IngredientsSupplierId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
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
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_People_CookId",
                        column: x => x.CookId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_People_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_People_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderContent",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    Number = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContent", x => new { x.DishId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderContent_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderContent_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IngredientsSupplierId",
                table: "Contract",
                column: "IngredientsSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CookId",
                table: "Order",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DelivererId",
                table: "Order",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WaiterId",
                table: "Order",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContent_OrderId",
                table: "OrderContent",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "OrderContent");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
