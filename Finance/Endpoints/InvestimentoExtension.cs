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
            app.MapGet("/Investimentos", ([FromServices] DAL<Investimentos> dal) =>
            {
                return Results.Ok(EntityListToResponse(dal.Read()));
            });

            app.MapPost("/Investimentos", ([FromServices] DAL<Investimentos> dal,
                [FromBody] InvestimentoRequest investimentoRequest) =>
            {
                var investimento = new Investimentos(investimentoRequest.descricao, investimentoRequest.valorInvestido,
                    investimentoRequest.tipoInvestimento, investimentoRequest.corretora, investimentoRequest.riscoInvestimento,
                    investimentoRequest.rentabilidade);

                dal.Create(investimento);
                return Results.Ok();
            });

            app.MapPut("/Investimentos", ([FromServices] DAL<Investimentos> dal,
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

            app.MapDelete("/Investimentos/{id}", ([FromServices] DAL<Investimentos> dal,
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
