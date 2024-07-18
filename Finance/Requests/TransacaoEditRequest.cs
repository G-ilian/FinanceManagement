namespace Finance.Requests
{
    public record TransacaoEditRequest(
        double valor,
        DateTime dataTransacao,
        string descricao,
        string tipo,
        int id
    );
}
