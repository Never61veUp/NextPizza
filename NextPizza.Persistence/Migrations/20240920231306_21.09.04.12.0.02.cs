using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextPizza.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _21090412002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_DoughTypeEntity_DoughTypeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_SizeEntity_SizeId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeEntity",
                table: "SizeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoughTypeEntity",
                table: "DoughTypeEntity");

            migrationBuilder.RenameTable(
                name: "SizeEntity",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "DoughTypeEntity",
                newName: "DoughTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoughTypes",
                table: "DoughTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_DoughTypes_DoughTypeId",
                table: "Pizzas",
                column: "DoughTypeId",
                principalTable: "DoughTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_DoughTypes_DoughTypeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoughTypes",
                table: "DoughTypes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "SizeEntity");

            migrationBuilder.RenameTable(
                name: "DoughTypes",
                newName: "DoughTypeEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeEntity",
                table: "SizeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoughTypeEntity",
                table: "DoughTypeEntity",
                column: "Id");

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
    }
}
