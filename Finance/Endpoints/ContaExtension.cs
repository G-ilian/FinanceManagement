using Finance_console;
using FinanceManagement.Shared.Data.DB;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Endpoints
{
    public static class ContaExtension
    {
        public static void AddEndpointsConta(this WebApplication app)
        {
            app.MapGet("/Contas", ([FromServices] DAL<Conta> dal) =>
            {
                return Results.Ok(dal.Read());
            });

            app.MapPost("/Contas", ([FromServices] DAL<Conta> dal,
                [FromBody] Conta conta) =>
            {
                dal.Create(conta);
                return Results.Ok();
            });

            app.MapPut("/Contas", ([FromServices] DAL<Conta> dal,
                [FromBody] Conta conta) =>
            {
                var contaToEdit = dal.ReadBy(c => c.id == conta.id);

                if (contaToEdit is null)
                    return Results.NotFound();

                contaToEdit.nome = conta.nome;
                contaToEdit.saldo = conta.saldo;
                contaToEdit.tipo = conta.tipo;
                contaToEdit.instituicao = conta.instituicao;

                dal.Update(contaToEdit);

                return Results.Ok();
            });

            app.MapDelete("/Contas/{id}", ([FromServices] DAL<Conta> dal,
                int id) =>
            {
                var conta = dal.ReadBy(dal => dal.id == id);

                if (conta is null)
                    return Results.NotFound();

                dal.Delete(conta);
                return Results.Ok();
            });
        }
    }
}
