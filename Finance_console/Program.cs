

using Finance_console;

Dictionary<string, Conta> contasDict = new Dictionary<string, Conta>();

bool sair = false;

while (!sair)
{
    Console.WriteLine("--- BEM VINDO AO SISTEMA DE GERENCIAMENTO DE FINANÇAS ---\n");
    Console.WriteLine("1 - Adicionar conta");
    Console.WriteLine("2 - Adicionar transação");
    Console.WriteLine("3 - Listar transações");
    Console.WriteLine("4 - Sair\n");
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
            Console.WriteLine("Obrigado por utilizar!");
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;

        
    }



}

void ListarTransacoes()
{
    if(contasDict.Count == 0)
    {
        Console.WriteLine("Nenhuma conta registrada");
        return;
    }
    else
    {   
        Console.WriteLine("Listando transações da conta");
        foreach (var conta in contasDict.Values)
        {
            conta.listarTransacoes();
        }
    }

}

void RegistrarTransacao()
{
    Console.Clear();
    Console.WriteLine("Registro de transações /n");

    Random random = new Random();
    int idTransacao = random.Next(1000, 10000); // Gera um número entre 1000 e 9999
    Console.WriteLine("Informe o nome da conta: ");
    String nome = Console.ReadLine();

    if (contasDict.ContainsKey(nome))
    {
        Console.WriteLine("Informe o valor da transação: ");
        double valor = double.Parse(Console.ReadLine());
        Console.WriteLine("Informe a data da transação: ");
        DateTime dataTransacao = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Informe a descrição da transação: ");
        String descricao = Console.ReadLine();
        Console.WriteLine("Informe o tipo da transação: ");
        String tipo = Console.ReadLine();

        Transacao transacao = new Transacao(idTransacao, valor, dataTransacao, descricao, tipo);
        contasDict[nome].adicionarTransacao(transacao);
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

    Conta conta = new Conta(contasDict.Count + 1, nome, tipo, saldo, instituicaoFinanceira);
    contasDict.Add(nome, conta);

    Console.WriteLine("Conta registrada com sucesso!");
}