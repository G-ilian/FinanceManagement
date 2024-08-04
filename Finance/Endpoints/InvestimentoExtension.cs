using Finance.Requests;
using Finance.Responses;
using Finance_console;
using FinanceManagement.Shared.Data.DB;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Endpoints
{
    public static class InvestimentoExtension
    {
        public static void AddEndpointsInvestimento(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Investimentos").RequireAuthorization().WithTags("Investimentos");
            groupBuilder.MapGet("", ([FromServices] DAL<Investimentos> dal) =>
            {
                return Results.Ok(EntityListToResponse(dal.Read()));
            });

            groupBuilder.MapGet("{id}/contas", (
                [FromServices] DAL<Investimentos> dalInv,
                [FromServices] DAL<Conta> dalConta,
                int id) =>
            {
                var investimento = dalInv.ReadBy(c => c.id == id);
                if (investimento is null)
                    return Results.NotFound();

                var contas = dalConta.Read().Where(conta => conta.investimentos.Any(inv => inv.id == id)).ToList();

                var contasResponse = contas.Select(c => new ContaResponse(c.nome, c.tipo, c.saldo, c.instituicao, c.id)).ToList();
          
                return Results.Ok(contasResponse);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Investimentos> dal,
                [FromBody] InvestimentoRequest investimentoRequest) =>
            {
                var investimento = new Investimentos(investimentoRequest.descricao, investimentoRequest.valorInvestido,
                    investimentoRequest.tipoInvestimento, investimentoRequest.corretora, investimentoRequest.riscoInvestimento,
                    investimentoRequest.rentabilidade);

                dal.Create(investimento);
                return Results.Ok();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Investimentos> dal,
                [FromBody] InvestimentoEditRequest investimentoEditRequest) =>
            {
                var investimentoToEdit = dal.ReadBy(c => c.id == investimentoEditRequest.id);

                if (investimentoToEdit is null)
                    return Results.NotFound();

                investimentoToEdit.descricao = investimentoEditRequest.descricao;
                investimentoToEdit.valorInvestido = investimentoEditRequest.valorInvestido;
                investimentoToEdit.tipoInvestimento = investimentoEditRequest.tipoInvestimento;
                investimentoToEdit.corretora = investimentoEditRequest.corretora;
                investimentoToEdit.riscoInvestimento = investimentoEditRequest.riscoInvestimento;
                investimentoToEdit.rentabilidade = investimentoEditRequest.rentabilidade;

                dal.Update(investimentoToEdit);

                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Investimentos> dal,
                int id) =>
            {
                var investimentoToDelete = dal.ReadBy(c => c.id == id);

                if (investimentoToDelete is null)
                    return Results.NotFound();

                dal.Delete(investimentoToDelete);

                return Results.Ok();
            });
        }

        private static ICollection<InvestimentoResponse> EntityListToResponse(IEnumerable<Investimentos> invList)
        {
            return invList.Select(i => EntityToResponse(i)).ToList();
        }

        private static InvestimentoResponse EntityToResponse(Investimentos invs)
        {
            return new InvestimentoResponse(
                invs.descricao,
                invs.valorInvestido,
                invs.tipoInvestimento,
                invs.corretora,
                invs.riscoInvestimento,
                invs.rentabilidade,
                invs.id
                );
        }
    }
}
