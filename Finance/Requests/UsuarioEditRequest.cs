namespace Finance.Requests
{
    public record UsuarioEditRequest(
        string nome,
        string cpf,
        string email,
        string telefone,
        int id
    );
}
