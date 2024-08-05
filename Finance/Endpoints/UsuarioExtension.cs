using Finance.Requests;
using Finance.Responses;
using Finance_console;
using FinanceManagement.Shared.Data.DB;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Endpoints
{
    public static class UsuarioExtension
    {
        public static void AddEnpointsUsuario(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Usuarios").RequireAuthorization().WithTags("Usuarios");

            groupBuilder.MapGet("", ([FromServices] DAL<Usuario> dal) =>
            {
                return Results.Ok(EntityListToResponse(dal.Read()));
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Usuario> dal, int id) =>
            {
                var usuario = dal.ReadBy(dal => dal.id == id);
                if (usuario is null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(usuario));
            });

            groupBuilder.MapGet("{id}/contas", (
                            [FromServices] DAL<Usuario> dalUser,
                            [FromServices] DAL<Conta> dalConta,
            int id) =>
            {
                var usuario = dalUser.ReadBy(user => user.id == id);

                if (usuario is null)
                    return Results.NotFound();

                var contas = dalConta.Read().Where(conta => conta.usuario.Equals(usuario)).ToList();

                var contasResponse = contas.Select(c => new ContaResponse(c.nome, c.tipo, c.saldo, c.instituicao, c.id)).ToList();

                return Results.Ok(contasResponse);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Usuario> dal,DAL<Conta>dalConta, [FromBody] UsuarioRequest usuarioRequest) =>
            {
                var usuario = new Usuario(usuarioRequest.nome, usuarioRequest.cpf, usuarioRequest.email, usuarioRequest.telefone)
                {
                    contas = usuarioRequest.contas is not null ?
                    ContasRequestConverter(usuarioRequest.contas, dalConta) :
                    new List<Conta>()
                };
                dal.Create(usuario);
                return Results.Ok();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Usuario> dal, [FromBody] UsuarioEditRequest usuarioEditRequest) =>
            {
                var usuarioToEdit = dal.ReadBy(c => c.id == usuarioEditRequest.id);

                if (usuarioToEdit is null)
                    return Results.NotFound();

                usuarioToEdit.nome = usuarioEditRequest.nome;
                usuarioToEdit.cpf = usuarioEditRequest.cpf;
                usuarioToEdit.email = usuarioEditRequest.email;
                usuarioToEdit.telefone = usuarioEditRequest.telefone;

                dal.Update(usuarioToEdit);

                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Usuario> dal, int id) =>
            {
                var usuario = dal.ReadBy(dal => dal.id == id);
                if (usuario is null)
                    return Results.NotFound();
                dal.Delete(usuario);
                return Results.Ok();
            });
        }

        private static ICollection<Conta> ContasRequestConverter(
            ICollection<ContaBasicRequest> contas, 
            DAL<Conta> dalConta)
        {
            var contasList = new List<Conta>();
            var readContas = dalConta.Read();

            foreach (var conta in contas)
            {
                var contaEntity = RequestToEntity(conta);
                var contaInDb = readContas.FirstOrDefault(conta => conta.nome == contaEntity.nome);
                if (contaInDb is not null)
                {
                    contasList.Add(contaInDb);
                }
                else
                {
                    contasList.Add(contaEntity);
                }

            }

            return contasList;
        }

        private static Conta RequestToEntity(ContaBasicRequest conta)
        {
            return new Conta(conta.nome);
        }

        private static ICollection<UsuarioResponse> EntityListToResponse(IEnumerable<Usuario> userList)
        {
            return userList.Select(user => EntityToResponse(user)).ToList();

        }

        private static UsuarioResponse EntityToResponse(Usuario user)
        {
            return new UsuarioResponse(user.nome, user.cpf, user.email, user.telefone, user.id);
        }

    }
}
