namespace Finance.Requests
{
    public record TransacaoRequest(
        double valor,
        DateTime dataTransacao,
        string descricao,
        string tipo
    );
}
