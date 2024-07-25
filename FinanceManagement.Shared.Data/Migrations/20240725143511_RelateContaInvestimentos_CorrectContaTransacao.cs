using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateContaInvestimentos_CorrectContaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valorInvestido = table.Column<double>(type: "float", nullable: false),
                    tipoInvestimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    corretora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    riscoInvestimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rentabilidade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContaInvestimentos",
                columns: table => new
                {
                    contasid = table.Column<int>(type: "int", nullable: false),
                    investimentosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaInvestimentos", x => new { x.contasid, x.investimentosid });
                    table.ForeignKey(
                        name: "FK_ContaInvestimentos_Conta_contasid",
                        column: x => x.contasid,
                        principalTable: "Conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaInvestimentos_Investimentos_investimentosid",
                        column: x => x.investimentosid,
                        principalTable: "Investimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaInvestimentos_investimentosid",
                table: "ContaInvestimentos",
                column: "investimentosid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao",
                column: "contaid",
                principalTable: "Conta",
                principalColumn: "id");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao");

            migrationBuilder.DropTable(
                name: "ContaInvestimentos");

            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Conta_contaid",
                table: "Transacao",
                column: "contaid",
                principalTable: "Conta",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
