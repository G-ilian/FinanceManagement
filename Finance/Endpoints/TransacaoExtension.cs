using Finance.Requests;
using Finance.Responses;
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
                var transacaoList = dal.Read();
                if (transacaoList is null)
                    return Results.NotFound();

                return Results.Ok(EntityListToResponse(transacaoList));
            });

            app.MapPost("/Transacao", ([FromServices] DAL<Transacao> dal
                , [FromBody] TransacaoRequest transacaoRequest) => {
                    var transacao = new Transacao(transacaoRequest.valor, transacaoRequest.dataTransacao, 
                         transacaoRequest.descricao, transacaoRequest.tipo);
                    dal.Create(transacao);
                    return Results.Ok();
                });

            app.MapPut("/Transacao", ([FromServices] DAL<Transacao> dal, 
                [FromBody] TransacaoEditRequest transacaoEditRequest) => {
                var transacaoToEdit = dal.ReadBy(t => t.id == transacaoEditRequest.id);

                if (transacaoToEdit is null)
                    return Results.NotFound();

                transacaoToEdit.valor = transacaoEditRequest.valor;
                transacaoToEdit.dataTransacao = transacaoEditRequest.dataTransacao;
                transacaoToEdit.descricao = transacaoEditRequest.descricao;
                transacaoToEdit.tipo = transacaoEditRequest.tipo;

                dal.Update(transacaoToEdit);
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

        private static ICollection<TransacaoResponse> EntityListToResponse(IEnumerable<Transacao> transacaoList)
        {
            return transacaoList.Select(t => EntityToResponse(t)).ToList();
        }

        private static TransacaoResponse EntityToResponse(Transacao transacao)
        {
            return new TransacaoResponse(
                transacao.valor, 
                transacao.dataTransacao, 
                transacao.descricao ?? String.Empty, 
                transacao.tipo ?? String.Empty, 
                transacao.id,
                transacao.conta?.id ?? 00,
                transacao.conta?.nome ??"No linked account!");
        }
    }
}
