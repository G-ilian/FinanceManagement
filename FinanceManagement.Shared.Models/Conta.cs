﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_console
{
    public class Conta
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public double saldo { get; set; }
        public string instituicao { get; set; }
        public virtual ICollection<Transacao> transacaoes { get; set; } = new List<Transacao>();
        public virtual ICollection<Investimentos> investimentos { get; set; }
        public virtual Usuario? usuario { get; set; }

        public Conta(string nome, string tipo, double saldo, string instituicao)
        {
            this.nome = nome;
            this.tipo = tipo;
            this.saldo = saldo;
            this.instituicao = instituicao;
        }

        public Conta(string nome)
        {
            this.nome = nome;
        }
        public void adicionarTransacao(Transacao transacao)
        {
            transacaoes.Add(transacao);
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
            return $@"DADOS DA CONTA 
                    ID: {this.id}, 
                    Nome: {this.nome}, 
                    Tipo: {this.tipo}, 
                    Saldo: {this.saldo},
                    Instituicão: {this.instituicao}";
        }
    }
}
