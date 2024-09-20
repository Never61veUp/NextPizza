using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextPizza.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _20092200001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoughTypeId",
                table: "Pizzas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Pizzas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "Pizzas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DoughTypeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ThicknessInCm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoughTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SizeInCm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_DoughTypeId",
                table: "Pizzas",
                column: "DoughTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_DoughTypeEntity_DoughTypeId",
                table: "Pizzas",
                column: "DoughTypeId",
                principalTable: "DoughTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_SizeEntity_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "SizeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_DoughTypeEntity_DoughTypeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_SizeEntity_SizeId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "DoughTypeEntity");

            migrationBuilder.DropTable(
                name: "SizeEntity");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_DoughTypeId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DoughTypeId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Pizzas");
        }
    }
}
