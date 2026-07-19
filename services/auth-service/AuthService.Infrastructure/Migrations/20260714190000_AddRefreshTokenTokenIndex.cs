using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations;

[DbContext(typeof(AuthDbContext))]
[Migration("20260714190000_AddRefreshTokenTokenIndex")]
public partial class AddRefreshTokenTokenIndex : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_Token",
            table: "RefreshTokens",
            column: "Token",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_RefreshTokens_Token",
            table: "RefreshTokens");
    }
}
