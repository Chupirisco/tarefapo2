using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computaria
{
    class Vendedor
    {
        private string nome, cpf;

        public string GetNome()
        {
            return nome;
        }

        public string GetCpf()
        {
            return this.cpf;
        }
        public void SetCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Vendedor() { }
        public Vendedor(string nome, string cpf)
        {

            this.cpf = cpf;
            this.nome = nome;
        }
    }
}