﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextPizza.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _22091611005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "Products",
                newName: "Discriminator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Products",
                newName: "ProductType");
        }
    }
}
