using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateUsuarioConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioid",
                table: "Conta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_usuarioid",
                table: "Conta",
                column: "usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Usuario_usuarioid",
                table: "Conta",
                column: "usuarioid",
                principalTable: "Usuario",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Usuario_usuarioid",
                table: "Conta");


            migrationBuilder.DropIndex(
                name: "IX_Conta_usuarioid",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "usuarioid",
                table: "Conta");
        }
    }
}
