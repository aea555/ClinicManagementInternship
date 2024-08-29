using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementInternship.Migrations
{
    /// <inheritdoc />
    public partial class Fixadminmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Admins_AccountId",
                table: "Admins",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AccountId",
                table: "Admins");
        }
    }
}
