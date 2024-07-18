namespace Finance.Responses
{
    public record TransacaoResponse(
        double valor,
        DateTime dataTransacao,
        string descricao,
        string tipo,
        int id
    );
}
