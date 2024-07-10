using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Conta",
                new string[] { "nome", "tipo", "saldo", "instituicao" },
                new object[] { "Conta Nubank", "Corrente", 800, "Nubank" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Conta");
        }
    }
}
