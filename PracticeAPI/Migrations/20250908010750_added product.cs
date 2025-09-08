using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PracticeAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userAccount",
                table: "userAccount");

            migrationBuilder.RenameTable(
                name: "userAccount",
                newName: "UserAccount");

            migrationBuilder.RenameColumn(
                name: "hashedPassword",
                table: "UserAccount",
                newName: "hashedpassword");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserAccount",
                newName: "userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "userid");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "userAccount");

            migrationBuilder.RenameColumn(
                name: "hashedpassword",
                table: "userAccount",
                newName: "hashedPassword");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "userAccount",
                newName: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAccount",
                table: "userAccount",
                column: "userId");
        }
    }
}
