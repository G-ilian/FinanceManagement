

using Finance_console;
using FinanceManagement.Shared.Data.DB;
using System.Threading.Channels;


var contaDAL = new ContaDAL(new FinanceContext());

bool sair = false;

while (!sair)
{
    Console.WriteLine("--- BEM VINDO AO SISTEMA DE GERENCIAMENTO DE FINANÇAS ---\n");
    Console.WriteLine("1 - Adicionar conta");
    Console.WriteLine("2 - Adicionar transação");
    Console.WriteLine("3 - Listar transações");
    Console.WriteLine("4 - Cadastrar Investimento");
    Console.WriteLine("5 - Sair\n");
    Console.WriteLine("Informe sua escolha: ");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            RegistrarConta();
            break;
        case 2:
            RegistrarTransacao();
            break;
        case 3:
            ListarTransacoes();
            break;
        case 4:
            CadastrarInvestimento();
            break;
        case 5:
            Console.WriteLine("Obrigado por utilizar!");
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;

        
    }



}

void CadastrarInvestimento()
{
    Console.Clear();
    Console.WriteLine("Registro de investimentos /n");
    if (contaDAL.Read().Equals(null))
    {
        Console.WriteLine("Nenhuma conta registrada");
        return;
    }
    else
    {
        ListarContas();
        Console.WriteLine("/n");
        Console.WriteLine("Informe o nome da conta: ");
        String nome = Console.ReadLine();
        
        if (ContaExiste(nome))
        {
            Console.WriteLine("Informe a descrição do investimento: ");
            String descricao = Console.ReadLine();
            Console.WriteLine("Informe o valor investido: ");
            double valorInvestido = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o tipo do investimento: ");
            String tipoInvestimento = Console.ReadLine();
            Console.WriteLine("Informe a corretora: ");
            String corretora = Console.ReadLine();
            Console.WriteLine("Informe o risco do investimento: ");
            String riscoInvestimento = Console.ReadLine();
            Console.WriteLine("Informe a rentabilidade: ");
            double rentabilidade = double.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Conta não encontrada");
        }

    }
}

void ListarContas()
{
    foreach (var conta in contaDAL.Read())
    {
        conta.ToString();
    }
}

void ListarTransacoes()
{
    if(contaDAL.Read().Equals(null))
    {
        Console.WriteLine("Nenhuma conta registrada");
        return;
    }
    else
    {   
        Console.WriteLine("Listando transações da conta");
        foreach (var conta in contaDAL.Read())
        {
            conta.listarTransacoes();
        }
    }

}

void RegistrarTransacao()
{
    Console.Clear();
    Console.WriteLine("Registro de transações /n");

    Console.WriteLine("Informe o nome da conta: ");
    String nome = Console.ReadLine();

    if (ContaExiste(nome))
    {
        Console.WriteLine("Informe o valor da transação: ");
        double valor = double.Parse(Console.ReadLine());
        Console.WriteLine("Informe a data da transação: ");
        DateTime dataTransacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Informe a descrição da transação: ");
        String descricao = Console.ReadLine();
        Console.WriteLine("Informe o tipo da transação: ");
        String tipo = Console.ReadLine();

        Transacao transacao = new Transacao(valor, dataTransacao, descricao, tipo);

        TransacaoDAL transacaoDAL = new TransacaoDAL(new FinanceContext());
        transacaoDAL.Create(transacao);
    }
    else
    {
        Console.WriteLine("Conta não encontrada");
    }
}

void RegistrarConta()
{
    Console.Clear();
    Console.WriteLine("Registro de contas /n");
    Console.WriteLine("Informe o nome da conta: ");
    String nome = Console.ReadLine();
    Console.WriteLine("Informe o tipo da conta: ");
    String tipo = Console.ReadLine();
    Console.WriteLine("Informe o saldo da conta: ");
    double saldo = double.Parse(Console.ReadLine());
    Console.WriteLine("Informe a instituição financeira: ");
    String instituicaoFinanceira = Console.ReadLine();

    Conta conta = new Conta(nome, tipo, saldo, instituicaoFinanceira);
    contaDAL.Create(conta);

    Console.WriteLine("Conta registrada com sucesso!");
}

bool ContaExiste(String nome)
{
    Console.WriteLine("Buscando a conta....");
    return contaDAL.ReadyByName(nome) != null;
}