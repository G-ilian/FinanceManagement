namespace Finance.Responses
{
    public record ContaResponse(
        string nome,
        string tipo,
        double saldo,
        string instituicao,
        int id
    );
}
