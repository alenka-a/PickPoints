using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PickPoints.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postamps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Goods = table.Column<string[]>(type: "text[]", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    RecipientPhone = table.Column<string>(type: "text", nullable: false),
                    RecipientFullname = table.Column<string>(type: "text", nullable: false),
                    PostampId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Postamps_PostampId",
                        column: x => x.PostampId,
                        principalTable: "Postamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Postamps",
                columns: new[] { "Id", "Address", "IsActive", "Number" },
                values: new object[,]
                {
                    { 1, "Авиаторов, улица 30", true, "1111-111" },
                    { 2, "Авиаторов, улица 30", true, "2222-222" },
                    { 3, "Авиаторов, улица 30", false, "3333-333" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PostampId",
                table: "Orders",
                column: "PostampId");

            migrationBuilder.CreateIndex(
                name: "IX_Postamps_Number",
                table: "Postamps",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Postamps");
        }
    }
}
