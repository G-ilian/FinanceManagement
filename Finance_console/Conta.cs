using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_console
{
    internal class Conta
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public double saldo { get; set; }
        public string instituicaoFinanceira { get; set; }

        public List<Transacao> transacaoes = new List<Transacao>();

        public Conta(int id, string nome, string tipo, double saldo, string instituicaoFinanceira)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.saldo = saldo;
            this.instituicaoFinanceira = instituicaoFinanceira;
        }

        public void adicionarTransacao(Transacao transacao)
        {
            this.transacaoes.Add(transacao);
        }

        public void listarTransacoes()
        {
            Console.WriteLine($"Transações da conta {this.nome}");
            foreach (var t in this.transacaoes)
            {
                Console.WriteLine(t);
            }
        }
        public override string ToString()
        {
            return $@"Conta: {this.id}, {this.nome}, {this.tipo}, {this.saldo}, {this.instituicaoFinanceira}";
        }
    }
}
