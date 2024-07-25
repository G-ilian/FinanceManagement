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
            var groupBuilder = app.MapGroup("Contas").RequireAuthorization().WithTags("Contas");

            groupBuilder.MapGet("", ([FromServices] DAL<Conta> dal) =>
            {

                return Results.Ok(EntityListToResponse(dal.Read()));
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Conta> dal,int id) =>
            {
                var hero = dal.ReadBy(dal => dal.id == id);
                if (hero is null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(hero));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Conta> dal,
                [FromServices] DAL<Investimentos> dalInv,
                [FromBody] ContaRequest contaRequest) =>
            {   
                var conta = new Conta(contaRequest.nome, contaRequest.tipo, 
                    contaRequest.saldo, contaRequest.instituicao){

                            investimentos = 
                            contaRequest.investimentos is not null ?
                            investimentoRequestConverter(contaRequest.investimentos,dalInv) : 
                            new List<Investimentos>()
                    
                    };


                dal.Create(conta);
                return Results.Ok();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Conta> dal,
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

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Conta> dal,
                int id) =>
            {
                var conta = dal.ReadBy(dal => dal.id == id);

                if (conta is null)
                    return Results.NotFound();

                dal.Delete(conta);
                return Results.Ok();
            });
        }

        private static ICollection<Investimentos> investimentoRequestConverter(
            ICollection<InvestimentoRequest> investimentos,
            DAL<Investimentos> dalInv )
        {
            var investimentosList = new List<Investimentos>();
            var readInvestimentos = dalInv.Read();
            foreach (var investimento in investimentos)
            {
                var investimentoEntity = RequestToEntity(investimento);
                var investimentoInDb = readInvestimentos.FirstOrDefault(i => i.corretora == investimentoEntity.corretora);
                if (investimentoInDb is not null)
                {
                    investimentosList.Add(investimentoInDb);
                }
                else
                {
                    investimentosList.Add(investimentoEntity);
                }
            }
            
            return investimentosList;
        }

        private static Investimentos RequestToEntity(InvestimentoRequest e)
        {
            return new Investimentos(e.descricao, e.
                valorInvestido, 
                e.tipoInvestimento,
                e.corretora, 
                e.riscoInvestimento, 
                e.rentabilidade);
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
