﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeAPI.Migrations
{
    /// <inheritdoc />
    public partial class addeduseridtoproductdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");
        }
    }
}
