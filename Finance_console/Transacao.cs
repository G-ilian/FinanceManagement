using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_console
{
    internal class Transacao
    {
        public int id { get; set; }
        public double valor { get; set; }
        public DateTime dataTransacao { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }

        public Transacao(int id, double valor, DateTime dataTransacao, string descricao, string tipo)
        {
            this.id = id;
            this.valor = valor;
            this.dataTransacao = dataTransacao;
            this.descricao = descricao;
            this.tipo = tipo;
        }

        public override string ToString()
        {
            return $@"Transacao: {this.id}, {this.valor}, {this.dataTransacao}, {this.descricao}, {this.tipo}";
        }
    }
}
