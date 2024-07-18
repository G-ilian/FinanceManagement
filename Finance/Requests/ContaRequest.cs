namespace Finance.Requests
{
    public record ContaRequest(
        string nome,
        double saldo,
        string tipo,
        string instituicao
        );
}
