using Finance.Requests;
using Finance.Responses;
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

                return Results.Ok(EntityListToResponse(dal.Read()));
            });

            app.MapGet("/Contas/{id}", ([FromServices] DAL<Conta> dal,int id) =>
            {
                var hero = dal.ReadBy(dal => dal.id == id);
                if (hero is null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(hero));
            });

            app.MapPost("/Contas", ([FromServices] DAL<Conta> dal,
                [FromBody] ContaRequest contaRequest) =>
            {
                var conta = new Conta(contaRequest.nome, contaRequest.tipo, 
                    contaRequest.saldo, contaRequest.instituicao);

                dal.Create(conta);
                return Results.Ok();
            });

            app.MapPut("/Contas", ([FromServices] DAL<Conta> dal,
                [FromBody] ContaEditRequest contaEditRequest) =>
            {
                var contaToEdit = dal.ReadBy(c => c.id == contaEditRequest.id);

                if (contaToEdit is null)
                    return Results.NotFound();

                contaToEdit.nome = contaEditRequest.nome;
                contaToEdit.saldo = contaEditRequest.saldo;
                contaToEdit.tipo = contaEditRequest.tipo;
                contaToEdit.instituicao = contaEditRequest.instituicao;

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

        private static ICollection<ContaResponse> EntityListToResponse(IEnumerable<Conta> contaList)
        {
            return contaList.Select(c => EntityToResponse(c)).ToList();
        }

        private static ContaResponse EntityToResponse(Conta conta)
        {
            return new ContaResponse(conta.nome, conta.tipo, conta.saldo, conta.instituicao, conta.id);
        }
    }
}
