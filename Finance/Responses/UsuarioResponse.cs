namespace Finance.Responses
{
    public record UsuarioResponse(
        string nome,
        string cpf,
        string email,
        string telefone,
        int id
    );
}
