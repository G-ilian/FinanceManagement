namespace Finance.Requests
{
    public record InvestimentoRequest(
        string descricao,
        double valorInvestido,
        string tipoInvestimento,
        string corretora,
        string riscoInvestimento,
        double rentabilidade
        );
}
