namespace Finance.Requests
{
    public record UsuarioRequest(
        string nome,
        string cpf,
        string email,
        string telefone,
        ICollection<ContaBasicRequest> contas = null
    );
}
