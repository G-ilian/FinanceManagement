using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateContaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contaid",
                table: "Transacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_contaid",
                table: "Transacao",
                column: "contaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao",
                column: "contaid",
                principalTable: "Conta",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacao_contaid",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "contaid",
                table: "Transacao");
        }
    }
}
