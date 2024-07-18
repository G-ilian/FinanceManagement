using Finance_console;
using FinanceManagement.Shared.Data.DB;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Endpoints
{
    public static class TransacaoExtension
    {
        public static void AddEndpointsTransacao(this WebApplication app)
        {

            app.MapGet("/Transacao", ([FromServices] DAL<Transacao> dal) =>
            {
                return Results.Ok(dal.Read());
            });

            app.MapPost("/Transacao", ([FromServices] DAL<Transacao> dal
                , [FromBody] Transacao transacao) => {

                    dal.Create(transacao);
                    return Results.Ok();
                });

            app.MapPut("/Transacao", ([FromServices] DAL<Transacao> dal, [FromBody] Transacao transacao) => {
                var transacaoToEdit = dal.ReadBy(t => t.id == transacao.id);

                if (transacaoToEdit is null)
                    return Results.NotFound();

                transacaoToEdit.valor = transacao.valor;
                transacaoToEdit.dataTransacao = transacao.dataTransacao;
                transacaoToEdit.descricao = transacao.descricao;
                transacaoToEdit.tipo = transacao.tipo;


                dal.Update(transacao);
                return Results.Ok();
            });

            app.MapDelete("/Transacao/{id}", ([
                FromServices] DAL<Transacao> dal, int id) =>
            {
                var transacao = dal.ReadBy(dal => dal.id == id);

                if (transacao is null)
                    return Results.NotFound();
                dal.Delete(transacao);
                return Results.Ok();
            });
        }
    }
}
