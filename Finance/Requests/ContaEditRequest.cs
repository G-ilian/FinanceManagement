namespace Finance.Requests
{
    public record ContaEditRequest(
        string nome,
        string tipo,
        double saldo,
        string instituicao,
        int id
        );
}
