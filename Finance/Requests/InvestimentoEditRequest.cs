namespace Finance.Requests
{
    public record InvestimentoEditRequest(
        string descricao,
        double valorInvestido,
        string tipoInvestimento,
        string corretora,
        string riscoInvestimento,
        double rentabilidade,
        int id
    );
}
