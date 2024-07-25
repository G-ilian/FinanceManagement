namespace Finance.Responses
{
    public record InvestimentoResponse(
            string descricao,
            double valorInvestido,
            string tipoInvestimento,
            string corretora,
            string riscoInvestimento,
            double rentabilidade,
            int id
        );
}
