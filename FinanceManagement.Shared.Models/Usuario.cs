using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_console
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public virtual ICollection<Conta> contas { get; set; } = new List<Conta>();

        public Usuario(string nome,string cpf,string email,string telefone)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.email = email;
            this.telefone = telefone;
        }

        public Usuario() { }

        public override string ToString()
        {
            return $@"Propietario: {this.id}, {this.nome}, {this.cpf}, {this.email}, {this.telefone}";
        }

    }
}
