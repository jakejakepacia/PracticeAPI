using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeAPI.Migrations
{
    /// <inheritdoc />
    public partial class renamedcolumnid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "hashedPassword");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "hashedPassword",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");
        }
    }
}
