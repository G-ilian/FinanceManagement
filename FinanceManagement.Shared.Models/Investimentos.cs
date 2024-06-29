using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_console
{
    public class Investimentos
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public double valorInvestido { get; set; }
        public string tipoInvestimento { get; set; }
        public string corretora { get; set; }

        public string riscoInvestimento { get; set; }
        public double rentabilidade { get; set; }

        public Investimentos(int id, string descricao, double valorInvestido, string tipoInvestimento, string corretora, string riscoInvestimento, double rentabilidade)
        {
            this.id = id;
            this.descricao = descricao;
            this.valorInvestido = valorInvestido;
            this.tipoInvestimento = tipoInvestimento;
            this.corretora = corretora;
            this.riscoInvestimento = riscoInvestimento;
            this.rentabilidade = rentabilidade;
        }

        public override string ToString()
        {
            return $@"Investimento: {this.id}, {this.descricao}, {this.valorInvestido}, {this.tipoInvestimento}, {this.corretora}, {this.riscoInvestimento}, {this.rentabilidade}";
        }
    }
}
