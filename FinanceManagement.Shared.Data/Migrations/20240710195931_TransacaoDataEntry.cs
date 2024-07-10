using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransacaoDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Transacao", new string[] { "valor", "dataTransacao", "descricao", "tipo", "contaid" },
                new object[] { 800.0, "2024-07-10", "Salario", "Credito", 1 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
